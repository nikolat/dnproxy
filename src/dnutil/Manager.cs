using System;
using System.IO;
using System.Reflection;
using D.N.Properties;

using Ukagaka.NET.Interfaces;

namespace D.N
{
    /// <summary>
    /// ロード時とアンロード時の統一的処理を行うクラスです。
    /// </summary>
    internal class Manager : MarshalByRefObject, ILoad, IUnload
    {
        #region ILoad メンバ

        /// <summary>
        /// ロード時に呼ばれます。
        /// </summary>
        /// <param name="h">ゼロポインタ。</param>
        /// <param name="len">0。</param>
        /// <returns>成功時には、true。</returns>
        public bool load(IntPtr h, int len)
        {
            return this.Initialize();
        }

        #endregion

        #region IUnload メンバ

        /// <summary>
        /// アンロード時に呼ばれます。
        /// </summary>
        /// <returns>成功時には、true。</returns>
        public bool unload()
        {
            return this.Finalize();
        }

        #endregion

        /// <summary>
        /// 初期化時に行う処理を追加します。
        /// </summary>
        /// <remarks>
        /// ロガーの初期化を行います。
        /// </remarks>
        /// <returns>成功時には、true。</returns>
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
        /// 終了時に行う処理を追加します。
        /// </summary>
        /// <remarks>
        /// ロガーの終了処理を行います。
        /// </remarks>
        /// <returns>成功時には、true。</returns>
        private bool Finalize()
        {
            Logger.Finalize();

            return true;
        }
    }
}
