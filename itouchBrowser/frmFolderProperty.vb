Option Strict On
Option Explicit On
' =============================================================================
' *
' *  System      : itouchBrowser
' *  Module name : BackupDirDialog.vb
' *  Description : Backup directory dialog box
' *
' *    %Z% %I% %W% %G% %U% [ %H% %T% ]
' *    $Header:  $
' *
' *  (c) Copyright sugi. 2008. All rights reserved.
' *
' *  Modification history :
' *    Date        Level  Author        Description
' *    ----------  -----  ------------  -----------------------------------
' *    2009/01/31  1.00   Sugi          Initial release
' *
' =============================================================================

Imports System.Threading
Imports itouchBrowser.Manzana

Public Class frmFolderProperty

    Private allSize As ULong = 0
    Private fileCount As Long = 0
    Private folderCount As Integer = 0
    Private pathThread As Thread = Nothing
    Private suspend As Boolean = False
    Friend CurrentPath As String

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub frmFolderProperty_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If suspend = False Then
            suspend = True
            If pathThread IsNot Nothing Then
                pathThread.Join(4000)
            End If
        End If
    End Sub

    Private Sub txtFolderName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtFolderName.TextChanged

        pathThread = New Thread(New ThreadStart(AddressOf Me.findFiles))
        pathThread.Start()

    End Sub

    Private Sub findFiles()
        Dim sPath As String = Me.CurrentPath

        If sPath = "/" Then ' handle root special case
            sPath = ""
        End If

        Try
            Me.progress(True)

            findFiles(sPath)
            folderCount -= 1

        Catch ex As Exception
            StatusWarning(My.Resources.String35)

        Finally
            suspend = True
            Me.progress(False)
        End Try

    End Sub

    Private Sub progress(ByVal visible As Boolean)
        If Me.InvokeRequired Then
            Me.pgbProgress.Invoke(chgProgress, visible)
        Else
            changeProgress(visible)
        End If
    End Sub

    Private Delegate Sub delChgProgress(ByVal visible As Boolean)
    Private chgProgress As delChgProgress = New delChgProgress(AddressOf changeProgress)

    Private Sub changeProgress(ByVal visible As Boolean)
        Me.pgbProgress.Visible = visible
        If Not visible Then
            btnCancel.Enabled = False
        End If
    End Sub

    Private Sub findFiles(ByVal sPath As String)
        'Dim sbpath As String
        'Dim sFolders As iPhone.strDir()

        Try
            'get the data from the phone
            'sFolders = iPhoneInterface.GetDirectories(sPath)

            'For Each strFolder As iPhone.strDir In sFolders
            '    sbpath = sPath & "/" & strFolder.Dir

            '    If Not strFolder.IsSLink Then
            '        findFiles(sbpath)
            '    End If
            '    If suspend Then
            '        Exit Try
            '    End If
            'Next
            For Each strFiles As iPhone.strFileInfo In iPhoneInterface.GetFolderInfo(sPath)
                If strFiles.isDir Then
                    If Not strFiles.isSLink Then
                        Dim fileName As String = convertcd(strFiles.name)
                        findFiles(sPath & "/" & fileName)
                    End If
                    If suspend Then
                        Exit Try
                    End If
                Else
                    If Not strFiles.isSLink Then
                        allSize += strFiles.size
                        fileCount += 1
                    End If
                End If
            Next
            folderCount += 1
            Thread.Sleep(1)

        Catch ex As Exception
            StatusWarning(My.Resources.String35)

        End Try

    End Sub

    Private Sub frmFolderProperty_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Load

        'lblName.Text = "Total size:" & vbCrLf & "File count:" & vbCrLf & "Folder count:"
        lblValue.Text = ""
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles Timer1.Tick

        lblValue.Text = (allSize / 1024).ToString("#,##0.00 kb") & vbCrLf _
                & fileCount.ToString & vbCrLf _
                & folderCount.ToString

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        suspend = True
        lblValue.ForeColor = Color.Gray
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

End Class