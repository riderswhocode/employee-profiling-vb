Imports System.IO
Imports System.Drawing.Imaging

Public Class frm_Profiling
    Public Sub DisplayData(a As String)
        Call DisablingChildren()
        Call DisablingEducationalBackground()
        Call DisablingEligibility()
        Call DisablingFamilyBackground()
        Call DisablingPersonalInfo()
        Call DisablingSeminar()
        Call DisablingVoluntary()
        Call DisablingWork()
        btnSave.Text = "Save"
        SavingStatus = "None"
        Dim emid As String = ""
        sqlquery = "Select *  FROM public.personal_info " & a
        sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        sqldr = sqlcmd.ExecuteReader()
        sqldr.Read()
        If sqldr.HasRows Then
            emid = sqldr("emp_no").ToString
            emp_no.Text = sqldr("emp_no").ToString
            item_no.Text = sqldr("item_no").ToString
            fname.Text = sqldr("fname").ToString
            lname.Text = sqldr("lname").ToString
            mname.Text = sqldr("mname").ToString
            name_ext.Text = sqldr("name_ext").ToString
            birth_date.Text = sqldr("birth_date").ToString
            birth_place.Text = sqldr("birth_place").ToString
            gender.Text = sqldr("gender").ToString
            civil_status.Text = sqldr("civil_status").ToString
            tribe.Text = sqldr("tribe").ToString
            religion.Text = sqldr("religion").ToString
            citizenship.Text = sqldr("citizenship").ToString
            Em_height.Text = sqldr("height").ToString
            weight.Text = sqldr("weight").ToString
            blood_type.Text = sqldr("blood_type").ToString
            gsis_no.Text = sqldr("gsis_no")
            pag_ibig_no.Text = sqldr("pag_ibig_no").ToString
            philhealth_no.Text = sqldr("philhealth_no").ToString
            sss_no.Text = sqldr("sss_no").ToString
            tin_no.Text = sqldr("tin_no").ToString
            res_add.Text = sqldr("res_add").ToString
            res_zipcode.Text = sqldr("res_zipcode").ToString
            res_telno.Text = sqldr("res_telno").ToString
            per_add.Text = sqldr("per_add").ToString
            per_zipcode.Text = sqldr("per_zipcode").ToString
            per_telno.Text = sqldr("per_telno").ToString
            email_add.Text = sqldr("email_add").ToString
            cel_no.Text = sqldr("cel_no").ToString
            person_notify_fulname.Text = sqldr("person_notify_fulname").ToString
            person_notify_relation.Text = sqldr("person_notify_relation").ToString
            person_notify_contact.Text = sqldr("person_notify_contact").ToString
            remarks_comments.Text = sqldr("remarks_comments").ToString
        Else
            emid = ""
            Call ClearingPersonalInfo()
        End If
        Call sqlclose()

        If emid <> "" Then
            Try
                sqlquery = "select * from public.family_background where emp_no = " & emid
                sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
                sqldr = sqlcmd.ExecuteReader()
                sqldr.Read()
                If sqldr.HasRows Then
                    spouse_fname.Text = sqldr("spouse_fname").ToString
                    spouse_mname.Text = sqldr("spouse_mname").ToString
                    spouse_lname.Text = sqldr("spouse_lname").ToString
                    spouse_name_ext.Text = sqldr("spouse_name_ext").ToString
                    sp_occupation.Text = sqldr("sp_occupation").ToString
                    sp_employer_name.Text = sqldr("sp_employer_name").ToString
                    sp_employer_add.Text = sqldr("sp_employer_add").ToString
                    sp_contact.Text = sqldr("sp_contact").ToString
                    father_fname.Text = sqldr("father_fname").ToString
                    father_mname.Text = sqldr("father_mname").ToString
                    father_lname.Text = sqldr("father_lname").ToString
                    father_name_ext.Text = sqldr("father_name_ext").ToString
                    mother_fname.Text = sqldr("mother_fname").ToString
                    mother_mname.Text = sqldr("mother_mname").ToString
                    mother_lname.Text = sqldr("mother_lname").ToString
                    mother_name_ext.Text = sqldr("mother_name_ext").ToString
                Else
                    Call ClearingFamilyBackground()
                End If
                Call sqlclose()
            Catch ex As Exception

            End Try


            Call loadchildren(emid)

            Call loadeducationalbackground(emid)

            Call loadeligibility(emid)

            Call loadservicerecord(emid)

            Call loadworkstraining(emid)

            Call loadseminars(emid)
        End If
    End Sub

    Public Sub loadchildren(a As String)
        Try
            sqlquery = "Select *  FROM public.children where emp_no = " & a
            sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
            sqldr = sqlcmd.ExecuteReader()
            lstvChildren.Items.Clear()
            While sqldr.Read
                With lstvChildren
                    .Items.Add(sqldr("child_id").ToString)
                    With .Items(.Items.Count - 1).SubItems
                        .Add(sqldr("fname").ToString)
                        .Add(sqldr("mname").ToString)
                        .Add(sqldr("lname").ToString)
                        .Add(sqldr("name_ext").ToString)
                        .Add(sqldr("birth_date").ToString)
                    End With
                End With
            End While
            Call sqlclose()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub loadeducationalbackground(a As String)
        Try
            sqlquery = "Select * from public.educational_background where emp_no = " & a
            sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
            sqldr = sqlcmd.ExecuteReader()
            lstvEducationalBackground.Items.Clear()
            While sqldr.Read
                With lstvEducationalBackground
                    .Items.Add(sqldr("edback_id").ToString)
                    With .Items(.Items.Count - 1).SubItems
                        .Add(sqldr("level").ToString)
                        .Add(sqldr("school_name").ToString)
                        .Add(sqldr("school_add").ToString)
                        .Add(sqldr("degree_course").ToString)
                        .Add(sqldr("year_graduated").ToString)
                        .Add(sqldr("highest_level_notgraduated").ToString)
                        .Add(sqldr("inclusive_date_from").ToString)
                        .Add(sqldr("inclusive_date_to").ToString)
                        .Add(sqldr("honor_received").ToString)
                    End With
                End With
            End While
            Call sqlclose()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub loadeligibility(a As String)
        Try
            sqlquery = "SELECT *  FROM public.eligibility_info where emp_no = " & a
            sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
            sqldr = sqlcmd.ExecuteReader()
            lstvEligibilty.Items.Clear()
            While sqldr.Read
                With lstvEligibilty
                    .Items.Add(sqldr("elig_id").ToString)
                    With .Items(.Items.Count - 1).SubItems
                        .Add(sqldr("name").ToString)
                        .Add(sqldr("rating").ToString)
                        .Add(sqldr("exam_date").ToString)
                        .Add(sqldr("exam_add").ToString)
                        .Add(sqldr("license"))
                        .Add(sqldr("date_released").ToString)
                    End With
                End With
            End While
            Call sqlclose()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub loadservicerecord(a As String)
        Try
            sqlquery = "SELECT *  FROM  public.service_record where emp_no = " & a
            sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
            sqldr = sqlcmd.ExecuteReader()
            lstvWork.Items.Clear()
            While sqldr.Read
                With lstvWork
                    .Items.Add(sqldr("servicerec_id").ToString)
                    With .Items(.Items.Count - 1).SubItems
                        .Add(CDate(sqldr("date_from")).ToShortDateString)
                        .Add(CDate(sqldr("date_to")).ToShortDateString)
                        .Add(sqldr("position_title").ToString)
                        .Add(sqldr("institution_name").ToString)
                        .Add(sqldr("salary_grade").ToString)
                        .Add(sqldr("step_inc").ToString)
                        .Add(sqldr("monthly_salary").ToString)
                        .Add(sqldr("appointment_status").ToString)
                        .Add(sqldr("service_type").ToString)
                    End With
                End With
            End While
            Call sqlclose()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub loadworkstraining(a As String)
        Try
            sqlquery = "SELECT *  FROM public.works_trainings where emp_no = " & a
            sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
            sqldr = sqlcmd.ExecuteReader()
            lstvWorksTraining.Items.Clear()
            While sqldr.Read
                With lstvWorksTraining
                    .Items.Add(sqldr("work_id").ToString)
                    With .Items(.Items.Count - 1).SubItems
                        .Add(sqldr("organization_name").ToString)
                        .Add(sqldr("organization_add").ToString)
                        .Add(sqldr("date_from").ToString)
                        .Add(sqldr("date_to").ToString)
                        .Add(sqldr("hours_no").ToString)
                        .Add(sqldr("work_position").ToString)
                        .Add(sqldr("training_work").ToString)
                    End With
                End With
            End While
            Call sqlclose()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub loadseminars(a As String)
        Try
            sqlquery = "SELECT *  FROM public.seminars where emp_no = " & a
            sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
            sqldr = sqlcmd.ExecuteReader()
            lstvChildren.Items.Clear()
            While sqldr.Read
                With lstvChildren
                    .Items.Add(sqldr("sem_id"))
                    With .Items(.Items.Count - 1).SubItems
                        .Add(sqldr("title").ToString)
                        .Add(sqldr("venue").ToString)
                        .Add(sqldr("date_from").ToString)
                        .Add(sqldr("date_to").ToString)
                        .Add(sqldr("hours_no").ToString)
                        .Add(sqldr("sponsor").ToString)
                    End With
                End With
            End While
            Call sqlclose()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub ClearingPersonalInfo()
        emp_image.Image = Nothing
        emp_no.Text = ""
        item_no.Text = ""
        fname.Text = ""
        lname.Text = ""
        mname.Text = ""
        name_ext.Text = ""
        birth_date.ResetText()
        birth_place.Text = ""
        gender.Text = ""
        civil_status.Text = ""
        tribe.Text = ""
        religion.Text = ""
        citizenship.Text = ""
        Em_height.Text = ""
        weight.Text = ""
        blood_type.Text = ""
        gsis_no.Text = ""
        pag_ibig_no.Text = ""
        philhealth_no.Text = ""
        sss_no.Text = ""
        tin_no.Text = ""
        res_add.Text = ""
        res_zipcode.Text = ""
        res_telno.Text = ""
        per_add.Text = ""
        per_zipcode.Text = ""
        per_telno.Text = ""
        email_add.Text = ""
        cel_no.Text = ""
        person_notify_fulname.Text = ""
        person_notify_relation.Text = ""
        person_notify_contact.Text = ""
        remarks_comments.Text = ""
    End Sub

    Public Sub EnablingPersonalInfo()
        ChooseImage.Enabled = True
        'emp_no.Enabled = True
        item_no.Enabled = True
        fname.Enabled = True
        lname.Enabled = True
        mname.Enabled = True
        name_ext.Enabled = True
        birth_date.Enabled = True
        birth_place.Enabled = True
        gender.Enabled = True
        civil_status.Enabled = True
        tribe.Enabled = True
        religion.Enabled = True
        citizenship.Enabled = True
        Em_height.Enabled = True
        weight.Enabled = True
        blood_type.Enabled = True
        gsis_no.Enabled = True
        pag_ibig_no.Enabled = True
        philhealth_no.Enabled = True
        sss_no.Enabled = True
        tin_no.Enabled = True
        res_add.Enabled = True
        res_zipcode.Enabled = True
        res_telno.Enabled = True
        per_add.Enabled = True
        per_zipcode.Enabled = True
        per_telno.Enabled = True
        email_add.Enabled = True
        cel_no.Enabled = True
        person_notify_fulname.Enabled = True
        person_notify_relation.Enabled = True
        person_notify_contact.Enabled = True
        remarks_comments.Enabled = True
    End Sub

    Public Sub DisablingPersonalInfo()
        ChooseImage.Enabled = False
        emp_no.Enabled = False
        item_no.Enabled = False
        fname.Enabled = False
        lname.Enabled = False
        mname.Enabled = False
        name_ext.Enabled = False
        birth_date.Enabled = False
        birth_place.Enabled = False
        gender.Enabled = False
        civil_status.Enabled = False
        tribe.Enabled = False
        religion.Enabled = False
        citizenship.Enabled = False
        Em_height.Enabled = False
        weight.Enabled = False
        blood_type.Enabled = False
        gsis_no.Enabled = False
        pag_ibig_no.Enabled = False
        philhealth_no.Enabled = False
        sss_no.Enabled = False
        tin_no.Enabled = False
        res_add.Enabled = False
        res_zipcode.Enabled = False
        res_telno.Enabled = False
        per_add.Enabled = False
        per_zipcode.Enabled = False
        per_telno.Enabled = False
        email_add.Enabled = False
        cel_no.Enabled = False
        person_notify_fulname.Enabled = False
        person_notify_relation.Enabled = False
        person_notify_contact.Enabled = False
        remarks_comments.Enabled = False
    End Sub

    Public Sub ClearingFamilyBackground()
        spouse_fname.Text = ""
        spouse_mname.Text = ""
        spouse_lname.Text = ""
        spouse_name_ext.Text = ""
        sp_occupation.Text = ""
        sp_employer_name.Text = ""
        sp_employer_add.Text = ""
        sp_contact.Text = ""
        father_fname.Text = ""
        father_mname.Text = ""
        father_lname.Text = ""
        father_name_ext.Text = ""
        mother_fname.Text = ""
        mother_mname.Text = ""
        mother_lname.Text = ""
        mother_name_ext.Text = ""
    End Sub

    Public Sub EnablingFamilyBackground()
        spouse_fname.Enabled = True
        spouse_mname.Enabled = True
        spouse_lname.Enabled = True
        spouse_name_ext.Enabled = True
        sp_occupation.Enabled = True
        sp_employer_name.Enabled = True
        sp_employer_add.Enabled = True
        sp_contact.Enabled = True
        father_fname.Enabled = True
        father_mname.Enabled = True
        father_lname.Enabled = True
        father_name_ext.Enabled = True
        mother_fname.Enabled = True
        mother_mname.Enabled = True
        mother_lname.Enabled = True
        mother_name_ext.Enabled = True
    End Sub

    Public Sub DisablingFamilyBackground()
        spouse_fname.Enabled = False
        spouse_mname.Enabled = False
        spouse_lname.Enabled = False
        spouse_name_ext.Enabled = False
        sp_occupation.Enabled = False
        sp_employer_name.Enabled = False
        sp_employer_add.Enabled = False
        sp_contact.Enabled = False
        father_fname.Enabled = False
        father_mname.Enabled = False
        father_lname.Enabled = False
        father_name_ext.Enabled = False
        mother_fname.Enabled = False
        mother_mname.Enabled = False
        mother_lname.Enabled = False
        mother_name_ext.Enabled = False
    End Sub

    Public Sub ClearingChildren()
        cfname.Text = ""
        clname.Text = ""
        cmname.Text = ""
        cname_ext.Text = ""
        cbirth_date.ResetText()
    End Sub

    Public Sub EnablingChildren()
        cfname.Enabled = True
        clname.Enabled = True
        cmname.Enabled = True
        cname_ext.Enabled = True
        cbirth_date.Enabled = True
    End Sub

    Public Sub DisablingChildren()
        cfname.Enabled = False
        clname.Enabled = False
        cmname.Enabled = False
        cname_ext.Enabled = False
        cbirth_date.Enabled = False
    End Sub

    Public Sub ClearingEducationalBackground()
        level.Text = ""
        school_name.Text = ""
        school_add.Text = ""
        degree_course.Text = ""
        year_graduated.Text = ""
        highest_level_notgraduated.Text = ""
        inclusive_date_from.ResetText()
        inclusive_date_to.ResetText()
        honor_received.Text = ""
    End Sub

    Public Sub EnablingEducationalBackground()
        level.Enabled = True
        school_name.Enabled = True
        school_add.Enabled = True
        degree_course.Enabled = True
        year_graduated.Enabled = True
        highest_level_notgraduated.Enabled = True
        inclusive_date_from.Enabled = True
        inclusive_date_to.Enabled = True
        honor_received.Enabled = True
    End Sub

    Public Sub DisablingEducationalBackground()
        level.Enabled = False
        school_name.Enabled = False
        school_add.Enabled = False
        degree_course.Enabled = False
        year_graduated.Enabled = False
        highest_level_notgraduated.Enabled = False
        inclusive_date_from.Enabled = False
        inclusive_date_to.Enabled = False
        honor_received.Enabled = False
    End Sub

    Public Sub ClearingEligibility()
        Eligibilty_name.Text = ""
        rating.Text = ""
        exam_date.Text = ""
        exam_add.Text = ""
        license.Text = ""
        date_released.ResetText()
    End Sub

    Public Sub EnablingEligibility()
        Eligibilty_name.Enabled = True
        rating.Enabled = True
        exam_date.Enabled = True
        exam_add.Enabled = True
        license.Enabled = True
        date_released.Enabled = True
    End Sub

    Public Sub DisablingEligibility()
        Eligibilty_name.Enabled = False
        rating.Enabled = False
        exam_date.Enabled = False
        exam_add.Enabled = False
        license.Enabled = False
        date_released.Enabled = False
    End Sub

    Public Sub ClearingWork()
        date_from.ResetText()
        date_to.ResetText()
        position_title.Text = ""
        institution_name.Text = ""
        salary_grade.Text = ""
        step_inc.Text = ""
        monthly_salary.Text = ""
        appointment_status.Text = ""
        service_type_government.Checked = False
        service_type_private.Checked = False
    End Sub
    Public Sub EnablingWork()
        date_from.Enabled = True
        date_to.Enabled = True
        position_title.Enabled = True
        institution_name.Enabled = True
        salary_grade.Enabled = True
        step_inc.Enabled = True
        monthly_salary.Enabled = True
        appointment_status.Enabled = True
        service_type_government.Enabled = True
        service_type_private.Enabled = True
    End Sub
    Public Sub DisablingWork()
        date_from.Enabled = False
        date_to.Enabled = False
        position_title.Enabled = False
        institution_name.Enabled = False
        salary_grade.Enabled = False
        step_inc.Enabled = False
        monthly_salary.Enabled = False
        appointment_status.Enabled = False
        service_type_government.Enabled = False
        service_type_private.Enabled = False
    End Sub
    Public Sub ClearingVoluntary()
        training_work_voluntary.Checked = False
        training_work_training.Checked = False
        organization_name.Text = ""
        organization_add.Text = ""
        VW_date_from.ResetText()
        VW_date_to.ResetText()
        hours_no.Text = ""
        work_position.Text = ""
    End Sub
    Public Sub EnablingVoluntary()
        training_work_voluntary.Enabled = True
        training_work_training.Enabled = True
        organization_name.Enabled = True
        organization_add.Enabled = True
        VW_date_from.Enabled = True
        VW_date_to.Enabled = True
        hours_no.Enabled = True
        work_position.Enabled = True
    End Sub
    Public Sub DisablingVoluntary()
        training_work_voluntary.Enabled = False
        training_work_training.Enabled = False
        organization_name.Enabled = False
        organization_add.Enabled = False
        VW_date_from.Enabled = False
        VW_date_to.Enabled = False
        hours_no.Enabled = False
        work_position.Enabled = False
    End Sub
    Public Sub ClearingSeminar()
        title.Text = ""
        venue.Text = ""
        S_date_from.ResetText()
        S_date_to.ResetText()
        hours_no.Text = ""
        sponsor.Text = ""
    End Sub
    Public Sub EnablingSeminar()
        title.Enabled = True
        venue.Enabled = True
        S_date_from.Enabled = True
        S_date_to.Enabled = True
        hours_no.Enabled = True
        sponsor.Enabled = True
    End Sub
    Public Sub DisablingSeminar()
        title.Enabled = False
        venue.Enabled = False
        S_date_from.Enabled = False
        S_date_to.Enabled = False
        hours_no.Enabled = False
        sponsor.Enabled = False
    End Sub

    Private Sub item_no_KeyPress(sender As Object, e As KeyPressEventArgs) Handles item_no.KeyPress
        Call IntDouble(False, e)
    End Sub

    Private Sub Em_height_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Em_height.KeyPress
        Call IntDouble2(True, Em_height.Text, e)
    End Sub

    Private Sub weight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles weight.KeyPress
        Call IntDouble2(True, weight.Text, e)
    End Sub

    Private Sub rating_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rating.KeyPress
        Call IntDouble2(True, rating.Text, e)
    End Sub

    Private Sub hours_no_KeyPress(sender As Object, e As KeyPressEventArgs) Handles hours_no.KeyPress
        Call IntDouble(False, e)
    End Sub

    Private Sub S_hours_no_KeyPress(sender As Object, e As KeyPressEventArgs) Handles S_hours_no.KeyPress
        Call IntDouble(False, e)
    End Sub

    Private Sub monthly_salary_KeyPress(sender As Object, e As KeyPressEventArgs) Handles monthly_salary.KeyPress
        Call IntDouble2(True, monthly_salary.Text, e)
    End Sub

    Dim SavingStatus = "None"
    Private Sub CheckingFields()
        If SavingStatus = "None" Then
            If emp_no.Text = "" Then
                btnEdit.Enabled = False
                btnDelete.Enabled = False
            Else
                btnEdit.Enabled = True
                btnDelete.Enabled = True
            End If
            btnSave.Enabled = False
        ElseIf SavingStatus = "Save" Then
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            If emp_no.Text = "" Or fname.Text = "" Or lname.Text = "" Then
                btnSave.Enabled = False
            Else
                btnSave.Enabled = True
            End If
        ElseIf SavingStatus = "Update" Then
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            If emp_no.Text = "" Or fname.Text = "" Or lname.Text = "" Then
                btnSave.Enabled = False
            Else
                btnSave.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Call ClearingChildren()
        Call ClearingEducationalBackground()
        Call ClearingEligibility()
        Call ClearingPersonalInfo()
        Call ClearingFamilyBackground()
        Call ClearingSeminar()
        Call ClearingVoluntary()
        Call ClearingWork()
        Call EnablingChildren()
        Call EnablingEducationalBackground()
        Call EnablingEligibility()
        Call EnablingFamilyBackground()
        Call EnablingPersonalInfo()
        Call EnablingSeminar()
        Call EnablingVoluntary()
        Call EnablingWork()
        lstvChildren.Items.Clear()
        lstvEducationalBackground.Items.Clear()
        lstvEligibilty.Items.Clear()
        lstvSeminar.Items.Clear()
        lstvWork.Items.Clear()
        lstvWorksTraining.Items.Clear()
        btnSave.Text = "Save"
        SavingStatus = "Save"
        Try
            Call selectdata("SELECT MAX(emp_no)+1 as New_ID from personal_info")
            sqldr.Read()
            emp_no.Text = sqldr("New_ID")
            sqlclose()
        Catch ex As Exception
            emp_no.Text = "1"
        End Try
    End Sub

    Private Sub InsertingData()
        'Try
        'Dim mstream As New MemoryStream()
        'emp_image.Image.Save(mstream, ImageFormat.Jpeg)
        'Dim ArImage() As Byte = mstream.GetBuffer
        '    sqlquery = "INSERT INTO personal_info(emp_no, item_no, fname, mname, lname, name_ext, birth_date, " +
        '    "birth_place, gender, civil_status, tribe, religion, citizenship, " +
        '    "Height, weight, blood_type, gsis_no, pag_ibig_no, philhealth_no, " +
        '    "sss_no, tin_no, res_add, res_zipcode, res_telno, per_add, per_zipcode, " +
        '    "per_telno, email_add, cel_no, person_notify_fulname, person_notify_relation, " +
        '    "person_notify_contact, remarks_comments) " &
        '          "VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"

        '    sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        '    With sqlcmd
        '        '.Parameters.AddWithValue("@emp_image", ArImage)
        '        .Parameters.AddWithValue("@emp_no", emp_no.Text)
        '        .Parameters.AddWithValue("@item_no", item_no.Text)
        '        .Parameters.AddWithValue("@fname", fname.Text)
        '        .Parameters.AddWithValue("@mname", mname.Text)
        '        .Parameters.AddWithValue("@lname", lname.Text)
        '        .Parameters.AddWithValue("@name_ext", name_ext.Text)
        '        .Parameters.AddWithValue("@birth_date", birth_date.Text)
        '        .Parameters.AddWithValue("@birth_place", birth_place.Text)
        '        .Parameters.AddWithValue("@gender", gender.Text)
        '        .Parameters.AddWithValue("@civil_status", civil_status.Text)
        '        .Parameters.AddWithValue("@tribe", tribe.Text)
        '        .Parameters.AddWithValue("@religion", religion.Text)
        '        .Parameters.AddWithValue("@citizenship", citizenship.Text)
        '        .Parameters.AddWithValue("@height", Em_height.Text)
        '        .Parameters.AddWithValue("@weight", weight.Text)
        '        .Parameters.AddWithValue("@blood_type", blood_type.Text)
        '        .Parameters.AddWithValue("@gsis_no", gsis_no.Text)
        '        .Parameters.AddWithValue("@pag_ibig_no", pag_ibig_no.Text)
        '        .Parameters.AddWithValue("@philhealth_no", philhealth_no.Text)
        '        .Parameters.AddWithValue("@sss_no", sss_no.Text)
        '        .Parameters.AddWithValue("@tin_no", tin_no.Text)
        '        .Parameters.AddWithValue("@res_add", res_add.Text)
        '        .Parameters.AddWithValue("@res_zipcode", res_zipcode.Text)
        '        .Parameters.AddWithValue("@res_telno", res_telno.Text)
        '        .Parameters.AddWithValue("@per_add", per_add.Text)
        '        .Parameters.AddWithValue("@per_zipcode", per_zipcode.Text)
        '        .Parameters.AddWithValue("@email_add", email_add.Text)
        '        .Parameters.AddWithValue("@cel_no", cel_no.Text)
        '        .Parameters.AddWithValue("@person_notify_fulname", person_notify_fulname.Text)
        '        .Parameters.AddWithValue("@person_notify_relation", person_notify_relation.Text)
        '        .Parameters.AddWithValue("@person_notify_contact", person_notify_contact.Text)
        '        .Parameters.AddWithValue("@remarks_comments", remarks_comments.Text)
        '    End With
        '    sqlcmd.ExecuteNonQuery()
        '    sqlcmd.Dispose()
        '    sqlquery = vbEmpty
        'Catch ex As Exception
        '    MsgBox(ex.Message)

        'End Try

        Dim h As Double = 0
        Dim w As Double = 0
        Dim it As Integer = 0
        If Em_height.Text = "" Then
            h = 0
        Else
            h = CDbl(Em_height.Text)
        End If

        If weight.Text = "" Then
            w = 0
        Else
            w = CDbl(weight.Text)
        End If

        If item_no.Text = "" Then
            it = 0
        Else
            it = CInt(item_no.Text)
        End If
        If Em_height.Text = "" Then

        End If

        sqlquery = "INSERT INTO public.personal_info(" +
            " emp_no, item_no, fname, mname, lname, name_ext, birth_date, " +
        "birth_place, gender, civil_status, tribe, religion, citizenship, " +
        "Height, weight, blood_type, gsis_no, pag_ibig_no, philhealth_no, " +
        "sss_no, tin_no, res_add, res_zipcode, res_telno, per_add, per_zipcode, " +
        "per_telno, email_add, cel_no, person_notify_fulname, person_notify_relation, " +
         "person_notify_contact, remarks_comments) " +
        " VALUES (" & CInt(emp_no.Text) & "," & it & "," & Replacer(fname.Text) & "," & Replacer(mname.Text) &
        "," & Replacer(lname.Text) & "," & Replacer(name_ext.Text) & ",'" & CDate(birth_date.Text).ToShortDateString & "'," &
        Replacer(birth_place.Text) & "," & Replacer(gender.Text) & "," & Replacer(civil_status.Text) & "," &
        Replacer(tribe.Text) & "," & Replacer(religion.Text) & "," & Replacer(citizenship.Text) & "," &
        h & "," & w & "," & Replacer(blood_type.Text) & "," &
        Replacer(gsis_no.Text) & "," & Replacer(pag_ibig_no.Text) & "," & Replacer(philhealth_no.Text) & "," &
        Replacer(sss_no.Text) & "," & Replacer(tin_no.Text) & "," & Replacer(res_add.Text) & "," & Replacer(res_zipcode.Text) & "," &
        Replacer(res_telno.Text) & "," & Replacer(per_add.Text) & "," & Replacer(per_zipcode.Text) & "," &
        Replacer(per_telno.Text) & "," & Replacer(email_add.Text) & "," & Replacer(cel_no.Text) & "," & Replacer(person_notify_fulname.Text) & "," &
 Replacer(person_notify_relation.Text) & "," & Replacer(person_notify_contact.Text) & "," & Replacer(remarks_comments.Text) & ")"
        sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        sqlcmd.ExecuteNonQuery()
        sqlquery = vbEmpty
        sqlcmd.Dispose()
        ''===============End Of Personal Info===============

        ''===============Beginning of Family Background================
        sqlquery = "INSERT INTO public.family_background(" +
            " emp_no, spouse_fname, spouse_mname, spouse_lname, spouse_name_ext," &
            "sp_occupation, sp_employer_name, sp_employer_add, sp_contact, " &
            "father_fname, father_mname, father_lname, father_name_ext, mother_fname," &
            "mother_mname, mother_lname, mother_name_ext) " +
        " VALUES (" & CInt(emp_no.Text) & "," & Replacer(spouse_fname.Text) & "," & Replacer(spouse_mname.Text) & "," & Replacer(spouse_lname.Text) &
        "," & Replacer(spouse_name_ext.Text) & "," & Replacer(sp_occupation.Text) & "," & Replacer(sp_employer_name.Text) & "," &
        " " & Replacer(sp_employer_add.Text) & "," & Replacer(sp_contact.Text) & "," & Replacer(father_fname.Text) & "," &
        " " & Replacer(father_mname.Text) & "," & Replacer(father_lname.Text) & "," & Replacer(father_name_ext.Text) & "," &
        " " & Replacer(mother_fname.Text) & "," & Replacer(mother_mname.Text) & "," & Replacer(mother_lname.Text) & "," & Replacer(mother_name_ext.Text) & ")"
        sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        'With sqlcmd
        '    '.Parameters.AddWithValue("@emp_image", ArImage)
        'End With
        sqlcmd.ExecuteNonQuery()
        sqlquery = vbEmpty
        sqlcmd.Dispose()

        For i2 As Integer = 0 To lstvChildren.Items.Count - 1
            Dim new_id As Integer = 0
            Try
                Call selectdata("SELECT MAX(child_id)+1 as New_ID from children")
                sqldr.Read()
                new_id = sqldr("New_ID")
                sqlclose()
            Catch ex As Exception
                new_id = 1
            End Try
            sqlquery = "INSERT INTO public.children(" +
           "emp_no, child_id, fname, mname, lname, name_ext, birth_date)" +
           " VALUES (" & CInt(emp_no.Text) & ",'" & lstvChildren.Items(i2).SubItems(0).Text & "','" & lstvChildren.Items(i2).SubItems(1).Text & "','" & lstvChildren.Items(i2).SubItems(2).Text & "'" &
           ",'" & lstvChildren.Items(i2).SubItems(3).Text & "','" & lstvChildren.Items(i2).SubItems(4).Text & "','" & CDate(lstvChildren.Items(i2).SubItems(5).Text).ToShortDateString & "')"
            sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
            sqlcmd.ExecuteNonQuery()
            sqlquery = vbEmpty
            sqlcmd.Dispose()
        Next

        ''===============End of Family Background======================

        ''===============Beginning of Educational Background================
        For i As Integer = 0 To lstvEducationalBackground.Items.Count - 1
            Dim newEDID As Integer = 0
            Try
                Call selectdata("SELECT MAX(emp_no)+1 as New_ID from educational_background")
                sqldr.Read()
                newEDID = CInt(sqldr("New_ID"))
                sqlclose()
            Catch ex As Exception
                newEDID = 1
            End Try
            sqlquery = "insert INTO public.educational_background(" &
            "emp_no, edback_id, level, school_name, school_add, degree_course, " &
            "year_graduated, highest_level_notgraduated, inclusive_date_from, " &
            "inclusive_date_to, honor_received)" &
            "VALUES (" & CInt(emp_no.Text) & "," & newEDID &
              "," & Replacer(lstvEducationalBackground.Items(i).SubItems(1).Text) &
            "," & Replacer(lstvEducationalBackground.Items(i).SubItems(2).Text) &
            "," & Replacer(lstvEducationalBackground.Items(i).SubItems(3).Text) &
            "," & Replacer(lstvEducationalBackground.Items(i).SubItems(4).Text) &
            "," & CInt(lstvEducationalBackground.Items(i).SubItems(5).Text) &
            "," & Replacer(lstvEducationalBackground.Items(i).SubItems(6).Text) &
            ",'" & lstvEducationalBackground.Items(i).SubItems(7).Text &
            "','" & lstvEducationalBackground.Items(i).SubItems(8).Text &
            "'," & Replacer(lstvEducationalBackground.Items(i).SubItems(9).Text) &
            ");"
            sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
            'With sqlcmd
            '    .Parameters.AddWithValue("@emp_image", ArImage)
            'End With
            sqlcmd.ExecuteNonQuery()
            sqlquery = vbEmpty
            sqlcmd.Dispose()
        Next
        ''===============End of Educational Background================

        ''===============Beginning of Eligibility====================
        For i3 As Integer = 0 To lstvEligibilty.Items.Count - 1
            Dim new_id As Integer = 0
            Try
                Call selectdata("SELECT MAX(elig_id)+1 as New_ID from eligibility_info")
                sqldr.Read()
                new_id = sqldr("New_ID")
                sqlclose()
            Catch ex As Exception
                new_id = 1
            End Try
            sqlquery = "INSERT INTO public.eligibility_info(" +
           "emp_no, elig_id, name, rating, exam_date, exam_add, license, date_released)" +
           " VALUES (" & CInt(emp_no.Text) & ",'" & lstvEligibilty.Items(i3).SubItems(0).Text & "','" & lstvEligibilty.Items(i3).SubItems(1).Text & "','" & lstvEligibilty.Items(i3).SubItems(2).Text & "'" +
           ",'" & CDate(lstvEligibilty.Items(i3).SubItems(3).Text).ToShortDateString & "','" & lstvEligibilty.Items(i3).SubItems(4).Text & "'," +
           "'" & lstvEligibilty.Items(i3).SubItems(5).Text & "','" & CDate(lstvEligibilty.Items(i3).SubItems(6).Text).ToShortDateString & "')"
            sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
            sqlcmd.ExecuteNonQuery()
            sqlquery = vbEmpty
            sqlcmd.Dispose()
        Next
        ''===============End of Eligibility====================

        ''===============Beginning of work experience================
        For i4 As Integer = 0 To lstvWork.Items.Count - 1
            Dim new_id As Integer = 0
            Try
                Call selectdata("SELECT MAX(servicerec_id)+1 as New_ID from service_record")
                sqldr.Read()
                new_id = sqldr("New_ID")
                sqlclose()
            Catch ex As Exception
                new_id = 1
            End Try

            sqlquery = "INSERT INTO public.service_record(" +
           " emp_no, servicerec_id, date_from, date_to, position_title, institution_name, " +
           "salary_grade, step_inc, monthly_salary, appointment_status, service_type)" +
           " VALUES (" & CInt(emp_no.Text) & ",'" & new_id & "','" & lstvWork.Items(i4).SubItems(1).Text & "','" & lstvWork.Items(i4).SubItems(2).Text & "'" +
           ",'" & lstvWork.Items(i4).SubItems(3).Text & "','" & lstvWork.Items(i4).SubItems(4).Text & "'," +
            "'" & lstvWork.Items(i4).SubItems(5).Text & "','" & lstvWork.Items(i4).SubItems(6).Text & "','" & lstvWork.Items(i4).SubItems(7).Text & "'," +
           "'" & lstvWork.Items(i4).SubItems(8).Text & "','" & lstvWork.Items(i4).SubItems(9).Text & "')"
            sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
            sqlcmd.ExecuteNonQuery()
            sqlquery = vbEmpty
            sqlcmd.Dispose()
        Next
        ''==============================End of work experience =======

        ''===============================Beginning of voluntary or trainings============
        For i5 As Integer = 0 To lstvWorksTraining.Items.Count - 1
            Dim new_id As Integer = 0
            Try
                Call selectdata("SELECT MAX(work_id)+1 as New_ID from works_trainings")
                sqldr.Read()
                new_id = sqldr("New_ID")
                sqlclose()
            Catch ex As Exception
                new_id = 1
            End Try

            sqlquery = "INSERT INTO public.works_trainings(" +
           " emp_no, work_id, organization_name, organization_add, " +
           " date_from, date_to, hours_no, work_position,training_work)" +
           " VALUES (" & CInt(emp_no.Text) & ",'" & new_id & "','" & lstvWorksTraining.Items(i5).SubItems(1).Text & "','" & lstvWorksTraining.Items(i5).SubItems(2).Text & "'" +
            ",'" & lstvWorksTraining.Items(i5).SubItems(3).Text & "','" & lstvWorksTraining.Items(i5).SubItems(4).Text & "','" & lstvWorksTraining.Items(i5).SubItems(5).Text & "'," +
           "'" & lstvWorksTraining.Items(i5).SubItems(6).Text & "','" & lstvWorksTraining.Items(i5).SubItems(7).Text & "')"
            sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
            sqlcmd.ExecuteNonQuery()
            sqlquery = vbEmpty
            sqlcmd.Dispose()
        Next
        ''============================end

        ''=========================Beginning
        For i6 As Integer = 0 To lstvSeminar.Items.Count - 1
            Dim new_id As Integer = 0
            Try
                Call selectdata("SELECT MAX(sem_id)+1 as New_ID from seminars")
                sqldr.Read()
                new_id = sqldr("New_ID")
                sqlclose()
            Catch ex As Exception
                new_id = 1
            End Try

            sqlquery = "INSERT INTO public.seminars(" +
           "emp_no, sem_id, title, venue, date_from, date_to, hours_no, sponsor) " +
           " VALUES (" & CInt(emp_no.Text) & ",'" & new_id & "','" & lstvSeminar.Items(i6).SubItems(1).Text & "','" & lstvSeminar.Items(i6).SubItems(2).Text & "'" +
            ",'" & lstvSeminar.Items(i6).SubItems(3).Text & "','" & lstvSeminar.Items(i6).SubItems(4).Text & "','" & lstvSeminar.Items(i6).SubItems(5).Text & "'," +
           "'" & lstvSeminar.Items(i6).SubItems(6).Text & "')"
            sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
            sqlcmd.ExecuteNonQuery()
            sqlquery = vbEmpty
            sqlcmd.Dispose()
        Next
        ' ''======================end
    End Sub

    Private Sub UpdatingData()
        Dim h As Double = 0
        Dim w As Double = 0
        Dim it As Integer = 0
        If Em_height.Text = "" Then
            h = 0
        Else
            h = CDbl(Em_height.Text)
        End If

        If weight.Text = "" Then
            w = 0
        Else
            w = CDbl(weight.Text)
        End If

        If item_no.Text = "" Then
            it = 0
        Else
            it = CInt(item_no.Text)
        End If
        If Em_height.Text = "" Then

        End If

        sqlquery = "update public.personal_info set item_no = " & it & ",fname =" & Replacer(fname.Text) & ",mname= " & Replacer(mname.Text) &
        ",lname =" & Replacer(lname.Text) & ",name_ext = " & Replacer(name_ext.Text) & ",birth_date ='" & CDate(birth_date.Text).ToShortDateString &
        "',birth_place = " & Replacer(birth_place.Text) & ",gender = " & Replacer(gender.Text) & ",civil_status = " & Replacer(civil_status.Text) &
        ",tribe = " & Replacer(tribe.Text) & ",religion = " & Replacer(religion.Text) & ",citizenship = " & Replacer(citizenship.Text) & ",Height = " & h &
        ",weight = " & w & ",blood_type = " & Replacer(blood_type.Text) & ",gsis_no = " & Replacer(gsis_no.Text) & ",pag_ibig_no = " & Replacer(pag_ibig_no.Text) &
        ",philhealth_no = " & Replacer(philhealth_no.Text) & ",sss_no = " & Replacer(sss_no.Text) & ",tin_no = " & Replacer(tin_no.Text) & ",res_add = " & Replacer(res_add.Text) &
        ",res_zipcode = " & Replacer(res_zipcode.Text) & ",res_telno = " & Replacer(res_telno.Text) & ",per_add = " & Replacer(per_add.Text) &
        ",per_zipcode = " & Replacer(per_zipcode.Text) & ",per_telno = " & Replacer(per_telno.Text) & ",email_add = " & Replacer(email_add.Text) &
        ",cel_no = " & Replacer(cel_no.Text) & ",person_notify_fulname = " & Replacer(person_notify_fulname.Text) & ",person_notify_relation= " & Replacer(person_notify_relation.Text) &
        ",person_notify_contact = " & Replacer(person_notify_contact.Text) & ",remarks_comments = " & Replacer(remarks_comments.Text) & " where emp_no = " & emp_no.Text
        sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        sqlcmd.ExecuteNonQuery()
        sqlquery = vbEmpty
        sqlcmd.Dispose()
        ''===============End Of Personal Info===============
       
        ''===============Beginning of Family Background================
        sqlquery = "UPDATE public.family_background" +
        " SET spouse_fname=" & Replacer(spouse_fname.Text) & ",spouse_mname=" & Replacer(spouse_mname.Text) & ",spouse_lname=" & Replacer(spouse_lname.Text) &
        ",spouse_name_ext=" & Replacer(spouse_name_ext.Text) & ",sp_occupation=" & Replacer(sp_occupation.Text) & ",sp_employer_name=" & Replacer(sp_employer_name.Text) & "," &
        "sp_employer_add= " & Replacer(sp_employer_add.Text) & ",sp_contact=" & Replacer(sp_contact.Text) & ",father_fname=" & Replacer(father_fname.Text) & "," &
        "father_mname= " & Replacer(father_mname.Text) & ",father_lname=" & Replacer(father_lname.Text) & ",father_name_ext=" & Replacer(father_name_ext.Text) & "," &
        "mother_fname= " & Replacer(mother_fname.Text) & ",mother_mname=" & Replacer(mother_mname.Text) & ",mother_lname=" & Replacer(mother_lname.Text) & ",mother_name_ext=" & Replacer(mother_name_ext.Text) & " WHERE emp_no = " & emp_no.Text
        sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        'With sqlcmd
        '    '.Parameters.AddWithValue("@emp_image", ArImage)
        'End With
        sqlcmd.ExecuteNonQuery()
        sqlquery = vbEmpty
        sqlcmd.Dispose()
        sqlquery = "DELETE FROM public.children WHERE emp_no = " & emp_no.Text
        sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        sqlcmd.ExecuteNonQuery()
        sqlquery = vbEmpty
        sqlcmd.Dispose()

        'For i2 As Integer = 0 To lstvChildren.Items.Count - 1
        '    Dim new_id As Integer = 0
        '    Try
        '        Call selectdata("SELECT MAX(child_id)+1 as New_ID from children")
        '        sqldr.Read()
        '        new_id = sqldr("New_ID")
        '        sqlclose()
        '    Catch ex As Exception
        '        new_id = 1
        '    End Try
        '    sqlquery = "INSERT INTO public.children(" +
        '   "emp_no, child_id, fname, mname, lname, name_ext, birth_date)" +
        '   " VALUES (" & CInt(emp_no.Text) & ",'" & lstvChildren.Items(i2).SubItems(0).Text & "','" & lstvChildren.Items(i2).SubItems(1).Text & "','" & lstvChildren.Items(i2).SubItems(2).Text & "'" &
        '   ",'" & lstvChildren.Items(i2).SubItems(3).Text & "','" & lstvChildren.Items(i2).SubItems(4).Text & "','" & CDate(lstvChildren.Items(i2).SubItems(5).Text).ToShortDateString & "')"
        '    sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        '    sqlcmd.ExecuteNonQuery()
        '    sqlquery = vbEmpty
        '    sqlcmd.Dispose()
        'Next

        ''===============End of Family Background======================

        ''===============Beginning of Educational Background================
        'sqlquery = "DELETE FROM public.educational_background WHERE emp_no = " & emp_no.Text
        'sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        'sqlcmd.ExecuteNonQuery()
        'sqlquery = vbEmpty
        'sqlcmd.Dispose()

        'For i As Integer = 0 To lstvEducationalBackground.Items.Count - 1
        '    Dim newEDID As Integer = 0
        '    Try
        '        Call selectdata("SELECT MAX(edback_id)+1 as New_ID from educational_background")
        '        sqldr.Read()
        '        newEDID = CInt(sqldr("New_ID"))
        '        sqlclose()
        '    Catch ex As Exception
        '        newEDID = 1
        '    End Try
        '    Dim yg As Integer = 0
        '    If lstvEducationalBackground.Items(i).SubItems(5).Text = "" Then
        '        yg = 0
        '    Else
        '        Try
        '            yg = CInt(lstvEducationalBackground.Items(i).SubItems(5).Text)
        '        Catch ex As Exception
        '            yg = 0
        '        End Try
        '    End If
        '    sqlquery = "insert INTO public.educational_background(" &
        '    "emp_no, edback_id, level, school_name, school_add, degree_course, " &
        '    "year_graduated, highest_level_notgraduated, inclusive_date_from, " &
        '    "inclusive_date_to, honor_received)" &
        '    "VALUES (" & CInt(emp_no.Text) & "," & newEDID &
        '      "," & Replacer(lstvEducationalBackground.Items(i).SubItems(1).Text) &
        '    "," & Replacer(lstvEducationalBackground.Items(i).SubItems(2).Text) &
        '    "," & Replacer(lstvEducationalBackground.Items(i).SubItems(3).Text) &
        '    "," & Replacer(lstvEducationalBackground.Items(i).SubItems(4).Text) &
        '    "," & yg &
        '    "," & Replacer(lstvEducationalBackground.Items(i).SubItems(6).Text) &
        '    ",'" & lstvEducationalBackground.Items(i).SubItems(7).Text &
        '    "','" & lstvEducationalBackground.Items(i).SubItems(8).Text &
        '    "'," & Replacer(lstvEducationalBackground.Items(i).SubItems(9).Text) &
        '    ");"
        '    sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        '    'With sqlcmd
        '    '    .Parameters.AddWithValue("@emp_image", ArImage)
        '    'End With
        '    sqlcmd.ExecuteNonQuery()
        '    sqlquery = vbEmpty
        '    sqlcmd.Dispose()
        'Next
        ''===============End of Educational Background================

        ''===============Beginning of Eligibility====================
        'sqlquery = "DELETE FROM public.eligibility_info WHERE emp_no = " & emp_no.Text
        'sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        'sqlcmd.ExecuteNonQuery()
        'sqlquery = vbEmpty
        'sqlcmd.Dispose()

        'For i3 As Integer = 0 To lstvEligibilty.Items.Count - 1
        '    Dim new_id As Integer = 0
        '    Try
        '        Call selectdata("SELECT MAX(elig_id)+1 as New_ID from eligibility_info")
        '        sqldr.Read()
        '        new_id = sqldr("New_ID")
        '        sqlclose()
        '    Catch ex As Exception
        '        new_id = 1
        '    End Try
        '    sqlquery = "INSERT INTO public.eligibility_info(" +
        '   "emp_no, elig_id, name, rating, exam_date, exam_add, license, date_released)" +
        '   " VALUES (" & CInt(emp_no.Text) & ",'" & lstvEligibilty.Items(i3).SubItems(0).Text & "','" & lstvEligibilty.Items(i3).SubItems(1).Text & "','" & lstvEligibilty.Items(i3).SubItems(2).Text & "'" +
        '   ",'" & CDate(lstvEligibilty.Items(i3).SubItems(3).Text).ToShortDateString & "','" & lstvEligibilty.Items(i3).SubItems(4).Text & "'," +
        '   "'" & lstvEligibilty.Items(i3).SubItems(5).Text & "','" & CDate(lstvEligibilty.Items(i3).SubItems(6).Text).ToShortDateString & "')"
        '    sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        '    sqlcmd.ExecuteNonQuery()
        '    sqlquery = vbEmpty
        '    sqlcmd.Dispose()
        'Next
        ' ''===============End of Eligibility====================

        ' ''===============Beginning of work experience================
        'sqlquery = "DELETE FROM public.service_record WHERE emp_no = " & emp_no.Text
        'sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        'sqlcmd.ExecuteNonQuery()
        'sqlquery = vbEmpty
        'sqlcmd.Dispose()

        'For i4 As Integer = 0 To lstvWork.Items.Count - 1
        '    Dim new_id As Integer = 0
        '    Try
        '        Call selectdata("SELECT MAX(servicerec_id)+1 as New_ID from service_record")
        '        sqldr.Read()
        '        new_id = sqldr("New_ID")
        '        sqlclose()
        '    Catch ex As Exception
        '        new_id = 1
        '    End Try

        '    sqlquery = "INSERT INTO public.service_record(" +
        '   " emp_no, servicerec_id, date_from, date_to, position_title, institution_name, " +
        '   "salary_grade, step_inc, monthly_salary, appointment_status, service_type)" +
        '   " VALUES (" & CInt(emp_no.Text) & ",'" & new_id & "','" & lstvWork.Items(i4).SubItems(1).Text & "','" & lstvWork.Items(i4).SubItems(2).Text & "'" +
        '   ",'" & lstvWork.Items(i4).SubItems(3).Text & "','" & lstvWork.Items(i4).SubItems(4).Text & "'," +
        '    "'" & lstvWork.Items(i4).SubItems(5).Text & "','" & lstvWork.Items(i4).SubItems(6).Text & "','" & lstvWork.Items(i4).SubItems(7).Text & "'," +
        '   "'" & lstvWork.Items(i4).SubItems(8).Text & "','" & lstvWork.Items(i4).SubItems(9).Text & "')"
        '    sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        '    sqlcmd.ExecuteNonQuery()
        '    sqlquery = vbEmpty
        '    sqlcmd.Dispose()
        'Next
        ' ''==============================End of work experience =======

        ' ''===============================Beginning of voluntary or trainings============
        'sqlquery = "DELETE FROM public.works_trainings WHERE emp_no = " & emp_no.Text
        'sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        'sqlcmd.ExecuteNonQuery()
        'sqlquery = vbEmpty
        'sqlcmd.Dispose()

        'For i5 As Integer = 0 To lstvWorksTraining.Items.Count - 1
        '    Dim new_id As Integer = 0
        '    Try
        '        Call selectdata("SELECT MAX(work_id)+1 as New_ID from works_trainings")
        '        sqldr.Read()
        '        new_id = sqldr("New_ID")
        '        sqlclose()
        '    Catch ex As Exception
        '        new_id = 1
        '    End Try

        '    sqlquery = "INSERT INTO public.works_trainings(" +
        '   " emp_no, work_id, organization_name, organization_add, " +
        '   " date_from, date_to, hours_no, work_position,training_work)" +
        '   " VALUES (" & CInt(emp_no.Text) & ",'" & new_id & "','" & lstvWorksTraining.Items(i5).SubItems(1).Text & "','" & lstvWorksTraining.Items(i5).SubItems(2).Text & "'" +
        '    ",'" & lstvWorksTraining.Items(i5).SubItems(3).Text & "','" & lstvWorksTraining.Items(i5).SubItems(4).Text & "','" & lstvWorksTraining.Items(i5).SubItems(5).Text & "'," +
        '   "'" & lstvWorksTraining.Items(i5).SubItems(6).Text & "','" & lstvWorksTraining.Items(i5).SubItems(7).Text & "')"
        '    sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        '    sqlcmd.ExecuteNonQuery()
        '    sqlquery = vbEmpty
        '    sqlcmd.Dispose()
        'Next
        ' ''============================end

        ' ''=========================Beginning
        'sqlquery = "DELETE FROM public.seminars WHERE emp_no = " & emp_no.Text
        'sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        'sqlcmd.ExecuteNonQuery()
        'sqlquery = vbEmpty
        'sqlcmd.Dispose()

        'For i6 As Integer = 0 To lstvSeminar.Items.Count - 1
        '    Dim new_id As Integer = 0
        '    Try
        '        Call selectdata("SELECT MAX(sem_id)+1 as New_ID from seminars")
        '        sqldr.Read()
        '        new_id = sqldr("New_ID")
        '        sqlclose()
        '    Catch ex As Exception
        '        new_id = 1
        '    End Try

        '    sqlquery = "INSERT INTO public.seminars(" +
        '   "emp_no, sem_id, title, venue, date_from, date_to, hours_no, sponsor) " +
        '   " VALUES (" & CInt(emp_no.Text) & ",'" & new_id & "','" & lstvSeminar.Items(i6).SubItems(1).Text & "','" & lstvSeminar.Items(i6).SubItems(2).Text & "'" +
        '    ",'" & lstvSeminar.Items(i6).SubItems(3).Text & "','" & lstvSeminar.Items(i6).SubItems(4).Text & "','" & lstvSeminar.Items(i6).SubItems(5).Text & "'," +
        '   "'" & lstvSeminar.Items(i6).SubItems(6).Text & "')"
        '    sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        '    sqlcmd.ExecuteNonQuery()
        '    sqlquery = vbEmpty
        '    sqlcmd.Dispose()
        'Next
        '' ''======================end
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If SavingStatus = "Save" Then
                Call InsertingData()
                Call InsertLog("Saving Profile of " & fname.Text & " " & mname.Text & " " & lname.Text)
                MsgBox("DATA SUCCESFULLY SAVED!")
            ElseIf SavingStatus = "Update" Then
                Call UpdatingData()
                Call InsertLog("Updating Profile of " & fname.Text & " " & mname.Text & " " & lname.Text)
                MsgBox("UPDATES SUCCESFULLY SAVE!")
            End If
            Call DisablingChildren()
            Call DisablingEducationalBackground()
            Call DisablingEligibility()
            Call DisablingFamilyBackground()
            Call DisablingPersonalInfo()
            Call DisablingSeminar()
            Call DisablingVoluntary()
            Call DisablingWork()
            btnSave.Text = "Save"
            SavingStatus = "None"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Call EnablingChildren()
        Call EnablingEducationalBackground()
        Call EnablingEligibility()
        Call EnablingFamilyBackground()
        Call EnablingPersonalInfo()
        Call EnablingSeminar()
        Call EnablingVoluntary()
        Call EnablingWork()
        Call InsertLog("Attempting to edit the data of " & fname.Text & " " & mname.Text & " " & lname.Text)
        btnSave.Text = "Update"
        SavingStatus = "Update"
    End Sub
    Public Sub Form_size()
        Dim ScreenSize As System.Drawing.Rectangle = Screen.PrimaryScreen.WorkingArea
        Me.Size = New System.Drawing.Size(ScreenSize.Width, ScreenSize.Height)
        Me.Location = New System.Drawing.Point(0, 0)
    End Sub

    Private Sub frm_Profiling_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frm_Login.Show()
        Call InsertLog("Logged out")
        sqlconn.Close()
        DefaultSqlconn.Close()
    End Sub
    Private Sub frm_Profiling_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Call Form_size()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        OptionYesNoForm.btnOk.Enabled = True
        OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete " & emp_no.Text & " from the list?"
        OptionYesNoForm.ShowDialog()
        If OptionYesNoForm.YNoption = True Then
            Call InsertLog("Delete the Profile of " & fname.Text & " " & mname.Text & " " & lname.Text)
            Try
                sqlquery = "DELETE FROM public.seminars WHERE emp_no = " & emp_no.Text & ";" &
                                "DELETE FROM public.works_trainings WHERE emp_no = " & emp_no.Text & ";" &
                                "DELETE FROM public.service_record WHERE emp_no = " & emp_no.Text & ";" &
                                 "DELETE FROM public.eligibility_info WHERE emp_no = " & emp_no.Text & ";" &
                                 "DELETE FROM public.educational_background WHERE emp_no = " & emp_no.Text & ";" &
                                 "DELETE FROM public.children WHERE emp_no = " & emp_no.Text & ";" &
                                 "DELETE FROM  public.family_background WHERE emp_no = " & emp_no.Text & ";" &
                                 "DELETE FROM public.personal_info WHERE emp_no = " & emp_no.Text & ";"
                sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
                sqlcmd.ExecuteNonQuery()
                sqlquery = vbEmpty
                sqlcmd.Dispose()
                Call ClearingChildren()
                Call ClearingEducationalBackground()
                Call ClearingEligibility()
                Call ClearingPersonalInfo()
                Call ClearingFamilyBackground()
                Call ClearingSeminar()
                Call ClearingVoluntary()
                Call ClearingWork()
                Call DisablingChildren()
                Call DisablingEducationalBackground()
                Call DisablingEligibility()
                Call DisablingFamilyBackground()
                Call DisablingPersonalInfo()
                Call DisablingSeminar()
                Call DisablingVoluntary()
                Call DisablingWork()
                SavingStatus = "None"
                btnSave.Text = "Save"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call CheckingFields()
    End Sub

    Private Sub emp_no_TextChanged(sender As Object, e As EventArgs) Handles emp_no.TextChanged
        Call CheckingFields()
    End Sub

    Private Sub fname_TextChanged(sender As Object, e As EventArgs) Handles fname.TextChanged
        Call CheckingFields()
    End Sub

    Private Sub mname_TextChanged(sender As Object, e As EventArgs) Handles lname.TextChanged
        Call CheckingFields()
    End Sub
    Dim imgLoc As String
    Private Sub ChooseImage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ChooseImage.LinkClicked
        Try
            With OpenFileDialog1
                .FileName = "SELECT PICTURE"
                .Filter = "ALL Files (*.*)|*.*| JPEG Files (*.jpg)|*.jpg| PNG Files (*.png)|*.png| GIF Files (*.gif)|*.gif"
                .Title = "Select Product Image"
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    imgLoc = OpenFileDialog1.FileName.ToString
                    emp_image.ImageLocation = OpenFileDialog1.FileName
                    'PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                End If
            End With
        Catch ex As Exception
            MsgBox("Unknown error occurred!")
        End Try
    End Sub

    Private Sub AddToEducationalBackground()
        Dim newbackid As String = ""
        Try
            Call selectdata("SELECT MAX(edback_id)+1 as New_ID from educational_background")
            sqldr.Read()
            newbackid = sqldr("New_ID")
            sqlclose()
        Catch ex As Exception
            newbackid = "1"
        End Try
        newbackid = (CInt(newbackid) + lstvEducationalBackground.Items.Count).ToString
        With lstvEducationalBackground
            .Items.Add(newbackid)
            With .Items(.Items.Count - 1).SubItems
                .Add(level.Text)
                .Add(school_name.Text)
                .Add(school_add.Text)
                .Add(degree_course.Text)
                If year_graduated.Text = "" Then
                    .Add(year_graduated.Text)
                Else
                    .Add("0")
                End If
                .Add(highest_level_notgraduated.Text)
                .Add(inclusive_date_from.Text)
                .Add(inclusive_date_to.Text)
                .Add(honor_received.Text)
            End With
        End With
    End Sub

    Dim education_position As Integer
    Dim education_saving As Boolean = False
    Dim education_updates As String = ""
    Private Sub assign_education()
        education_position = lstvEducationalBackground.FocusedItem.Index
        education_saving = True
        education_updates = lstvEducationalBackground.FocusedItem.SubItems(0).Text
        level.Text = lstvEducationalBackground.FocusedItem.SubItems(1).Text
        school_name.Text = lstvEducationalBackground.FocusedItem.SubItems(2).Text
        school_add.Text = lstvEducationalBackground.FocusedItem.SubItems(3).Text
        degree_course.Text = lstvEducationalBackground.FocusedItem.SubItems(4).Text
        year_graduated.Text = lstvEducationalBackground.FocusedItem.SubItems(5).Text
        highest_level_notgraduated.Text = lstvEducationalBackground.FocusedItem.SubItems(6).Text
        inclusive_date_from.Text = lstvEducationalBackground.FocusedItem.SubItems(7).Text
        inclusive_date_to.Text = lstvEducationalBackground.FocusedItem.SubItems(8).Text
        honor_received.Text = lstvEducationalBackground.FocusedItem.SubItems(9).Text
    End Sub
    Private Sub update_education()
        lstvEducationalBackground.Items(education_position).SubItems(1).Text = level.Text
        lstvEducationalBackground.Items(education_position).SubItems(2).Text = school_name.Text
        lstvEducationalBackground.Items(education_position).SubItems(3).Text = degree_course.Text
        lstvEducationalBackground.Items(education_position).SubItems(4).Text = year_graduated.Text
        lstvEducationalBackground.Items(education_position).SubItems(5).Text = highest_level_notgraduated.Text
        lstvEducationalBackground.Items(education_position).SubItems(6).Text = inclusive_date_from.Text
        lstvEducationalBackground.Items(education_position).SubItems(7).Text = inclusive_date_to.Text
        lstvEducationalBackground.Items(education_position).SubItems(8).Text = honor_received.Text
        education_saving = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If SavingStatus = "Save" Then
            Try
                If education_saving = False Then
                    Call AddToEducationalBackground()
                    Call ClearingEducationalBackground()
                Else
                    Call update_education()
                    Call ClearingEducationalBackground()
                End If
                education_saving = False
            Catch ex As Exception

            End Try
        ElseIf SavingStatus = "Update" Then
            Try
                If education_saving = False Then
                    Dim new_id As Integer = 0
                    Try
                        Call selectdata("SELECT MAX(edback_id)+1 as New_ID from educational_background")
                        sqldr.Read()
                        new_id = sqldr("New_ID")
                        Call sqlclose()
                    Catch ex As Exception
                        new_id = 1
                    End Try
                    Call insert("INSERT INTO public.educational_background(emp_no, edback_id, level, school_name, school_add, degree_course, " &
                            " year_graduated, highest_level_notgraduated, inclusive_date_from, inclusive_date_to, honor_received) " &
                            " VALUES (" & emp_no.Text & "," & new_id & ",'" & level.Text & "','" & school_name.Text & "','" & school_add.Text &
                            "','" & degree_course.Text & "'," & year_graduated.Text & ",'" & highest_level_notgraduated.Text & "','" & inclusive_date_from.Text &
                            "','" & inclusive_date_to.Text & "','" & honor_received.Text & "')")
                Else
                    Call insert("update educational_background set level ='" & level.Text & "',school_name = '" & school_name.Text & "', school_add = '" & school_add.Text &
                            "',degree_course = '" & degree_course.Text & "',year_graduated = " & year_graduated.Text &
                            ",highest_level_notgraduated ='" & highest_level_notgraduated.Text & "',inclusive_date_from = '" & inclusive_date_from.Text &
                            "',inclusive_date_to = '" & inclusive_date_to.Text & "',honor_received = '" & honor_received.Text & "' where emp_no = " & emp_no.Text & " and edback_id = " & education_updates)
                End If
                Call ClearingEducationalBackground()
                Call loadeducationalbackground(emp_no.Text)
                education_saving = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else

        End If
    End Sub

    Private Sub year_graduated_KeyPress(sender As Object, e As KeyPressEventArgs) Handles year_graduated.KeyPress
        Call IntDouble(False, e)
    End Sub

    Private Sub year_graduated_TextChanged(sender As Object, e As EventArgs) Handles year_graduated.TextChanged

    End Sub

    Private Sub addtolist_children()
        Dim new_id As Integer = 0
        Try
            Call selectdata("SELECT MAX(child_id)+1 as New_ID from children")
            sqldr.Read()
            new_id = sqldr("New_ID")
            sqlclose()
        Catch ex As Exception
            new_id = 1
        End Try
        new_id = new_id + lstvChildren.Items.Count
        With lstvChildren
            .Items.Add(new_id)
            With .Items(.Items.Count - 1).SubItems
                .Add(cfname.Text)
                .Add(clname.Text)
                .Add(clname.Text)
                .Add(cname_ext.Text)
                .Add(cbirth_date.Text)
            End With
        End With
    End Sub

    Dim children_position As Integer
    Dim children_saving As Boolean = False
    Dim children_updates As String = ""
    Private Sub assign_children()
        children_updates = lstvChildren.FocusedItem.SubItems(0).Text
        children_position = lstvChildren.FocusedItem.Index
        children_saving = True
        cfname.Text = lstvChildren.FocusedItem.SubItems(1).Text
        cmname.Text = lstvChildren.FocusedItem.SubItems(2).Text
        clname.Text = lstvChildren.FocusedItem.SubItems(3).Text
        cname_ext.Text = lstvChildren.FocusedItem.SubItems(4).Text
        cbirth_date.Text = lstvChildren.FocusedItem.SubItems(5).Text
    End Sub
    Private Sub update_children()
        lstvChildren.Items(children_position).SubItems(1).Text = cfname.Text
        lstvChildren.Items(children_position).SubItems(2).Text = cmname.Text
        lstvChildren.Items(children_position).SubItems(3).Text = clname.Text
        lstvChildren.Items(children_position).SubItems(4).Text = cname_ext.Text
        lstvChildren.Items(children_position).SubItems(5).Text = cbirth_date.Text
        children_saving = False
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If SavingStatus = "Save" Then
            Try
                If children_saving = False Then
                    Call addtolist_children()
                    Call ClearingChildren()
                Else
                    Call update_children()
                    Call ClearingChildren()
                End If
                children_saving = False
            Catch ex As Exception

            End Try
        ElseIf SavingStatus = "Update" Then
            Try
                If children_saving = False Then
                    Dim new_id As Integer = 0
                    Try
                        Call selectdata("SELECT MAX(child_id)+1 as New_ID from children")
                        sqldr.Read()
                        new_id = sqldr("New_ID")
                        Call sqlclose()
                    Catch ex As Exception
                        new_id = 1
                    End Try
                    Call insert("INSERT INTO public.children(emp_no, child_id, fname, mname, lname, name_ext, birth_date) " &
                        "VALUES (" & emp_no.Text & "," & new_id & ",'" & cfname.Text & "','" & cmname.Text & "','" & clname.Text &
                        "','" & cname_ext.Text & "','" & cbirth_date.Text & "')")
                Else
                    Call insert("UPDATE public.children SET fname= '" & cfname.Text & "', mname= '" & cmname.Text & "', lname= '" & lname.Text & "', name_ext= '" & cname_ext.Text & "', " &
               "birth_date= '" & cbirth_date.Text & "' WHERE emp_no = " & emp_no.Text & " and child_id = " & children_updates)

                End If
                Call ClearingChildren()
                Call loadchildren(emp_no.Text)
                children_saving = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else

        End If

    End Sub

    Private Sub addtolist_eligibility()
        Dim new_id As Integer = 0
        Try
            Call selectdata("SELECT MAX(elig_id)+1 as New_ID from eligibility_info")
            sqldr.Read()
            new_id = sqldr("New_ID")
            sqlclose()
        Catch ex As Exception
            new_id = 1
        End Try
        new_id = new_id + lstvEligibilty.Items.Count
        With lstvEligibilty
            .Items.Add(new_id)
            With .Items(.Items.Count - 1).SubItems
                .Add(Eligibilty_name.Text)
                .Add(rating.Text)
                .Add(exam_date.Text)
                .Add(exam_add.Text)
                .Add(license.Text)
                .Add(date_released.Text)
            End With
        End With
    End Sub

    Dim eligibility_position As Integer
    Dim eligibility_saving As Boolean = False
    Dim eligibilty_update As String = ""
    Private Sub assign_eligibility()
        eligibility_position = lstvEligibilty.FocusedItem.Index
        eligibility_saving = True
        eligibilty_update = lstvEligibilty.FocusedItem.SubItems(0).Text
        Eligibilty_name.Text = lstvEligibilty.FocusedItem.SubItems(1).Text
        rating.Text = lstvEligibilty.FocusedItem.SubItems(2).Text
        exam_date.Text = lstvEligibilty.FocusedItem.SubItems(3).Text
        exam_add.Text = lstvEligibilty.FocusedItem.SubItems(4).Text
        license.Text = lstvEligibilty.FocusedItem.SubItems(5).Text
        date_released.Text = lstvEligibilty.FocusedItem.SubItems(6).Text
    End Sub
    Private Sub update_eligibility()
        lstvEligibilty.Items(eligibility_position).SubItems(1).Text = Eligibilty_name.Text
        lstvEligibilty.Items(eligibility_position).SubItems(2).Text = rating.Text
        lstvEligibilty.Items(eligibility_position).SubItems(3).Text = exam_date.Text
        lstvEligibilty.Items(eligibility_position).SubItems(4).Text = exam_add.Text
        lstvEligibilty.Items(eligibility_position).SubItems(5).Text = license.Text
        lstvEligibilty.Items(eligibility_position).SubItems(6).Text = date_released.Text
        education_saving = False
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If SavingStatus = "Save" Then
            Try
                If eligibility_saving = False Then
                    Call addtolist_eligibility()
                    Call ClearingEligibility()
                Else
                    Call update_eligibility()
                    Call ClearingEligibility()
                End If
                eligibility_saving = False
            Catch ex As Exception
            End Try
        ElseIf SavingStatus = "Update" Then
            Try
                If eligibility_saving = False Then
                    Dim new_id As Integer = 0
                    Try
                        Call selectdata("SELECT MAX(elig_id)+1 as New_ID from eligibility_info")
                        sqldr.Read()
                        new_id = sqldr("New_ID")
                        Call sqlclose()
                    Catch ex As Exception
                        new_id = 1
                    End Try
                    Call insert("INSERT INTO public.eligibility_info(emp_no, elig_id, name, rating, exam_date, exam_add, license,date_released) " &
                        "VALUES (" & emp_no.Text & "," & new_id & ",'" & Eligibilty_name.Text & "','" & rating.Text & "','" & exam_date.Text &
                        "','" & exam_add.Text & "','" & license.Text & "', '" & date_released.Text & "')")
                Else
                    Call insert("UPDATE public.eligibility_info SET name= '" & Eligibilty_name.Text & "', rating= '" & rating.Text & "', exam_date= '" & exam_date.Text & "', exam_add= '" & exam_add.Text & "', " &
                        "license= '" & license.Text & "', date_released = '" & date_released.Text & "' WHERE emp_no = " & emp_no.Text & " and elig_id = " & eligibilty_update)
                End If
                Call ClearingEligibility()
                Call loadeligibility(emp_no.Text)
                eligibility_saving = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub ComboBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        Try
            Dim qry As String = ""
            If ComboBox1.Text = "All" Then
                qry = " where fname like '" & TextBox6.Text.Replace("'", "\'") & "%' or lname like '" & TextBox6.Text.Replace("'", "\'") & "%'"
            ElseIf ComboBox1.Text = "ID" Then
                qry = " where emp_no = " & Replacer(TextBox6.Text)
            ElseIf ComboBox1.Text = "Item Number" Then
                qry = " where item_no = " & Replacer(TextBox6.Text)
            ElseIf ComboBox1.Text = "First Name" Then
                qry = " where fname = " & Replacer(TextBox6.Text)
            ElseIf ComboBox1.Text = "Last Name" Then
                qry = " where lname = " & Replacer(TextBox6.Text)
            End If
            If TextBox6.Text = "" Then
                qry = ""
                Call ClearingChildren()
                Call ClearingEducationalBackground()
                Call ClearingEligibility()
                Call ClearingPersonalInfo()
                Call ClearingFamilyBackground()
                Call ClearingSeminar()
                Call ClearingVoluntary()
                Call ClearingWork()
                Call DisablingChildren()
                Call DisablingEducationalBackground()
                Call DisablingEligibility()
                Call DisablingFamilyBackground()
                Call DisablingPersonalInfo()
                Call DisablingSeminar()
                Call DisablingVoluntary()
                Call DisablingWork()
                btnSave.Text = "Save"
                SavingStatus = "None"
            Else
                Call DisplayData(qry)
            End If
            SavingStatus = "None"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub addtolist_work()
        Dim servicetype As String = ""
        If service_type_government.Checked = True Then
            servicetype = "Government Serive"
        ElseIf service_type_private.Checked = True Then
            servicetype = "Private Service"
        End If
        Dim new_id As Integer = 0
        Try
            Call selectdata("SELECT MAX(servicerec_id)+1 as New_ID from service_record")
            sqldr.Read()
            new_id = sqldr("New_ID")
            sqlclose()
        Catch ex As Exception
            new_id = 1
        End Try
        new_id = new_id + lstvWork.Items.Count
        With lstvWork
            .Items.Add(new_id)
            With .Items(.Items.Count - 1).SubItems
                .Add(date_from.Text)
                .Add(date_to.Text)
                .Add(position_title.Text)
                .Add(institution_name.Text)
                .Add(salary_grade.Text)
                .Add(step_inc.Text)
                .Add(monthly_salary.Text)
                .Add(appointment_status.Text)
                .Add(servicetype)
            End With
        End With
    End Sub


    Dim servicetype As String = ""
    Dim workexp_position As Integer
    Dim workexp_saving As Boolean = False
    Dim workexp_update As String = ""
    Private Sub assign_workexp()
        workexp_position = lstvWork.FocusedItem.Index
        workexp_saving = True
        workexp_update = lstvWork.FocusedItem.SubItems(0).Text
        date_from.Text = lstvWork.FocusedItem.SubItems(1).Text
        date_to.Text = lstvWork.FocusedItem.SubItems(2).Text
        position_title.Text = lstvWork.FocusedItem.SubItems(3).Text
        institution_name.Text = lstvWork.FocusedItem.SubItems(4).Text
        salary_grade.Text = lstvWork.FocusedItem.SubItems(5).Text
        step_inc.Text = lstvWork.FocusedItem.SubItems(6).Text
        monthly_salary.Text = lstvWork.FocusedItem.SubItems(7).Text
        appointment_status.Text = lstvWork.FocusedItem.SubItems(8).Text
        If service_type_government.Text = lstvWork.FocusedItem.SubItems(9).Text Then
            service_type_government.Checked = True
        ElseIf service_type_private.Text = lstvWork.FocusedItem.SubItems(9).Text Then
            service_type_private.Checked = True
        End If

    End Sub
    Private Sub update_workexp()
        lstvWork.Items(workexp_position).SubItems(1).Text = date_from.Text
        lstvWork.Items(workexp_position).SubItems(2).Text = date_to.Text
        lstvWork.Items(workexp_position).SubItems(3).Text = position_title.Text
        lstvWork.Items(workexp_position).SubItems(4).Text = institution_name.Text
        lstvWork.Items(workexp_position).SubItems(5).Text = salary_grade.Text
        lstvWork.Items(workexp_position).SubItems(6).Text = step_inc.Text
        lstvWork.Items(workexp_position).SubItems(7).Text = monthly_salary.Text
        lstvWork.Items(workexp_position).SubItems(8).Text = appointment_status.Text
        If lstvWork.FocusedItem.SubItems(9).Text = service_type_government.Text Then
            lstvWork.FocusedItem.SubItems(9).Text = service_type_government.Text
        ElseIf lstvWork.FocusedItem.SubItems(9).Text = service_type_private.Text Then
            lstvWork.FocusedItem.SubItems(9).Text = service_type_private.Text
        End If
        workexp_saving = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If service_type_government.Checked = True Then
            servicetype = "Government Serive"
        ElseIf service_type_private.Checked = True Then
            servicetype = "Private Service"
        End If
        If SavingStatus = "Save" Then
            Try
                If workexp_saving = False Then
                    Call addtolist_work()
                    Call ClearingWork()
                Else
                    Call update_workexp()
                    Call ClearingWork()
                End If
                workexp_saving = False
            Catch ex As Exception
            End Try
        ElseIf SavingStatus = "Update" Then
            Try
                If workexp_saving = False Then
                    Dim new_id As Integer = 0
                    Try
                        Call selectdata("SELECT MAX(servicerec_id)+1 as New_ID from service_record")
                        sqldr.Read()
                        new_id = sqldr("New_ID")
                        Call sqlclose()
                    Catch ex As Exception
                        new_id = 1
                    End Try
                    Call insert("INSERT INTO public.service_record(emp_no, servicerec_id, date_from, date_to, position_title, institution_name, " &
                        "salary_grade, step_inc, monthly_salary, appointment_status, service_type) " &
                        "VALUES (" & emp_no.Text & "," & new_id & ",'" & date_from.Text & "','" & date_to.Text & "','" & position_title.Text &
                        "','" & institution_name.Text & "','" & salary_grade.Text & "', '" & step_inc.Text & "', '" & monthly_salary.Text & "'" &
                        ", '" & appointment_status.Text & "', '" & servicetype & "')")
                Else
                    Call insert("UPDATE public.service_record SET date_from = '" & date_from.Text & "', date_to = '" & date_to.Text & "', position_title = '" & position_title.Text & "', institution_name = '" & institution_name.Text & "', " &
                        "salary_grade = '" & salary_grade.Text & "', step_inc = '" & step_inc.Text & "', monthly_salary = '" & monthly_salary.Text & "', appointment_status = '" & appointment_status.Text & "', service_type = '" & servicetype & "' WHERE emp_no = " & emp_no.Text & " and servicerec_id = " & workexp_update)
                End If
                Call ClearingWork()
                Call loadservicerecord(emp_no.Text)
                workexp_saving = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub addtolist_voluntary()
        Dim trainingwork As String = ""
        If training_work_voluntary.Checked = True Then
            trainingwork = "Voluntary Works"
        ElseIf training_work_training.Checked = True Then
            trainingwork = "Trainings"
        End If
        Dim new_id As Integer = 0
        Try
            Call selectdata("SELECT MAX(work_id)+1 as New_ID from works_trainings")
            sqldr.Read()
            new_id = sqldr("New_ID")
            sqlclose()
        Catch ex As Exception
            new_id = 1
        End Try
        new_id = new_id + lstvWorksTraining.Items.Count
        With lstvWorksTraining
            .Items.Add(new_id)
            With .Items(.Items.Count - 1).SubItems
                .Add(organization_name.Text)
                .Add(organization_add.Text)
                .Add(VW_date_from.Text)
                .Add(VW_date_to.Text)
                .Add(hours_no.Text)
                .Add(work_position.Text)
                .Add(trainingwork)

            End With
        End With

    End Sub

    Dim trainingwork As String = ""
    Dim voluntary_position As Integer
    Dim voluntary_saving As Boolean = False
    Dim voluntary_update As String = ""
    Private Sub assign_voluntary()
        voluntary_position = lstvWorksTraining.FocusedItem.Index
        voluntary_saving = True
        voluntary_update = lstvWorksTraining.FocusedItem.SubItems(0).Text
        organization_name.Text = lstvWorksTraining.FocusedItem.SubItems(1).Text
        organization_add.Text = lstvWorksTraining.FocusedItem.SubItems(2).Text
        VW_date_from.Text = lstvWorksTraining.FocusedItem.SubItems(3).Text
        VW_date_to.Text = lstvWorksTraining.FocusedItem.SubItems(4).Text
        hours_no.Text = lstvWorksTraining.FocusedItem.SubItems(5).Text
        work_position.Text = lstvWorksTraining.FocusedItem.SubItems(6).Text
        If training_work_voluntary.Text = lstvWorksTraining.FocusedItem.SubItems(7).Text Then
            training_work_voluntary.Checked = True
        ElseIf training_work_training.Text = lstvWorksTraining.FocusedItem.SubItems(7).Text Then
            training_work_training.Checked = True
        End If

    End Sub
    Private Sub update_voluntary()
        lstvWorksTraining.Items(voluntary_position).SubItems(1).Text = date_from.Text
        lstvWorksTraining.Items(voluntary_position).SubItems(2).Text = date_to.Text
        lstvWorksTraining.Items(voluntary_position).SubItems(3).Text = position_title.Text
        lstvWorksTraining.Items(voluntary_position).SubItems(4).Text = institution_name.Text
        lstvWorksTraining.Items(voluntary_position).SubItems(5).Text = salary_grade.Text
        lstvWorksTraining.Items(voluntary_position).SubItems(6).Text = step_inc.Text
        If lstvWorksTraining.FocusedItem.SubItems(7).Text = training_work_voluntary.Text Then
            lstvWorksTraining.FocusedItem.SubItems(7).Text = training_work_voluntary.Text
        ElseIf lstvWorksTraining.FocusedItem.SubItems(7).Text = training_work_training.Text Then
            lstvWorksTraining.FocusedItem.SubItems(7).Text = training_work_training.Text
        End If
        education_saving = False
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If training_work_voluntary.Checked = True Then
            trainingwork = "Voluntary Works"
        ElseIf training_work_training.Checked = True Then
            trainingwork = "Trainings"
        End If
        If SavingStatus = "Save" Then
            Try
                If voluntary_saving = False Then
                    Call addtolist_voluntary()
                    Call ClearingVoluntary()
                Else
                    Call update_voluntary()
                    Call ClearingVoluntary()
                End If
                voluntary_saving = False
            Catch ex As Exception
            End Try
        ElseIf SavingStatus = "Update" Then
            Try
                If voluntary_saving = False Then
                    Dim new_id As Integer = 0
                    Try
                        Call selectdata("SELECT MAX(work_id)+1 as New_ID from works_trainings")
                        sqldr.Read()
                        new_id = sqldr("New_ID")
                        Call sqlclose()
                    Catch ex As Exception
                        new_id = 1
                    End Try
                    Call insert("INSERT INTO public.works_trainings(emp_no, work_id, training_work, organization_name, organization_add, " &
                        " date_from, date_to, hours_no, work_position) " &
                        "VALUES (" & emp_no.Text & "," & new_id & ",'" & trainingwork & "','" & organization_name.Text & "','" & organization_add.Text &
                        "','" & VW_date_from.Text & "','" & VW_date_to.Text & "', '" & hours_no.Text & "','" & work_position.Text & "')")
                Else
                    Call insert("UPDATE public.works_trainings SET training_work = '" & trainingwork & "', organization_name = '" & organization_name.Text & "', organization_add = '" & organization_add.Text & "', " &
                        " date_from = '" & VW_date_from.Text & "', date_to = '" & VW_date_to.Text & "', hours_no = '" & hours_no.Text & "', work_position = '" & work_position.Text & "' WHERE emp_no = " & emp_no.Text & " and work_id = " & voluntary_update)
                End If
                Call ClearingVoluntary()
                Call loadworkstraining(emp_no.Text)
                voluntary_saving = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub addtolist_seminar()
        Dim new_id As Integer = 0
        Try
            Call selectdata("SELECT MAX(sem_id)+1 as New_ID from seminars")
            sqldr.Read()
            new_id = sqldr("New_ID")
            sqlclose()
        Catch ex As Exception
            new_id = 1
        End Try
        new_id = new_id + lstvSeminar.Items.Count
        With lstvSeminar
            .Items.Add(new_id)
            With .Items(.Items.Count - 1).SubItems
                .Add(title.Text)
                .Add(venue.Text)
                .Add(S_date_from.Text)
                .Add(S_date_to.Text)
                .Add(S_hours_no.Text)
                .Add(sponsor.Text)
            End With
        End With
    End Sub
    Dim seminar_position As Integer
    Dim seminar_saving As Boolean = False
    Dim seminar_update As String = ""
    Private Sub assign_seminar()
        seminar_position = lstvSeminar.FocusedItem.Index
        seminar_saving = True
        seminar_update = lstvSeminar.FocusedItem.SubItems(0).Text
        title.Text = lstvSeminar.FocusedItem.SubItems(1).Text
        venue.Text = lstvSeminar.FocusedItem.SubItems(2).Text
        S_date_from.Text = lstvSeminar.FocusedItem.SubItems(3).Text
        S_date_to.Text = lstvSeminar.FocusedItem.SubItems(4).Text
        S_hours_no.Text = lstvSeminar.FocusedItem.SubItems(5).Text
        sponsor.Text = lstvSeminar.FocusedItem.SubItems(6).Text

    End Sub
    Private Sub update_seminar()
        lstvSeminar.Items(eligibility_position).SubItems(1).Text = title.Text
        lstvSeminar.Items(eligibility_position).SubItems(2).Text = venue.Text
        lstvSeminar.Items(eligibility_position).SubItems(3).Text = S_date_from.Text
        lstvSeminar.Items(eligibility_position).SubItems(4).Text = S_date_to.Text
        lstvSeminar.Items(eligibility_position).SubItems(5).Text = S_hours_no.Text
        lstvSeminar.Items(eligibility_position).SubItems(6).Text = sponsor.Text
        seminar_saving = False
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If SavingStatus = "Save" Then
            Try
                If eligibility_saving = False Then
                    Call addtolist_seminar()
                    Call ClearingSeminar()
                Else
                    Call update_seminar()
                    Call ClearingSeminar()
                End If
                seminar_saving = False
            Catch ex As Exception
            End Try
        ElseIf SavingStatus = "Update" Then
            Try
                If seminar_saving = False Then
                    Dim new_id As Integer = 0
                    Try
                        Call selectdata("SELECT MAX(sem_id)+1 as New_ID from seminars")
                        sqldr.Read()
                        new_id = sqldr("New_ID")
                        Call sqlclose()
                    Catch ex As Exception
                        new_id = 1
                    End Try
                    Call insert("INSERT INTO public.seminars(emp_no, sem_id, title, venue, date_from, date_to, hours_no, sponsor) " &
                        "VALUES (" & emp_no.Text & "," & new_id & ",'" & title.Text & "','" & venue.Text & "','" & S_date_from.Text &
                        "','" & S_date_to.Text & "','" & S_hours_no.Text & "', '" & sponsor.Text & "')")
                Else
                    Call insert("UPDATE public.seminars SET title = '" & title.Text & "', venue = '" & venue.Text & "', date_from = '" & S_date_from.Text & "', " &
                                "date_to = '" & S_date_to.Text & "', hours_no = '" & S_hours_no.Text & "', sponsor = '" & sponsor.Text & "' WHERE emp_no = " & emp_no.Text & " and sem_id = " & seminar_update)
                End If
                Call ClearingSeminar()
                Call loadseminars(emp_no.Text)
                seminar_saving = False
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Try

            Call assign_seminar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListForm.Show()
        Call InsertLog("Viewed the list of employees")
        Me.Hide()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            Call assign_children()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If SavingStatus = "Save" Then
            Try
                OptionYesNoForm.btnOk.Enabled = True
                OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete all?"
                OptionYesNoForm.ShowDialog()
                If OptionYesNoForm.YNoption = True Then
                    lstvChildren.Items.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf SavingStatus = "Update" Then
            OptionYesNoForm.btnOk.Enabled = True
            OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete all?"
            OptionYesNoForm.ShowDialog()
            If OptionYesNoForm.YNoption = True Then
                Call insert("delete from children where emp_no = " & emp_no.Text)
                Call loadchildren(emp_no.Text)
            End If
        Else
            MsgBox("Unable to delete all")
        End If


    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        If SavingStatus = "Save" Then
            Try
                Try
                    OptionYesNoForm.btnOk.Enabled = True
                    OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
                    OptionYesNoForm.ShowDialog()
                    If OptionYesNoForm.YNoption = True Then
                        lstvChildren.FocusedItem.Remove()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf SavingStatus = "Update" Then
            OptionYesNoForm.btnOk.Enabled = True
            OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
            OptionYesNoForm.ShowDialog()
            If OptionYesNoForm.YNoption = True Then
                Call insert("delete from children where emp_no = " & emp_no.Text & " and child_id = " & lstvChildren.FocusedItem.SubItems(0).Text)
                Call loadchildren(emp_no.Text)
            End If
        Else
            MsgBox("Unable to delete all")
        End If
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        Try
            Call assign_education()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        If SavingStatus = "Save" Then
            Try
                OptionYesNoForm.btnOk.Enabled = True
                OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete all?"
                OptionYesNoForm.ShowDialog()
                If OptionYesNoForm.YNoption = True Then
                    lstvEducationalBackground.Items.Clear()
                End If
            Catch ex As Exception

            End Try
        ElseIf SavingStatus = "Update" Then
            OptionYesNoForm.btnOk.Enabled = True
            OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
            OptionYesNoForm.ShowDialog()
            If OptionYesNoForm.YNoption = True Then
                Call insert("DELETE FROM educational_background where emp_no = " & emp_no.Text)
                Call loadeducationalbackground(emp_no.Text)
            End If
        Else
            MsgBox("Unable to delete")
        End If
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        If SavingStatus = "Save" Then
            Try
                OptionYesNoForm.btnOk.Enabled = True
                OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
                OptionYesNoForm.ShowDialog()
                If OptionYesNoForm.YNoption = True Then
                    lstvEducationalBackground.FocusedItem.Remove()
                End If
            Catch ex As Exception

            End Try
        ElseIf SavingStatus = "Update" Then
            OptionYesNoForm.btnOk.Enabled = True
            OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
            OptionYesNoForm.ShowDialog()
            If OptionYesNoForm.YNoption = True Then
                Call insert("DELETE FROM educational_background where emp_no = " & emp_no.Text & " and edback_id = " & lstvEducationalBackground.FocusedItem.SubItems(0).Text)
                Call loadeducationalbackground(emp_no.Text)
            End If
        Else
            MsgBox("Unable to delete")
        End If
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        Try
            Call assign_eligibility()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        If SavingStatus = "Save" Then
            Try
                OptionYesNoForm.btnOk.Enabled = True
                OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete all?"
                OptionYesNoForm.ShowDialog()
                If OptionYesNoForm.YNoption = True Then
                    lstvEligibilty.Items.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf SavingStatus = "Update" Then
            OptionYesNoForm.btnOk.Enabled = True
            OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete all?"
            OptionYesNoForm.ShowDialog()
            If OptionYesNoForm.YNoption = True Then
                Call insert("delete from eligibility_info where emp_no = " & emp_no.Text)
                Call loadeligibility(emp_no.Text)
            End If
        Else
            MsgBox("Unable to delete all")
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        If SavingStatus = "Save" Then
            Try
                Try
                    OptionYesNoForm.btnOk.Enabled = True
                    OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
                    OptionYesNoForm.ShowDialog()
                    If OptionYesNoForm.YNoption = True Then
                        lstvEligibilty.FocusedItem.Remove()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf SavingStatus = "Update" Then
            OptionYesNoForm.btnOk.Enabled = True
            OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
            OptionYesNoForm.ShowDialog()
            If OptionYesNoForm.YNoption = True Then
                Call insert("delete from eligibility_info where emp_no = " & emp_no.Text & " and elig_id = " & lstvEligibilty.FocusedItem.SubItems(0).Text)
                Call loadeligibility(emp_no.Text)
            End If
        Else
            MsgBox("Unable to delete all")
        End If
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        Try
            Call assign_workexp()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        If SavingStatus = "Save" Then
            Try
                OptionYesNoForm.btnOk.Enabled = True
                OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete all?"
                OptionYesNoForm.ShowDialog()
                If OptionYesNoForm.YNoption = True Then
                    lstvWork.Items.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf SavingStatus = "Update" Then
            OptionYesNoForm.btnOk.Enabled = True
            OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete all?"
            OptionYesNoForm.ShowDialog()
            If OptionYesNoForm.YNoption = True Then
                Call insert("delete from service_record where emp_no = " & emp_no.Text)
                Call loadservicerecord(emp_no.Text)
            End If
        Else
            MsgBox("Unable to delete all")
        End If
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        If SavingStatus = "Save" Then
            Try
                OptionYesNoForm.btnOk.Enabled = True
                OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete all?"
                OptionYesNoForm.ShowDialog()
                If OptionYesNoForm.YNoption = True Then
                    lstvWorksTraining.Items.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf SavingStatus = "Update" Then
            OptionYesNoForm.btnOk.Enabled = True
            OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete all?"
            OptionYesNoForm.ShowDialog()
            If OptionYesNoForm.YNoption = True Then
                Call insert("delete from works_trainings where emp_no = " & emp_no.Text)
                Call loadworkstraining(emp_no.Text)
            End If
        Else
            MsgBox("Unable to delete all")
        End If
    End Sub

    Private Sub DeleteAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteAllToolStripMenuItem.Click
        If SavingStatus = "Save" Then
            Try
                OptionYesNoForm.btnOk.Enabled = True
                OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete all?"
                OptionYesNoForm.ShowDialog()
                If OptionYesNoForm.YNoption = True Then
                    lstvSeminar.Items.Clear()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf SavingStatus = "Update" Then
            OptionYesNoForm.btnOk.Enabled = True
            OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete all?"
            OptionYesNoForm.ShowDialog()
            If OptionYesNoForm.YNoption = True Then
                Call insert("delete from seminars where emp_no = " & emp_no.Text)
                Call loadseminars(emp_no.Text)
            End If
        Else
            MsgBox("Unable to delete all")
        End If
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        If SavingStatus = "Save" Then
            Try
                Try
                    OptionYesNoForm.btnOk.Enabled = True
                    OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
                    OptionYesNoForm.ShowDialog()
                    If OptionYesNoForm.YNoption = True Then
                        lstvWork.FocusedItem.Remove()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf SavingStatus = "Update" Then
            OptionYesNoForm.btnOk.Enabled = True
            OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
            OptionYesNoForm.ShowDialog()
            If OptionYesNoForm.YNoption = True Then
                Call insert("delete from service_record where emp_no = " & emp_no.Text & " and servicerec_id = " & lstvWork.FocusedItem.SubItems(0).Text)
                Call loadservicerecord(emp_no.Text)
            End If
        Else
            MsgBox("Unable to delete all")
        End If
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        If SavingStatus = "Save" Then
            Try
                Try
                    OptionYesNoForm.btnOk.Enabled = True
                    OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
                    OptionYesNoForm.ShowDialog()
                    If OptionYesNoForm.YNoption = True Then
                        lstvWorksTraining.FocusedItem.Remove()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf SavingStatus = "Update" Then
            OptionYesNoForm.btnOk.Enabled = True
            OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
            OptionYesNoForm.ShowDialog()
            If OptionYesNoForm.YNoption = True Then
                Call insert("delete from works_trainings where emp_no = " & emp_no.Text & " and work_id = " & lstvWorksTraining.FocusedItem.SubItems(0).Text)
                Call loadworkstraining(emp_no.Text)
            End If
        Else
            MsgBox("Unable to delete all")
        End If
    End Sub

    Private Sub ctxSeminar_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ctxSeminar.Opening

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If SavingStatus = "Save" Then
            Try
                Try
                    OptionYesNoForm.btnOk.Enabled = True
                    OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
                    OptionYesNoForm.ShowDialog()
                    If OptionYesNoForm.YNoption = True Then
                        lstvSeminar.FocusedItem.Remove()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf SavingStatus = "Update" Then
            OptionYesNoForm.btnOk.Enabled = True
            OptionYesNoForm.YesNomsg.Text = "Are you sure you want to delete this item?"
            OptionYesNoForm.ShowDialog()
            If OptionYesNoForm.YNoption = True Then
                Call insert("delete from seminars where emp_no = " & emp_no.Text & " and sem_id = " & lstvSeminar.FocusedItem.SubItems(0).Text)
                Call loadseminars(emp_no.Text)
            End If
        Else
            MsgBox("Unable to delete all")
        End If
    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        Try

            Call assign_voluntary()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub CreateUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateUserToolStripMenuItem.Click
        CreateUserForm.Show()
        Me.Hide()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        frm_Login.Show()
        Me.Close()
    End Sub

    Private Sub appointment_status_KeyDown(sender As Object, e As KeyEventArgs) Handles appointment_status.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub appointment_status_KeyPress(sender As Object, e As KeyPressEventArgs) Handles appointment_status.KeyPress
        e.Handled = True
    End Sub

   
    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub gender_KeyDown(sender As Object, e As KeyEventArgs) Handles gender.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub gender_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gender.KeyPress
        e.Handled = True
    End Sub

    Private Sub gender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gender.SelectedIndexChanged

    End Sub

    Private Sub civil_status_KeyDown(sender As Object, e As KeyEventArgs) Handles civil_status.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub civil_status_KeyPress(sender As Object, e As KeyPressEventArgs) Handles civil_status.KeyPress
        e.Handled = True
    End Sub

    Private Sub civil_status_SelectedIndexChanged(sender As Object, e As EventArgs) Handles civil_status.SelectedIndexChanged

    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
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
                .Columns.Add("EHieght", GetType(System.String))
                .Columns.Add("EWeight", GetType(System.String))
                .Columns.Add("RAddress", GetType(System.String))
                .Columns.Add("RZipcode", GetType(System.String))
                .Columns.Add("RTelNo", GetType(System.String))
                .Columns.Add("PAddress", GetType(System.String))
                .Columns.Add("PZipcode", GetType(System.String))
                .Columns.Add("PTelNo", GetType(System.String))
                .Columns.Add("EMailAddress", GetType(System.String))
                .Columns.Add("CellNo", GetType(System.String))
                .Columns.Add("FullName", GetType(System.String))
                .Columns.Add("Relationship", GetType(System.String))
                .Columns.Add("Contact", GetType(System.String))
                .Columns.Add("DFrom", GetType(System.String))
                .Columns.Add("DTo", GetType(System.String))
                .Columns.Add("Position", GetType(System.String))
                .Columns.Add("Agency", GetType(System.String))
            End With
            If lstvWork.Items.Count = 0 Then
                dt1.Rows.Add(emp_no.Text, _
                          item_no.Text, _
                          fname.Text + " " + mname.Text + " " + lname.Text + " " & name_ext.Text, _
                          birth_date.Text, _
                          birth_place.Text, _
                          gender.Text, _
                          civil_status.Text, _
                          tribe.Text, _
                          religion.Text, _
                          citizenship.Text, _
                         Em_height.Text, _
                         weight.Text, _
                         res_add.Text, _
                         res_zipcode.Text, _
                         res_telno.Text, _
                         per_add.Text, _
                         per_zipcode.Text, _
                         per_telno.Text, _
                         email_add.Text, _
                         cel_no.Text, _
                         person_notify_fulname.Text, _
                         person_notify_relation.Text, _
                         person_notify_contact.Text, _
                        "", _
                         "", _
                        "", _
                        "")
            Else
                For i As Integer = 0 To lstvWork.Items.Count - 1
                    dt1.Rows.Add(emp_no.Text, _
                                 item_no.Text, _
                                 fname.Text + " " + mname.Text + " " + lname.Text + " " & name_ext.Text, _
                                 birth_date.Text, _
                                 birth_place.Text, _
                                 gender.Text, _
                                 civil_status.Text, _
                                 tribe.Text, _
                                 religion.Text, _
                                 citizenship.Text, _
                                Em_height.Text, _
                                weight.Text, _
                                res_add.Text, _
                                res_zipcode.Text, _
                                res_telno.Text, _
                                per_add.Text, _
                                per_zipcode.Text, _
                                per_telno.Text, _
                                email_add.Text, _
                                cel_no.Text, _
                                person_notify_fulname.Text, _
                                person_notify_relation.Text, _
                                person_notify_contact.Text, _
                                lstvWork.Items(i).SubItems(1).Text, _
                                lstvWork.Items(i).SubItems(2).Text, _
                                lstvWork.Items(i).SubItems(3).Text, _
                                lstvWork.Items(i).SubItems(4).Text)
                Next
            End If
            PrintForm.PrintInfoBindingSource.DataSource = dt1
            PrintForm.LoadReport(4)
            Call InsertLog("Printed the data of " & fname.Text & " " & mname.Text & " " & lname.Text)
            PrintForm.ShowDialog()
            PrintForm.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub HistoryLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoryLogToolStripMenuItem.Click
        If HistoryLogForm.Visible = False Then
            HistoryLogForm.Visible = True
        Else
            If HistoryLogForm.WindowState = FormWindowState.Normal Or HistoryLogForm.WindowState = FormWindowState.Maximized Then
                HistoryLogForm.BringToFront()
                HistoryLogForm.Visible = True
            Else
                HistoryLogForm.WindowState = FormWindowState.Normal
                HistoryLogForm.BringToFront()
                HistoryLogForm.Visible = True
            End If

        End If
    End Sub
End Class