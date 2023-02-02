using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;

namespace D.N
{
    /// <summary>
    /// ���O���W���I�ɊǗ����邽�߂̃N���X�ł��B
    /// </summary>
    /// <remarks>
    /// ���O���W���I�ɊǗ����邽�߂̃N���X�ł��B
    /// ���̃N���X�̃C���X�^���X���쐬���邱�Ƃ͂ł��܂���B
    /// �v���O�����̍ŏ���Initialize���Ăя���������K�v������܂��B
    /// �܂��A�v���O�����̍Ō��Finalize���ĂяI���������s���Ă��������B
    /// </remarks>
    public static class Logger
    {
        /// <summary>
        /// �`�F�b�N�c�[���̃E�B���h�E�N���X����ێ����܂��B
        /// </summary>
        private const string CLASSNAME_CHECKTOOL = "TamaWndClass";

        /// <summary>
        /// ���O���p�̊�f�B���N�g����ێ����܂��B
        /// </summary>
        private static string basedir;

        /// <summary>
        /// ���O�t�@�C���̃p�X��ێ����܂��B
        /// </summary>
        private static string logpath;

        /// <summary>
        /// ���O�̏������݃X�g���[����ێ����܂��B
        /// </summary>
        private static StreamWriter writer;

        /// <summary>
        /// ���O�̃G���R�[�h����ێ����܂��B
        /// </summary>
        private static Encoding encode;

        /// <summary>
        /// �������ς݂��ǂ����m�F���邽�߂̃t���O�ł��B
        /// </summary>
        private static bool initialized = false;

        /// <summary>
        /// �I�������ς݂��ǂ����m�F���邽�߂̃t���O�ł��B
        /// </summary>
        private static bool finalized = false;

        /// <summary>
        /// �������ݎ��̌x�����x�����w�肵�܂��B
        /// </summary>
        /// <remarks>
        /// �ݒ莞�ɂ͕������r�b�g���Z�i�_���a�j�ŉ��Z�ł��܂��B
        /// ALL�́A�������ݎ��ɂ͎w��ł��܂���B
        /// </remarks>
        [FlagsAttribute]
        public enum Level
        {
            /// <summary>
            /// ���O�����܂���B��ɏ������ɗp���܂��B
            /// </summary>
            NONE = 0,
            /// <summary>
            /// �v���I�ȃG���[�̔����������܂��B
            /// </summary>
            FATAL = 1,
            /// <summary>
            /// �񕜉\�ȃG���[�̔����������܂��B
            /// </summary>
            ERROR = 2,
            /// <summary>
            /// �x���̔����������܂��B
            /// </summary>
            WARNING = 4,
            /// <summary>
            /// ���ӂ����N���܂��B
            /// </summary>
            NOTICE = 8,
            /// <summary>
            /// ����񋟂��܂��B
            /// </summary>
            INFO = 16,
            /// <summary>
            /// �S�Ă̌x�����x����\�����邽�߂̃t���O�ł��B
            /// ���O�̏������ݎ��ɂ͗p���܂���B
            /// </summary>
            ALL = 31,
        }

        /// <summary>
        /// ���O�p�̕����R�[�h��ݒ肵�܂��B
        /// </summary>
        /// <remarks>
        /// ���O�̏������݂Ɏg���镶���R�[�h��ݒ肵�܂��B
        /// </remarks>
        public enum Charset
        {
            /// <summary>
            /// �����R�[�h��Shift_JIS�ɐݒ肵�܂��B
            /// </summary>
            SJIS,
            /// <summary>
            /// �����R�[�h��UTF-8�ɐݒ肵�܂��B
            /// </summary>
            UTF8,
            /// <summary>
            /// �����R�[�h���V�X�e���̕����R�[�h�ɐݒ肵�܂��B
            /// </summary>
            DEFAULT,
        }

        /// <summary>
        /// �ʑ��M�p�̃��O�̕t������ݒ肵�܂��B
        /// </summary>
        /// <remarks>
        /// �ʂɃ��b�Z�[�W�𑗐M���鎞�ɂ����g���܂���B
        /// </remarks>
        private enum TamaMode
        {
            /// <summary>
            /// �W���̃��b�Z�[�W
            /// </summary>
            INFO,
            /// <summary>
            /// �t�F�[�^���G���[
            /// </summary>
            FATAL,
            /// <summary>
            /// �G���[
            /// </summary>
            ERROR,
            /// <summary>
            /// ���[�j���O
            /// </summary>
            WARNING,
            /// <summary>
            /// ���L
            /// </summary>
            NOTICE,
            /// <summary>
            /// ���O�̏I��
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
            /// OS�f�t�H���g�̃R�[�h
            /// </summary>
            DEFAULT = 32,
        }

        /// <summary>
        /// ���O�t�@�C������ێ����܂��B
        /// </summary>
        private static string logFile = "log.txt";

        /// <summary>
        /// ���O�t�@�C�������w�肵�܂��B
        /// </summary>
        /// <value>���O�t�@�C�����B</value>
        public static string LogFile {
            get { return Logger.logFile;  }
            set { Logger.logFile = value; }
        }

