using System;
using System.IO;
using System.Reflection;
using D.N.Properties;

using Ukagaka.NET.Interfaces;

namespace D.N
{
    /// <summary>
    /// ���[�h���ƃA�����[�h���̓���I�������s���N���X�ł��B
    /// </summary>
    internal class Manager : MarshalByRefObject, ILoad, IUnload
    {
        #region ILoad �����o

        /// <summary>
        /// ���[�h���ɌĂ΂�܂��B
        /// </summary>
        /// <param name="h">�[���|�C���^�B</param>
        /// <param name="len">0�B</param>
        /// <returns>�������ɂ́Atrue�B</returns>
        public bool load(IntPtr h, int len)
        {
            return this.Initialize();
        }

        #endregion

        #region IUnload �����o

        /// <summary>
        /// �A�����[�h���ɌĂ΂�܂��B
        /// </summary>
        /// <returns>�������ɂ́Atrue�B</returns>
        public bool unload()
        {
            return this.Finalize();
        }

        #endregion

        /// <summary>
        /// ���������ɍs��������ǉ����܂��B
        /// </summary>
        /// <remarks>
        /// ���K�[�̏��������s���܂��B
        /// </remarks>
        /// <returns>�������ɂ́Atrue�B</returns>
        public bool Initialize()
        {
            Logger.LogFile          = Settings.Default.logfile;
            Logger.LogType          = Settings.Default.logtype;
            Logger.LogLevelString   = Settings.Default.loglevel;
            Logger.LogCharsetString = Settings.Default.logcharset;
            Logger.Initialize();

            return true;
        }

        /// <summary>
        /// �I�����ɍs��������ǉ����܂��B
        /// </summary>
        /// <remarks>
        /// ���K�[�̏I���������s���܂��B
        /// </remarks>
        /// <returns>�������ɂ́Atrue�B</returns>
        private bool Finalize()
        {
            Logger.Finalize();

            return true;
        }
    }
}
