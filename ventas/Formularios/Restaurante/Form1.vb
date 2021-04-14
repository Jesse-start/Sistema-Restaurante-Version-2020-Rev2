Imports System.Drawing
Imports System.Drawing.Imaging

Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim cropBitmap As Bitmap
    Dim cropX As Integer
    Dim cropY As Integer
    Dim cropWidth As Integer
    Dim cropHeight As Integer
    Dim cropPen As Pen
    Public cropPenSize As Integer = 2
    Public cropDashStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
    Public cropPenColor As Color = Color.Aquamarine
    Public c As Cursor

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Try
            Dim openDLG As New OpenFileDialog
            openDLG.Filter = "Image Files (*.bmp, *.gif, *.jpg)|*.bmp;*.gif;*.jpg"
            If openDLG.ShowDialog = DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(openDLG.FileName, True)
            End If
        Catch exc As Exception
            MessageBox.Show(exc.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        Try
            If e.Button = MouseButtons.Left Then
                cropX = e.X
                cropY = e.Y
                cropPen = New Pen(cropPenColor, cropPenSize)
                cropPen.DashStyle = cropDashStyle
            End If
            PictureBox1.Refresh()
        Catch exc As Exception

            MessageBox.Show(exc.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Try

            If PictureBox1.Image Is Nothing Then Exit Sub

            If e.Button = MouseButtons.Left Then
                PictureBox1.Refresh()
                cropWidth = e.X - cropX
                cropHeight = e.Y - cropY
                PictureBox1.CreateGraphics.DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight)
            End If
            GC.Collect()

        Catch exc As Exception
            If Err.Number = 5 Then Exit Sub
            MessageBox.Show(exc.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        Try
        Catch exc As Exception
            MessageBox.Show(exc.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If pbCrop.Image Is Nothing Then
                MessageBox.Show("You have not edited the original image. There is no new image to save.", " Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            Dim saveDLG As SaveFileDialog = New SaveFileDialog
            saveDLG.Filter = "Image Files (*.bmp, *.gif, *.jpg)|*.bmp;*.gif;*.jpg"
            If saveDLG.ShowDialog = DialogResult.OK Then

                If saveDLG.FileName.EndsWith("bmp") Then
                    pbCrop.Image.Save(saveDLG.FileName, ImageFormat.Bmp)

                ElseIf saveDLG.FileName.EndsWith("gif") Then
                    pbCrop.Image.Save(saveDLG.FileName, ImageFormat.Gif)
                Else
                    pbCrop.Image.Save(saveDLG.FileName, ImageFormat.Jpeg)

                End If
                saveDLG.Dispose()
            End If

        Catch exc As Exception
            MessageBox.Show(exc.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnCrop_Click(sender As Object, e As EventArgs) Handles btnCrop.Click
        Try
            If cropWidth < 1 Then
                MessageBox.Show("You need to first select what portion of the image to crop.", " No cropping Cordinates!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Dim rect As Rectangle = New Rectangle(cropX, cropY, cropWidth, cropHeight)
            Dim bit As Bitmap = New Bitmap(PictureBox1.Image, PictureBox1.Width, PictureBox1.Height)

            cropBitmap = New Bitmap(cropWidth, cropHeight)
            Dim g As Graphics = Graphics.FromImage(cropBitmap)
            g.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel)
            pbCrop.Image = cropBitmap

        Catch exc As Exception
            MessageBox.Show(exc.Message, " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
