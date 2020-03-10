Public Class HistoryLogForm

    Private Sub ListViewSize()
        With ListView1
            .Columns(0).Width = CInt(ListView1.Width) * 0.1
            .Columns(1).Width = CInt(ListView1.Width) * 0.25
            .Columns(2).Width = CInt(ListView1.Width) * 0.4
            .Columns(3).Width = CInt(ListView1.Width) * 0.24
        End With
    End Sub

    Dim ct As Integer = 0
    Dim type As String = " where DATE(logtime) = CURRENT_DATE "
    Dim sorttyp As String = " order by logno asc"
    Private Sub loadhistroy()
        Call defaultselectdata("Select * from historylog " & type & sorttyp)
        ListView1.Items.Clear()
        While Defaultsqldr.Read
            With ListView1
                .Items.Add(Defaultsqldr(0))
                With .Items(.Items.Count - 1).SubItems
                    .Add(Defaultsqldr(1))
                    .Add(Defaultsqldr(2))
                    .Add(Defaultsqldr(3))
                End With
            End With
        End While
        Call Defaultsqlclose()
        Call defaultselectdata("Select count(*) as nooflog from historylog " & type)
        Defaultsqldr.Read()
        If Defaultsqldr.HasRows Then
            ct = CInt(Defaultsqldr(0))
        End If
        Call Defaultsqlclose()
        Timer1.Start()
    End Sub

    Private Sub HistoryLogForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ListViewSize()
        Call loadhistroy()
    End Sub

    Private Sub HistoryLogForm_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Call ListViewSize()
    End Sub

    Private Sub TodayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ctxtoday.Click
        Try
            type = " where DATE(logtime) = CURRENT_DATE "
            Timer1.Stop()
            Call loadhistroy()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ctxall.Click
        Try
            type = ""
            Timer1.Stop()
            Call loadhistroy()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If type = "" Then
            ctxall.Checked = True
            ctxtoday.Checked = False
        Else
            ctxall.Checked = False
            ctxtoday.Checked = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Call defaultselectdata("Select count(*) as nooflog from historylog " & type)
            Defaultsqldr.Read()
            If CInt(Defaultsqldr(0)) > ct Then
                ct = CInt(Defaultsqldr(0))
                If type = "" Then
                    Call defaultselectdata("Select * from historylog where logno = (select max(logno) from historylog)")
                Else
                    Call defaultselectdata("Select * from historylog " & type & " and logno = (select max(logno) from historylog)")
                End If
                Defaultsqldr.Read()
                With ListView1
                    .Items.Add(Defaultsqldr(0))
                    With .Items(.Items.Count - 1).SubItems
                        .Add(Defaultsqldr(1))
                        .Add(Defaultsqldr(2))
                        .Add(CDate(Defaultsqldr(3)).ToString)
                    End With
                End With
            End If
            Call Defaultsqlclose()
        Catch ex As Exception

        End Try
    End Sub
End Class