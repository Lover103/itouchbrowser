Option Strict On
Option Explicit On
' =============================================================================
' *
' *  System      : itouchBrowser
' *  Module name : frmBackupFiles.vb
' *  Description : Backup files form
' *
' *    %Z% %I% %W% %G% %U% [ %H% %T% ]
' *    $Header:  $
' *
' *  (c) Copyright . 2008. All rights reserved.
' *
' *  Modification history :
' *    Date        Level  Author        Description
' *    ----------  -----  ------------  -----------------------------------
' *    2008/07/29  1.00   Sugi          Initial release
' *
' =============================================================================
Imports System.IO

Public Class frmBackupFiles

    Private mvarBindingSourceNewList As BindingSource = Nothing
    Private mvarBindingSourceSubList As BindingSource = Nothing
    Private mvarDb As DbManager
    Private mvarSubDB As DbManager
    Private mvarDb1 As DbManager = ObjDb
    Private mvarDb2 As DbManager

    Private Sub frmBackupFiles_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Disposed

        My.Settings.PosBackupFile = Me.Left.ToString() & "," & Me.Top.ToString() & "," & Me.Width.ToString() & "," & Me.Height.ToString()
        My.Settings.Save()
        ObjDb.ExportDB()
        mvarBindingSourceNewList.Dispose()
        If mvarBindingSourceSubList IsNot Nothing Then
            mvarBindingSourceSubList.Dispose()
        End If
        mvarDb.Dispose()
    End Sub

    Private Sub frmBackupFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        objMain.Cursor = Cursors.WaitCursor

        Dim pos As String = My.Settings.PosBackupFile
        If pos.IndexOf(",") > 0 Then
            Dim position As String() = pos.Split(","c)
            Me.SetDesktopLocation(CInt(position(0)), CInt(position(1)))
            Me.Size = New Size(CInt(position(2)), CInt(position(3)))
        End If

        tabChanged(0)
        objMain.Cursor = Cursors.Default

    End Sub

    Private Sub TabFileGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles TabFileGroup.Click

        Me.Cursor = Cursors.WaitCursor

        Try
            tabChanged(TabFileGroup.SelectedIndex)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tabChanged(ByVal selectedTabIndex As Integer)
        Dim sql As String = ""
        Dim filter As String = ""

        Select Case selectedTabIndex
            Case 0
                If mvarDb1 Is Nothing Then
                    sql = "SELECT FileName, FileSize, tstp, BackupFolder " _
                        & "FROM list.txt " _
                        & "ORDER BY FileName, tstp DESC"
                    mvarDb1 = ModuleMain.GetDbInstance(sql, "")
                End If
                filter = "BackupFolder <> 'Error'"
                mvarDb = mvarDb1
                ObjDb = mvarDb1
                dgvBackupView.ContextMenuStrip = menuRightClickAllView
            Case 1
                If mvarDb2 Is Nothing Then
                    sql = "SELECT FileName, Max(FileSize) as FileSize, Max(tstp) as tstp, Max(BackupFolder) as BackupFolder, Count(FileName) as cnt " _
                        & "FROM list.txt " _
                        & "GROUP BY FileName " '_
                    '& "ORDER BY FileName "
                    mvarDb2 = ModuleMain.GetDbInstance(sql, "FileName")
                End If
                filter = "cnt > 1"
                mvarDb = mvarDb2
                dgvBackupView.ContextMenuStrip = Nothing
        End Select

        mvarBindingSourceNewList = New BindingSource(mvarDb.DataSet, mvarDb.DataSet.Tables(0).TableName)
        mvarBindingSourceNewList.Filter = filter

        With Me.dgvBackupView
            .SuspendLayout()
            Select Case selectedTabIndex
                Case 1
                    If .Columns.Count = 4 Then
                        .Columns.Add(colCnt)
                    End If
                    .Columns(0).DisplayIndex = 1
                    .Columns(1).DisplayIndex = 2
                    .Columns(2).DisplayIndex = 3
                    .Columns(3).DisplayIndex = 4
                    .Columns(4).DisplayIndex = 0
                    SplitContainer1.Panel2Collapsed = False

                Case Else
                    If .Columns.Count = 5 Then
                        .Columns.RemoveAt(4)
                    End If
                    .Columns(0).DisplayIndex = 0
                    .Columns(1).DisplayIndex = 1
                    .Columns(2).DisplayIndex = 2
                    .Columns(3).DisplayIndex = 3
                    SplitContainer1.Panel2Collapsed = True

            End Select
            .DataSource = mvarBindingSourceNewList
            .ResumeLayout()
        End With

        statFileCount.Text = mvarBindingSourceNewList.Count.ToString()
        statFileName.Text = ""

    End Sub

    Private Function setDetailData(ByVal fileName As String) As Integer
        Dim sql As String = ""
        Dim count As Integer = 0
        Dim filter As String = "FileName = '" & fileName.Replace("'", "''") & "'"

        Me.Cursor = Cursors.WaitCursor

        Try
            If mvarSubDB Is Nothing Then
                mvarSubDB = mvarDb1
                mvarBindingSourceSubList = New BindingSource(mvarSubDB.DataSet, mvarSubDB.DataSet.Tables(0).TableName)
            End If
            mvarBindingSourceSubList.Filter = filter

            With Me.dgvDetailView
                .SuspendLayout()
                .DataSource = mvarBindingSourceSubList
                For row As Integer = 0 To mvarBindingSourceSubList.Count - 1
                    Me.setStatus(row)
                Next
                .ResumeLayout()
            End With
            count = mvarBindingSourceSubList.Count

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try

        Return count

    End Function

    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) _
        Handles dgvBackupView.CellFormatting

        Dim dgv As DataGridViewRow

        Try
            Select Case e.ColumnIndex
                Case 1
                    If dgvBackupView.ColumnCount > 4 Then
                        dgv = dgvBackupView.Rows(e.RowIndex)
                        If IsDBNull(dgv.Cells(4).Value) = False AndAlso CInt(dgv.Cells(4).Value) <= 3 Then
                            'dgv.Visible = False
                        Else
                            dgv.Cells(0).Style.BackColor = Color.LightPink
                        End If
                    End If
                Case 2

            End Select

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Private Sub dgvBackupView_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvBackupView.RowEnter

        Dim col As Integer = 0

        If TabFileGroup.SelectedIndex = 1 AndAlso dgvBackupView.CurrentRow IsNot Nothing Then
            statFileName.Text = dgvBackupView.Rows(e.RowIndex).Cells(col).Value.ToString()
            Dim cnt As Integer = Me.setDetailData(statFileName.Text)
            dgvBackupView.Rows(e.RowIndex).Cells(4).Value = cnt
        End If
    End Sub

    Private Sub frmBackupFiles_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.SizeChanged

        If Me.WindowState = FormWindowState.Minimized Then
            objMain.Visible = False
        Else
            objMain.Visible = True
        End If
    End Sub

    Private Sub setStatus(ByVal rowIndex As Integer)
        With dgvDetailView.Rows(rowIndex)
            If rowIndex = 0 Then
                .Cells(0).Value = My.Resources.String36
            Else
                Dim bakPath As String = GetBackupPath(True) & "\"
                Dim file1 As String = bakPath & .Cells(2).FormattedValue.ToString & .Cells(3).FormattedValue.ToString
                Dim file2 As String = bakPath & dgvDetailView.Rows(rowIndex - 1).Cells(2).FormattedValue.ToString & dgvDetailView.Rows(rowIndex - 1).Cells(3).FormattedValue.ToString
                If DbManager.Compare(file1, file2) Then
                    .Cells(0).Value = My.Resources.String37
                Else
                    .Cells(0).Value = My.Resources.String38
                End If
            End If
        End With
    End Sub

    Private Sub dgvDetailView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) _
        Handles dgvDetailView.CellFormatting

        Select Case e.ColumnIndex
            Case 0
                If e.Value IsNot Nothing AndAlso e.Value.ToString = My.Resources.String37 Then
                    e.CellStyle.ForeColor = Color.Red
                Else
                    e.CellStyle.ForeColor = Color.Black
                End If
        End Select
    End Sub

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles btnClose.Click

        Me.Close()
    End Sub

    ' Delete file
    Private Sub tsmDeleteFile1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmDeleteFile1.Click

        Try
            If TabFileGroup.TabIndex = 0 AndAlso dgvBackupView.SelectedRows.Count > 0 Then

                For Each sItem As DataGridViewRow In dgvBackupView.SelectedRows
                    Dim path As String = sItem.Cells(2).Value.ToString

                    Try ' delete backuped file.
                        Dim subDir As String = "\" & sItem.Cells(1).Value.ToString
                        Dim fullPath As String = GetBackupPath(True) & subDir & path.Replace("/", "\")
                        If File.Exists(fullPath) Then
                            File.Delete(fullPath)
                        End If
                        ' delete from database
                        ObjDb.RemoveRow(subDir.Substring(1), path)

                    Catch ex As IOException
                        StatusWarning(ex.Message)
                    End Try
                Next

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub tsmDeleteFile2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmDeleteFile2.Click

        Try
            If dgvDetailView.SelectedRows.Count > 0 Then
                'sSourcePath = getSelectedPath()

                For Each sItem As DataGridViewRow In dgvDetailView.SelectedRows
                    Dim path As String = sItem.Cells(3).Value.ToString

                    Try ' delete backuped file.
                        Dim subDir As String = "\" & sItem.Cells(2).Value.ToString
                        Dim fullPath As String = GetBackupPath(True) & subDir & path.Replace("/", "\")
                        If File.Exists(fullPath) Then
                            File.Delete(fullPath)
                        End If
                        ' delete from database
                        ObjDb.RemoveRow(subDir.Substring(1), path)

                    Catch ex As IOException
                        StatusWarning(ex.Message)
                    End Try
                Next
                ' refresh view
                statFileName.Text = dgvBackupView.SelectedRows(0).Cells(0).Value.ToString()
                Me.setDetailData(statFileName.Text)

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    ' 右クリックで、行を移動する
    Private Sub dgvDetailView_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
        Handles dgvDetailView.CellMouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            dgvDetailView.CurrentCell = dgvDetailView.Rows(e.RowIndex).Cells(0)
        End If
    End Sub

    Private Sub dgvBackupView_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
        Handles dgvBackupView.CellMouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then
            dgvBackupView.CurrentCell = dgvBackupView.Rows(e.RowIndex).Cells(0)
        End If
    End Sub

End Class