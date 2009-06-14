Option Explicit On
Option Strict On
' =============================================================================
' *
' *  System      : itouchBrowser
' *  Module name : frmSSHConfig.vb
' *  Description : SSH connection configuration dialog box
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
Imports itouchBrowser

Public Class frmSSHConfig

    Private Sub frmSSHConfig_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Load

        chkAutoSet.Checked = My.Settings.SSHAddrAutoset
        txtUserID.Text = My.Settings.SSHUser
        txtPasswd.Text = My.Settings.SSHPasswd
        txtPassphrase.Text = My.Settings.SSHPasswd
        txtKeyFileDir.Text = My.Settings.SSHKeyPath
        cmbAuthType.SelectedIndex = My.Settings.SSHAuthType

    End Sub

    Private Sub chkAutoSet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles chkAutoSet.CheckedChanged

        If chkAutoSet.Checked Then
            txtIPAddress.Text = GetSSHAddress()
        Else
            txtIPAddress.Text = ""
        End If

        txtIPAddress.Enabled = Not chkAutoSet.Checked

    End Sub

    Private Sub cmbAuthType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAuthType.SelectedIndexChanged
        Dim isKeyAuth As Boolean = False

        Select Case cmbAuthType.SelectedIndex
            Case 0
                isKeyAuth = False
            Case 1
                isKeyAuth = True
        End Select

        brpPasswdConnect.Enabled = Not isKeyAuth
        brpKeyConnect.Enabled = isKeyAuth

    End Sub

    Private Sub btnLocalKeyDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalKeyDir.Click

        '"SSH key pairを作成するディレクトリを選択してください。"
        fbdSSHKeyPairPath.Description = My.Resources.String61
        fbdSSHKeyPairPath.SelectedPath = txtKeyFileDir.Text

        If fbdSSHKeyPairPath.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtKeyFileDir.Text = fbdSSHKeyPairPath.SelectedPath
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnOK.Click

        My.Settings.SSHAuthType = cmbAuthType.SelectedIndex
        My.Settings.SSHAddrAutoset = chkAutoSet.Checked
        My.Settings.SSHUser = txtUserID.Text
        My.Settings.SSHKeyPath = txtKeyFileDir.Text

        If cmbAuthType.SelectedIndex = 0 Then
            My.Settings.SSHPasswd = txtPasswd.Text
        Else
            My.Settings.SSHPasswd = txtPassphrase.Text
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnTestConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnTestConnect.Click

        Const DLG_TITLE As String = "Connection test result"

        Dim sshman As New SSHManager
        Dim authtype As SSHManager.AuthType
        Dim passwd As String = ""

        If cmbAuthType.SelectedIndex = 0 Then
            authtype = SSHManager.AuthType.Password
            passwd = Me.txtPasswd.Text
        Else
            authtype = SSHManager.AuthType.PublicKey
            passwd = Me.txtPassphrase.Text
        End If

        Try
            If sshman.Open(Me.txtIPAddress.Text, _
                        Me.txtUserID.Text, _
                        passwd, _
                        authtype, _
                        Me.txtKeyFileDir.Text & "\id_rsa") Then

                MsgBox("Connection OK", MsgBoxStyle.Information, DLG_TITLE)
            Else
                MsgBox("Connection failed", MsgBoxStyle.Exclamation, DLG_TITLE)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, DLG_TITLE)
        End Try

        sshman.Close()

    End Sub

End Class