Option Explicit On
Option Strict On
' =============================================================================
' *
' *  System      : itouchBrowser
' *  Module name : frmSSHInformation.vb
' *  Description : SSH connection information dialog box
' *
' *    %Z% %I% %W% %G% %U% [ %H% %T% ]
' *    $Header:  $
' *
' *  (c) Copyright sugi. 2009. All rights reserved.
' *
' *  Modification history :
' *    Date        Level  Author        Description
' *    ----------  -----  ------------  -----------------------------------
' *    2009/05/17  1.00   Sugi          Initial release
' *
' =============================================================================
'Imports Routrek.SSHCV2

Public Class frmSSHInformation

    Private oParent As frmCommandWindow
    Private mvarFilePath As String = ""

    Friend Shadows Property ParentForm() As frmCommandWindow
        Get
            Return oParent
        End Get
        Set(ByVal value As frmCommandWindow)
            oParent = value
        End Set
    End Property

    Private Sub frmSSHInformation_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Load

        txtLocalKeyDir.Text = My.Settings.SSHKeyPath

    End Sub

    Private Sub btnLocalKeyDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnLocalKeyDir.Click

        '"SSH key pairを作成するディレクトリを選択してください。"
        fbdSSHKeyPairPath.Description = My.Resources.String61
        fbdSSHKeyPairPath.SelectedPath = txtLocalKeyDir.Text

        If fbdSSHKeyPairPath.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtLocalKeyDir.Text = fbdSSHKeyPairPath.SelectedPath
        End If

    End Sub

    Private Sub txtLocalKeyDir_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtLocalKeyDir.TextChanged

        Dim actv As Boolean = False

        If txtLocalKeyDir.Text.Length > 0 Then
            mvarFilePath = txtLocalKeyDir.Text      '"D:\DevWork\itouchBrowser\ssh\Routrek\id_rsa"
            actv = True
        Else
            mvarFilePath = ""
        End If

        Me.btnGenKey.Enabled = actv

    End Sub

    Private Sub btnGenKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnGenKey.Click

        If oParent IsNot Nothing Then
            Me.Cursor = Cursors.WaitCursor

            Try
                If Me.txtPassphrase1.Text <> Me.txtPassphrase2.Text Then
                    MsgBox("Mismatch the passphrases.", MsgBoxStyle.Exclamation, "itouchBrowser")
                    Exit Sub
                End If

                oParent.AddTextLine("!Creating new key pair. Please wait.....")
                oParent.mvarObjSSH.GenFile(mvarFilePath & "\id_rsa", Me.txtPassphrase1.Text)
                oParent.AddTextLine("!The target key pair was generated.")

                My.Settings.SSHKeyPath = mvarFilePath
                Me.btnCopyKey.Enabled = True

            Catch ex As Exception

            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If

    End Sub

    Private Sub btnCopyKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnCopyKey.Click

        Const rootPath As String = "/var/root/.ssh"
        Dim rc As String

        Try
            If iPhoneInterface.Exists(rootPath) = False Then
                oParent.AddTextLine("!mkdir " & rootPath & " via USB.")
                iPhoneInterface.CreateDirectory(rootPath)
                oParent.ExecCmd("chmod 700 " & rootPath)
            End If

            oParent.AddTextLine("!cp " & mvarFilePath & "\id_rsa.pub " & rootPath & "/id_rsa.pub via USB.")
            ModuleMain.CopyToPhone(mvarFilePath & "\id_rsa.pub", rootPath & "/id_rsa.pub", Config.bConvertToiPhonePNG)
            rc = oParent.ExecCmd("cd /var/root")
            rc = oParent.ExecCmd("chmod 600 .ssh/id_rsa.pub")

            My.Settings.SSHKeyPath = mvarFilePath
            Me.btnInstallKey.Enabled = True

        Catch ex As Exception
            Me.btnInstallKey.Enabled = False
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)

        End Try

    End Sub

    Private Sub btnInstallKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInstallKey.Click

        Dim rc As String
        rc = oParent.ExecCmd("cd /var/root")
        rc = oParent.ExecCmd("cat .ssh/id_rsa.pub >> .ssh/authorized_keys")
        rc = oParent.ExecCmd("chmod 600 .ssh/authorized_keys")

    End Sub

End Class