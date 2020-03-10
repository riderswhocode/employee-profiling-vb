<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateRoleForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateRoleForm))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.lblusername = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chxWithGrantOption = New System.Windows.Forms.CheckBox()
        Me.chxTruncate = New System.Windows.Forms.CheckBox()
        Me.chxDelete = New System.Windows.Forms.CheckBox()
        Me.chxUpdate = New System.Windows.Forms.CheckBox()
        Me.chxInsert = New System.Windows.Forms.CheckBox()
        Me.chxSelect = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Children", "Educational_Background", "Personal_info", "Salary_Grade_StepIncrement", "Seminars", "Service_Record", "UsersTable", "RolesTable", "Works_Trainings"})
        Me.ComboBox1.Location = New System.Drawing.Point(103, 32)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(242, 24)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Text = "UsersTable"
        '
        'lblusername
        '
        Me.lblusername.AutoSize = True
        Me.lblusername.Location = New System.Drawing.Point(100, 9)
        Me.lblusername.Name = "lblusername"
        Me.lblusername.Size = New System.Drawing.Size(51, 17)
        Me.lblusername.TabIndex = 1
        Me.lblusername.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Table Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Username"
        '
        'chxWithGrantOption
        '
        Me.chxWithGrantOption.AutoSize = True
        Me.chxWithGrantOption.Location = New System.Drawing.Point(212, 107)
        Me.chxWithGrantOption.Margin = New System.Windows.Forms.Padding(4)
        Me.chxWithGrantOption.Name = "chxWithGrantOption"
        Me.chxWithGrantOption.Size = New System.Drawing.Size(141, 21)
        Me.chxWithGrantOption.TabIndex = 25
        Me.chxWithGrantOption.Text = "With Grant Option"
        Me.chxWithGrantOption.UseVisualStyleBackColor = True
        '
        'chxTruncate
        '
        Me.chxTruncate.AutoSize = True
        Me.chxTruncate.Location = New System.Drawing.Point(212, 78)
        Me.chxTruncate.Margin = New System.Windows.Forms.Padding(4)
        Me.chxTruncate.Name = "chxTruncate"
        Me.chxTruncate.Size = New System.Drawing.Size(84, 21)
        Me.chxTruncate.TabIndex = 24
        Me.chxTruncate.Text = "Truncate"
        Me.chxTruncate.UseVisualStyleBackColor = True
        '
        'chxDelete
        '
        Me.chxDelete.AutoSize = True
        Me.chxDelete.Location = New System.Drawing.Point(112, 107)
        Me.chxDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.chxDelete.Name = "chxDelete"
        Me.chxDelete.Size = New System.Drawing.Size(68, 21)
        Me.chxDelete.TabIndex = 23
        Me.chxDelete.Text = "Delete"
        Me.chxDelete.UseVisualStyleBackColor = True
        '
        'chxUpdate
        '
        Me.chxUpdate.AutoSize = True
        Me.chxUpdate.Location = New System.Drawing.Point(113, 78)
        Me.chxUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.chxUpdate.Name = "chxUpdate"
        Me.chxUpdate.Size = New System.Drawing.Size(73, 21)
        Me.chxUpdate.TabIndex = 22
        Me.chxUpdate.Text = "Update"
        Me.chxUpdate.UseVisualStyleBackColor = True
        '
        'chxInsert
        '
        Me.chxInsert.AutoSize = True
        Me.chxInsert.Location = New System.Drawing.Point(19, 107)
        Me.chxInsert.Margin = New System.Windows.Forms.Padding(4)
        Me.chxInsert.Name = "chxInsert"
        Me.chxInsert.Size = New System.Drawing.Size(62, 21)
        Me.chxInsert.TabIndex = 21
        Me.chxInsert.Text = "Insert"
        Me.chxInsert.UseVisualStyleBackColor = True
        '
        'chxSelect
        '
        Me.chxSelect.AutoSize = True
        Me.chxSelect.Location = New System.Drawing.Point(19, 78)
        Me.chxSelect.Margin = New System.Windows.Forms.Padding(4)
        Me.chxSelect.Name = "chxSelect"
        Me.chxSelect.Size = New System.Drawing.Size(66, 21)
        Me.chxSelect.TabIndex = 20
        Me.chxSelect.Text = "Select"
        Me.chxSelect.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(245, 136)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(222, 49)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Label3"
        '
        'CreateRoleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 178)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chxWithGrantOption)
        Me.Controls.Add(Me.chxTruncate)
        Me.Controls.Add(Me.chxDelete)
        Me.Controls.Add(Me.chxUpdate)
        Me.Controls.Add(Me.chxInsert)
        Me.Controls.Add(Me.chxSelect)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblusername)
        Me.Controls.Add(Me.ComboBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CreateRoleForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Create Role"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents lblusername As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chxWithGrantOption As System.Windows.Forms.CheckBox
    Friend WithEvents chxTruncate As System.Windows.Forms.CheckBox
    Friend WithEvents chxDelete As System.Windows.Forms.CheckBox
    Friend WithEvents chxUpdate As System.Windows.Forms.CheckBox
    Friend WithEvents chxInsert As System.Windows.Forms.CheckBox
    Friend WithEvents chxSelect As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
