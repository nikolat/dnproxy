using System.Diagnostics;
using System.Configuration;

namespace D.N.Properties {
    /// <summary>
    /// �A�v���P�[�V�����ݒ�t�@�C���̐ݒ�l��Ԃ��܂��B
    /// </summary>
    public sealed partial class Settings : ApplicationSettingsBase
    {
        /// <summary>
        /// �V���O���g���C���X�^���X��ێ����܂��B
        /// </summary>
        private static Settings defaultInstance =
            ((Settings) (ApplicationSettingsBase.Synchronized(new Settings())));
        
        /// <summary>
        /// �V���O���g���C���X�^���X��Ԃ��܂��B
        /// </summary>
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// �v���C�x�[�g�A�Z���u���p�X��Ԃ��܂��B
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
        /// ���[�U�[�A�Z���u������Ԃ��܂��B
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
        /// ���[�U�[�A�Z���u���̃��C���N���X����Ԃ��܂��B
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
        /// ���[�U�[�A�Z���u���̃v���g�R����Ԃ��܂��B
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
        /// ���O�t�@�C������Ԃ��܂��B
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
        /// ���O�̋L�^���@��Ԃ��܂��B
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
        /// ���O�̋L�^���x����Ԃ��܂��B
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
        /// ���O�̕����R�[�h��Ԃ��܂��B
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
