Public Class frm_nuevo_inventario_fisico
    Dim id_almacen As String
    Dim fecha As Date
    Dim hora As DateTime
    Dim cargado As Boolean = False

    Private Sub btn_cancelar_Click(sender As System.Object, e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub
    Private Sub frm_nuevo_inventario_fisico_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargado = False
        dtp_fecha.Value = Today
        dtp_hora.Value = Now
        rellenar_catalogo_combobox("id_almacen", "nombre", "almacenes", cb_almacen)
        configuracion_listas()
        cargado = True
        cargar_grupos(CType(cb_almacen.SelectedItem, myItem).Value)
    End Sub
    Private Sub configuracion_listas()
        With lst_grupo_insumos
            .CheckBoxes = True
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Folio", 50)
            .Columns.Add("nombre", 200)
        End With
    End Sub
    Private Sub rellenar_catalogo_combobox(id As String, valor As String, tabla_db As String, combobox As ComboBox, Optional opcion_general As Boolean = False)
        Dim recordset As New ADODB.Recordset
        combobox.Items.Clear()
        If opcion_general = True Then
            combobox.Items.Add(New myItem("0", "Todos"))
        End If

        recordset.Open("SELECT " & id & "," & valor & " FROM " & tabla_db & "", conn)
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
    End Sub
    Private Sub cargar_grupos(id_almacen As Integer)
        lst_grupo_insumos.Items.Clear()
        Dim id_tipo_almacen As Integer = 0

        rs.Open("SELECT id_almacen_tipo FROM almacenes WHERE id_almacen='" & id_almacen & "'", conn)
        If rs.RecordCount > 0 Then
            id_tipo_almacen = rs.Fields("id_almacen_tipo").Value
        End If
        rs.Close()


        If id_tipo_almacen = 1 Then ' PRODUCTOS
            Dim i As Integer = 0
            rs.Open("SELECT id_categoria,nombre FROM categoria", conn)
            If rs.RecordCount > 0 Then
                While Not rs.EOF
                    Dim str(1) As String
                    str(0) = rs.Fields("id_categoria").Value
                    str(1) = rs.Fields("nombre").Value

                    lst_grupo_insumos.Items.Add(New ListViewItem(str, 0))
                    lst_grupo_insumos.Items(i).Tag = rs.Fields("id_categoria").Value
                    rs.MoveNext()
                    i = i + 1

                End While
            End If
            rs.Close()

        ElseIf id_tipo_almacen = 2 Or 3 Then ' INSUMOS


        End If

        For i = 0 To lst_grupo_insumos.Items.Count - 2 Step 2
            lst_grupo_insumos.Items(i + 1).BackColor = Color.DarkGray
            lst_grupo_insumos.Items(i).BackColor = Color.White
        Next

    End Sub
    Private Sub cb_almacen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_almacen.SelectedIndexChanged
        If cargado = True Then
            cargar_grupos(CType(cb_almacen.SelectedItem, myItem).Value)
        End If
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        For count = 0 To lst_grupo_insumos.Items.Count - 1
            If lst_grupo_insumos.Items(count).Checked = True Then
                lst_grupo_insumos.Items(count).Checked = False
            Else
                lst_grupo_insumos.Items(count).Checked = True
            End If
        Next
    End Sub

    Private Sub btn_aceptar_Click(sender As System.Object, e As System.EventArgs) Handles btn_aceptar.Click

        Dim fecha_hora As String = Format(dtp_fecha.Value, "yyyy-MM-dd") & " " & Format(dtp_hora.Value, "HH:mm:ss")
        conn.Execute("INSERT INTO inventario_fisico (fecha_hora,id_almacen,id_empleado) VALUES('" & fecha_hora & "'," & CType(cb_almacen.SelectedItem, myItem).Value & ", " & global_id_empleado & ")")
        Dim id_inventario_fisico As Integer
        rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        id_inventario_fisico = rs.Fields(0).Value
        rs.Close()
        Me.Close()
        For count = 0 To lst_grupo_insumos.Items.Count - 1
            If lst_grupo_insumos.Items(count).Checked = True Then
                frm_inventario_fisico.agregar_categoria_inventario(lst_grupo_insumos.Items(count).Tag(), CType(cb_almacen.SelectedItem, myItem).Value, id_inventario_fisico)
            End If
        Next
    End Sub



End Class