Imports System.Drawing.Drawing2D

Class ljTabcontrolVerticalWA
    Inherits TabControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(44, 136)
    End Sub
    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Left
    End Sub

    Function ToPen(ByVal color As Color) As Pen
        Return New Pen(color)
    End Function

    Function ToBrush(ByVal color As Color) As Brush
        Return New SolidBrush(color)
    End Function

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Try : SelectedTab.BackColor = Color.White : Catch : End Try
        G.Clear(Color.White)
        G.FillRectangle(New SolidBrush(Color.FromArgb(246, 248, 252)), New Rectangle(0, 0, ItemSize.Height + 4, Height))
        G.DrawLine(New Pen(Color.FromArgb(170, 187, 204)), New Point(ItemSize.Height + 3, 0), New Point(ItemSize.Height + 3, 999))
        For i = 0 To TabCount - 1
            If i = SelectedIndex Then
                Dim x2 As Rectangle = New Rectangle(New Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), New Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1))
                Dim myBlend As New ColorBlend()
                myBlend.Colors = {Color.FromArgb(232, 232, 240), Color.FromArgb(232, 232, 240), Color.FromArgb(232, 232, 240)}
                myBlend.Positions = {0.0F, 0.5F, 1.0F}
                Dim lgBrush As New LinearGradientBrush(x2, Color.Black, Color.Black, 90.0F)
                lgBrush.InterpolationColors = myBlend
                G.FillRectangle(lgBrush, x2)
                G.DrawRectangle(New Pen(Color.FromArgb(170, 187, 204)), x2)

                G.SmoothingMode = SmoothingMode.HighQuality
                Dim p() As Point = {New Point(ItemSize.Height - 3, GetTabRect(i).Location.Y + 20), New Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 14), New Point(ItemSize.Height + 4, GetTabRect(i).Location.Y + 27)}
                G.FillPolygon(Brushes.White, p)
                G.DrawPolygon(New Pen(Color.FromArgb(170, 187, 204)), p)

                If ImageList IsNot Nothing Then
                    Try
                        If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then

                            G.DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(x2.Location.X + 8, x2.Location.Y + 6))
                            G.DrawString("  " & TabPages(i).Text, Font, Brushes.Black, x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                        Else
                            G.DrawString(TabPages(i).Text, New Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.Black, x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                        End If
                    Catch ex As Exception
                        G.DrawString(TabPages(i).Text, New Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.Black, x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                    End Try
                Else
                    G.DrawString(TabPages(i).Text, New Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.Black, x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                End If

                G.DrawLine(New Pen(Color.FromArgb(200, 200, 250)), New Point(x2.Location.X - 1, x2.Location.Y - 1), New Point(x2.Location.X, x2.Location.Y))
                G.DrawLine(New Pen(Color.FromArgb(200, 200, 250)), New Point(x2.Location.X - 1, x2.Bottom - 1), New Point(x2.Location.X, x2.Bottom))
            Else
                Dim x2 As Rectangle = New Rectangle(New Point(GetTabRect(i).Location.X - 2, GetTabRect(i).Location.Y - 2), New Size(GetTabRect(i).Width + 3, GetTabRect(i).Height - 1))
                G.FillRectangle(New SolidBrush(Color.FromArgb(246, 248, 252)), x2)
                G.DrawLine(New Pen(Color.FromArgb(170, 187, 204)), New Point(x2.Right, x2.Top), New Point(x2.Right, x2.Bottom))
                If ImageList IsNot Nothing Then
                    Try
                        If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                            G.DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(x2.Location.X + 8, x2.Location.Y + 6))
                            G.DrawString("  " & TabPages(i).Text, Font, Brushes.DimGray, x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                        Else
                            G.DrawString(TabPages(i).Text, Font, Brushes.DimGray, x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                        End If
                    Catch ex As Exception
                        G.DrawString(TabPages(i).Text, Font, Brushes.DimGray, x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                    End Try
                Else
                    G.DrawString(TabPages(i).Text, Font, Brushes.DimGray, x2, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                End If
            End If
        Next

        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose() : B.Dispose()
    End Sub

    Dim OldIndex As Integer

    Private _Speed As Integer = 5
    Property Speed As Integer
        Get
            Return _Speed
        End Get
        Set(value As Integer)
            If value > 20 Or value < -20 Then
                MsgBox("Speed needs to be in between -20 and 20.")
            Else
                _Speed = value
            End If
        End Set
    End Property

    Sub DoAnimationScrollLeft(ByVal Control1 As Control, Control2 As Control)
        Dim G As Graphics = Control1.CreateGraphics()
        Dim P1 As New Bitmap(Control1.Width, Control1.Height)
        Dim P2 As New Bitmap(Control2.Width, Control2.Height)
        Control1.DrawToBitmap(P1, New Rectangle(0, 0, Control1.Width, Control1.Height))
        Control2.DrawToBitmap(P2, New Rectangle(0, 0, Control2.Width, Control2.Height))

        For Each c As Control In Control1.Controls
            c.Hide()
        Next

        Dim Slide As Integer = Control1.Width - (Control1.Width Mod _Speed)

        Dim a As Integer
        For a = 0 To Slide Step _Speed
            G.DrawImage(P1, New Rectangle(a, 0, Control1.Width, Control1.Height))
            G.DrawImage(P2, New Rectangle(a - Control2.Width, 0, Control2.Width, Control2.Height))
        Next
        a = Control1.Width
        G.DrawImage(P1, New Rectangle(a, 0, Control1.Width, Control1.Height))
        G.DrawImage(P2, New Rectangle(a - Control2.Width, 0, Control2.Width, Control2.Height))

        SelectedTab = Control2

        For Each c As Control In Control2.Controls
            c.Show()
        Next

        For Each c As Control In Control1.Controls
            c.Show()
        Next
    End Sub

    Protected Overrides Sub OnSelecting(e As System.Windows.Forms.TabControlCancelEventArgs)
        If OldIndex < e.TabPageIndex Then
            DoAnimationScrollRight(TabPages(OldIndex), TabPages(e.TabPageIndex))
        Else
            DoAnimationScrollLeft(TabPages(OldIndex), TabPages(e.TabPageIndex))
        End If
    End Sub

    Protected Overrides Sub OnDeselecting(e As System.Windows.Forms.TabControlCancelEventArgs)
        OldIndex = e.TabPageIndex
    End Sub

    Sub DoAnimationScrollRight(ByVal Control1 As Control, Control2 As Control)
        Dim G As Graphics = Control1.CreateGraphics()
        Dim P1 As New Bitmap(Control1.Width, Control1.Height)
        Dim P2 As New Bitmap(Control2.Width, Control2.Height)
        Control1.DrawToBitmap(P1, New Rectangle(0, 0, Control1.Width, Control1.Height))
        Control2.DrawToBitmap(P2, New Rectangle(0, 0, Control2.Width, Control2.Height))

        For Each c As Control In Control1.Controls
            c.Hide()
        Next

        Dim Slide As Integer = Control1.Width - (Control1.Width Mod _Speed)

        Dim a As Integer
        For a = 0 To -Slide Step -_Speed
            G.DrawImage(P1, New Rectangle(a, 0, Control1.Width, Control1.Height))
            G.DrawImage(P2, New Rectangle(a + Control2.Width, 0, Control2.Width, Control2.Height))
        Next
        a = Control1.Width
        G.DrawImage(P1, New Rectangle(a, 0, Control1.Width, Control1.Height))
        G.DrawImage(P2, New Rectangle(a + Control2.Width, 0, Control2.Width, Control2.Height))

        SelectedTab = Control2

        For Each c As Control In Control2.Controls
            c.Show()
        Next

        For Each c As Control In Control1.Controls
            c.Show()
        Next
    End Sub
End Class
''====================

'============================================
Public Class ljTabcontrolVerticalNA
    Inherits TabControl

    Private G As Graphics
    Private Rect As Rectangle

    Sub New()
        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(30, 170)
        Alignment = TabAlignment.Left
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        G.Clear(Color.White)

        Using Right As New Pen(Color.FromArgb(211, 223, 229))
            G.DrawLine(Right, ItemSize.Height + 3, 4, ItemSize.Height + 3, Height)
        End Using

        For T As Integer = 0 To TabPages.Count - 1

            Rect = GetTabRect(T)

            If SelectedIndex = T Then

                Using TextBrush As New SolidBrush(Color.FromArgb(32, 32, 32)), TextFont As New Font("Verdana", 10)
                    G.DrawString(TabPages(T).Text, TextFont, TextBrush, New Point(Rect.X + 45, Rect.Y + 7))
                End Using

            Else

                Using TextBrush As New SolidBrush(Color.FromArgb(129, 129, 129)), TextFont As New Font("Verdana", 10)
                    G.DrawString(TabPages(T).Text, TextFont, TextBrush, New Point(Rect.X + 45, Rect.Y + 7))
                End Using

            End If

            If Not IsNothing(ImageList) Then
                If Not TabPages(T).ImageIndex < 0 Then
                    G.DrawImage(ImageList.Images(TabPages(T).ImageIndex), New Rectangle(Rect.X + 20, Rect.Y + 7, 16, 16))
                End If
            End If

        Next

        MyBase.OnPaint(e)
    End Sub

End Class

'=========================================
'============
Public Class ljTabcontrolHorizontal
    Inherits TabControl
    Dim OldIndex As Integer

    Private _Speed As Integer = 9
    Property Speed As Integer
        Get
            Return _Speed
        End Get
        Set(value As Integer)
            If value > 20 Or value < -20 Then
                MsgBox("Speed needs to be in between -20 and 20.")
            Else
                _Speed = value
            End If
        End Set
    End Property

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
    End Sub

    Sub DoAnimationScrollLeft(ByVal Control1 As Control, Control2 As Control)
        Dim G As Graphics = Control1.CreateGraphics()
        Dim P1 As New Bitmap(Control1.Width, Control1.Height)
        Dim P2 As New Bitmap(Control2.Width, Control2.Height)
        Control1.DrawToBitmap(P1, New Rectangle(0, 0, Control1.Width, Control1.Height))
        Control2.DrawToBitmap(P2, New Rectangle(0, 0, Control2.Width, Control2.Height))

        For Each c As Control In Control1.Controls
            c.Hide()
        Next

        Dim Slide As Integer = Control1.Width - (Control1.Width Mod _Speed)

        Dim a As Integer
        For a = 0 To Slide Step _Speed
            G.DrawImage(P1, New Rectangle(a, 0, Control1.Width, Control1.Height))
            G.DrawImage(P2, New Rectangle(a - Control2.Width, 0, Control2.Width, Control2.Height))
        Next
        a = Control1.Width
        G.DrawImage(P1, New Rectangle(a, 0, Control1.Width, Control1.Height))
        G.DrawImage(P2, New Rectangle(a - Control2.Width, 0, Control2.Width, Control2.Height))

        SelectedTab = Control2

        For Each c As Control In Control2.Controls
            c.Show()
        Next

        For Each c As Control In Control1.Controls
            c.Show()
        Next
    End Sub

    Protected Overrides Sub OnSelecting(e As System.Windows.Forms.TabControlCancelEventArgs)
        If OldIndex < e.TabPageIndex Then
            DoAnimationScrollRight(TabPages(OldIndex), TabPages(e.TabPageIndex))
        Else
            DoAnimationScrollLeft(TabPages(OldIndex), TabPages(e.TabPageIndex))
        End If
    End Sub

    Protected Overrides Sub OnDeselecting(e As System.Windows.Forms.TabControlCancelEventArgs)
        OldIndex = e.TabPageIndex
    End Sub

    Sub DoAnimationScrollRight(ByVal Control1 As Control, Control2 As Control)
        Dim G As Graphics = Control1.CreateGraphics()
        Dim P1 As New Bitmap(Control1.Width, Control1.Height)
        Dim P2 As New Bitmap(Control2.Width, Control2.Height)
        Control1.DrawToBitmap(P1, New Rectangle(0, 0, Control1.Width, Control1.Height))
        Control2.DrawToBitmap(P2, New Rectangle(0, 0, Control2.Width, Control2.Height))

        For Each c As Control In Control1.Controls
            c.Hide()
        Next

        Dim Slide As Integer = Control1.Width - (Control1.Width Mod _Speed)

        Dim a As Integer
        For a = 0 To -Slide Step -_Speed
            G.DrawImage(P1, New Rectangle(a, 0, Control1.Width, Control1.Height))
            G.DrawImage(P2, New Rectangle(a + Control2.Width, 0, Control2.Width, Control2.Height))
        Next
        a = Control1.Width
        G.DrawImage(P1, New Rectangle(a, 0, Control1.Width, Control1.Height))
        G.DrawImage(P2, New Rectangle(a + Control2.Width, 0, Control2.Width, Control2.Height))

        SelectedTab = Control2

        For Each c As Control In Control2.Controls
            c.Show()
        Next

        For Each c As Control In Control1.Controls
            c.Show()
        Next
    End Sub

End Class

''++++++++
''=============================================================================================

Class TransparentControl
    Inherits Control

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub
End Class
Class ljTransparentRichTextBox
    Inherits RichTextBox

    Public Sub New()
        MyBase.New()
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = (cp.ExStyle Or 32)
            Return cp
        End Get
    End Property

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)

    End Sub
End Class

Class ljButtonEmboss
    Inherits Button

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.BackgroundImage = My.Resources.ButtonStyle1
        MyBase.BackgroundImageLayout = ImageLayout.Stretch
        MyBase.FlatStyle = Windows.Forms.FlatStyle.Flat
        MyBase.FlatAppearance.BorderSize = 0
        MyBase.FlatAppearance.MouseDownBackColor = Color.Transparent
        MyBase.FlatAppearance.MouseOverBackColor = Color.Transparent
        MyBase.ForeColor = Color.White
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.ButtonStyle1
        Refresh()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.ButtonStyle2
        Refresh()
    End Sub

    'Protected Overrides ReadOnly Property CreateParams As CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ExStyle = (cp.ExStyle Or 32)
    '        Return cp
    '    End Get
    'End Property
End Class

Class ljBigButton
    Inherits Button

    Public Sub New()
        MyBase.New()
        MyBase.BackgroundImage = My.Resources.Header3
        MyBase.BackgroundImageLayout = ImageLayout.Stretch
        MyBase.FlatStyle = Windows.Forms.FlatStyle.Flat
        MyBase.FlatAppearance.BorderSize = 1
        MyBase.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255)
        MyBase.FlatAppearance.MouseDownBackColor = Color.Transparent
        MyBase.FlatAppearance.MouseOverBackColor = Color.Transparent
        MyBase.ForeColor = Color.FromArgb(28, 78, 99)
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.Width = 250
        MyBase.Height = 100
        MyBase.Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.Header3
        MyBase.ForeColor = Color.FromArgb(28, 78, 99)
        Refresh()
    End Sub

    Protected Overrides Sub Onclick(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.ButtonBack3
        MyBase.ForeColor = Color.FromArgb(28, 78, 99)
        Refresh()
    End Sub


    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.ButtonBack1
        MyBase.ForeColor = Color.FromArgb(28, 78, 99)
        Refresh()
    End Sub

    'Protected Overrides ReadOnly Property CreateParams As CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ExStyle = (cp.ExStyle Or 32)
    '        Return cp
    '    End Get
    'End Property
End Class

Class ljTextBox
    Inherits TextBox

    Public Sub New()
        MyBase.New()
        MyBase.ForeColor = Color.FromArgb(28, 78, 99)
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.BorderStyle = Windows.Forms.BorderStyle.None
        MyBase.BackColor = Color.White
    End Sub

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)
        MyBase.ForeColor = Color.Black
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Regular)
        MyBase.BackColor = Color.White
        Refresh()
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)
        MyBase.ForeColor = Color.FromArgb(28, 78, 99)
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.BackColor = Color.White
        Refresh()
    End Sub
End Class

Class ljTealTexBox
    Inherits TextBox

    Public Sub New()
        MyBase.New()
        MyBase.ForeColor = Color.White
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.BorderStyle = Windows.Forms.BorderStyle.None
        MyBase.BackColor = Color.Teal
    End Sub

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)
        MyBase.ForeColor = Color.Black
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Regular)
        MyBase.BackColor = Color.White
        Refresh()
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)
        MyBase.ForeColor = Color.White
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.BackColor = Color.Teal
        Refresh()
    End Sub
