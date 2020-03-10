<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionYesNoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionYesNoForm))
        Me.YesNomsg = New System.Windows.Forms.Label()
        Me.AlertImage = New System.Windows.Forms.PictureBox()
        Me.btnOk = New Postgess.ljButtonEmboss()
        Me.btnCancel = New Postgess.ljButtonEmboss()
        CType(Me.AlertImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'YesNomsg
        '
        Me.YesNomsg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.YesNomsg.BackColor = System.Drawing.Color.Transparent
        Me.YesNomsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YesNomsg.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.YesNomsg.Location = New System.Drawing.Point(94, 61)
        Me.YesNomsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.YesNomsg.Name = "YesNomsg"
        Me.YesNomsg.Size = New System.Drawing.Size(431, 93)
        Me.YesNomsg.TabIndex = 15
        Me.YesNomsg.Text = "msg"
        Me.YesNomsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AlertImage
        '
        Me.AlertImage.BackColor = System.Drawing.Color.Transparent
        Me.AlertImage.Image = Global.Postgess.My.Resources.Resources.infopic2
        Me.AlertImage.Location = New System.Drawing.Point(17, 61)
        Me.AlertImage.Name = "AlertImage"
        Me.AlertImage.Size = New System.Drawing.Size(72, 72)
        Me.AlertImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AlertImage.TabIndex = 14
        Me.AlertImage.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackgroundImage = CType(resources.GetObject("btnOk.BackgroundImage"), System.Drawing.Image)
        Me.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Image = Global.Postgess.My.Resources.Resources.ok1
        Me.btnOk.Location = New System.Drawing.Point(385, 171)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(140, 40)
        Me.btnOk.TabIndex = 18
        Me.btnOk.Text = "Yes"
        Me.btnOk.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Image = Global.Postgess.My.Resources.Resources.delete
        Me.btnCancel.Location = New System.Drawing.Point(239, 172)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(140, 40)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "No"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'OptionYesNoForm
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(556, 228)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.YesNomsg)
        Me.Controls.Add(Me.AlertImage)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "OptionYesNoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Profiling"
        CType(Me.AlertImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents YesNomsg As System.Windows.Forms.Label
    Friend WithEvents AlertImage As System.Windows.Forms.PictureBox
    Friend WithEvents btnOk As Postgess.ljButtonEmboss
    Friend WithEvents btnCancel As Postgess.ljButtonEmboss
End Class
