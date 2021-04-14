﻿Public Class frm_presentaciones
    Public id_insumo As Integer = 0
    Private id_presentacion As Integer = 0
    Public precarga As Boolean = False
    Private cargado As Boolean = False


    Private Sub frm_presentaciones_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        global_frm_presentaciones = 0
    End Sub
    Public Sub cargar()
        Try
            configuracion_inicio()
            rellenar_catalogo_combobox("id_insumo_grupo", "grupo", "rest_insumo_grupo", cb_grupo)
            rellenar_catalogo_combobox("id_insumo_grupo", "grupo", "rest_insumo_grupo", cb_grupo_busqueda, True)
            rellenar_catalogo_combobox("id_unidad", "nombre", "unidad", cb_unidad_medida)
            rellenar_catalogo_combobox("id_impuesto", "alias", "impuesto", cb_impuesto)
            configuracion_listas()
            cargar_proveedores()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        End Try
    End Sub
    Public Sub precargar_insumo(id_insumo As Integer, nombre_insumo As String, unidad As String)
        precarga = True
        cargar_presentacion(0)
        tb_descripcion.Text = nombre_insumo
        cargar_insumo(id_insumo, nombre_insumo, unidad)
    End Sub
    Private Sub frm_presentaciones_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        global_frm_presentaciones = 1
    End Sub
    Public Sub cargar_proveedores()
        cb_proveedor.Items.Clear()
        rs.Open("SELECT id_proveedor, CASE WHEN proveedor.id_persona = 0 THEN  empresa.alias ELSE persona.alias END AS proveedor " & _
                      "FROM proveedor " & _
                      "LEFT OUTER JOIN persona ON proveedor.id_persona = persona.id_persona " & _
                      "LEFT OUTER JOIN empresa ON proveedor.id_empresa = empresa.id_empresa", conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                cb_proveedor.Items.Add(New myItem(rs.Fields("id_proveedor").Value, rs.Fields("proveedor").Value))
                rs.MoveNext()
            End While
        End If
        rs.Close()
        If cb_proveedor.Items.Count > 0 Then
            cb_proveedor.SelectedIndex = 0
        End If

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

    Private Sub configuracion_inicio()
        btn_nuevo.Enabled = True
        btn_guardar.Enabled = False
        btn_deshacer.Enabled = False
        btn_editar.Enabled = False
        btn_buscar.Enabled = True
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_insumo.Enabled = False

        tb_clave.Text = ""
        tb_descripcion.Text = ""
        tb_costo_impuesto.Text = "0"
        tb_costo_promedio.Text = "0"
        tb_ultimo_costo.Text = "0"
        id_insumo = 0
        tb_costo_estandar.Text = "0"
        tb_rendimiento.Text = "0"
        tb_insumo_base.Text = ""
        tb_stock_maximo.Text = "1"
        tb_stock_minimo.Text = "1"
    End Sub
    Private Sub configuracion_nuevo()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_insumo.Enabled = True

        tb_clave.Text = ""
        tb_descripcion.Text = ""
        tb_costo_impuesto.Text = "0"
        tb_costo_promedio.Text = "0"
        tb_ultimo_costo.Text = "0"
        id_insumo = 0
        tb_costo_estandar.Text = "0"
        tb_rendimiento.Text = "0"
        tb_insumo_base.Text = ""
        tb_stock_maximo.Text = "1"
        tb_stock_minimo.Text = "1"

    End Sub

    Private Sub configuracion_editar()
        btn_nuevo.Enabled = False
        btn_guardar.Enabled = True
        btn_deshacer.Enabled = True
        btn_editar.Enabled = False
        btn_buscar.Enabled = False
        btn_eliminar.Enabled = False
        btn_salir.Enabled = True
        gb_insumo.Enabled = True
    End Sub
    Private Sub configuracion_listas()
        With lst_presentaciones
            .FullRowSelect = True
            .Columns.Clear()
            .Columns.Add("Clave", 50)
            .Columns.Add("Descripción", 180)
            .Columns.Add("Costo", 70)
            .Columns.Add("Unidad", 70)
        End With

        For i = 0 To lst_presentaciones.Items.Count - 2 Step 2
            lst_presentaciones.Items(i + 1).BackColor = Color.Turquoise
            lst_presentaciones.Items(i).BackColor = Color.White
        Next

    End Sub

    Private Sub btn_nuevo_Click(sender As System.Object, e As System.EventArgs) Handles btn_nuevo.Click
        cargar_presentacion(0)
    End Sub


    Private Sub guardar_presentacion(id_presentacion As Integer)

        Dim correcto As Boolean = True
        Dim mensaje As String = "Se encontraron los siguientes errores " & vbCrLf

        If Trim(tb_descripcion.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Falta descripción de la presentacion " & vbCrLf
        End If
        If cb_grupo.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un grupo de presentaciones " & vbCrLf
        End If
        If cb_unidad_medida.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione una unidad de medida " & vbCrLf
        End If

        If cb_impuesto.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un impuesto " & vbCrLf
        End If

        If cb_proveedor.SelectedIndex = -1 Then
            correcto = False
            mensaje &= "    Seleccione un proveedor " & vbCrLf
        End If

        If id_insumo = 0 Then
            correcto = False
            mensaje &= "    Seleccione un insumo base " & vbCrLf
        End If

        If Trim(tb_rendimiento.TextLength) = 0 Then
            correcto = False
            mensaje &= "    Introduzca el rendimiento de la presentación" & vbCrLf
        End If
        If correcto = True Then
            Dim id_insumo_grupo As Integer = 0
            Dim id_unidad_medida As Integer = 0
            Dim id_impuesto As Integer = 0
            Dim id_proveedor As Integer = 0

            id_insumo_grupo = CType(cb_grupo.SelectedItem, myItem).Value
            id_unidad_medida = CType(cb_unidad_medida.SelectedItem, myItem).Value
            id_impuesto = CType(cb_impuesto.SelectedItem, myItem).Value
            id_proveedor = CType(cb_proveedor.SelectedItem, myItem).Value

            If id_presentacion > 0 Then
                conn.Execute("UPDATE rest_presentacion SET id_insumo_grupo='" & id_insumo_grupo & "',clave='" & tb_clave.Text & "',descripcion='" & tb_descripcion.Text & "',id_unidad='" & id_unidad_medida & "',ultimo_costo='" & tb_ultimo_costo.Text & "',costo_promedio='" & tb_costo_promedio.Text & "',costo_estandar='" & tb_costo_estandar.Text & "', id_impuesto='" & id_impuesto & "',costo_cimpuestos='" & tb_costo_impuesto.Text & "',id_proveedor='" & id_proveedor & "',id_insumo='" & id_insumo & "',rendimiento='" & tb_rendimiento.Text & "',stock_minimo='" & tb_stock_minimo.Text & "',stock_maximo='" & tb_stock_maximo.Text & "' WHERE id_presentacion='" & id_presentacion & "'")

            Else
                conn.Execute("INSERT INTO rest_presentacion(id_insumo_grupo,clave,descripcion,id_unidad,ultimo_costo,costo_promedio,costo_estandar, id_impuesto,costo_cimpuestos,id_proveedor,id_insumo,rendimiento,stock_minimo,stock_maximo)VALUES('" & id_insumo_grupo & "','" & tb_clave.Text & "','" & tb_descripcion.Text & "','" & id_unidad_medida & "','" & tb_ultimo_costo.Text & "','" & tb_costo_promedio.Text & "','" & tb_costo_estandar.Text & "','" & id_impuesto & "','" & tb_costo_impuesto.Text & "','" & id_proveedor & "','" & id_insumo & "','" & tb_rendimiento.Text & "','" & tb_stock_minimo.Text & "','" & tb_stock_maximo.Text & "')")

                rs.Open("SELECT last_insert_id() ", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                id_presentacion = rs.Fields(0).Value
                rs.Close()


            End If

            cargar_grupo_presentacion(CType(cb_grupo_busqueda.SelectedItem, myItem).Value)
            cargar_presentacion(id_presentacion)
        Else
            MsgBox(mensaje, MsgBoxStyle.Critical, "Aviso")
        End If




    End Sub

    Private Sub btn_guardar_Click(sender As System.Object, e As System.EventArgs) Handles btn_guardar.Click
        guardar_presentacion(id_presentacion)
        If precarga = True Then
            If global_frm_insumos = 1 Then
                frm_insumos.cargar_presentaciones(id_insumo)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btn_deshacer_Click(sender As System.Object, e As System.EventArgs) Handles btn_deshacer.Click
        configuracion_inicio()
    End Sub

    Private Sub btn_salir_Click(sender As System.Object, e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Function propuesta_codigo(ByVal id_grupo As Integer) As String
        tb_clave.Text = ""
        Dim codigo As String = ""
        Dim rw As New ADODB.Recordset
        Dim clave_grupo As String = ""


        rw.Open("SELECT clave FROM rest_insumo_grupo WHERE id_insumo_grupo='" & id_grupo & "'", conn)
        If rw.RecordCount > 0 Then
            clave_grupo = rw.Fields("clave").Value
        End If
        rw.Close()


        rw.Open("SELECT CASE WHEN ISNULL(MAX(clave)) THEN 0 ELSE (MAX(clave)+1) END AS propuesta FROM rest_presentacion WHERE id_insumo_grupo='" & id_grupo & "'", conn)
        If rw.RecordCount > 0 Then
            codigo = rw.Fields("propuesta").Value
        End If
        rw.Close()

        If codigo = "0" Then
            codigo = CDbl(clave_grupo) + 1
        End If

        Return codigo
    End Function

    Private Sub cb_grupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_grupo.SelectedIndexChanged
        If cargado = True Then
            If cb_grupo.SelectedIndex <> -1 Then
                tb_clave.Text = propuesta_codigo(CType(cb_grupo.SelectedItem, myItem).Value)
            End If
        End If

    End Sub

    Private Sub cb_grupo_busqueda_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cb_grupo_busqueda.SelectedIndexChanged
        cargar_grupo_presentacion(CType(cb_grupo_busqueda.SelectedItem, myItem).Value)
        If cb_grupo_busqueda.SelectedIndex > 0 Then
            seleccionar_catalogo(CType(cb_grupo_busqueda.SelectedItem, myItem).Value, cb_grupo)
        End If
    End Sub

    Private Sub seleccionar_catalogo(ByVal id_catalogo As Integer, ByVal cb As ComboBox)
        '-----buscamos el tipo servicio_tecnico
        For x = 0 To cb.Items.Count - 1
            If id_catalogo = CType(cb.Items(x), myItem).Value Then
                cb.SelectedIndex = x
                Exit For
            End If
        Next
    End Sub
    Private Sub cargar_grupo_presentacion(id_grupo As Integer)
        Dim filtro As String = ""
        Dim i As Integer = 0

        lst_presentaciones.Items.Clear()
        If id_grupo > 0 Then
            filtro = "WHERE id_insumo_grupo='" & id_grupo & "'"
        End If

        rs.Open("SELECT rp.id_presentacion, rp.clave, rp.descripcion,u.nombre AS unidad,rp.ultimo_costo " & _
                "FROM rest_presentacion rp " & _
                "JOIN unidad u ON u.id_unidad=rp.id_unidad " & filtro, conn)
        If rs.RecordCount > 0 Then
            While Not rs.EOF
                Dim str(3) As String
                str(0) = rs.Fields("clave").Value
                str(1) = rs.Fields("descripcion").Value
                str(2) = FormatCurrency(rs.Fields("ultimo_costo").Value, 2)
                str(3) = rs.Fields("unidad").Value

                lst_presentaciones.Items.Add(New ListViewItem(str, 0))
                lst_presentaciones.Items(i).Tag = rs.Fields("id_presentacion").Value
                rs.MoveNext()
                i = i + 1

            End While
        End If
        rs.Close()

        aplicar_estilo_insumo()

    End Sub
    Private Sub aplicar_estilo_insumo()

        For i = 0 To lst_presentaciones.Items.Count - 2 Step 2
            lst_presentaciones.Items(i + 1).BackColor = Color.Turquoise
            lst_presentaciones.Items(i).BackColor = Color.White
        Next


    End Sub
    Private Sub cargar_presentacion(id As Integer)
        cargado = False
        id_presentacion = id


        If id_presentacion > 0 Then
            '=======================CARGAMOS INSUMO===========================
            rs.Open("SELECT rp.id_insumo_grupo,rp.clave,rp.descripcion,rp.id_unidad,u.nombre AS unidad_insumo,rp.ultimo_costo,rp.costo_promedio,rp.id_impuesto,rp.costo_cimpuestos,rp.costo_estandar,rp.id_proveedor,rp.id_insumo,ri.descripcion AS insumo,rp.rendimiento,rp.stock_minimo,rp.stock_maximo " & _
                    "FROM rest_presentacion rp " & _
              "JOIN rest_insumo ri ON rp.id_insumo=ri.id_insumo " & _
              "jOIN unidad u ON ri.id_unidad=u.id_unidad " & _
                    "WHERE rp.id_presentacion='" & id_presentacion & "'", conn)
            If rs.RecordCount > 0 Then
                tb_clave.Text = rs.Fields("clave").Value
                tb_descripcion.Text = rs.Fields("descripcion").Value
                seleccionar_catalogo(rs.Fields("id_unidad").Value, cb_unidad_medida)
                tb_ultimo_costo.Text = rs.Fields("ultimo_costo").Value
                tb_costo_promedio.Text = rs.Fields("costo_promedio").Value
                seleccionar_catalogo(rs.Fields("id_impuesto").Value, cb_impuesto)
                tb_costo_impuesto.Text = rs.Fields("costo_cimpuestos").Value
                tb_costo_estandar.Text = rs.Fields("costo_estandar").Value
                seleccionar_catalogo(rs.Fields("id_impuesto").Value, cb_impuesto)
                seleccionar_catalogo(rs.Fields("id_proveedor").Value, cb_proveedor)
                tb_insumo_base.Text = rs.Fields("id_insumo").Value
                cargar_insumo(rs.Fields("id_insumo").Value, rs.Fields("insumo").Value, rs.Fields("unidad_insumo").Value)
                tb_rendimiento.Text = rs.Fields("rendimiento").Value

            End If
            rs.Close()

            btn_guardar.Enabled = False
            btn_nuevo.Enabled = True
            btn_deshacer.Enabled = False
            btn_editar.Enabled = True
            btn_eliminar.Enabled = True
        Else
            '=============================INSUMO NUEVO===================================
            configuracion_nuevo()
            If cb_grupo.SelectedIndex <> -1 Then
                tb_clave.Text = propuesta_codigo(CType(cb_grupo.SelectedItem, myItem).Value)
            End If
        End If
        cargado = True
    End Sub
    Private Sub lst_insumos_DoubleClick(sender As Object, e As System.EventArgs) Handles lst_presentaciones.DoubleClick
        If lst_presentaciones.SelectedItems.Count > 0 Then
            cargar_presentacion(lst_presentaciones.SelectedItems.Item(0).Tag)
        End If
    End Sub


    Private Sub btn_eliminar_Click(sender As System.Object, e As System.EventArgs) Handles btn_eliminar.Click
        eliminar_presentacion(id_presentacion)
    End Sub
    Private Sub eliminar_presentacion(id As Integer)
        Try
            If MsgBox("Desea borrar esta presentacion?, se eliminaran del inventario!", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
                conn.Execute("DELETE FROM rest_presentacion WHERE id_presentacion='" & id & "'")
                cargar_grupo_presentacion(CType(cb_grupo_busqueda.SelectedItem, myItem).Value)
                configuracion_inicio()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Interno")
        End Try

    End Sub

    Private Sub btn_editar_Click(sender As System.Object, e As System.EventArgs) Handles btn_editar.Click
        configuracion_editar()
    End Sub
    Private Sub btn_buscar_insumo_Click(sender As System.Object, e As System.EventArgs) Handles btn_buscar_insumo.Click
        frm_busqueda_insumo.ShowDialog()
    End Sub
    Public Sub cargar_insumo(id As Integer, insumo As String,unidad As string)
        id_insumo = id
        tb_insumo_base.Text = insumo
        tb_unidad_rendimiento.Text = unidad
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        frm_directorio.Show()
    End Sub
    Private Sub tb_ultimo_costo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tb_ultimo_costo.KeyPress
        e.Handled = txtNumerico(tb_ultimo_costo, e.KeyChar, True)
    End Sub
    Private Sub tb_costo_promedio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tb_costo_promedio.KeyPress
        e.Handled = txtNumerico(tb_costo_promedio, e.KeyChar, True)
    End Sub
    Private Sub tb_costo_estandar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tb_costo_estandar.KeyPress
        e.Handled = txtNumerico(tb_costo_estandar, e.KeyChar, True)
    End Sub
    Private Sub tb_costo_impuesto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tb_costo_impuesto.KeyPress
        e.Handled = txtNumerico(tb_costo_impuesto, e.KeyChar, True)
    End Sub
    Private Function calcular_costo(costo_impuesto As Decimal, id_impuesto As Integer) As Decimal
        Try
            Dim costo As Decimal = 0
            Dim porcentaje As Decimal = 0

            Dim rw As New ADODB.Recordset
            rw.Open("SELECT porcentaje FROM impuesto WHERE id_impuesto='" & id_impuesto & "'", conn)
            If rw.RecordCount > 0 Then
                porcentaje = rw.Fields("porcentaje").Value
            End If
            rw.Close()

            costo = FormatNumber(costo_impuesto / (1 + (porcentaje / 100)), 2)
            Return costo
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error interno")
        End Try
       

    End Function

    Private Sub tb_costo_impuesto_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tb_costo_impuesto.KeyUp
        If Trim(tb_costo_impuesto.Text) = "" Then
            tb_ultimo_costo.Text = "0.00"
        Else
            Dim costo As Decimal = calcular_costo(tb_costo_impuesto.Text, CType(cb_impuesto.SelectedItem, myItem).Value)
            tb_ultimo_costo.Text = costo
        End If
    End Sub

    Private Sub btn_buscar_Click(sender As System.Object, e As System.EventArgs) Handles btn_buscar.Click

    End Sub
End Class