End Class


Class ljLeftButton
    Inherits Button

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.BackgroundImage = My.Resources.i_shapeB3
        MyBase.BackgroundImageLayout = ImageLayout.Stretch
        MyBase.FlatStyle = Windows.Forms.FlatStyle.Flat
        MyBase.FlatAppearance.BorderSize = 0
        MyBase.FlatAppearance.MouseDownBackColor = Color.Transparent
        MyBase.FlatAppearance.MouseOverBackColor = Color.Transparent
        MyBase.ForeColor = Color.White
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.i_shapeB3
        Refresh()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.i_shapeB4
        Refresh()
    End Sub

    'Protected Overrides ReadOnly Property CreateParams As CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ExStyle = (cp.ExStyle Or 32)
    '        Return cp
    '    End Get
    'End Property
End Class

Class ljRightButton
    Inherits Button

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.BackgroundImage = My.Resources.i_shapeB1
        MyBase.BackgroundImageLayout = ImageLayout.Stretch
        MyBase.FlatStyle = Windows.Forms.FlatStyle.Flat
        MyBase.FlatAppearance.BorderSize = 0
        MyBase.FlatAppearance.MouseDownBackColor = Color.Transparent
        MyBase.FlatAppearance.MouseOverBackColor = Color.Transparent
        MyBase.ForeColor = Color.White
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.i_shapeB1
        Refresh()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.i_shapeB2
        Refresh()
    End Sub

    'Protected Overrides ReadOnly Property CreateParams As CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ExStyle = (cp.ExStyle Or 32)
    '        Return cp
    '    End Get
    'End Property
