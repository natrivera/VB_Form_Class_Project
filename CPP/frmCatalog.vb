Public Class frmCatalog

    'a list to hold all the cal=talog objects
    Dim catalogList As New List(Of clsCatalog)

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF CatalogS

        If strMode = "L" Then
            'MODE IS LIST

            Me.gbCatalogDetail.Hide()
            Me.gbCatalogList.Left = 0
            Me.gbCatalogList.Top = 0
            Me.Width = gbCatalogList.Width + 50
            Me.Height = gbCatalogList.Height + 50

            Me.gbCatalogList.Visible = True
        Else
            'MODE IS DETAIL

            Me.gbCatalogList.Hide()
            Me.gbCatalogDetail.Left = 0
            Me.gbCatalogDetail.Top = 0
            Me.Width = gbCatalogDetail.Width + 50
            Me.Height = gbCatalogDetail.Height + 50

            Me.gbCatalogDetail.Visible = True
        End If
    End Sub


    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        Dim StudentBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE ---CATALOG--- LIST
        StudentBindingSource.DataSource = catalogList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        Me.CPP_CATALOGDataGridView.DataSource = StudentBindingSource
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        setMode("D")
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        'this sub will add or update a catalog record

        'create an instance of catalog
        Dim aCatalog As clsCatalog = New clsCatalog()

        'get the input from the user
        aCatalog.ID = CATALOG_IDTextBox.Text
        aCatalog.Year = YEARTextBox.Text
        aCatalog.Quarter = QUARTERComboBox.Text

        Dim courseIDstr As String = Me.COURSE_IDComboBox.Text
        Dim location As Integer = courseIDstr.IndexOf(" ")
        courseIDstr = courseIDstr.Substring(0, location)
        aCatalog.CourseID = courseIDstr

        Dim profIDstr As String = Me.PROF_IDComboBox.Text
        location = profIDstr.IndexOf(" ")
        profIDstr = profIDstr.Substring(0, location)
        aCatalog.ProfessorID = profIDstr

        'CHECK IF WE ARE SAVING OR UPDATING
        If (btn_save.Text = "&Save") Then

            If (aCatalog.getError = "") Then
                'SAVE STUDENT
                CPP_DB.dbOpen()
                CPP_DB.insertCatalog(aCatalog)
                CPP_DB.dbClose()

                'CHECK FOR ERRORS
                If CPP_DB.dbGetError <> "" Then
                    MessageBox.Show(CPP_DB.dbGetError)
                Else
                    catalogList.Add(aCatalog)                       'NO ERRORS ADD STUDENT TO LIST
                    refreshDataGrid()                               'REFRESH GRID
                    MessageBox.Show("Catalog Saved!")               'NOTIFY
                    Me.setMode("L")                                 'SWITCH TO LIST MODE
                End If
            Else
                MessageBox.Show(aCatalog.getError)
            End If

        Else

            If (aCatalog.getError = "") Then
                'UPDATE CATALOG
                CPP_DB.dbOpen()
                CPP_DB.updateCatalog(aCatalog)
                CPP_DB.dbClose()

                'CHECK FOR ERRORS
                If CPP_DB.dbGetError <> "" Then
                    MessageBox.Show(CPP_DB.dbGetError)
                Else
                    'REMOVE OLD CATALOG FROM LIST
                    For Each catalog In catalogList
                        If catalog.ID = aCatalog.ID Then
                            catalogList.Remove(catalog)
                            Exit For
                        End If
                    Next
                    catalogList.Add(aCatalog)                       'NO ERRORS ADD NEW STUDENT TO LIST
                    refreshDataGrid()                               'REFRESH GRID
                    MessageBox.Show("Catalog Updated!")             'NOTIFY
                    Me.setMode("L")                                 'SWITCH TO LIST MODE
                    Me.btn_save.Text = "&Save"                       'MAKE SURE WE SET THE SAVE BUTTON BACK TO DEFAULT
                End If
            Else
                MessageBox.Show(aCatalog.getError)
            End If

        End If

    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click

        Dim strCatalogId As String = InputBox("Enter Catalog ID")

        For Each row As DataGridViewRow In CPP_CATALOGDataGridView.Rows
            If row.Cells(0).Value = strCatalogId Then
                row.Selected = True 'CPP_CATALOGDataGridView.CurrentRow.
                MessageBox.Show("Found!")
                Exit Sub
            End If
        Next

        MessageBox.Show("Not found!")

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim row As DataGridViewRow = Me.CPP_CATALOGDataGridView.CurrentRow

        'CHECK IF ROW IS VALID OTHERWISE STOP
        If IsNothing(row) Then
            MessageBox.Show("Nothing selected!")
            Exit Sub
        End If

        'CONVERT ROW TO CATALOG
        Dim aCatalog As clsCatalog = TryCast(row.DataBoundItem, clsCatalog)

        'DELETE CATALOG FROM DB
        CPP_DB.dbOpen()
        CPP_DB.deleteStudent(aCatalog.ID)
        CPP_DB.dbClose()

        'CHECK FOR ERRORS
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Student Deleted!")
            'REMOVE CATALOG FROM LIST
            For Each catalog In catalogList
                If catalog.ID = aCatalog.ID Then
                    catalogList.Remove(catalog)
                    Exit For
                End If
            Next
            'UPDATE GRID
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        'CLEAR ALL CONTROLS
        For Each ctrl In gbCatalogDetail.Controls
            If TypeOf (ctrl) Is TextBox Then
                TryCast(ctrl, TextBox).Clear()
            End If
        Next

        'SET SAVE BUTTON TO DEFAULT 
        btn_save.Text = "&Save"

        'SWITCH TO LIST MODE
        setMode("L")
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        setMode("D")
    End Sub

    Private Sub frmCatalog_Load(sender As Object, e As EventArgs) Handles Me.Load
        CPP_DB.dbOpen()
        catalogList = CPP_DB.loadCatalog
        refreshDataGrid()
        CPP_DB.dbClose()

        'LOAD ALL THE COMBO BOXES
        CPP_DB.dbOpen()
        Dim coursesBox As ComboBox = COURSE_IDComboBox
        Dim courses As List(Of clsCourse) = CPP_DB.loadCourses
        For Each course In courses
            coursesBox.Items.Add(course.ID & " - (" & course.Description & ")")
        Next
        CPP_DB.dbClose()

        CPP_DB.dbOpen()
        Dim instructorbox As ComboBox = PROF_IDComboBox
        Dim instructors As List(Of clsInstructor) = CPP_DB.loadIntructor
        For Each instructor In instructors
            instructorbox.Items.Add(instructor.ID & " - (" & instructor.firstName & ", " & instructor.lastName & ")")
        Next
        CPP_DB.dbClose()

    End Sub
End Class