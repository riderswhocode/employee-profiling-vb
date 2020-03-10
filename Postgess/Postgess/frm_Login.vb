Public Class frm_Login

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            LogUsername = TextBox1.Text
            LogPassword = TextBox2.Text
            Call DBConnection()
            Call DefaultDBConnection()
            Call defaultselectdata("Select Fullname from userstable where username = '" & LogUsername & "'")
            Defaultsqldr.Read()
            If Defaultsqldr.HasRows Then
                NameofUser = Defaultsqldr("fullname")
            End If
            Call Defaultsqlclose()
            Call InsertLog("Logged in")
            TextBox1.Text = ""
            TextBox2.Text = ""
            frm_Profiling.Show()
            Me.Hide()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub frm_Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sqlconn.Close()
    End Sub

    Private Sub frm_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ChangeConnectionForm.ShowDialog()
    End Sub
End Class
