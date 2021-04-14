Module funciones_matriz_precios
    Private ds As DataSet
    Private tabla_linea As DataRow
    Dim linea_ As Integer
    Public tabla_matriz_precios As DataTable
    Private tabla_columna As DataGridTextBoxColumn


    Public Sub estilo_matriz_precios(ByVal dgv_matriz As DataGridView)
        tabla_matriz_precios = New DataTable("matriz_precio")

        With tabla_matriz_precios.Columns
            .Add(New DataColumn("eliminar", GetType(Boolean)))
            .Add(New DataColumn("id_producto", GetType(Integer)))
            .Add(New DataColumn("codigo", GetType(String)))
            .Add(New DataColumn("descripcion", GetType(String)))
            .Add(New DataColumn("costo", GetType(Decimal)))
            .Add(New DataColumn("utilidad", GetType(Decimal)))
            .Add(New DataColumn("precio_pg", GetType(Decimal)))



            'obentemos la listra de precios 
            'Conectar()
            rs.Open("SELECT id_ctlg_precios,nombre FROM ctlg_precios ORDER BY id_ctlg_precios DESC", conn)
            If rs.RecordCount > 0 Then
                Dim i As Integer = 1
                While Not rs.EOF
                    .Add(New DataColumn("id_ctlg_precio" & i, GetType(Integer)))
                    .Add(New DataColumn("precio" & i, GetType(Decimal)))
                    i += 1
                    rs.MoveNext()
                End While
            End If

            rs.Close()

            'conn.close()
            'conn = Nothing
        End With
        ds = New DataSet
        ds.Tables.Add(tabla_matriz_precios)

        With dgv_matriz
            .DataSource = ds
            .DataMember = "matriz_precio"

            .AllowUserToAddRows = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 235, 231)

            .AllowUserToOrderColumns = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            With .Columns("eliminar")
                .HeaderText = "Eliminar"
                .Width = 30
                .Visible = True
                .Frozen = True
            End With

            With .Columns("id_producto")
                .Width = 0
                .Visible = False
                .Frozen = True
            End With
            With .Columns("codigo")
                .HeaderText = "codigo"
                .Width = 100
                .ReadOnly = True
                .Frozen = True

                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            End With
            With .Columns("descripcion")
                .HeaderText = "Nombre"
                .Width = 300
                .ReadOnly = False
                .Frozen = True
                .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            End With
            With .Columns("costo")
                .HeaderText = "Costo"
                .Width = 60
                .ReadOnly = False
            End With

            With .Columns("utilidad")
                .HeaderText = "%Gan"
                .Width = 40
                .ReadOnly = True
            End With

            With .Columns("precio_pg")
                .HeaderText = "PUBLICO"
                .Width = 60
                .ReadOnly = False
            End With
        End With

        'Conectar()
        rs.Open("SELECT id_ctlg_precios,nombre FROM ctlg_precios ORDER BY id_ctlg_precios DESC", conn)
        If rs.RecordCount > 0 Then
            Dim i As Integer = 1
            While Not rs.EOF
                With dgv_matriz
                    With .Columns("id_ctlg_precio" & i)
                        .Width = 0
                        .ReadOnly = True
                        .Visible = False
                    End With
                    With .Columns("precio" & i)
                        .HeaderText = rs.Fields("nombre").Value
                        .Width = 60
                        .ReadOnly = False
                        .Visible = True
                    End With
                End With
                i += 1
                rs.MoveNext()
            End While
        End If

        rs.Close()

        'conn.close()
        'conn = Nothing

    End Sub
    Public Sub agregar_matriz_precios(ByVal eliminar As Boolean, ByVal id_producto As Integer, ByVal codigo As String, ByVal descripcion As String, ByVal costo As Decimal, ByVal ganancia As Decimal, ByVal precio_publico_general As Decimal, Optional ByVal id_precio_ctlg1 As Integer = 0, Optional ByVal precio1 As Decimal = 0, Optional ByVal id_precio_ctlg2 As Integer = 0, Optional ByVal precio2 As Decimal = 0, Optional ByVal id_precio_ctlg3 As Integer = 0, Optional ByVal precio3 As Decimal = 0, Optional ByVal id_precio_ctlg4 As Integer = 0, Optional ByVal precio4 As Decimal = 0, Optional ByVal id_precio_ctlg5 As Integer = 0, Optional ByVal precio5 As Decimal = 0, Optional ByVal id_precio_ctlg6 As Integer = 0, Optional ByVal precio6 As Decimal = 0, Optional ByVal id_precio_ctlg7 As Integer = 0, Optional ByVal precio7 As Decimal = 0, Optional ByVal id_precio_ctlg8 As Integer = 0, Optional ByVal precio8 As Decimal = 0, Optional ByVal id_precio_ctlg9 As Integer = 0, Optional ByVal precio9 As Decimal = 0, Optional ByVal id_precio_ctlg10 As Integer = 0, Optional ByVal precio10 As Decimal = 0, Optional ByVal id_precio_ctlg11 As Integer = 0, Optional ByVal precio11 As Decimal = 0, Optional ByVal id_precio_ctlg12 As Integer = 0, Optional ByVal precio12 As Decimal = 0, Optional ByVal id_precio_ctlg13 As Integer = 0, Optional ByVal precio13 As Decimal = 0, Optional ByVal id_precio_ctlg14 As Integer = 0, Optional ByVal precio14 As Decimal = 0, Optional ByVal id_precio_ctlg15 As Integer = 0, Optional ByVal precio15 As Decimal = 0, Optional ByVal id_precio_ctlg16 As Integer = 0, Optional ByVal precio16 As Decimal = 0, Optional ByVal id_precio_ctlg17 As Integer = 0, Optional ByVal precio17 As Decimal = 0, Optional ByVal id_precio_ctlg18 As Integer = 0, Optional ByVal precio18 As Decimal = 0, Optional ByVal id_precio_ctlg19 As Integer = 0, Optional ByVal precio19 As Decimal = 0, Optional ByVal id_precio_ctlg20 As Integer = 0, Optional ByVal precio20 As Decimal = 0, Optional ByVal id_precio_ctlg21 As Integer = 0, Optional ByVal precio21 As Decimal = 0, Optional ByVal id_precio_ctlg22 As Integer = 0, Optional ByVal precio22 As Decimal = 0, Optional ByVal id_precio_ctlg23 As Integer = 0, Optional ByVal precio23 As Decimal = 0, Optional ByVal id_precio_ctlg24 As Integer = 0, Optional ByVal precio24 As Decimal = 0, Optional ByVal id_precio_ctlg25 As Integer = 0, Optional ByVal precio25 As Decimal = 0)
        tabla_linea = tabla_matriz_precios.NewRow()
        tabla_linea("eliminar") = eliminar
        tabla_linea("id_producto") = id_producto
        tabla_linea("codigo") = codigo
        tabla_linea("descripcion") = descripcion
        tabla_linea("costo") = costo
        tabla_linea("utilidad") = ganancia
        tabla_linea("precio_pg") = precio_publico_general

        If id_precio_ctlg1 <> 0 Then
            tabla_linea("id_ctlg_precio1") = id_precio_ctlg1
            tabla_linea("precio1") = precio1
        End If
        If id_precio_ctlg2 <> 0 Then
            tabla_linea("id_ctlg_precio2") = id_precio_ctlg2
            tabla_linea("precio2") = precio2
        End If
        If id_precio_ctlg3 <> 0 Then
            tabla_linea("id_ctlg_precio3") = id_precio_ctlg3
            tabla_linea("precio3") = precio3
        End If
        If id_precio_ctlg4 <> 0 Then
            tabla_linea("id_ctlg_precio4") = id_precio_ctlg4
            tabla_linea("precio4") = precio4
        End If
        If id_precio_ctlg5 <> 0 Then
            tabla_linea("id_ctlg_precio5") = id_precio_ctlg5
            tabla_linea("precio5") = precio5
        End If
        If id_precio_ctlg6 <> 0 Then
            tabla_linea("id_ctlg_precio6") = id_precio_ctlg6
            tabla_linea("precio6") = precio6
        End If
        If id_precio_ctlg7 <> 0 Then
            tabla_linea("id_ctlg_precio7") = id_precio_ctlg7
            tabla_linea("precio7") = precio7
        End If
        If id_precio_ctlg8 <> 0 Then
            tabla_linea("id_ctlg_precio8") = id_precio_ctlg8
            tabla_linea("precio8") = precio8
        End If
        If id_precio_ctlg9 <> 0 Then
            tabla_linea("id_ctlg_precio9") = id_precio_ctlg9
            tabla_linea("precio9") = precio9
        End If
        If id_precio_ctlg10 <> 0 Then
            tabla_linea("id_ctlg_precio10") = id_precio_ctlg10
            tabla_linea("precio10") = precio10
        End If
        If id_precio_ctlg11 <> 0 Then
            tabla_linea("id_ctlg_precio11") = id_precio_ctlg11
            tabla_linea("precio11") = precio11
        End If
        If id_precio_ctlg12 <> 0 Then
            tabla_linea("id_ctlg_precio12") = id_precio_ctlg12
            tabla_linea("precio12") = precio12
        End If
        If id_precio_ctlg13 <> 0 Then
            tabla_linea("id_ctlg_precio13") = id_precio_ctlg13
            tabla_linea("precio13") = precio13
        End If
        If id_precio_ctlg14 <> 0 Then
            tabla_linea("id_ctlg_precio14") = id_precio_ctlg14
            tabla_linea("precio14") = precio14
        End If
        If id_precio_ctlg15 <> 0 Then
            tabla_linea("id_ctlg_precio15") = id_precio_ctlg15
            tabla_linea("precio15") = precio15
        End If
        If id_precio_ctlg16 <> 0 Then
            tabla_linea("id_ctlg_precio16") = id_precio_ctlg16
            tabla_linea("precio16") = precio16
        End If
        If id_precio_ctlg17 <> 0 Then
            tabla_linea("id_ctlg_precio17") = id_precio_ctlg17
            tabla_linea("precio17") = precio17
        End If
        If id_precio_ctlg18 <> 0 Then
            tabla_linea("id_ctlg_precio18") = id_precio_ctlg18
            tabla_linea("precio18") = precio18
        End If
        If id_precio_ctlg19 <> 0 Then
            tabla_linea("id_ctlg_precio19") = id_precio_ctlg19
            tabla_linea("precio19") = precio19
        End If
        If id_precio_ctlg20 <> 0 Then
            tabla_linea("id_ctlg_precio20") = id_precio_ctlg20
            tabla_linea("precio20") = precio20
        End If
        If id_precio_ctlg21 <> 0 Then
            tabla_linea("id_ctlg_precio21") = id_precio_ctlg21
            tabla_linea("precio21") = precio21
        End If
        If id_precio_ctlg22 <> 0 Then
            tabla_linea("id_ctlg_precio22") = id_precio_ctlg22
            tabla_linea("precio22") = precio22
        End If
        If id_precio_ctlg23 <> 0 Then
            tabla_linea("id_ctlg_precio23") = id_precio_ctlg23
            tabla_linea("precio23") = precio23
        End If
        If id_precio_ctlg24 <> 0 Then
            tabla_linea("id_ctlg_precio24") = id_precio_ctlg24
            tabla_linea("precio24") = precio24
        End If
        If id_precio_ctlg25 <> 0 Then
            tabla_linea("id_ctlg_precio25") = id_precio_ctlg25
            tabla_linea("precio25") = precio25
        End If
        tabla_matriz_precios.Rows.Add(tabla_linea)
    End Sub
End Module
