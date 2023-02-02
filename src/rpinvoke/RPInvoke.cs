/**
 * 伺かインターフェイス（+玉）用逆P/Invoke支援プログラム
 * 
 * 逆P/InvokeとはC#のような、managedなライブラリをunmanagedなプログラムから
 * 呼び出すための方法です。詳しくはマイクロソフトの下記サイトを参照してください。
 * http://support.microsoft.com/default.aspx?scid=kb;ja;815065#E0DB0ADAAA
 * ただし、上記の方法だけでは伺かのようなcdecl呼び出し規約に対応できませんので、
 * その対応のためには、上記の変更に加えて、エクスポートするメソッド名の直前に、
 * modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl)
 * を追加する必要があります。
 * このプログラムは逆アセンブルとその書き換え及び再コンパイルを自動で行うためのものです。
 * ソースコードのコンパイルから行うこともできます。
 * 
 * - rpinvoke.exe.configについて -
 * rpinvoke.exe.configは.NET構成ファイルです。
 * rpinvoke.exeと同じフォルダに置いてください。
 * このプログラムを使用する前に、rpinvoke.exe.configの
 * CSC/ILDASM/ILASMのパスを実行環境に合わせてください。
 * ※CSCはこのプログラムを用いてソースコードコンパイルを行わないのならば
 * 　使われないため、設定を変更しなくても問題ありません。
 * Targetは逆P/Invoke仕様に変更される実行ファイル名です。
 * rpinvoke.exeで第1引数を指定した場合は無視されます。
 * ExportClassは、エクスポートしたいメソッド
 * を含んでいるクラス名のフルネームを指定してください。
 * ExportMethodは、エクスポートしたいメソッドを,で区切って指定してください。
 * ,の間にスペースが入るとエラーになります。
 * requestのような予約語は''で囲う必要があるので注意。
 * 
 * - usage -
 * rpinvoke.exe [target [options1 [options2 [options3...]]]]
 * target: 逆P/Invokeするターゲットの実行ファイル名。省略時はconfigファイルのTarget
 * options[n]: ソースコンパイルから行う場合。コンパイラオプション及びファイル名。
 *             先にコンパイラオプションを並べ、後にソースファイルを列挙する必要があります。
 * 
 */
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;
using rpinvoke.Properties;

namespace rpinvoke
{
    // Main()のみ。完全な流れ処理
    class RPInvoke
    {
        delegate void OutputDataReceived(object sender, DataReceivedEventArgs r);

        private enum MODE {
            SEARCH_META,
            SEARCH_CLASS,
            SEARCH_METHOD,
            SEARCH_EXPORT_MARKER,
            SEARCH_END_OF_METHOD,
            SEARCH_END_OF_CLASS,
        }

