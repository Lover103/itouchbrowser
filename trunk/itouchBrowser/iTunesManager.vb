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

Imports system.IPod

Public Class iTunesManager
    Private mvarItDb As Music.ITunesDb = Nothing
    Private mvarArts As String() = {"Error"}
    Private mvarItunes As Data.DataTable = Nothing

    Friend Sub New()
        mvarItDb = New Music.ITunesDb
    End Sub

    Friend Sub Dispose()
        mvarItunes.Dispose()
        mvarItDb.Clear()
        mvarItDb = Nothing
        mvarItDb = New Music.ITunesDb
    End Sub

    Friend Sub Clear()
        mvarItDb.Clear()
        If mvarItunes IsNot Nothing Then
            mvarItunes.Clear()
            mvarItunes = Nothing
        End If
    End Sub

    Friend Function GetArtists(ByVal dbPath As String) As String()
        Try
            If mvarItDb.Loaded = False Then
                mvarItDb.Load(dbPath & "\iTunesDB")
            End If
            mvarArts = mvarItDb.GetArtists()
            Array.Sort(mvarArts)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return mvarArts

    End Function

    Friend Function GetAlbums(ByVal artist As String) As String()
        Dim albums As String() = {"Error"}
        Try
            albums = mvarItDb.GetAlbums(artist)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return albums

    End Function

    Friend Function GetSongs(ByVal artist As String) As Music.TrackItem()
        Dim songs As Music.TrackItem() = Nothing
        Try
            songs = mvarItDb.GetAllSongs(artist)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return songs

    End Function

    Friend Function GetRecSet() As Data.DataTable
        Dim dt As New Data.DataTable

        If mvarItDb.Loaded = False Then
            Return Nothing
        End If

        Dim dc As New Data.DataColumn("Location", System.Type.GetType("System.String"))
        dc.Caption = "Path"
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("Title", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("FileSize", System.Type.GetType("System.Int32"))
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("Artist", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("Album", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("Genre", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("FileType", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)
        dc = New Data.DataColumn("Commnet", System.Type.GetType("System.String"))
        dt.Columns.Add(dc)

        Dim trItems As Music.TrackItem()
        dt.BeginInit()
        For i As Integer = 0 To mvarArts.Length - 1
            trItems = GetSongs(mvarArts(i))
            For j As Integer = 0 To trItems.Length - 1
                Dim trItem As Music.TrackItem = trItems(j)
                Dim row As Data.DataRow = dt.NewRow()
                row.Item(0) = trItem.Location
                row.Item(1) = trItem.Title
                row.Item(2) = trItem.FileSize
                row.Item(3) = trItem.Artist
                row.Item(4) = trItem.Album
                row.Item(5) = trItem.Genre
                row.Item(6) = trItem.FileType
                row.Item(7) = trItem.Commnet
                dt.Rows.Add(row)
            Next
        Next
        dt.EndInit()
        mvarItunes = dt

        Return dt

    End Function

    Friend Function [Select](ByVal iPhoneFile As String) As String

        If mvarItunes Is Nothing Then
            Return ""
        End If

        Dim ret As String = ""
        Dim tuneIndex As Integer = iPhoneFile.IndexOf("iTunes_Control/")

        If tuneIndex < 0 Then Return ""

        Dim tuneName As String = iPhoneFile.Substring(tuneIndex).Replace("/", "\")
        Dim dr As Data.DataRow() = mvarItunes.Select("Location='" & tuneName & "'")
        If dr.Length > 0 Then
            ret = "(" & dr(0).Item("Artist").ToString _
                & ":" & dr(0).Item("Title").ToString _
                & ":" & dr(0).Item("Album").ToString & ")"
        End If

        Return ret
    End Function

End Class
