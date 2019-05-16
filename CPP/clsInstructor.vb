Public Class clsInstructor

    Public ID As String
    Public firstName As String
    Public lastName As String
    Public phoneNumber As String
    Public Department As String
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
    Public Property anID() As String
        Get
            Return ID
        End Get
        Set(ByVal value As String)
            If (validator.isValidString(value)) Then
                ID = value
            Else
                addError("Please enter a valid ID")
            End If

        End Set
    End Property


    Public Property aFirstName() As String
        Get
            Return firstName
        End Get
        Set(ByVal value As String)
            If (validator.isValidString(value)) Then
                firstName = value
            Else
                addError("Please enter a valid First Name")
            End If
        End Set
    End Property


    Public Property aLastName() As String
        Get
            Return lastName
        End Get
        Set(ByVal value As String)
            If (validator.isValidString(value)) Then
                lastName = value
            Else
                addError("Please enter a valid Last Name")
            End If

        End Set
    End Property


    Public Property aPhoneNumber() As String
        Get
            Return phoneNumber
        End Get
        Set(ByVal value As String)
            If (validator.isValidPhone(value)) Then
                phoneNumber = value
            Else
                addError("Please enter a valid phone")
            End If

        End Set
    End Property


    Public Property aDepartment() As String
        Get
            Return Department
        End Get
        Set(ByVal value As String)
            If (validator.isValidString(value)) Then
                Department = value
            Else
                addError("Please enter a valid Department")
            End If

        End Set
    End Property

End Class
