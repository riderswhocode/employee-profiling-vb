Public Class CreateRoleForm

    Private Sub clearingfields()
        chxSelect.Checked = False
        chxInsert.Checked = False
        chxUpdate.Checked = False
        chxDelete.Checked = False
        chxTruncate.Checked = False
        chxWithGrantOption.Checked = False
    End Sub

    Dim savaingstatus As String = ""
    Public Sub LoadRoles()
        Call selectdata("SELECT username, field, selectpri, insertpri, updatepri, " &
                        "deletepri, truncatepri, withgrantoption FROM public.rolestable where username ='" & lblusername.Text & "' and field = '" & ComboBox1.Text & "';")
        sqldr.Read()
        If sqldr.HasRows Then
            savaingstatus = "Update"
            chxSelect.Checked = CBool(sqldr("selectpri"))
            chxInsert.Checked = CBool(sqldr("insertpri"))
            chxUpdate.Checked = CBool(sqldr("updatepri"))
            chxDelete.Checked = CBool(sqldr("deletepri"))
            chxTruncate.Checked = CBool(sqldr("truncatepri"))
            chxWithGrantOption.Checked = CBool(sqldr("withgrantoption"))
        Else
            savaingstatus = "Save"
            Call clearingfields()
        End If
        Call sqlclose()
    End Sub
    Private Sub CreateRoleForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call LoadRoles()
    End Sub

    Dim pri As String() = {"", "", "", "", ""}
    Dim selectpri As String = ""
    Dim insertpri As String = ""
    Dim updatepri As String = ""
    Dim deletepri As String = ""
    Dim truncatepri As String = ""
    Dim withgrantoptionpri As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If chxSelect.Checked = False Then
                selectpri = "False"
            Else
                selectpri = "True"
            End If

            If chxInsert.Checked = False Then
                insertpri = "False"
            Else
                insertpri = "True"
            End If

            If chxDelete.Checked = False Then
                deletepri = "False"
            Else
                deletepri = "True"
            End If

            If chxUpdate.Checked = False Then
                updatepri = "False"
            Else
                updatepri = "True"
            End If

            If chxTruncate.Checked = False Then
                truncatepri = "False"
            Else
                truncatepri = "True"
            End If

            If chxWithGrantOption.Checked = False Then
                withgrantoptionpri = "False"
            Else
                withgrantoptionpri = "True"
            End If

            Call selectdata("SELECT username, field, selectpri, insertpri, updatepri, " &
                                   "deletepri, truncatepri, withgrantoption FROM public.rolestable where username ='" & lblusername.Text & "' and field = '" & ComboBox1.Text & "';")
            sqldr.Read()
            If sqldr.HasRows Then
                Call insert("update public.rolestable set selectpri = '" & selectpri & "', insertpri ='" & insertpri & "' , updatepri = '" & updatepri &
                        "', deletepri = '" & deletepri & "', truncatepri = '" & truncatepri & "', withgrantoption = '" & withgrantoptionpri & "' where username = '" & lblusername.Text &
                        "' and field = '" & ComboBox1.Text & "'; " & " Revoke all privileges on " & ComboBox1.Text & " from " & lblusername.Text & "; " & grantqry)
                MsgBox("Role has been Changed")
            Else
                Call insert("INSERT INTO public.rolestable(username, field, selectpri, insertpri, updatepri, deletepri, truncatepri, withgrantoption) " &
                          "  VALUES ('" & lblusername.Text & "','" & ComboBox1.Text & "','" & selectpri &
                          "','" & insertpri & "','" & updatepri & "','" & deletepri & "','" & truncatepri & "' , '" & withgrantoptionpri & "'); " & grantqry)
                MsgBox("Role has been created")
            End If
            Call sqlclose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Dim revokeqry As String = ""
    Dim grantqry As String = ""
    Private Sub BuildQuery()
        Dim priquery As String = ""
        Dim maxv As Integer = 0
        Dim minv As Integer = 0
        Dim ct As Integer = 0
        For i As Integer = 0 To 4
            If pri(i) <> "" Then
                If ct = 0 Then
                    minv = i
                End If
                ct = ct + 1
                maxv = i
            End If
        Next
        If ct = 0 Then
            grantqry = ""
        ElseIf ct = 1 Then
            grantqry = "Grant " & pri(minv) & " on " & ComboBox1.Text & " to " & lblusername.Text & " " & withgrantoptionpri1 & ";"
        ElseIf ct > 1 Then
            For i As Integer = minv To maxv
                If i < maxv Then
                    If pri(i) <> "" Then
                        priquery = priquery + pri(i) + ","
                    End If
                Else
                    priquery = priquery + pri(i)
                End If
            Next
            grantqry = "Grant " & priquery & " on " & ComboBox1.Text & " to " & lblusername.Text & " " & withgrantoptionpri1 & ";"
        End If
        If savaingstatus = "Update" Then
            revokeqry = "Revoke all privileges on " & ComboBox1.Text & " from " & lblusername.Text & ";"
        Else
            revokeqry = ""
        End If
        Label3.Text = revokeqry & " " & grantqry
    End Sub
    Private Sub chxSelect_CheckedChanged(sender As Object, e As EventArgs) Handles chxSelect.CheckedChanged
        If chxSelect.Checked = False Then
            pri(0) = ""
        Else
            pri(0) = "select"
        End If
        Call BuildQuery()
    End Sub

    Private Sub chxInsert_CheckedChanged(sender As Object, e As EventArgs) Handles chxInsert.CheckedChanged
        If chxInsert.Checked = False Then
            pri(1) = ""
        Else
            pri(1) = "insert"
        End If
        Call BuildQuery()
    End Sub

    Private Sub chxUpdate_CheckedChanged(sender As Object, e As EventArgs) Handles chxUpdate.CheckedChanged
        If chxUpdate.Checked = False Then
            pri(2) = ""
        Else
            pri(2) = "update"
        End If
        Call BuildQuery()
    End Sub

    Private Sub chxDelete_CheckedChanged(sender As Object, e As EventArgs) Handles chxDelete.CheckedChanged
        If chxDelete.Checked = False Then
            pri(3) = ""
        Else
            pri(3) = "delete"
        End If
        Call BuildQuery()
    End Sub

    Private Sub chxTruncate_CheckedChanged(sender As Object, e As EventArgs) Handles chxTruncate.CheckedChanged
        If chxTruncate.Checked = False Then
            pri(4) = ""
        Else
            pri(4) = "truncate"
        End If
        Call BuildQuery()
    End Sub

    Dim withgrantoptionpri1 As String = ""
    Private Sub chxWithGrantOption_CheckedChanged(sender As Object, e As EventArgs) Handles chxWithGrantOption.CheckedChanged
        If chxWithGrantOption.Checked = False Then
            withgrantoptionpri1 = ""
        Else
            withgrantoptionpri1 = " with grant option"
        End If
        Call BuildQuery()
    End Sub
End Class