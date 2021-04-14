Module funciones_usuarios
    Public login_index_select As Integer
    Public usuarios(50, 12) As String
    Public usuario_thumb(50) As System.Drawing.Image
 'matriz usuarios
    '       0     /  1   /    2       /  3   /   4      /      5       /       6        /      7           /       8      /     9         /    10     /     11      /        12
    '/id_empleado/nombre/nombre_corto/puesto/contraseña/cobro_terminal/pago_proveedores/recepcion-productos/traspasos_env/traspasos_recep/devoluciones/conversiones/ajuste_inventario/ 

    Public Sub limpiar_usuarios()
        For i = 0 To 50
            For j = 0 To 12
                usuarios(i, j) = Nothing
            Next
        Next
    End Sub
    Public Sub limpiar_usuarios_thumb()
        For i = 0 To 50
            usuario_thumb(i) = Nothing
        Next
    End Sub
End Module
