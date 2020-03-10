Module SqlQueries
    Public ConnectionString As String
    Public sqlconn As New Odbc.OdbcConnection
    Public sqlquery As String
    Public sqlcmd As Odbc.OdbcCommand
    Public sqldr As Odbc.OdbcDataReader
    Public sqlda As Odbc.OdbcDataAdapter
    Public dt As New DataTable
    Public LogUsername As String = "postgres"
    Public LogPassword As String = "1"
    Public DBName As String = My.Settings.DBname
    Public DBServer As String = My.Settings.DBserver
    Public DBPort As String = My.Settings.DBport

    Public DefaultPassword As String = My.Settings.DefaultPassword
    Public DefaultUsername As String = My.Settings.DefaultUsername
    Public DefaultSqlconn As New Odbc.OdbcConnection
    Public Defaultsqlquery As String
    Public Defaultsqlcmd As Odbc.OdbcCommand
    Public Defaultsqldr As Odbc.OdbcDataReader
    Public NameofUser As String = ""
    Public Sub DefaultDBConnection()
        DefaultSqlconn.ConnectionString = "Driver={PostgreSQL ANSI};database=" & DBName & ";" & _
                          "server=" & DBServer & ";port=" & DBPort & ";uid=" & DefaultUsername & ";" & _
                          "sslmode=disable;readonly=0;User ID= " & DefaultUsername & ";" & _
                          "password=" & DefaultPassword & ";"
        If DefaultSqlconn.State = ConnectionState.Closed Then
            DefaultSqlconn.Open()
            'MsgBox("Connected To PostGres.")
        ElseIf DefaultSqlconn.State = ConnectionState.Open Then
            'MsgBox("Already connected to Database.")
        End If
    End Sub

    Public Sub defaultinsert(ByVal qry As String)
        Defaultsqlquery = qry
        Defaultsqlcmd = New Odbc.OdbcCommand(Defaultsqlquery, DefaultSqlconn)
        Defaultsqlcmd.ExecuteNonQuery()

        Defaultsqlquery = vbEmpty
        Defaultsqlcmd.Dispose()
    End Sub

    Public Sub InsertLog(task As String)
        Call defaultinsert("INSERT INTO public.historylog(fullname, task, logtime) " &
                       " VALUES ('" & NameofUser & "','" & task & "',NOW());")

    End Sub

    Public Sub defaultselectdata(ByVal qry As String)
        Defaultsqlquery = qry
        Defaultsqlcmd = New Odbc.OdbcCommand(Defaultsqlquery, DefaultSqlconn)
        Defaultsqldr = Defaultsqlcmd.ExecuteReader()
    End Sub

    Public Sub Defaultsqlclose()
        Defaultsqlquery = vbEmpty
        Defaultsqlcmd.Dispose()
        Defaultsqldr.Close()
    End Sub


    Public Sub DBConnection()
        sqlconn.ConnectionString = "Driver={PostgreSQL ANSI};database=" & DBName & ";" & _
                          "server=" & DBServer & ";port=" & DBPort & ";uid=" & LogUsername & ";" & _
                          "sslmode=disable;readonly=0;User ID= " & LogUsername & ";" & _
                          "password=" & LogPassword & ";"
        If sqlconn.State = ConnectionState.Closed Then
            sqlconn.Open()
            'MsgBox("Connected To PostGres.")
        ElseIf sqlconn.State = ConnectionState.Open Then
            'MsgBox("Already connected to Database.")
        End If
    End Sub



    Public Sub sqlclose()
        sqlquery = vbEmpty
        sqlcmd.Dispose()
        sqldr.Close()
    End Sub

    Public Sub sqlcloseForWithImage()
        sqlquery = vbEmpty
        sqlcmd.Dispose()
    End Sub

    Public Sub insert(ByVal qry As String)
        sqlquery = qry
        sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        sqlcmd.ExecuteNonQuery()

        sqlquery = vbEmpty
        sqlcmd.Dispose()
    End Sub



    Public Sub insertWithParameter(ByVal qry As String)
        sqlquery = qry
        sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
    End Sub

    Public Sub updateWithParameter(ByVal qry As String)
        sqlquery = qry
        sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
    End Sub

    Public Sub updatetb(ByVal qry As String)
        sqlquery = qry
        sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        sqldr = sqlcmd.ExecuteReader
        Call sqlclose()
    End Sub

    Public Sub deleteit(ByVal qry As String)
        sqlquery = qry
        sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        sqlcmd.ExecuteNonQuery()

        sqlquery = vbEmpty
        sqlcmd.Dispose()
    End Sub

    Public Sub selectdata(ByVal qry As String)
        sqlquery = qry
        sqlcmd = New Odbc.OdbcCommand(sqlquery, sqlconn)
        sqldr = sqlcmd.ExecuteReader()
    End Sub

    'Encrypt and decrypt function
    Public Function EncryptData(ByVal datainput As String)
        Dim dataoutput As String = ""
        Dim wrapper As New ljcrypt("lj")
        dataoutput = wrapper.EncryptData(datainput)
        Return dataoutput
    End Function

    Public Function DecryptData(ByVal datainput As String)
        Dim dataoutput As String = ""
        Dim wrapper As New ljcrypt("lj")
        Try
            dataoutput = wrapper.DecryptData(datainput)
        Catch ex As System.Security.Cryptography.CryptographicException
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try
        Return dataoutput
    End Function
    Public Sub IntDouble(a As Boolean, e As KeyPressEventArgs)
        If a = False Then
            If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        ElseIf a = True Then
            If Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Public Sub IntDouble2(a As Boolean, b As String, e As KeyPressEventArgs)
        If a = False Then
            If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        ElseIf a = True Then
            Dim c As Integer = 0
            Try
                Dim str As String() = b.Split(".")
                c = str.Length - 1
            Catch ex As Exception
                c = 0
            End Try

            If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar = "." Then
                If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                ElseIf e.KeyChar = "." And c = 0 Then
                    e.Handled = False
                ElseIf e.KeyChar = "." And c > 0 Then
                    e.Handled = True
                End If
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Public Function Replacer(a As String)
        Dim nv As String = ""
        nv = a.Replace("\", "\\")
        nv = nv.Replace("'", "\'")
        nv = "'" & nv & "'"
        Return nv.Trim
    End Function


End Module
