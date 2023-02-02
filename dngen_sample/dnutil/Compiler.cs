using System;
using System.IO;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace D.N
{
    /// <summary>
    /// .NET����̃\�[�X�R�[�h���R���p�C�����܂��B
    /// </summary>
    /// <remarks>
    /// .NET����̃\�[�X�R�[�h�𓮓I�ɃR���p�C������@�\��񋟂��܂��B
    /// </remarks>
    public class Compiler
    {
        /// <summary>
        /// �R���p�C�����ꂽ�A�Z���u���ւ̎Q�Ƃ�ێ����܂��B
        /// </summary>
        private Assembly assembly;
        /// <summary>
        /// �R���p�C�����ꂽ�A�Z���u���ւ̎Q�Ƃ�Ԃ��܂��B
        /// </summary>
        /// <value>�R���p�C�����ꂽ�A�Z���u���ւ̎Q�ƁB</value>
        public Assembly Assembly {
            get { return this.assembly; }
        }

        /// <summary>
        /// �R���p�C�����ꂽ�A�Z���u���̃p�X��ێ����܂��B
        /// </summary>
        private string pathToAssembly;
        /// <summary>
        /// �R���p�C�����ꂽ�A�Z���u���̃p�X��Ԃ��܂��B
        /// </summary>
        /// <value>�R���p�C�����ꂽ�A�Z���u���̃p�X�B</value>
        public string PathToAssembly {
            get { return this.pathToAssembly; }
        }

        /// <summary>
        /// �R���p�C�������A�Z���u���̃\�[�X�̌����ێ����܂��B
        /// </summary>
        private string language;
        /// <summary>
        /// �R���p�C�������A�Z���u���̃\�[�X�̌����Ԃ��܂��B
        /// </summary>
        /// <value>�R���p�C�����ꂽ�A�Z���u���̃\�[�X�̌���B</value>
        public string Language {
            get { return this.language; }
        }

        /// <summary>
        /// �R���p�C�������\�[�X�t�@�C������ێ����܂��B
        /// </summary>
        private string[] sourceFiles;
        /// <summary>
        /// �R���p�C�������\�[�X�t�@�C������Ԃ��܂��B
        /// </summary>
        /// <value>�R���p�C�����ꂽ�\�[�X�t�@�C����</value>
        public string[] SourceFiles {
            get { return this.sourceFiles; }
        }

        /// <summary>
        /// �R���p�C�����̃p�����^��ێ����܂��B
        /// </summary>
        private CompilerParameters config;
        /// <summary>
        /// �R���p�C�����̃p�����^��Ԃ��܂��B
        /// </summary>
        /// <value>�R���p�C�����̃p�����^�B</value>
        public CompilerParameters Config {
            get { return this.config; }
        }

        /// <summary>
        /// �R���p�C���ݒ���L�q�����t�@�C����ێ����܂��B
        /// </summary>
        private string configFile;
        /// <summary>
        /// �R���p�C���ݒ���L�q�����t�@�C������ݒ肵�܂��B
        /// </summary>
        /// <value>�R���p�C���ݒ���L�q�����t�@�C�����B</value>
        public string ConfigFile {
            set { this.configFile = value; }
            get { return this.configFile; }
        }

        /// <summary>
        /// <c>list</c>�ɓn���ꂽ�t�H���_�E�t�@�C�����X�g���t���p�X�ɂ���yield�ŕԂ��܂��B
        /// </summary>
        /// <param name="basedir">�t�@�C�������������f�B���N�g���B</param>
        /// <param name="list">��������t�@�C���̃��X�g�B</param>
        /// <param name="searchGac">GAC�t�H���_�������Ώ̂Ɋ܂ޏꍇ�Atrue�B�܂܂Ȃ��ꍇ�Afalse�B</param>
        /// <returns></returns>
        private IEnumerable<string> AddFiles(string basedir, string[] list, bool searchGac)
        {
            foreach (string item in list) {
                string target = item.Trim();
                if (target.Length == 0) {
                    continue;
                }
                if (target.IndexOf('|') != -1 || target.IndexOf('.') == -1) {
                    string[] dir = target.Split('|');
                    if (!Directory.Exists(dir[0])) {
                        continue;
                    }
                    string[] files = Directory.GetFiles(dir[0],
                        dir.Length == 1 ? "*.*" : dir[1], SearchOption.AllDirectories);
                    foreach (string file in files) {
                        yield return Path.Combine(basedir, file);
                    }
                } else {
                    if (File.Exists(Path.Combine(basedir, target))) {
                        yield return Path.Combine(basedir, target);
                    //} else if (File.Exists(Path.Combine(Application.StartupPath, target))) {
                    //    yield return Path.Combine(Application.StartupPath, target);
                    } else if (searchGac) {
                        yield return target;
                    }
                }
            }
        }

        /// <summary>
        /// <c>CompilerParameters</c>���R���p�C���ݒ�t�@�C�����琶�����Ԃ��܂��B
        /// </summary>
        /// <remarks>
        /// ���<c>ConfigFile</c>�v���p�e�B�ɃR���p�C���ݒ�t�@�C�����w�肵�Ă����K�v������܂��B
        /// </remarks>
        /// <returns>�������<c>CompilerParameters</c>�N���X�B</returns>
        public CompilerParameters CompilerParametersFromFile()
        {
            return this.CompilerParametersFromFile(this.ConfigFile);
        }

        /// <summary>
        /// <c>CompilerParameters</c>���R���p�C���ݒ�t�@�C�����琶�����Ԃ��܂��B
        /// </summary>
        /// <param name="config">�R���p�C���ݒ�t�@�C���̃p�X�B</param>
        /// <returns>�������<c>CompilerParameters</c>�N���X�B</returns>
        public CompilerParameters CompilerParametersFromFile(string config)
        {
            if (this.configFile == "") {
                throw new Exception("�ݒ�t�@�C�������w�肳��Ă��܂���B");
            }

            CompilerParameters cp = new CompilerParameters();

            List<string> sourceFiles = new List<string>();
            string language = null;
            string basedir = Path.GetDirectoryName(this.configFile) + Path.DirectorySeparatorChar;
            using (StreamReader reader = new StreamReader(this.configFile)) {
                string key = null;
                string line;
                while ((line = reader.ReadLine()) != null) {
                    int pos;
                    if ((pos = line.IndexOf("//")) != -1) {
                        line = line.Substring(0, pos);
                    }
                    if (line.Length == 0) {
                        continue;
                    }

                    string values;
                    if (line.IndexOf(':') != -1) {
                        string[] entry = line.Split(new char[] { ':' }, 2);
                        key = entry[0].Trim();
                        values = entry[1].Trim();
                    } else if (key != null) {
                        values = line.Trim();
                    } else {
                        continue;
                    }

                    if (values.Length == 0) {
                        continue;
                    }
                    switch (key.ToLower()) {
                        case "sourcefiles":
                            foreach (string value in this.AddFiles(basedir, values.Split(','), false)) {
                                sourceFiles.Add(value);
                            }
                            break;
                        case "language":
                            language = values;
                            break;
                        case "mainclass":
                            cp.MainClass = values;
                            break;
                        case "outputassembly":
                            cp.OutputAssembly = values;
                            break;
                        case "generateexecutable":
                            cp.GenerateExecutable =
                                int.Parse(values) == 0 ? false : true;
                            break;
                        case "generateinmemory":
                            cp.GenerateInMemory =
                                int.Parse(values) == 0 ? false : true;
                            break;
                        case "includedebuginformation":
                            cp.IncludeDebugInformation =
                                int.Parse(values) == 0 ? false : true;
                            break;
                        case "compileroptions":
                            cp.CompilerOptions = values;
                            break;
                        case "warninglevel":
                            cp.WarningLevel = int.Parse(values);
                            break;
                        case "treatwarningsaserrors":
                            cp.TreatWarningsAsErrors =
                                int.Parse(values) == 0 ? false : true;
                            break;
                        case "referencedassemblies":
                            foreach (string value in this.AddFiles(basedir, values.Split(','), true)) {
                                cp.ReferencedAssemblies.Add(value);
                            }
                            break;
                        case "embeddedresources":
                            foreach (string value in this.AddFiles(basedir, values.Split(','), false)) {
                                cp.EmbeddedResources.Add(value);
                            }
                            break;
                        case "linkedresources":
                            foreach (string value in this.AddFiles(basedir, values.Split(','), false)) {
                                cp.LinkedResources.Add(value);
                            }
                            break;
                        case "win32resource":
                            cp.Win32Resource = values;
                            break;
                    }
                }
            }
            this.language = language;
            this.sourceFiles = sourceFiles.ToArray();
            this.config = cp;
            return this.config;
        }

        /// <summary>
        /// �R���p�C���ݒ�t�@�C�����瓾���������ɃR���p�C�����܂��B
        /// </summary>
        /// <remarks>
        /// �R���p�C���ݒ�t�@�C�����瓾���������ɃR���p�C�����܂��B�p�X�͐ݒ�t�@�C���̈ʒu�Ɉˑ����܂��B
        /// �R���p�C���ݒ�t�@�C���̎d�l�Ɋւ��Ă̓R���p�C���ݒ�t�@�C�����Q�Ƃ��Ă��������B
        /// </remarks>
        /// <returns>�R���p�C���̐������ɂ́Atrue�B</returns>
        public bool Execute()
        {
            if (this.config == null) {
                this.CompilerParametersFromFile();
            }
            return this.Execute(this.language, this.sourceFiles, this.config);
        }

        /// <summary>
        /// �p�����^���w�肵�ăR���p�C�������s���܂��B
        /// </summary>
        /// <remarks>
        /// �p�����^���w�肵�ăR���p�C�������s���܂��B
        /// �\�[�X�t�@�C�����P���̏ꍇ�ɌĂ΂�܂��B
        /// </remarks>
        /// <param name="language">�R���p�C������\�[�X�̌���B</param>
        /// <param name="souceFiles">�R���p�C������\�[�X�t�@�C���B</param>
        /// <param name="cp">�R���p�C���p�����^�B</param>
        /// <returns>�R���p�C���̐������ɂ́Atrue�B</returns>
        public bool Execute(string language, string souceFiles, CompilerParameters cp)
        {
            return this.Execute(language, new string[] { souceFiles }, cp);
        }

        /// <summary>
        /// �p�����^���w�肵�ăR���p�C�������s���܂��B
        /// </summary>
        /// <remarks>
        /// �p�����^���w�肵�ăR���p�C�������s���܂��B
        /// �\�[�X�t�@�C���������̏ꍇ�ɌĂ΂�܂��B
        /// </remarks>
        /// <param name="souceFiles">�R���p�C������\�[�X�t�@�C���B</param>
        /// <param name="language">�R���p�C������\�[�X�̌���B</param>
        /// <param name="cp">�R���p�C���p�����^�B</param>
        /// <returns>�R���p�C���̐������ɂ́Atrue�B</returns>
        public bool Execute(string language, string[] souceFiles, CompilerParameters cp)
        {
            if (souceFiles.Length == 0) {
                throw new Exception("�\�[�X�t�@�C�����ݒ肳��Ă��܂���B");
            }
            if (language == null) {
                throw new Exception("�\�[�X�̌��ꖼ���ݒ肳��Ă��܂���B");
            }
            CompilerInfo ci = CodeDomProvider.GetCompilerInfo(language);
            CodeDomProvider provider = ci.CreateProvider();

            if (!provider.Supports(GeneratorSupport.EntryPointMethod)) {
                cp.MainClass = null;
            }
            if (!provider.Supports(GeneratorSupport.Resources)) {
                cp.EmbeddedResources.Clear();
                cp.LinkedResources.Clear();
            }
            if (!provider.Supports(GeneratorSupport.Win32Resources)) {
                cp.Win32Resource = null;
            }

            // �R���p�C���̎��s
            CompilerResults cr = provider.CompileAssemblyFromFile(cp, souceFiles);

            // �R���p�C���G���[�̑Ή�
            if (cr.Errors.Count > 0) {
                List<string> errors = new List<string>();
                foreach (CompilerError e in cr.Errors) {
                    errors.Add(String.Format(
                        "FileName: {0}\nLine: {1}\nColumn: {2}\nErrorNumber: {3}\n{4}\n",
                        e.FileName, e.Line, e.Column, e.ErrorNumber, e.ErrorText));
                }
                throw new Exception(String.Join("\n", errors.ToArray()));
            }

            // �A�Z���u���̏���o�^
            this.assembly = cr.CompiledAssembly;
            this.pathToAssembly = cr.PathToAssembly;
            this.language = language;
            this.sourceFiles = souceFiles;
            this.config = cp;

            return true;
        }
    }
}
