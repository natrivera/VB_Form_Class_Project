Public Class clsCourse

    Public ID As String
    Public Description As String
    Public Units As String
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


    Public Property aDescription() As String
        Get
            Return Description
        End Get
        Set(ByVal value As String)
            If (validator.isValidString(value)) Then
                Description = value
            Else
                addError("Please enter a valid description")
            End If

        End Set
    End Property


    Public Property aUnits() As String
        Get
            Return Units
        End Get
        Set(ByVal value As String)
            If (validator.isValidNumber(value)) Then
                Units = value
            Else
                addError("Please enter a valid number for units")
            End If

        End Set
    End Property

End Class
