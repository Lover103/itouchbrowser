Option Explicit On
Option Strict On
' =============================================================================
' *
' *  System      : CommonClass
' *  Module name : DbManager.vb
' *  Description : Database Manager Class
' *
' *    %Z% %I% %W% %G% %U% [ %H% %T% ]
' *    $Header:  $
' *
' *  (c) Copyright . 2007, 2008. All rights reserved.
' *
' *  Modification history :
' *    Date        Level  Author        Description
' *    ----------  -----  ------------  -----------------------------------
' *    2008/07/29  1.00   Sugi          Initial release
' *
' =============================================================================

Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SQLite

<System.Runtime.InteropServices.ComVisible(False)> Public Class DbManager
    Implements IDisposable

    Private Const MODULE_NAME As String = "DbManager"

    ' Track whether Dispose has been called.
    Private disposed As Boolean = False

    Private mvarDataSet As DataSet
    Private mvarSource As String = ""
    Private mvarDbProvider As String = ""
    Private mvarDbFileName As String = ""
    Private oConn As OleDbConnection
    Private oCommand As OleDbCommand
    Private oDataAdapter As OleDbDataAdapter = Nothing
    Private mvarView As DataView = Nothing
    Private mvarSort As String = ""
    Private mvarLastKeyName As String = ""
    Private mvarFileCount As Long = 0
    Private mvarViewUpdated As Boolean = False

    Public Sub New(ByVal dbProvider As String)
        Util.TraceS(MODULE_NAME, "New")

        mvarDbProvider = dbProvider
        mvarDataSet = New DataSet
        oConn = New OleDbConnection
        oDataAdapter = New OleDbDataAdapter
        'mvarSource = source     'Config.DbDir

        Util.TraceE(MODULE_NAME, "New")
    End Sub

    Public Overloads Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        ' This object will be cleaned up by the Dispose method.
        ' Therefore, you should call GC.SupressFinalize to
        ' take this object off the finalization queue 
        ' and prevent finalization code for this object
        ' from executing a second time.
        GC.SuppressFinalize(Me)
    End Sub

    Private Overloads Sub Dispose(ByVal disposing As Boolean)
        ' Check to see if Dispose has already been called.
        If Not Me.disposed Then
            ' If disposing equals true, dispose all managed 
            ' and unmanaged resources.
            If disposing Then
                ' Dispose managed resources.
                'component.Dispose()
                If mvarView IsNot Nothing Then
                    mvarView.Dispose()
                End If
                oDataAdapter.Dispose()
                mvarDataSet.Dispose()
            End If

            ' Call the appropriate methods to clean up 
            ' unmanaged resources here.
            ' If disposing is false, 
            ' only the following code is executed.
            'CloseHandle(handle)
            'handle = IntPtr.Zero
        End If
        disposed = True
    End Sub

    ' This finalizer will run only if the Dispose method 
    ' does not get called.
    ' It gives your base class the opportunity to finalize.
    ' Do not provide finalize methods in types derived from this class.
    Protected Overrides Sub Finalize()
        Util.TraceS(MODULE_NAME, "Finalize")
        ' Do not re-create Dispose clean-up code here.
        ' Calling Dispose(false) is optimal in terms of
        ' readability and maintainability.
        Dispose(False)
        MyBase.Finalize()

        Util.TraceE(MODULE_NAME, "Finalize")
    End Sub

    Public Property Source() As String
        <DebuggerStepThrough()> Get
            Return mvarSource
        End Get
        <DebuggerStepThrough()> Set(ByVal value As String)
            mvarSource = value
        End Set
    End Property

    Public Property DataSet() As DataSet
        <DebuggerStepThrough()> Get
            Return mvarDataSet
        End Get
        <DebuggerStepThrough()> Set(ByVal value As DataSet)
            mvarDataSet = value
        End Set
    End Property

    Public ReadOnly Property Parameters() As OleDbParameterCollection
        <DebuggerStepThrough()> Get
            Return oDataAdapter.SelectCommand.Parameters
        End Get
    End Property

    Public Property Sort() As String
        Get
            Return mvarSort
        End Get
        Set(ByVal value As String)
            mvarSort = value
        End Set
    End Property

    Public ReadOnly Property FileCount() As Long
        Get
            Return mvarFileCount
        End Get
    End Property

    Public Property DbFileName() As String
        Get
            Return mvarDbFileName
        End Get
        Set(ByVal value As String)
            mvarDbFileName = value
        End Set
    End Property

    Public Sub ReSelect()

        If oDataAdapter Is Nothing Then
            Throw New Exception("ReSelect error.")
        End If

        Dim sql As String = oDataAdapter.SelectCommand.CommandText
        If sql = "" Then
            Throw New Exception("ReSelect error.")
        End If
        oDataAdapter.Dispose()
        mvarDataSet.Dispose()

        SelectOLEDB(sql, mvarLastKeyName)
        If mvarView IsNot Nothing Then
            mvarView.Dispose()
            mvarView = Nothing
        End If
        mvarViewUpdated = False

    End Sub

    Public Function SelectOLEDB(ByVal sql As String, Optional ByVal keyName As String = "") As DataSet
        Util.TraceS(MODULE_NAME, "SelectOLEDB: SQL = " & sql)
        Dim rc As Integer

        Try
            If Not File.Exists(mvarSource & "\schema.ini") Then
                Dim val As String
                val = "[list.txt]" & vbCrLf _
                    & "ColNameHeader=False" & vbCrLf _
                    & "Format=CSVDelimited" & vbCrLf _
                    & "Col1=tstp Text" & vbCrLf _
                    & "Col2=BackupFolder Text" & vbCrLf _
                    & "Col3=FileName Text" & vbCrLf _
                    & "Col4=FileSize Long" & vbCrLf

                rc = Me.CreateSchema(mvarSource, val)
                If rc < 0 Then
                    Return Nothing
                End If

                If Not File.Exists(mvarSource & "\list.txt") Then
                    File.AppendAllText(mvarSource & "\list.txt", "")
                End If
            End If

            'DB接続文字列の設定
            Dim builder As New System.Data.OleDb.OleDbConnectionStringBuilder

            builder.Add("Provider", mvarDbProvider)
            builder.Add("Data Source", mvarSource)
            builder.Add("Extended Properties", "Text")

            Using oConn As OleDbConnection = New OleDbConnection(builder.ConnectionString)

                oCommand = New OleDbCommand

                'Set connection value
                oCommand.Connection = oConn

                'Set SQL statement
                oCommand.CommandText = sql

                'Get data
                oDataAdapter.SelectCommand = oCommand
                mvarDataSet = New DataSet()
                oDataAdapter.Fill(mvarDataSet)
                mvarFileCount = mvarDataSet.Tables(0).Rows.Count

                If keyName <> "" Then
                    If keyName.IndexOf(","c) > -1 Then
                        Dim keys() As String = keyName.Split(","c)
                        mvarDataSet.Tables(0).PrimaryKey = New DataColumn() _
                            {mvarDataSet.Tables(0).Columns(keys(0)), _
                            mvarDataSet.Tables(0).Columns(keys(1))}
                    Else
                        mvarDataSet.Tables(0).PrimaryKey = New DataColumn() {mvarDataSet.Tables(0).Columns(keyName)}
                    End If
                End If

            End Using

            mvarLastKeyName = keyName
            If mvarFileCount = 0 Then
                '本当に０かチェックする
                Dim ds() As DirectoryInfo = (New DirectoryInfo(mvarSource)).GetDirectories()
                If ds.Length = 0 Then
                    'not backuped
                    mvarFileCount = -1
                End If
            End If

        Catch e As System.Data.OleDb.OleDbException
            Util.Log(Util.MsgLevel.AA_ERROR, e.ToString)
            mvarDataSet.Tables.Add("NO_DATA")
            MsgBox(e.Message, MsgBoxStyle.Critical)

        Catch ex As Exception
            Util.Log(Util.MsgLevel.AA_ERROR, ex.ToString)
            MsgBox(ex.Message)

        Finally
            Util.TraceE(MODULE_NAME, "SelectOLEDB")
        End Try

        Return mvarDataSet

    End Function

    Friend Function RemoveRow(ByVal subDir As String, ByVal key As String) As Integer

        Dim row As Integer = Me.Find(subDir, key)
        If row > -1 Then
            mvarView.Delete(row)
            mvarViewUpdated = True
        End If

    End Function

    Friend Function prepareOLEDB(ByVal sql As String) As OleDbDataAdapter
        Util.TraceS(MODULE_NAME, "prepareOLEDB")

        Try
            'DB接続文字列の設定
            Dim builder As New System.Data.OleDb.OleDbConnectionStringBuilder

            builder.Add("Provider", mvarDbProvider)
            builder.Add("Data Source", mvarSource)
            builder.Add("Extended Properties", "Text")

            oConn = New OleDbConnection(builder.ConnectionString)

            'Set connection value
            oCommand.Connection = oConn

            'Set SQL statement
            oCommand.CommandText = sql

            'Get data
            oDataAdapter.SelectCommand = oCommand

        Catch ex As Exception
            Util.Log(Util.MsgLevel.AA_ERROR, ex.ToString)
            MsgBox(ex.Message)

        Finally
            Util.TraceE(MODULE_NAME, "prepareOLEDB")
        End Try

        Return oDataAdapter

    End Function

    Private Function setDataView(ByVal update As Boolean) As Integer

        If mvarView IsNot Nothing Then
            mvarView.Dispose()
        End If

        mvarView = New DataView()
        With mvarView
            .Table = mvarDataSet.Tables(0)
            .AllowDelete = update
            .AllowEdit = update
            .AllowNew = update
            .RowStateFilter = DataViewRowState.CurrentRows
            .Sort = mvarSort    '.Table.PrimaryKey(0).Caption
        End With

    End Function

    Public Function Find(ByVal subDir As String, ByVal key As String) As Integer
        Dim rc As Integer = 0

        If mvarView Is Nothing Then
            setDataView(True)
        End If

        If subDir = "" Then
            mvarView.Sort = "FileName"
            rc = mvarView.Find(key)
        Else
            mvarView.Sort = "BackupFolder, FileName"
            Dim k(1) As Object
            k(0) = subDir
            k(1) = key
            rc = mvarView.Find(k)
        End If

        Return rc

    End Function

    Public Function GetValue(ByVal row As Integer, ByVal col As Integer) As String
        Dim retValue As String = ""

        Try
            retValue = mvarView.Item(row).Item(col).ToString
        Catch ex As Exception
            Throw ex
        End Try

        Return retValue
    End Function

    Public Sub Fill()
        Util.TraceS(MODULE_NAME, "Fill")

        'mvarDataSet.Tables(0).Clear()
        oDataAdapter.Fill(mvarDataSet)

        Util.TraceE(MODULE_NAME, "Fill")
    End Sub

    '引数のSQLに対するDataViewオブジェクトを新規作成する。
    Public Function CreateDataView(ByVal sql As String, ByVal sortkey As String, ByVal updateFlg as Boolean) As DataView
        Util.TraceS(MODULE_NAME, "CreateDataView")

        Dim view As DataView = Nothing

        Try
            Using ds As DataSet = Me.SelectOLEDB(sql)
                view = New DataView()
                With view
                    .Table = ds.Tables(0)
                    .AllowDelete = updateFlg
                    .AllowEdit = updateFlg
                    .AllowNew = updateFlg
                    .RowStateFilter = DataViewRowState.Unchanged    ' DataViewRowState.ModifiedCurrent
                    .Sort = sortkey
                End With
            End Using

        Catch ex As Exception
            Util.Log(Util.MsgLevel.AA_ERROR, ex.ToString())
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)

        Finally
            Util.TraceE(MODULE_NAME, "CreateDataView")
        End Try

        Return view

    End Function

    'Public Function CommitView() As Integer
    '    Dim ds2 As DataSet = mvarDataSet.GetChanges()
    '    Dim builder As New System.Data.OleDb.OleDbConnectionStringBuilder

    '    builder.Add("Provider", mvarDbProvider)
    '    builder.Add("Data Source", mvarSource)
    '    builder.Add("Extended Properties", "Text")

    '    Using oConn As OleDbConnection = New OleDbConnection(builder.ConnectionString)
    '        oCommand = New OleDbCommand( _
    '            "DELETE FROM list.txt WHERE tstp='?' AND BackupFolder='?' AND FileName='?' AND FileSize=?", oConn)
    '        oDataAdapter.DeleteCommand = oCommand
    '        Dim para As OleDbParameter
    '        para = oDataAdapter.DeleteCommand.Parameters.Add( _
    '            "@tstp", OleDbType.Filetime, 0, "tstp")
    '        para.SourceVersion = DataRowVersion.Original
    '        para.IsNullable = True

    '        para = oDataAdapter.DeleteCommand.Parameters.Add( _
    '            "@BackupFolder", OleDbType.Variant, 0, "BackupFolder")
    '        para.SourceVersion = DataRowVersion.Original
    '        para.IsNullable = True

    '        para = oDataAdapter.DeleteCommand.Parameters.Add( _
    '            "@FileName", OleDbType.Variant, 0, "FileName")
    '        para.SourceVersion = DataRowVersion.Original
    '        para.IsNullable = True
    '        oDataAdapter.DeleteCommand.Parameters.Add( _
    '            "@FileSize", OleDbType.Integer, 0, "FileSize").SourceVersion = DataRowVersion.Original

    '        oDataAdapter.Update(ds2)
    '        mvarDataSet.Merge(ds2)
    '        mvarDataSet.AcceptChanges()
    '    End Using

    'End Function

    Friend Sub AddFilenameToDB(ByVal time As Date, ByVal bkupSubPath As String, ByVal name As String, ByVal size As Long)

        mvarView.AllowEdit = True

        Dim drv As DataRowView = mvarView.AddNew()
        With drv.Row
            'With mvarView(mvarView.Count - 1)
            .BeginEdit()
            .Item(0) = time
            .Item(1) = bkupSubPath
            .Item(2) = name
            .Item(3) = size
            .EndEdit()
        End With
        
    End Sub

    Friend Sub ExportDB()

        If mvarViewUpdated = False Then
            Exit Sub
        End If

        Dim time As Date
        Dim bkupSubPath As String
        Dim name As String
        Dim size As String
        Dim dat As String
        Dim dbName As String = mvarSource & "\" & mvarDbFileName
        Dim tmpName As String = mvarSource & "\" & "tmp.txt"    'mvarDbFileName
        Dim i As Integer

        If mvarView Is Nothing Then
            setDataView(False)
        End If
        If File.Exists(tmpName) Then
            File.Delete(tmpName)
        End If

        Using wfs As StreamWriter = File.AppendText(tmpName)

            For i = 0 To mvarView.Count - 1
                With mvarView.Item(i)
                    time = CType(.Item(0), System.DateTime)
                    bkupSubPath = .Item(1).ToString()
                    name = .Item(2).ToString()
                    size = .Item(3).ToString()

                    dat = time.ToShortDateString & " " & time.ToLongTimeString & "." _
                        & time.Millisecond.ToString.PadLeft(3, "0"c) _
                        & ",""" & bkupSubPath & """,""" & name & """," & size

                    wfs.WriteLine(dat)
                End With
            Next

            wfs.Flush()
            wfs.Close()
        End Using

        If File.Exists(dbName) Then
            File.Delete(dbName)
        End If

        File.Move(tmpName, dbName)

    End Sub

    Public Function RefreshDB(ByVal fileshomedir As String) As Integer
        Dim rc As Integer = -1
        Dim dbName As String = mvarSource & "\" & mvarDbFileName

        Try
            If Directory.Exists(fileshomedir) Then
                Dim tmpFile As String = dbName & ".tmp"
                If File.Exists(tmpFile) Then
                    File.Delete(tmpFile)
                End If

                Dim d As New DirectoryInfo(fileshomedir)
                Dim ds() As DirectoryInfo = d.GetDirectories()
                Dim wfs As StreamWriter = File.AppendText(tmpFile)

                Try
                    mvarFileCount = 0
                    For Each sd As DirectoryInfo In ds
                        rc = refreshPath(wfs, sd.FullName, 0)
                        If rc <> 0 Then
                            Exit For
                        End If
                    Next
                Finally
                    wfs.Flush()
                    wfs.Close()
                End Try

                If rc = 0 Then
                    If File.Exists(dbName) Then
                        If File.Exists(dbName & ".bak") Then
                            File.Delete(dbName & ".bak")
                        End If
                        File.Move(dbName, dbName & ".bak")
                    End If
                    File.Move(tmpFile, dbName)
                    'Refresh the current database
                    Me.ReSelect()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        Return rc

    End Function

    Private Function refreshPath(ByVal wfs As StreamWriter, ByVal dir As String, ByVal depth As Integer) As Integer
        Dim rc As Integer = -1
        Dim fi As FileInfo

        Try
            If Directory.Exists(dir) Then
                Dim d As New DirectoryInfo(dir)
                Dim ds() As DirectoryInfo = d.GetDirectories()
                For Each sd As DirectoryInfo In ds
                    rc = refreshPath(wfs, sd.FullName, depth + 1)
                Next

                Dim fs() As FileInfo = d.GetFiles()
                For Each fi In fs
                    Dim ps() As String = fi.FullName.Split("\"c)
                    Dim bkupSubPath As String = ps(ps.Length - depth - 2)
                    Dim time As Date = fi.CreationTime
                    Dim info As New System.Text.StringBuilder(time.ToShortDateString)

                    info.Append(" ").Append(time.ToLongTimeString).Append(".") _
                        .Append(time.Millisecond.ToString.PadLeft(3, "0"c)) _
                        .Append(",""").Append(bkupSubPath) _
                        .Append(""",""")    '.Append("/").Append(String.Join("/", ps, ps.Length - depth - 1, depth + 1)) _
                    For i As Integer = ps.Length - depth - 1 To ps.Length - 1
                        info.Append("/" & ps(i))
                    Next
                    info.Append(""",").Append(fi.Length)

                    wfs.WriteLine(info)
                Next
                mvarFileCount += fs.Length
                rc = 0
            Else
                rc = -1
            End If

        Catch ex As Exception
            Throw
        End Try

        Return rc

    End Function

    Public Shared Function Compare(ByVal path1 As String, ByVal path2 As String) As Boolean

        If File.Exists(path1) AndAlso File.Exists(path2) Then
            Using fs1 As FileStream = File.OpenRead(path1)
                Using fs2 As FileStream = File.OpenRead(path2)

                    Dim datLen As Long = fs1.Length

                    If datLen <> fs2.Length Then Return False
                    If datLen > 100000000 Then
                        Do While fs1.Position < datLen
                            If fs1.ReadByte() <> fs2.ReadByte Then
                                Return False
                            End If
                        Loop
                        Return True
                    End If

                End Using
            End Using

            Dim bt1() As Byte = My.Computer.FileSystem.ReadAllBytes(path1)
            Dim bt2() As Byte = My.Computer.FileSystem.ReadAllBytes(path2)

            Dim pos As Integer = 0
            Do While pos < bt1.Length
                If bt1(pos) <> bt2(pos) Then
                    Return False
                End If
                pos += 1
            Loop

            Return True
        Else
            '指定ファイルが見つからない場合
            Return False
        End If

    End Function

    Public Shared Sub PackDB(ByVal dbPath As String)
        Dim ldb As DbManager
        Dim i As Integer
        Dim folder As String
        Dim fname As String
        Dim fsize As String
        Dim ftstp As String
        Dim lastname As String = ""
        Dim lastfolder As String = ""
        Dim Sql As String = "SELECT FileName, FileSize, tstp, BackupFolder " _
            & "FROM list.txt " _
            & "ORDER BY FileName, tstp DESC"

        ldb = GetDbInstance(Sql, "")
        Dim wkfile As String = ldb.Source & "\listwk.txt"

        If File.Exists(wkfile) Then
            File.Delete(wkfile)
        End If

        Using wfs As StreamWriter = File.AppendText(wkfile)
            With ldb.DataSet.Tables(0)
                For i = 0 To .Rows.Count - 1
                    fname = .Rows(i).Item(0).ToString
                    fsize = .Rows(i).Item(1).ToString
                    ftstp = .Rows(i).Item(2).ToString
                    folder = .Rows(i).Item(3).ToString
                    If lastname = fname AndAlso Compare(dbPath & "\" & lastfolder & fname, dbPath & "\" & folder & fname) Then
                        File.Delete(dbPath & "\" & folder & fname)
                    Else
                        Dim info As String = ftstp & ",""" & folder _
                            & """,""" & fname & """," & fsize
                        wfs.WriteLine(info)
                        lastname = fname
                        lastfolder = folder
                    End If
                    Application.DoEvents()
                Next
            End With
        End Using

        If File.Exists(ldb.Source & "\list.txt.bak") Then
            File.Delete(ldb.Source & "\list.txt.bak")
        End If
        File.Move(ldb.Source & "\list.txt", ldb.Source & "\list.txt.bak")
        File.Move(wkfile, ldb.Source & "\list.txt")

        ObjDb.Dispose()
        ObjDb = Nothing

        '空のサブフォルダーを削除
        removeBlankFolders(dbPath, 0)

    End Sub

    Private Shared Function removeBlankFolders(ByVal root As String, ByVal depth As Integer) As Integer
        Dim rc As Integer = 0
        Dim cnt As Integer = 0

        Try
            If Directory.Exists(root) Then
                Dim d As New DirectoryInfo(root)
                Dim ds() As DirectoryInfo = d.GetDirectories()
                For Each sd As DirectoryInfo In ds
                    rc = removeBlankFolders(sd.FullName, depth + 1)
                    If rc < 0 Then
                        Return -1
                    Else
                        If rc = 0 Then
                            Directory.Delete(sd.FullName)
                        End If
                        cnt += rc
                    End If
                Next

                Dim fs() As FileInfo = d.GetFiles()
                cnt += fs.Length
                Application.DoEvents()

            End If

        Catch ex As Exception
            Return -1
        End Try

        Return cnt

    End Function

    Public Function CreateSchema(ByVal path As String, ByVal value As String) As Integer
        Dim rc As Integer = 0

        Try
            If Not Directory.Exists(path) Then
                Directory.CreateDirectory(path)
            End If
            Using sw As StreamWriter = File.AppendText(path & "\schema.ini")
                sw.Write(value)
            End Using

        Catch ed As DirectoryNotFoundException
            rc = -2
        Catch ex As Exception
            rc = -1
        End Try

        Return rc
    End Function

    Public Shared Function GetDBInfo(ByVal dsn As String) As String

        Dim info As New System.Text.StringBuilder

        Using cnn As SQLiteConnection = New SQLiteConnection("Data Source=" & dsn)
            Using cmd As SQLiteCommand = cnn.CreateCommand

                cnn.Open()

                Dim dtables As DataTable = cnn.GetSchema("Tables")

                info.Append("Server Version = ").Append(cnn.ServerVersion).AppendLine(vbCrLf)

                For Each dt As DataRow In dtables.Rows
                    Dim tblname As String = dt.Item(2).ToString

                    info.Append("<<").Append(tblname).AppendLine(">>")
                    cmd.CommandText = "SELECT * FROM " & tblname

                    Dim j As Integer = 0
                    Using reader As SQLiteDataReader = cmd.ExecuteReader
                        Do While reader.Read()
                            'write header
                            If j = 0 Then
                                For i As Integer = 0 To reader.FieldCount - 1
                                    Select Case reader.Item(i).GetType().Name
                                        Case "Byte[]"
                                            info.Append(reader.GetName(i)).Append("[").Append(DirectCast(reader.Item(i), Byte()).Length).Append("], ")
                                        Case Else
                                            info.Append(reader.GetName(i)).Append(", ")
                                    End Select
                                Next
                                info.AppendLine()
                            End If
                            'write data
                            For i As Integer = 0 To reader.FieldCount - 1
                                Select Case reader.Item(i).GetType().Name
                                    Case "Byte[]"
                                        info.Append("[")
                                        For k As Integer = 0 To DirectCast(reader.Item(i), Byte()).Length - 1
                                            info.AppendFormat("{0:X}, ", DirectCast(reader.Item(i), Byte())(k))
                                            If k > 100 Then
                                                info.Append(" ...")
                                                Exit For
                                            End If
                                        Next
                                        info.Append("], ")
                                    Case Else
                                        If reader.Item(i).ToString.IndexOf(",") > -1 Then
                                            info.Append("""").Append(reader.Item(i)).Append(""", ")
                                        Else
                                            info.Append(reader.Item(i)).Append(", ")
                                        End If
                                End Select
                            Next
                            info.AppendLine()
                            If j > 500 Then
                                info.AppendLine(" ... (Over 500 records)")
                                Exit Do
                            End If
                            j += 1
                        Loop
                    End Using
                    info.AppendLine(vbCrLf)
                Next
            End Using
        End Using

        Return info.ToString

    End Function

End Class
