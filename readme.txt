

D.N.Proxy (.NET Proxy)
Version 2.0.0.0


【作者】
摂理


【概要】
伺かインターフェイス（後述）を持ち、同インターフェイスを持つ
.NET言語のソースコードと本体との通信を中継するライブラリです。
ソースコードは実行時にコンパイルされます。
玉[http://umeici.hp.infoseek.co.jp/のtama(debugger for aya)]による
デバッグとリアルタイム表示が可能なログ共有機能及び
.NET言語コンパイル機能を外部からも利用できます。


【利用方法】
.NET Framework2.0が導入された環境で、
.NETに対応した言語であることと、
伺かインターフェイスを継承したクラスを持つこと
という条件を満たしたソースコードがあれば動作します。

dnproxy.dll, dnutil.dll, Ukagaka.NET.Interfaces.dll
をベースディレクトリに入れてください。

コンパイル時の設定はdnproxy.iniで行います。
詳しくは、dnproxy.iniを参照してください。

dnproxy.dll.configでログの設定を行えます。
詳しくは、後述の【dnproxy.dll.configによる設定】を参照してください。

ソースコード上で何をするかは自由です。
.NET Frameworkの機能は全て使えるはずです。

【配布時】
Version2.0.0.0以降、配布時には必ずしもソースコードを同梱する必要がなくなりました。
実行時コンパイルする必要がない場合は、
descript.txt
dnproxy.dll.config
Ukagaka.NET.Interfaces.dll
user.dll（dnproxy.dll.configのAssemblyNameで指定したdll）
だけあれば動きます。
（dnutil.dllを参照アセンブリ[dnproxy.iniのReferencedAssembly]に
加えている場合はdnutil.dllも必要です）


【対応プロトコル】
SHIORI/2.0 ～ SHIORI/2.6, SHIORI/3.0, MAKOTO/2.0, PLUGIN/1.0, PLUGIN/2.0
HEADLINE/1.1, SCHEDULE/1.0, SCHEDULE/2.0, SAORI/1.0


【伺かインターフェイス】
便宜的にそう呼んでいるだけで、正式名称ではないと思います。
詳しくは、添付のdnproxy.chmをご参照ください。

インターフェイスの仕様は.NET版ではありますが、
本質的には伺かで要求しているインターフェイスの仕様と全く同じものです。
D.N.Proxyは、本体から渡された変数をそのままコンパイルされたアセンブリへ渡します。


【デバッグ機能とコンパイル機能】
詳しくは、添付のdnproxy.chmをご参照ください。


【dnproxy.dll.configによる設定】
Version1.1.0.0までdescript.txtで設定していたログ設定を
Version1.2.0.0以降、dnproxy.dll.configで行うようになりました。
dnproxy.dll.configをテキストエディタで編集してください。
基本的な記述方式は1.1.0.0以前と変わりません。
PrivateBinPath: アセンブリを検索するパスです。
ベースディレクトリ相対パスです。複数ある場合は;で区切ってください。

AssemblyName: ユーザーソースコードから生成するアセンブリの名前です。
dnproxy.iniのOutputAssemblyを省略した場合この名前が使われます。

MainClass: ユーザーソースコードコンパイル後に呼び出して欲しいクラス名です。
dnproxy.iniのMainClassを省略した場合この名前が使われます。

Protocol: ユーザーソースコードのプロトコルです。
上述の【対応プロトコル】のいずれかである必要があります。

logfile: ログファイル名を設定します。

logtype: ログの取る方式を設定します。
// 0: 取らない
// 1: チェックツール（玉）に表示
// 2: 玉が存在しない場合ファイルに取る

loglevel: ログを取る警告レベル。複数ある場合は | で区切ります。
// INFO:    情報
// NOTICE:  注記
// WARNING: 警告
// ERROR:   続行可能なエラー
// FATAL:   致命的なエラー

logcharset: ログの文字コード
// Shift_JIS or UTF-8


【動作環境】
.NET Frameworkランタイム 2.0以上がインストールされている必要があります
開発環境よりも、動作させる環境の方が重要です。
.NET Frameworkランタイム 2.0が標準で使えるのはC#、VB、JScriptです。
その他は環境によって別途言語プロバイダのアセンブリ
(System.言語名.dll)が必要かもしれません。


【開発言語】
C# 2.0


【開発環境】
Windows 2000 SP4
Visual C# 2005 Express Edition
nDoc1.3.1


【LICENSE】
Public Domain Software.


【D.N.Proxyのソースコードについて】
Visual C# 2005 Express Editionで作成されています。
C#の仕様上、アセンブリは逆P/Inokeしないと伺かのようなネイティブコードから呼び出すことができません。
そこでD.N.Proxyでは、伺かインターフェイスの逆P/Inoke対応を支援するプログラムを添付しています。
逆P/Inokeの仕様について詳しくはRPInvoke.csをご参照ください。
添付のソリューションでは、標準でD.N.Proxyのビルド後に
自動的に逆P/Inoke対応のアセンブリにコンパイルされるように設定されています。
