Public Class clsEnrollment

    Public BroncoID As String
    Public CatalogID As String
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
    Public Property aBroncoID() As String
        Get
            Return BroncoID
        End Get
        Set(ByVal value As String)
            BroncoID = value
        End Set
    End Property


    Public Property aCatalogID() As String
        Get
            Return CatalogID
        End Get
        Set(ByVal value As String)
            CatalogID = value
        End Set
    End Property

End Class
