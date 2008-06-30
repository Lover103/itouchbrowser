itouchBrowser　　　　　　　　　　　　　　　　　　　　2008/06/29

バージョン：1.6.10
対象OS：Windows XP 日本語または英語
前提ソフトウエア：
	Microsoft .NET Framework 2.0
	iTunes 7   http://www.apple.com/jp/itunes/download/

説明：
本アプリケーションは、iPod touch(jailbreak済み)のファイルシステムにUSB経由でアクセスし、
PCとtouch間でファイルのコピー・追加・削除・再生などを実現するものです。

導入方法：
パッケージは、zip形式で圧縮されています。一般的な圧縮ツールやXPの機能でも展開できます。
展開後、setup.exeをダブルクリックしてください。

バックアップディレクトリの変更：
導入直後には、バックアップ先が L:\iPodBackup になっています。次の方法で変更してください。
１）メモ帳でitouchBrowser.exe.configを開く
２）65行目の次の記述を探す
            <setting name="BackupPath" serializeAs="String">
                <value>L:\iPodBackup</value>
３）L:\iPodBackupを希望のディレクトリに変更する
４）ファイルメニューから「上書き保存」を選択する。
以上で次の起動からバック先が変わります。

使用方法：
スタートメニュー -> すべてのプログラム -> itouchBrowser -> itouchBrowser
で起動できます。
起動後、iPod touchをUSBで接続してください。

取り扱い：
New BSD License のiPhoneBrowser (http://code.google.com/p/iphonebrowser/)を改変して作成しています。
ipodtouchBrowserもNew BSD Licenseとします。

