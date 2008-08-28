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

    Public Shadows Event VisibleChanged(ByVal visibled As Boolean)
    Public Event AnnotationUpdate(ByVal annotation As String)
    Public Event ShowStatusString(ByVal message As String)

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.FileName = ""
        MyBase.QuickTimeTerminate()

        MyBase.Finalize()
    End Sub

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
            If annot <> "" Then
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

    Private Function getAnnotation(ByVal qtMovie As QTOLibrary.IQTMovie) As String
        Dim str As String = ""

        If qtMovie IsNot Nothing Then
            Dim citems As QTOLibrary.CFObjects = qtMovie.Annotations.ChildItems
            For i As Integer = 1 To citems.Count
                Dim item As QTOLibrary.CFObject = citems(i)
                Select Case item.Key.ToString
                    Case "arts"
                        str &= item.Value.ToString & ": "
                    Case "albm"
                        str &= item.Value.ToString & ": "
                    Case "name"
                        str &= item.Value.ToString & ": "
                End Select

            Next
        End If

        Return str

    End Function

    ' remove all event listeners for the movie
    Private Sub removeMovieEventListeners(ByVal myMovie As QTOLibrary.QTMovie)
        ' Make sure a movie is loaded first
        If myMovie IsNot Nothing Then
            ' Remove all event listeners
            myMovie.EventListeners.RemoveAll()
        End If
    End Sub

End Class
