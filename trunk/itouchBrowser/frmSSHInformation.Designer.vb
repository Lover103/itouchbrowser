<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSSHInformation
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSSHInformation))
        Me.lblPassPhrase1 = New System.Windows.Forms.Label
        Me.lblPassPhrase2 = New System.Windows.Forms.Label
        Me.txtPassphrase1 = New System.Windows.Forms.TextBox
        Me.txtPassphrase2 = New System.Windows.Forms.TextBox
        Me.lblLocalKeyDir = New System.Windows.Forms.Label
        Me.txtLocalKeyDir = New System.Windows.Forms.TextBox
        Me.btnLocalKeyDir = New System.Windows.Forms.Button
        Me.btnGenKey = New System.Windows.Forms.Button
        Me.btnCopyKey = New System.Windows.Forms.Button
        Me.btnInstallKey = New System.Windows.Forms.Button
        Me.lbl1 = New System.Windows.Forms.Label
        Me.lbl2 = New System.Windows.Forms.Label
        Me.lbl3 = New System.Windows.Forms.Label
        Me.lblKeyType = New System.Windows.Forms.Label
        Me.lblConfirm = New System.Windows.Forms.Label
        Me.fbdSSHKeyPairPath = New System.Windows.Forms.FolderBrowserDialog
        Me.lblComment = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblPassPhrase1
        '
        resources.ApplyResources(Me.lblPassPhrase1, "lblPassPhrase1")
        Me.lblPassPhrase1.Name = "lblPassPhrase1"
        '
        'lblPassPhrase2
        '
        resources.ApplyResources(Me.lblPassPhrase2, "lblPassPhrase2")
        Me.lblPassPhrase2.Name = "lblPassPhrase2"
        '
        'txtPassphrase1
        '
        resources.ApplyResources(Me.txtPassphrase1, "txtPassphrase1")
        Me.txtPassphrase1.Name = "txtPassphrase1"
        '
        'txtPassphrase2
        '
        resources.ApplyResources(Me.txtPassphrase2, "txtPassphrase2")
        Me.txtPassphrase2.Name = "txtPassphrase2"
        '
        'lblLocalKeyDir
        '
        resources.ApplyResources(Me.lblLocalKeyDir, "lblLocalKeyDir")
        Me.lblLocalKeyDir.Name = "lblLocalKeyDir"
        '
        'txtLocalKeyDir
        '
        resources.ApplyResources(Me.txtLocalKeyDir, "txtLocalKeyDir")
        Me.txtLocalKeyDir.Name = "txtLocalKeyDir"
        '
        'btnLocalKeyDir
        '
        resources.ApplyResources(Me.btnLocalKeyDir, "btnLocalKeyDir")
        Me.btnLocalKeyDir.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.OPENFOLD
        Me.btnLocalKeyDir.Name = "btnLocalKeyDir"
        Me.btnLocalKeyDir.UseVisualStyleBackColor = True
        '
        'btnGenKey
        '
        resources.ApplyResources(Me.btnGenKey, "btnGenKey")
        Me.btnGenKey.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.PrimaryKeyHS
        Me.btnGenKey.Name = "btnGenKey"
        Me.btnGenKey.UseVisualStyleBackColor = True
        '
        'btnCopyKey
        '
        resources.ApplyResources(Me.btnCopyKey, "btnCopyKey")
        Me.btnCopyKey.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.NewMessageHS
        Me.btnCopyKey.Name = "btnCopyKey"
        Me.btnCopyKey.UseVisualStyleBackColor = True
        '
        'btnInstallKey
        '
        resources.ApplyResources(Me.btnInstallKey, "btnInstallKey")
        Me.btnInstallKey.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.PageUpHS
        Me.btnInstallKey.Name = "btnInstallKey"
        Me.btnInstallKey.UseVisualStyleBackColor = True
        '
        'lbl1
        '
        resources.ApplyResources(Me.lbl1, "lbl1")
        Me.lbl1.Name = "lbl1"
        '
        'lbl2
        '
        resources.ApplyResources(Me.lbl2, "lbl2")
        Me.lbl2.Name = "lbl2"
        '
        'lbl3
        '
        resources.ApplyResources(Me.lbl3, "lbl3")
        Me.lbl3.Name = "lbl3"
        '
        'lblKeyType
        '
        resources.ApplyResources(Me.lblKeyType, "lblKeyType")
        Me.lblKeyType.Name = "lblKeyType"
        '
        'lblConfirm
        '
        resources.ApplyResources(Me.lblConfirm, "lblConfirm")
        Me.lblConfirm.Name = "lblConfirm"
        '
        'lblComment
        '
        resources.ApplyResources(Me.lblComment, "lblComment")
        Me.lblComment.Name = "lblComment"
        '
        'frmSSHInformation
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblComment)
        Me.Controls.Add(Me.lblConfirm)
        Me.Controls.Add(Me.lblKeyType)
        Me.Controls.Add(Me.lbl3)
        Me.Controls.Add(Me.lbl2)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.btnInstallKey)
        Me.Controls.Add(Me.btnCopyKey)
        Me.Controls.Add(Me.btnGenKey)
        Me.Controls.Add(Me.btnLocalKeyDir)
        Me.Controls.Add(Me.txtLocalKeyDir)
        Me.Controls.Add(Me.lblLocalKeyDir)
        Me.Controls.Add(Me.txtPassphrase2)
        Me.Controls.Add(Me.txtPassphrase1)
        Me.Controls.Add(Me.lblPassPhrase2)
        Me.Controls.Add(Me.lblPassPhrase1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSSHInformation"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbdSSHKeyPairPath As System.Windows.Forms.FolderBrowserDialog
    Private WithEvents txtPassphrase1 As System.Windows.Forms.TextBox
    Private WithEvents txtPassphrase2 As System.Windows.Forms.TextBox
    Private WithEvents txtLocalKeyDir As System.Windows.Forms.TextBox
    Private WithEvents btnLocalKeyDir As System.Windows.Forms.Button
    Private WithEvents btnGenKey As System.Windows.Forms.Button
    Private WithEvents btnCopyKey As System.Windows.Forms.Button
    Private WithEvents btnInstallKey As System.Windows.Forms.Button
    Private WithEvents lblPassPhrase1 As System.Windows.Forms.Label
    Private WithEvents lblPassPhrase2 As System.Windows.Forms.Label
    Private WithEvents lblLocalKeyDir As System.Windows.Forms.Label
    Private WithEvents lbl1 As System.Windows.Forms.Label
    Private WithEvents lbl2 As System.Windows.Forms.Label
    Private WithEvents lbl3 As System.Windows.Forms.Label
    Private WithEvents lblKeyType As System.Windows.Forms.Label
    Private WithEvents lblConfirm As System.Windows.Forms.Label
    Private WithEvents lblComment As System.Windows.Forms.Label
End Class
