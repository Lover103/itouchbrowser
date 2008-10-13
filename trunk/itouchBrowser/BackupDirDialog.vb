Option Explicit On
Option Strict On

Imports System.Windows.Forms

Public Class BackupDirDialog

    Private mvarBackupPath As String = ""
    Private mvarDbPath As String = ""

    Private Sub BackupDirDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mvarBackupPath = My.Settings.BackupPath
        mvarDbPath = My.Settings.DbPath

        If mvarDbPath = "" Then
            mvarDbPath = ModuleMain.GetBackupPath(True)
        End If

        txtPath.Text = mvarBackupPath
        txtDbPath.Text = mvarDbPath
        ckbBackupControl.Checked = Config.bBackupControled

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim path As String = txtPath.Text
        If path.EndsWith("\") Then
            path = path.Substring(0, path.Length - 1)
        End If
        My.Settings.BackupPath = path

        path = txtDbPath.Text
        If path <> mvarDbPath Then
            If path.EndsWith("\") Then
                path = path.Substring(0, path.Length - 1)
            End If
            My.Settings.DbPath = path
        End If

        Config.bBackupControled = ckbBackupControl.Checked

        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnBackupPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackupPath.Click

        Dim folderBr As New FolderBrowserDialog
        'folderBr.RootFolder = "C:\"
        folderBr.SelectedPath = txtPath.Text

        If folderBr.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPath.Text = folderBr.SelectedPath
        End If

    End Sub

    Private Sub btnDbPath_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDbPath.Click

        Dim folderBr As New FolderBrowserDialog

        folderBr.SelectedPath = txtDbPath.Text

        If folderBr.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtDbPath.Text = folderBr.SelectedPath
        End If

    End Sub

    Private Sub txtPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.TextChanged
        If txtPath.Text <> mvarBackupPath Then
            txtPath.BackColor = Color.LightPink
        Else
            txtPath.BackColor = Color.White
        End If
    End Sub

    Private Sub txtDbPath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDbPath.TextChanged
        If txtDbPath.Text <> mvarDbPath Then
            txtDbPath.BackColor = Color.LightPink
        Else
            txtDbPath.BackColor = Color.White
        End If
    End Sub

    Private Sub ckbBackupControl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbBackupControl.CheckedChanged
        txtDbPath.Enabled = ckbBackupControl.Checked
        btnDbPath.Enabled = ckbBackupControl.Checked
        If ckbBackupControl.Checked Then
            lblDbPath.ForeColor = Color.Black
        Else
            lblDbPath.ForeColor = Color.Gray
        End If
    End Sub

End Class
