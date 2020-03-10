Public Class OptionYesNoForm
    Dim X, Y As Integer
    Dim NewPoint As New System.Drawing.Point

    Private Sub Ljheader1_DoubleClick(sender As Object, e As EventArgs)
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        ElseIf Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub Ljheader1_MouseDown(sender As Object, e As MouseEventArgs)
        X = Control.MousePosition.X - Me.Location.X
        Y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Ljheader1_MouseMove(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            NewPoint = Control.MousePosition
            NewPoint.X -= (X)
            NewPoint.Y -= (Y)
            Me.Location = NewPoint
        End If
    End Sub

    Public YNoption As Boolean = False
    Private Sub OptionYesNoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        YNoption = False
        btnOk.Focus()
    End Sub

    Private Sub LjButtonEmboss1_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        YNoption = True
        Me.Close()
    End Sub

    Private Sub LjButtonEmboss2_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        YNoption = False
        Me.Close()
    End Sub

    Private Sub LjCloseButton1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Ljheader1_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class