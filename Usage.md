# Introduction #
本アプリケーションは、iPod touch(jailbreak済み)のファイルシステムにUSB経由でアクセスし、
PCとtouch間でファイルのコピー・追加・削除・再生などを実現するものです。
iPhoneBrowserをベースに日本語化、安定化、機能拡張を目標にしています。

# Installation #
パッケージは、zip形式で圧縮されています。一般的な圧縮ツールやXPの機能でも展開できます。
展開後、setup.exeをダブルクリックしてください。

**バックアップディレクトリの変更 (ver 1.6.0.10の場合):**

導入直後には、バックアップ先が L:\iPodBackup になっています。次の方法で変更してください。
  * 1. メモ帳でitouchBrowser.exe.configを開く
  * 2. 65行目の次の記述を探す
> > 

&lt;setting name="BackupPath" serializeAs="String"&gt;


> > > 

&lt;value&gt;

L:\iPodBackup

&lt;/value&gt;


  * 3. L:\iPodBackupを希望のディレクトリに変更する
  * 4. ファイルメニューから「上書き保存」を選択する。
以上で次の起動からバック先が変わります。

# Usage #
スタートメニュー -> すべてのプログラム -> itouchBrowser -> itouchBrowser
で起動できます。
起動後、iPod touchをUSBで接続してください。