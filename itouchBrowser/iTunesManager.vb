Option Explicit On
Option Strict On
' =============================================================================
' *
' *  System      : itouchBrowser
' *  Module name : iTunesManager.vb
' *  Description : iTunes Manafer Class
' *
' *    %Z% %I% %W% %G% %U% [ %H% %T% ]
' *    $Header:  $
' *
' *  (c) Copyright . 2008. All rights reserved.
' *
' *  Modification history :
' *    Date        Level  Author        Description
' *    ----------  -----  ------------  -----------------------------------
' *    2008/10/12  1.00   Sugi          Initial release
' *
' =============================================================================

Imports System.IPod
Imports System.Data.SQLite

Public Class iTunesManager
    Private mvarItDb As Music.ITunesDb = Nothing
    Private mvarArts As String() = {"Error"}
    Private mvarItunes As Data.DataTable = Nothing
    Private mvarObjSql As SQLiteConnection
    Private mvarDBVer As Single = 2.0
    Private mvarDBPath As String
    Private mvarGenres() As String
    Private mvarFileType() As String

    Friend Sub New()
        mvarItDb = New Music.ITunesDb
    End Sub

    Friend Sub Dispose()
        mvarItunes.Dispose()
        mvarItDb.Clear()
        mvarItDb = Nothing
        mvarItDb = New Music.ITunesDb
    End Sub

    Public ReadOnly Property Loaded() As Boolean
        Get
            Return mvarItDb.Loaded
        End Get
    End Property

    Friend Sub Clear()
        mvarItDb.Clear()
        If mvarItunes IsNot Nothing Then
            mvarItunes.Clear()
            mvarItunes = Nothing
        End If
    End Sub

    Friend Function GetArtists(ByVal dbPath As String) As String()
        Try
            mvarDBPath = dbPath

            If FileSystem.FileLen(dbPath & "\iTunesDB") = 0 Then
                Dim i As Integer = 0
                Dim sql As String = "select distinct artist from item"
                Dim ds As Data.DataSet = DbManager.SelectSQL(dbPath & "\Library.itdb", sql)
                mvarArts = New String(ds.Tables(0).Rows.Count) {}
                For Each rec As Data.DataRow In ds.Tables(0).Rows
                    mvarArts(i) = rec.Item(0).ToString()
                    i += 1
                Next
                ds.Dispose()
                mvarDBVer = 3.0

            Else
                If mvarItDb.Loaded = False Then
                    mvarItDb.Load(dbPath & "\iTunesDB")
                End If
                mvarArts = mvarItDb.GetArtists()
            End If
            If mvarArts.Length > 0 Then
                Array.Sort(mvarArts)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return mvarArts

    End Function

    Friend Function GetAlbums(ByVal artist As String) As String()
        Dim albums As String() = {"Error"}
        Dim j As Integer = 0
        Dim lastVal As String = ""

        Try
            'albums = mvarItDb.GetAlbums(artist)
            Dim dr() As Data.DataRow = mvarItunes.Select("Artist='" & DbManager.CvtData(artist) & "'")
            albums = New String(dr.Length) {}
            For i As Integer = 0 To dr.Length - 1
                Dim val As String = dr(i).Item("Album").ToString()
                If lastVal <> val Then
                    albums(j) = val
                    lastVal = val
                    j += 1
                End If
            Next

            If j = 0 Then
                albums = New String(-1) {}
            Else
                ReDim Preserve albums(j - 1)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return albums

    End Function

    Private Function GetSongs(ByVal artist As String) As Music.TrackItem()
        Dim songs As Music.TrackItem() = Nothing
        Try
            songs = mvarItDb.GetAllSongs(artist)
            If songs.Length = 0 Then
                songs = mvarItDb.GetSongs(artist)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return songs

    End Function

    Friend Function GetSongsByArt(ByVal artist As String, ByVal album As String) As Data.DataRow()
        Dim songs() As Data.DataRow = Nothing
        Try
            If mvarItunes IsNot Nothing Then
                If artist = "All" Then
                    songs = mvarItunes.Select("Artist='" & DbManager.CvtData(album) & "'")
                End If
                If songs Is Nothing OrElse songs.Length = 0 Then
                    songs = mvarItunes.Select("Artist='" & DbManager.CvtData(artist) & "' and Album='" & DbManager.CvtData(album) & "'")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return songs

    End Function

    Friend Function GetRecSet() As Data.DataTable
        Dim dt As New Data.DataTable

        If mvarItDb.Loaded = False AndAlso mvarDBVer < 3.0 Then
            Return Nothing
        End If

        Dim dc As New Data.DataColumn("Location", System.Type.GetType("System.String"))
        dc.Caption = "Path"
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("Title", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)
        If mvarDBVer < 3.0 Then
            dc = New Data.DataColumn("FileSize", System.Type.GetType("System.Int32"))
        Else
            dc = New Data.DataColumn("FileSize", System.Type.GetType("System.String"))
        End If
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("Artist", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("Album", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("Genre", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("FileType", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("Comment", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("TrackNumber", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)

        Dim trItems As Music.TrackItem()
        dt.BeginInit()

        Try
            If mvarDBVer < 3.0 Then
                For i As Integer = 0 To mvarArts.Length - 1
                    trItems = Me.GetSongs(mvarArts(i))
                    For j As Integer = 0 To trItems.Length - 1
                        Dim trItem As Music.TrackItem = trItems(j)
                        Dim row As Data.DataRow = dt.NewRow()
                        row.Item(0) = trItem.Location.Replace("\", "/")
                        row.Item(1) = trItem.Title
                        row.Item(2) = CInt(trItem.FileSize)
                        row.Item(3) = trItem.Artist
                        row.Item(4) = trItem.Album
                        row.Item(5) = trItem.Genre
                        row.Item(6) = trItem.FileType
                        row.Item(7) = trItem.Commnet
                        row.Item(8) = trItem.TrackNumber
                        dt.Rows.Add(row)
                    Next
                Next
            Else
                Dim sql As String
                ' Get genre map data
                sql = "select id, genre from genre_map order by id"
                Using ds As Data.DataSet = DbManager.SelectSQL(mvarDBPath & "\Library.itdb", sql)
                    mvarGenres = New String(ds.Tables(0).Rows.Count) {}
                    For Each rec As Data.DataRow In ds.Tables(0).Rows
                        mvarGenres(CInt(rec.Item(0))) = rec.Item(1).ToString()
                    Next
                End Using

                ' Get file type map data
                sql = "select id, kind from location_kind_map order by id"
                Using ds As Data.DataSet = DbManager.SelectSQL(mvarDBPath & "\Library.itdb", sql)
                    mvarFileType = New String(ds.Tables(0).Rows.Count + 60) {}
                    For Each rec As Data.DataRow In ds.Tables(0).Rows
                        mvarFileType(CInt(rec.Item(0))) = rec.Item(1).ToString()
                    Next
                End Using

                sql = "select item_pid,location from location order by item_pid"
                Using locds As Data.DataSet = DbManager.SelectSQL(mvarDBPath & "\Locations.itdb", sql)
                    'Dim sql As String = "select title,Artist,Album,total_time_ms,Comment,track_number from item where genre_id='' and artist='" & DbManager.CvtData(mvarArts(i)) & "'"
                    'Dim sql As String = "select item.title,item.artist,item.album,item.total_time_ms,item.comment,item.track_number,genre_id from item,genre_map where item.genre_id=genre_map.id"
                    'Dim sql As String = "select item.title,item.artist,item.album,item.total_time_ms,item.comment,item.track_number,genre_map.genre from item,genre_map where item.genre_id=genre_map.id"
                    sql = "select pid,title,artist,album,total_time_ms,media_kind,comment,track_number,genre_id from item order by album"
                    Using ds As Data.DataSet = DbManager.SelectSQL(mvarDBPath & "\Library.itdb", sql)
                        For Each rec As Data.DataRow In ds.Tables(0).Rows
                            Dim row As Data.DataRow = dt.NewRow()
                            Dim loc() As Data.DataRow = locds.Tables(0).Select("item_pid=" & rec("pid").ToString())
                            row.Item(0) = "iTunes_Control/Music/" & loc(0).Item("location").ToString()
                            row.Item(1) = rec("title").ToString()
                            row.Item(2) = String.Format("{0:0}sec", CInt(rec("total_time_ms")) / 1000)
                            row.Item(3) = rec("artist").ToString()
                            row.Item(4) = rec("album").ToString()
                            row.Item(5) = mvarGenres(CInt(rec("Genre_id")))
                            'Debug.WriteLine(rec("media_kind").ToString() & " - " & rec("title").ToString())
                            row.Item(6) = mvarFileType(CInt(rec("media_kind")))
                            row.Item(7) = rec("comment").ToString()
                            row.Item(8) = rec("track_number").ToString()
                            dt.Rows.Add(row)
                        Next
                    End Using
                End Using
            End If

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Exclamation)
        Finally
            dt.EndInit()
            mvarItunes = dt
        End Try

        Return dt

    End Function

    Friend Function [Select](ByVal iPhoneFile As String) As String

        If mvarItunes Is Nothing Then
            Return ""
        End If

        Dim ret As String = ""
        Dim tuneIndex As Integer = iPhoneFile.IndexOf("iTunes_Control/")

        If tuneIndex < 0 Then Return ""

        Dim tuneName As String = iPhoneFile.Substring(tuneIndex)    '.Replace("/", "\")
        Dim dr As Data.DataRow() = mvarItunes.Select("Location='" & tuneName & "'")
        If dr.Length > 0 Then
            ret = "(" & dr(0).Item("Artist").ToString _
                & ":" & dr(0).Item("Title").ToString _
                & ":" & dr(0).Item("Album").ToString & ")"
        End If

        Return ret
    End Function

End Class
