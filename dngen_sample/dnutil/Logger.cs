using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;

namespace D.N
{
    /// <summary>
    /// ログを集中的に管理するためのクラスです。
    /// </summary>
    /// <remarks>
    /// ログを集中的に管理するためのクラスです。
    /// このクラスのインスタンスを作成することはできません。
    /// プログラムの最初にInitializeを呼び初期化する必要があります。
    /// また、プログラムの最後にFinalizeを呼び終了処理を行ってください。
    /// </remarks>
    public static class Logger
    {
        /// <summary>
        /// チェックツールのウィンドウクラス名を保持します。
        /// </summary>
        private const string CLASSNAME_CHECKTOOL = "TamaWndClass";

        /// <summary>
        /// ログ取り用の基準ディレクトリを保持します。
        /// </summary>
        private static string basedir;

        /// <summary>
        /// ログファイルのパスを保持します。
        /// </summary>
        private static string logpath;

        /// <summary>
        /// ログの書き込みストリームを保持します。
        /// </summary>
        private static StreamWriter writer;

        /// <summary>
        /// ログのエンコード情報を保持します。
        /// </summary>
        private static Encoding encode;

        /// <summary>
        /// 初期化済みかどうか確認するためのフラグです。
        /// </summary>
        private static bool initialized = false;

        /// <summary>
        /// 終了処理済みかどうか確認するためのフラグです。
        /// </summary>
        private static bool finalized = false;

        /// <summary>
        /// 書き込み時の警告レベルを指定します。
        /// </summary>
        /// <remarks>
        /// 設定時には複数をビット演算（論理和）で加算できます。
        /// ALLは、書き込み時には指定できません。
        /// </remarks>
        [FlagsAttribute]
        public enum Level
        {
            /// <summary>
            /// ログを取りません。主に初期化に用います。
            /// </summary>
            NONE = 0,
            /// <summary>
            /// 致命的なエラーの発生を示します。
            /// </summary>
            FATAL = 1,
            /// <summary>
            /// 回復可能なエラーの発生を示します。
            /// </summary>
            ERROR = 2,
            /// <summary>
            /// 警告の発生を示します。
            /// </summary>
            WARNING = 4,
            /// <summary>
            /// 注意を喚起します。
            /// </summary>
            NOTICE = 8,
            /// <summary>
            /// 情報を提供します。
            /// </summary>
            INFO = 16,
            /// <summary>
            /// 全ての警告レベルを表示するためのフラグです。
            /// ログの書き込み時には用いません。
            /// </summary>
            ALL = 31,
        }

        /// <summary>
        /// ログ用の文字コードを設定します。
        /// </summary>
        /// <remarks>
        /// ログの書き込みに使われる文字コードを設定します。
        /// </remarks>
        public enum Charset
        {
            /// <summary>
            /// 文字コードをShift_JISに設定します。
            /// </summary>
            SJIS,
            /// <summary>
            /// 文字コードをUTF-8に設定します。
            /// </summary>
            UTF8,
            /// <summary>
            /// 文字コードをシステムの文字コードに設定します。
            /// </summary>
            DEFAULT,
        }

        /// <summary>
        /// 玉送信用のログの付加情報を設定します。
        /// </summary>
        /// <remarks>
        /// 玉にメッセージを送信する時にしか使われません。
        /// </remarks>
        private enum TamaMode
        {
            /// <summary>
            /// 標準のメッセージ
            /// </summary>
            INFO,
            /// <summary>
            /// フェータルエラー
            /// </summary>
            FATAL,
            /// <summary>
            /// エラー
            /// </summary>
            ERROR,
            /// <summary>
            /// ワーニング
            /// </summary>
            WARNING,
            /// <summary>
            /// 注記
            /// </summary>
            NOTICE,
            /// <summary>
            /// ログの終了
            /// </summary>
            END,
            /// <summary>
            /// SJIS
            /// </summary>
            SJIS = 16,
            /// <summary>
            /// UTF-8
            /// </summary>
            UTF8,
            /// <summary>
            /// OSデフォルトのコード
            /// </summary>
            DEFAULT = 32,
        }

        /// <summary>
        /// ログファイル名を保持します。
        /// </summary>
        private static string logFile = "log.txt";

