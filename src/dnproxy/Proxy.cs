using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Windows.Forms;
using System.Xml;

#if DEBUG
using System.Text.RegularExpressions;
#endif

//using Ukagaka.NET.Interfaces;

namespace D.N
{
   /// <summary>
    /// 絶対パスを元に新しいアプリケーションドメインを作成し、
    /// ベースウェアからGenerator/Manager/Userクラスへデータをリモート中継します。
    /// </summary>
    internal static class Proxy
    {
        /// <summary>
        /// アプリケーションドメインを保持します。
        /// </summary>
        private static AppDomain domain;

        /// <summary>
        /// ユーティリティインスタンスを保持します。
        /// </summary>
        private static object utility;

        /// <summary>
        /// ユーザーインスタンスを保持します。
        /// </summary>
        private static object instance;

        /// <summary>
        /// ユーザアセンブリのプロトコルタイプを保持します。
        /// </summary>
        private static string protocol;

        /// <summary>
        /// リモート通信用のインターフェイスクラス名です。
        /// </summary>
        private const string REMOTE_INTERFACE = "Ukagaka.NET.Interfaces";

        /// <summary>
        /// ジェネレータアセンブリファイル名です。
        /// </summary>
        private const string GENERATOR_NAME = "dngen.dll";

        /// <summary>
        /// ジェネレータアセンブリの通信用クラス名です。
        /// </summary>
        private const string GENERATOR_MAINCLASS = "D.N.Generator";

        /// <summary>
        /// ユーティリティアセンブリファイル名です。
        /// </summary>
        private const string UTILITY_NAME = "dnutil.dll";

        /// <summary>
        /// ユーティリティアセンブリの通信用クラス名です。
        /// </summary>
        private const string UTILITY_MAINCLASS = "D.N.Manager";

        /// <summary>
        /// リモートメソッド情報構造体
        /// </summary>
        private struct RemoteMethods
        {
            public MethodInfo GetVersion;
            public MethodInfo Load;
            public MethodInfo Unload;
            public MethodInfo Request;
            public MethodInfo Notify;
            public MethodInfo Configure;
            public MethodInfo Execute;
            public MethodInfo GetUrl;
            public MethodInfo GetSchedule;
            public MethodInfo GetUrlPost;
        }

        /// <summary>
        /// リモートメソッド情報構造体を保持します。
        /// </summary>
        private static RemoteMethods remote;

#if DEBUG
        private static FileSystemWatcher fsw;
        private delegate void FileSystemEventDelegate(object sender, FileSystemEventArgs args);
        private static readonly object thisLock = new object();
        private static bool reload;
#endif

        /// <summary>
        /// 設定ファイルのアプリケーション設定にアクセスするXMLパスを返します。
        /// </summary>
        /// <param name="doc">設定ファイルのXMLドキュメント。</param>
        /// <returns>設定ファイルのアプリケーション設定にアクセスするパス。</returns>
        private static XmlElement configSettingsElement(XmlDocument doc)
        {
            return doc["configuration"]["applicationSettings"]["D.N.Properties.Settings"];
        }