        /// <summary>
        /// ���O�̎�����ێ����܂��B
        /// </summary>
        private static int logType = 2;

        /// <summary>
        /// ���O�̎�����ݒ肵�܂��B
        /// </summary>
        /// <remarks>
        /// 0�ł́A���O�����܂���,
        /// 1�ł́A�`�F�b�N�c�[���݂̂Ƀ��O��\���܂��B
        /// �`�F�b�N�c�[�����N�����Ă��Ȃ��ꍇ�̓��O�����܂���B
        /// 2�ł́A�`�F�b�N�c�[�������݂��Ȃ��ꍇ�̓t�@�C���ɏ������݂܂��B
        /// </remarks>
        /// <value>���O�̎����B</value>
        public static int LogType {
            get { return Logger.logType;  }
            set { Logger.logType = value; }
        }

        /// <summary>
        /// ���O�������ݑΏۂɂ��郌�x����ێ����܂��B
        /// </summary>
        private static Level logLevel = Level.FATAL | Level.ERROR | Level.WARNING | Level.NOTICE;

        /// <summary>
        /// ���O�������ݎ��ɏ������ݑΏۂɂ���x�����x����ݒ肵�܂��B
        /// </summary>
        /// <remarks>
        /// NONE:�����������܂�܂���B
        /// ALL:�ȉ��̑S�Ăɓ��Ă͂܂�܂��B
        /// FATAL:�p���s�\�ȃG���[�̏������݂������܂��B
        /// ERROR:�񕜉\�ȃG���[�̏������݂������܂��B
        /// WARNING:�x���̏������݂������܂��B
        /// NOTICE:���L�̏������݂������܂��B
        /// INFO:���̏������݂������܂��B
        /// </remarks>
        /// <value>���O�̏������ݑΏۂƂ���x�����x���B</value>
        public static Level LogLevel {
            get { return Logger.logLevel;  }
            set { Logger.logLevel = value; }
        }

        /// <summary>
        /// ���O�������ݎ��ɏ������ݑΏۂɂ���x�����x���𕶎���Őݒ肵�܂��B
        /// </summary>
        /// <remarks>
        /// <para>
        /// �����̃��x�����w�肷��ꍇ�́A�p�C�v|�ŋ�؂��Ă��������B
        /// �܂��A�����̃��x�����w�肳��Ă���ꍇ�́A�p�C�v�ŋ�؂�ꂽ������ŕԂ���܂��B
        /// </para>
        /// NONE:�����������܂�܂���B
        /// ALL:�ȉ��̑S�Ăɓ��Ă͂܂�܂��B
        /// FATAL:�p���s�\�ȃG���[�̏������݂������܂��B
        /// ERROR:�񕜉\�ȃG���[�̏������݂������܂��B
        /// WARNING:�x���̏������݂������܂��B
        /// NOTICE:���L�̏������݂������܂��B
        /// INFO:���̏������݂������܂��B
        /// </remarks>
        /// <value>���O�̏������ݑΏۂƂ���x�����x��������|�i�p�C�v�j�ŋ�؂�ꂽ������B</value>
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
        /// ���O�̕����R�[�h��ێ����܂��B
        /// </summary>
        private static Charset logCharset = Charset.DEFAULT;

        /// <summary>
        /// ���O�̕����R�[�h��ݒ肵�܂��B
        /// </summary>
        /// <remarks>
        /// SJIS: SJIS�����R�[�h�ŏ������݂܂��B
        /// UTF8: UTF-8�����R�[�h�ŏ������݂܂��B
        /// DEFAULT: �V�X�e���̃f�t�H���g�����R�[�h�ŏ������݂܂��B
        /// </remarks>
        /// <value>���O�̕����R�[�h�B</value>
        public static Charset LogCharset {
            get { return Logger.logCharset;  }
            set { Logger.logCharset = value; }
        }

        /// <summary>
        /// ���O�̕����R�[�h�𕶎���Őݒ肵�܂��B
        /// </summary>
        /// <remarks>
        /// Shift_JIS:
        /// SJIS: SJIS�����R�[�h�ŏ������݂܂��B
        /// UTF8:
        /// UTF-8: UTF-8�����R�[�h�ŏ������݂܂��B
        /// ����ȊO�̕����R�[�h���ݒ肳�ꂽ�ꍇ�́A�V�X�e���̃f�t�H���g�����R�[�h�ɂȂ�܂��B
        /// </remarks>
        /// <value>���O�̕����R�[�h������������B</value>
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
        /// �`�F�b�N�c�[���̃E�B���h�E�n���h����ێ����܂��B
        /// </summary>
        private static IntPtr hlogrcvWnd;

        /// <summary>
        /// �`�F�b�N�c�[���̃E�B���h�E�n���h����ݒ肵�܂��B
        /// </summary>
        /// <value>�`�F�b�N�c�[���̃E�B���h�E�n���h���B</value>
        public static IntPtr HlogrcvWnd {
            get { return Logger.hlogrcvWnd;  }
            set { Logger.hlogrcvWnd = value; }
        }