        static int Main(string[] args)
        {
            // エクスポートされるアセンブリのファイル名
            string target;

            string[] methods = Settings.Default.ExportMethods.Split(',');

            if (args.Length == 0) {
                target = Settings.Default.Target;
            } else {
                target = args[0];
            }
            if (target == "") {
                Console.WriteLine("ターゲットとなるアセンブリ名が指定されていません。");
                return -1;
            }
            Console.WriteLine("ターゲット: " + target);
            Console.WriteLine();


            // エクスポートメソッドのあるクラス名（一つのクラス内にのみ対応）
            string enameclass = Settings.Default.ExportClass;
            string eclass = null;
            if (enameclass.IndexOf('.') != -1) {
                eclass = enameclass.Substring(enameclass.LastIndexOf('.') + 1);
            }

            // IL逆アセンブラとILコンパイラ
            string ildasm = Settings.Default.ILDASM;
            string ilasm  = Settings.Default.ILASM;
            if (!File.Exists(ildasm)) {
                Console.WriteLine("IL逆アセンブラが指定されたパスで見つかりません。");
                Console.WriteLine("指定されたパス: " + ildasm);
                return -1;
            } else if (!File.Exists(ilasm)) {
                Console.WriteLine("ILコンパイラが指定されたパスで見つかりません。");
                Console.WriteLine("指定されたパス: " + ilasm);
                return -1;
            }

            // 逆アセンブルで生成されるファイルの名前
            string targetIL = Path.ChangeExtension(target, ".il");

            // 外部ツールの出力のオートリダイレクタ
            OutputDataReceived dataReceiveDelegate
                = delegate(object sender, DataReceivedEventArgs r) { Console.WriteLine("> " + r.Data); };

            // 引数が2つ以上あった場合はコンパイルから始める
            string csc = Settings.Default.CSC;
            if (args.Length > 1 && File.Exists(csc)) {
                // コンパイルの実行 -------------------------------------------------------------
                Process procCSC = new Process();
                procCSC.StartInfo.FileName = csc;
                procCSC.StartInfo.Arguments = "/out:" + target + " "
                    + string.Join(" ", args, 1, args.Length - 1);
                procCSC.StartInfo.UseShellExecute = false;
                procCSC.StartInfo.RedirectStandardOutput = true;
                procCSC.OutputDataReceived += new DataReceivedEventHandler(dataReceiveDelegate);
                Console.WriteLine("コンパイルしています...");

                procCSC.Start();    // 実行

                procCSC.BeginOutputReadLine();
                procCSC.WaitForExit();

                if (procCSC.ExitCode != 0) {
                    Console.WriteLine("コンパイルに失敗しました。");
                    return -1;
                } else {
                    Console.WriteLine("コンパイルに成功しました。");
                }
                Console.WriteLine();
            } else if (args.Length > 1 && !File.Exists(csc)) {
                Console.WriteLine("コンパイラが指定されたパスで見つかりません。");
                Console.WriteLine("指定されたパス: " + csc);
                return -1;
            }


            // 逆アセンブルの実行 --------------------------------------------------------------
            Process procILDASM = new Process();
            procILDASM.StartInfo.FileName = ildasm;
            procILDASM.StartInfo.Arguments = target + " /linenum /out:" + targetIL;
            procILDASM.StartInfo.UseShellExecute = false;
            procILDASM.StartInfo.RedirectStandardOutput = true;
            procILDASM.OutputDataReceived += new DataReceivedEventHandler(dataReceiveDelegate);
            Console.WriteLine("逆アセンブルしています...");

            procILDASM.Start(); // 実行

            procILDASM.BeginOutputReadLine();
            procILDASM.WaitForExit();

            if (procILDASM.ExitCode != 0) {
                Console.WriteLine("逆アセンブルに失敗しました。");
                return -1;
            } else {
                Console.WriteLine("逆アセンブルに成功しました。");
            }
            Console.WriteLine();


            // 逆P/Invoke のためのILアセンブリの書き換え ------------------------------------
            // 逆P/Invoke 置換設定
            Dictionary<string, string> replacement = new Dictionary<string, string>();
            replacement["meta"] = ".corflags 0x00000002    // 32BITREQUIRED\n"
                                + "// Image base: 0x03DE0000\n"
                                + ".data VT_01 = int32[%TOTAL%]\n"
                                + ".vtfixup [%TOTAL%] int32 fromunmanaged at VT_01\n";
            foreach (string func in methods) {
                replacement[func] = "    .vtentry 1:%NUM%\n"
                                + "    .export [%NUM%] as %FUNC%\n";
            }
            // %TOTAL%はエクスポートされるメソッドの総数に変換される。
            // %FUNC%はreplacementのキーである関数名に変換される。
            // %NUM%はエクスポートされるメソッドの番号が自動的に割り振られる。

            // エクスポートメソッド名集積用リスト（下のエクスポートメソッド検索用正規表現で使う）
            List<string> fnExports = new List<string>();

            // 総数カウントとエクスポートメソッド名の集積
            foreach (KeyValuePair<string, string> pair in replacement) {
                if (pair.Key == "meta") {
                    continue;
                }
                fnExports.Add(pair.Key);
            }
            // エクスポートメソッド検索用正規表現
            Regex reFnList = new Regex(
                " (" + String.Join("|", fnExports.ToArray()) + ")\\(", RegexOptions.Compiled);
            // CDECL呼び出し規約
            string callConv = "modopt([mscorlib]System.Runtime.CompilerServices.CallConvCdecl) ";

            // ILの書き換えパーサ
            Console.WriteLine("ILアセンブリの変換中...");
            StreamReader reader = new StreamReader(targetIL);
            string[] lines = reader.ReadToEnd().Replace("\r\n", "\n").Split('\n');
            reader.Close();
            int count = 0;
            string modified = "";
            string method = "";
            //bool isTargetClass = false;
            Match m;
            MODE mode = MODE.SEARCH_META;
            for (int i = 0; i < lines.Length; i++) {
                string line = lines[i];
                switch (mode) {
                    case MODE.SEARCH_META: // メタデータの検索
                        if (line.StartsWith(".corflags")) {
                            if (line.EndsWith("// 32BITREQUIRED")) {
                                // 既に書き換え済み？
                                Console.WriteLine(targetIL + "は既に逆P/Invoke仕様に書き換えられている");
                                Console.WriteLine("可能性があるため処理を中断します。");
                                Console.WriteLine();
                                Console.WriteLine(target + "は書き換えられませんでした。");
                                return -1;
                            }
                            // メタデータの書き換え
                            line = replacement["meta"];
                            Console.WriteLine("    メタデータの書き換え");
                            i++;
                            mode = MODE.SEARCH_CLASS;
                        }
                        break;
                    case MODE.SEARCH_CLASS: // エクスポートクラスの検索
                        if (line.IndexOf(".class") != -1 && line.EndsWith(enameclass)) {
                            // エクスポート関数のあるクラスの始まり
                            Console.WriteLine("    ターゲットクラス: " + enameclass + "の解析開始");
                            mode = MODE.SEARCH_METHOD;
                        }
                        break;
                    case MODE.SEARCH_METHOD: // エクスポートクラス内：エクスポート関数の検索
                        if (line.EndsWith("// end of class " + enameclass)) {
                            // エクスポート関数のあるクラスの終わり
                            Console.WriteLine("    ターゲットクラス: " + enameclass + "の解析終了");
                            mode = MODE.SEARCH_END_OF_CLASS;
                        } else if ((m = reFnList.Match(line)).Success) {
                            // エクスポート関数の発見
                            method = m.Groups[1].Value;
                            // 呼び出し規約の挿入
                            line = line.Insert(line.IndexOf(method), callConv);
                            mode = MODE.SEARCH_EXPORT_MARKER;
                        }
                        break;
                    case MODE.SEARCH_EXPORT_MARKER: // エクスポート関数内：エクスポートマーカの検索
                        if (line.IndexOf(".maxstack") != -1) {
                            // 関数のエクスポートを実装
                            count++;
                            line = replacement[method].Replace(
                                "%NUM%", count.ToString()).Replace("%FUNC%", method) + line;
                            Console.WriteLine("        " + method + "のエクスポートを完了");
                            mode = MODE.SEARCH_END_OF_METHOD;
                        }
                        break;
                    case MODE.SEARCH_END_OF_METHOD: // エクスポート関数内：メソッドの終端を検索
                        if (line.EndsWith("// end of method " + eclass + "::" + method)) {
                            // エクスポート関数の終了
                            mode = MODE.SEARCH_METHOD;
                        }
                        break;
                    case MODE.SEARCH_END_OF_CLASS: break;
                }
                modified += line + "\n";
            }
            modified = modified.Replace("%TOTAL%", count.ToString());
            Console.WriteLine("ILアセンブリの変換終了");
            Console.WriteLine();


            // 置換結果の書き込み ------------------------------------------------------
            Console.WriteLine("ILアセンブリに書き込んでいます...");
            StreamWriter writer = new StreamWriter(targetIL);
            writer.Write(modified);
            writer.Close();
            Console.WriteLine("ILアセンブリの書き込みを終了しました。");
            Console.WriteLine();


            // ターゲットファイルのバックアップを作成 ------------------------------------
            string targetBak = target + ".bak";
            if (File.Exists(target)) {
                File.Copy(target, targetBak, true);
                Console.WriteLine("ターゲットのバックアップ" + targetBak + "を作成しました。");
                Console.WriteLine();
            } else {
                Console.WriteLine(target + "が存在しません。");
                return -1;
            }


            // 再コンパイル -------------------------------------------------------------
            Console.WriteLine("再コンパイルしています...");
            string resource = Path.ChangeExtension(target, ".res");
            Process procILASM = new Process();
            procILASM.StartInfo.FileName = ilasm;
            procILASM.StartInfo.Arguments =
                " /dll " + targetIL + " /out:" + target + " /res:" + resource;
            procILASM.StartInfo.UseShellExecute = false;
            procILASM.StartInfo.RedirectStandardOutput = true;
            procILASM.OutputDataReceived += new DataReceivedEventHandler(dataReceiveDelegate);

            procILASM.Start(); // 実行

            procILASM.BeginOutputReadLine();
            procILASM.WaitForExit();

            if (procILASM.ExitCode != 0) {
                Console.WriteLine("再コンパイルに失敗しました。");
                return -1;
            } else {
                Console.WriteLine("再コンパイルに成功しました。");
                Console.WriteLine();
                Console.WriteLine(target + "は逆P/Invoke仕様に書き換えられました。");
            }

            return 0;   // 正常終了
        }
    }
}
