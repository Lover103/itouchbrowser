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

Public Class frmBackupFiles

    Private mvarBindingSourceNewList As BindingSource
    Private mvarBindingSourceSubList As BindingSource
    Private mvarDb As DbManager
    Private mvarSubDB As DbManager

    Private Sub frmBackupFiles_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Disposed

        My.Settings.PosBackupFile = Me.Left.ToString() & "," & Me.Top.ToString() & "," & Me.Width.ToString() & "," & Me.Height.ToString()
        My.Settings.Save()
        mvarBindingSourceNewList.Dispose()
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
                sql = "SELECT FileName, FileSize, tstp, BackupFolder " _
                    & "FROM list.txt " _
                    & "WHERE BackupFolder<>'Error' " _
                    & "ORDER BY FileName, tstp DESC"
            Case 1
                sql = "SELECT FileName, Max(FileSize) as FileSize, Max(tstp) as tstp, Max(BackupFolder) as BackupFolder, Count(FileName) as cnt " _
                    & "FROM list.txt " _
                    & "GROUP BY FileName " _
                    & "ORDER BY FileName "
                filter = "cnt > 1"
        End Select

        mvarDb = GetBackupList(sql, "")
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

    Private Sub SetDetailData(ByVal fileName As String)
        Dim sql As String = ""
        Dim filter As String = "FileName = '" & fileName.Replace("'", "''") & "'"

        Me.Cursor = Cursors.WaitCursor

        Try
            If mvarSubDB Is Nothing Then
                sql = "SELECT FileName, FileSize, tstp, BackupFolder " _
                            & "FROM list.txt " _
                            & "ORDER BY FileName, tstp DESC"

                mvarSubDB = GetBackupList(sql, "")
                mvarBindingSourceSubList = New BindingSource(mvarSubDB.DataSet, mvarSubDB.DataSet.Tables(0).TableName)
            End If
            mvarBindingSourceSubList.Filter = filter

            With Me.dgvDetailView
                .SuspendLayout()
                .DataSource = mvarBindingSourceSubList
                For row As Integer = 0 To mvarBindingSourceSubList.Count - 1
                    setStatus(row)
                Next
                .ResumeLayout()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

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
            SetDetailData(statFileName.Text)
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
                Dim file1 As String = GetBackupPath(True) & .Cells(4).FormattedValue.ToString & .Cells(1).FormattedValue.ToString
                Dim file2 As String = GetBackupPath(True) & dgvDetailView.Rows(rowIndex - 1).Cells(4).FormattedValue.ToString & dgvDetailView.Rows(rowIndex - 1).Cells(1).FormattedValue.ToString
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
End Class