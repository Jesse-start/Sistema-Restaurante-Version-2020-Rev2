Public Class frm_cambio_precio
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_cambio_precio As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Dim precio(25) As Decimal

    Public Sub estilo_cambio_precios(ByVal dgv_cambio_precio As DataGridView)
        tabla_cambio_precio = New DataTable("cambio_precio")

        With tabla_cambio_precio.Columns
            .Add(New DataColumn("seleccion", GetType(Boolean)))
            .Add(New DataColumn("id_temp_venta_detalle", GetType(Integer)))
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("nombre", GetType(String)))
            .Add(New DataColumn("tasa_impuestos", GetType(String)))
            .Add(New DataColumn("precio_actual", GetType(Decimal)))


            'obentemos la listra de precios 

            rs.Open("SELECT id_ctlg_precios FROM ctlg_precios ORDER BY id_ctlg_precios ASC", conn)
            If rs.RecordCount > 0 Then
                Dim i As Integer = 1
                While Not rs.EOF
                    .Add(New DataColumn("precio" & i, GetType(Decimal)))
                    i += 1
                    rs.MoveNext()
                End While
            End If
            rs.Close()
        End With
        ds = New DataSet
        ds.Tables.Add(tabla_cambio_precio)

        With dgv_cambio_precio
            .DataSource = ds
            .DataMember = "cambio_precio"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            With .Columns("seleccion")
                .HeaderText = "Selec"
                .Width = 30
                .Visible = True
                .Frozen = True
            End With

            With .Columns("id_producto")
                .Width = 0
                .Visible = False
                .Frozen = True
            End With
            With .Columns("id_temp_venta_detalle")
                .Width = 0
                .Visible = False
                .Frozen = True
            End With
            With .Columns("tasa_impuestos")
                .Width = 0
                .Visible = False
                .Frozen = True
            End With
            With .Columns("nombre")
                .HeaderText = "Nombre"
                .Width = 300
                .ReadOnly = False
                .Frozen = True
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            End With

            With .Columns("precio_actual")
                .HeaderText = "Precio Actual"
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Width = 60
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "c"
                .ReadOnly = True
            End With

        End With

        rs.Open("SELECT id_ctlg_precios,nombre FROM ctlg_precios ORDER BY id_ctlg_precios ASC", conn)
        If rs.RecordCount > 0 Then
            Dim i As Integer = 1
            While Not rs.EOF
                With dgv_cambio_precio
                    With .Columns("precio" & i)
                        .HeaderText = rs.Fields("nombre").Value
                        .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .DefaultCellStyle.Format = "c"
                        .ReadOnly = True
                    End With
                End With
                i += 1
                rs.MoveNext()
            End While
        End If

        rs.Close()
    End Sub
    Public Sub agregar_cambio_precio(ByVal id_temp_venta_detalle As Integer, ByVal seleccion As Boolean, ByVal id_producto As Integer, ByVal codigo As String, ByVal nombre As String, ByVal tasa_impuesto As Decimal, ByVal precio_actual As Decimal, Optional ByVal precio1 As Decimal = 0, Optional ByVal precio2 As Decimal = 0, Optional ByVal precio3 As Decimal = 0, Optional ByVal precio4 As Decimal = 0, Optional ByVal precio5 As Decimal = 0, Optional ByVal precio6 As Decimal = 0, Optional ByVal precio7 As Decimal = 0, Optional ByVal precio8 As Decimal = 0, Optional ByVal precio9 As Decimal = 0, Optional ByVal precio10 As Decimal = 0, Optional ByVal precio11 As Decimal = 0, Optional ByVal precio12 As Decimal = 0, Optional ByVal precio13 As Decimal = 0, Optional ByVal precio14 As Decimal = 0, Optional ByVal precio15 As Decimal = 0, Optional ByVal precio16 As Decimal = 0, Optional ByVal precio17 As Decimal = 0, Optional ByVal precio18 As Decimal = 0, Optional ByVal precio19 As Decimal = 0, Optional ByVal precio20 As Decimal = 0, Optional ByVal precio21 As Decimal = 0, Optional ByVal precio22 As Decimal = 0, Optional ByVal precio23 As Decimal = 0, Optional ByVal precio24 As Decimal = 0, Optional ByVal precio25 As Decimal = 0)
        tabla_linea = tabla_cambio_precio.NewRow()
        tabla_linea("id_temp_venta_detalle") = id_temp_venta_detalle
        tabla_linea("seleccion") = seleccion
        tabla_linea("id_producto") = id_producto
        tabla_linea("nombre") = nombre
        tabla_linea("tasa_impuestos") = tasa_impuesto
        tabla_linea("precio_actual") = precio_actual

        If precio1 > 0 Then
            tabla_linea("precio1") = precio1
        End If
        If precio2 > 0 Then
            tabla_linea("precio2") = precio2
        End If
        If precio3 > 0 Then
            tabla_linea("precio3") = precio3
        End If
        If precio4 > 0 Then
            tabla_linea("precio4") = precio4
        End If
        If precio5 > 0 Then
            tabla_linea("precio5") = precio5
        End If
        If precio6 > 0 Then
            tabla_linea("precio6") = precio6
        End If
        If precio7 > 0 Then
            tabla_linea("precio7") = precio7
        End If
        If precio8 > 0 Then
            tabla_linea("precio8") = precio8
        End If
        If precio9 > 0 Then
            tabla_linea("precio9") = precio9
        End If
        If precio10 > 0 Then
            tabla_linea("precio10") = precio10
        End If
        If precio11 > 0 Then
            tabla_linea("precio11") = precio11
        End If
        If precio12 > 0 Then
            tabla_linea("precio12") = precio12
        End If
        If precio13 > 0 Then
            tabla_linea("precio13") = precio13
        End If
        If precio14 > 0 Then
            tabla_linea("precio14") = precio14
        End If
        If precio15 > 0 Then
            tabla_linea("precio15") = precio15
        End If
        If precio16 > 0 Then
            tabla_linea("precio16") = precio16
        End If
        If precio17 > 0 Then
            tabla_linea("precio17") = precio17
        End If
        If precio18 > 0 Then
            tabla_linea("precio18") = precio18
        End If
        If precio19 > 0 Then
            tabla_linea("precio19") = precio19
        End If
        If precio20 > 0 Then
            tabla_linea("precio20") = precio20
        End If
        If precio21 > 0 Then
            tabla_linea("precio21") = precio21
        End If
        If precio22 > 0 Then
            tabla_linea("precio22") = precio22
        End If
        If precio23 > 0 Then
            tabla_linea("precio23") = precio23
        End If
        If precio24 > 0 Then
            tabla_linea("precio24") = precio24
        End If
        If precio25 > 0 Then
            tabla_linea("precio25") = precio25
        End If
        tabla_cambio_precio.Rows.Add(tabla_linea)
    End Sub

    Private Sub frm_cambio_precio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rellenar_catalogo_combobox("id_ctlg_precios", "nombre", "ctlg_precios", cb_precio)
        estilo_cambio_precios(dgv_cambio_precio)
        cargar(global_id_empleado)

    End Sub


    Private Sub cargar(ByVal id_empleado As Integer)
        tabla_cambio_precio.Clear()
        rs.Open("SELECT id_temp_venta_detalle, id_producto, nombre,precio,tasa_impuestos FROM temp_venta_detalle WHERE id_empleado='" & id_empleado & "'", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cargar_precios_productos(rs.Fields("id_producto").Value)
                Dim precio_actual As Decimal = rs.Fields("precio").Value * (1 + rs.Fields("tasa_impuestos").Value)
                agregar_cambio_precio(rs.Fields("id_temp_venta_detalle").Value, False, rs.Fields("id_producto").Value, "0", rs.Fields("nombre").Value, rs.Fields("tasa_impuestos").Value, precio_actual, precio(1), precio(2), precio(3), precio(4), precio(5), precio(6), precio(7), precio(8), precio(9), precio(10), precio(11), precio(12), precio(13), precio(14), precio(15), precio(16), precio(17), precio(18), precio(19), precio(20), precio(21), precio(22), precio(23), precio(24), precio(25))
                rs.MoveNext()
            End While
        End If
        rs.Close()
    End Sub
    Private Sub rellenar_catalogo_combobox(ByVal id As String, ByVal valor As String, ByVal tabla_db As String, ByVal combobox As ComboBox, Optional ByVal opcion_general As Boolean = False, Optional ByVal condicion As String = "", Optional ByVal cadena_concatenar As String = "")
        Try
            Dim recordset As New ADODB.Recordset
            combobox.Items.Clear()
            If opcion_general = True Then
                combobox.Items.Add(New myItem("0", "Todos"))
            End If

            If cadena_concatenar = "" Then
                recordset.Open("SELECT " & id & "," & valor & " FROM " & tabla_db & condicion & "", conn)
            Else
                recordset.Open("SELECT " & id & "," & cadena_concatenar & " FROM " & tabla_db & condicion & "", conn)
            End If

            If recordset.RecordCount > 0 Then
                While Not recordset.EOF
                    combobox.Items.Add(New myItem(recordset.Fields(id).Value, recordset.Fields(valor).Value))
                    recordset.MoveNext()
                End While
            End If
            recordset.Close()

            If combobox.Items.Count > 0 Then
                combobox.SelectedIndex = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cargar_precios_productos(ByVal id_producto As Integer)
        'id_catalogo_precio(15)
        'precio(15)
        limpiar_variables()
        Dim rx As New ADODB.Recordset
        rx.Open("SELECT id_producto_precio,precio FROM producto_precio WHERE id_producto='" & id_producto & "' ORDER BY id_ctlg_precios ASC", conn)
        If rx.RecordCount > 0 Then
            Dim i As Integer = 1
            While Not rx.EOF
                precio(i) = rx.Fields("precio").Value
                i += 1
                rx.MoveNext()
            End While
        End If
        rx.Close()
    End Sub
    Private Sub limpiar_variables()
        For x = 0 To 25
            precio(x) = 0
        Next
    End Sub

    Private Sub btn_aplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aplicar_precios.Click
        If MsgBox("¿Esta seguro que desea aplicar el precio a los productos seleccionados?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            frm_validaciones.tipo_validacion = 3
            frm_validaciones.ShowDialog()
        End If
    End Sub

    Private Sub dgv_cambio_precio_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_cambio_precio.CellValueChanged
        For x = 0 To tabla_cambio_precio.Rows.Count - 1
            If dgv_cambio_precio.Rows(x).Cells("seleccion").Value = True Then
                btn_aplicar_precios.Enabled = True
            End If
        Next
    End Sub
    Public Sub guardar_cambio_precios()
        Dim nuevo_precio As Decimal = 0
        Dim cantidad As Decimal = 0
        Dim importe As Decimal = 0
        Dim total_impuestos As Decimal = 0

        For x = 0 To tabla_cambio_precio.Rows.Count - 1
            If dgv_cambio_precio.Rows(x).Cells("seleccion").Value = True Then
                nuevo_precio = obtener_precio_producto(dgv_cambio_precio.Rows(x).Cells("id_producto").Value, CType(cb_precio.SelectedItem, myItem).Value) / (1 + dgv_cambio_precio.Rows(x).Cells("tasa_impuestos").Value)
                rs.Open("SELECT cantidad FROM temp_venta_detalle WHERE id_temp_venta_detalle='" & dgv_cambio_precio.Rows(x).Cells("id_temp_venta_detalle").Value & "'", conn)
                If rs.RecordCount > 0 Then
                    cantidad = rs.Fields("cantidad").Value
                End If
                rs.Close()
                importe = FormatNumber(nuevo_precio * cantidad, 2)
                total_impuestos = importe * dgv_cambio_precio.Rows(x).Cells("tasa_impuestos").Value
                conn.Execute("UPDATE temp_venta_detalle SET precio='" & nuevo_precio & "', importe='" & importe & "',total_impuestos='" & total_impuestos & "' WHERE id_temp_venta_detalle='" & dgv_cambio_precio.Rows(x).Cells("id_temp_venta_detalle").Value & "' ")
            End If
        Next
        MsgBox("Cambio de precios guardado correctamente", MsgBoxStyle.Information, "Aviso")
        frm_principal3.cargar_usuario_actual()
        Me.Close()
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub
End Class