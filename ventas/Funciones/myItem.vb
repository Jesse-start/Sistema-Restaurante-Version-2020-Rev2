Public Class myItem
    Public Value As Integer
    Public Text As String
    Public Opcional As String
    Public Opcional2 As String

    Public Sub New(ByVal NewValue As Integer, ByVal NewText As String, Optional ByVal NewAux1 As String = "", Optional ByVal NewAux2 As String = "")
        Value = NewValue
        Text = NewText
        Opcional = NewAux1
        Opcional2 = NewAux2
    End Sub

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class