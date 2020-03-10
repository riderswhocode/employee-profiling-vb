Public Class PrintForm
    Public Sub LoadReport(a As Integer)
        If a = 1 Then
            Me.ReportViewer2.Visible = False
            Me.ReportViewer3.Visible = False
            Me.ReportViewer4.Visible = False
            Me.ReportViewer1.Visible = True
            Me.ReportViewer1.Dock = DockStyle.Fill
            Me.ReportViewer1.RefreshReport()
        ElseIf a = 2 Then
            Me.ReportViewer1.Visible = False
            Me.ReportViewer3.Visible = False
            Me.ReportViewer4.Visible = False
            Me.ReportViewer2.Visible = True
            Me.ReportViewer2.Dock = DockStyle.Fill
            Me.ReportViewer2.RefreshReport()
        ElseIf a = 3 Then
            Me.ReportViewer2.Visible = False
            Me.ReportViewer1.Visible = False
            Me.ReportViewer4.Visible = False
            Me.ReportViewer3.Visible = True
            Me.ReportViewer3.Dock = DockStyle.Fill
            Me.ReportViewer3.RefreshReport()
        ElseIf a = 4 Then
            Me.ReportViewer2.Visible = False
            Me.ReportViewer3.Visible = False
            Me.ReportViewer1.Visible = False
            Me.ReportViewer4.Visible = True
            Me.ReportViewer4.Dock = DockStyle.Fill
            Me.ReportViewer4.RefreshReport()
        End If
    End Sub

    Private Sub PrintForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ReportViewer4_Load(sender As Object, e As EventArgs) Handles ReportViewer4.Load

    End Sub
End Class