Public Class frm_clasificar
    Dim TRConceptos As Integer = 0      ' Nº DE FILAS EN CONCEPTOS 
    Dim TRNoClasificados As Integer = 0   'Nº DE FILAS EN NO CLASIFICADOS
    '--variuables treetview----
    Private idNodo As Integer = 0
    Private nodo, nodo_anterior As TreeViewEventArgs
    '---------------------------
    '---- variables estilos de tablas-
    Dim ds As DataSet

    Dim dt As DataTable
    Dim TablaEventos As DataTable

    Dim Linea As DataRow
    Dim sColumna As DataGridTextBoxColumn

    Dim styleConceptos, styleNoClasif As DataGridTableStyle

    '-----------------------
    '---NOMBRE DE LAS TABLAS---
    Dim TblConceptos As New String("TblConceptos")
    Dim TblNoClasif As New String("TblNoClasif")
    '--------------------------
    Private Sub frmClasificar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frm_principal
        Styles() ' CARGAMOS LOS ESTILOS DE LA TABLAS ANTES DE MOSTRAR LA TABLA
        Me.DgNoClasificados.DataSource = ObtNoClasif(TblNoClasif, tb_busqueda.Text)
        Me.DgConceptos.DataSource = ObtConceptos(TblConceptos, idNodo, tb_busqueda.Text)
        BtnAgregar.Enabled = False
        BtnQuitar.Enabled = False
        '--cargamos el arbol de cuentas-----
        arbolCategorias.Nodes.Add(0, "Categorias")
        'Conectar()
        Categoria(0, arbolCategorias.Nodes(0).Nodes)
        'conn.close()
        'conn = Nothing
        arbolCategorias.Nodes(0).Expand()
        '--------------------------------------
    End Sub
    Private Sub UpdateArbol()
        arbolCategorias.Nodes.Clear()
        arbolCategorias.Nodes.Add(0, "Cuentas")
        'Conectar()
        Categoria(0, arbolCategorias.Nodes(0).Nodes)
        'conn.close()
        'conn = Nothing
        arbolCategorias.Focus()
        arbolCategorias.SelectedNode.ExpandAll()
    End Sub
    Public Sub Categoria(ByVal nivel As Integer, ByVal Nodo As TreeNodeCollection)
        Dim i As Integer
        Dim rs = New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.Open("SELECT * from categoria where super ='" & nivel & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        i = 0
        While Not rs.EOF
            Nodo.Add(rs.Fields("id_categoria").Value, rs.Fields("nombre").Value)
            Nodo(i).Tag = rs.Fields("id_categoria").Value
            Categoria(rs.Fields("id_categoria").Value, Nodo(i).Nodes)
            rs.MoveNext()
            i = i + 1
        End While
        rs.Close()
    End Sub
    Private Sub arbolCategorias_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles arbolCategorias.AfterSelect

        'arbolCategorias.Nodes(1).ForeColor = Color.Black
        nodo = e
        idNodo = e.Node.Tag
        'LastIDnode = e.Node.Text
        nodo = e
        '==== Cambiamos de color el nodo seleccionado===============
        If Not nodo_anterior Is Nothing Then
            nodo_anterior.Node.BackColor = Color.White
            nodo_anterior.Node.ForeColor = Color.Black
        End If
        e.Node.BackColor = Color.Black
        e.Node.ForeColor = Color.White
        nodo_anterior = e
        '===========================================================
        'If tb_cuenta.Text = "Cuentas" Then
        'GroupBox1.Enabled = False
        'Else

        'GroupBox1.Enabled = True
        'Button4.Enabled = True
        '---obtenemos el codigo de la cuenta seleccionada------
        ''Conectar()
        'Dim rs = New ADODB.Recordset
        'rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rs.Open("SELECT cuenta FROM cuentas WHERE id_cuenta ='" & idNodo & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
        'CCuenta = rs.Fields("cuenta").Value
        'tb_vcuenta.Text = rs.Fields("cuenta").Value
        'rs.Close()
        ''conn.close()
        '-----------------------------------------------------
        'End If
        'Button5.Enabled = False
        'MsgBox(idNodo)
        DgConceptos.CaptionText = UCase(e.Node.Text)
        Me.DgConceptos.DataSource = ObtConceptos(TblConceptos, idNodo, tb_busqueda.Text)
    End Sub
    Private Sub Styles()

        '---ESTILO TABLA CONCEPTOS----------------
        styleConceptos = New DataGridTableStyle
        styleConceptos.MappingName = "TblConceptos"

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "ID"
            .HeaderText = "ID"
            .Width = 0
            .TextBox.Enabled = False
            .Alignment = HorizontalAlignment.Center
        End With
        styleConceptos.GridColumnStyles.Add(sColumna)

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "DESCRIPCION"
            .HeaderText = "DESCRIPCION"
            .Width = 350
            .TextBox.Enabled = False
            .Alignment = HorizontalAlignment.Center
        End With
        styleConceptos.GridColumnStyles.Add(sColumna)

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "UNIDAD"
            .HeaderText = "UNIDAD"
            .Width = 100
            .TextBox.Enabled = False
            .Alignment = HorizontalAlignment.Left
        End With
        styleConceptos.GridColumnStyles.Add(sColumna)

        styleConceptos.BackColor = Color.White
        styleConceptos.HeaderBackColor = Color.White
        styleConceptos.HeaderForeColor = Color.Black
        styleConceptos.ForeColor = Color.Black
        styleConceptos.HeaderFont = New Font("Tahoma", 10, FontStyle.Bold)

        '---ESTILO DE NO CLASIFICADOS----------------
        styleNoClasif = New DataGridTableStyle
        styleNoClasif.MappingName = "TblNoClasif"

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "ID"
            .HeaderText = "ID"
            .Width = 0
            .TextBox.Enabled = False
            .Alignment = HorizontalAlignment.Center
        End With
        styleNoClasif.GridColumnStyles.Add(sColumna)

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "DESCRIPCION"
            .HeaderText = "DESCRIPCION"
            .Width = 350
            .TextBox.Enabled = False
            .Alignment = HorizontalAlignment.Center
        End With
        styleNoClasif.GridColumnStyles.Add(sColumna)

        sColumna = New DataGridTextBoxColumn
        With sColumna
            .MappingName = "UNIDAD"
            .HeaderText = "UNIDAD"
            .Width = 100
            .TextBox.Enabled = False
            .Alignment = HorizontalAlignment.Left
        End With
        styleNoClasif.GridColumnStyles.Add(sColumna)

        styleNoClasif.BackColor = Color.White
        styleNoClasif.HeaderBackColor = Color.White
        styleNoClasif.HeaderForeColor = Color.Black
        styleNoClasif.ForeColor = Color.Black
        styleNoClasif.HeaderFont = New Font("Tahoma", 10, FontStyle.Bold)

    End Sub
    Private Sub ActualizarTabla(ByVal tablename As String)

        If tablename = "TblNoClasif" Then
            LimpiarTabla(TblNoClasif)
            Me.DgNoClasificados.DataSource = ObtNoClasif(TblNoClasif, tb_busqueda.Text)
        ElseIf tablename = "TblConceptos" Then
            LimpiarTabla(TblConceptos)
            Me.DgConceptos.DataSource = ObtConceptos(TblConceptos, idNodo, tb_busqueda.Text)
        End If
        BtnQuitar.Enabled = False
        BtnAgregar.Enabled = False
    End Sub
    Private Function LimpiarTabla(ByVal tablename As String) As DataTable
        Dim dt As New DataTable(tablename)
        Return dt
    End Function
    Private Function ObtNoClasif(ByVal TblNoClasif As String, ByVal busqueda As String) As DataTable


        Dim dt As New DataTable(TblNoClasif)

        dt.Columns.Add(New DataColumn("ID"))
        dt.Columns.Add(New DataColumn("DESCRIPCION"))
        dt.Columns.Add(New DataColumn("UNIDAD"))

        '


        '-OBTENEMOS lOS CONCEPTOS no CLASIFICADOS-----------------
        If busqueda = "" Then
            'Conectar()
            Dim rs = New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT producto.id_producto,producto.nombre, unidad.nombre as unidad  FROM producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE id_categoria=1", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            Dim dr As DataRow
            TRNoClasificados = rs.RecordCount
            Do While Not rs.EOF
                dr = dt.NewRow
                dr(0) = UCase(rs.Fields("id_producto").Value)
                dr(1) = UCase(rs.Fields("nombre").Value)
                dr(2) = UCase(rs.Fields("Unidad").Value)
                dt.Rows.Add(dr)
                rs.MoveNext()

            Loop
            rs.Close()
            'conn.close()
        Else
            'Conectar()
            Dim rs = New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.Open("SELECT producto.id_producto,producto.nombre,unidad.nombre As unidad FROM producto JOIN unidad On unidad.id_unidad=producto.id_unidad WHERE id_categoria='1' AND producto.nombre LIKE '%" & busqueda & "%' OR descripcion LIKE '%" & busqueda & "%'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
            Dim dr As DataRow
            TRNoClasificados = rs.RecordCount
            Do While Not rs.EOF
                dr = dt.NewRow
                dr(0) = UCase(rs.Fields("id_producto").Value)
                dr(1) = UCase(rs.Fields("nombre").Value)
                dr(2) = UCase(rs.Fields("unidad").Value)
                dt.Rows.Add(dr)
                rs.MoveNext()

            Loop
            rs.Close()
            'conn.close()

        End If

        'APLICAMOS LOS ESTILOS AL DATAGRID
        ds = New DataSet
        ds.Tables.Add(dt)
        DgNoClasificados.TableStyles.Clear()
        DgNoClasificados.TableStyles.Add(styleNoClasif)
        DgNoClasificados.SetDataBinding(ds, "TblNoClasif")
        '----
        Return dt
    End Function
    Private Function ObtConceptos(ByVal TblConceptos As String, ByVal cuenta As Integer, ByVal busqueda As String) As DataTable

        Dim dt As New DataTable(TblConceptos)
        dt.Columns.Add(New DataColumn("ID"))
        dt.Columns.Add(New DataColumn("DESCRIPCION"))
        dt.Columns.Add(New DataColumn("UNIDAD"))
        '


        '-OBTENEMOS lOS CONCEPTOS DE LA CUENTA-----------------
        If busqueda = "" Then
            If cuenta <> 0 Then
                'Conectar()

                Dim rs = New ADODB.Recordset
                rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                rs.Open("SELECT producto.id_producto,producto.nombre, unidad.nombre as unidad FROM producto JOIN unidad ON unidad.id_unidad=producto.id_unidad WHERE id_categoria='" & cuenta & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                Dim dr As DataRow
                TRConceptos = rs.RecordCount
                Do While Not rs.EOF
                    dr = dt.NewRow
                    dr(0) = UCase(rs.Fields("id_producto").Value)
                    dr(1) = UCase(rs.Fields("nombre").Value)
                    dr(2) = UCase(rs.Fields("unidad").Value)
                    dt.Rows.Add(dr)
                    rs.MoveNext()

                Loop
                rs.Close()
                'conn.close()

            End If
        Else
            If cuenta <> 0 Then
                'Conectar()

                Dim rs = New ADODB.Recordset
                rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
                rs.Open("SELECT producto.id_producto,producto.nombre,unidad.nombre As unidad FROM producto JOIN unidad On unidad.id_unidad=producto.id_unidad WHERE id_categoria='" & cuenta & "' AND producto.nombre LIKE '%" & busqueda & "%' OR descripcion LIKE '%" & busqueda & "%'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
                Dim dr As DataRow
                TRConceptos = rs.RecordCount
                Do While Not rs.EOF
                    dr = dt.NewRow
                    dr(0) = UCase(rs.Fields("id_producto").Value)
                    dr(1) = UCase(rs.Fields("nombre").Value)
                    dr(2) = UCase(rs.Fields("unidad").Value)
                    dt.Rows.Add(dr)
                    rs.MoveNext()

                Loop
                rs.Close()
                'conn.close()

            End If
        End If
        'APLICAMOS LOS ESTILOS AL DATAGRID
        ds = New DataSet
        ds.Tables.Add(dt)
        DgConceptos.TableStyles.Clear()
        DgConceptos.TableStyles.Add(styleConceptos)
        DgConceptos.SetDataBinding(ds, "TblConceptos")
        '----

        Return dt

    End Function
    Private Sub DgConceptos_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgConceptos.MouseUp
        ' CON ESTA FUNCION SELECCIONAMOS TODA LA FILA-------------
        Dim pt As System.Drawing.Point
        pt = New Point(e.X, e.Y)

        Dim hti As DataGrid.HitTestInfo
        hti = DgConceptos.HitTest(pt)
        If hti.Type = DataGrid.HitTestType.Cell Then
            DgConceptos.CurrentCell = New DataGridCell(hti.Row, hti.Column)
            DgConceptos.Select(hti.Row)
            If idNodo <> 0 Then
                BtnQuitar.Enabled = True
            End If
        End If
        '-------------------

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitar.Click
        '-ACTUALIZAMOS VALORES SELECCIONADOS-------------------
        Dim NumRow As Integer
        NumRow = 0
        Do Until NumRow = TRConceptos
            If DgConceptos.IsSelected(NumRow) = True Then
                'Conectar()
                conn.Execute("UPDATE producto SET id_categoria='1' WHERE id_producto='" & DgConceptos.Item(NumRow, 0) & "'")
                'conn.close()
                'conn = Nothing
                ActualizarTabla(TblNoClasif)
                ActualizarTabla(TblConceptos)
            Else
                NumRow = NumRow + 1
            End If

        Loop
        '--------------------------------------------


    End Sub

    Private Sub DgConceptos_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DgConceptos.Navigate

    End Sub

    Private Sub DgNoClasificados_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DgNoClasificados.MouseUp
        ' CON ESTA FUNCION SELECCIONAMOS TODA LA FILA-------------
        Dim pt As System.Drawing.Point
        pt = New Point(e.X, e.Y)

        Dim hti As DataGrid.HitTestInfo
        hti = DgNoClasificados.HitTest(pt)
        If hti.Type = DataGrid.HitTestType.Cell Then
            DgNoClasificados.CurrentCell = New DataGridCell(hti.Row, hti.Column)
            DgNoClasificados.Select(hti.Row)
            If idNodo <> 0 Then
                BtnAgregar.Enabled = True
            End If
        End If
        '-------------------


    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        '-ACTUALIZAMOS VALORES SELECCIONADOS-------------------

        Dim NumRow As Integer
        NumRow = 0
        Do Until NumRow = TRNoClasificados
            If DgNoClasificados.IsSelected(NumRow) = True Then
                'Conectar()
                conn.Execute("UPDATE producto SET id_categoria='" & idNodo & "' WHERE id_producto='" & DgNoClasificados.Item(NumRow, 0) & "'")
                'conn.close()
                'conn = Nothing
                ActualizarTabla(TblNoClasif)
                ActualizarTabla(TblConceptos)
                '(DgConceptos.Item(NumRow, 0))
            Else
                NumRow = NumRow + 1
            End If

        Loop
        '--------------------------------------------

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        arbolCategorias.Focus()
        arbolCategorias.SelectedNode.Collapse()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        arbolCategorias.Focus()
        arbolCategorias.SelectedNode.ExpandAll()
    End Sub

    Private Sub arbolCategorias_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles arbolCategorias.LostFocus
        arbolCategorias.SelectedNode.BackColor = Color.Black
        arbolCategorias.SelectedNode.ForeColor = Color.White

    End Sub

    Private Sub arbolCategorias_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles arbolCategorias.MouseUp
    End Sub

    Private Sub DgNoClasificados_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DgNoClasificados.Navigate

    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        tb_busqueda.Text = ""
        ActualizarTabla(TblConceptos)
        ActualizarTabla(TblNoClasif)
    End Sub

    Private Sub tb_busqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_busqueda.TextChanged
        ActualizarTabla(TblConceptos)
        ActualizarTabla(TblNoClasif)
    End Sub
End Class