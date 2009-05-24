Option Strict On
Option Explicit On
' =============================================================================
' *
' *  System      : itouchBrowser
' *  Module name : frmFileAttributes.vb
' *  Description : File Attributes dialog box
' *
' *    %Z% %I% %W% %G% %U% [ %H% %T% ]
' *    $Header:  $
' *
' *  (c) Copyright sugi. 2009. All rights reserved.
' *
' *  Modification history :
' *    Date        Level  Author        Description
' *    ----------  -----  ------------  -----------------------------------
' *    2009/04/24  1.00   Sugi          Initial release
' *
' =============================================================================
Imports itouchBrowser

Public Class frmFileAttributes

    Private mvarFileName As String = ""
    Private mvarAttributes As String = ""
    Public ObjSSL As SSHManager

    Friend Property FileName() As String
        Get
            Return mvarFileName
        End Get
        Set(ByVal value As String)
            mvarFileName = value
        End Set
    End Property

    Friend Property Atributes() As String
        Get
            Return mvarAttributes
        End Get
        Set(ByVal value As String)
            mvarAttributes = value
        End Set
    End Property

    Private Sub FileAttributes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim attr As String = mvarAttributes

        If attr.Length > 9 Then
            chkOR.Checked = (attr.Substring(1, 1) = "r")
            chkOW.Checked = (attr.Substring(2, 1) = "w")
            chkOX.Checked = (attr.Substring(3, 1) = "x")
            chkGR.Checked = (attr.Substring(4, 1) = "r")
            chkGW.Checked = (attr.Substring(5, 1) = "w")
            chkGX.Checked = (attr.Substring(6, 1) = "x")
            chkER.Checked = (attr.Substring(7, 1) = "r")
            chkEW.Checked = (attr.Substring(8, 1) = "w")
            chkEX.Checked = (attr.Substring(9, 1) = "x")
        End If

        txtFileName.Text = mvarFileName

        Dim attrs() As String = attr.Split(" "c)
        If attrs.Length > 4 Then
            lblOwnerName.Text = attrs(1)
            lblGroupName.Text = attrs(2)

            Dim p As Integer = attrs(0).Length + attrs(1).Length + attrs(2).Length + 3
            lblUpdateValue.Text = attr.Substring(p)
        End If

    End Sub

    Private Function getOctalValue() As Integer
        Dim o As Integer = 0
        Dim g As Integer = 0
        Dim e As Integer = 0

        o = CInt(IIf(chkOR.Checked, 4, 0))
        o += CInt(IIf(chkOW.Checked, 2, 0))
        o += CInt(IIf(chkOX.Checked, 1, 0))

        g = CInt(IIf(chkGR.Checked, 4, 0))
        g += CInt(IIf(chkGW.Checked, 2, 0))
        g += CInt(IIf(chkGX.Checked, 1, 0))

        e = CInt(IIf(chkER.Checked, 4, 0))
        e += CInt(IIf(chkEW.Checked, 2, 0))
        e += CInt(IIf(chkEX.Checked, 1, 0))

        Return o * 100 + g * 10 + e

    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal ev As System.EventArgs) _
        Handles btnOK.Click

        Dim oct As Integer = getOctalValue()

        Dim cmd As String = "chmod " & txtOctal.Text & " " & mvarFileName
        If ObjSSL IsNot Nothing AndAlso ObjSSL.Connected Then
            Dim ret As String = ObjSSL.Command(cmd)

        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub chkOR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkOR.CheckedChanged, chkOW.CheckedChanged, chkOX.CheckedChanged, _
                chkGR.CheckedChanged, chkGW.CheckedChanged, chkGX.CheckedChanged, _
                chkER.CheckedChanged, chkEW.CheckedChanged, chkEX.CheckedChanged

        Dim ctl As CheckBox = DirectCast(sender, CheckBox)
        If ctl.Checked Then
            ctl.BackColor = Color.LightSkyBlue
        Else
            ctl.BackColor = Color.WhiteSmoke
        End If

        txtOctal.Text = "0" & getOctalValue().ToString()

    End Sub

    Private Sub txtOctal_TextChanged(ByVal sender As Object, ByVal ea As System.EventArgs) _
        Handles txtOctal.TextChanged

        Dim v As String = txtOctal.Text

        If v.Length = 4 Then
            Dim o As Integer = Integer.Parse(v.Substring(1, 1))
            Dim g As Integer = Integer.Parse(v.Substring(2, 1))
            Dim e As Integer = Integer.Parse(v.Substring(3, 1))
            chkOR.Checked = ((o And 4) = 4)
            chkOW.Checked = ((o And 2) = 2)
            chkOX.Checked = ((o And 1) = 1)
            chkGR.Checked = ((g And 4) = 4)
            chkGW.Checked = ((g And 2) = 2)
            chkGX.Checked = ((g And 1) = 1)
            chkER.Checked = ((e And 4) = 4)
            chkEW.Checked = ((e And 2) = 2)
            chkEX.Checked = ((e And 1) = 1)
        End If

    End Sub

End Class