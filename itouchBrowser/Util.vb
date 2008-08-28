Option Explicit On
Option Strict On
' =============================================================================
' *
' *  System      : CommonClass
' *  Module name : Util.vb
' *  Description : Common Utility Class
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

<System.Runtime.InteropServices.ComVisible(False)> Public Class Util

    Public Enum MsgLevel
        AA_INFO
        AA_ERROR
        AA_DEBUG
    End Enum

    'Logの処理ファンクション
    Private Shared mInd As Integer = 0

    ''' <summary>
    ''' ログのインデントレベルを取得・設定できます。
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Property LogIndentLevel() As Integer
        <DebuggerStepThrough()> Get
            Return mInd
        End Get
        <DebuggerStepThrough()> Set(ByVal value As Integer)
            mInd = value
        End Set
    End Property

    ''' <summary>
    ''' 開始ログをログファイルに記録します。
    ''' </summary>
    <DebuggerStepThrough()> Public Shared Sub TraceS(ByVal funcName As String, ByVal logMsg As String)
        Try
            'If mLogger Is Nothing Then
            '    mLogger = ExeLogger.GetInstance()
            'End If

            Dim msg As String = Space(mInd) _
                & "+" & funcName & "." & logMsg & " - Start"
            'mLogger.WriteMessage(CommonClassLib.MsgLevel.AA_DEBUG, msg.ToString)
            Debug.WriteLine(msg)

        Catch ex As Exception
            Trace.WriteLine(ex.ToString)

        Finally
            mInd += 1
        End Try

    End Sub

    ''' <summary>
    ''' 終了ログをログファイルに記録します。
    ''' </summary>
    <DebuggerStepThrough()> Public Shared Sub TraceE(ByVal funcName As String, ByVal logMsg As String)
        mInd -= 1
        'If Not mLogger Is Nothing Then
        If mInd < 0 Then
            mInd = 0
            'mLogger.WriteMessage(MsgLevel.AA_DEBUG, "Missmatch indent!!")
        End If
        Dim msg As String = Space(mInd) _
            & "-" & funcName & "." & logMsg & " - End"
        'mLogger.WriteMessage(CommonClassLib.MsgLevel.AA_DEBUG, msg.ToString)
        Debug.WriteLine(msg)

        'End If
    End Sub

    ''' <summary>
    ''' メッセージをログファイルに記録します。
    ''' </summary>
    <DebuggerStepThrough()> Public Shared Sub Log(ByVal logMode As MsgLevel, ByVal logMsg As String)
        'If Not mLogger Is Nothing Then
        '   mLogger.WriteMessage(logMode, Space(mInd) & logMsg)
        Debug.WriteLine(Space(mInd) & logMsg)
        'End If
    End Sub

End Class
