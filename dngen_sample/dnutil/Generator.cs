using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using D.N.Properties;

using Ukagaka.NET.Interfaces;

namespace D.N
{
    /// <summary>
    /// アセンブリの生成処理クラスです。
    /// </summary>
    internal class Generator : MarshalByRefObject, IExecute
    {
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

            if (File.Exists(configFile)) {
                // ユーザーレベルアセンブリのコンパイル
                Compiler compiler = new Compiler();
                compiler.ConfigFile = configFile;
                CompilerParameters cp = compiler.CompilerParametersFromFile();

                // キャッシュチェック
                if (cp.OutputAssembly == null) {
                    cp.OutputAssembly = Settings.Default.AssemblyName;
                }
                if (cp.MainClass == null) {
                    cp.MainClass = Settings.Default.MainClass;
                }
                string cachedir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profile");
                string cache = Path.Combine(cachedir, cp.OutputAssembly + ".cache");
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
            return IntPtr.Zero;
        }

        #endregion
    }
}
