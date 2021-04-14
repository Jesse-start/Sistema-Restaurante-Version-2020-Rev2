Public Class frm_productos_codigos
    Private cargado As Boolean = False
    Private tabla_cargado As Boolean = False
    Public id_categoria As Integer
    Public producto As String
    Public tipo_bus As Integer

    Private Sub frm_productos_codigos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargado = False
        estilo_tabla_codigos(dgv_codigos)
        cargar(id_categoria, producto, tipo_bus)
    End Sub
    Public Sub cargar(ByVal id_catg As Integer, ByVal nombre_producto As String, ByVal id_tipo_bus As Integer)
        tabla_codigos.Clear()
        'id_tipo_bus=0 ' se busca por categoria
        'id_tipo_bus=1 se busca por nombre
        tb_nombre.Text = nombre_producto
        'Conectar()
        rs.Open("SELECT nombre FROM categoria WHERE id_categoria='" & id_categoria & "'", conn)
        If rs.RecordCount > 0 Then
            tb_categoria.Text = rs.Fields("nombre").Value
        End If
        rs.Close()
        'conn.close()
        'conn = Nothing


        If id_tipo_bus = 1 Then
            If id_catg = 1 Then
                'Conectar()
                rs.Open("SELECT p.id_producto,p.nombre AS producto,p.codigo FROM producto p ORDER BY p.codigo ASC", conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        agregar_tabla_codigos(rs.Fields("id_producto").Value, rs.Fields("codigo").Value, rs.Fields("producto").Value)
                        rs.MoveNext()
                    End While
                End If

                rs.Close()
                'conn.close()
            Else
                'Conectar()
                rs.Open("SELECT p.id_producto,p.nombre AS producto,p.codigo FROM producto p WHERE p.id_categoria='" & id_catg & "' ORDER BY p.codigo ASC", conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        agregar_tabla_codigos(rs.Fields("id_producto").Value, rs.Fields("codigo").Value, rs.Fields("producto").Value)
                        rs.MoveNext()
                    End While
                End If

                rs.Close()
                'conn.close()

            End If
        Else
            If id_catg = 1 Then
                'Conectar()
                rs.Open("SELECT p.id_producto,p.nombre AS producto,p.codigo FROM producto p WHERE p.nombre LIKE '%" & Trim(tb_nombre.Text) & "%' ORDER BY p.codigo ASC", conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        agregar_tabla_codigos(rs.Fields("id_producto").Value, rs.Fields("codigo").Value, rs.Fields("producto").Value)
                        rs.MoveNext()
                    End While
                End If

                rs.Close()
                'conn.close()
            Else
                'Conectar()
                rs.Open("SELECT p.id_producto,p.nombre AS producto,p.codigo FROM producto p WHERE p.nombre LIKE '%" & Trim(tb_nombre.Text) & "%' AND p.id_categoria='" & id_categoria & "' ORDER BY p.codigo ASC", conn)
                If rs.RecordCount > 0 Then
                    While Not rs.EOF
                        agregar_tabla_codigos(rs.Fields("id_producto").Value, rs.Fields("codigo").Value, rs.Fields("producto").Value)
                        rs.MoveNext()
                    End While
                End If

                rs.Close()
                'conn.close()

            End If

        End If
        cargado = True
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cerrar.Click
        Me.Close()
    End Sub

    Private Sub chb_categoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_categoria.CheckedChanged
        If chb_categoria.Checked = True Then
            chb_descripcion.Checked = False
            If cargado = True Then
                cargar(id_categoria, tb_nombre.Text, chb_categoria.CheckState)
            End If
        Else
            chb_descripcion.Checked = True
            If cargado = True Then
                cargar(1, tb_nombre.Text, chb_categoria.CheckState)
            End If
        End If
        

    End Sub

    Private Sub chb_descripcion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chb_descripcion.CheckedChanged
        If chb_descripcion.Checked = True Then
            chb_categoria.Checked = False
        Else
            chb_categoria.Checked = True
        End If
    End Sub

    Private Sub tb_nombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_nombre.TextChanged
        If chb_descripcion.Checked = True Then
            cargar(1, tb_nombre.Text, chb_categoria.CheckState)
        End If
    End Sub

    Private Sub dgv_codigos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_codigos.CellContentClick

    End Sub

    Private Sub dgv_codigos_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgv_codigos.CellFormatting
        e.CellStyle.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
        For x = 0 To dgv_codigos.Columns.Count - 1
            If dgv_codigos.Columns(e.ColumnIndex).Index = x Then
                If x = 1 Then
                    e.CellStyle.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
                End If
                e.CellStyle.BackColor = Color.White
                e.CellStyle.ForeColor = Color.Black
                e.CellStyle.SelectionBackColor = Color.Black
                e.CellStyle.SelectionForeColor = Color.White
            End If
        Next
    End Sub
End Class