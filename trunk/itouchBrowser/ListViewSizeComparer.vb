Option Strict On

Class ListViewSizeComparer
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

    Private Function SizeToLong(ByVal aSize As String) As Double
        Dim ans As Double
        ans = Conversion.Val(aSize)
        If aSize.EndsWith("KB") Then
            ans = 1024 * ans
        ElseIf aSize.EndsWith("MB") Then
            ans = 1024 * 1024 * ans
        End If
        Return ans
    End Function

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim xs As Double, ys As Double
        xs = SizeToLong(CType(x, ListViewItem).SubItems(col).Text)
        ys = SizeToLong(CType(y, ListViewItem).SubItems(col).Text)
        If sortOrder = Windows.Forms.SortOrder.Ascending Then
            Return CInt(xs - ys)
        Else
            Return CInt(ys - xs)
        End If
    End Function

End Class
