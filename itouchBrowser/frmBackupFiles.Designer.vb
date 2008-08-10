<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackupFiles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBackupFiles))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.dgvBackupView = New System.Windows.Forms.DataGridView
        Me.colFileName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBackupDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFSize = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colFolderName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCnt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabFileGroup = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgvDetailView = New System.Windows.Forms.DataGridView
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnClose = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.statFileCount = New System.Windows.Forms.ToolStripStatusLabel
        Me.statFileName = New System.Windows.Forms.ToolStripStatusLabel
        Me.statDummy = New System.Windows.Forms.ToolStripStatusLabel
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvBackupView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabFileGroup.SuspendLayout()
        CType(Me.dgvDetailView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.AccessibleDescription = Nothing
        Me.SplitContainer1.AccessibleName = Nothing
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.BackgroundImage = Nothing
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Font = Nothing
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AccessibleDescription = Nothing
        Me.SplitContainer1.Panel1.AccessibleName = Nothing
        resources.ApplyResources(Me.SplitContainer1.Panel1, "SplitContainer1.Panel1")
        Me.SplitContainer1.Panel1.BackgroundImage = Nothing
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvBackupView)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabFileGroup)
        Me.SplitContainer1.Panel1.Font = Nothing
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AccessibleDescription = Nothing
        Me.SplitContainer1.Panel2.AccessibleName = Nothing
        resources.ApplyResources(Me.SplitContainer1.Panel2, "SplitContainer1.Panel2")
        Me.SplitContainer1.Panel2.BackgroundImage = Nothing
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvDetailView)
        Me.SplitContainer1.Panel2.Font = Nothing
        '
        'dgvBackupView
        '
        Me.dgvBackupView.AccessibleDescription = Nothing
        Me.dgvBackupView.AccessibleName = Nothing
        Me.dgvBackupView.AllowUserToAddRows = False
        Me.dgvBackupView.AllowUserToDeleteRows = False
        resources.ApplyResources(Me.dgvBackupView, "dgvBackupView")
        Me.dgvBackupView.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvBackupView.BackgroundImage = Nothing
        Me.dgvBackupView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBackupView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFileName, Me.colBackupDate, Me.colFSize, Me.colFolderName, Me.colCnt})
        Me.dgvBackupView.Font = Nothing
        Me.dgvBackupView.Name = "dgvBackupView"
        Me.dgvBackupView.ReadOnly = True
        Me.dgvBackupView.RowTemplate.Height = 21
        Me.dgvBackupView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'colFileName
        '
        Me.colFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colFileName.DataPropertyName = "FileName"
        Me.colFileName.FillWeight = 250.0!
        resources.ApplyResources(Me.colFileName, "colFileName")
        Me.colFileName.Name = "colFileName"
        Me.colFileName.ReadOnly = True
        '
        'colBackupDate
        '
        Me.colBackupDate.DataPropertyName = "tstp"
        resources.ApplyResources(Me.colBackupDate, "colBackupDate")
        Me.colBackupDate.Name = "colBackupDate"
        Me.colBackupDate.ReadOnly = True
        '
        'colFSize
        '
        Me.colFSize.DataPropertyName = "FileSize"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.colFSize.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.colFSize, "colFSize")
        Me.colFSize.Name = "colFSize"
        Me.colFSize.ReadOnly = True
        '
        'colFolderName
        '
        Me.colFolderName.DataPropertyName = "BackupFolder"
        resources.ApplyResources(Me.colFolderName, "colFolderName")
        Me.colFolderName.Name = "colFolderName"
        Me.colFolderName.ReadOnly = True
        '
        'colCnt
        '
        Me.colCnt.DataPropertyName = "cnt"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colCnt.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.colCnt, "colCnt")
        Me.colCnt.Name = "colCnt"
        Me.colCnt.ReadOnly = True
        '
        'TabFileGroup
        '
        Me.TabFileGroup.AccessibleDescription = Nothing
        Me.TabFileGroup.AccessibleName = Nothing
        resources.ApplyResources(Me.TabFileGroup, "TabFileGroup")
        Me.TabFileGroup.BackgroundImage = Nothing
        Me.TabFileGroup.Controls.Add(Me.TabPage1)
        Me.TabFileGroup.Controls.Add(Me.TabPage2)
        Me.TabFileGroup.Font = Nothing
        Me.TabFileGroup.Name = "TabFileGroup"
        Me.TabFileGroup.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.AccessibleDescription = Nothing
        Me.TabPage1.AccessibleName = Nothing
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.BackgroundImage = Nothing
        Me.TabPage1.Font = Nothing
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.AccessibleDescription = Nothing
        Me.TabPage2.AccessibleName = Nothing
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.BackgroundImage = Nothing
        Me.TabPage2.Font = Nothing
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvDetailView
        '
        Me.dgvDetailView.AccessibleDescription = Nothing
        Me.dgvDetailView.AccessibleName = Nothing
        Me.dgvDetailView.AllowUserToAddRows = False
        Me.dgvDetailView.AllowUserToDeleteRows = False
        resources.ApplyResources(Me.dgvDetailView, "dgvDetailView")
        Me.dgvDetailView.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvDetailView.BackgroundImage = Nothing
        Me.dgvDetailView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetailView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.dgvDetailView.Font = Nothing
        Me.dgvDetailView.Name = "dgvDetailView"
        Me.dgvDetailView.ReadOnly = True
        Me.dgvDetailView.RowTemplate.Height = 21
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AccessibleDescription = Nothing
        Me.FlowLayoutPanel1.AccessibleName = Nothing
        resources.ApplyResources(Me.FlowLayoutPanel1, "FlowLayoutPanel1")
        Me.FlowLayoutPanel1.BackgroundImage = Nothing
        Me.FlowLayoutPanel1.Controls.Add(Me.btnClose)
        Me.FlowLayoutPanel1.Font = Nothing
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        '
        'btnClose
        '
        Me.btnClose.AccessibleDescription = Nothing
        Me.btnClose.AccessibleName = Nothing
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.BackgroundImage = Nothing
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = Nothing
        Me.btnClose.Name = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AccessibleDescription = Nothing
        Me.StatusStrip1.AccessibleName = Nothing
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.BackgroundImage = Nothing
        Me.StatusStrip1.Font = Nothing
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statFileCount, Me.statFileName, Me.statDummy})
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'statFileCount
        '
        Me.statFileCount.AccessibleDescription = Nothing
        Me.statFileCount.AccessibleName = Nothing
        resources.ApplyResources(Me.statFileCount, "statFileCount")
        Me.statFileCount.BackgroundImage = Nothing
        Me.statFileCount.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.statFileCount.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.statFileCount.Name = "statFileCount"
        '
        'statFileName
        '
        Me.statFileName.AccessibleDescription = Nothing
        Me.statFileName.AccessibleName = Nothing
        resources.ApplyResources(Me.statFileName, "statFileName")
        Me.statFileName.BackgroundImage = Nothing
        Me.statFileName.Name = "statFileName"
        Me.statFileName.Spring = True
        '
        'statDummy
        '
        Me.statDummy.AccessibleDescription = Nothing
        Me.statDummy.AccessibleName = Nothing
        resources.ApplyResources(Me.statDummy, "statDummy")
        Me.statDummy.BackgroundImage = Nothing
        Me.statDummy.Name = "statDummy"
        '
        'Column5
        '
        resources.ApplyResources(Me.Column5, "Column5")
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "FileName"
        resources.ApplyResources(Me.Column1, "Column1")
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "tstp"
        resources.ApplyResources(Me.Column2, "Column2")
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "FileSize"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.Column3, "Column3")
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "BackupFolder"
        resources.ApplyResources(Me.Column4, "Column4")
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'frmBackupFiles
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.CancelButton = Me.btnClose
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = Nothing
        Me.Icon = Nothing
        Me.Name = "frmBackupFiles"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvBackupView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabFileGroup.ResumeLayout(False)
        CType(Me.dgvDetailView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents dgvBackupView As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statFileCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabFileGroup As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents statFileName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statDummy As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents colFileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBackupDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFolderName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCnt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvDetailView As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
