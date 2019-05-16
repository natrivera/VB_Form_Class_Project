Imports System.Data.SqlClient
Imports CPP

Public Class CPP_DB
    Private Shared cn As SqlConnection
    Private Shared strError As String

    ''' 
    ''' STUDENTS SECTION
    ''' 

    Public Shared Function loadStudents() As List(Of clsStudent)
        'List of students that will be returned
        Dim studentList As New List(Of clsStudent)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_STUDENTS"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic student information
                Dim aStudent As New clsStudent
                aStudent.broncoID = rdr("BRONCO_ID")
                aStudent.firstName = rdr("FIRST_NAME")
                aStudent.lastName = rdr("LAST_NAME")
                aStudent.email = rdr("EMAIL")
                aStudent.phone = rdr("PHONE")

                studentList.Add(aStudent)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return studentList
    End Function

    Public Shared Function deleteStudent(strStudentID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_STUDENTS where BRONCO_ID = '" & strStudentID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Student id " & strStudentID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Sub updateStudent(aStudent As clsStudent)
        strError = ""

        'To update we remove old student and add new student
        'there are other ways to do this as well using the update statement
        deleteStudent(aStudent.broncoID)
        insertStudent(aStudent)

        If strError <> "" Then
            strError = "Could not Update student " & aStudent.broncoID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Function insertStudent(aStudent As clsStudent) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strStudentSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strStudentSQL = "INSERT INTO CPP_STUDENTS (BRONCO_ID, FIRST_NAME, LAST_NAME, PHONE, EMAIL) " &
                            "values('" & aStudent.broncoID & "','" & aStudent.firstName & "','" & aStudent.lastName & "','" & aStudent.phone & "', '" &
                            aStudent.email & "')"

            cmd.Connection = cn
            cmd.CommandText = strStudentSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    '''END OF STUDENT SECTION
    '''
    '''INTRUCTOR SECTION
    '''
    '''


    Public Shared Function loadIntructor() As List(Of clsInstructor)
        'List of students that will be returned
        Dim instructorList As New List(Of clsInstructor)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_INSTRUCTORS"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic student information
                Dim anInstructor As New clsInstructor
                anInstructor.ID = rdr("PROF_ID")
                anInstructor.firstName = rdr("FIRST_NAME")
                anInstructor.lastName = rdr("LAST_NAME")
                anInstructor.phoneNumber = rdr("PHONE")
                anInstructor.Department = rdr("DEPARTMENT")

                instructorList.Add(anInstructor)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return instructorList
    End Function

    Public Shared Function deleteIntructor(strInstructorID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_INSTRUCTORS where PROF_ID = '" & strInstructorID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Istructor id " & strInstructorID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Sub updateInstructor(anInstructor As clsInstructor)
        strError = ""

        'To update we remove old student and add new student
        'there are other ways to do this as well using the update statement
        deleteIntructor(anInstructor.ID)
        insertInstructor(anInstructor)

        If strError <> "" Then
            strError = "Could not Update student " & anInstructor.ID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Function insertInstructor(anInstructor As clsInstructor) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strInstructorSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strInstructorSQL = "INSERT INTO CPP_INSTRUCTORS (PROF_ID, FIRST_NAME, LAST_NAME, PHONE, DEPARTMENT) " &
                            "values('" & anInstructor.ID & "','" & anInstructor.firstName & "','" & anInstructor.lastName & "','" & anInstructor.phoneNumber & "', '" &
                            anInstructor.Department & "')"

            cmd.Connection = cn
            cmd.CommandText = strInstructorSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function


    '''END OF INSTRUCTOR SECTION
    '''
    '''
    '''
    '''COURSES SECTION

    Public Shared Function loadCourses() As List(Of clsCourse)

        'List of students that will be returned
        Dim courseList As New List(Of clsCourse)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_COURSES"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic student information
                Dim aCourse As New clsCourse
                aCourse.ID = rdr("COURSE_ID")
                aCourse.Description = rdr("DESCRIPTION")
                aCourse.Units = rdr("UNITS")


                courseList.Add(aCourse)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return courseList


    End Function


    Public Shared Sub updateCourse(aCourse As clsCourse)
        strError = ""

        'To update we remove old student and add new student
        'there are other ways to do this as well using the update statement
        deleteCourse(aCourse.ID)
        insertCourse(aCourse)

        If strError <> "" Then
            strError = "Could not Update course " & aCourse.ID & vbCrLf & vbCrLf & strError
        End If

    End Sub

    Public Shared Function deleteCourse(strCourseID As String) As Integer

        Dim result As Integer
        'Result that will be returned


        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_COURSES where COURSE_ID = '" & strCourseID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            result = cmd.ExecuteNonQuery()

            If (result < 1) Then
                dbAddError("DELETE Failed, Course id " & strCourseID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return result

    End Function


    Public Shared Function insertCourse(aCourse As clsCourse) As Integer
        Dim result As Integer

        'DB variables
        Dim cmd As New SqlCommand
        Dim strCourseSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strCourseSQL = "INSERT INTO CPP_COURSES (COURSE_ID, DESCRIPTION, UNITS) " &
                            "values('" & aCourse.ID & "','" & aCourse.Description & "','" & aCourse.Units & "')"

            cmd.Connection = cn
            cmd.CommandText = strCourseSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return result


    End Function


    ''' END OF COURSES SECTION
    ''' 
    ''' 
    ''' CATALOG SECTION

    Public Shared Function loadCatalog() As List(Of clsCatalog)

        'List of students that will be returned
        Dim catalogList As New List(Of clsCatalog)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_CATALOG"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic student information
                Dim aCatalog As New clsCatalog
                aCatalog.ID = rdr("CATALOG_ID")
                aCatalog.Year = rdr("YEAR")
                aCatalog.Quarter = rdr("QUARTER")
                aCatalog.CourseID = rdr("COURSE_ID")
                aCatalog.ProfessorID = rdr("PROF_ID")


                catalogList.Add(aCatalog)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return catalogList


    End Function



    Public Shared Function insertCatalog(aCatalog As clsCatalog) As Integer
        Dim result As Integer

        'DB variables
        Dim cmd As New SqlCommand
        Dim strCatalogSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strCatalogSQL = "INSERT INTO CPP_CATALOG (CATALOG_ID, YEAR, QUARTER, COURSE_ID, PROF_ID) " &
                            "values('" & aCatalog.ID & "','" & aCatalog.Year & "','" & aCatalog.Quarter & "','" & aCatalog.CourseID & "', '" &
                            aCatalog.ProfessorID & "')"

            cmd.Connection = cn
            cmd.CommandText = strCatalogSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return result
    End Function


    Public Shared Function deleteCatalog(strCatalogID As String) As Integer

        Dim result As Integer
        'Result that will be returned


        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_CATALOG where CATALOG_ID = '" & strCatalogID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            result = cmd.ExecuteNonQuery()

            If (result < 1) Then
                dbAddError("DELETE Failed, Catalog id " & strCatalogID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return result
    End Function


    Public Shared Sub updateCatalog(aCatalog As clsCatalog)

        strError = ""

        'To update we remove old student and add new student
        'there are other ways to do this as well using the update statement
        deleteCatalog(aCatalog.ID)
        insertCatalog(aCatalog)

        If strError <> "" Then
            strError = "Could not Update catalog " & aCatalog.ID & vbCrLf & vbCrLf & strError
        End If

    End Sub


    Public Shared Function findCatalog(strCatalogID As String) As clsCatalog
        'student that will be returned
        Dim aCatalog As clsCatalog = New clsCatalog

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From CPP_CATALOG Where ID = '" & strCatalogID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aCatalog.ID = rdr("CATALOG_ID")
                aCatalog.Year = rdr("YEAR")
                aCatalog.Quarter = rdr("QUARTER")
                aCatalog.CourseID = rdr("COURSE_ID")
                aCatalog.ProfessorID = rdr("PROF_ID")
            Else
                dbAddError("Catalog not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aCatalog
    End Function

    ''' END OF CATALOG SECTION
    ''' 
    ''' 
    ''' ENROLLMENT SECTION

    Public Shared Function loadEnrollments() As List(Of clsEnrollment)

        'List of enrollments that will be returned
        Dim enrollmentList As New List(Of clsEnrollment)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From CPP_ENROLLMENT"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic student information
                Dim anEnrollment As New clsEnrollment
                anEnrollment.BroncoID = rdr("BRONCO_ID")
                anEnrollment.CatalogID = rdr("CATALOG_ID")

                enrollmentList.Add(anEnrollment)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return enrollmentList
    End Function

    Public Shared Function insertEnrollment(anEnrollment As clsEnrollment) As Integer

        Dim result As Integer

        'DB variables
        Dim cmd As New SqlCommand
        Dim strEnrollmentSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strEnrollmentSQL = "INSERT INTO CPP_ENROLLMENT (BRONCO_ID, CATALOG_ID) " &
                            "values('" & anEnrollment.BroncoID & "','" & anEnrollment.CatalogID & "')"

            cmd.Connection = cn
            cmd.CommandText = strEnrollmentSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return result


    End Function

    Public Shared Sub updateEnrollment(anEnrollment As clsEnrollment)

        strError = ""

        'To update we remove old student and add new student
        'there are other ways to do this as well using the update statement
        deleteEnrollment(anEnrollment)
        insertEnrollment(anEnrollment)

        If strError <> "" Then
            strError = "Could not Update catalog " & anEnrollment.BroncoID & vbCrLf & vbCrLf & strError
        End If

    End Sub

    Public Shared Function deleteEnrollment(anEnrollment As clsEnrollment) As Integer

        Dim result As Integer
        'Result that will be returned


        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from CPP_ENROLLMENT where BRONCO_ID = '" & anEnrollment.aBroncoID & "' and CATALOG_ID = '" & anEnrollment.CatalogID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            result = cmd.ExecuteNonQuery()

            If (result < 1) Then
                dbAddError("DELETE Failed, Catalog id " & anEnrollment.BroncoID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return result

    End Function

    ''' END OF ENROLLMENT SECTION
    ''' 
    ''' 

    Public Shared Function findStudent(strStudentID As String) As clsStudent
        'student that will be returned
        Dim aStudent As clsStudent = New clsStudent

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From CPP_STUDENT Where ID = '" & strStudentID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aStudent.broncoID = rdr("BRONCO_ID")
                aStudent.firstName = rdr("FIRST_NAME")
                aStudent.lastName = rdr("LAST_NAME")
                aStudent.email = rdr("EMAIL")
                aStudent.phone = rdr("PHONE")
            Else
                dbAddError("Student not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aStudent
    End Function

    Public Shared Sub dbOpen()
        'Only assign one reference to the connection
        If IsNothing(cn) Then
            cn = New SqlConnection
            'EXAMPLE OF CONNECTION STRING TO A SQL SERVER INSTANCE
            'cn.ConnectionString = "Data Source=SKYNET\SQLEXPRESS;Initial Catalog=CPP;Integrated Security=True"

            'EXAMPLE OF CONNECTION TO A LOCAL DATABASE FILE. YOU MIGHT NEED TO ADJUST THE CONNECTION STRING
            'BASED ON YOUR PROJECT DATABASE VERSION. 
            cn.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CPP.mdf;Integrated Security=True"

        End If
    End Sub

    Public Shared Sub dbConnect()
        'Only open if connection is closed
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
    End Sub

    Public Shared Sub dbClose()
        'Only close if open
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Shared Sub dbAddError(ByVal s As String)
        'build error
        If strError = "" Then
            strError = s
        Else
            strError += vbCrLf & s
        End If
    End Sub

    Public Shared Function dbGetError() As String
        'return error
        Return strError
    End Function
End Class
