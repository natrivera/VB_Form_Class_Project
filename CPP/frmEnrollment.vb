Public Class frmEnrollment

    Dim enrollmentList As New List(Of clsEnrollment)

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF EnrollmentS

        If strMode = "L" Then
            'MODE IS LIST

            Me.gbEnrollmentDetail.Hide()
            Me.gbEnrollmentList.Left = 0
            Me.gbEnrollmentList.Top = 0
            Me.Width = gbEnrollmentList.Width + 50
            Me.Height = gbEnrollmentList.Height + 50

            Me.gbEnrollmentList.Visible = True
        Else
            'MODE IS DETAIL

            Me.gbEnrollmentList.Hide()
            Me.gbEnrollmentDetail.Left = 0
            Me.gbEnrollmentDetail.Top = 0
            Me.Width = gbEnrollmentDetail.Width + 50
            Me.Height = gbEnrollmentDetail.Height + 50

            Me.gbEnrollmentDetail.Visible = True
        End If
    End Sub

    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        Dim StudentBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE STUDENT LIST
        StudentBindingSource.DataSource = enrollmentList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_ENROLLMENTDataGridView.DataSource = StudentBindingSource
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'SWITCH TO DETAIL DATA ENTRY
        Me.setMode("D")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'CREATE ENROLLMENT OBJECT
        Dim anEnrollment As New clsEnrollment

        'POPULATE STUDENT OBJECT
        Dim broncoIDstr As String = Me.BRONCO_IDComboBox.Text
        Dim location As Integer = broncoIDstr.IndexOf(" ")
        broncoIDstr = broncoIDstr.Substring(0, location)
        anEnrollment.BroncoID = broncoIDstr

        Dim catalogIDstr As String = Me.CATALOG_IDComboBox.Text
        location = catalogIDstr.IndexOf(" ")
        catalogIDstr = catalogIDstr.Substring(0, location)
        anEnrollment.CatalogID = catalogIDstr


        'CHECK IF WE ARE SAVING OR UPDATING
        If (btnSave.Text = "&Save") Then

            'SAVE STUDENT
            CPP_DB.dbOpen()
            CPP_DB.insertEnrollment(anEnrollment)
            CPP_DB.dbClose()

            'CHECK FOR ERRORS
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                enrollmentList.Add(anEnrollment)                       'NO ERRORS ADD STUDENT TO LIST
                refreshDataGrid()                               'REFRESH GRID
                MessageBox.Show("Enrollment Saved!")               'NOTIFY
                Me.setMode("L")                                 'SWITCH TO LIST MODE
            End If
        Else

            'UPDATE STUDENT
            CPP_DB.dbOpen()
            CPP_DB.updateEnrollment(anEnrollment)
            CPP_DB.dbClose()

            'CHECK FOR ERRORS
            If CPP_DB.dbGetError <> "" Then
                MessageBox.Show(CPP_DB.dbGetError)
            Else
                'REMOVE OLD STUDENT FROM LIST
                For Each enrollment In enrollmentList
                    If enrollment.BroncoID = anEnrollment.BroncoID Then
                        enrollmentList.Remove(enrollment)
                        Exit For
                    End If
                Next
                enrollmentList.Add(anEnrollment)                       'NO ERRORS ADD NEW STUDENT TO LIST
                refreshDataGrid()                               'REFRESH GRID
                MessageBox.Show("Enrollment Updated!")             'NOTIFY
                Me.setMode("L")                                 'SWITCH TO LIST MODE
                Me.btnSave.Text = "&Save"                       'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'CLEAR ALL CONTROLS
        For Each ctrl In gbEnrollmentDetail.Controls
            If TypeOf (ctrl) Is TextBox Then
                TryCast(ctrl, TextBox).Clear()
            End If
        Next

        'SET SAVE BUTTON TO DEFAULT 
        btnSave.Text = "&Save"

        'SWITCH TO LIST MODE
        setMode("L")
    End Sub

    Private Sub frmEnrollment_Load(sender As Object, e As EventArgs) Handles Me.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        enrollmentList = CPP_DB.loadEnrollments()
        CPP_DB.dbClose()

        CPP_DB.dbOpen()
        Dim broncoIdBox As ComboBox = BRONCO_IDComboBox
        Dim studentList As List(Of clsStudent) = CPP_DB.loadStudents
        For Each student In studentList
            broncoIdBox.Items.Add(student.broncoID & " - (" & student.firstName & ", " & student.lastName & ")")
        Next
        CPP_DB.dbClose()

        CPP_DB.dbOpen()
        Dim catalogIdBox As ComboBox = CATALOG_IDComboBox
        Dim catalofList As List(Of clsCatalog) = CPP_DB.loadCatalog
        For Each catalog In catalofList
            catalogIdBox.Items.Add(catalog.ID & " - (" & catalog.Year & ", " & catalog.Quarter & ", " & catalog.CourseID & ")")
        Next
        CPP_DB.dbClose()

        'CHECK ERRORS
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'GET CURRENT ENROLLMENT ROW FROM THE GRID
        Dim row As DataGridViewRow = Me.CPP_ENROLLMENTDataGridView.CurrentRow

        'CHECK IF ROW IS VALIID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing Selected!")
            Exit Sub
        End If

        'CONVERT THE ROW TO A STUDENT OBJECT
        Dim anEnrollment As clsEnrollment = TryCast(row.DataBoundItem, clsEnrollment)

        'GET DATA FROM THE ROW TO THE TEXTBOXES
        Me.BRONCO_IDComboBox.Text = anEnrollment.BroncoID
        Me.CATALOG_IDComboBox.Text = anEnrollment.CatalogID


        'SET THE FOCUS ON ID
        Me.BRONCO_IDComboBox.Focus()

        'SWITCH SAVE TO UPDATE
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_ENROLLMENTDataGridView.CurrentRow

        'CHECK IF ROW IS VALID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing selected!")
            Exit Sub
        End If

        'CONVERT ROW TO STUDENT
        Dim anEnrollment As clsEnrollment = TryCast(row.DataBoundItem, clsEnrollment)

        'DELETE STUDENT FROM DB
        CPP_DB.dbOpen()
        'CPP_DB.deleteStudent(aStudent.broncoID)
        CPP_DB.deleteEnrollment(anEnrollment)
        CPP_DB.dbClose()

        'CHECK FOR ERRORS
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Student Deleted!")
            'REMOVE STUDENT FROM LIST
            For Each enrollment In enrollmentList
                If enrollment.BroncoID = anEnrollment.BroncoID Then
                    enrollmentList.Remove(enrollment)
                    Exit For
                End If
            Next
            'UPDATE GRID
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim strBroncoId As String = InputBox("Enter Bronco ID")

        For Each row As DataGridViewRow In CPP_ENROLLMENTDataGridView.Rows
            If row.Cells(0).Value = strBroncoId Then
                row.Selected = True 'CPP_EnrollmentDataGridView.CurrentRow.
                MessageBox.Show("Found!")
                Exit Sub
            End If
        Next

        MessageBox.Show("Not found!")
    End Sub
End Class