        /// <summary>
        /// ログファイル名を指定します。
        /// </summary>
        /// <value>ログファイル名。</value>
        public static string LogFile {
            get { return Logger.logFile;  }
            set { Logger.logFile = value; }
        }

        /// <summary>
        /// ログの取り方を保持します。
        /// </summary>
        private static int logType = 2;

        /// <summary>
        /// ログの取り方を設定します。
        /// </summary>
        /// <remarks>
        /// 0では、ログを取りません,
        /// 1では、チェックツールのみにログを表示ます。
        /// チェックツールを起動していない場合はログを取りません。
        /// 2では、チェックツールが存在しない場合はファイルに書き込みます。
        /// </remarks>
        /// <value>ログの取り方。</value>
        public static int LogType {
            get { return Logger.logType;  }
            set { Logger.logType = value; }
        }

        /// <summary>
        /// ログ書き込み対象にするレベルを保持します。
        /// </summary>
        private static Level logLevel = Level.FATAL | Level.ERROR | Level.WARNING | Level.NOTICE;

        /// <summary>
        /// ログ書き込み時に書き込み対象にする警告レベルを設定します。
        /// </summary>
        /// <remarks>
        /// NONE:何も書き込まれません。
        /// ALL:以下の全てに当てはまります。
        /// FATAL:継続不可能なエラーの書き込みを許可します。
        /// ERROR:回復可能なエラーの書き込みを許可します。
        /// WARNING:警告の書き込みを許可します。
        /// NOTICE:注記の書き込みを許可します。
        /// INFO:情報の書き込みを許可します。
        /// </remarks>
        /// <value>ログの書き込み対象とする警告レベル。</value>
        public static Level LogLevel {
            get { return Logger.logLevel;  }
            set { Logger.logLevel = value; }
        }

