Option Explicit On
Option Strict On

Imports System.Windows.Forms

Public Class BackupDirDialog

    Private Sub BackupDirDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtPath.Text = My.Settings.BackupPath
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim path As String = txtPath.Text
        If path.EndsWith("\") Then
            path = path.Substring(0, path.Length - 1)
        End If
        My.Settings.BackupPath = path
        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim folderBr As New FolderBrowserDialog
        'folderBr.RootFolder = "C:\"
        folderBr.SelectedPath = My.Settings.BackupPath

        If folderBr.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPath.Text = folderBr.SelectedPath
        End If

    End Sub

End Class
