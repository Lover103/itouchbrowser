<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlayPanel))
        Me.txtMovieName = New System.Windows.Forms.TextBox
        Me.txtLyric = New System.Windows.Forms.TextBox
        Me.picArtistImage = New System.Windows.Forms.PictureBox
        Me.spcLeft = New System.Windows.Forms.SplitContainer
        Me.splBase = New System.Windows.Forms.SplitContainer
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.qtPlugin = New iPhoneBrowser.itouchBrowser.QtWrapper
        CType(Me.picArtistImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcLeft.Panel1.SuspendLayout()
        Me.spcLeft.Panel2.SuspendLayout()
        Me.spcLeft.SuspendLayout()
        Me.splBase.Panel1.SuspendLayout()
        Me.splBase.Panel2.SuspendLayout()
        Me.splBase.SuspendLayout()
        CType(Me.qtPlugin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtMovieName
        '
        Me.txtMovieName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMovieName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMovieName.Location = New System.Drawing.Point(0, 0)
        Me.txtMovieName.Multiline = True
        Me.txtMovieName.Name = "txtMovieName"
        Me.txtMovieName.ReadOnly = True
        Me.txtMovieName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMovieName.Size = New System.Drawing.Size(150, 110)
        Me.txtMovieName.TabIndex = 10
        '
        'txtLyric
        '
        Me.txtLyric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLyric.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtLyric.Location = New System.Drawing.Point(0, 26)
        Me.txtLyric.Multiline = True
        Me.txtLyric.Name = "txtLyric"
        Me.txtLyric.ReadOnly = True
        Me.txtLyric.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLyric.Size = New System.Drawing.Size(381, 204)
        Me.txtLyric.TabIndex = 12
        '
        'picArtistImage
        '
        Me.picArtistImage.BackColor = System.Drawing.SystemColors.Control
        Me.picArtistImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picArtistImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picArtistImage.Location = New System.Drawing.Point(0, 0)
        Me.picArtistImage.Name = "picArtistImage"
        Me.picArtistImage.Size = New System.Drawing.Size(150, 116)
        Me.picArtistImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picArtistImage.TabIndex = 13
        Me.picArtistImage.TabStop = False
        '
        'spcLeft
        '
        Me.spcLeft.BackColor = System.Drawing.SystemColors.ControlDark
        Me.spcLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcLeft.Location = New System.Drawing.Point(0, 0)
        Me.spcLeft.Name = "spcLeft"
        Me.spcLeft.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcLeft.Panel1
        '
        Me.spcLeft.Panel1.Controls.Add(Me.txtMovieName)
        '
        'spcLeft.Panel2
        '
        Me.spcLeft.Panel2.Controls.Add(Me.picArtistImage)
        Me.spcLeft.Size = New System.Drawing.Size(150, 230)
        Me.spcLeft.SplitterDistance = 110
        Me.spcLeft.TabIndex = 14
        '
        'splBase
        '
        Me.splBase.BackColor = System.Drawing.SystemColors.Control
        Me.splBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splBase.ForeColor = System.Drawing.SystemColors.ControlText
        Me.splBase.Location = New System.Drawing.Point(0, 0)
        Me.splBase.Name = "splBase"
        '
        'splBase.Panel1
        '
        Me.splBase.Panel1.Controls.Add(Me.spcLeft)
        '
        'splBase.Panel2
        '
        Me.splBase.Panel2.Controls.Add(Me.Splitter1)
        Me.splBase.Panel2.Controls.Add(Me.qtPlugin)
        Me.splBase.Panel2.Controls.Add(Me.txtLyric)
        Me.splBase.Size = New System.Drawing.Size(535, 230)
        Me.splBase.SplitterDistance = 150
        Me.splBase.TabIndex = 15
        '
        'Splitter1
        '
        Me.Splitter1.Cursor = System.Windows.Forms.Cursors.HSplit
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 22)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(381, 4)
        Me.Splitter1.TabIndex = 13
        Me.Splitter1.TabStop = False
        '
        'qtPlugin
        '
        Me.qtPlugin.Enabled = True
        Me.qtPlugin.EventEnabled = True
        Me.qtPlugin.Location = New System.Drawing.Point(0, 0)
        Me.qtPlugin.Name = "qtPlugin"
        Me.qtPlugin.OcxState = CType(resources.GetObject("qtPlugin.OcxState"), System.Windows.Forms.AxHost.State)
        Me.qtPlugin.Size = New System.Drawing.Size(381, 20)
        Me.qtPlugin.TabIndex = 11
        '
        'PlayPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.splBase)
        Me.Name = "PlayPanel"
        Me.Size = New System.Drawing.Size(535, 230)
        CType(Me.picArtistImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcLeft.Panel1.ResumeLayout(False)
        Me.spcLeft.Panel1.PerformLayout()
        Me.spcLeft.Panel2.ResumeLayout(False)
        Me.spcLeft.ResumeLayout(False)
        Me.splBase.Panel1.ResumeLayout(False)
        Me.splBase.Panel2.ResumeLayout(False)
        Me.splBase.Panel2.PerformLayout()
        Me.splBase.ResumeLayout(False)
        CType(Me.qtPlugin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected Friend WithEvents qtPlugin As iPhoneBrowser.itouchBrowser.QtWrapper
    Private WithEvents splBase As System.Windows.Forms.SplitContainer
    Private WithEvents txtMovieName As System.Windows.Forms.TextBox
    Private WithEvents picArtistImage As System.Windows.Forms.PictureBox
    Private WithEvents spcLeft As System.Windows.Forms.SplitContainer
    Private WithEvents Splitter1 As System.Windows.Forms.Splitter
    Private WithEvents txtLyric As System.Windows.Forms.TextBox

End Class