End Class

Class ljTopRightButton
    Inherits Button

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.BackgroundImage = My.Resources.i_TopRight1
        MyBase.BackgroundImageLayout = ImageLayout.Stretch
        MyBase.FlatStyle = Windows.Forms.FlatStyle.Flat
        MyBase.FlatAppearance.BorderSize = 0
        MyBase.FlatAppearance.MouseDownBackColor = Color.Transparent
        MyBase.FlatAppearance.MouseOverBackColor = Color.Transparent
        MyBase.ForeColor = Color.White
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.i_TopRight1
        Refresh()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.i_TopRight2
        Refresh()
    End Sub

    'Protected Overrides ReadOnly Property CreateParams As CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ExStyle = (cp.ExStyle Or 32)
    '        Return cp
    '    End Get
    'End Property
End Class

Class ljTopLefttButton
    Inherits Button

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.BackgroundImage = My.Resources.i_TopLeft1
        MyBase.BackgroundImageLayout = ImageLayout.Stretch
        MyBase.FlatStyle = Windows.Forms.FlatStyle.Flat
        MyBase.FlatAppearance.BorderSize = 0
        MyBase.FlatAppearance.MouseDownBackColor = Color.Transparent
        MyBase.FlatAppearance.MouseOverBackColor = Color.Transparent
        MyBase.ForeColor = Color.White
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.i_TopLeft1
        Refresh()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.i_TopLeft2
        Refresh()
    End Sub

    'Protected Overrides ReadOnly Property CreateParams As CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ExStyle = (cp.ExStyle Or 32)
    '        Return cp
    '    End Get
    'End Property
