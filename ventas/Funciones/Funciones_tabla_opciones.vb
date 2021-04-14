Module funciones_tabla_opciones
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_opciones As DataTable
    Private tabla_columna As DataGridTextBoxColumn
    Public Sub estilo_opciones(ByVal opciones As DataGridView)
        tabla_opciones = New DataTable("opciones")

        With tabla_opciones.Columns
            .Add(New DataColumn("id_opcion", GetType(Integer)))
            .Add(New DataColumn("imagen", GetType(System.Drawing.Image)))
            .Add(New DataColumn("opcion", GetType(String)))
            'Ocultos

        End With

        ds = New DataSet
        ds.Tables.Add(tabla_opciones)

        With opciones
            .DataSource = ds
            .DataMember = "opciones"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False

            With .Columns("id_opcion")
                .Width = 0
                .ReadOnly = True
            End With
            With .Columns("imagen")
                .HeaderText = "imagen"
                .Width = 50
                .ReadOnly = True
            End With
            With .Columns("opcion")
                .HeaderText = "Opcion"
                .Width = 250
                .ReadOnly = True
            End With
        End With
    End Sub
    Public Sub agregar_opcion(ByVal id_opcion As Integer, ByVal opcion As String, ByVal imagen As System.Drawing.Image)
        tabla_linea = tabla_opciones.NewRow()
        tabla_linea("id_opcion") = id_opcion
        tabla_linea("imagen") = imagen
        tabla_linea("opcion") = opcion
        tabla_opciones.Rows.Add(tabla_linea)
    End Sub
    Public Sub obtener_opciones_diponibles()
        tabla_opciones.Clear()
        rs.Open("SELECT perfil.* FROM perfil JOIN perfil_empleado ON perfil_empleado.id_perfil=perfil.id_perfil WHERE perfil_empleado.id_empleado=" & global_id_empleado, conn)
        If rs.RecordCount > 0 Then
            If rs.Fields("usuarios").Value = 1 Then 'ID01 
                agregar_opcion("1", "Alta de usuarios y configuracion de perfiles", frm_botones_terminal.obtener_imagen(1).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("cuentas_bancarias").Value = 1 Then 'ID02 
                agregar_opcion("2", "Cuentas Bancarias", frm_botones_terminal.obtener_imagen(2).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("impuestos").Value = 1 Then 'ID03
                agregar_opcion("3", "Impuestos", frm_botones_terminal.obtener_imagen(3).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("productos").Value = 1 Then 'ID04
                agregar_opcion("4", "Productos", frm_botones_terminal.obtener_imagen(4).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("catalogo").Value = 1 Then 'ID05
                agregar_opcion("5", "Categorias", frm_botones_terminal.obtener_imagen(5).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("sucursal").Value = 1 Then 'ID06
                agregar_opcion("6", "Sucursales", frm_botones_terminal.obtener_imagen(6).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("almacenes").Value = 1 Then 'ID07
                agregar_opcion("7", "Almacenes", frm_botones_terminal.obtener_imagen(7).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("directorio").Value = 1 Then 'ID08
                agregar_opcion("8", "Directorio", frm_botones_terminal.obtener_imagen(8).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("cotizaciones").Value = 1 Then 'ID09
                agregar_opcion("9", "Cotizaciones", frm_botones_terminal.obtener_imagen(9).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("compras").Value = 1 Then 'ID10
                agregar_opcion("10", "Recepción de Producto", frm_botones_terminal.obtener_imagen(10).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("pedidos").Value = 1 Then 'ID11
                agregar_opcion("11", "Ver pedidos", frm_botones_terminal.obtener_imagen(11).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("caja").Value = 1 Then 'ID12
                agregar_opcion("12", "Caja", frm_botones_terminal.obtener_imagen(12).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("pagos").Value = 1 Then 'ID13
                agregar_opcion("13", "Cuentas por pagar", frm_botones_terminal.obtener_imagen(13).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("facturacion").Value = 1 Then 'ID14
                agregar_opcion("14", "Facturacion", frm_botones_terminal.obtener_imagen(14).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("clasificacion_productos").Value = 1 Then 'ID15
                agregar_opcion("15", "Clasificar Productos", frm_botones_terminal.obtener_imagen(15).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("favoritos").Value = 1 Then 'ID16
                agregar_opcion("16", "Configuración de favoritos", frm_botones_terminal.obtener_imagen(16).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("conversiones").Value = 1 Then 'ID17
                agregar_opcion("17", "Conversiones", frm_botones_terminal.obtener_imagen(17).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("programacion_pedidos").Value = 1 Then 'ID18
                agregar_opcion("18", "Programación de pedidos", frm_botones_terminal.obtener_imagen(18).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("vehiculos").Value = 1 Then 'ID19
                agregar_opcion("19", "Vehiculos", frm_botones_terminal.obtener_imagen(19).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("repartidores").Value = 1 Then 'ID20
                agregar_opcion("20", "Repartidores", frm_botones_terminal.obtener_imagen(20).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("catalogo_precios").Value = 1 Then 'ID21
                agregar_opcion("21", "Catalogo de precios", frm_botones_terminal.obtener_imagen(21).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("perfiles_impresion").Value = 1 Then 'ID22
                agregar_opcion("22", "Perfiles de Impresión", frm_botones_terminal.obtener_imagen(22).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("cfg_conversiones").Value = 1 Then 'ID23
                agregar_opcion("23", "Configuración de conversiones", frm_botones_terminal.obtener_imagen(23).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("cfg_empresa").Value = 1 Then 'ID24
                agregar_opcion("24", "Configuracion de empresa", frm_botones_terminal.obtener_imagen(24).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("cfg_descuentos").Value = 1 Then 'ID25
                agregar_opcion("25", "Configuracion de descuentos", frm_botones_terminal.obtener_imagen(25).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("reporteador").Value = 1 Then 'ID26
                agregar_opcion("26", "Reporteador", frm_botones_terminal.obtener_imagen(26).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("ajuste_inventario").Value = 1 Then 'ID27
                agregar_opcion("27", "Inventario", frm_botones_terminal.obtener_imagen(27).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("traspasos_env").Value = 1 Then 'ID28
                agregar_opcion("28", "Traspasos (envio)", frm_botones_terminal.obtener_imagen(28).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("traspasos_recep").Value = 1 Then 'ID29
                agregar_opcion("29", "Traspasos (recepcion)", frm_botones_terminal.obtener_imagen(29).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("cfg_godmode").Value = 1 Then 'ID30
                agregar_opcion("30", "Configuraciones Avanzadas", frm_botones_terminal.obtener_imagen(30).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("cfg_correo").Value = 1 Then 'ID31
                agregar_opcion("31", "Configuraciones de correo", frm_botones_terminal.obtener_imagen(31).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("punto_venta").Value = 1 Then 'ID32
                agregar_opcion("32", "Punto de venta", frm_botones_terminal.obtener_imagen(32).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("cobros_creditos").Value = 1 Then 'ID33
                agregar_opcion("33", "Cuentas por cobrar", frm_botones_terminal.obtener_imagen(33).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("corte_caja").Value = 1 Then 'ID34
                agregar_opcion("34", "Corte de caja", frm_botones_terminal.obtener_imagen(34).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("corte_x").Value = 1 Then 'ID35
                agregar_opcion("35", "Corte x", frm_botones_terminal.obtener_imagen(35).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("devoluciones").Value = 1 Then 'ID36
                agregar_opcion("36", "Devoluciones a clientes", frm_botones_terminal.obtener_imagen(36).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("devoluciones").Value = 1 Then 'ID37
                agregar_opcion("37", "Lista de precios", frm_botones_terminal.obtener_imagen(37).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            If rs.Fields("devoluciones").Value = 1 Then 'ID38
                agregar_opcion("38", "Ajuste de Inventario", frm_botones_terminal.obtener_imagen(38).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            End If
            'id39
            agregar_opcion("39", "Pagina Web", frm_botones_terminal.obtener_imagen(39).GetThumbnailImage(50, 50, Nothing, New IntPtr))
            agregar_opcion("40", "Modulo de Mantenimiento", frm_botones_terminal.obtener_imagen(40).GetThumbnailImage(50, 50, Nothing, New IntPtr))
        End If
        rs.Close()
    End Sub

End Module
