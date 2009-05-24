<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileAttributes
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFileAttributes))
        Me.lblFileName = New System.Windows.Forms.Label
        Me.lblOwner = New System.Windows.Forms.Label
        Me.lblGroup = New System.Windows.Forms.Label
        Me.lblEveryone = New System.Windows.Forms.Label
        Me.chkOR = New System.Windows.Forms.CheckBox
        Me.chkOW = New System.Windows.Forms.CheckBox
        Me.chkOX = New System.Windows.Forms.CheckBox
        Me.chkGX = New System.Windows.Forms.CheckBox
        Me.chkGW = New System.Windows.Forms.CheckBox
        Me.chkGR = New System.Windows.Forms.CheckBox
        Me.chkEX = New System.Windows.Forms.CheckBox
        Me.chkEW = New System.Windows.Forms.CheckBox
        Me.chkER = New System.Windows.Forms.CheckBox
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblOwnerName = New System.Windows.Forms.Label
        Me.lblGroupName = New System.Windows.Forms.Label
        Me.lblUpdate = New System.Windows.Forms.Label
        Me.lblUpdateValue = New System.Windows.Forms.Label
        Me.lblOctal = New System.Windows.Forms.Label
        Me.txtOctal = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lblFileName
        '
        Me.lblFileName.AccessibleDescription = Nothing
        Me.lblFileName.AccessibleName = Nothing
        resources.ApplyResources(Me.lblFileName, "lblFileName")
        Me.lblFileName.Font = Nothing
        Me.lblFileName.Name = "lblFileName"
        '
        'lblOwner
        '
        Me.lblOwner.AccessibleDescription = Nothing
        Me.lblOwner.AccessibleName = Nothing
        resources.ApplyResources(Me.lblOwner, "lblOwner")
        Me.lblOwner.Font = Nothing
        Me.lblOwner.Name = "lblOwner"
        '
        'lblGroup
        '
        Me.lblGroup.AccessibleDescription = Nothing
        Me.lblGroup.AccessibleName = Nothing
        resources.ApplyResources(Me.lblGroup, "lblGroup")
        Me.lblGroup.Font = Nothing
        Me.lblGroup.Name = "lblGroup"
        '
        'lblEveryone
        '
        Me.lblEveryone.AccessibleDescription = Nothing
        Me.lblEveryone.AccessibleName = Nothing
        resources.ApplyResources(Me.lblEveryone, "lblEveryone")
        Me.lblEveryone.Font = Nothing
        Me.lblEveryone.Name = "lblEveryone"
        '
        'chkOR
        '
        Me.chkOR.AccessibleDescription = Nothing
        Me.chkOR.AccessibleName = Nothing
        resources.ApplyResources(Me.chkOR, "chkOR")
        Me.chkOR.BackgroundImage = Nothing
        Me.chkOR.Font = Nothing
        Me.chkOR.Name = "chkOR"
        Me.chkOR.UseVisualStyleBackColor = False
        '
        'chkOW
        '
        Me.chkOW.AccessibleDescription = Nothing
        Me.chkOW.AccessibleName = Nothing
        resources.ApplyResources(Me.chkOW, "chkOW")
        Me.chkOW.BackgroundImage = Nothing
        Me.chkOW.Font = Nothing
        Me.chkOW.Name = "chkOW"
        Me.chkOW.UseVisualStyleBackColor = True
        '
        'chkOX
        '
        Me.chkOX.AccessibleDescription = Nothing
        Me.chkOX.AccessibleName = Nothing
        resources.ApplyResources(Me.chkOX, "chkOX")
        Me.chkOX.BackgroundImage = Nothing
        Me.chkOX.Font = Nothing
        Me.chkOX.Name = "chkOX"
        Me.chkOX.UseVisualStyleBackColor = True
        '
        'chkGX
        '
        Me.chkGX.AccessibleDescription = Nothing
        Me.chkGX.AccessibleName = Nothing
        resources.ApplyResources(Me.chkGX, "chkGX")
        Me.chkGX.BackgroundImage = Nothing
        Me.chkGX.Font = Nothing
        Me.chkGX.Name = "chkGX"
        Me.chkGX.UseVisualStyleBackColor = True
        '
        'chkGW
        '
        Me.chkGW.AccessibleDescription = Nothing
        Me.chkGW.AccessibleName = Nothing
        resources.ApplyResources(Me.chkGW, "chkGW")
        Me.chkGW.BackgroundImage = Nothing
        Me.chkGW.Font = Nothing
        Me.chkGW.Name = "chkGW"
        Me.chkGW.UseVisualStyleBackColor = True
        '
        'chkGR
        '
        Me.chkGR.AccessibleDescription = Nothing
        Me.chkGR.AccessibleName = Nothing
        resources.ApplyResources(Me.chkGR, "chkGR")
        Me.chkGR.BackgroundImage = Nothing
        Me.chkGR.Font = Nothing
        Me.chkGR.Name = "chkGR"
        Me.chkGR.UseVisualStyleBackColor = True
        '
        'chkEX
        '
        Me.chkEX.AccessibleDescription = Nothing
        Me.chkEX.AccessibleName = Nothing
        resources.ApplyResources(Me.chkEX, "chkEX")
        Me.chkEX.BackgroundImage = Nothing
        Me.chkEX.Font = Nothing
        Me.chkEX.Name = "chkEX"
        Me.chkEX.UseVisualStyleBackColor = True
        '
        'chkEW
        '
        Me.chkEW.AccessibleDescription = Nothing
        Me.chkEW.AccessibleName = Nothing
        resources.ApplyResources(Me.chkEW, "chkEW")
        Me.chkEW.BackgroundImage = Nothing
        Me.chkEW.Font = Nothing
        Me.chkEW.Name = "chkEW"
        Me.chkEW.UseVisualStyleBackColor = True
        '
        'chkER
        '
        Me.chkER.AccessibleDescription = Nothing
        Me.chkER.AccessibleName = Nothing
        resources.ApplyResources(Me.chkER, "chkER")
        Me.chkER.BackgroundImage = Nothing
        Me.chkER.Font = Nothing
        Me.chkER.Name = "chkER"
        Me.chkER.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.AccessibleDescription = Nothing
        Me.txtFileName.AccessibleName = Nothing
        resources.ApplyResources(Me.txtFileName, "txtFileName")
        Me.txtFileName.BackgroundImage = Nothing
        Me.txtFileName.Font = Nothing
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        '
        'btnOK
        '
        Me.btnOK.AccessibleDescription = Nothing
        Me.btnOK.AccessibleName = Nothing
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.BackgroundImage = Nothing
        Me.btnOK.Font = Nothing
        Me.btnOK.Name = "btnOK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleDescription = Nothing
        Me.btnCancel.AccessibleName = Nothing
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.BackgroundImage = Nothing
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = Nothing
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblOwnerName
        '
        Me.lblOwnerName.AccessibleDescription = Nothing
        Me.lblOwnerName.AccessibleName = Nothing
        resources.ApplyResources(Me.lblOwnerName, "lblOwnerName")
        Me.lblOwnerName.Font = Nothing
        Me.lblOwnerName.Name = "lblOwnerName"
        '
        'lblGroupName
        '
        Me.lblGroupName.AccessibleDescription = Nothing
        Me.lblGroupName.AccessibleName = Nothing
        resources.ApplyResources(Me.lblGroupName, "lblGroupName")
        Me.lblGroupName.Font = Nothing
        Me.lblGroupName.Name = "lblGroupName"
        '
        'lblUpdate
        '
        Me.lblUpdate.AccessibleDescription = Nothing
        Me.lblUpdate.AccessibleName = Nothing
        resources.ApplyResources(Me.lblUpdate, "lblUpdate")
        Me.lblUpdate.Font = Nothing
        Me.lblUpdate.Name = "lblUpdate"
        '
        'lblUpdateValue
        '
        Me.lblUpdateValue.AccessibleDescription = Nothing
        Me.lblUpdateValue.AccessibleName = Nothing
        resources.ApplyResources(Me.lblUpdateValue, "lblUpdateValue")
        Me.lblUpdateValue.Font = Nothing
        Me.lblUpdateValue.Name = "lblUpdateValue"
        '
        'lblOctal
        '
        Me.lblOctal.AccessibleDescription = Nothing
        Me.lblOctal.AccessibleName = Nothing
        resources.ApplyResources(Me.lblOctal, "lblOctal")
        Me.lblOctal.Font = Nothing
        Me.lblOctal.Name = "lblOctal"
        '
        'txtOctal
        '
        Me.txtOctal.AccessibleDescription = Nothing
        Me.txtOctal.AccessibleName = Nothing
        resources.ApplyResources(Me.txtOctal, "txtOctal")
        Me.txtOctal.BackgroundImage = Nothing
        Me.txtOctal.Font = Nothing
        Me.txtOctal.Name = "txtOctal"
        '
        'frmFileAttributes
        '
        Me.AcceptButton = Me.btnOK
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.CancelButton = Me.btnCancel
        Me.Controls.Add(Me.txtOctal)
        Me.Controls.Add(Me.lblOctal)
        Me.Controls.Add(Me.lblUpdateValue)
        Me.Controls.Add(Me.lblUpdate)
        Me.Controls.Add(Me.lblGroupName)
        Me.Controls.Add(Me.lblOwnerName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.chkEX)
        Me.Controls.Add(Me.chkEW)
        Me.Controls.Add(Me.chkER)
        Me.Controls.Add(Me.chkGX)
        Me.Controls.Add(Me.chkGW)
        Me.Controls.Add(Me.chkGR)
        Me.Controls.Add(Me.chkOX)
        Me.Controls.Add(Me.chkOW)
        Me.Controls.Add(Me.chkOR)
        Me.Controls.Add(Me.lblEveryone)
        Me.Controls.Add(Me.lblGroup)
        Me.Controls.Add(Me.lblOwner)
        Me.Controls.Add(Me.lblFileName)
        Me.Font = Nothing
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = Nothing
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFileAttributes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents lblOwner As System.Windows.Forms.Label
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblEveryone As System.Windows.Forms.Label
    Friend WithEvents chkOR As System.Windows.Forms.CheckBox
    Friend WithEvents chkOW As System.Windows.Forms.CheckBox
    Friend WithEvents chkOX As System.Windows.Forms.CheckBox
    Friend WithEvents chkGX As System.Windows.Forms.CheckBox
    Friend WithEvents chkGW As System.Windows.Forms.CheckBox
    Friend WithEvents chkGR As System.Windows.Forms.CheckBox
    Friend WithEvents chkEX As System.Windows.Forms.CheckBox
    Friend WithEvents chkEW As System.Windows.Forms.CheckBox
    Friend WithEvents chkER As System.Windows.Forms.CheckBox
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblOwnerName As System.Windows.Forms.Label
    Friend WithEvents lblGroupName As System.Windows.Forms.Label
    Friend WithEvents lblUpdate As System.Windows.Forms.Label
    Friend WithEvents lblUpdateValue As System.Windows.Forms.Label
    Friend WithEvents lblOctal As System.Windows.Forms.Label
    Friend WithEvents txtOctal As System.Windows.Forms.TextBox
End Class
