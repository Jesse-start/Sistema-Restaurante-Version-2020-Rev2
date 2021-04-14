'---impresora
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Printing
'-----------
Public Class ticket
    Public LineasDeLaCabeza As ArrayList = New ArrayList()
    Public LineasDeLaSubCabeza As ArrayList = New ArrayList()
    Public LineasDeCliente As ArrayList = New ArrayList()
    Public Elementos As ArrayList = New ArrayList()
    Public Totales As ArrayList = New ArrayList()
    Public LineasDelPie As ArrayList = New ArrayList()
    Private headerImagep As Image = global_logotipo

    Public contador As Integer = 0

    Public CaracteresMaximos As Integer = cfg_longitud_maxima_ticket ' 39 original
    Public CaracteresMaximosDescripcion As Integer = cfg_longitud_descripcion '16 original

    Public imageHeight As Integer = 0

    Public MargenIzquierdo As Double = 2
    Public MargenSuperior As Double = 0

    ' Public NombreDeLaFuente As String = "Lucida Console" 'Lucida Console original
    'Public TamanoDeLaFuente As Integer = 7
    Public BigFontprinter = New Font(cfg_fuente_tituto, cfg_tamaño_fuente_titulo, FontStyle.Bold) ''Lucida Console original
    Public smallFontprinter = New Font(cfg_fuente_producto, cfg_tamaño_fuente_producto, FontStyle.Bold) ''Lucidºa Console original
    Public FuenteImpresa = New Font(cfg_fuente_producto, cfg_tamaño_fuente_producto, FontStyle.Regular)
    Public ColorDeLaFuente As SolidBrush = New SolidBrush(Color.Black)


    Public gfx As Graphics

    Public CadenaPorEscribirEnLinea As String = ""
    Private WithEvents DocumentoAImprimir As New PrintDocument

    Public Property HeaderImage() As Image
        Get
            Return headerImagep
        End Get
        Set(ByVal value As Image)
            'If headerImagep.Width <> value.Width Then

            'End If
            headerImagep = value
        End Set
    End Property



    Public Property MaximoCaracter() As Integer
        Get
            Return CaracteresMaximos
        End Get
        Set(ByVal value As Integer)
            If (value <> CaracteresMaximosDescripcion) Then CaracteresMaximosDescripcion = value
        End Set
    End Property



    Public Property MaximoCaracterDescripcion() As Integer
        Get
            Return CaracteresMaximosDescripcion
        End Get
        Set(ByVal value As Integer)
            If (value <> CaracteresMaximosDescripcion) Then CaracteresMaximosDescripcion = value
        End Set
    End Property



    Public Property TamanoLetra() As Integer
        Get
            Return TamanoDeLaFuente
        End Get
        Set(ByVal value As Integer)
            If (value <> TamanoDeLaFuente) Then TamanoDeLaFuente = value
        End Set
    End Property


    Public Property NombreLetra() As String
        Get
            Return NombreDeLaFuente
        End Get
        Set(ByVal value As String)
            If (value <> NombreDeLaFuente) Then NombreDeLaFuente = value
        End Set
    End Property


    Public Sub AnadirLineaCabeza(ByVal linea As String, Optional ByVal size_font As Integer = 0)
        LineasDeLaCabeza.Add(linea)
    End Sub

    Public Sub AnadirLineaSubcabeza(ByVal linea As String)

        LineasDeLaSubCabeza.Add(linea)
    End Sub
    Public Sub AnadirLineaCLiente(ByVal linea As String)
        LineasDeCliente.Add(linea)
    End Sub

    Public Sub AnadirElemento(ByVal cantidad As String, ByVal elemento As String, ByVal precio_unitario As String, ByVal precio As String)

        Dim NuevoElemento As OrdenarElementos = New OrdenarElementos()
        If cfg_productos_mayusculas_ticket = 1 Then
            elemento = UCase(elemento)
        End If
        '''''items.Add(newitem.
        Elementos.Add(NuevoElemento.GenerarElemento(cantidad, elemento, precio_unitario, precio))
    End Sub

    Public Sub AnadirTotal(ByVal Nombre As String, ByVal Precio As String, Optional ByVal big_font As Integer = 0)
        Dim NuevoTotal As OrdernarTotal = New OrdernarTotal
        ' OrderTotal(newtotal)
        If big_font = 1 Then
            '  Totales.Add("BF" & Nombre & " " & Precio)
            Totales.Add(NuevoTotal.GenerarTotal(Nombre, Precio))
        Else
            Totales.Add(NuevoTotal.GenerarTotal(Nombre, Precio))
        End If

    End Sub

    Public Sub AnadeLineaAlPie(ByVal linea As String)
        LineasDelPie.Add(linea)
    End Sub

    Private Function AlineaTextoaLaDerecha(ByVal Izquierda As Integer) As String

        Dim espacios As String = ""
        Dim spaces As Integer = MaximoCaracter() - Izquierda
        Dim x As Integer
        For x = 0 To spaces
            espacios += " "
        Next
        Return espacios
    End Function
    Private Function AlineaTextoaLaDerecha_bf(ByVal Izquierda As Integer) As String

        Dim espacios As String = ""
        Dim spaces As Integer = MaximoCaracter() - Izquierda
        Dim x As Integer
        For x = 0 To spaces
            espacios += " "
        Next
        Return espacios
    End Function
    Private Function AlineaTextoaLaDerecha_sf(ByVal Izquierda As Integer) As String

        Dim espacios As String = ""
        Dim spaces As Integer = cfg_longitud_linea_productos - Izquierda
        Dim x As Integer
        For x = 0 To spaces
            espacios += " "
        Next
        Return espacios
    End Function

    Private Function DottedLine() As String

        Dim dotted As String = ""
        Dim x As Integer
        For x = 0 To MaximoCaracter()
            dotted += " "
        Next
        Return dotted
    End Function

    Public Function ImpresoraExistente(ByVal impresora As String) As Boolean

        For Each strPrinter As String In PrinterSettings.InstalledPrinters

            If impresora = strPrinter Then
                Return True
            End If
        Next strPrinter
        Return False
    End Function

    Public Sub ImprimeTicket(ByVal index_impresora As String)
        Try
            FuenteImpresa = New Font(NombreLetra, TamanoLetra, FontStyle.Regular)
            DocumentoAImprimir.PrinterSettings.PrinterName = index_impresora
            DocumentoAImprimir.PrintController = New StandardPrintController
            DocumentoAImprimir.Print()
            Imprimir_recepcion_producto = 0
        Catch ex As Exception
            MsgBox("Se produjo un error al imprimir en " & index_impresora & ", verifique que la impresora se encuentra instalada y conectada correctamente o Seleccione una impresora diferente." & vbCrLf & "Codigo de Error:" & ex.Message, MsgBoxStyle.Critical, "Aviso")
            'If MsgBox("¿Desea cambiar la configuracion de impresoras en el sistema ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then
            'frm_configuracion_empresa.ShowDialog()
            'frm_configuracion_empresa.TabCFG.SelectTab(4)
            'frm_configuracion_empresa.BringToFront()
            'End If
        End Try

    End Sub

    Private Sub DocumentoAImprimir_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocumentoAImprimir.PrintPage
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        gfx = e.Graphics

        If conf_pv(19) = 1 Then
            If globa_eliminar_imagen_ticket = False Then
                DrawImage()
            End If
        End If

        If global_imprimir_codigo_barras = True Then
            codigo_barra()
        End If

        'DrawImage()
        ' DrawHeader()
        DibujaLaCabecera()
        'DrawSubHeader()
        DibujaLineaCliente()
        DibujaLaSubCabecera()
        'DrawItems()
        DibujaElementos()
        'DrawTotales()
        DibujaTotales()
        DibujarPieDePagina()

        'If (headerImagep.Width <> 0) Then
        '      HeaderImage.Dispose()
        '      HeaderImage.Dispose()
        'End If
    End Sub

    Private Function Renglon() As Double

        Return MargenSuperior + (contador * FuenteImpresa.GetHeight(gfx) + imageHeight)


    End Function
    Private Function Renglon2() As Double

        Return MargenSuperior + (contador * BigFontprinter.GetHeight(gfx) + imageHeight)


    End Function

    Private Sub DrawImage()

        If (headerImagep.Width <> 0) Then
            Try
                ' gfx.DrawImage(HeaderImage, New Point(CInt(MargenIzquierdo), CInt(Renglon())))
                gfx.DrawImage(HeaderImage, New Point(8, CInt(Renglon())))
                Dim height As Double = (HeaderImage.Height / cfg_escala_logo_ticket) * cfg_escala_altura_logo
                imageHeight = CInt(Math.Round(height) + 3)
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub codigo_barra()

        If (headerImagep.Width <> 0) Then
            Try
                ' gfx.DrawImage(HeaderImage, New Point(CInt(MargenIzquierdo), CInt(Renglon())))
                gfx.DrawImage(global_codigo_barra_venta, New Point(25, CInt(Renglon())))
                Dim height As Double = (global_codigo_barra_venta.Height / cfg_escala_logo_ticket) * cfg_escala_altura_logo
                imageHeight = CInt(Math.Round(height) + 3)

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub DibujaLaCabecera()

        For Each Cabecera As String In LineasDeLaCabeza

            If (Cabecera.Length > MaximoCaracter()) Then

                Dim CaracterActual As Integer = 0
                Dim LongitudDeCabecera As Integer = Cabecera.Length

                While (LongitudDeCabecera > MaximoCaracter())

                    CadenaPorEscribirEnLinea = Cabecera.Substring(CaracterActual, MaximoCaracter)
                    gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                    contador += 1
                    CaracterActual += MaximoCaracter()
                    LongitudDeCabecera -= MaximoCaracter()
                End While
                CadenaPorEscribirEnLinea = Cabecera
                gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                contador += 1

            Else


                CadenaPorEscribirEnLinea = Cabecera
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                contador += 1
            End If
        Next Cabecera
        DibujaEspacio()
    End Sub

    Private Sub DibujaLaSubCabecera()

        For Each SubCabecera As String In LineasDeLaSubCabeza

            If (SubCabecera.Length > MaximoCaracter()) Then

                Dim CaracterActual As Integer = 0
                Dim LongitudSubcabecera As Integer = SubCabecera.Length

                While (LongitudSubcabecera > MaximoCaracter())

                    CadenaPorEscribirEnLinea = SubCabecera
                    gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, MaximoCaracter), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                    contador += 1
                    CaracterActual += MaximoCaracter()
                    LongitudSubcabecera -= MaximoCaracter()
                End While
                CadenaPorEscribirEnLinea = SubCabecera
                gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                contador += 1

            Else

                CadenaPorEscribirEnLinea = SubCabecera

                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                contador += 1

                ' CadenaPorEscribirEnLinea = DottedLine()

                'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                'contador += 1
            End If
        Next SubCabecera
        'DibujaEspacio()
    End Sub
    Private Sub DibujaLineaCliente()

        For Each LineasCliente As String In LineasDeCliente
            Dim espacios As String = ""
            Dim len As Integer = 0

            If (LineasCliente.Length > 27) Then

                Dim CaracterActual As Integer = 0
                Dim LongitudLineaCliente As Integer = LineasCliente.Length

                While (LongitudLineaCliente > 27)

                    CadenaPorEscribirEnLinea = LineasCliente
                    gfx.DrawString(CadenaPorEscribirEnLinea.Substring(CaracterActual, 27), BigFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                    len = CInt((27 - (LineasCliente.Length - 27)) / 2)
                    espacios = ""
                    For x = 1 To len
                        espacios += " "
                    Next

                    contador += 1
                    CaracterActual += 27
                    LongitudLineaCliente -= 27
                End While
                CadenaPorEscribirEnLinea = LineasCliente
                gfx.DrawString(espacios & CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), BigFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                contador += 1

            Else

                CadenaPorEscribirEnLinea = LineasCliente

                gfx.DrawString(CadenaPorEscribirEnLinea, BigFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                contador += 1

                ' CadenaPorEscribirEnLinea = DottedLine()

                'gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                'contador += 1
            End If
        Next LineasCliente
        DibujaEspacioLineaCliente()
    End Sub

    Private Sub DibujaElementos()

        Dim OrdenElemento As OrdenarElementos = New OrdenarElementos()

        gfx.DrawString(EncabezadoConcepto, smallFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

        contador += 1
        DibujaEspacio()

        For Each Elemento As String In Elementos

            CadenaPorEscribirEnLinea = OrdenElemento.ObtenerCantidadDeElementos(Elemento)

            gfx.DrawString(CadenaPorEscribirEnLinea, smallFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
            CadenaPorEscribirEnLinea = OrdenElemento.ObtenerPrecioElemento(Elemento)
            Dim longitud_cantidades As Integer = CadenaPorEscribirEnLinea.Length
            CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha_sf(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea

            gfx.DrawString(CadenaPorEscribirEnLinea, smallFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

            Dim Nombre As String = OrdenElemento.ObtenerNombreElemento(Elemento)

            MargenIzquierdo = 2
            If Imprimir_recepcion_producto = 1 Then
                If (Nombre.Length > CaracteresMaximosDescripcion) Then

                    Dim CaracterActual As Integer = 0
                    Dim LongitudElemento As Integer = Nombre.Length

                    While (LongitudElemento > CaracteresMaximosDescripcion)

                        CadenaPorEscribirEnLinea = OrdenElemento.ObtenerNombreElemento(Elemento)
                        'gfx.DrawString("   " + CadenaPorEscribirEnLinea.Substring(CaracterActual, MaximoCaracterDescripcion), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                        gfx.DrawString("         " + CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length), smallFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                        '--espacio de la descripcion
                        contador += 1
                        CaracterActual += CaracteresMaximosDescripcion
                        LongitudElemento -= CaracteresMaximosDescripcion
                    End While

                    'CadenaPorEscribirEnLinea = OrdenElemento.ObtenerNombreElemento(Elemento)
                    'gfx.DrawString("" + CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon() + 10, New StringFormat())
                    'gfx.DrawString("         " + CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), smallFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon() + 0, New StringFormat())
                    'contador += 1
                    'contador += 1

                Else

                    'gfx.DrawString("   " + OrdenElemento.ObtenerNombreElemento(Elemento), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                    gfx.DrawString("         " + OrdenElemento.ObtenerNombreElemento(Elemento), smallFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                    contador += 1
                End If
            Else
                Dim len As Integer = CaracteresMaximos - longitud_cantidades
                If (Nombre.Length > len) Then

                    Dim CaracterActual As Integer = 0
                    Dim LongitudElemento As Integer = Nombre.Length

                    While (LongitudElemento > len)

                        CadenaPorEscribirEnLinea = OrdenElemento.ObtenerNombreElemento(Elemento)
                        'gfx.DrawString("   " + CadenaPorEscribirEnLinea.Substring(CaracterActual, MaximoCaracterDescripcion), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                        gfx.DrawString("             " + CadenaPorEscribirEnLinea.Substring(CaracterActual, len), smallFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                        '--espacio de la descripcion
                        contador += 1
                        CaracterActual += len
                        LongitudElemento -= len
                    End While

                    CadenaPorEscribirEnLinea = OrdenElemento.ObtenerNombreElemento(Elemento)
                    'gfx.DrawString("" + CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon() + 10, New StringFormat())
                    gfx.DrawString("            " + CadenaPorEscribirEnLinea.Substring(CaracterActual, CadenaPorEscribirEnLinea.Length - CaracterActual), smallFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon() + 0, New StringFormat())
                    contador += 1
                    contador += 1

                Else

                    'gfx.DrawString("   " + OrdenElemento.ObtenerNombreElemento(Elemento), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                    gfx.DrawString("             " + OrdenElemento.ObtenerNombreElemento(Elemento), smallFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                    contador += 1
                End If
            End If

        Next Elemento

        MargenIzquierdo = 2
        'DibujaEspacio()
        CadenaPorEscribirEnLinea = DottedLine()

        gfx.DrawString(CadenaPorEscribirEnLinea, smallFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

        contador += 1
        'DibujaEspacio()
    End Sub

    Private Sub DibujaTotales()

        Dim ordTot As OrdernarTotal = New OrdernarTotal()

        For Each total As String In Totales
            Dim font_printer As Font = FuenteImpresa
            Dim s As String = ""
            s = Left(total, 2)

            Dim relleno As String = ""
            For x = 1 To cfg_espacios_antes_total
                relleno = relleno & " "
            Next

            Dim margen_izq_total As String = ""
            For x = 1 To cfg_margen_izq_total
                margen_izq_total = margen_izq_total & " "
            Next

            If s = "BF" Then
                total = total.Substring(2)
                font_printer = BigFontprinter

                CadenaPorEscribirEnLinea = ordTot.ObtenerTotalCantidad(total)
                CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha_bf(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea

                gfx.DrawString(CadenaPorEscribirEnLinea, font_printer, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                MargenIzquierdo = 2

               
                CadenaPorEscribirEnLinea = relleno + ordTot.ObtenerTotalNombre(total)
                gfx.DrawString(CadenaPorEscribirEnLinea, font_printer, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                contador += 1
            Else
                CadenaPorEscribirEnLinea = ordTot.ObtenerTotalCantidad(total)
                CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea

                gfx.DrawString(CadenaPorEscribirEnLinea, font_printer, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                MargenIzquierdo = 2

                'CadenaPorEscribirEnLinea = " " + ordTot.ObtenerTotalNombre(total)
                CadenaPorEscribirEnLinea = margen_izq_total + ordTot.ObtenerTotalNombre(total)

                gfx.DrawString(CadenaPorEscribirEnLinea, font_printer, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                contador += 1
            End If
            'CadenaPorEscribirEnLinea = ordTot.ObtenerTotalCantidad(total)
            'CadenaPorEscribirEnLinea = AlineaTextoaLaDerecha(CadenaPorEscribirEnLinea.Length) + CadenaPorEscribirEnLinea

            'gfx.DrawString(CadenaPorEscribirEnLinea, font_printer, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
            'MargenIzquierdo = 2

            'CadenaPorEscribirEnLinea = "         " + ordTot.ObtenerTotalNombre(total)
            'gfx.DrawString(CadenaPorEscribirEnLinea, font_printer, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
            'contador += 1
        Next total
        MargenIzquierdo = 2
        'DibujaEspacio()
        'DibujaEspacio()
    End Sub

    Private Sub DibujarPieDePagina()

        For Each PieDePagina As String In LineasDelPie

            If (PieDePagina.Length > MaximoCaracter()) Then

                Dim currentChar As Integer = 0
                Dim LongitudPieDePagina As Integer = PieDePagina.Length

                While (LongitudPieDePagina > MaximoCaracter())

                    CadenaPorEscribirEnLinea = PieDePagina
                    gfx.DrawString(CadenaPorEscribirEnLinea.Substring(currentChar, MaximoCaracter), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                    contador += 1
                    currentChar += MaximoCaracter()
                    LongitudPieDePagina -= MaximoCaracter()
                End While
                CadenaPorEscribirEnLinea = PieDePagina
                gfx.DrawString(CadenaPorEscribirEnLinea.Substring(currentChar, CadenaPorEscribirEnLinea.Length - currentChar), FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())
                contador += 1

            Else

                CadenaPorEscribirEnLinea = PieDePagina
                gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

                contador += 1
            End If
        Next PieDePagina
        MargenIzquierdo = 2
        DibujaEspacio()
    End Sub

    Private Sub DibujaEspacio() '-ESPACIO ENTRE LINEAS

        CadenaPorEscribirEnLinea = "   "

        gfx.DrawString(CadenaPorEscribirEnLinea, FuenteImpresa, ColorDeLaFuente, MargenIzquierdo, Renglon(), New StringFormat())

        contador += 1

    End Sub
    Private Sub DibujaEspacioLineaCliente() '-ESPACIO ENTRE LINEAS

        CadenaPorEscribirEnLinea = "   "

        gfx.DrawString(CadenaPorEscribirEnLinea, BigFontprinter, ColorDeLaFuente, MargenIzquierdo, Renglon2(), New StringFormat())

        contador += 1

    End Sub

    Public Sub New()

    End Sub


End Class
Public Class OrdenarElementos

    Public delimitador() As Char = "|||"


    Public Sub OrdenarElementos(ByVal delimit As Char)
        Dim delimitador As Char = delimit
    End Sub


    Public Function ObtenerCantidadDeElementos(ByVal orderItem As String) As String

        Dim delimitado() As String = orderItem.Split(delimitador)
        Return delimitado(0)
    End Function

    Public Function ObtenerNombreElemento(ByVal orderItem As String) As String

        Dim delimitado() As String = orderItem.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function ObtenerPrecioElemento(ByVal orderItem As String) As String

        Dim delimitado() As String = orderItem.Split(delimitador)
        Return delimitado(2)
    End Function

    Public Function GenerarElemento(ByVal cantidad As String, ByVal NombreElemento As String, ByVal Precio_unitario As String, ByVal Precio As String) As String
        Precio = Precio_unitario + "  " + Precio
        Return cantidad + delimitador(0) + NombreElemento + delimitador(0) + Precio
       
    End Function
End Class




Public Class OrdernarTotal

    Public delimitador() As Char = "   "

    Public Sub OrdernarTotal(ByVal delimit As Char)

        Dim delimitador As Char = delimit
    End Sub

    Public Function ObtenerTotalNombre(ByVal totalItem As String) As String

        Dim delimitado() As String = totalItem.Split(delimitador)
        Return delimitado(0)

    End Function
    Public Function ObtenerTotalCantidad(ByVal totalItem As String) As String

        Dim delimitado() As String = totalItem.Split(delimitador)
        Return delimitado(1)
    End Function

    Public Function GenerarTotal(ByVal totalName As String, ByVal price As String) As String

        GenerarTotal = totalName + delimitador(0) + price
    End Function

End Class