End Class

Class ljButtonFlat
    Inherits Button

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.BackgroundImage = My.Resources.FlatButtonStyle1
        MyBase.BackgroundImageLayout = ImageLayout.Stretch
        MyBase.FlatStyle = Windows.Forms.FlatStyle.Flat
        MyBase.FlatAppearance.BorderSize = 0
        MyBase.FlatAppearance.MouseDownBackColor = Color.Transparent
        MyBase.FlatAppearance.MouseOverBackColor = Color.Transparent
        MyBase.ForeColor = Color.White
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.Cursor = Cursors.Hand
    End Sub

    'Protected Overrides Sub OnMouseLeave(e As EventArgs)
    '    MyBase.OnMouseLeave(e)
    '    MyBase.BackgroundImage = My.Resources.FlatButtonStyle1
    '    Refresh()
    'End Sub

    'Protected Overrides Sub OnMouseEnter(e As EventArgs)
    '    MyBase.OnMouseLeave(e)
    '    MyBase.BackgroundImage = My.Resources.FlatButtonStyle3
    '    Refresh()
    'End Sub

    'Protected Overrides ReadOnly Property CreateParams As CreateParams
    '    Get
    '        Dim cp As CreateParams = MyBase.CreateParams
    '        cp.ExStyle = (cp.ExStyle Or 32)
    '        Return cp
    '    End Get
    'End Property
