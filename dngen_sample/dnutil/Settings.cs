using System.Diagnostics;
using System.Configuration;

namespace D.N.Properties {
    /// <summary>
    /// アプリケーション設定ファイルの設定値を返します。
    /// </summary>
    public sealed partial class Settings : ApplicationSettingsBase
    {
        /// <summary>
        /// シングルトンインスタンスを保持します。
        /// </summary>
        private static Settings defaultInstance =
            ((Settings) (ApplicationSettingsBase.Synchronized(new Settings())));
        
        /// <summary>
        /// シングルトンインスタンスを返します。
        /// </summary>
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// プライベートアセンブリパスを返します。
        /// </summary>
        [ApplicationScopedSettingAttribute()]
        [DebuggerNonUserCodeAttribute()]
        [DefaultSettingValueAttribute("lib;plugin;service")]
        public string PrivateBinPath {
            get {
                return ((string)(this["PrivateBinPath"]));
            }
        }
        
        /// <summary>
        /// ユーザーアセンブリ名を返します。
        /// </summary>
        [ApplicationScopedSettingAttribute()]
        [DebuggerNonUserCodeAttribute()]
        [DefaultSettingValueAttribute("user.dll")]
        public string AssemblyName {
            get {
                return ((string)(this["AssemblyName"]));
            }
        }
        
        /// <summary>
        /// ユーザーアセンブリのメインクラス名を返します。
        /// </summary>
        [ApplicationScopedSettingAttribute()]
        [DebuggerNonUserCodeAttribute()]
        [DefaultSettingValueAttribute("Unknown.User")]
        public string MainClass {
            get {
                return ((string)(this["MainClass"]));
            }
        }
        
        /// <summary>
        /// ユーザーアセンブリのプロトコルを返します。
        /// </summary>
        [ApplicationScopedSettingAttribute()]
        [DebuggerNonUserCodeAttribute()]
        [DefaultSettingValueAttribute("UNKNOWN/1.0")]
        public string Protocol {
            get {
                return ((string)(this["Protocol"]));
            }
        }
        
        /// <summary>
        /// ログファイル名を返します。
        /// </summary>
        [ApplicationScopedSettingAttribute()]
        [DebuggerNonUserCodeAttribute()]
        [DefaultSettingValueAttribute("log.txt")]
        public string logfile {
            get {
                return ((string)(this["logfile"]));
            }
        }
        
        /// <summary>
        /// ログの記録方法を返します。
        /// </summary>
        [ApplicationScopedSettingAttribute()]
        [DebuggerNonUserCodeAttribute()]
        [DefaultSettingValueAttribute("2")]
        public int logtype {
            get {
                return ((int)(this["logtype"]));
            }
        }
        
        /// <summary>
        /// ログの記録レベルを返します。
        /// </summary>
        [ApplicationScopedSettingAttribute()]
        [DebuggerNonUserCodeAttribute()]
        [DefaultSettingValueAttribute("NOTICE | WARNING | ERROR | FATAL")]
        public string loglevel {
            get {
                return ((string)(this["loglevel"]));
            }
        }
        
        /// <summary>
        /// ログの文字コードを返します。
        /// </summary>
        [ApplicationScopedSettingAttribute()]
        [DebuggerNonUserCodeAttribute()]
        [DefaultSettingValueAttribute("Shift_JIS")]
        public string logcharset {
            get {
                return ((string)(this["logcharset"]));
            }
        }
    }
}
