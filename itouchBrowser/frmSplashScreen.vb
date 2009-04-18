Option Explicit On
Option Strict On
' =============================================================================
' *
' *  System      : CommonClass
' *  Module name : frmSplashScreen.vb
' *  Description : Splash screen Class
' *
' *    %Z% %I% %W% %G% %U% [ %H% %T% ]
' *    $Header:  $
' *
' *  (c) Copyright sugi. 2008. All rights reserved.
' *
' *  Modification history :
' *    Date        Level  Author        Description
' *    ----------  -----  ------------  -----------------------------------
' *    2008/07/29  1.00   Sugi          Initial release
' *
' =============================================================================

Public NotInheritable Class frmSplashScreen

    Friend Sub SetProgressMessage(ByVal msg As String)
        Me.lblMessage.Text = msg
    End Sub

    Private Sub frmSplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Application title
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Version.Text = System.String.Format(Version.Text, _
                My.Application.Info.Version.Major, _
                My.Application.Info.Version.Minor, _
                My.Application.Info.Version.Build, _
                My.Application.Info.Version.Revision)

        'Copyright information
        Copyright.Text = My.Application.Info.Copyright
    End Sub

    Private Sub lblMessage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblMessage.TextChanged
        Me.lblMessage.Refresh()
    End Sub

End Class
