Public Class ChangeConnectionForm

    Private Sub LoadSettings()
        txtdbname.Text = My.Settings.DBname
        txtport.Text = My.Settings.DBport
        txtserver.Text = My.Settings.DBserver
        DBName = My.Settings.DBname
        DBPort = My.Settings.DBport
        DBServer = My.Settings.DBserver
        txtusername.Text = My.Settings.DefaultUsername
        txtpassword.Text = My.Settings.DefaultPassword
    End Sub
  
    Private Sub ChangeConnectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadSettings()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            My.Settings.DefaultUsername = txtusername.Text
            My.Settings.DefaultPassword = txtpassword.Text
            My.Settings.DBname = txtdbname.Text
            My.Settings.DBport = txtport.Text
            My.Settings.DBserver = txtserver.Text
            Call LoadSettings()
            MsgBox("Connection successfully saved")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtserver_TextChanged(sender As Object, e As EventArgs) Handles txtserver.TextChanged

    End Sub
End Class