Option Explicit On
Option Strict On
' =============================================================================
' *
' *  System      : itouchBrowser
' *  Module name : QtWrapper.vb
' *  Description : Quicktime wrapper Class
' *
' *    %Z% %I% %W% %G% %U% [ %H% %T% ]
' *    $Header:  $
' *
' *  (c) Copyright . 2007, 2008. All rights reserved.
' *
' *  Modification history :
' *    Date        Level  Author        Description
' *    ----------  -----  ------------  -----------------------------------
' *    2008/08/16  1.00   Sugi          Initial release
' *
' =============================================================================
Imports QTOLibrary
Imports System.Runtime.InteropServices

Public Class QtWrapper
    Inherits AxQTOControlLib.AxQTControl
    Implements IDisposable

    'QTPlayerMenuItemStateEnum
    Public Enum QTPlayerMenuItemStateEnum
        qtpMenuItemStateEnabled = 1
        qtpMenuItemStateChecked = 2
        qtpMenuItemStateProOnly = 4
    End Enum

    'QTPlayerWindowStateEnum
    Public Enum QTPlayerWindowStateEnum
        qtpWindowStateNormal = 0
        qtpWindowStateMaximize = 1
        qtpWindowStateMinimize = 2
    End Enum

    'Status Code types'
    Public Enum QTStatusCodeTypesEnum
        qtStatusCodeTypeControl = 0
        qtStatusCodeTypeMovieLoadState = 2
    End Enum

    'Status codes'
    Public Enum QTStatusCodesEnum
        qtStatusNone = 0
        qtStatusConnecting = 2
        qtStatusNegotiating = 5
        qtStatusRequestedData = 11
        qtStatusBuffering = 12
        qtStatusURLChanged = 4096
        qtStatusFullScreenBegin = 4097
        qtStatusFullScreenEnd = 4098
        qtStatusMovieLoadFinalize = 4099
        qtMovieLoadStateError = -1
        qtMovieLoadStateLoading = 1000
        qtMovieLoadStateLoaded = 2000
        qtMovieLoadStatePlayable = 10000
        qtMovieLoadStatePlaythroughOK = 20000
        qtMovieLoadStateComplete = 100000
    End Enum

    Public Enum QTAnnotationsEnum
        qtAnnotationAlbum = 1634493037
        qtAnnotationArtist = 1634890867
        qtAnnotationArtwork = 1634890871
        qtAnnotationAuthor = 1635087464
        qtAnnotationComments = 1668115828
        qtAnnotationComposer = 1668246896
        qtAnnotationCopyright = 1668313716
        qtAnnotationDescription = 1684370275
        qtAnnotationDirector = 1685352306
        qtAnnotationGenre = 1734700658
        qtAnnotationInformation = 1768842863
        qtAnnotationFullName = 1851878757
        qtAnnotationOriginalFormat = 1869769062
        qtAnnotationOriginalSource = 1869769075
        qtAnnotationPerformers = 1885696614
        qtAnnotationProducer = 1886547812
        qtAnnotationSoftware = 1936680564
        qtAnnotationWriter = 2003989618
    End Enum

    Public Shadows Event VisibleChanged(ByVal visibled As Boolean)
    Public Event AnnotationUpdate(ByVal annotation As String)
    Public Event ShowStatusString(ByVal message As String)
    Private mvarEventEnabled As Boolean = True

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overrides Sub Finalize()
        Try
            'MyBase.FileName = ""
            MyBase.QuickTimeTerminate()
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Public Property EventEnabled() As Boolean
        Get
            Return mvarEventEnabled
        End Get
        Set(ByVal value As Boolean)
            mvarEventEnabled = value
        End Set
    End Property

    Public Shadows Function QuickTimeInitialize() As Integer
        Dim rc As Integer

        rc = MyBase.QuickTimeInitialize()

        Return rc
    End Function

    Public Function Play(ByVal fname As String) As Boolean
        Dim rc As Boolean = True
        Try
            removeMovieEventListeners(MyBase.Movie)
            MyBase.FileName = fname
            '.URL = tmpOnPC
            MyBase.Sizing = QTOControlLib.QTSizingModeEnum.qtMovieFitsControlMaintainAspectRatio
            MyBase.AutoPlay = CStr(True)
            MyBase.Visible = True
            MyBase.Refresh()

        Catch ex As Exception
            rc = False
        End Try

        Return rc

    End Function

    Public Function GetAnnotation(ByVal fname As String) As String
        Dim rc As Boolean = True
        Dim annot As String = ""

        Try
            removeMovieEventListeners(MyBase.Movie)
            MyBase.FileName = fname
            'MyBase.AutoPlay = CStr(True)
            'MyBase.Visible = False
            MyBase.Refresh()
            annot = Me.GetAnnotation(MyBase.Movie)

        Catch ex As Exception
            rc = False
        End Try

        Return annot

    End Function

    Public Sub Close()
        If MyBase.Movie IsNot Nothing Then
            removeMovieEventListeners(MyBase.Movie)
            MyBase.FileName = ""
        End If
        Me.Hide()
    End Sub

    Private Sub qtPlugin_QTEvent(ByVal sender As Object, ByVal e As AxQTOControlLib._IQTControlEvents_QTEventEvent) _
        Handles MyBase.QTEvent

        'MyBase.FullScreen = Not MyBase.FullScreen
        Select Case e.eventID
            Case QTEventIDsEnum.qtEventShowStatusStringRequest
                Dim msg As String = e.eventObject.GetParam(QTEventObjectParametersEnum.qtEventParamStatusString).ToString()
                RaiseEvent ShowStatusString(msg)

        End Select
    End Sub

    Private Sub qtPlugin_StatusUpdate(ByVal sender As Object, ByVal e As AxQTOControlLib._IQTControlEvents_StatusUpdateEvent) _
        Handles MyBase.StatusUpdate

        'Return
        If e.statusCodeType = QTStatusCodeTypesEnum.qtStatusCodeTypeControl _
            AndAlso e.statusCode = QTStatusCodesEnum.qtStatusMovieLoadFinalize Then

            Dim annot As String = getAnnotation(MyBase.Movie)
            If annot <> "" AndAlso mvarEventEnabled Then

                Dim listen As QTOLibrary.IQTEventListeners = MyBase.Movie.EventListeners

                listen.RemoveAll()

                ' status string listener
                listen.Add( _
                    QTOLibrary.QTEventClassesEnum.qtEventClassApplicationRequest, _
                    QTOLibrary.QTEventIDsEnum.qtEventShowStatusStringRequest, _
                    0, Nothing)

                ' rate change listener
                listen.Add( _
                    QTOLibrary.QTEventClassesEnum.qtEventClassStateChange, _
                    QTOLibrary.QTEventIDsEnum.qtEventRateWillChange, _
                    0, Nothing)

                ' time change listener
                listen.Add( _
                    QTOLibrary.QTEventClassesEnum.qtEventClassTemporal, _
                    QTOLibrary.QTEventIDsEnum.qtEventTimeWillChange, _
                    0, Nothing)

                ' audio volume change listener
                listen.Add( _
                    QTOLibrary.QTEventClassesEnum.qtEventClassAudio, _
                    QTOLibrary.QTEventIDsEnum.qtEventAudioVolumeDidChange, _
                    0, Nothing)

            End If
            RaiseEvent AnnotationUpdate(annot)
        End If

    End Sub

    Private Sub qtPlugin_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.VisibleChanged

        RaiseEvent VisibleChanged(MyBase.Visible)

    End Sub

    Private Function getAnnotation(ByVal qtMovie As QTOLibrary.QTMovie) As String
        Dim str As New System.Text.StringBuilder()

        If qtMovie IsNot Nothing Then
            Try
                'If qtMovie.Active Then
                Dim citems As QTOLibrary.CFObjects = qtMovie.Annotations.ChildItems
                For i As Integer = 1 To citems.Count
                    Dim item As QTOLibrary.CFObject = citems(i)
                    Select Case item.Key.ToString
                        Case "arts"
                            str.Append(item.Value.ToString).Append(": ")
                        Case "albm"
                            str.Append(item.Value.ToString).Append(": ")
                        Case "name"
                            str.Append(item.Value.ToString).Append(": ")
                    End Select
                Next
                'End If
                str.Append(vbCrLf).Append(vbCrLf)

                Dim annoStr As String = ""

                ' Display some popular movie annotations
                'annoStr = Me.getMovieAnnotation(QTAnnotationsEnum.qtAnnotationFullName, qtMovie)
                'If annoStr IsNot Nothing Then
                '    str.Append(annoStr).Append(vbCrLf)
                'End If

                ' copyright
                annoStr = Me.getMovieAnnotation(QTAnnotationsEnum.qtAnnotationCopyright, qtMovie)
                If annoStr IsNot Nothing Then
                    str.Append(annoStr).Append(vbCrLf)
                End If

                ' author
                annoStr = Me.getMovieAnnotation(QTAnnotationsEnum.qtAnnotationAuthor, qtMovie)
                If annoStr IsNot Nothing Then
                    str.Append(annoStr).Append(vbCrLf)
                End If

                ' comments
                annoStr = Me.getMovieAnnotation(QTAnnotationsEnum.qtAnnotationComments, qtMovie)
                If annoStr IsNot Nothing Then
                    str.Append(annoStr).Append(vbCrLf)
                End If

                ' description
                annoStr = Me.getMovieAnnotation(QTAnnotationsEnum.qtAnnotationDescription, qtMovie)
                If annoStr IsNot Nothing Then
                    str.Append(annoStr).Append(vbCrLf)
                End If

                ' Display movie characteristics

                ' width, height
                If qtMovie.Width > 0 Then
                    str.Append("Size: ").Append(qtMovie.Width.ToString()).Append(" x ").Append(qtMovie.Height.ToString()).Append(vbCrLf)
                End If

                ' duration
                str.Append("Duration: ").Append(qtMovie.Duration.ToString()).Append(vbCrLf)

                Dim tracks As QTTracks = qtMovie.Tracks
                Dim trackEnum As IEnumerator = tracks.GetEnumerator()

                ' display movie track information
                Do While (trackEnum.MoveNext() = True)

                    Dim currTrackObj As QTTrack = CType(trackEnum.Current, QTTrack)

                    ' track display name                    track format
                    str.Append(currTrackObj.DisplayName).Append(": ").Append(currTrackObj.Format())

                    If currTrackObj.Height > 0 Then
                        ' track width/height
                        str.Append(", ").Append(currTrackObj.Width.ToString()).Append(" x ").Append( _
                          currTrackObj.Height.ToString())
                    End If

                    str.Append(vbCrLf)
                Loop

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            End Try

        End If

        Return str.ToString()

    End Function

    ' Get the specified annotation from the movie
    Private Function getMovieAnnotation(ByVal inAnnoID As Integer, ByVal inMovie As QTMovie) As String
        Dim anno As String = ""

        If inMovie IsNot Nothing Then
            Try
                ' get movie annotation
                anno = inMovie.Annotation(inAnnoID)

            Catch
                ' an error here means movie does not contain
                ' the desired annotation
            End Try
        End If

        Return anno

    End Function

    ' remove all event listeners for the movie
    Private Sub removeMovieEventListeners(ByVal myMovie As QTOLibrary.QTMovie)
        ' Make sure a movie is loaded first
        If myMovie IsNot Nothing Then
            ' Remove all event listeners
            myMovie.EventListeners.RemoveAll()
        End If
    End Sub

    Public Sub ShowExportDialog()
        If Me.Movie Is Nothing Then Return

        ' Perform export with user configured settings.
        ' If you want to allow the user to configure
        ' everything (exporter type, file, options:
        ' same as QuickTime Player Export) then use the following:

        Try
            Dim qt As QTOLibrary.QTQuickTime = Me.QuickTime

            If qt.Exporters.Count = 0 Then
                qt.Exporters.Add()
            End If

            Dim ex As QTOLibrary.QTExporter = qt.Exporters(1)

            ' Set exporter data source - could also be a track
            ex.SetDataSource(Me.Movie)
            ' Display the export dialog
            ex.ShowExportDialog()

        Catch ex As COMException

            If ex.ErrorCode <> -2147156096 Then    ' Ignore Cancel
                MessageBox.Show("Error code: " & ex.ErrorCode.ToString("X"), "Export Error")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Export Error")

        End Try

    End Sub

End Class
