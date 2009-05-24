<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSSHConfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSSHConfig))
        Me.brpPasswdConnect = New System.Windows.Forms.GroupBox
        Me.txtPasswd = New System.Windows.Forms.TextBox
        Me.lblPasswd = New System.Windows.Forms.Label
        Me.brpKeyConnect = New System.Windows.Forms.GroupBox
        Me.txtPassphrase = New System.Windows.Forms.TextBox
        Me.lblPassphrase = New System.Windows.Forms.Label
        Me.btnLocalKeyDir = New System.Windows.Forms.Button
        Me.txtKeyFileDir = New System.Windows.Forms.TextBox
        Me.lblKeyFileDir = New System.Windows.Forms.Label
        Me.grpGeneral = New System.Windows.Forms.GroupBox
        Me.cmbAuthType = New System.Windows.Forms.ComboBox
        Me.lblAuth = New System.Windows.Forms.Label
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.lblUserID = New System.Windows.Forms.Label
        Me.txtIPAddress = New System.Windows.Forms.TextBox
        Me.chkAutoSet = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.fbdSSHKeyPairPath = New System.Windows.Forms.FolderBrowserDialog
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnTestConnect = New System.Windows.Forms.Button
        Me.brpPasswdConnect.SuspendLayout()
        Me.brpKeyConnect.SuspendLayout()
        Me.grpGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'brpPasswdConnect
        '
        Me.brpPasswdConnect.AccessibleDescription = Nothing
        Me.brpPasswdConnect.AccessibleName = Nothing
        resources.ApplyResources(Me.brpPasswdConnect, "brpPasswdConnect")
        Me.brpPasswdConnect.BackgroundImage = Nothing
        Me.brpPasswdConnect.Controls.Add(Me.txtPasswd)
        Me.brpPasswdConnect.Controls.Add(Me.lblPasswd)
        Me.brpPasswdConnect.Font = Nothing
        Me.brpPasswdConnect.Name = "brpPasswdConnect"
        Me.brpPasswdConnect.TabStop = False
        '
        'txtPasswd
        '
        Me.txtPasswd.AccessibleDescription = Nothing
        Me.txtPasswd.AccessibleName = Nothing
        resources.ApplyResources(Me.txtPasswd, "txtPasswd")
        Me.txtPasswd.BackgroundImage = Nothing
        Me.txtPasswd.Font = Nothing
        Me.txtPasswd.Name = "txtPasswd"
        '
        'lblPasswd
        '
        Me.lblPasswd.AccessibleDescription = Nothing
        Me.lblPasswd.AccessibleName = Nothing
        resources.ApplyResources(Me.lblPasswd, "lblPasswd")
        Me.lblPasswd.Font = Nothing
        Me.lblPasswd.Name = "lblPasswd"
        '
        'brpKeyConnect
        '
        Me.brpKeyConnect.AccessibleDescription = Nothing
        Me.brpKeyConnect.AccessibleName = Nothing
        resources.ApplyResources(Me.brpKeyConnect, "brpKeyConnect")
        Me.brpKeyConnect.BackgroundImage = Nothing
        Me.brpKeyConnect.Controls.Add(Me.txtPassphrase)
        Me.brpKeyConnect.Controls.Add(Me.lblPassphrase)
        Me.brpKeyConnect.Controls.Add(Me.btnLocalKeyDir)
        Me.brpKeyConnect.Controls.Add(Me.txtKeyFileDir)
        Me.brpKeyConnect.Controls.Add(Me.lblKeyFileDir)
        Me.brpKeyConnect.Font = Nothing
        Me.brpKeyConnect.Name = "brpKeyConnect"
        Me.brpKeyConnect.TabStop = False
        '
        'txtPassphrase
        '
        Me.txtPassphrase.AccessibleDescription = Nothing
        Me.txtPassphrase.AccessibleName = Nothing
        resources.ApplyResources(Me.txtPassphrase, "txtPassphrase")
        Me.txtPassphrase.BackgroundImage = Nothing
        Me.txtPassphrase.Font = Nothing
        Me.txtPassphrase.Name = "txtPassphrase"
        '
        'lblPassphrase
        '
        Me.lblPassphrase.AccessibleDescription = Nothing
        Me.lblPassphrase.AccessibleName = Nothing
        resources.ApplyResources(Me.lblPassphrase, "lblPassphrase")
        Me.lblPassphrase.Font = Nothing
        Me.lblPassphrase.Name = "lblPassphrase"
        '
        'btnLocalKeyDir
        '
        Me.btnLocalKeyDir.AccessibleDescription = Nothing
        Me.btnLocalKeyDir.AccessibleName = Nothing
        resources.ApplyResources(Me.btnLocalKeyDir, "btnLocalKeyDir")
        Me.btnLocalKeyDir.BackgroundImage = Nothing
        Me.btnLocalKeyDir.Font = Nothing
        Me.btnLocalKeyDir.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.OPENFOLD
        Me.btnLocalKeyDir.Name = "btnLocalKeyDir"
        Me.btnLocalKeyDir.UseVisualStyleBackColor = True
        '
        'txtKeyFileDir
        '
        Me.txtKeyFileDir.AccessibleDescription = Nothing
        Me.txtKeyFileDir.AccessibleName = Nothing
        resources.ApplyResources(Me.txtKeyFileDir, "txtKeyFileDir")
        Me.txtKeyFileDir.BackgroundImage = Nothing
        Me.txtKeyFileDir.Font = Nothing
        Me.txtKeyFileDir.Name = "txtKeyFileDir"
        '
        'lblKeyFileDir
        '
        Me.lblKeyFileDir.AccessibleDescription = Nothing
        Me.lblKeyFileDir.AccessibleName = Nothing
        resources.ApplyResources(Me.lblKeyFileDir, "lblKeyFileDir")
        Me.lblKeyFileDir.Font = Nothing
        Me.lblKeyFileDir.Name = "lblKeyFileDir"
        '
        'grpGeneral
        '
        Me.grpGeneral.AccessibleDescription = Nothing
        Me.grpGeneral.AccessibleName = Nothing
        resources.ApplyResources(Me.grpGeneral, "grpGeneral")
        Me.grpGeneral.BackgroundImage = Nothing
        Me.grpGeneral.Controls.Add(Me.cmbAuthType)
        Me.grpGeneral.Controls.Add(Me.lblAuth)
        Me.grpGeneral.Controls.Add(Me.txtUserID)
        Me.grpGeneral.Controls.Add(Me.lblUserID)
        Me.grpGeneral.Controls.Add(Me.txtIPAddress)
        Me.grpGeneral.Controls.Add(Me.chkAutoSet)
        Me.grpGeneral.Controls.Add(Me.Label1)
        Me.grpGeneral.Font = Nothing
        Me.grpGeneral.Name = "grpGeneral"
        Me.grpGeneral.TabStop = False
        '
        'cmbAuthType
        '
        Me.cmbAuthType.AccessibleDescription = Nothing
        Me.cmbAuthType.AccessibleName = Nothing
        resources.ApplyResources(Me.cmbAuthType, "cmbAuthType")
        Me.cmbAuthType.BackgroundImage = Nothing
        Me.cmbAuthType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAuthType.Font = Nothing
        Me.cmbAuthType.FormattingEnabled = True
        Me.cmbAuthType.Items.AddRange(New Object() {resources.GetString("cmbAuthType.Items"), resources.GetString("cmbAuthType.Items1")})
        Me.cmbAuthType.Name = "cmbAuthType"
        '
        'lblAuth
        '
        Me.lblAuth.AccessibleDescription = Nothing
        Me.lblAuth.AccessibleName = Nothing
        resources.ApplyResources(Me.lblAuth, "lblAuth")
        Me.lblAuth.Font = Nothing
        Me.lblAuth.Name = "lblAuth"
        '
        'txtUserID
        '
        Me.txtUserID.AccessibleDescription = Nothing
        Me.txtUserID.AccessibleName = Nothing
        resources.ApplyResources(Me.txtUserID, "txtUserID")
        Me.txtUserID.BackgroundImage = Nothing
        Me.txtUserID.Font = Nothing
        Me.txtUserID.Name = "txtUserID"
        '
        'lblUserID
        '
        Me.lblUserID.AccessibleDescription = Nothing
        Me.lblUserID.AccessibleName = Nothing
        resources.ApplyResources(Me.lblUserID, "lblUserID")
        Me.lblUserID.Font = Nothing
        Me.lblUserID.Name = "lblUserID"
        '
        'txtIPAddress
        '
        Me.txtIPAddress.AccessibleDescription = Nothing
        Me.txtIPAddress.AccessibleName = Nothing
        resources.ApplyResources(Me.txtIPAddress, "txtIPAddress")
        Me.txtIPAddress.BackgroundImage = Nothing
        Me.txtIPAddress.Font = Nothing
        Me.txtIPAddress.Name = "txtIPAddress"
        '
        'chkAutoSet
        '
        Me.chkAutoSet.AccessibleDescription = Nothing
        Me.chkAutoSet.AccessibleName = Nothing
        resources.ApplyResources(Me.chkAutoSet, "chkAutoSet")
        Me.chkAutoSet.BackgroundImage = Nothing
        Me.chkAutoSet.Font = Nothing
        Me.chkAutoSet.Name = "chkAutoSet"
        Me.chkAutoSet.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = Nothing
        Me.Label1.AccessibleName = Nothing
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Font = Nothing
        Me.Label1.Name = "Label1"
        '
        'fbdSSHKeyPairPath
        '
        resources.ApplyResources(Me.fbdSSHKeyPairPath, "fbdSSHKeyPairPath")
        '
        'btnOK
        '
        Me.btnOK.AccessibleDescription = Nothing
        Me.btnOK.AccessibleName = Nothing
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.BackgroundImage = Nothing
        Me.btnOK.Font = Nothing
        Me.btnOK.Name = "btnOK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleDescription = Nothing
        Me.btnCancel.AccessibleName = Nothing
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.BackgroundImage = Nothing
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = Nothing
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnTestConnect
        '
        Me.btnTestConnect.AccessibleDescription = Nothing
        Me.btnTestConnect.AccessibleName = Nothing
        resources.ApplyResources(Me.btnTestConnect, "btnTestConnect")
        Me.btnTestConnect.BackgroundImage = Nothing
        Me.btnTestConnect.Font = Nothing
        Me.btnTestConnect.Name = "btnTestConnect"
        Me.btnTestConnect.UseVisualStyleBackColor = True
        '
        'frmSSHConfig
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.CancelButton = Me.btnCancel
        Me.ControlBox = False
        Me.Controls.Add(Me.btnTestConnect)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpGeneral)
        Me.Controls.Add(Me.brpKeyConnect)
        Me.Controls.Add(Me.brpPasswdConnect)
        Me.Font = Nothing
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Nothing
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSSHConfig"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.brpPasswdConnect.ResumeLayout(False)
        Me.brpPasswdConnect.PerformLayout()
        Me.brpKeyConnect.ResumeLayout(False)
        Me.brpKeyConnect.PerformLayout()
        Me.grpGeneral.ResumeLayout(False)
        Me.grpGeneral.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents brpPasswdConnect As System.Windows.Forms.GroupBox
    Private WithEvents brpKeyConnect As System.Windows.Forms.GroupBox
    Private WithEvents grpGeneral As System.Windows.Forms.GroupBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents lblPasswd As System.Windows.Forms.Label
    Private WithEvents txtUserID As System.Windows.Forms.TextBox
    Private WithEvents lblUserID As System.Windows.Forms.Label
    Private WithEvents txtIPAddress As System.Windows.Forms.TextBox
    Private WithEvents chkAutoSet As System.Windows.Forms.CheckBox
    Private WithEvents cmbAuthType As System.Windows.Forms.ComboBox
    Private WithEvents lblAuth As System.Windows.Forms.Label
    Private WithEvents txtPasswd As System.Windows.Forms.TextBox
    Private WithEvents txtKeyFileDir As System.Windows.Forms.TextBox
    Private WithEvents lblKeyFileDir As System.Windows.Forms.Label
    Private WithEvents btnLocalKeyDir As System.Windows.Forms.Button
    Friend WithEvents fbdSSHKeyPairPath As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents txtPassphrase As System.Windows.Forms.TextBox
    Private WithEvents lblPassphrase As System.Windows.Forms.Label
    Private WithEvents btnTestConnect As System.Windows.Forms.Button
End Class
