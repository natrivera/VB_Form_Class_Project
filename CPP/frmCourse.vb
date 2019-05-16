'CONFIRMED WORKING

Public Class frmCourse

    'a list to hold all the course objects
    Dim courseList As New List(Of clsCourse)

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF CourseS

        If strMode = "L" Then
            'MODE IS LIST

            Me.gbCourseDetail.Hide()
            Me.gbCourseList.Left = 0
            Me.gbCourseList.Top = 0
            Me.Width = gbCourseList.Width + 50
            Me.Height = gbCourseList.Height + 50

            Me.gbCourseList.Visible = True
        Else
            'MODE IS DETAIL

            Me.gbCourseList.Hide()
            Me.gbCourseDetail.Left = 0
            Me.gbCourseDetail.Top = 0
            Me.Width = gbCourseDetail.Width + 50
            Me.Height = gbCourseDetail.Height + 50

            Me.gbCourseDetail.Visible = True
        End If
    End Sub

    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        Dim StudentBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE ---CATALOG--- LIST
        StudentBindingSource.DataSource = courseList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_COURSESDataGridView.DataSource = StudentBindingSource
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        'CLEAR ALL CONTROLS
        For Each ctrl In gbCourseDetail.Controls
            If TypeOf (ctrl) Is TextBox Then
                TryCast(ctrl, TextBox).Clear()
            End If
        Next

        'SET SAVE BUTTON TO DEFAULT 
        btnSave.Text = "&Save"

        'SWITCH TO LIST MODE
        setMode("L")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        'this sub will add or update a catalog record

        Dim aCourse As clsCourse = New clsCourse

        aCourse.ID = COURSE_IDTextBox.Text
        aCourse.Description = DESCRIPTIONTextBox.Text
        aCourse.Units = UNITSTextBox.Text

        'CHECK IF WE ARE SAVING OR UPDATING
        If (btnSave.Text = "&Save") Then

            If (aCourse.getError = "") Then
                'SAVE STUDENT
                CPP_DB.dbOpen()
                CPP_DB.insertCourse(aCourse)
                CPP_DB.dbClose()

                'CHECK FOR ERRORS
                If CPP_DB.dbGetError <> "" Then
                    MessageBox.Show(CPP_DB.dbGetError)
                Else
                    courseList.Add(aCourse)                       'NO ERRORS ADD STUDENT TO LIST
                    refreshDataGrid()                               'REFRESH GRID
                    MessageBox.Show("Course Saved!")               'NOTIFY
                    Me.setMode("L")                                 'SWITCH TO LIST MODE
                End If
            Else
                MessageBox.Show(aCourse.getError)
            End If

        Else

            If (aCourse.getError = "") Then
                'UPDATE CATALOG
                CPP_DB.dbOpen()
                CPP_DB.updateCourse(aCourse)
                CPP_DB.dbClose()

                'CHECK FOR ERRORS
                If CPP_DB.dbGetError <> "" Then
                    MessageBox.Show(CPP_DB.dbGetError)
                Else
                    'REMOVE OLD CATALOG FROM LIST
                    For Each course In courseList
                        If course.ID = aCourse.ID Then
                            courseList.Remove(course)
                            Exit For
                        End If
                    Next
                    courseList.Add(aCourse)                       'NO ERRORS ADD NEW STUDENT TO LIST
                    refreshDataGrid()                               'REFRESH GRID
                    MessageBox.Show("Catalog Updated!")             'NOTIFY
                    Me.setMode("L")                                 'SWITCH TO LIST MODE
                    Me.btnSave.Text = "&Save"                       'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
                End If
            Else
                MessageBox.Show(aCourse.getError)
            End If

        End If

    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click

        Dim strCatalogId As String = InputBox("Enter Catalog ID")

        For Each row As DataGridViewRow In CPP_COURSESDataGridView.Rows
            If row.Cells(0).Value = strCatalogId Then
                row.Selected = True 'CPP_COURSESDataGridView.CurrentRow.
                MessageBox.Show("Found!")
                Exit Sub
            End If
        Next

        MessageBox.Show("Not found!")

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'SWITCH TO DETAIL DATA ENTRY
        Me.setMode("D")
        Me.COURSE_IDTextBox.Focus()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'GET CURRENT COURSE ROW FROM THE GRID
        Dim row As DataGridViewRow = Me.CPP_COURSESDataGridView.CurrentRow

        'CHECK IF ROW IS VALIID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing Selected!")
            Exit Sub
        End If

        'CONVERT THE ROW TO A STUDENT OBJECT
        Dim aCourse As clsCourse = TryCast(row.DataBoundItem, clsCourse)

        'GET DATA FROM THE ROW TO THE TEXTBOXES
        Me.COURSE_IDTextBox.Text = aCourse.ID
        Me.DESCRIPTIONTextBox.Text = aCourse.Description
        Me.UNITSTextBox.Text = aCourse.Units


        'SET THE FOCUS ON ID
        Me.COURSE_IDTextBox.Focus()

        'SWITCH SAVE TO UPDATE
        Me.btnSave.Text = "&Update"

        'DISPLAY DETAIL MODE
        Me.setMode("D")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_COURSESDataGridView.CurrentRow

        'CHECK IF ROW IS VALID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing selected!")
            Exit Sub
        End If

        'CONVERT ROW TO STUDENT
        Dim aCourse As clsCourse = TryCast(row.DataBoundItem, clsCourse)

        'DELETE STUDENT FROM DB
        CPP_DB.dbOpen()
        CPP_DB.deleteCourse(aCourse.ID)
        CPP_DB.dbClose()

        'CHECK FOR ERRORS
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Course Deleted!")
            'REMOVE COURSE FROM LIST
            For Each course In courseList
                If course.ID = aCourse.ID Then
                    courseList.Remove(course)
                    Exit For
                End If
            Next
            'UPDATE GRID
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub

    Private Sub frmCourse_Load(sender As Object, e As EventArgs) Handles Me.Load
        'LOAD FROM DB
        CPP_DB.dbOpen()
        courseList = CPP_DB.loadCourses()
        CPP_DB.dbClose()

        'CHECK ERRORS
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub
End Class