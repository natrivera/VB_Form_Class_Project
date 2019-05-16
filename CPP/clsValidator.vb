Imports System.Net.Mail

Public Class clsValidator


    Public Function isValidPhone(phone As String) As Boolean

        Dim check As Boolean = False

        If (phone Like "##########") Then
            check = True
        End If

        Return check
    End Function

    Public Function isValidNumber(num As String) As Boolean
        Dim check As Boolean
        Try
            Dim temp As Int16 = CInt(num)
            If (temp <= 0) Then
                check = False
            Else
                check = True
            End If
        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function

    Public Function isValidString(str As String) As Boolean
        Dim check As Boolean

        If (str <> "") Then
            check = True
        Else
            check = False
        End If

        Return check
    End Function

    Public Function isValidEmail(str As String) As Boolean
        Dim check As Boolean = False
        Dim address As MailAddress
        Try
            address = New MailAddress(str)
            check = True
        Catch ex As Exception

        End Try

        Return check
    End Function

    Public Function isValidYear(num As String) As Boolean
        Dim check As Boolean
        Try
            Dim temp As Int16 = CInt(num)
            If (temp < 0) Then
                check = False
            Else
                check = True
            End If
        Catch ex As Exception
            check = False
        End Try

        Return check
    End Function

End Class
