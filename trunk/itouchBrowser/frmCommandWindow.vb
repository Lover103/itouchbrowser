Option Strict On
Option Explicit On
' =============================================================================
' *
' *  System      : itouchBrowser
' *  Module name : frmCommandWindow.vb
' *  Description : SSH command line dialog box
' *
' *    %Z% %I% %W% %G% %U% [ %H% %T% ]
' *    $Header:  $
' *
' *  (c) Copyright sugi. 2009. All rights reserved.
' *
' *  Modification history :
' *    Date        Level  Author        Description
' *    ----------  -----  ------------  -----------------------------------
' *    2009/04/24  1.00   Sugi          Initial release
' *
' =============================================================================
Imports itouchBrowser
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
'Imports Routrek.SSHCV2

Public Class frmCommandWindow

    Friend WithEvents mvarObjSSH As SSHManager = Nothing

    <DllImport("user32.dll")> _
    Private Shared Function SendMessage(ByVal hwnd As IntPtr, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32
    End Function

    ' for SendMessage API
    Private Const WM_VSCROLL As Int32 = &H115
    Private Const SB_BOTTOM As Int32 = 7

    Private mvarHist(20) As String
    Private mvarCurHistNum As Integer = 0
    Private mvarCurNum As Integer = 0

    Private Sub txtCommand_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtCommand.KeyDown

        Select Case e.KeyCode
            Case Keys.Down
                If mvarCurHistNum <> mvarCurNum Then
                    mvarCurHistNum += 1
                    If mvarCurHistNum >= mvarHist.Length Then
                        mvarCurHistNum = 0
                    End If
                End If

                If mvarCurHistNum = mvarCurNum Then
                    txtCommand.Text = ""
                Else
                    txtCommand.Text = mvarHist(mvarCurHistNum)
                End If
                txtCommand.SelectAll()

            Case Keys.Up
                Dim p As Integer = mvarCurHistNum

                mvarCurHistNum -= 1
                If mvarCurHistNum < 0 Then
                    mvarCurHistNum = mvarHist.Length - 1
                End If
                If mvarCurHistNum = mvarCurNum OrElse mvarHist(mvarCurHistNum) = "" Then
                    mvarCurHistNum = p
                End If

                If mvarCurHistNum = mvarCurNum Then
                    txtCommand.Text = ""
                Else
                    txtCommand.Text = mvarHist(mvarCurHistNum)
                End If
                txtCommand.SelectAll()

        End Select

    End Sub

    Private Sub txtCommand_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtCommand.KeyUp

        Try
            If e.KeyCode = Keys.Return AndAlso mvarObjSSH IsNot Nothing AndAlso mvarObjSSH.Connected Then
                If txtCommand.Text = "exit" Then
                    Me.Close()
                Else
                    ExecCmd(txtCommand.Text)
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Friend Function ExecCmd(ByVal cmd As String) As String

        Dim retTxt As String = mvarObjSSH.Transmit(cmd)
        'AddText(retTxt)
        mvarHist(mvarCurNum) = cmd
        mvarCurNum += 1
        If mvarCurNum >= mvarHist.Length Then
            mvarCurNum = 0
        End If
        mvarHist(mvarCurNum) = ""
        mvarCurHistNum = mvarCurNum

        txtCommand.Text = ""

        Return retTxt

    End Function

    Private Delegate Sub AddTextDelegate(ByVal txt As String)

    Private Sub mvarObjSSH_OnGetDataEvent(ByVal sender As Object, ByVal data As String) _
        Handles mvarObjSSH.OnGetDataEvent

        If Me.InvokeRequired Then
            Try
                Me.Invoke(New AddTextDelegate(AddressOf AddText), data)
            Catch ex As Exception
                ' NOP
            End Try
        Else
            AddText(data)
        End If

    End Sub

    Friend Sub AddText(ByVal txt As String)
        Const st As Char = Chr(&H1B)
        Const ed As Char = "m"c
        Dim pst As Integer = 0
        Dim ped As Integer = 0
        Dim stdin As New System.Text.StringBuilder

        Do
            pst = txt.IndexOf(st, ped)
            If pst < 0 Then
                Exit Do
            End If
            stdin.Append(txt.Substring(ped, pst - ped))
            ped = txt.IndexOf(ed, pst)
            If ped < 0 Then
                Exit Do
            End If
            ped += 1
        Loop
        stdin.Append(txt.Substring(ped))
        'Debug.Write(txt.Substring(ped))

        With rtbCommand
            .SuspendLayout()
            .AppendText(stdin.ToString())
            If .TextLength > 300000 Then
                '.Select(0, .TextLength - 30000)
                '.SelectedText = ""
                '.SelectionStart = .TextLength
                .Text = stdin.ToString()
            End If
            SendMessage(.Handle, WM_VSCROLL, SB_BOTTOM, 0)
            '.ScrollToCaret()
            .ResumeLayout()
            .Refresh()
        End With
        'Application.DoEvents()

    End Sub

    Friend Sub AddTextLine(ByVal str As String)
        Me.AddText(str & vbCrLf)
    End Sub

    Private Sub frmCommandWindow_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Disposed

        My.Settings.PosSSHCmd = Me.Left.ToString() & "," & Me.Top.ToString() & "," & Me.Width.ToString() & "," & Me.Height.ToString()
        My.Settings.Save()

        mvarObjSSH = Nothing

    End Sub

    Private Sub frmCommandWindow_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Load

        Dim pos As String = My.Settings.PosSSHCmd
        If pos.IndexOf(",") > 0 Then
            Dim position As String() = pos.Split(","c)
            Me.SetDesktopLocation(CInt(position(0)), CInt(position(1)))
            Me.Size = New Size(CInt(position(2)), CInt(position(3)))
        End If

        AddText(mvarObjSSH.Transmit(""))

    End Sub

    Private Sub dudCommand_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles dudCommand.MouseDown

        If e.Y > 6 Then
            Debug.WriteLine("Click Down")
            txtCommand_KeyDown(sender, New KeyEventArgs(Keys.Down))
        Else
            Debug.WriteLine("Click Up")
            txtCommand_KeyDown(sender, New KeyEventArgs(Keys.Up))
        End If
        txtCommand.Focus()

    End Sub

    Private Sub tsmClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmClear.Click

        rtbCommand.Text = ""

    End Sub

    Private Sub tsmClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmClose.Click

        Me.Close()

    End Sub

    Private Sub tsmBackupFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmBackupFolder.Click

        Dim res As DialogResult

        fbdDirectoryBrowser.SelectedPath = My.Settings.LastArchiveDir
        fbdDirectoryBrowser.Description = My.Resources.String60

        res = fbdDirectoryBrowser.ShowDialog(Me)

        If res = Windows.Forms.DialogResult.OK Then
            Dim path As String = fbdDirectoryBrowser.SelectedPath
            Dim pwd As String = ExecCmd("pwd")

            If pwd.StartsWith("pwd") Then
                Dim pwds As String() = pwd.Split(vbCrLf.ToCharArray())
                Dim fname As String = String.Format("/tmp/archive_{0,4}{1,2:00}{2,2:00}{3}.tar", _
                                                    Now.Year, Now.Month, Now.Day, _
                                                    pwds(2).Replace("/"c, "-"c))
                Dim CMD As String = String.Format("tar -zcvf {0} {1}", fname, pwds(2))

                ExecCmd(CMD)
                Me.AddTextLine("!Copy " & fname & " " & path & "\" & fname.Substring(5))
                ModuleMain.CopyFromPhone(fname, path & "\" & fname.Substring(5))
                Me.AddTextLine("!Delete " & fname)
                iPhoneInterface.DeleteFile(fname)

            End If

            My.Settings.LastArchiveDir = fbdDirectoryBrowser.SelectedPath
        End If

    End Sub

    Private Sub tsbCommand_AvailableChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbCommand.AvailableChanged
        Debug.WriteLine("available changed")
    End Sub

    Private Sub tsbCommand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCommand.Click

        Dim pwd As String = ExecCmd("pwd")
        If pwd.StartsWith("pwd") Then
            Dim pwds As String() = pwd.Split(vbCrLf.ToCharArray())
            Dim bkFolder As String = pwds(2)
            tsmBackupFolder.Text = String.Format(My.Resources.String62, bkFolder)   '"Backup " & bkFolder & " Folder..."
        End If

    End Sub

    Private Sub tsbCommand_DisplayStyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles tsbCommand.DisplayStyleChanged

        Debug.WriteLine("display style changed")
    End Sub

    Private Sub tsmCreateSSHKeyPair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmCreateSSHKeyPair.Click

        Dim dlg As New frmSSHInformation

        dlg.ParentForm = Me
        dlg.ShowDialog(Me)
        dlg.Dispose()

        ''"SSH key pairを作成するディレクトリを選択してください。"
        'fbdSSHKeyPairPath.Description = My.Resources.String61

        'If fbdSSHKeyPairPath.ShowDialog() = Windows.Forms.DialogResult.OK Then

        '    Dim filename As String = fbdSSHKeyPairPath.SelectedPath & "\id_rsa"     '"D:\DevWork\itouchBrowser\ssh\Routrek\id_rsa"

        '    Me.AddText("Creating new key pair. Please wait.....")
        '    mvarObjSSH.GenFile(filename)
        '    Me.AddText("The target key pair was generated.")
        '    Me.AddText("cp " & filename & ".pub /var/root/.ssh/authorized_keys via USB.")
        '    ModuleMain.CopyToPhone(filename & ".pub", "/var/root/.ssh/authorized_keys", Config.bConvertToiPhonePNG)
        '    Dim rc As String = execCmd("chmod 600 /var/root/.ssh/authorized_keys")
        'End If

    End Sub

End Class