End Class

Class ljBF
    Inherits Button

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.BackgroundImage = My.Resources.FlatButtonStyle1
        MyBase.BackgroundImageLayout = ImageLayout.Stretch
        MyBase.FlatStyle = Windows.Forms.FlatStyle.Flat
        MyBase.FlatAppearance.BorderSize = 0
        MyBase.FlatAppearance.MouseDownBackColor = Color.Transparent
        MyBase.FlatAppearance.MouseOverBackColor = Color.Transparent
        MyBase.ForeColor = Color.White
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.FlatButtonStyle1
        Refresh()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.FlatButtonStyle3
        Refresh()
    End Sub

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = (cp.ExStyle Or 32)
            Return cp
        End Get
    End Property
End Class


Class ljheader
    Inherits Panel

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.BackgroundImage = My.Resources.HeaderStyle6
        MyBase.BackgroundImageLayout = ImageLayout.Stretch
    End Sub
End Class

Class ljControlHeader
    Inherits Panel

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.BackgroundImage = My.Resources.HeaderStyle6
        MyBase.BackgroundImageLayout = ImageLayout.Stretch
        Dim CB As New ljCloseButton
    End Sub
End Class



Class ljCloseButton
    Inherits Button

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.BackgroundImage = My.Resources.CloseButton3
        MyBase.BackgroundImageLayout = ImageLayout.Stretch
        MyBase.FlatStyle = Windows.Forms.FlatStyle.Flat
        MyBase.FlatAppearance.BorderSize = 0
        MyBase.FlatAppearance.MouseDownBackColor = Color.Transparent
        MyBase.FlatAppearance.MouseOverBackColor = Color.Transparent
        MyBase.ForeColor = Color.White
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.Cursor = Cursors.Hand
        MyBase.Size = New Size(42, 27)
        MyBase.Text = ""
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.CloseButton3
        Refresh()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.CloseButton2
        Refresh()
    End Sub

End Class

Class ljMinimizeButton
    Inherits Button

    Public Sub New()
        MyBase.New()
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.BackgroundImage = My.Resources.MinimizeButton1
        MyBase.BackgroundImageLayout = ImageLayout.Stretch
        MyBase.FlatStyle = Windows.Forms.FlatStyle.Flat
        MyBase.FlatAppearance.BorderSize = 0
        MyBase.FlatAppearance.MouseDownBackColor = Color.Transparent
        MyBase.FlatAppearance.MouseOverBackColor = Color.Transparent
        MyBase.ForeColor = Color.White
        MyBase.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        MyBase.Cursor = Cursors.Hand
        MyBase.Size = New Size(42, 27)
        MyBase.Text = ""
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.MinimizeButton1
        Refresh()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseLeave(e)
        MyBase.BackgroundImage = My.Resources.MinimizeButton2
        Refresh()
    End Sub

End Class

