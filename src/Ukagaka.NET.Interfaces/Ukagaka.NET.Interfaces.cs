using System;

namespace Ukagaka.NET.Interfaces
{
    /// <summary>
    /// ロード時に呼ばれるメソッドを返すインターフェイスです。単独では使用しません。
    /// </summary>
    public interface ILoad
    {
        /// <summary>
        /// ロード時に必要な処理を行います。
        /// </summary>
        /// <remarks>
        /// <para>
        /// アセンブリのロード時に呼ばれます。
        /// アセンブリの実行のために必要な初期化を行います。
        /// </para>
        /// <para>
        /// <c>Marshal.FreeHGlobal</c>を用い
        /// <c>h</c>に割り当てられたメモリを解放してください。
        /// </para>
        /// </remarks>
        /// <param name="h">パス文字列を格納したメモリへのポインタ。</param>
        /// <param name="len"><c>h</c>で示される文字列の長さ。</param>
        /// <returns>
        /// <para>処理の成功時には、true。</para>
        /// <para>処理の失敗時には、false。</para>
        /// </returns>
        bool load(IntPtr h, int len);
    }

    /// <summary>
    /// アンロード時に呼ばれるメソッドを返すインターフェイスです。単独では使用しません。
    /// </summary>
    public interface IUnload
    {
        /// <summary>
        /// アンロード時に必要な処理を行います。
        /// </summary>
        /// <remarks>
        /// アセンブリの終了時に呼ばれます。
        /// リソースの解放やリロードに必要な準備等を行います。
        /// </remarks>
        /// <returns>
        /// <para>処理の成功時には、true。</para>
        /// <para>処理の失敗時には、false。</para>
        /// </returns>
        bool unload();
    }

