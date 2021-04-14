Public Class frm_bitacora

    Private Sub frm_principal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            configuracion_listas()
            Conectar()
            cargar_bitacora()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error interno")
        End Try

    End Sub

    Private Sub configuracion_listas()
        With lst_mantenimientos
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Fecha Proceso", 120)
            .Columns.Add("Fecha Inicial (Venta)", 120)
            .Columns.Add("Fecha FInal (Venta)", 120)
            .Columns.Add("Total Cuentas", 120)
            .Columns.Add("Cuentas Modificadas", 120)
            .Columns.Add("Importe Anterior", 100)
            .Columns.Add("Importe Nuevo", 100)
            .Columns.Add("Diferencia", 80)
            .Columns.Add("Tipo de Eliminación", 150)
        End With

        For i = 0 To lst_mantenimientos.Items.Count - 2 Step 2
            lst_mantenimientos.Items(i + 1).BackColor = Color.Turquoise
            lst_mantenimientos.Items(i).BackColor = Color.White
        Next
    End Sub
    Public Sub cargar_bitacora()
        lst_mantenimientos.Items.Clear()
        Dim i As Integer = 0

        rs.Open("SELECT * FROM manto_bitacora", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(8) As String
                str(0) = rs.Fields("fecha_proceso").Value
                str(1) = rs.Fields("fecha_inicial").Value
                str(2) = rs.Fields("fecha_final").Value
                str(3) = rs.Fields("total_cuentas").Value
                str(4) = rs.Fields("total_cuentas_modificadas").Value
                str(5) = FormatCurrency(rs.Fields("importe_anterior").Value)
                str(6) = FormatCurrency(rs.Fields("importe_nuevo").Value)
                str(7) = FormatCurrency(rs.Fields("diferencia").Value)
                str(8) = rs.Fields("tipo_eliminacion").Value

                lst_mantenimientos.Items.Add(New ListViewItem(str, 0))
                lst_mantenimientos.Items(i).Tag = rs.Fields("id_manto_bitacora").Value
                rs.MoveNext()
                i = i + 1
            End While
        End If
        rs.Close()
    End Sub

    Public Sub Centrar(ByVal Objeto As Object)
        ' Centrar un Formulario ...  
        If TypeOf Objeto Is Form Then
            Dim frm As Form = CType(Objeto, Form)
            With Screen.PrimaryScreen.WorkingArea ' Dimensiones de la pantalla sin el TaskBar  
                frm.Top = (.Height - frm.Height) \ 2
                frm.Left = (.Width - frm.Width) \ 2
            End With

            ' Centrar un control dentro del contenedor  
        Else
            ' referencia al control  
            Dim c As Control = CType(Objeto, Control)

            'le  establece el top y el Left dentro del Parent  
            With c
                .Top = (.Parent.ClientSize.Height - c.Height) \ 2
                .Left = (.Parent.ClientSize.Width - c.Width) \ 2
            End With
        End If
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frm_eliminacion_masiva.Show()
    End Sub

    Private Sub btn_reimpresion_folios_Click(sender As System.Object, e As System.EventArgs) Handles btn_reimpresion_folios.Click
        Dim rw As New ADODB.Recordset

        rs.Open("SELECT id_venta FROM manto_venta WHERE id_bitacora='" & lst_mantenimientos.SelectedItems.Item(0).Tag & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF

                Dim fecha As Date
                Dim hora As DateTime
                Dim cadena_fecha As String = ""
                Dim cadena_hora As String = ""
                Dim subtotal As Decimal = 0
                Dim total_iva As Decimal = 0
                Dim total_otros As Decimal = 0
                Dim total As Decimal = 0
                Dim cliente As String = ""
                Dim cliente_alias As String = ""
                Dim empleado As String = ""
                Dim estatus As String = ""
                Dim id_venta As Integer = 0
                '---buscamos el ticket seleeccionado
                'Conectar()
                rw.Open("SELECT manto_venta.id_venta,manto_venta.fecha,manto_venta.num_ticket,manto_venta.subtotal,manto_venta.total_iva,manto_venta.total_otros,manto_venta.total,CASE WHEN cliente.id_persona = 0 THEN  empresa.razon_social ELSE CONCAT(persona.nombre,' ',persona.ap_paterno,' ',persona.ap_materno) END AS cliente,CASE WHEN cliente.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS cliente_alias,manto_venta.status,(SELECT CONCAT(p.nombre,' ',p.ap_paterno) FROM empleado ep, persona p, manto_venta v WHERE v.id_empleado=ep.id_empleado AND p.id_persona=ep.id_persona AND v.id_venta='" & rs.Fields("id_venta").Value & "') AS empleadopv  FROM cliente LEFT OUTER JOIN persona ON cliente.id_persona = persona.id_persona LEFT OUTER JOIN empresa ON cliente.id_empresa = empresa.id_empresa JOIN manto_venta ON manto_venta.id_cliente=cliente.id_cliente WHERE manto_venta.id_venta=" & rs.Fields("id_venta").Value, conn)
                If rw.RecordCount > 0 Then
                    fecha = rw.Fields("fecha").Value
                    hora = rw.Fields("fecha").Value
                    cadena_fecha = fecha.ToLongDateString
                    cadena_hora = hora.ToLongTimeString
                    subtotal = FormatCurrency(rw.Fields("subtotal").Value)
                    total_iva = FormatCurrency(rw.Fields("total_iva").Value)
                    total_otros = FormatCurrency(rw.Fields("total_otros").Value)
                    total = FormatCurrency(rw.Fields("total").Value)
                    cliente = rw.Fields("cliente").Value
                    cliente_alias = rw.Fields("cliente_alias").Value
                    empleado = rw.Fields("empleadopv").Value
                    estatus = rw.Fields("status").Value
                    id_venta = rw.Fields("id_venta").Value
                End If
                rw.Close()


                Dim forma_pago As String = ""
                Dim cobro As Decimal = 0
                Dim cambio As Decimal = 0

                rw.Open("SELECT id_manto_cobro,cobro,cambio,importe,id_forma_pago,fecha,fecha_cobro,status FROM manto_pagos_ventas WHERE id_venta='" & id_venta & "' ORDER by fecha_cobro", conn)

                If rw.RecordCount > 0 Then
                    While Not rw.EOF
                        forma_pago = nombre_forma_pago(rw.Fields("id_forma_pago").Value)
                        cobro = FormatCurrency(rw.Fields("cobro").Value)
                        cambio = FormatCurrency(rw.Fields("cambio").Value)
                        rw.MoveNext()
                    End While
                End If
                rw.Close()

                For k = 0 To conf_pv(5)
                    reimprimir_ticket_venta_manto(id_venta, cliente, cliente_alias, id_venta, subtotal, total_iva, total_otros, total, cobro, cambio, empleado, forma_pago, cadena_fecha, cadena_hora, k, conf_pv(5))
                Next

                rs.MoveNext()
            End While
        End If
        rs.Close()


       
    End Sub

    Private Sub btn_eliminar_manto_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar_manto.Click
        If MsgBox("Esta seguro que desea guardar eliminar este mantenimiento, esta operación no se puede deshacer", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Confirmación") = MsgBoxResult.Yes Then
            rs.Open("SELECT id_venta FROM manto_venta WHERE id_bitacora='" & lst_mantenimientos.SelectedItems.Item(0).Tag & "'", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    conn.Execute("DELETE FROM manto_venta_detalle WHERE id_venta='" & rs.Fields("id_venta").Value & "'")
                    conn.Execute("DELETE FROM manto_pagos_ventas WHERE id_venta='" & rs.Fields("id_venta").Value & "'")
                    rs.MoveNext()
                End While
            End If
            rs.Close()

            conn.Execute("DELETE FROM manto_venta WHERE id_bitacora='" & lst_mantenimientos.SelectedItems.Item(0).Tag & "'")
            conn.Execute("DELETE FROM manto_bitacora WHERE id_manto_bitacora='" & lst_mantenimientos.SelectedItems.Item(0).Tag & "'")

            Me.cargar_bitacora()
            MsgBox("Mantenimiento eliminado correctamente", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub
End Class