        /// <summary>
        /// 設定ファイルのアプリケーション設定を取得します。
        /// </summary>
        /// <param name="element">アプリケーション設定のXMLエレメント。</param>
        /// <param name="key">取得したい設定名。</param>
        /// <returns><c>key</c>で示される設定値。見つからない場合には、null。</returns>
        private static string getAssemblyData(XmlElement element, string key)
        {
            foreach (XmlNode node in element) {
                if (node.Name == "setting") {
                    foreach (XmlAttribute attr in node.Attributes) {
                        if (attr.Name == "name" && attr.Value == key) {
                            foreach (XmlNode target in node.ChildNodes) {
                                if (target.Name == "value") {
                                    return target.FirstChild.Value;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 初期化時に必要な処理を行います。
        /// </summary>
        /// <remarks>
        /// アプリケーション構成ファイルから必要な情報を取得、
        /// 伺かインターフェイスを読み込みインターフェイスの取得、
        /// 新たなアプリケーションドメインを作成、そのアプリケーションドメインで
        /// dngenとdnutilの実行し、ユーザーインスタンスを作成します。
        /// </remarks>
        /// <returns>処理の成功時には、true。</returns>
        private static bool initialize()
        {
#if !DEBUG
            string selfpath = Assembly.GetExecutingAssembly().Location;
#else
            Assembly selfasm = Assembly.GetExecutingAssembly();
            string selfpath = Path.GetDirectoryName(selfasm.Location)
                + Path.DirectorySeparatorChar + selfasm.FullName.Substring(
                    0, selfasm.FullName.IndexOf(',')) + ".dll";
#endif
            if (Proxy.domain != null) {
                return true;
            }
            string appdir = AppDomain.CurrentDomain.BaseDirectory;
            string selfdir = Path.GetDirectoryName(selfpath) + Path.DirectorySeparatorChar;

            // アプリケーション設定の取得
            string appconf = selfpath + ".config";
            string privateBinPath = null;
            string assemblyName   = null;
            string mainClass      = null;
            if (File.Exists(appconf)) {
                // 依存アセンブリの情報を設定
                XmlDocument doc = new XmlDocument();
                doc.Load(appconf);
                // アプリケーション設定の取得
                XmlElement element = Proxy.configSettingsElement(doc);
                Proxy.protocol = Proxy.getAssemblyData(element, "Protocol");
                privateBinPath = Proxy.getAssemblyData(element, "PrivateBinPath");
                assemblyName   = Proxy.getAssemblyData(element, "AssemblyName");
                mainClass      = Proxy.getAssemblyData(element, "MainClass");
            }

            // アプリケーションドメインの設定
            AppDomainSetup setup = new AppDomainSetup();
            setup.ConfigurationFile = appconf;
            setup.ApplicationBase   = selfdir;
            setup.PrivateBinPath    = privateBinPath;

            // アプリケーションドメインを作成して記憶
            Proxy.domain = AppDomain.CreateDomain(selfpath, null, setup);

            // リモートインターフェイスのロードと割り当て
            try {
                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(
                    delegate(object sender, ResolveEventArgs args) {
                        string dll = selfdir + args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
                        return Assembly.LoadFrom(dll);
                    });

                Assembly assembly = Assembly.LoadFrom(selfdir + Proxy.REMOTE_INTERFACE + ".dll");
                Proxy.remote.GetVersion = assembly.GetType(Proxy.REMOTE_INTERFACE + ".IGetVersion").GetMethod(
                    "getversion", new Type[] { typeof(int).MakeByRefType() });
                Proxy.remote.Load = assembly.GetType(Proxy.REMOTE_INTERFACE + ".ILoad").GetMethod(
                    "load", new Type[] { typeof(IntPtr), typeof(int) });
                Proxy.remote.Unload = assembly.GetType(Proxy.REMOTE_INTERFACE + ".IUnload").GetMethod(
                    "unload");
                Proxy.remote.Request = assembly.GetType(Proxy.REMOTE_INTERFACE + ".IRequest").GetMethod(
                    "request", new Type[] { typeof(IntPtr), typeof(int).MakeByRefType() });
                Proxy.remote.Notify = assembly.GetType(Proxy.REMOTE_INTERFACE + ".INotify").GetMethod(
                    "notify", new Type[] { typeof(IntPtr), typeof(int).MakeByRefType() });
                Proxy.remote.Configure = assembly.GetType(Proxy.REMOTE_INTERFACE + ".IConfigure").GetMethod(
                    "configure", new Type[] { typeof(IntPtr) });
                Proxy.remote.Execute = assembly.GetType(Proxy.REMOTE_INTERFACE + ".IExecute").GetMethod(
                    "execute", new Type[] { typeof(IntPtr), typeof(int).MakeByRefType() });
                Proxy.remote.GetUrl = assembly.GetType(Proxy.REMOTE_INTERFACE + ".IGetUrl").GetMethod(
                    "geturl", new Type[] { typeof(int).MakeByRefType(), typeof(int), typeof(int), typeof(int) });
                Proxy.remote.GetSchedule = assembly.GetType(Proxy.REMOTE_INTERFACE + ".IGetSchedule").GetMethod(
                    "getschedule", new Type[] { typeof(IntPtr), typeof(int).MakeByRefType() });
                Proxy.remote.GetUrlPost = assembly.GetType(Proxy.REMOTE_INTERFACE + ".IGetUrlPost").GetMethod(
                    "geturlpost", new Type[] { typeof(IntPtr), typeof(int).MakeByRefType(), typeof(int).MakeByRefType() });
            } catch (Exception e) {
                MessageBox.Show(e.GetType().FullName + "\n" + e.Message);
            }

            // ジェネレータの処理
            string genpath = selfdir + Proxy.GENERATOR_NAME;
            if (File.Exists(genpath)) {
                try {
                    string genconf = Path.ChangeExtension(genpath, ".ini");
                    object generator = Proxy.domain.CreateInstanceFromAndUnwrap(
                        genpath, Proxy.GENERATOR_MAINCLASS);

                    IntPtr h = Marshal.StringToHGlobalAnsi(appconf);
                    int len  = appconf.Length;
                    Proxy.remote.Load.Invoke(generator, new object[] { h, len });
                    h = Marshal.StringToHGlobalAnsi(genconf);
                    len = genconf.Length;
                    Proxy.remote.Execute.Invoke(generator, new object[] { h, len });
                } catch (Exception e) {
                    MessageBox.Show(e.GetType().FullName + "\n" + e.Message);
                }
            }

            //ユーティリティの処理
            string utilpath = selfdir + Proxy.UTILITY_NAME;
            if (File.Exists(utilpath)) {
                try {
                    Proxy.utility = Proxy.domain.CreateInstanceFromAndUnwrap(
                        utilpath, Proxy.UTILITY_MAINCLASS);
                    Proxy.remote.Load.Invoke(Proxy.utility, new object[] { IntPtr.Zero, 0 });
                    object generator = Proxy.domain.CreateInstanceFromAndUnwrap(
                        utilpath, Proxy.GENERATOR_MAINCLASS);
                    string config = Path.ChangeExtension(selfpath, ".ini");
                    IntPtr h = Marshal.StringToHGlobalAnsi(config);
                    int len  = config.Length;
                    Proxy.remote.Execute.Invoke(generator, new object[] { h, len });
                } catch (Exception e) {
                    MessageBox.Show(e.GetType().FullName + "\n" + e.Message);
                }
            }

            // ユーザーインスタンスの作成
            try {
                Proxy.instance = Proxy.domain.CreateInstanceFromAndUnwrap(
                    selfdir + assemblyName, mainClass);
            } catch (Exception e) {
                MessageBox.Show(e.GetType().FullName + "\n" + e.Message);
                return false;
            }
#if DEBUG
            Proxy.reload = false;

            FileSystemWatcher fsw = new FileSystemWatcher(selfdir);
            fsw.Filter = "*.cs";
            fsw.NotifyFilter =
                NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            FileSystemEventDelegate fileSystemEventDelegate =
                delegate(object sender, FileSystemEventArgs args) {
                    lock (thisLock) { Proxy.reload = true; }
                };
            fsw.Changed += new FileSystemEventHandler(fileSystemEventDelegate);
            fsw.EnableRaisingEvents = true;
            fsw.IncludeSubdirectories = true;

            Proxy.fsw = fsw;
#endif
            return true;
        }

        /// <summary>
        /// 終了時に必要な処理を行います。
        /// </summary>
        /// <remarks>
        /// ユーティリティのアンロード、作成したアプリケーションドメインと関連するオブジェクト解放します。
        /// </remarks>
        /// <returns>処理の成功時には、true。</returns>
        private static bool finalize()
        {
#if DEBUG
            if (Proxy.fsw != null) {
                Proxy.fsw.Dispose();
                Proxy.fsw = null;
                Proxy.reload = false;
            }
#endif
            if (Proxy.utility != null) {
                Proxy.remote.Unload.Invoke(Proxy.utility, null);
                Proxy.utility = null;
            }
            if (Proxy.instance != null) {
                Proxy.instance = null;
            }
            if (Proxy.domain != null) {
                AppDomain.Unload(Proxy.domain);
                Proxy.domain = null;
            }
            GC.Collect();

            return true;
        }

        /// <summary>
        /// チェックツールからの呼びだし専用です。
        /// このメソッドはエクスポートされます。
        /// </summary>
        /// <remarks>
        /// チェックツールは<a href="http://umeici.hp.infoseek.co.jp/">再配布、自作ソフトへの同梱自由</a>からダウンロードできます。
        /// </remarks>
        /// <param name="hWnd">チェックツールのウィンドウハンドル。</param>
        /// <returns>処理成功時には、true。</returns>
        private static bool logsend(int hWnd)
        {
            return true;
        }

        /// <summary>
        /// プロトコルの種類とバージョンの確認要求時に呼ばれます。
        /// このメソッドはエクスポートされます。
        /// </summary>
        /// <remarks>
        /// <para>PLUGIN/1.0, HEADLINE/1.1, SCHEDULE/1.0, SCHEDULE/2.0</para>
        /// </remarks>
        /// <param name="len">プロトコル文字列の長さ。</param>
        /// <returns>プロトコル文字列を格納したメモリへのポインタ。</returns>
        private static IntPtr getversion(ref int len)
        {
            if (!Proxy.initialize()) {
                len = 0;
                return IntPtr.Zero;
            }
            try {
                object[] args = new object[] { len };
                IntPtr h = (IntPtr) Proxy.remote.GetVersion.Invoke(Proxy.instance, args);
                len = (int) args[1];
                return h;
            } catch (TargetException) {
                try {
                    len = Proxy.protocol.Length;
                    return Marshal.StringToHGlobalAnsi(Proxy.protocol);
                } catch {
                    string response = Proxy.protocol + " 500 Internal Server Error\r\n\r\n";
                    len = response.Length;
                    return Marshal.StringToHGlobalAnsi(response);
                }
            } catch {
                len = 0;
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// ロード時に呼ばれます。
        /// このメソッドはエクスポートされます。
        /// </summary>
        /// <remarks>
        /// <para>全てのアセンブリ</para>
        /// </remarks>
        /// <param name="h">パス文字列を格納したメモリへのポインタ。</param>
        /// <param name="len">パス文字列の長さ。</param>
        /// <returns>処理の成功時には、true。</returns>
        private static bool load(IntPtr h, int len)
        {
            if (!Proxy.initialize()) {
                Marshal.FreeHGlobal(h);
                return false;
            }
            try {
                return (bool) Proxy.remote.Load.Invoke(Proxy.instance, new object[] { h, len });
            } catch (TargetException) {
                Marshal.FreeHGlobal(h);
                return false;
            } catch {
                return false;
            }
        }

        /// <summary>
        /// アンロード時に呼ばれます。
        /// このメソッドはエクスポートされます。
        /// </summary>
        /// <remarks>
        /// <para>全てのアセンブリ</para>
        /// </remarks>
        /// <returns>処理の成功時には、true。</returns>
        private static bool unload()
        {
            bool result = false;
            try {
                result = (bool) Proxy.remote.Unload.Invoke(Proxy.instance, null);
            } catch (TargetException) {
                result = false;
            } catch {
                result = false;
            }
            if (!Proxy.finalize()) {
                return false;
            }
            return result;
        }

        /// <summary>
        /// リクエストがきた時に呼ばれます。
        /// このメソッドはエクスポートされます。
        /// </summary>
        /// <remarks>
        /// <para>SHIORI/2.X, SHIORI/3.0, MAKOTO/2.0, SAORI/1.0, PLUGIN/2.0, SCHEDULE/2.0</para>
        /// </remarks>
        /// <param name="h">リクエスト文字列を格納したメモリへのポインタ。</param>
        /// <param name="len">リクエスト文字列の長さ。</param>
        /// <returns>レスポンス文字列を格納したメモリへのポインタ。</returns>
        private static IntPtr request(IntPtr h, ref int len)
        {
#if !DEBUG
            try {
                object[] args = new object[] { h, len };
                h = (IntPtr) Proxy.remote.Request.Invoke(Proxy.instance, args);
                len = (int) args[1];
                return h;
            } catch (TargetException) {
                Marshal.FreeHGlobal(h);
                string response = Proxy.protocol + " 500 Internal Server Error\r\n\r\n";
                len = response.Length;
                return Marshal.StringToHGlobalAnsi(response);
            } catch {
                string response = Proxy.protocol + " 500 Internal Server Error\r\n\r\n";
                len = response.Length;
                return Marshal.StringToHGlobalAnsi(response);
            }
#else
            string selfpath = Assembly.GetExecutingAssembly().Location;
            try {
            } catch (NullReferenceException) {
                Marshal.FreeHGlobal(h);
                string response = "UNKNOWN/1.0 500 Internal Server Error\r\n\r\n";
                len = response.Length;
                return Marshal.StringToHGlobalAnsi(response);
            }
            if (!Proxy.reload) {
                object[] args = new object[] { h, len };
                h = (IntPtr) Proxy.remote.Request.Invoke(Proxy.instance, args);
                len = (int) args[1];
                return h;
            } else {   // Requests Reloading
                string request = Marshal.PtrToStringAnsi(h, len);
                string[] lines = Regex.Split(request, "\r\n");
                if (lines[0].IndexOf("SHIORI") == -1) { // NOT SHIORI Protocol
                    Proxy.reload = false;
                    object[] args = new object[] { h, len };
                    h = (IntPtr) Proxy.remote.Request.Invoke(Proxy.instance, args);
                    len = (int) args[1];
                    return h;
                } else if (lines[0].IndexOf("GET") != 0) {  // NOT GET Request
                    object[] args = new object[] { h, len };
                    h = (IntPtr) Proxy.remote.Request.Invoke(Proxy.instance, args);
                    len = (int) args[1];
                    return h;
                } else {    // GET SHIORI/3.0 or GET XXXX SHIORI/2.x Request
                    Regex reID = new Regex(@"^(ID|Event)\s*:\s*(On.+)\s*", RegexOptions.Compiled);
                    Match m;
                    string evname = null;
                    int count = 0;
                    foreach (string line in lines) {
                        if (line.Length != 0 && (m = reID.Match(line)).Success) {
                            evname = m.Groups[2].Value;
                            break;
                        }
                        count++;
                    }
                    if (evname == null) {   // NOT an event request
                        object[] args = new object[] { h, len };
                        h = (IntPtr) Proxy.remote.Request.Invoke(Proxy.instance, args);
                        len = (int) args[1];
                        return h;
                    } else {    // "OnXXXX" event
                        lines[count] = lines[count].Replace(evname, "OnGhostChanging");
                        request = String.Join("\r\n", lines);
                        object[] args = new object[] { Marshal.StringToHGlobalAnsi(request), request.Length };
                        h = (IntPtr) Proxy.remote.Request.Invoke(Proxy.instance, args);
                        len = (int) args[1];

                        string response = Marshal.PtrToStringAnsi(h, len);
                        Marshal.FreeHGlobal(h);
                        string name = null;
                        // gets my ghost name from my descript.txt for reloading by \![change,ghost]
                        using (StreamReader sr = new StreamReader(
                            Path.Combine(Path.GetDirectoryName(selfpath), "descript.txt"))) {
                            string line;
                            while ((line = sr.ReadLine()) != null) {
                                if (line.IndexOf("name") != -1) {
                                    int pos;
                                    if ((pos = line.IndexOf("//")) != -1) {
                                        line = line.Substring(0, pos);
                                    }
                                    if (line.Length == 0 || line.IndexOf(',') == -1) {
                                        continue;
                                    }
                                    string[] entry = line.Split(new char[] { ',' }, 2);
                                    string key = entry[0].Trim();
                                    string value = entry[1].Trim();
                                    if (key == "name") {
                                        name = value;
                                        break;
                                    }
                                }
                            }
                        }
                        if (name == null) {
                            name = "random";
                        }
                        lines = Regex.Split(response, "\r\n");
                        if (lines[0].IndexOf("200") == -1) {    // NOT response OK
                            lines[0] = "SHIORI/3.0 200 OK\r\nValue: \\![change,ghost," + name + "]";
                        } else {    // response OK
                            Regex reVal = new Regex(@"^Value\s*:\s*(.+)", RegexOptions.Compiled);
                            count = 0;
                            foreach (string line in lines) {
                                if (line.Length != 0 && reVal.Match(line).Success) {
                                    lines[count] = @"Value: \![change,ghost," + name + "]";
                                    break;
                                }
                                count++;
                            }
                        }
                        Proxy.reload = false;
                        response = String.Join("\r\n", lines);
                        len = response.Length;
                        return Marshal.StringToHGlobalAnsi(response);
                    }
                }
            }
#endif
        }
        /// <summary>
        /// 本体からイベントが通知されます。
        /// このメソッドはエクスポートされます。
        /// </summary>
        /// <remarks>
        /// <para>PLUGIN/1.0</para>
        /// </remarks>
        /// <param name="h">リクエスト文字列を格納したメモリへのポインタ。</param>
        /// <param name="len">リクエスト文字列の長さ。参照渡しされている理由は不明。</param>
        private static void notify(IntPtr h, ref int len)
        {
            try {
                object[] args = new object[] { h, len };
                Proxy.remote.Notify.Invoke(Proxy.instance, args);
                len = (int) args[1];
            } catch (TargetException) {
                Marshal.FreeHGlobal(h);
                len = 0;
                return;
            }
        }

        /// <summary>
        /// ポップアップメニュー上からプラグインが選択された時の処理を行います。
        /// このメソッドはエクスポートされます。
        /// </summary>
        /// <remarks>
        /// <para>PLUGIN/1.0</para>
        /// </remarks>
        /// <param name="hWnd">未文書化。恐らく本体のウィンドウハンドル。</param>
        private static void configure(IntPtr hWnd)
        {
            try {
                Proxy.remote.Configure.Invoke(Proxy.instance, new object[] { hWnd });
            } catch (TargetException) {
                return;
            }
        }

        /// <summary>
        /// ダウンロードしたヘッドラインを解析して結果を返します。
        /// このメソッドはエクスポートされます。
        /// </summary>
        /// <remarks>
        /// <para>HEADLINE/1.1</para>
        /// </remarks>
        /// <param name="h">ダウンロードされたファイルのパス文字列を格納したメモリへのポインタ。</param>
        /// <param name="len">パス文字列の長さ。</param>
        /// <returns>CR+LF を改行コードとする表示させたい文字列を格納したメモリへのポインタ。</returns>
        private static IntPtr execute(IntPtr h, ref int len)
        {
            try {
                object[] args = new object[] { h, len };
                h = (IntPtr) Proxy.remote.Execute.Invoke(Proxy.instance, args);
                len = (int) args[1];
                return h;
            } catch (TargetException) {
                Marshal.FreeHGlobal(h);
                len = 0;
                return IntPtr.Zero;
            } catch {
                len = 0;
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// スケジュールをセンスするためのURLを返します。
        /// このメソッドはエクスポートされます。
        /// </summary>
        /// <remarks>
        /// <para>SCHEDULE/1.0</para>
        /// </remarks>
        /// <param name="len">スケジュール用URLの長さを代入する。</param>
        /// <param name="year">未文書化。恐らく現在年。</param>
        /// <param name="month">未文書化。恐らく現在月。</param>
        /// <param name="day">未文書化。恐らく現在日。</param>
        /// <returns>
        /// <para>year,month,dayに相当するスケジュール用URLを格納したメモリへのポインタ。</para>
        /// </returns>
        private static IntPtr geturl(ref int len, int year, int month, int day)
        {
            try {
                object[] args = new object[] { len, year, month, day };
                IntPtr h = (IntPtr) Proxy.remote.GetUrl.Invoke(Proxy.instance, args);
                len = (int) args[0];
                return h;
            } catch (TargetException) {
                len = 0;
                return IntPtr.Zero;
            } catch {
                len = 0;
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// スケジュールを解析して返します。
        /// このメソッドはエクスポートされます。
        /// </summary>
        /// <remarks>
        /// <para>SCHEDULE/1.0</para>
        /// </remarks>
        /// <param name="h">指定されたURLから取得したHTMLファイルへの絶対パスを格納したメモリへのポインタ。</param>
        /// <param name="len">パス文字列の長さ。解析後の文字列の長さを代入する。</param>
        /// <returns>解析後の文字列を格納したメモリへのポインタ。</returns>
        private static IntPtr getschedule(IntPtr h, ref int len)
        {
            try {
                object[] args = new object[]{ h, len };
                h = (IntPtr) Proxy.remote.GetSchedule.Invoke(Proxy.instance, args);
                len = (int) args[1];
                return h;
            } catch (TargetException) {
                Marshal.FreeHGlobal(h);
                len = 0;
                return IntPtr.Zero;
            } catch {
                len = 0;
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// スケジュール投稿のためのURLとパラメタを返します。
        /// このメソッドはエクスポートされます。
        /// </summary>
        /// <remarks>
        /// <para>SCHEDULE/1.0</para>
        /// </remarks>
        /// <param name="h">getscheduleで説明した形式でスケジュールデータ文字列を格納したメモリへのポインタ。</param>
        /// <param name="len">スケジュールデータ文字列の長さ。スケジュール投稿用URL文字列の長さを代入する。</param>
        /// <param name="method">メソッド示す値を代入する。0でGET、1でPOST。</param>
        /// <returns>スケジュール投稿用URL文字列を格納したメモリへのポインタ。</returns>
        private static IntPtr geturlpost(IntPtr h, ref int len, ref int method)
        {
            try {
                object[] args = new object[] { h, len, method };
                h = (IntPtr) Proxy.remote.GetUrlPost.Invoke(Proxy.instance, args);
                len = (int) args[1];
                method = (int) args[2];
                return h;
            } catch (TargetException) {
                Marshal.FreeHGlobal(h);
                len = 0;
                method = 0;
                return IntPtr.Zero;
            } catch {
                len = 0;
                method = 0;
                return IntPtr.Zero;
            }
        }
    }
}
