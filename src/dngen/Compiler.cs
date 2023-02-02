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
    /// .NET言語のソースコードをコンパイルします。
    /// </summary>
    /// <remarks>
    /// .NET言語のソースコードを動的にコンパイルする機能を提供します。
    /// </remarks>
    internal class Compiler
    {
        /// <summary>
        /// コンパイルされたアセンブリへの参照を保持します。
        /// </summary>
        private Assembly assembly;
        /// <summary>
        /// コンパイルされたアセンブリへの参照を返します。
        /// </summary>
        /// <value>コンパイルされたアセンブリへの参照。</value>
        public Assembly Assembly {
            get { return this.assembly; }
        }

        /// <summary>
        /// コンパイルされたアセンブリのパスを保持します。
        /// </summary>
        private string pathToAssembly;
        /// <summary>
        /// コンパイルされたアセンブリのパスを返します。
        /// </summary>
        /// <value>コンパイルされたアセンブリのパス。</value>
        public string PathToAssembly {
            get { return this.pathToAssembly; }
        }

        /// <summary>
        /// コンパイルされるアセンブリのソースの言語を保持します。
        /// </summary>
        private string language;
        /// <summary>
        /// コンパイルされるアセンブリのソースの言語を返します。
        /// </summary>
        /// <value>コンパイルされたアセンブリのソースの言語。</value>
        public string Language {
            get { return this.language; }
        }

        /// <summary>
        /// コンパイルされるソースファイル名を保持します。
        /// </summary>
        private string[] sourceFiles;
        /// <summary>
        /// コンパイルされるソースファイル名を返します。
        /// </summary>
        /// <value>コンパイルされたソースファイル名</value>
        public string[] SourceFiles {
            get { return this.sourceFiles; }
        }

        /// <summary>
        /// コンパイル時のパラメタを保持します。
        /// </summary>
        private CompilerParameters config;
        /// <summary>
        /// コンパイル時のパラメタを返します。
        /// </summary>
        /// <value>コンパイル時のパラメタ。</value>
        public CompilerParameters Config {
            get { return this.config; }
        }

        /// <summary>
        /// コンパイル設定を記述したファイルを保持します。
        /// </summary>
        private string configFile;
        /// <summary>
        /// コンパイル設定を記述したファイル名を設定します。
        /// </summary>
        /// <value>コンパイル設定を記述したファイル名。</value>
        public string ConfigFile {
            set { this.configFile = value; }
            get { return this.configFile;  }
        }

        /// <summary>
        /// <c>list</c>に渡されたフォルダ・ファイルリストをフルパスにしてyieldで返します。
        /// </summary>
        /// <param name="basedir">ファイルを検索する基準ディレクトリ。</param>
        /// <param name="list">検索するファイルのリスト。</param>
        /// <param name="searchGac">GACフォルダを検索対称に含む場合、true。含まない場合、false。</param>
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
        /// <c>CompilerParameters</c>クラスをコンパイル設定ファイルから生成し返します。
        /// </summary>
        /// <remarks>
        /// 先に<c>ConfigFile</c>プロパティにコンパイル設定ファイルを指定しておく必要があります。
        /// </remarks>
        /// <returns>生成後の<c>CompilerParameters</c>クラス。</returns>
        public CompilerParameters CompilerParametersFromFile()
        {
            return this.CompilerParametersFromFile(this.ConfigFile);
        }

        /// <summary>
        /// <c>CompilerParameters</c>をコンパイル設定ファイルから生成し返します。
        /// </summary>
        /// <param name="config">コンパイル設定ファイルのパス。</param>
        /// <returns>生成後の<c>CompilerParameters</c>クラス。</returns>
        public CompilerParameters CompilerParametersFromFile(string config)
        {
            if (this.configFile == "") {
                throw new Exception("設定ファイル名が指定されていません。");
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
        /// コンパイル設定ファイルから得た情報を元にコンパイルします。
        /// </summary>
        /// <remarks>
        /// コンパイル設定ファイルから得た情報を元にコンパイルします。パスは設定ファイルの位置に依存します。
        /// コンパイル設定ファイルの仕様に関してはコンパイル設定ファイルを参照してください。
        /// </remarks>
        /// <returns>コンパイルの成功時には、true。</returns>
        public bool Execute()
        {
            if (this.config == null) {
                this.CompilerParametersFromFile();
            }
            return this.Execute(this.language, this.sourceFiles, this.config);
        }

        /// <summary>
        /// パラメタを指定してコンパイルを実行します。
        /// </summary>
        /// <remarks>
        /// パラメタを指定してコンパイルを実行します。
        /// ソースファイルが単数の場合に呼ばれます。
        /// </remarks>
        /// <param name="language">コンパイルするソースの言語。</param>
        /// <param name="souceFiles">コンパイルするソースファイル。</param>
        /// <param name="cp">コンパイルパラメタ。</param>
        /// <returns>コンパイルの成功時には、true。</returns>
        public bool Execute(string language, string souceFiles, CompilerParameters cp)
        {
            return this.Execute(language, new string[] { souceFiles }, cp);
        }

        /// <summary>
        /// パラメタを指定してコンパイルを実行します。
        /// </summary>
        /// <remarks>
        /// パラメタを指定してコンパイルを実行します。
        /// ソースファイルが複数の場合に呼ばれます。
        /// </remarks>
        /// <param name="souceFiles">コンパイルするソースファイル。</param>
        /// <param name="language">コンパイルするソースの言語。</param>
        /// <param name="cp">コンパイルパラメタ。</param>
        /// <returns>コンパイルの成功時には、true。</returns>
        public bool Execute(string language, string[] souceFiles, CompilerParameters cp)
        {
            if (souceFiles.Length == 0) {
                throw new Exception("ソースファイルが設定されていません。");
            }
            if (language == null) {
                throw new Exception("ソースの言語名が設定されていません。");
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

            // コンパイルの実行
            CompilerResults cr = provider.CompileAssemblyFromFile(cp, souceFiles);

            // コンパイルエラーの対応
            if (cr.Errors.Count > 0) {
                List<string> errors = new List<string>();
                foreach (CompilerError e in cr.Errors) {
                    errors.Add(String.Format(
                        "FileName: {0}\nLine: {1}\nColumn: {2}\nErrorNumber: {3}\n{4}\n",
                        e.FileName, e.Line, e.Column, e.ErrorNumber, e.ErrorText));
                }
                throw new Exception(String.Join("\n", errors.ToArray()));
            }

            // アセンブリの情報を登録
            this.assembly = cr.CompiledAssembly;
            this.pathToAssembly = cr.PathToAssembly;
            this.language = language;
            this.sourceFiles = souceFiles;
            this.config = cp;

            return true;
        }
    }
}