        /// <summary>
        /// �E�B���h�E���������܂��B
        /// </summary>
        /// <remarks>
        /// �`�F�b�N�c�[���E�B���h�E�̌����Ɏg�p���܂��BWin32API�ł��B
        /// </remarks>
        /// <param name="lpClassName">�E�B���h�E�N���X�l�[��</param>
        /// <param name="lpWindowName">�E�B���h�E�l�[��</param>
        /// <returns>�E�B���h�E�n���h��</returns>
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// �E�B���h�E���b�Z�[�W�𑗐M���܂��B
        /// </summary>
        /// <remarks>
        /// �`�F�b�N�c�[���E�B���h�E�ւ̃��b�Z�[�W���M�Ɏg�p���܂��BWin32API�ł��B
        /// </remarks>
        /// <param name="hWnd">�`�F�b�N�c�[���̃E�B���h�E�n���h��</param>
        /// <param name="Msg">���b�Z�[�W (WM_COPYDATA���w�肷�邱��)</param>
        /// <param name="wParam">���IntPtr.Zero���w�肷��</param>
        /// <param name="lParam">���M���郁�b�Z�[�W���܂ލ\����</param>
        /// <returns>���b�Z�[�W�̏�������</returns>
        /// <seealso cref="COPYDATASTRUCT"/>
        [DllImport("user32.dll")]
        private static extern uint SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);

        /// <summary>
        /// �`�F�b�N�c�[���ւ̑��M�p���b�Z�[�W�R�[�h�ł��B
        /// </summary>
        private static uint WM_COPYDATA = 0x0000004a;

        /// <summary>
        /// �`�F�b�N�c�[���ւ̑��M�Ɏg�p����\���̂ł��B
        /// </summary>
        /// <see cref="SendMessage"/>
        [StructLayout(LayoutKind.Sequential)]
        private struct COPYDATASTRUCT
        {
            /// <summary>
            /// �`�F�b�N�c�[���ւ̃R�}���h��x�����x����ݒ肵�܂��BTamaMode�񋓑̂�IntPtr�ɃL���X�g���Ă��������B
            /// </summary>
            public IntPtr dwData;
            /// <summary>
            /// ���C�h�����ɕϊ��������̕����̒������w�肵�܂��B���Ȃ킿(������ + 1) * 2�ł��B
            /// </summary>
            public uint cbData;
            /// <summary>
            /// �\������������������w�肵�܂��BLPWSTR�^�ɕϊ�����܂��B
            /// </summary>
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpData;
        }

        /// <summary>
        /// �������������s���܂��B
        /// </summary>
        /// <remarks>
        /// ��f�B���N�g���͌��݂̃A�v���P�[�V�����h���C���̃x�[�X�f�B���N�g���ɂȂ�܂��B
        /// </remarks>
        /// <returns>�����������ɂ́Atrue�B</returns>
        public static bool Initialize()
        {
            return Logger.Initialize(AppDomain.CurrentDomain.BaseDirectory);
        }

        /// <summary>
        /// �������������s���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�̐ݒ�����������A�`�F�b�N�c�[���ɊJ�n���b�Z�[�W�𑗂�܂��B
        /// </remarks>
        /// <param name="basedir">���O�t�@�C���̊�f�B���N�g���B</param>
        /// <returns>�����������ɂ́Atrue�B</returns>
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
        /// �I���������s���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�p�̃X�g���[����������A�`�F�b�N�c�[���ɏI�����b�Z�[�W�𑗂�܂��B
        /// </remarks>
        /// <returns>�����������ɂ́Atrue�B</returns>
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
        /// Level�^����TamaMode�^�̓����̒l�ւ̕ϊ����܂��B
        /// </summary>
        /// <remarks>
        /// �`�F�b�N�c�[���ւ̑��M���A�����̌^����ϊ����邽�߂Ɏg���܂��B
        /// </remarks>
        /// <param name="level">���O�̌x�����x���B</param>
        /// <returns>level�Ɠ�����TamaMode�^�̒l�B</returns>
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
        /// �`�F�b�N�c�[���Ƀ��b�Z�[�W�𑗐M���܂��B
        /// </summary>
        /// <param name="str">�`�F�b�N�c�[���ɕ\����������������B</param>
        /// <param name="mode">���O�̃��[�h�B</param>
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
        /// ���O���������݂܂��B���s���t������܂��B
        /// </summary>
        /// <remarks>
        /// ���O���������݂܂��B���s���t������܂��B
        /// </remarks>
        /// <param name="level">�������݂̌x�����x���B</param>
        /// <param name="value">�������ޕ�����B</param>
        public static void WriteLine(Level level, string value)
        {
            Logger.Write(level, value + "\n");
        }

        /// <summary>
        /// ���O���������݂܂��B
        /// </summary>
        /// <remarks>
        /// ���O���������݂܂��B
        /// </remarks>
        /// <param name="level">�������݂̌x�����x���B</param>
        /// <param name="value">�������ޕ�����B</param>
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
