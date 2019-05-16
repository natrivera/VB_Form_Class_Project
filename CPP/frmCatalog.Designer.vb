<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatalog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim CATALOG_IDLabel As System.Windows.Forms.Label
        Dim YEARLabel As System.Windows.Forms.Label
        Dim QUARTERLabel As System.Windows.Forms.Label
        Dim COURSE_IDLabel As System.Windows.Forms.Label
        Dim PROF_IDLabel As System.Windows.Forms.Label
        Me.gbCatalogDetail = New System.Windows.Forms.GroupBox()
        Me.CATALOG_IDTextBox = New System.Windows.Forms.TextBox()
        Me.YEARTextBox = New System.Windows.Forms.TextBox()
        Me.QUARTERComboBox = New System.Windows.Forms.ComboBox()
        Me.COURSE_IDComboBox = New System.Windows.Forms.ComboBox()
        Me.PROF_IDComboBox = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.gbCatalogList = New System.Windows.Forms.GroupBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.CPP_CATALOGDataGridView = New System.Windows.Forms.DataGridView()
        CATALOG_IDLabel = New System.Windows.Forms.Label()
        YEARLabel = New System.Windows.Forms.Label()
        QUARTERLabel = New System.Windows.Forms.Label()
        COURSE_IDLabel = New System.Windows.Forms.Label()
        PROF_IDLabel = New System.Windows.Forms.Label()
        Me.gbCatalogDetail.SuspendLayout
        Me.gbCatalogList.SuspendLayout
        CType(Me.CPP_CATALOGDataGridView,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'CATALOG_IDLabel
        '
        CATALOG_IDLabel.AutoSize = True
        CATALOG_IDLabel.Location = New System.Drawing.Point(81, 47)
        CATALOG_IDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        CATALOG_IDLabel.Name = "CATALOG_IDLabel"
        CATALOG_IDLabel.Size = New System.Drawing.Size(95, 17)
        CATALOG_IDLabel.TabIndex = 24
        CATALOG_IDLabel.Text = "CATALOG ID:"
        '
        'YEARLabel
        '
        YEARLabel.AutoSize = True
        YEARLabel.Location = New System.Drawing.Point(81, 79)
        YEARLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        YEARLabel.Name = "YEARLabel"
        YEARLabel.Size = New System.Drawing.Size(49, 17)
        YEARLabel.TabIndex = 26
        YEARLabel.Text = "YEAR:"
        '
        'QUARTERLabel
        '
        QUARTERLabel.AutoSize = True
        QUARTERLabel.Location = New System.Drawing.Point(81, 111)
        QUARTERLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        QUARTERLabel.Name = "QUARTERLabel"
        QUARTERLabel.Size = New System.Drawing.Size(80, 17)
        QUARTERLabel.TabIndex = 28
        QUARTERLabel.Text = "QUARTER:"
        '
        'COURSE_IDLabel
        '
        COURSE_IDLabel.AutoSize = True
        COURSE_IDLabel.Location = New System.Drawing.Point(81, 144)
        COURSE_IDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        COURSE_IDLabel.Name = "COURSE_IDLabel"
        COURSE_IDLabel.Size = New System.Drawing.Size(87, 17)
        COURSE_IDLabel.TabIndex = 30
        COURSE_IDLabel.Text = "COURSE ID:"
        '
        'PROF_IDLabel
        '
        PROF_IDLabel.AutoSize = True
        PROF_IDLabel.Location = New System.Drawing.Point(81, 177)
        PROF_IDLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        PROF_IDLabel.Name = "PROF_IDLabel"
        PROF_IDLabel.Size = New System.Drawing.Size(67, 17)
        PROF_IDLabel.TabIndex = 32
        PROF_IDLabel.Text = "PROF ID:"
        '
        'gbCatalogDetail
        '
        Me.gbCatalogDetail.Controls.Add(CATALOG_IDLabel)
        Me.gbCatalogDetail.Controls.Add(Me.CATALOG_IDTextBox)
        Me.gbCatalogDetail.Controls.Add(YEARLabel)
        Me.gbCatalogDetail.Controls.Add(Me.YEARTextBox)
        Me.gbCatalogDetail.Controls.Add(QUARTERLabel)
        Me.gbCatalogDetail.Controls.Add(Me.QUARTERComboBox)
        Me.gbCatalogDetail.Controls.Add(COURSE_IDLabel)
        Me.gbCatalogDetail.Controls.Add(Me.COURSE_IDComboBox)
        Me.gbCatalogDetail.Controls.Add(PROF_IDLabel)
        Me.gbCatalogDetail.Controls.Add(Me.PROF_IDComboBox)
        Me.gbCatalogDetail.Controls.Add(Me.btnCancel)
        Me.gbCatalogDetail.Controls.Add(Me.btn_save)
        Me.gbCatalogDetail.Location = New System.Drawing.Point(16, 15)
        Me.gbCatalogDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.gbCatalogDetail.Name = "gbCatalogDetail"
        Me.gbCatalogDetail.Padding = New System.Windows.Forms.Padding(4)
        Me.gbCatalogDetail.Size = New System.Drawing.Size(855, 310)
        Me.gbCatalogDetail.TabIndex = 14
        Me.gbCatalogDetail.TabStop = False
        Me.gbCatalogDetail.Visible = False
        '
        'CATALOG_IDTextBox
        '
        Me.CATALOG_IDTextBox.Location = New System.Drawing.Point(188, 43)
        Me.CATALOG_IDTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.CATALOG_IDTextBox.Name = "CATALOG_IDTextBox"
        Me.CATALOG_IDTextBox.Size = New System.Drawing.Size(99, 22)
        Me.CATALOG_IDTextBox.TabIndex = 25
        '
        'YEARTextBox
        '
        Me.YEARTextBox.Location = New System.Drawing.Point(188, 75)
        Me.YEARTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.YEARTextBox.Name = "YEARTextBox"
        Me.YEARTextBox.Size = New System.Drawing.Size(160, 22)
        Me.YEARTextBox.TabIndex = 27
        '
        'QUARTERComboBox
        '
        Me.QUARTERComboBox.FormattingEnabled = True
        Me.QUARTERComboBox.Items.AddRange(New Object() {"FALL", "WINTER", "SPRING", "SUMMER"})
        Me.QUARTERComboBox.Location = New System.Drawing.Point(188, 107)
        Me.QUARTERComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.QUARTERComboBox.Name = "QUARTERComboBox"
        Me.QUARTERComboBox.Size = New System.Drawing.Size(160, 24)
        Me.QUARTERComboBox.TabIndex = 29
        '
        'COURSE_IDComboBox
        '
        Me.COURSE_IDComboBox.FormattingEnabled = True
        Me.COURSE_IDComboBox.Location = New System.Drawing.Point(188, 140)
        Me.COURSE_IDComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.COURSE_IDComboBox.Name = "COURSE_IDComboBox"
        Me.COURSE_IDComboBox.Size = New System.Drawing.Size(387, 24)
        Me.COURSE_IDComboBox.TabIndex = 31
        '
        'PROF_IDComboBox
        '
        Me.PROF_IDComboBox.FormattingEnabled = True
        Me.PROF_IDComboBox.Location = New System.Drawing.Point(188, 174)
        Me.PROF_IDComboBox.Margin = New System.Windows.Forms.Padding(4)
        Me.PROF_IDComboBox.Name = "PROF_IDComboBox"
        Me.PROF_IDComboBox.Size = New System.Drawing.Size(387, 24)
        Me.PROF_IDComboBox.TabIndex = 33
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(220, 235)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCancel.TabIndex = 24
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Location = New System.Drawing.Point(85, 235)
        Me.btn_save.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(100, 28)
        Me.btn_save.TabIndex = 23
        Me.btn_save.Text = "&Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'gbCatalogList
        '
        Me.gbCatalogList.Controls.Add(Me.btnFind)
        Me.gbCatalogList.Controls.Add(Me.btnDelete)
        Me.gbCatalogList.Controls.Add(Me.btnUpdate)
        Me.gbCatalogList.Controls.Add(Me.btnAdd)
        Me.gbCatalogList.Controls.Add(Me.CPP_CATALOGDataGridView)
        Me.gbCatalogList.Location = New System.Drawing.Point(16, 332)
        Me.gbCatalogList.Margin = New System.Windows.Forms.Padding(4)
        Me.gbCatalogList.Name = "gbCatalogList"
        Me.gbCatalogList.Padding = New System.Windows.Forms.Padding(4)
        Me.gbCatalogList.Size = New System.Drawing.Size(855, 470)
        Me.gbCatalogList.TabIndex = 15
        Me.gbCatalogList.TabStop = False
        Me.gbCatalogList.Text = "Course Catalog List"
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(393, 402)
        Me.btnFind.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(100, 28)
        Me.btnFind.TabIndex = 18
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(265, 402)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 28)
        Me.btnDelete.TabIndex = 17
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(143, 402)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(100, 28)
        Me.btnUpdate.TabIndex = 16
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(23, 402)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 28)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'CPP_CATALOGDataGridView
        '
        Me.CPP_CATALOGDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CPP_CATALOGDataGridView.Location = New System.Drawing.Point(23, 30)
        Me.CPP_CATALOGDataGridView.Margin = New System.Windows.Forms.Padding(4)
        Me.CPP_CATALOGDataGridView.Name = "CPP_CATALOGDataGridView"
        Me.CPP_CATALOGDataGridView.Size = New System.Drawing.Size(809, 335)
        Me.CPP_CATALOGDataGridView.TabIndex = 14
        '
        'frmCatalog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 815)
        Me.Controls.Add(Me.gbCatalogList)
        Me.Controls.Add(Me.gbCatalogDetail)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmCatalog"
        Me.Text = "CPP COURSE CATALOG INFORMATION"
        Me.gbCatalogDetail.ResumeLayout(false)
        Me.gbCatalogDetail.PerformLayout
        Me.gbCatalogList.ResumeLayout(false)
        CType(Me.CPP_CATALOGDataGridView,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents gbCatalogDetail As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents gbCatalogList As System.Windows.Forms.GroupBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents CPP_CATALOGDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents CATALOG_IDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents YEARTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QUARTERComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents COURSE_IDComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents PROF_IDComboBox As System.Windows.Forms.ComboBox
End Class
