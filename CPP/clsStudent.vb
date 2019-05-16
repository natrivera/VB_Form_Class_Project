Public Class clsStudent
    Private strBroncoId As String
    Private strFirstName As String
    Private strLastName As String
    Private strPhone As String
    Private strEmail As String
    Private validator As clsValidator = New clsValidator()
    Private errString As String = ""


    Public Function addError(err As String)
        'private function to format our error message by
        'adding line breaks when necessary
        If errString = "" Then
            errString = err
        Else
            errString += vbCrLf & err
        End If
    End Function

    Public Function getError() As String
        Return errString
    End Function


    Public Property broncoID As String
        Get
            Return strBroncoId
        End Get
        Set(value As String)
            Dim check As Boolean = validator.isValidString(value)
            If (check) Then
                strBroncoId = value
            Else
                addError("Please enter a valid Bronco ID")
            End If

        End Set
    End Property

    Public Property firstName As String
        Get
            Return strFirstName
        End Get
        Set(value As String)
            If (validator.isValidString(value)) Then
                strFirstName = value
            Else
                addError("Please enter a valid First name")
            End If

        End Set
    End Property

    Public Property lastName As String
        Get
            Return strLastName
        End Get
        Set(value As String)
            If (validator.isValidString(value)) Then
                strLastName = value
            Else
                addError("Please enter a valid Last Name")
            End If

        End Set
    End Property

    Public Property phone As String
        Get
            Return strPhone
        End Get
        Set(value As String)
            If (validator.isValidPhone(value)) Then
                strPhone = value
            Else
                addError("Please enter a valid phone number")
            End If

        End Set
    End Property

    Public Property email As String
        Get
            Return strEmail
        End Get
        Set(value As String)
            If (validator.isValidEmail(value)) Then
                strEmail = value
            Else
                addError("Please enter a valid email")
            End If

        End Set
    End Property


End Class
