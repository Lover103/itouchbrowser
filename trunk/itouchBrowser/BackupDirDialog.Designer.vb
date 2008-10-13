<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BackupDirDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BackupDirDialog))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.btnBackupPath = New System.Windows.Forms.Button
        Me.lblBackupPath = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.txtDbPath = New System.Windows.Forms.TextBox
        Me.btnDbPath = New System.Windows.Forms.Button
        Me.lblDbPath = New System.Windows.Forms.Label
        Me.ckbBackupControl = New System.Windows.Forms.CheckBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        resources.ApplyResources(Me.TableLayoutPanel1, "TableLayoutPanel1")
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        '
        'OK_Button
        '
        resources.ApplyResources(Me.OK_Button, "OK_Button")
        Me.OK_Button.Name = "OK_Button"
        '
        'Cancel_Button
        '
        resources.ApplyResources(Me.Cancel_Button, "Cancel_Button")
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Name = "Cancel_Button"
        '
        'txtPath
        '
        resources.ApplyResources(Me.txtPath, "txtPath")
        Me.txtPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem
        Me.txtPath.Name = "txtPath"
        '
        'btnBackupPath
        '
        resources.ApplyResources(Me.btnBackupPath, "btnBackupPath")
        Me.btnBackupPath.Name = "btnBackupPath"
        Me.btnBackupPath.UseVisualStyleBackColor = True
        '
        'lblBackupPath
        '
        resources.ApplyResources(Me.lblBackupPath, "lblBackupPath")
        Me.lblBackupPath.Name = "lblBackupPath"
        '
        'txtDbPath
        '
        resources.ApplyResources(Me.txtDbPath, "txtDbPath")
        Me.txtDbPath.Name = "txtDbPath"
        '
        'btnDbPath
        '
        resources.ApplyResources(Me.btnDbPath, "btnDbPath")
        Me.btnDbPath.Name = "btnDbPath"
        Me.btnDbPath.UseVisualStyleBackColor = True
        '
        'lblDbPath
        '
        resources.ApplyResources(Me.lblDbPath, "lblDbPath")
        Me.lblDbPath.Name = "lblDbPath"
        '
        'ckbBackupControl
        '
        resources.ApplyResources(Me.ckbBackupControl, "ckbBackupControl")
        Me.ckbBackupControl.Checked = True
        Me.ckbBackupControl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbBackupControl.Name = "ckbBackupControl"
        Me.ckbBackupControl.UseVisualStyleBackColor = True
        '
        'BackupDirDialog
        '
        Me.AcceptButton = Me.OK_Button
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.Controls.Add(Me.lblDbPath)
        Me.Controls.Add(Me.btnDbPath)
        Me.Controls.Add(Me.txtDbPath)
        Me.Controls.Add(Me.lblBackupPath)
        Me.Controls.Add(Me.btnBackupPath)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ckbBackupControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BackupDirDialog"
        Me.ShowInTaskbar = False
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnBackupPath As System.Windows.Forms.Button
    Friend WithEvents lblBackupPath As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents txtDbPath As System.Windows.Forms.TextBox
    Friend WithEvents btnDbPath As System.Windows.Forms.Button
    Friend WithEvents lblDbPath As System.Windows.Forms.Label
    Friend WithEvents ckbBackupControl As System.Windows.Forms.CheckBox

End Class
