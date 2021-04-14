Public Class myTreeNode
    Inherits TreeNode
    Public opcional As Integer
    Public Sub New(ByVal text As String, ByVal id As Integer, Optional ByVal OptionalId As Integer = 0)
        MyBase.New()
        Me.Text = text
        Me.Tag = id
        opcional = OptionalId
    End Sub
End Class
