Public Class frm_precios_clientes

    Private Sub frm_precios_clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        estilo_catalogo_cliente(dgv_cliente_catalogo)
        estilo_precios_clientes(dgv_precio_cliente_catalogo)
        cargar()
    End Sub
    Private Sub cargar()
        cargar_precios()
    End Sub
    Private Sub cargar_precios()
        cb_precios.Items.Clear()
        cb_precios.Text = ""

        cb_precios.Items.Add(New myItem("0", "PUBLICO"))

        rs.Open("SELECT id_catalogo_precio, nombre FROM catalogo_precios", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_precios.Items.Add(New myItem(rs.Fields("id_catalogo_precio").Value, rs.Fields("nombre").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()

    End Sub
    Private Sub cargar_clientes(ByVal id_catalogo_precio As Integer)
        tabla_catalogo_cliente.Clear()
        rs.Open("SELECT cliente.id_cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS nombre " & _
                "FROM cliente " & _
                "LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona " & _
                "LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa " & _
                   "JOIN cliente_precio ON cliente_precio.id_cliente = cliente.id_cliente " & _
                "WHERE cliente.id_cliente<>1 AND cliente_precio.id_catalogo_precio='" & id_catalogo_precio & "' ORDER by cliente.id_cliente", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                agregar_catalogo_cliente(rs.Fields("id_cliente").Value, rs.Fields("nombre").Value)
                rs.MoveNext()
            End While
        End If
        rs.Close()

    End Sub
    Private Sub cargar_precios(ByVal id_catalogo_precio As Integer)
        tabla_precios_cliente.Clear()
        rs.Open("SELECT p.id_producto,pv.id_descuento,pv.descuento,p.nombre,p.costo,pp.precio " & _
                "FROM producto_volumen pv " & _
                "JOIN producto p ON p.id_producto=pv.id_producto " & _
                "JOIN producto_precio pp ON pp.id_producto=pv.id_producto " & _
                "WHERE id_catalogo_precio='" & id_catalogo_precio & "' AND descuento<>0", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim precio As Decimal = FormatNumber((rs.Fields("precio").Value - (rs.Fields("costo").Value * (rs.Fields("descuento").Value / 100))), 2)
                agregar_precios_cliente(rs.Fields("id_producto").Value, rs.Fields("nombre").Value, precio)
                rs.MoveNext()
            End While
        End If
        rs.Close()

    End Sub

    Private Sub cb_precios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_precios.SelectedIndexChanged
        If cb_precios.SelectedIndex <> -1 Then
            cargar_clientes(CType(cb_precios.SelectedItem, myItem).Value)
            cargar_precios(CType(cb_precios.SelectedItem, myItem).Value)
        End If
    End Sub
End Class