        /// <summary>
        /// ログ書き込み時に書き込み対象にする警告レベルを文字列で設定します。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 複数のレベルを指定する場合は、パイプ|で区切ってください。
        /// また、複数のレベルが指定されている場合は、パイプで区切られた文字列で返されます。
        /// </para>
        /// NONE:何も書き込まれません。
        /// ALL:以下の全てに当てはまります。
        /// FATAL:継続不可能なエラーの書き込みを許可します。
        /// ERROR:回復可能なエラーの書き込みを許可します。
        /// WARNING:警告の書き込みを許可します。
        /// NOTICE:注記の書き込みを許可します。
        /// INFO:情報の書き込みを許可します。
        /// </remarks>
        /// <value>ログの書き込み対象とする警告レベルを示す|（パイプ）で区切られた文字列。</value>
        public static string LogLevelString
        {
            get {
                return Logger.logLevel.GetType().ToString();
            }
            set {
                string[] levels = value.Split('|');
                string type = Logger.logLevel.GetType().ToString();
                string[] names = Enum.GetNames(Type.GetType(type));
                Logger.logLevel = Logger.Level.NONE;
                foreach (string level in levels) {
                    foreach (string name in names) {
                        if (name == level.Trim()) {
                            Logger.logLevel |= (Logger.Level) Enum.Parse(Type.GetType(type), name);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ログの文字コードを保持します。
        /// </summary>
        private static Charset logCharset = Charset.DEFAULT;

        /// <summary>
        /// ログの文字コードを設定します。
        /// </summary>
        /// <remarks>
        /// SJIS: SJIS文字コードで書き込みます。
        /// UTF8: UTF-8文字コードで書き込みます。
        /// DEFAULT: システムのデフォルト文字コードで書き込みます。
        /// </remarks>
        /// <value>ログの文字コード。</value>
        public static Charset LogCharset {
            get { return Logger.logCharset;  }
            set { Logger.logCharset = value; }
        }

        /// <summary>
        /// ログの文字コードを文字列で設定します。
        /// </summary>
        /// <remarks>
        /// Shift_JIS:
        /// SJIS: SJIS文字コードで書き込みます。
        /// UTF8:
        /// UTF-8: UTF-8文字コードで書き込みます。
        /// それ以外の文字コードが設定された場合は、システムのデフォルト文字コードになります。
        /// </remarks>
        /// <value>ログの文字コードを示す文字列。</value>
        public static string LogCharsetString
        {
            get {
                return Logger.logCharset.ToString();
            }
            set {
                switch (value.ToLower()) {
                    case "shift_jis":
                        goto case "sjis";
                    case "sjis":
                        Logger.logCharset = Logger.Charset.SJIS;
                        break;
                    case "utf8":
                        goto case "utf-8";
                    case "utf-8":
                        Logger.logCharset = Logger.Charset.UTF8;
                        break;
                    default:
                        Logger.logCharset = Logger.Charset.DEFAULT;
                        break;
                }
            }
        }

        /// <summary>
        /// チェックツールのウィンドウハンドルを保持します。
        /// </summary>
        private static IntPtr hlogrcvWnd;

        /// <summary>
        /// チェックツールのウィンドウハンドルを設定します。
        /// </summary>
        /// <value>チェックツールのウィンドウハンドル。</value>
        public static IntPtr HlogrcvWnd {
            get { return Logger.hlogrcvWnd;  }
            set { Logger.hlogrcvWnd = value; }
        }

        /// <summary>
        /// ウィンドウを検索します。
        /// </summary>
        /// <remarks>
        /// チェックツールウィンドウの検索に使用します。Win32APIです。
        /// </remarks>
        /// <param name="lpClassName">ウィンドウクラスネーム</param>
        /// <param name="lpWindowName">ウィンドウネーム</param>
        /// <returns>ウィンドウハンドル</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// ウィンドウメッセージを送信します。
        /// </summary>
        /// <remarks>
        /// チェックツールウィンドウへのメッセージ送信に使用します。Win32APIです。
        /// </remarks>
        /// <param name="hWnd">チェックツールのウィンドウハンドル</param>
        /// <param name="Msg">メッセージ (WM_COPYDATAを指定すること)</param>
        /// <param name="wParam">常にIntPtr.Zeroを指定する</param>
        /// <param name="lParam">送信するメッセージを含む構造体</param>
        /// <returns>メッセージの処理結果</returns>
        /// <seealso cref="COPYDATASTRUCT"/>
        [DllImport("user32.dll")]
        private static extern uint SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);

        /// <summary>
        /// チェックツールへの送信用メッセージコードです。
        /// </summary>
        private static uint WM_COPYDATA = 0x0000004a;

        /// <summary>
        /// チェックツールへの送信に使用する構造体です。
        /// </summary>
        /// <see cref="SendMessage"/>
        [StructLayout(LayoutKind.Sequential)]
        private struct COPYDATASTRUCT
        {
            /// <summary>
            /// チェックツールへのコマンドや警告レベルを設定します。TamaMode列挙体をIntPtrにキャストしてください。
            /// </summary>
            public IntPtr dwData;
            /// <summary>
            /// ワイド文字に変換した時の文字の長さを指定します。すなわち(文字数 + 1) * 2です。
            /// </summary>
            public uint cbData;
            /// <summary>
            /// 表示させたい文字列を指定します。LPWSTR型に変換されます。
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpData;
        }

        /// <summary>
        /// 初期化処理を行います。
        /// </summary>
        /// <remarks>
        /// 基準ディレクトリは現在のアプリケーションドメインのベースディレクトリになります。
        /// </remarks>
        /// <returns>処理成功時には、true。</returns>
        public static bool Initialize()
        {
            return Logger.Initialize(AppDomain.CurrentDomain.BaseDirectory);
        }

        /// <summary>
        /// 初期化処理を行います。
        /// </summary>
        /// <remarks>
        /// ログの設定を初期化し、チェックツールに開始メッセージを送ります。
        /// </remarks>
        /// <param name="basedir">ログファイルの基準ディレクトリ。</param>
        /// <returns>処理成功時には、true。</returns>
        public static bool Initialize(string basedir)
        {
            if (initialized) {
                return true;
            }
            Logger.basedir = basedir;
            Logger.logpath = Path.Combine(Logger.basedir, Logger.logFile);
            string bakpath = Path.ChangeExtension(Logger.logpath, ".bak");
            if (File.Exists(Logger.logpath)) {
                if (File.Exists(bakpath)) {
                    File.Delete(bakpath);
                }
                File.Move(Logger.logpath, bakpath);
            }

            if (Logger.hlogrcvWnd == IntPtr.Zero) {
                Logger.hlogrcvWnd = FindWindow(Logger.CLASSNAME_CHECKTOOL, null);
            }
            if (Logger.hlogrcvWnd != IntPtr.Zero) {
                Logger.SendLogToWnd("", (TamaMode) Enum.Parse(
                    Type.GetType("D.N.Logger+TamaMode"), Logger.logCharset.ToString()));
            }
            if (Logger.logType >= 2) {
                switch (Logger.logCharset) {
                    case Charset.UTF8:
                        Logger.encode = Encoding.UTF8;
                        break;
                    default:
                        Logger.encode = Encoding.Default;
                        break;
                }
            }
            initialized = true;
            return true;
        }

        /// <summary>
        /// 終了処理を行います。
        /// </summary>
        /// <remarks>
        /// ログ用のストリームを解放し、チェックツールに終了メッセージを送ります。
        /// </remarks>
        /// <returns>処理成功時には、true。</returns>
        public static bool Finalize()
        {
            if (Logger.finalized) {
                return true;
            }
            if (Logger.writer != null) {
                Logger.writer.Close();
            }
            Logger.SendLogToWnd("", TamaMode.END);
            Logger.finalized = true;

            return true;
        }

        /// <summary>
        /// Level型からTamaMode型の同等の値への変換します。
        /// </summary>
        /// <remarks>
        /// チェックツールへの送信時、内部の型から変換するために使われます。
        /// </remarks>
        /// <param name="level">ログの警告レベル。</param>
        /// <returns>levelと同等のTamaMode型の値。</returns>
        private static TamaMode TypeReplaceToTama(Level level)
        {
            switch (level) {
                case Level.INFO:
                    return TamaMode.INFO;
                case Level.NOTICE:
                    return TamaMode.NOTICE;
                case Level.WARNING:
                    return TamaMode.WARNING;
                case Level.ERROR:
                    return TamaMode.ERROR;
                case Level.FATAL:
                    return TamaMode.FATAL;
                default:
                    return TamaMode.NOTICE;
            }
        }

        /// <summary>
        /// チェックツールにメッセージを送信します。
        /// </summary>
        /// <param name="str">チェックツールに表示させたい文字列。</param>
        /// <param name="mode">ログのモード。</param>
        private static void SendLogToWnd(string str, TamaMode mode)
        {
            if (Logger.hlogrcvWnd == IntPtr.Zero) {
                return;
            }
            COPYDATASTRUCT cds;
            cds.dwData = (IntPtr) mode;
            cds.cbData = (uint) (str.Length + 1) * 2;
            cds.lpData = str;

            SendMessage(Logger.hlogrcvWnd, WM_COPYDATA, IntPtr.Zero, ref cds);
        }

        /// <summary>
        /// ログを書き込みます。改行が付加されます。
        /// </summary>
        /// <remarks>
        /// ログを書き込みます。改行が付加されます。
        /// </remarks>
        /// <param name="level">書き込みの警告レベル。</param>
        /// <param name="value">書き込む文字列。</param>
        public static void WriteLine(Level level, string value)
        {
            Logger.Write(level, value + "\n");
        }

        /// <summary>
        /// ログを書き込みます。
        /// </summary>
        /// <remarks>
        /// ログを書き込みます。
        /// </remarks>
        /// <param name="level">書き込みの警告レベル。</param>
        /// <param name="value">書き込む文字列。</param>
        public static void Write(Level level, string value)
        {
            if (Logger.logType >= 1 && Logger.hlogrcvWnd != IntPtr.Zero
                && (((int) (level & Logger.logLevel)) == (int) level)
                && (level != Level.NONE || level != Level.ALL)) {
                Logger.SendLogToWnd(value, Logger.TypeReplaceToTama(level));
            } else if (Logger.logType >= 2
                && ((int) (level & Logger.logLevel)) == (int) level
                && (level != Level.NONE || level != Level.ALL)) {
                if (Logger.writer == null) {
                    Logger.writer = new StreamWriter(Logger.logpath, true, Logger.encode);
                    Logger.writer.AutoFlush = true;
                }
                Logger.writer.Write(value);
            }
        }
    }
}
