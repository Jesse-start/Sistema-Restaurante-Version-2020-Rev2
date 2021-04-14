Module funciones_productos_pantalla
    Public favoritos_llena, cat1_llena, cat2_llena, cat3_llena, cat4_llena, cat5_llena, cat6_llena, cat7_llena, cat8_llena, cat9_llena, cat10_llena, cat11_llena, cat12_llena, cat13_llena, cat14_llena, cat15_llena, cat16_llena, cat17_llena, cat18_llena, cat19_llena, cat20_llena, cat21_llena, cat22_llena, cat23_llena, cat24_llena, cat25_llena, cat26_llena, cat27_llena, cat28_llena, cat29_llena As Boolean
    Public categoria(29, 1), favoritos(20, 7), cat1(20, 7), cat2(20, 7), cat3(20, 7), cat4(20, 7), cat5(20, 7), cat6(20, 7), cat7(20, 7), cat8(20, 7), cat9(20, 7), cat10(20, 7), cat11(20, 7), cat12(20, 7), cat13(20, 7), cat14(20, 7), cat15(20, 7), cat16(20, 7), cat17(20, 7), cat18(20, 7), cat19(20, 7), cat20(20, 7), cat21(20, 7), cat22(20, 7), cat23(20, 7), cat24(20, 7), cat25(20, 7), cat26(20, 7), cat27(20, 7), cat28(20, 7), cat29(20, 7) As String
    Public favoritos_thumb(20), cat1_thumb(20), cat2_thumb(20), cat3_thumb(20), cat4_thumb(20), cat5_thumb(20), cat6_thumb(20), cat7_thumb(20), cat8_thumb(20), cat9_thumb(20), cat10_thumb(20), cat11_thumb(20), cat12_thumb(20), cat13_thumb(20), cat14_thumb(20), cat15_thumb(20), cat16_thumb(20), cat17_thumb(20), cat18_thumb(20), cat19_thumb(20), cat20_thumb(20), cat21_thumb(20), cat22_thumb(20), cat23_thumb(20), cat24_thumb(20), cat25_thumb(20), cat26_thumb(20), cat27_thumb(20), cat28_thumb(20), cat29_thumb(20) As System.Drawing.Image
    Private Property rs2 As Object

    ' matriz productos
    '  /     0     /  1   /    2      /  3   /   4  /     5      /   6      /  7     /
    ' /id_producto/nombre/descripcion/unidad/codigo/id_categoria/venta_peso/favorito/
    '
    Public Sub limpiar_categoria(ByVal index As Integer)
        For i = 0 To 200
            For j = 0 To 7
                If index = 0 Then
                    favoritos(i, j) = Nothing
                ElseIf index = 1 Then
                    cat1(i, j) = Nothing
                ElseIf index = 2 Then
                    cat2(i, j) = Nothing
                ElseIf index = 3 Then
                    cat3(i, j) = Nothing
                ElseIf index = 4 Then
                    cat4(i, j) = Nothing
                ElseIf index = 5 Then
                    cat5(i, j) = Nothing
                ElseIf index = 6 Then
                    cat6(i, j) = Nothing
                ElseIf index = 7 Then
                    cat7(i, j) = Nothing
                ElseIf index = 8 Then
                    cat8(i, j) = Nothing
                ElseIf index = 9 Then
                    cat9(i, j) = Nothing
                ElseIf index = 10 Then
                    cat10(i, j) = Nothing
                ElseIf index = 11 Then
                    cat11(i, j) = Nothing
                ElseIf index = 12 Then
                    cat12(i, j) = Nothing
                ElseIf index = 13 Then
                    cat13(i, j) = Nothing
                ElseIf index = 14 Then
                    cat14(i, j) = Nothing
                ElseIf index = 15 Then
                    cat15(i, j) = Nothing
                ElseIf index = 16 Then
                    cat16(i, j) = Nothing
                ElseIf index = 17 Then
                    cat17(i, j) = Nothing
                ElseIf index = 18 Then
                    cat18(i, j) = Nothing
                ElseIf index = 19 Then
                    cat19(i, j) = Nothing
                ElseIf index = 20 Then
                    cat20(i, j) = Nothing
                ElseIf index = 21 Then
                    cat21(i, j) = Nothing
                ElseIf index = 22 Then
                    cat22(i, j) = Nothing
                ElseIf index = 23 Then
                    cat23(i, j) = Nothing
                ElseIf index = 24 Then
                    cat24(i, j) = Nothing
                ElseIf index = 25 Then
                    cat25(i, j) = Nothing
                ElseIf index = 26 Then
                    cat26(i, j) = Nothing
                ElseIf index = 27 Then
                    cat27(i, j) = Nothing
                ElseIf index = 28 Then
                    cat28(i, j) = Nothing
                ElseIf index = 29 Then
                    cat29(i, j) = Nothing
                End If
            Next
        Next
    End Sub
    Public Sub limpiar_categoria_thumb(ByVal index As Integer)
        For i = 0 To 200
            usuario_thumb(i) = Nothing
        Next
    End Sub
    Public Function obtener_precio_producto(ByVal id_producto As Integer, ByVal id_catalogo_precio As Integer) As Decimal
        Dim precio As Decimal = 0
        '========================PRECIO ESPECIAL==============================
        Dim precio_oferta As Double
        Dim oferta_inicio, oferta_termino As Date

        Dim rw As New ADODB.Recordset
        rw.Open("SELECT precio_especial,precio_especial_inicio,precio_especial_termino FROM producto WHERE id_producto='" & id_producto & "'", conn)
        If rw.RecordCount > 0 Then
            precio_oferta = rw.Fields("precio_especial").Value
            oferta_inicio = rw.Fields("precio_especial_inicio").Value
            oferta_termino = rw.Fields("precio_especial_termino").Value
        End If
        rw.Close()
        '========================================================================
        If precio_oferta > 0 Then
            If Date.Today >= CType(oferta_inicio, Date) And Date.Today <= CType(oferta_termino, Date) Then
                precio = precio_oferta
            Else
                GoTo A
            End If
        Else
A:          '=====================PRECIO DE VENTA============================
            Dim precio_venta As Decimal
            rw.Open("SELECT precio AS precio_venta FROM producto " & _
                    "WHERE id_producto = " & id_producto, conn)
            If rw.RecordCount > 0 Then
                precio_venta = rw.Fields("precio_venta").Value
            End If
            rw.Close()
            '-------------------------------------------
            If id_catalogo_precio = 0 Then
                precio = precio_venta
            Else
                rw.Open("SELECT precio FROM producto_precio " & _
                    "WHERE id_producto = '" & id_producto & "' AND id_ctlg_precios='" & id_catalogo_precio & "'", conn)
                If rw.RecordCount > 0 Then
                    precio = rw.Fields("precio").Value
                End If
                rw.Close()
            End If
        End If
        '----------------------------
        Return precio
    End Function
    Public Function validar_existencia_producto(ByVal id_producto As Integer, ByVal id_almacen As Integer, Optional ByVal close_conn As Integer = 0) As Decimal
        Dim cantidad As Decimal = 0
        If close_conn = 0 Then
            'Conectar()
        End If
        rs.Open("SELECT cantidad FROM producto_sucursal WHERE id_producto='" & id_producto & "' AND id_almacen=" & id_almacen, conn)
        If rs.RecordCount > 0 Then
            cantidad = rs.Fields("cantidad").Value
        End If
        rs.Close()
        If close_conn = 0 Then
            'conn.close()
            'conn = Nothing
        End If
        Return cantidad
    End Function
End Module
