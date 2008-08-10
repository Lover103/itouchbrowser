Public NotInheritable Class frmSplashScreen

    'TODO: このフォームは、プロジェクト デザイナ ([プロジェクト] メニューの下の [プロパティ]) の [アプリケーション] タブを使用して、
    '  アプリケーションのスプラッシュ スクリーンとして簡単に設定することができます


    Private Sub frmSplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'アプリケーションのアセンブリ情報に従って、ランタイムにダイアログ テキストを設定します。  

        'TODO: [プロジェクト] メニューの下にある [プロジェクト プロパティ] ダイアログの [アプリケーション] ペインで、アプリケーションのアセンブリ情報を 
        '  カスタマイズします

        'アプリケーション タイトル
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'アプリケーション タイトルがない場合は、拡張子なしのアプリケーション名を使用します
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Version.Text = System.String.Format(Version.Text, _
                My.Application.Info.Version.Major, _
                My.Application.Info.Version.Minor, _
                My.Application.Info.Version.Build, _
                My.Application.Info.Version.Revision)

        '著作権情報
        Copyright.Text = My.Application.Info.Copyright
    End Sub

End Class
