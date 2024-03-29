itouchBrowser　　　　　　　　　　　　　　　　　　　　2009/4/29

バージョン：1.9.2
対象OS：Windows XP 日本語または英語
前提ソフトウエア：
	Microsoft .NET Framework 2.0
	iTunes 9   http://www.apple.com/jp/itunes/download/

説明：
本アプリケーションは、iPhone又はiPod touch(jailbreak済み)のファイルシステムにUSB経由でアクセスし、
PCとtouch間でファイルのコピー・追加・削除・再生などを実現するものです。
音楽ファイルの曲名を容易に参照できます。
動画ファイルの取り込みも可能です。
バックアップした大量のファイルを容易に管理できます。
iTunes 9で使用できます。
iPod touch 2Gでの稼動も確認済みです。
iPod nanoでの稼動も確認済みです。
再生、吸出しなどの一部の機能は、nanoでも使用可能となりました。その他のiPodでも使えると思います。

導入方法：
パッケージは、zip形式で圧縮されています。一般的な圧縮ツールやXPの機能でも展開できます。
展開後、setup.exeをダブルクリックしてください。

起動方法：
スタートメニュー -> すべてのプログラム -> itouchBrowser -> itouchBrowser
で起動できます。

使用方法：
起動後、iPod touchをUSBで接続してください。touch内のフォルダーとファイルを表示します。
メニュー＞オプション＞バックアップディレクトリを選択し、バックアップ先のディレクトリを指定してください。
音楽ファイルや動画、アイコンファイルなどを選択すると、表示または演奏します。
また、そのファイルを選択してメニューから機能を選択することにより、PCへの転送やPCからの書き込みが出来ます。

日本語ファイル名：
やっとファイル名やフォルダ名が文字化けする問題を回避することが出来ました。
但し、濁点がある文字は不思議な現象が残っています。濁点を使用しなければ、問題はなくなったと思います。

バックアップファイルの管理：
バックアップ管理機能では、バックアップしたファイルが物理的にどこに保存されたのかが把握できるようになります。何度も同じファイルファイルをバックアップできますが、その重複したバックアップファイルをチェックすることも可能です。複数の同名ファイルがバックアップされていれば、その中身を比較し１バイトでも異なるものか完全に一致しているファイルなのかも確認できます。

起動の高速化：
バックアップファイルはリストで管理できますが、この機能を使うと起動時にデータベースを参照するので、起動が遅くなります。起動が遅くて困る方は、次の方法でこの機能を無効にすることが出来ます。
○メニューバーから[オプション]->[バックアップ管理機能]をクリックしてチェックをはずしてください。
次回の起動からは、データベースを読み込まないためすばやく起動できます。

動画再生機能：
動画や音楽ファイルは、ファイルを選択すると直接再生することが出来ます。このとき、データ中に埋め込まれた各種情報を表示します。歌詞が埋め込まれていると、その歌詞も表示します。アートワークも認識できれば表示します。
動画は、[拡大]ボタンを押すことによって大きな画面で再生できます。
動画ファイルにも歌詞が埋め込まれていると、歌詞表示が優先して動画が最小表示になってしまいます。

Last.fm：
音楽ファイルを選択すると[Last.fm]のタブを表示します。そのLast.fmをクリックするとその曲に関連するWebページが開きます。これは、"http://www.lastfm/music/<歌手名>"でWebページを開いているだけです。jpには、自動的にリダイレクトされるようです。
アドレスバーに[Http://〜]が表示されているときに[->]ボタンを押せば、Webページを直接ご使用のWebBrowerで開くことが出来ます。
[iPod]タブをクリックすれば、画面が元に戻ります。

iTunesタブ：
[iTunes]タブをクリックすると、iPodの/iTunes_Control/iTunes/iTunesDBファイルをPCに転送しファイルを解析します。その結果、歌手名、アルバム名、曲名、ファイルの場所などを取得することが出来ます。
その情報に基づいてフォルダーのリスト表示のときも曲名を表示しています。
一部の動画が、この方法で取得できないものがあります。フォルダー表示のときにiTunesDBからの情報が無いときは、そのデータのヘッダ部分のみを転送しながらそのヘッダー内の情報を解析しています。Musicフォルダーのファイルリストに多少遅延があるのは、この処理の時間のために起こっています。
Podcastファイルなどは、特殊な文字情報も取得するようにしています。

AMDeviceタブ：
このタブは、USBの接続時の情報を表示しています。この値が何を指しているのかは、まだまだ解明していません。何かわかった方は、教えてください。

取り扱い：
New BSD License のiPhoneBrowser (http://code.google.com/p/iphonebrowser/)を改変して作成しています。
ipodtouchBrowserもNew BSD Licenseとします。

作者への連絡先：
http://code.google.com/p/itouchbrowser/		最新情報もこちらです。
twitter:@sugi98521
ekj98521@gmail.com  =sugi=
