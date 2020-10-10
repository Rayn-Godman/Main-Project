<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHousehold
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
        Me.btnSetData = New System.Windows.Forms.Button()
        Me.btnReadData = New System.Windows.Forms.Button()
        Me.txtDisplayItem = New System.Windows.Forms.RichTextBox()
        Me.btnDetailsItem = New System.Windows.Forms.Button()
        Me.txtDisplayHouse = New System.Windows.Forms.RichTextBox()
        Me.btnHouseDetails = New System.Windows.Forms.Button()
        Me.btnCategory = New System.Windows.Forms.Button()
        Me.btnSaveFile = New System.Windows.Forms.Button()
        Me.btnCreateFile = New System.Windows.Forms.Button()
        Me.btnFileRead = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSetData
        '
        Me.btnSetData.Location = New System.Drawing.Point(40, 25)
        Me.btnSetData.Name = "btnSetData"
        Me.btnSetData.Size = New System.Drawing.Size(158, 44)
        Me.btnSetData.TabIndex = 0
        Me.btnSetData.Text = "Set Data"
        Me.btnSetData.UseVisualStyleBackColor = True
        '
        'btnReadData
        '
        Me.btnReadData.Location = New System.Drawing.Point(40, 75)
        Me.btnReadData.Name = "btnReadData"
        Me.btnReadData.Size = New System.Drawing.Size(158, 42)
        Me.btnReadData.TabIndex = 1
        Me.btnReadData.Text = "Read In Data"
        Me.btnReadData.UseVisualStyleBackColor = True
        '
        'txtDisplayItem
        '
        Me.txtDisplayItem.Location = New System.Drawing.Point(219, 25)
        Me.txtDisplayItem.Name = "txtDisplayItem"
        Me.txtDisplayItem.Size = New System.Drawing.Size(400, 472)
        Me.txtDisplayItem.TabIndex = 2
        Me.txtDisplayItem.Text = ""
        '
        'btnDetailsItem
        '
        Me.btnDetailsItem.Location = New System.Drawing.Point(40, 123)
        Me.btnDetailsItem.Name = "btnDetailsItem"
        Me.btnDetailsItem.Size = New System.Drawing.Size(158, 47)
        Me.btnDetailsItem.TabIndex = 3
        Me.btnDetailsItem.Text = "Display Details of each Item"
        Me.btnDetailsItem.UseVisualStyleBackColor = True
        '
        'txtDisplayHouse
        '
        Me.txtDisplayHouse.Location = New System.Drawing.Point(640, 25)
        Me.txtDisplayHouse.Name = "txtDisplayHouse"
        Me.txtDisplayHouse.Size = New System.Drawing.Size(300, 472)
        Me.txtDisplayHouse.TabIndex = 4
        Me.txtDisplayHouse.Text = ""
        '
        'btnHouseDetails
        '
        Me.btnHouseDetails.Location = New System.Drawing.Point(40, 176)
        Me.btnHouseDetails.Name = "btnHouseDetails"
        Me.btnHouseDetails.Size = New System.Drawing.Size(158, 48)
        Me.btnHouseDetails.TabIndex = 5
        Me.btnHouseDetails.Text = "Display Household Details"
        Me.btnHouseDetails.UseVisualStyleBackColor = True
        '
        'btnCategory
        '
        Me.btnCategory.Location = New System.Drawing.Point(40, 230)
        Me.btnCategory.Name = "btnCategory"
        Me.btnCategory.Size = New System.Drawing.Size(158, 54)
        Me.btnCategory.TabIndex = 6
        Me.btnCategory.Text = "Display Category of each Item"
        Me.btnCategory.UseVisualStyleBackColor = True
        '
        'btnSaveFile
        '
        Me.btnSaveFile.Location = New System.Drawing.Point(40, 389)
        Me.btnSaveFile.Name = "btnSaveFile"
        Me.btnSaveFile.Size = New System.Drawing.Size(158, 54)
        Me.btnSaveFile.TabIndex = 7
        Me.btnSaveFile.Text = "Save File"
        Me.btnSaveFile.UseVisualStyleBackColor = True
        '
        'btnCreateFile
        '
        Me.btnCreateFile.Location = New System.Drawing.Point(40, 334)
        Me.btnCreateFile.Name = "btnCreateFile"
        Me.btnCreateFile.Size = New System.Drawing.Size(158, 49)
        Me.btnCreateFile.TabIndex = 9
        Me.btnCreateFile.Text = "Create File"
        Me.btnCreateFile.UseVisualStyleBackColor = True
        '
        'btnFileRead
        '
        Me.btnFileRead.Location = New System.Drawing.Point(40, 450)
        Me.btnFileRead.Name = "btnFileRead"
        Me.btnFileRead.Size = New System.Drawing.Size(158, 47)
        Me.btnFileRead.TabIndex = 10
        Me.btnFileRead.Text = "Read File"
        Me.btnFileRead.UseVisualStyleBackColor = True
        '
        'frmHousehold
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 518)
        Me.Controls.Add(Me.btnFileRead)
        Me.Controls.Add(Me.btnCreateFile)
        Me.Controls.Add(Me.btnSaveFile)
        Me.Controls.Add(Me.btnCategory)
        Me.Controls.Add(Me.btnHouseDetails)
        Me.Controls.Add(Me.txtDisplayHouse)
        Me.Controls.Add(Me.btnDetailsItem)
        Me.Controls.Add(Me.txtDisplayItem)
        Me.Controls.Add(Me.btnReadData)
        Me.Controls.Add(Me.btnSetData)
        Me.Name = "frmHousehold"
        Me.Text = " Household Items Programme"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSetData As Button
    Friend WithEvents btnReadData As Button
    Friend WithEvents txtDisplayItem As RichTextBox
    Friend WithEvents btnDetailsItem As Button
    Friend WithEvents txtDisplayHouse As RichTextBox
    Friend WithEvents btnHouseDetails As Button
    Friend WithEvents btnCategory As Button
    Friend WithEvents btnSaveFile As Button
    Friend WithEvents btnReadFile As Button
    Friend WithEvents btnCreateFile As Button
    Friend WithEvents btnFileRead As Button
End Class
