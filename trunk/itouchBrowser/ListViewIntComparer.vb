Option Strict On
Option Explicit On

' Implements the manual sorting of items by columns.
Public Class ListViewIntComparer
    Implements IComparer

    Private col As Integer
    Private sortOrder As SortOrder

    Public Sub New()
        col = 0
        sortOrder = Windows.Forms.SortOrder.Ascending
    End Sub

    Public Sub New(ByVal column As Integer)
        col = column
        sortOrder = Windows.Forms.SortOrder.Ascending
    End Sub
    Public Sub New(ByVal column As Integer, ByVal sort As SortOrder)
        col = column
        sortOrder = sort
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim res As Integer = 0

        Try
            Dim col1 As String = CType(x, ListViewItem).SubItems(col).Text
            Dim col2 As String = CType(y, ListViewItem).SubItems(col).Text
            res = CInt(col1) - CInt(col2)
            If sortOrder = Windows.Forms.SortOrder.Ascending Then
                Return res
            Else
                Return -res
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function

End Class
