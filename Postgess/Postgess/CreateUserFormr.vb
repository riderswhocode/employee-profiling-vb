Public Class CreateUserForm
    Private Sub loadUsers()
        ListView1.Items.Clear()
        Dim qry As String = "Select * from UsersTable"
        Call selectdata(qry)
        While sqldr.Read
            With ListView1
                .Items.Add(sqldr(0).ToString)
                With .Items(.Items.Count - 1).SubItems
                    .Add(sqldr(1).ToString)
                    .Add(sqldr(2).ToString)
                    .Add(sqldr(3).ToString)
                    .Add(sqldr(4).ToString)
                    .Add(sqldr(5).ToString)
                    .Add(sqldr(6).ToString)
                End With
            End With
        End While
        Call sqlclose()
    End Sub

    Dim Userlevel As String = ""
    Dim Allpri As String = ""
    Dim createpri As String = ""
    Dim withgrantoptionpri As String = ""

    Private Sub clearingfield()
        txtname.Text = ""
        txtusername.Text = ""
        txtPassword.Text = ""
        RadUser.Checked = True
        chxAll.Checked = False
        chxWithGrantOption.Checked = False
        chxCreate.Checked = False
        'txtField.Text = ""
        SavingStatus = "Save"
    End Sub

    Dim SavingStatus As String = "Save"

    Private Sub checkfields()
        If txtname.Text = "" Or txtusername.Text = "" Or txtPassword.Text = "" Or txtname.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If RadUser.Checked = False Then
                Userlevel = "Super User"
            Else
                Userlevel = "User"
            End If

            If chxAll.Checked = True Then
                Allpri = "True"
            Else
                Allpri = "False"
            End If

            If chxCreate.Checked = False Then
                createpri = "False"
            Else
                createpri = "True"
            End If

            If chxWithGrantOption.Checked = False Then
                withgrantoptionpri = "False"
            Else
                withgrantoptionpri = "True"
            End If

            If SavingStatus = "Save" Then
                Call insert("INSERT INTO public.userstable(Fullname, username, pass, userlevel, allpri, createpri,  withgrantoptionpri) VALUES ('" &
                            txtname.Text & "','" & txtusername.Text & "','" & EncryptData(txtPassword.Text) & "','" &
                             Userlevel & "','" & Allpri & "','" & createpri & "','" & withgrantoptionpri & "');" & lblQuery.Text)
                Call InsertLog("Created an account for " & txtname.Text)
                MsgBox("User account successfully created!")
            Else
                CreateUserQuery = "Revoke all on schema public from " & updatevalue & ";"
                If RadUser.Checked = True Then
                    If chxAll.Checked = True Then
                        GrantUserQuery1 = "GRANT All ON SCHEMA public TO " & txtusername.Text & " " & withgrantoptionpri1 & ";"
                    Else
                        GrantUserQuery1 = "GRANT " & createpri1 & " usage ON SCHEMA public TO " & txtusername.Text & " " & withgrantoptionpri1 & ";"
                    End If
                Else
                    GrantUserQuery1 = "GRANT All ON SCHEMA public TO " & txtusername.Text & " " & withgrantoptionpri1 & ";"
                End If

                If updatevalue = txtusername.Text Then
                    Call insert("Revoke all on schema public from " & updatevalue & ";" &
                           "update userstable  set Fullname = '" & txtname.Text.Replace("'", "\'") & "', username = '" & txtusername.Text & "',pass='" & EncryptData(txtPassword.Text) & "',userlevel = '" &
                            Userlevel & "',allpri = '" & Allpri & "',createpri = '" & createpri & "',withgrantoptionpri = '" & withgrantoptionpri & "' where username = '" & updatevalue & "';" &
                           " ALTER ROLE " & txtusername.Text & " login PASSWORD '" & txtPassword.Text & "';" & GrantUserQuery1)
                Else
                    Call insert("Revoke all on schema public from " & updatevalue & ";" &
                             "update userstable  set Fullname = '" & txtname.Text.Replace("'", "\'") & "', username = '" & txtusername.Text & "',pass='" & EncryptData(txtPassword.Text) & "',userlevel = '" &
                              Userlevel & "',allpri = '" & Allpri & "',createpri = '" & createpri & "',withgrantoptionpri = '" & withgrantoptionpri & "' where username = '" & updatevalue & "';" &
                             " ALTER ROLE " & updatevalue & " RENAME TO " & txtusername.Text & ";" &
                             " ALTER ROLE " & txtusername.Text & " login PASSWORD '" & txtPassword.Text & "';" & GrantUserQuery1)
                End If
                Call InsertLog("Modifying the account of " & txtname.Text)
                MsgBox("User account successfully updated!")
            End If
            Call clearingfield()
            Call loadUsers()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Dim Allpri1 As String = ""
    Dim withgrantoptionpri1 As String = ""

    Dim CreateUserQuery As String = ""
    Dim GrantUserQuery1 As String = ""
    Private Sub BuildQuery()
        If SavingStatus = "Save" Then
            If RadUser.Checked = True Then
                CreateUserQuery = "Create user " & txtusername.Text & " login password '" & txtPassword.Text & "' valid until 'infinity';"
                If chxAll.Checked = True Then
                    GrantUserQuery1 = "GRANT All ON SCHEMA public TO " & txtusername.Text & " " & withgrantoptionpri1 & ";"
                Else
                    GrantUserQuery1 = "GRANT " & createpri1 & " usage ON SCHEMA public TO " & txtusername.Text & " " & withgrantoptionpri1 & ";"
                End If
            Else
                CreateUserQuery = "Create user " & txtusername.Text & " login password '" & txtPassword.Text & "' superuser inherit valid until 'infinity';"
                GrantUserQuery1 = "GRANT All ON SCHEMA public TO " & txtusername.Text & " " & withgrantoptionpri1 & ";"
            End If
        Else
            CreateUserQuery = "Revoke all on schema public from " & updatevalue & ";"
            If RadUser.Checked = True Then
                If chxAll.Checked = True Then
                    GrantUserQuery1 = "GRANT All ON SCHEMA public TO " & txtusername.Text & " " & withgrantoptionpri1 & ";"
                Else
                    GrantUserQuery1 = "GRANT " & createpri1 & " usage ON SCHEMA public TO " & txtusername.Text & " " & withgrantoptionpri1 & ";"
                End If
            Else
                GrantUserQuery1 = "GRANT All ON SCHEMA public TO " & txtusername.Text & " " & withgrantoptionpri1 & ";"
            End If
        End If
        lblQuery.Text = CreateUserQuery & " " & GrantUserQuery1
    End Sub

    Private Sub Create_User_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frm_Profiling.Show()
    End Sub
    Public Sub Form_size()
        Dim ScreenSize As System.Drawing.Rectangle = Screen.PrimaryScreen.WorkingArea
        Me.Size = New System.Drawing.Size(ScreenSize.Width, ScreenSize.Height)
        Me.Location = New System.Drawing.Point(0, 0)
    End Sub
    Private Sub Create_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Call loadUsers()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Call Form_size()
    End Sub

    Dim updatevalue As String = ""
    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Try
            Call selectdata("select * from userstable where username = '" & ListView1.FocusedItem.SubItems(1).Text & "'")
            sqldr.Read()
            If sqldr.HasRows Then
                SavingStatus = "Update"
                txtname.Text = ListView1.FocusedItem.SubItems(0).Text
                updatevalue = ListView1.FocusedItem.SubItems(1).Text
                txtusername.Text = ListView1.FocusedItem.SubItems(1).Text
                txtPassword.Text = DecryptData(ListView1.FocusedItem.SubItems(2).Text)
                If ListView1.FocusedItem.SubItems(3).Text = "User" Then
                    RadUser.Checked = True
                Else
                    RadSuperuser.Checked = True
                End If
                chxAll.Checked = CBool(ListView1.FocusedItem.SubItems(4).Text)
                chxCreate.Checked = CBool(ListView1.FocusedItem.SubItems(5).Text)
                chxWithGrantOption.Checked = CBool(ListView1.FocusedItem.SubItems(7).Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Dim createpri1 As String = ""
    Private Sub chxCreate_CheckedChanged(sender As Object, e As EventArgs) Handles chxCreate.CheckedChanged
        If chxCreate.Checked = False Then
            createpri1 = ""
        Else
            createpri1 = " create,"
        End If
        Call BuildQuery()
    End Sub

    Private Sub chxWithGrantOption_CheckedChanged(sender As Object, e As EventArgs) Handles chxWithGrantOption.CheckedChanged
        If chxWithGrantOption.Checked = False Then
            withgrantoptionpri1 = ""
        Else
            withgrantoptionpri1 = " with grant option"
        End If
        Call BuildQuery()
    End Sub

    Private Sub RadUser_CheckedChanged(sender As Object, e As EventArgs) Handles RadUser.CheckedChanged
        Call BuildQuery()
    End Sub

    Private Sub RadSuperuser_CheckedChanged(sender As Object, e As EventArgs) Handles RadSuperuser.CheckedChanged
        Call BuildQuery()
    End Sub

    Private Sub chxAll_CheckedChanged(sender As Object, e As EventArgs) Handles chxAll.CheckedChanged
        Call BuildQuery()
    End Sub

    Private Sub txtusername_TextChanged(sender As Object, e As EventArgs) Handles txtusername.TextChanged
        checkfields()
        Call BuildQuery()
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        checkfields()
        Call BuildQuery()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            'REVOKE ALL ON SCHEMA public FROM jl;

            Call insert("Delete from userstable where username = '" & ListView1.FocusedItem.SubItems(1).Text &
                        "'; Revoke all on schema public from " & ListView1.FocusedItem.SubItems(1).Text & ";" &
                        "Drop role " & ListView1.FocusedItem.SubItems(1).Text & ";")
            Call loadUsers()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call clearingfield()
    End Sub


    Private Sub txtemployeeid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtname.KeyPress

    End Sub

    Private Sub txtemployeeid_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
        checkfields()
    End Sub

    Private Sub CreateRoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateRoleToolStripMenuItem.Click
        Try
            CreateRoleForm.lblusername.Text = ListView1.FocusedItem.SubItems(1).Text
            CreateRoleForm.LoadRoles()
            CreateRoleForm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class