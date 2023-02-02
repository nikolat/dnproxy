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
    /// �A�Z���u���̐��������N���X�ł��B
    /// </summary>
    internal class Generator : MarshalByRefObject, IExecute
    {
        #region IExecute �����o

        /// <summary>
        /// �A�Z���u�����R���p�C�����܂��B
        /// </summary>
        /// <remarks>
        /// �L���b�V�����V�����t�@�C�����������ꍇ�A�Z���u�����R���p�C�����܂��B
        /// ������Ȃ������ꍇ�����������܂���B
        /// </remarks>
        /// <param name="h">�R���p�C���ݒ�t�@�C���̃p�X��������i�[�����������ւ̃|�C���^�B</param>
        /// <param name="len">�R���p�C���ݒ�t�@�C���̃p�X������̒����B</param>
        /// <returns>�[���|�C���^�B</returns>
        public IntPtr execute(IntPtr h, ref int len)
        {
            string configFile = Marshal.PtrToStringAnsi(h, len);
            Marshal.FreeHGlobal(h);

            if (File.Exists(configFile)) {
                // ���[�U�[���x���A�Z���u���̃R���p�C��
                Compiler compiler = new Compiler();
                compiler.ConfigFile = configFile;
                CompilerParameters cp = compiler.CompilerParametersFromFile();

                // �L���b�V���`�F�b�N
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
                // �R���p�C��
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
