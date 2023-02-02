using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.CodeDom.Compiler;
using System.Xml;
using System.Windows.Forms;

using Ukagaka.NET.Interfaces;

namespace D.N
{
    /// <summary>
    /// アセンブリの生成処理クラスです。
    /// </summary>
    internal class Generator : MarshalByRefObject, ILoad, IExecute
    {
        /// <summary>
        /// 設定ファイルのアプリケーション設定にアクセスするパスを返します。
        /// </summary>
        /// <param name="doc">設定ファイルのXMLドキュメント。</param>
        /// <returns>設定ファイルのアプリケーション設定にアクセスするパス。</returns>
        private XmlElement configSettingsElement(XmlDocument doc)
        {
            return doc["configuration"]["applicationSettings"]["D.N.Properties.Settings"];
        }

        /// <summary>
        /// 設定ファイルのアプリケーション設定を取得します。
        /// </summary>
        /// <param name="element">アプリケーション設定のXMLエレメント。</param>
        /// <param name="key">取得したい設定名。</param>
        /// <returns><c>key</c>で示される設定値。見つからない場合には、null。</returns>
        private string getAssemblyData(XmlElement element, string key)
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

        #region ILoad メンバ

        /// <summary>
        /// アプリケーション構成ファイルを元にロガーの初期設定をします。
        /// </summary>
        /// <param name="h">アプリケーション構成ファイルのパス文字列を格納したメモリへのポインタ。</param>
        /// <param name="len">アプリケーション構成ファイルのパス文字列の長さ。</param>
        /// <returns>処理成功時には、true。</returns>
        public bool load(IntPtr h, int len)
        {
            string appconf = Marshal.PtrToStringAnsi(h, len);
            Marshal.FreeHGlobal(h);

            // 依存アセンブリの情報を設定
            XmlDocument doc = new XmlDocument();
            doc.Load(appconf);
            // アプリケーション設定の取得
            XmlElement element = this.configSettingsElement(doc);
            Logger.LogFile          = "dngenlog.txt";
            Logger.LogType          = Int32.Parse(this.getAssemblyData(element, "logtype"));
            Logger.LogLevelString   = this.getAssemblyData(element, "loglevel");
            Logger.LogCharsetString = this.getAssemblyData(element, "logcharset");

            return true;
        }

        #endregion

        #region IExecute メンバ

        /// <summary>
        /// アセンブリをコンパイルします。
        /// </summary>
        /// <remarks>
        /// キャッシュより新しいファイルを見つけた場合アセンブリをコンパイルします。
        /// 見つからなかった場合何も処理しません。
        /// </remarks>
        /// <param name="h">コンパイラ設定ファイルのパス文字列を格納したメモリへのポインタ。</param>
        /// <param name="len">コンパイラ設定ファイルのパス文字列の長さ。</param>
        /// <returns>ゼロポインタ。</returns>
        public IntPtr execute(IntPtr h, ref int len)
        {
            string configFile = Marshal.PtrToStringAnsi(h, len);
            Marshal.FreeHGlobal(h);

            Logger.Initialize();

            if (File.Exists(configFile)) {
                // ユーザーレベルアセンブリのコンパイル
                Compiler compiler = new Compiler();
                compiler.ConfigFile = configFile;
                CompilerParameters cp = compiler.CompilerParametersFromFile();

                // キャッシュチェック
                string cachedir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profile");
                string cache    = Path.Combine(cachedir, cp.OutputAssembly + ".cache");
                string cachedData = null;
                if (!Directory.Exists(cachedir)) {
                    Directory.CreateDirectory(cachedir);
                }
                if (File.Exists(cache)) {
                    using (StreamReader sr = new StreamReader(cache)) {
                        cachedData = sr.ReadToEnd();
                    }
                }
                StringBuilder sb = new StringBuilder();
                sb.Append(configFile + "=");
                sb.Append(File.GetLastWriteTime(configFile).Ticks.ToString() + ",");
                foreach (string sources in compiler.SourceFiles) {
                    if (File.Exists(sources)) {
                        sb.Append(sources + "=");
                        sb.Append(File.GetLastWriteTime(sources).Ticks.ToString() + ",");
                    }
                }
                foreach (string refs in cp.ReferencedAssemblies) {
                    if (File.Exists(refs)) {
                        sb.Append(refs + "=");
                        sb.Append(File.GetLastWriteTime(refs).Ticks.ToString() + ",");
                    }
                }
                foreach (string embs in cp.EmbeddedResources) {
                    if (File.Exists(embs)) {
                        sb.Append(embs + "=");
                        sb.Append(File.GetLastWriteTime(embs).Ticks.ToString() + ",");
                    }
                }
                foreach (string links in cp.LinkedResources) {
                    if (File.Exists(links)) {
                        sb.Append(links + "=");
                        sb.Append(File.GetLastWriteTime(links).Ticks.ToString() + ",");
                    }
                }
                if (File.Exists(cp.Win32Resource)) {
                    sb.Append(cp.Win32Resource + "=");
                    sb.Append(File.GetLastWriteTime(cp.Win32Resource).Ticks.ToString() + ",");
                }
                // コンパイル
                if (!File.Exists(cp.OutputAssembly) || (cachedData != sb.ToString())) {
                    if (cachedData != sb.ToString()) {
                        using (StreamWriter sw = new StreamWriter(cache)) {
                            sw.Write(sb.ToString());
                        }
                    }
                    try {
                        compiler.Execute();
                    } catch (Exception e) {
                        Logger.WriteLine(Logger.Level.FATAL, e.Message);
                    }
                }
            }

            Logger.Finalize();

            return IntPtr.Zero;
        }

        #endregion
    }
}
