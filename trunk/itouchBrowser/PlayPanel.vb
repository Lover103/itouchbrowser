Option Explicit On
Option Strict On
' =============================================================================
' *
' *  System      : itouchBrowser
' *  Module name : PlayPanel.vb
' *  Description : Quicktime Panel Class
' *
' *    %Z% %I% %W% %G% %U% [ %H% %T% ]
' *    $Header:  $
' *
' *  (c) Copyright . 2007, 2008. All rights reserved.
' *
' *  Modification history :
' *    Date        Level  Author        Description
' *    ----------  -----  ------------  -----------------------------------
' *    2008/12/08  1.00   Sugi          Initial release
' *
' =============================================================================

Public Class PlayPanel

    Public Property ImageLocation() As String
        Get
            Return picArtistImage.ImageLocation
        End Get
        Set(ByVal value As String)
            picArtistImage.ImageLocation = value
        End Set
    End Property

    Public Property Lyric() As String
        Get
            Return txtLyric.Text
        End Get
        Set(ByVal value As String)
            txtLyric.Text = value
        End Set
    End Property

    Public Property MovieInfo() As String
        Get
            Return txtMovieName.Text
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Private mvarLyricVisible As Boolean = True

    Public Property LyricVisible() As Boolean
        Get
            Return mvarLyricVisible
        End Get
        Set(ByVal value As Boolean)
            mvarLyricVisible = value
            Me.txtLyric.Visible = value
            If value = False Then
                Me.txtLyric.Text = ""
            End If
            '_resize()
        End Set
    End Property

    Private mvarPictureVisible As Boolean = False

    Public Property PictureVisible() As Boolean
        Get
            Return mvarPictureVisible
        End Get
        Set(ByVal value As Boolean)
            mvarPictureVisible = value
            Me.spcLeft.Panel2Collapsed = Not value
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return qtPlugin.FileName
        End Get
        Set(ByVal value As String)
            qtPlugin.FileName = value
        End Set
    End Property

    Public Property LeftWidth() As Integer
        Get
            Return splBase.SplitterDistance
        End Get
        Set(ByVal value As Integer)
            splBase.SplitterDistance = value
        End Set
    End Property

    Public Property BottomHeight() As Integer
        Get
            Return Me.Height - spcLeft.SplitterDistance
        End Get
        Set(ByVal value As Integer)
            If value = 0 Then
                spcLeft.Panel2Collapsed = True
            Else
                spcLeft.Panel2Collapsed = False
                spcLeft.SplitterDistance = Me.Height - value
            End If
        End Set
    End Property

    Public ReadOnly Property QT() As QtWrapper
        Get
            Return qtPlugin
        End Get
    End Property

    Public ReadOnly Property ArtistName() As String
        Get
            Return qtPlugin.Arts
        End Get
    End Property

    'Public Property QtVisible() As Boolean
    '    Get
    '        Return qtPlugin.Visible
    '    End Get
    '    Set(ByVal value As Boolean)
    '        qtPlugin.Visible = value
    '    End Set
    'End Property

    Private suspended As Boolean = False

    Public Overloads Sub SuspendLayout()
        MyBase.SuspendLayout()
        qtPlugin.Visible = False
        Me.suspended = True
    End Sub

    Public Overloads Sub ResumeLayout()
        MyBase.ResumeLayout()
        Me.suspended = False
        _resize()
        qtPlugin.Visible = True
    End Sub

    Public Function Play(ByVal fname As String, ByVal comment As String) As Boolean
        Dim rc As Boolean = True

        Try
            rc = qtPlugin.Play(fname)
            If qtPlugin.Lyric.Length > 0 Then
                Me.LyricVisible = True
                Me.txtLyric.Text = qtPlugin.Lyric
                Application.DoEvents()
            Else
                If comment.Length > 0 Then
                    txtLyric.Text = comment
                    LyricVisible = True
                Else
                    LyricVisible = False
                End If
            End If
            Me.picArtistImage.Image = ConvertBLOBtoImage(qtPlugin.MetaData)
            Me.PictureVisible = (Me.picArtistImage.Image IsNot Nothing)
            _resize()

        Catch ex As Exception
            rc = False
        End Try

        Return rc

    End Function

    Private Sub qtPlugin_AnnotationUpdate(ByVal annotation As String) _
    Handles qtPlugin.AnnotationUpdate

        txtMovieName.Text = annotation

    End Sub

    Public Shadows Function QuickTimeInitialize() As Integer
        Dim rc As Integer

        rc = qtPlugin.QuickTimeInitialize()

        Return rc
    End Function

    Private Sub PlayPanel_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        qtPlugin.Dispose()
    End Sub

    'Private Sub PlayPanel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    _resize()
    'End Sub

    Private Sub spcLeft_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles spcLeft.Resize
        _resize()
    End Sub

    Private Sub _resize()

        If suspended = False Then
            Dim h As Integer = 20
            Dim w As Integer = Me.Width - splBase.SplitterDistance - 4

            If Me.LyricVisible = False Then
                h = spcLeft.Height - 2
            End If

            qtPlugin.Size = New Size(w, h)
            'qtPlugin.Refresh()
        End If

    End Sub

    Private Function ConvertBLOBtoImage(ByVal source As Byte()) As Drawing.Image
        Dim image As System.Drawing.Image = Nothing

        Try
            If source IsNot Nothing Then
                'Byte[]データ読み取り用ストリームを生成
                Dim tempStream As System.IO.MemoryStream = New System.IO.MemoryStream(source)
                'メモリストリーム(Byte[])からImageデータに変換
                image = System.Drawing.Image.FromStream(tempStream)
                'メモリストリームを閉じる
                tempStream.Close()
            End If
        Catch
            'Throw New BadImageFormatException("Image オブジェクト(BLOB)をImageデータを に変換できません。扱えないデータが指定された可能性があります。")
        End Try

        Return image

    End Function

    Friend Sub ShowExportDialog()

        Me.PauseMovie()
        Me.Enabled = False
        Try
            QT.ShowExportDialog()
            QT.Movie.Play()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Friend Sub PauseMovie()
        'if qt.Movie.
        QT.Movie.Pause()
    End Sub

    Private Sub PlayPanel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ResumeLayout()
    End Sub

End Class
