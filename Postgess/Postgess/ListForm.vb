Public Class ListForm

    Private Sub Loading()
        If ComboBox1.Text = "Hired" Then
            If TextBox2.Text = "" Then
                andqry = ""
            Else
                If CInt(TextBox2.Text) < 1000 Then
                    andqry = ""
                Else
                    If TextBox1.Text = "" Then
                        andqry = " where date_trunc('year', c.date_from) = (select min(date_trunc('year',date_from)) " &
                            "from service_record where emp_no = c.emp_no) and date_trunc('year', c.date_from) =  date_trunc('year', date '" & TextBox2.Text & "-01-01')"
                    Else
                        andqry = " and (date_trunc('year', c.date_from) = (select min(date_trunc('year',date_from)) " &
                            "from service_record where emp_no = c.emp_no) and date_trunc('year', c.date_from) =  date_trunc('year', date '" & TextBox2.Text & "-01-01'))"
                    End If
                End If
            End If
        Else

        End If
        If TextBox1.Text = "" Then
            Call loademployee(qry & andqry, sorttype, qrynoofitems & andqry)
        Else
            Call loademployee(qry & " where a.fname like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.mname like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.lname like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.birth_place like '" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.gender like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.civil_status like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.tribe like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.religion like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.citizenship like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.tin_no like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or b.name like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or c.position_title like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or c.institution_name like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' " & andqry,
                             sorttype,
                             qrynoofitems & " where a.fname like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.mname like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.lname like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.birth_place like '" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.gender like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.civil_status like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.tribe like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.religion like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.citizenship like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or a.tin_no like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or b.name like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or c.position_title like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' or c.institution_name like '%" & TextBox1.Text.Replace("'", "\'") &
                             "%' " & andqry)
        End If
    End Sub
    Dim andqry As String = ""
    Dim qry As String = "SELECT a.emp_no, a.item_no, a.fname, a.mname, a.lname, a.name_ext, a.birth_date, " &
       " a.birth_place, a.gender, a.civil_status, a.tribe, a.religion, a.citizenship, a.tin_no, b.name, c.position_title, c.institution_name, c.date_from, c.date_to " &
       "FROM personal_info as a left join eligibility_info as b on a.emp_no = b.emp_no left join service_record as c on a.emp_no = c.emp_no "
    Dim sorttype As String = " order by a.emp_no asc"
    Dim qrynoofitems As String = "Select count(*) as noofitems FROM personal_info as a left join eligibility_info as b on a.emp_no = b.emp_no left join service_record as c on a.emp_no = c.emp_no "
    Dim noi As Integer = 0
    Public Sub loademployee(a As String, b As String, c As String)
        Dim i As Integer = 0
        Call selectdata(qrynoofitems)
        sqldr.Read()
        If sqldr.HasRows Then
            noi = CInt(sqldr("noofitems"))
        Else
            noi = 0
        End If
        Call sqlclose()

        Dim noofitems As Integer = 0
        Call selectdata(c)
        sqldr.Read()
        If sqldr.HasRows Then
            noofitems = CInt(sqldr("noofitems"))
        Else
            noofitems = 0
        End If
        Call sqlclose()
        ListView1.Items.Clear()
        Call selectdata(a & b)
        Dim j As Integer = 0
        While sqldr.Read
            With ListView1
                .Items.Add(sqldr("emp_no"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(sqldr("item_no"))
                    .Add(sqldr("fname") & " " & sqldr("mname") & " " & sqldr("lname") & " " & sqldr("name_ext"))
                    .Add(sqldr("birth_date"))
                    .Add(sqldr("birth_place"))
                    .Add(sqldr("gender"))
                    .Add(sqldr("civil_status"))
                    .Add(sqldr("tribe"))
                    .Add(sqldr("religion"))
                    .Add(sqldr("citizenship"))
                    .Add(sqldr("tin_no"))
                    Try
                        .Add(sqldr("name").ToString)
                    Catch ex As Exception
                        .Add("")
                    End Try
                    Try
                        .Add(sqldr("position_title").ToString)
                    Catch ex As Exception
                        .Add("")
                    End Try
                    Try
                        .Add(sqldr("institution_name").ToString)
                    Catch ex As Exception
                        .Add("")
                    End Try
                    Try
                        .Add(sqldr("date_from"))
                    Catch ex As Exception
                        .Add("")
                    End Try
                    Try
                        .Add(sqldr("date_to"))
                    Catch ex As Exception
                        .Add("")
                    End Try
                End With
            End With
            If j Mod 2 = 0 Then
                ListView1.Items(j).BackColor = Color.FromArgb(200, 220, 220)
                ListView1.Items(j).ForeColor = Color.FromArgb(28, 78, 99)
            End If
            j = j + 1
        End While
        Call sqlclose()
        lbldisplayedlist.Text = noofitems.ToString & " of " & noi.ToString & " item(s) :: " & Math.Round((100 * (noofitems / noi)), 10).ToString & "% Displayed"
    End Sub

    Private Sub ListForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frm_Profiling.Show()
    End Sub


    Private Sub ListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Call loademployee(qry, sorttype, qrynoofitems)
            Call Loading()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Dim wrqry As String = " where a.fname = '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' or a.mname = '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' or a.lname = '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' or a.birth_place= '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' or a.gender= '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' or a.civil_status= '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' or a.tribe = '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' or a.religion= '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' or a.citizenship= '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' or a.tin_no= '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' or b.name= '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' or c.position_title= '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' or c.institution_name= '" & TextBox1.Text.Replace("'", "\'") &
    '                             "' "
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Call Loading()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dt1 As New DataTable
            With dt1
                .Columns.Add("ID", GetType(System.String))
                .Columns.Add("EItem", GetType(System.String))
                .Columns.Add("EmployeeName", GetType(System.String))
                .Columns.Add("BirthDate", GetType(System.String))
                .Columns.Add("BirthPlace", GetType(System.String))
                .Columns.Add("Gender", GetType(System.String))
                .Columns.Add("CivilStatus", GetType(System.String))
                .Columns.Add("Tribe", GetType(System.String))
                .Columns.Add("Religion", GetType(System.String))
                .Columns.Add("CitizenShip", GetType(System.String))
                .Columns.Add("TINNO", GetType(System.String))
                .Columns.Add("EligibilityName", GetType(System.String))
                .Columns.Add("PositionName", GetType(System.String))
                .Columns.Add("InstitutionName", GetType(System.String))
            End With

            For i As Integer = 0 To ListView1.Items.Count - 1
                dt1.Rows.Add(ListView1.Items(i).SubItems(0).Text, _
                             ListView1.Items(i).SubItems(1).Text, _
                             ListView1.Items(i).SubItems(2).Text, _
                            ListView1.Items(i).SubItems(3).Text, _
                            ListView1.Items(i).SubItems(4).Text, _
                            ListView1.Items(i).SubItems(5).Text, _
                           ListView1.Items(i).SubItems(6).Text, _
                           ListView1.Items(i).SubItems(7).Text, _
                            ListView1.Items(i).SubItems(8).Text, _
                              ListView1.Items(i).SubItems(9).Text, _
                                ListView1.Items(i).SubItems(10).Text, _
                                  ListView1.Items(i).SubItems(11).Text, _
                                    ListView1.Items(i).SubItems(12).Text, _
                            ListView1.Items(i).SubItems(13).Text)
            Next

            PrintForm.E_DataTableBindingSource.DataSource = dt1
            If RadioButton1.Checked = True Then
                PrintForm.LoadReport(1)
                PrintForm.ShowDialog()
            ElseIf RadioButton2.Checked = True Then
                PrintForm.LoadReport(3)
                PrintForm.ShowDialog()
            ElseIf RadioButton3.Checked = True Then
                PrintForm.LoadReport(2)
                PrintForm.ShowDialog()
            End If
            Call InsertLog("Printed list of employees ")
            PrintForm.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        Call IntDouble(False, e)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        'Try
        Call Loading()
        'Catch ex As Exception

        'End Try
    End Sub
End Class