    /// <summary>
    /// リクエスト時に呼ばれるメソッドを返すインターフェイスです。単独では使用しません。
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// イベントを処理します。
        /// </summary>
        /// <remarks>
        /// <para>
        /// <c>Marshal.FreeHGlobal</c>を用い<c>h</c>に割り当てられた
        /// メモリを解放し、戻り値となる文字列の長さを<c>len</c>に代入、
        /// <c>Marshal.StringToHGlobalAnsi</c>で戻り値となる文字列をグローバルメモリにコピーして返してください。
        /// </para>
        /// </remarks>
        /// <param name="h">リクエスト文字列を格納したメモリへのポインタ。</param>
        /// <param name="len"><c>h</c>で示される文字列の長さ。戻り値となる文字列の長さを代入する。</param>
        /// <returns>レスポンス文字列を格納したメモリへのポインタ。</returns>
        IntPtr request(IntPtr h, ref int len);
    }

    /// <summary>
    /// バージョン情報を返すインターフェイスです。単独では使用しません。
    /// </summary>
    public interface IGetVersion
    {
        /// <summary>
        /// プロトコルの種類とバージョンの確認時に呼ばます。
        /// </summary>
        /// <remarks>
        /// 戻り値となる文字列の長さを<c>len</c>に代入、
        /// <c>Marshal.StringToHGlobalAnsi</c>で戻り値となる文字列をグローバルメモリにコピーして返してください。
        /// 戻り値となる文字列は、PROTOCOL/MAJORVERSION.MINORVERSIONという形で返してください。(例:SHIORI/3.0)
        /// </remarks>
        /// <param name="len">戻り値となる文字列の長さを代入する。</param>
        /// <returns>戻り値となる文字列を格納したメモリへのポインタ。</returns>
        IntPtr getversion(ref int len);
    }

    /// <summary>
    /// ベースウェアからの通知イベントを処理するインターフェイスです。単独では使用しません。
    /// </summary>
    public interface INotify
    {
        /// <summary>
        /// イベントを処理します。
        /// </summary>
        /// <remarks>
        /// 本体からのイベント通知時に呼ばれます。
        /// 通知されるイベントの種類については、<a href="http://usada.sakura.vg/contents/plugin.html">プラグイン</a>
        /// を参照してください。
        /// </remarks>
        /// <param name="h">リクエスト文字列を格納したメモリへのポインタ。</param>
        /// <param name="len"><c>h</c>で示される文字列の長さ。参照渡しになっている理由は不明。</param>
        void notify(IntPtr h, ref int len);
    }

    /// <summary>
    /// プラグインとしてベースウェアのメニューから選択された時に呼ばれるインターフェイスです。単独では使用しません。
    /// </summary>
    public interface IConfigure
    {
        /// <summary>
        /// ポップアップメニュー上からプラグインが選択された時の処理を行います。
        /// </summary>
        /// <remarks>
        /// ユーザーの混乱を避けるために、ダイアログにaboutを表示するなどの何らかの反応をするようにしてください。
        /// </remarks>
        /// <param name="h">未文書化。恐らく本体のウィンドウハンドル。</param>
        void configure(IntPtr h);
    }

    /// <summary>
    /// ベースウェアがヘッドライン情報を取得した時に呼ばれるインターフェイスです。単独では使用しません。
    /// </summary>
    public interface IExecute
    {
        /// <summary>
        /// ダウンロードしたヘッドラインを解析した結果を返します。
        /// </summary>
        /// <remarks>
        /// <para>
        /// <c>Marshal.FreeHGlobal</c>を用い<c>h</c>に割り当てられた
        /// メモリを解放し、戻り値となる文字列の長さを<c>len</c>に代入、
        /// <c>Marshal.StringToHGlobalAnsi</c>で戻り値となる文字列をグローバルメモリにコピーして返してください。
        /// </para>
        /// </remarks>
        /// <param name="h">ダウンロードされたファイルのパス文字列を格納したメモリへのポインタ。</param>
        /// <param name="len"><c>h</c>で示される文字列の長さ。</param>
        /// <returns>CR+LF を改行コードとする表示させたい文字列を格納したメモリへのポインタ。</returns>
        IntPtr execute(IntPtr h, ref int len);
    }

    /// <summary>
    /// ベースウェアがスケジュール取得URLを要求した時に呼ばれるインターフェイスです。単独では使用しません。
    /// </summary>
    public interface IGetUrl
    {
        /// <summary>
        /// スケジュールをセンスするURLを返します。
        /// </summary>
        /// <remarks>
        /// 戻り値となる文字列の長さを<c>len</c>に代入、
        /// <c>Marshal.StringToHGlobalAnsi</c>で戻り値となる文字列をグローバルメモリにコピーして返してください。
        /// 戻り値となる文字列のフォーマットに関しては<a href="http://ssp.shillest.net/docs/calendar.html#sensor">スケジュールセンサ</a>
        /// を参照してください。
        /// </remarks>
        /// <param name="len">戻り値となる文字列の長さを代入する。</param>
        /// <param name="year">未文書化。恐らく現在年。</param>
        /// <param name="month">未文書化。恐らく現在月。</param>
        /// <param name="day">未文書化。恐らく現在日。</param>
        /// <returns><c>year</c>, <c>month</c>, <c>day</c>に相当するスケジュール用URLを格納したメモリへのポインタ。</returns>
        IntPtr geturl(ref int len, int year, int month, int day);
    }

    /// <summary>
    /// ベースウェアが、ダウンロードしたスケジュールを解析するよう要求した時に呼ばれます。単独では使用しません。
    /// </summary>
    public interface IGetSchedule
    {
        /// <summary>
        /// スケジュールを解析してスケジュールデータを返します。
        /// </summary>
        /// <remarks>
        /// <para>
        /// <c>Marshal.FreeHGlobal</c>を用い<c>h</c>に割り当てられた
        /// メモリを解放し、戻り値となる文字列の長さを<c>len</c>に代入、
        /// <c>Marshal.StringToHGlobalAnsi</c>で戻り値となる文字列をグローバルメモリにコピーして返してください。
        /// 戻り値となる文字列のフォーマットに関しては<a href="http://ssp.shillest.net/docs/calendar.html#sensor">スケジュールセンサ</a>
        /// を参照してください。
        /// </para>
        /// </remarks>
        /// <param name="h">指定されたURLから取得したHTMLファイルへの絶対パスを格納したメモリへのポインタ。</param>
        /// <param name="len"><c>h</c>で示される文字列の長さ。戻り値となる文字列の長さを代入する。</param>
        /// <returns>戻り値となる文字列を格納したメモリへのポインタ。</returns>
        IntPtr getschedule(IntPtr h, ref int len);
    }

    /// <summary>
    /// ベースウェアが、スケジュールをアップデートするためのURLを要求した時に呼ばれます。単独では使用しません。
    /// </summary>
    public interface IGetUrlPost
    {
        /// <summary>
        /// スケジュール投稿のためのURLとパラメタを返します。
        /// </summary>
        /// <remarks>
        /// <para>
        /// <c>Marshal.FreeHGlobal</c>を用い<c>h</c>に割り当てられた
        /// メモリを解放し、戻り値となる文字列の長さを<c>len</c>に代入、
        /// <c>Marshal.StringToHGlobalAnsi</c>で戻り値となる文字列をグローバルメモリにコピーして返してください。
        /// 戻り値となる文字列のフォーマットに関しては<a href="http://ssp.shillest.net/docs/calendar.html#sensor">スケジュールセンサ</a>
        /// を参照してください。
        /// </para>
        /// </remarks>
        /// <param name="h">スケジュールデータフォーマットの文字列を格納したメモリへのポインタ。</param>
        /// <param name="len"><c>h</c>で示される文字列の長さ。戻り値となる文字列の長さを代入する。</param>
        /// <param name="method">メソッド示す値を代入して返す。0でGET、1でPOST。</param>
        /// <returns>
        /// スケジュール投稿用URL文字列を格納したメモリへのポインタ。
        /// </returns>
        IntPtr geturlpost(IntPtr h, ref int len, ref int method);
    }

    /// <summary>
    /// SHIORI/2.0のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// SHIORI/2.0に対応するインターフェイスです。
    /// ILoad, IUnload, IRequestインターフェイスを実装している必要があります。
    /// </remarks>
    [Obsolete("このインターフェイスは古い仕様です。IShiori30を使用してください。")]
    public interface IShiori20 : ILoad, IUnload, IRequest
    {
    }

    /// <summary>
    /// SHIORI/2.1のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// SHIORI/2.1に対応するインターフェイスです。
    /// ILoad, IUnload, IRequestインターフェイスを実装している必要があります。
    /// </remarks>
    [Obsolete("このインターフェイスは古い仕様です。IShiori30を使用してください。")]
    public interface IShiori21 : ILoad, IUnload, IRequest
    {
    }

    /// <summary>
    /// SHIORI/2.2のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// SHIORI/2.2に対応するインターフェイスです。
    /// ILoad, IUnload, IRequestインターフェイスを実装している必要があります。
    /// </remarks>
    [Obsolete("このインターフェイスは古い仕様です。IShiori30を使用してください。")]
    public interface IShiori22 : ILoad, IUnload, IRequest
    {
    }

    /// <summary>
    /// SHIORI/2.3のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// SHIORI/2.3に対応するインターフェイスです。
    /// ILoad, IUnload, IRequestインターフェイスを実装している必要があります。
    /// </remarks>
    [Obsolete("このインターフェイスは古い仕様です。IShiori30を使用してください。")]
    public interface IShiori23 : ILoad, IUnload, IRequest
    {
    }

    /// <summary>
    /// SHIORI/2.4のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// SHIORI/2.4に対応するインターフェイスです。
    /// ILoad, IUnload, IRequestインターフェイスを実装している必要があります。
    /// </remarks>
    [Obsolete("このインターフェイスは古い仕様です。IShiori30を使用してください。")]
    public interface IShiori24 : ILoad, IUnload, IRequest
    {
    }

    /// <summary>
    /// SHIORI/2.5のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// SHIORI/2.5に対応するインターフェイスです。
    /// ILoad, IUnload, IRequestインターフェイスを実装している必要があります。
    /// </remarks>
    [Obsolete("このインターフェイスは古い仕様です。IShiori30を使用してください。")]
    public interface IShiori25 : ILoad, IUnload, IRequest
    {
    }

    /// <summary>
    /// SHIORI/2.6のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// SHIORI/2.6に対応するインターフェイスです。
    /// ILoad, IUnload, IRequestインターフェイスを実装している必要があります。
    /// </remarks>
    [Obsolete("このインターフェイスは古い仕様です。IShiori30を使用してください。")]
    public interface IShiori26 : ILoad, IUnload, IRequest
    {
    }

    /// <summary>
    /// SHIORI/3.0のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// SHIORI/3.0に対応するインターフェイスです。
    /// ILoad, IUnload, IRequestインターフェイスを実装している必要があります。
    /// </remarks>
    public interface IShiori30 : ILoad, IUnload, IRequest
    {
    }

    /// <summary>
    /// SAORI/1.0のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// SAORI/1.0に対応するインターフェイスです。
    /// ILoad, IUnload, IRequestインターフェイスを実装している必要があります。
    /// </remarks>
    public interface ISaori10 : ILoad, IUnload, IRequest
    {
    }

    /// <summary>
    /// MAKOTO/2.0のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// MAKOTO/2.0に対応するインターフェイスです。
    /// ILoad, IUnload, IRequestインターフェイスを実装している必要があります。
    /// </remarks>
    public interface IMakoto20 : ILoad, IUnload, IRequest
    {
    }

    /// <summary>
    /// PLUGIN/2.0のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// PLUGIN/2.0に対応するインターフェイスです。
    /// ILoad, IUnload, IRequestインターフェイスを実装している必要があります。
    /// </remarks>
    public interface IPlugin20 : ILoad, IUnload, IRequest
    {
    }

    /// <summary>
    /// PLUGIN/1.0のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// PLUGIN/1.0で使用します。
    /// ILoad, IUnload, IGetVersion, INotify, IConfigureインターフェイスを実装している必要があります。
    /// 詳しい内容に関しては、<a href="http://usada.sakura.vg/contents/plugin.html">プラグイン</a>
    /// を参照してください。
    /// </remarks>
    public interface IPlugin10 : ILoad, IUnload, IGetVersion, INotify, IConfigure
    {
    }

    /// <summary>
    /// HEADLINE/1.1のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// <para>
    /// HEADLINE/1.1で使用します。
    /// ILoad, IUnload, IGetVersion, IExecuteインターフェイスを実装している必要があります。
    /// </para>
    /// <para>
    /// 詳しい内容に関しては、<a href="http://usada.sakura.vg/contents/headlinesenser.html">ヘッドラインセンサ</a>
    /// を参照してください。
    /// </para>
    /// </remarks>
    public interface IHeadline11 : ILoad, IUnload, IGetVersion, IExecute
    {
    }

    /// <summary>
    /// SCHEDULE/1.0のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// SCHEDULE/1.0で使用します。
    /// ILoad, IUnload, IGetVersion, IGetUrl, IGetSchedule, IGetUrlPostインターフェイスを実装している必要があります。
    /// <para>
    /// 詳しい内容に関しては<a href="http://ssp.shillest.net/docs/calendar.html#sensor">スケジュールセンサ</a>
    /// を参照してください。
    /// </para>
    /// </remarks>
    [Obsolete("このインターフェイスは古い仕様です。ISchedule20を使用してください。")]
    public interface ISchedule10 : ILoad, IUnload, IGetVersion, IGetUrl, IGetSchedule, IGetUrlPost
    {
    }

    /// <summary>
    /// SCHEDULE/2.0のインターフェイスです。
    /// </summary>
    /// <remarks>
    /// <para>
    /// SCHEDULE/2.0で使用します。
    /// ILoad, IUnload, IRequest, IGetVersionインターフェイスを実装している必要があります。</para>
    /// <para>
    /// 詳しい内容に関しては、<a href="http://ssp.shillest.net/docs/schedule.txt">SCHEDULE/2.0</a>
    /// を参照してください。
    /// </para>
    /// </remarks>
    public interface ISchedule20 : ILoad, IUnload, IRequest, IGetVersion
    {
    }
}
