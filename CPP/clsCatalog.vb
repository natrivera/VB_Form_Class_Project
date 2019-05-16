Public Class clsCatalog

    Public ID As String
    Public Year As String
    Public Quarter As String
    Public CourseID As String
    Public ProfessorID As String
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
            If (validator.isValidNumber(value)) Then
                ID = value
            Else
                addError("Please enter a valid ID")
            End If

        End Set
    End Property


    Public Property aYear() As String
        Get
            Return Year
        End Get
        Set(ByVal value As String)
            If (validator.isValidYear(value)) Then
                Year = value
            Else
                addError("Please enter a valid year")
            End If

        End Set
    End Property


    Public Property aQuearter() As String
        Get
            Return Quarter
        End Get
        Set(ByVal value As String)
            Quarter = value
        End Set
    End Property



    Public Property aCourseID() As String
        Get
            Return CourseID
        End Get
        Set(ByVal value As String)
            CourseID = value
        End Set
    End Property


    Public Property aProfeessorID() As String
        Get
            Return ProfessorID
        End Get
        Set(ByVal value As String)
            ProfessorID = value
        End Set
    End Property

End Class
