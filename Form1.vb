Imports Microsoft.Win32.SafeHandles
Imports MySql.Data.MySqlClient

Public Class Form1

    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Dim pass As String
    Dim Uname As String

    Dim connectionString As String = "server=localhost;userid=root;password='Qua156';databse=book_shop;port3306"

    Public Function IsValidLogin(username As String, password As String) As Boolean
        Dim connection As New MySqlConnection(connectionString)
        connection.Open()

        Dim sql As String = "SELECT * FROM members WHERE name = @name AND password = @password"
        Dim command As New MySqlCommand(sql, connection)

        command.Parameters.AddWithValue("@name", username)
        command.Parameters.AddWithValue("@password", password)

        Dim reader As MySqlDataReader = command.ExecuteReader()
        Dim hasRows As Boolean = reader.HasRows

        reader.Close()
        command.Dispose()
        connection.Close()

        Return hasRows
    End Function
    Public Sub LogIn()
        Dim query As String = "server=localhost;userid=root;password='Qua156';databse=book_shop;port3306"
        Try
            conn = New MySqlConnection(query)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                MsgBox("connection success")
            End If

        Catch ex As Exception
            MsgBox("connection failed")
        End Try



    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LogIn()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Members.Show()
    End Sub
End Class
