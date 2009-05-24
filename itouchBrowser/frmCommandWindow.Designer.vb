<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommandWindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCommandWindow))
        Me.rtbCommand = New System.Windows.Forms.RichTextBox
        Me.txtCommand = New System.Windows.Forms.TextBox
        Me.lblCmd = New System.Windows.Forms.Label
        Me.dudCommand = New System.Windows.Forms.DomainUpDown
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbWindow = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmClear = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmClose = New System.Windows.Forms.ToolStripMenuItem
        Me.tsbCommand = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmBackupFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmCreateSSHKeyPair = New System.Windows.Forms.ToolStripMenuItem
        Me.fbdSSHKeyPairPath = New System.Windows.Forms.FolderBrowserDialog
        Me.fbdDirectoryBrowser = New System.Windows.Forms.FolderBrowserDialog
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbCommand
        '
        resources.ApplyResources(Me.rtbCommand, "rtbCommand")
        Me.rtbCommand.BackColor = System.Drawing.SystemColors.ControlLight
        Me.rtbCommand.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbCommand.Name = "rtbCommand"
        Me.rtbCommand.ReadOnly = True
        '
        'txtCommand
        '
        resources.ApplyResources(Me.txtCommand, "txtCommand")
        Me.txtCommand.Name = "txtCommand"
        '
        'lblCmd
        '
        resources.ApplyResources(Me.lblCmd, "lblCmd")
        Me.lblCmd.Name = "lblCmd"
        '
        'dudCommand
        '
        resources.ApplyResources(Me.dudCommand, "dudCommand")
        Me.dudCommand.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dudCommand.Name = "dudCommand"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbWindow, Me.tsbCommand, Me.ToolStripDropDownButton1})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'tsbWindow
        '
        Me.tsbWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbWindow.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmClear, Me.tsmClose})
        resources.ApplyResources(Me.tsbWindow, "tsbWindow")
        Me.tsbWindow.Name = "tsbWindow"
        '
        'tsmClear
        '
        Me.tsmClear.Name = "tsmClear"
        resources.ApplyResources(Me.tsmClear, "tsmClear")
        '
        'tsmClose
        '
        Me.tsmClose.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.delete
        Me.tsmClose.Name = "tsmClose"
        resources.ApplyResources(Me.tsmClose, "tsmClose")
        '
        'tsbCommand
        '
        Me.tsbCommand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbCommand.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmBackupFolder})
        resources.ApplyResources(Me.tsbCommand, "tsbCommand")
        Me.tsbCommand.Name = "tsbCommand"
        '
        'tsmBackupFolder
        '
        Me.tsmBackupFolder.Name = "tsmBackupFolder"
        resources.ApplyResources(Me.tsmBackupFolder, "tsmBackupFolder")
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmCreateSSHKeyPair})
        Me.ToolStripDropDownButton1.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.AddOnIcon
        resources.ApplyResources(Me.ToolStripDropDownButton1, "ToolStripDropDownButton1")
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        '
        'tsmCreateSSHKeyPair
        '
        Me.tsmCreateSSHKeyPair.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.warning
        Me.tsmCreateSSHKeyPair.Name = "tsmCreateSSHKeyPair"
        resources.ApplyResources(Me.tsmCreateSSHKeyPair, "tsmCreateSSHKeyPair")
        '
        'frmCommandWindow
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dudCommand)
        Me.Controls.Add(Me.lblCmd)
        Me.Controls.Add(Me.txtCommand)
        Me.Controls.Add(Me.rtbCommand)
        Me.Name = "frmCommandWindow"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmCreateSSHKeyPair As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fbdSSHKeyPairPath As System.Windows.Forms.FolderBrowserDialog
    Private WithEvents rtbCommand As System.Windows.Forms.RichTextBox
    Private WithEvents txtCommand As System.Windows.Forms.TextBox
    Private WithEvents lblCmd As System.Windows.Forms.Label
    Private WithEvents dudCommand As System.Windows.Forms.DomainUpDown
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents tsbWindow As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents tsmClear As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsmClose As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsbCommand As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents tsmBackupFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fbdDirectoryBrowser As System.Windows.Forms.FolderBrowserDialog
End Class
