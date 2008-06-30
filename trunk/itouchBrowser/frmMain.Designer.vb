<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        With My.Settings
            .ConfirmDeletions = ConfirmDeletionsToolStripMenuItem.Checked
            .PCToiPhonePNG = bConvertToiPhonePNG
            .iPhoneToPCPNG = bConvertToPNG
            .ShowPreviews = bShowPreview
            .IgnoreThumbsFile = bIgnoreThumbsFile
            .IgnoreDSStoreFile = bIgnoreDSStoreFile
            .FavNames = favNames
            .FavPaths = favPaths
            .ShowGroups = cmdShowGroups.Checked
        End With
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    '<System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.splMain = New System.Windows.Forms.SplitContainer
        Me.grpFolders = New System.Windows.Forms.GroupBox
        Me.trvFolders = New System.Windows.Forms.TreeView
        Me.imgFolders = New System.Windows.Forms.ImageList(Me.components)
        Me.splFiles = New System.Windows.Forms.SplitContainer
        Me.grpFiles = New System.Windows.Forms.GroupBox
        Me.lstFiles = New System.Windows.Forms.ListView
        Me.cohFilename = New System.Windows.Forms.ColumnHeader
        Me.cohSize = New System.Windows.Forms.ColumnHeader
        Me.cohFiletype = New System.Windows.Forms.ColumnHeader
        Me.menuRightClickFiles = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuRightSaveAs = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.menuRightBackupFile = New System.Windows.Forms.ToolStripMenuItem
        Me.menuRightRestoreFile = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemLoading = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdRenameFile = New System.Windows.Forms.ToolStripMenuItem
        Me.menuRightReplaceFile = New System.Windows.Forms.ToolStripMenuItem
        Me.menuRightDeleteFile = New System.Windows.Forms.ToolStripMenuItem
        Me.imgFilesLarge = New System.Windows.Forms.ImageList(Me.components)
        Me.imgFilesSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.grpDetails = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnPreview = New System.Windows.Forms.Button
        Me.chkPreviewEnabled = New System.Windows.Forms.CheckBox
        Me.picFileDetails = New System.Windows.Forms.PictureBox
        Me.txtFileDetails = New System.Windows.Forms.TextBox
        Me.WebBrws = New System.Windows.Forms.WebBrowser
        Me.qtPlugin = New AxQTOControlLib.AxQTControl
        Me.tlbStatusStrip = New System.Windows.Forms.StatusStrip
        Me.tlbStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.TSDDBtnCancel = New System.Windows.Forms.ToolStripDropDownButton
        Me.tlbProgress0 = New System.Windows.Forms.ToolStripProgressBar
        Me.tlbProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.toolStrip = New System.Windows.Forms.ToolStrip
        Me.ToolStripMenuItemFile = New System.Windows.Forms.ToolStripDropDownButton
        Me.ToolStripMenuItemCleanUp = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemViewBackups = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.menuSaveSummerboardTheme = New System.Windows.Forms.ToolStripMenuItem
        Me.AsSummerboardFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AsPXLPackageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.AsCustomizeFoldersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AsPXLPackageToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemExit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuView = New System.Windows.Forms.ToolStripDropDownButton
        Me.ToolStripMenuItemDetails = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemLargeIcons = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdSmallIcons = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdShowGroups = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGoTo = New System.Windows.Forms.ToolStripDropDownButton
        Me.toolStripGoTo1 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.toolStripGoTo3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuStdApps = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo20 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo4 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo6 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo13 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo14 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo8 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo7 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo5 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo9 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo10 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo12 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo15 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo11 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo16 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo17 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo18 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuThirdPartyApps = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.DockSwapDocksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EBooksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FrotzGamesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdGBAROMs = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.InstallerPackageSourcesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ISwitcherThemesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NESROMSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TTRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WeDictDictionariesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.CameraRollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo19 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFavorites = New System.Windows.Forms.ToolStripDropDownButton
        Me.AddToFavoritesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OrganizeFavoritesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton
        Me.ConfirmDeletionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IgnoreThumbsdbToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IgnoreDSStoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConvertPNGsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IPhoneToPCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PCToIPhoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ConvertBothToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.ShowPreviewsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PictureBackgroundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BlackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GrayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WhiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.fileSaveDialog = New System.Windows.Forms.SaveFileDialog
        Me.fileOpenDialog = New System.Windows.Forms.OpenFileDialog
        Me.menuRightClickFolders = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemNewFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.BackupFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemSaveFolderIn = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdRenameFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemDeleteFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.splMain.Panel1.SuspendLayout()
        Me.splMain.Panel2.SuspendLayout()
        Me.splMain.SuspendLayout()
        Me.grpFolders.SuspendLayout()
        Me.splFiles.Panel1.SuspendLayout()
        Me.splFiles.Panel2.SuspendLayout()
        Me.splFiles.SuspendLayout()
        Me.grpFiles.SuspendLayout()
        Me.menuRightClickFiles.SuspendLayout()
        Me.grpDetails.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.picFileDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.qtPlugin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbStatusStrip.SuspendLayout()
        Me.toolStrip.SuspendLayout()
        Me.menuRightClickFolders.SuspendLayout()
        Me.SuspendLayout()
        '
        'splMain
        '
        Me.splMain.AllowDrop = True
        resources.ApplyResources(Me.splMain, "splMain")
        Me.splMain.MinimumSize = New System.Drawing.Size(100, 92)
        Me.splMain.Name = "splMain"
        '
        'splMain.Panel1
        '
        Me.splMain.Panel1.Controls.Add(Me.grpFolders)
        resources.ApplyResources(Me.splMain.Panel1, "splMain.Panel1")
        '
        'splMain.Panel2
        '
        Me.splMain.Panel2.Controls.Add(Me.splFiles)
        resources.ApplyResources(Me.splMain.Panel2, "splMain.Panel2")
        '
        'grpFolders
        '
        Me.grpFolders.Controls.Add(Me.trvFolders)
        resources.ApplyResources(Me.grpFolders, "grpFolders")
        Me.grpFolders.Name = "grpFolders"
        Me.grpFolders.TabStop = False
        '
        'trvFolders
        '
        resources.ApplyResources(Me.trvFolders, "trvFolders")
        Me.trvFolders.ImageList = Me.imgFolders
        Me.trvFolders.Name = "trvFolders"
        Me.trvFolders.PathSeparator = "/"
        Me.trvFolders.ShowRootLines = False
        '
        'imgFolders
        '
        Me.imgFolders.ImageStream = CType(resources.GetObject("imgFolders.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgFolders.TransparentColor = System.Drawing.Color.Transparent
        Me.imgFolders.Images.SetKeyName(0, "Folder.ico")
        Me.imgFolders.Images.SetKeyName(1, "folderopen.ico")
        Me.imgFolders.Images.SetKeyName(2, "folder_closed.gif")
        Me.imgFolders.Images.SetKeyName(3, "folder_open.gif")
        '
        'splFiles
        '
        resources.ApplyResources(Me.splFiles, "splFiles")
        Me.splFiles.MinimumSize = New System.Drawing.Size(100, 92)
        Me.splFiles.Name = "splFiles"
        '
        'splFiles.Panel1
        '
        Me.splFiles.Panel1.Controls.Add(Me.grpFiles)
        '
        'splFiles.Panel2
        '
        Me.splFiles.Panel2.Controls.Add(Me.grpDetails)
        '
        'grpFiles
        '
        Me.grpFiles.Controls.Add(Me.lstFiles)
        resources.ApplyResources(Me.grpFiles, "grpFiles")
        Me.grpFiles.Name = "grpFiles"
        Me.grpFiles.TabStop = False
        '
        'lstFiles
        '
        Me.lstFiles.AllowColumnReorder = True
        Me.lstFiles.AllowDrop = True
        resources.ApplyResources(Me.lstFiles, "lstFiles")
        Me.lstFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cohFilename, Me.cohSize, Me.cohFiletype})
        Me.lstFiles.ContextMenuStrip = Me.menuRightClickFiles
        Me.lstFiles.LargeImageList = Me.imgFilesLarge
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.ShowGroups = False
        Me.lstFiles.SmallImageList = Me.imgFilesSmall
        Me.lstFiles.UseCompatibleStateImageBehavior = False
        Me.lstFiles.View = System.Windows.Forms.View.Details
        '
        'cohFilename
        '
        resources.ApplyResources(Me.cohFilename, "cohFilename")
        '
        'cohSize
        '
        resources.ApplyResources(Me.cohSize, "cohSize")
        '
        'cohFiletype
        '
        resources.ApplyResources(Me.cohFiletype, "cohFiletype")
        '
        'menuRightClickFiles
        '
        Me.menuRightClickFiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRightSaveAs, Me.ToolStripSeparator2, Me.menuRightBackupFile, Me.menuRightRestoreFile, Me.ToolStripSeparator1, Me.cmdRenameFile, Me.menuRightReplaceFile, Me.menuRightDeleteFile})
        Me.menuRightClickFiles.Name = "menuRightClickFiles"
        resources.ApplyResources(Me.menuRightClickFiles, "menuRightClickFiles")
        '
        'menuRightSaveAs
        '
        Me.menuRightSaveAs.Name = "menuRightSaveAs"
        resources.ApplyResources(Me.menuRightSaveAs, "menuRightSaveAs")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'menuRightBackupFile
        '
        Me.menuRightBackupFile.Name = "menuRightBackupFile"
        resources.ApplyResources(Me.menuRightBackupFile, "menuRightBackupFile")
        '
        'menuRightRestoreFile
        '
        Me.menuRightRestoreFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemLoading})
        resources.ApplyResources(Me.menuRightRestoreFile, "menuRightRestoreFile")
        Me.menuRightRestoreFile.Name = "menuRightRestoreFile"
        '
        'ToolStripMenuItemLoading
        '
        Me.ToolStripMenuItemLoading.Name = "ToolStripMenuItemLoading"
        resources.ApplyResources(Me.ToolStripMenuItemLoading, "ToolStripMenuItemLoading")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'cmdRenameFile
        '
        Me.cmdRenameFile.Name = "cmdRenameFile"
        resources.ApplyResources(Me.cmdRenameFile, "cmdRenameFile")
        '
        'menuRightReplaceFile
        '
        Me.menuRightReplaceFile.Name = "menuRightReplaceFile"
        resources.ApplyResources(Me.menuRightReplaceFile, "menuRightReplaceFile")
        '
        'menuRightDeleteFile
        '
        Me.menuRightDeleteFile.Name = "menuRightDeleteFile"
        resources.ApplyResources(Me.menuRightDeleteFile, "menuRightDeleteFile")
        '
        'imgFilesLarge
        '
        Me.imgFilesLarge.ImageStream = CType(resources.GetObject("imgFilesLarge.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgFilesLarge.TransparentColor = System.Drawing.Color.Transparent
        Me.imgFilesLarge.Images.SetKeyName(0, "help.ico")
        Me.imgFilesLarge.Images.SetKeyName(1, "cdmusic.ico")
        Me.imgFilesLarge.Images.SetKeyName(2, "Camcorder.ico")
        Me.imgFilesLarge.Images.SetKeyName(3, "document.ico")
        Me.imgFilesLarge.Images.SetKeyName(4, "camera.ico")
        Me.imgFilesLarge.Images.SetKeyName(5, "sound.ico")
        Me.imgFilesLarge.Images.SetKeyName(6, "dbs.ico")
        Me.imgFilesLarge.Images.SetKeyName(7, "mynetworkplaces.ico")
        '
        'imgFilesSmall
        '
        Me.imgFilesSmall.ImageStream = CType(resources.GetObject("imgFilesSmall.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgFilesSmall.TransparentColor = System.Drawing.Color.Transparent
        Me.imgFilesSmall.Images.SetKeyName(0, "help.ico")
        Me.imgFilesSmall.Images.SetKeyName(1, "cdmusic.ico")
        Me.imgFilesSmall.Images.SetKeyName(2, "Camcorder.ico")
        Me.imgFilesSmall.Images.SetKeyName(3, "document.ico")
        Me.imgFilesSmall.Images.SetKeyName(4, "camera.ico")
        Me.imgFilesSmall.Images.SetKeyName(5, "sound.ico")
        Me.imgFilesSmall.Images.SetKeyName(6, "dbs.ico")
        Me.imgFilesSmall.Images.SetKeyName(7, "mynetworkplaces.ico")
        '
        'grpDetails
        '
        Me.grpDetails.Controls.Add(Me.Panel1)
        Me.grpDetails.Controls.Add(Me.picFileDetails)
        Me.grpDetails.Controls.Add(Me.txtFileDetails)
        Me.grpDetails.Controls.Add(Me.WebBrws)
        Me.grpDetails.Controls.Add(Me.qtPlugin)
        resources.ApplyResources(Me.grpDetails, "grpDetails")
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.TabStop = False
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Controls.Add(Me.btnPreview)
        Me.Panel1.Controls.Add(Me.chkPreviewEnabled)
        Me.Panel1.Name = "Panel1"
        '
        'btnPreview
        '
        resources.ApplyResources(Me.btnPreview, "btnPreview")
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.TabStop = False
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'chkPreviewEnabled
        '
        resources.ApplyResources(Me.chkPreviewEnabled, "chkPreviewEnabled")
        Me.chkPreviewEnabled.Checked = Global.iPhoneBrowser.itouchBrowser.My.MySettings.Default.ShowPreviews
        Me.chkPreviewEnabled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPreviewEnabled.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iPhoneBrowser.itouchBrowser.My.MySettings.Default, "ShowPreviews", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkPreviewEnabled.Name = "chkPreviewEnabled"
        Me.chkPreviewEnabled.TabStop = False
        Me.chkPreviewEnabled.UseVisualStyleBackColor = True
        '
        'picFileDetails
        '
        resources.ApplyResources(Me.picFileDetails, "picFileDetails")
        Me.picFileDetails.BackColor = System.Drawing.SystemColors.Control
        Me.picFileDetails.Name = "picFileDetails"
        Me.picFileDetails.TabStop = False
        '
        'txtFileDetails
        '
        resources.ApplyResources(Me.txtFileDetails, "txtFileDetails")
        Me.txtFileDetails.Name = "txtFileDetails"
        Me.txtFileDetails.ReadOnly = True
        '
        'WebBrws
        '
        resources.ApplyResources(Me.WebBrws, "WebBrws")
        Me.WebBrws.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrws.Name = "WebBrws"
        '
        'qtPlugin
        '
        resources.ApplyResources(Me.qtPlugin, "qtPlugin")
        Me.qtPlugin.Name = "qtPlugin"
        Me.qtPlugin.OcxState = CType(resources.GetObject("qtPlugin.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'tlbStatusStrip
        '
        Me.tlbStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlbStatusLabel, Me.TSDDBtnCancel, Me.tlbProgress0, Me.tlbProgressBar})
        resources.ApplyResources(Me.tlbStatusStrip, "tlbStatusStrip")
        Me.tlbStatusStrip.Name = "tlbStatusStrip"
        Me.tlbStatusStrip.ShowItemToolTips = True
        '
        'tlbStatusLabel
        '
        resources.ApplyResources(Me.tlbStatusLabel, "tlbStatusLabel")
        Me.tlbStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tlbStatusLabel.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.warning
        Me.tlbStatusLabel.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.tlbStatusLabel.Name = "tlbStatusLabel"
        Me.tlbStatusLabel.Spring = True
        '
        'TSDDBtnCancel
        '
        Me.TSDDBtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        resources.ApplyResources(Me.TSDDBtnCancel, "TSDDBtnCancel")
        Me.TSDDBtnCancel.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.TSDDBtnCancel.Name = "TSDDBtnCancel"
        Me.TSDDBtnCancel.ShowDropDownArrow = False
        '
        'tlbProgress0
        '
        Me.tlbProgress0.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        resources.ApplyResources(Me.tlbProgress0, "tlbProgress0")
        Me.tlbProgress0.BackColor = System.Drawing.SystemColors.Desktop
        Me.tlbProgress0.Margin = New System.Windows.Forms.Padding(0, 4, 4, 4)
        Me.tlbProgress0.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.tlbProgress0.Name = "tlbProgress0"
        Me.tlbProgress0.Step = 1
        '
        'tlbProgressBar
        '
        Me.tlbProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        resources.ApplyResources(Me.tlbProgressBar, "tlbProgressBar")
        Me.tlbProgressBar.Margin = New System.Windows.Forms.Padding(0, 4, 10, 4)
        Me.tlbProgressBar.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.tlbProgressBar.MergeIndex = 2
        Me.tlbProgressBar.Name = "tlbProgressBar"
        Me.tlbProgressBar.Step = 1
        '
        'toolStrip
        '
        Me.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemFile, Me.mnuView, Me.mnuGoTo, Me.mnuFavorites, Me.ToolStripDropDownButton2, Me.ToolStripDropDownButton1})
        resources.ApplyResources(Me.toolStrip, "toolStrip")
        Me.toolStrip.Name = "toolStrip"
        '
        'ToolStripMenuItemFile
        '
        Me.ToolStripMenuItemFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCleanUp, Me.ToolStripMenuItemViewBackups, Me.ToolStripSeparator7, Me.menuSaveSummerboardTheme, Me.ToolStripMenuItem4, Me.ToolStripSeparator3, Me.ToolStripMenuItemExit})
        resources.ApplyResources(Me.ToolStripMenuItemFile, "ToolStripMenuItemFile")
        Me.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile"
        '
        'ToolStripMenuItemCleanUp
        '
        resources.ApplyResources(Me.ToolStripMenuItemCleanUp, "ToolStripMenuItemCleanUp")
        Me.ToolStripMenuItemCleanUp.Name = "ToolStripMenuItemCleanUp"
        '
        'ToolStripMenuItemViewBackups
        '
        Me.ToolStripMenuItemViewBackups.Name = "ToolStripMenuItemViewBackups"
        resources.ApplyResources(Me.ToolStripMenuItemViewBackups, "ToolStripMenuItemViewBackups")
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
        '
        'menuSaveSummerboardTheme
        '
        Me.menuSaveSummerboardTheme.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsSummerboardFolderToolStripMenuItem, Me.AsPXLPackageToolStripMenuItem})
        Me.menuSaveSummerboardTheme.Name = "menuSaveSummerboardTheme"
        resources.ApplyResources(Me.menuSaveSummerboardTheme, "menuSaveSummerboardTheme")
        '
        'AsSummerboardFolderToolStripMenuItem
        '
        Me.AsSummerboardFolderToolStripMenuItem.Name = "AsSummerboardFolderToolStripMenuItem"
        resources.ApplyResources(Me.AsSummerboardFolderToolStripMenuItem, "AsSummerboardFolderToolStripMenuItem")
        '
        'AsPXLPackageToolStripMenuItem
        '
        resources.ApplyResources(Me.AsPXLPackageToolStripMenuItem, "AsPXLPackageToolStripMenuItem")
        Me.AsPXLPackageToolStripMenuItem.Name = "AsPXLPackageToolStripMenuItem"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsCustomizeFoldersToolStripMenuItem, Me.AsPXLPackageToolStripMenuItem1})
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'AsCustomizeFoldersToolStripMenuItem
        '
        Me.AsCustomizeFoldersToolStripMenuItem.Name = "AsCustomizeFoldersToolStripMenuItem"
        resources.ApplyResources(Me.AsCustomizeFoldersToolStripMenuItem, "AsCustomizeFoldersToolStripMenuItem")
        '
        'AsPXLPackageToolStripMenuItem1
        '
        resources.ApplyResources(Me.AsPXLPackageToolStripMenuItem1, "AsPXLPackageToolStripMenuItem1")
        Me.AsPXLPackageToolStripMenuItem1.Name = "AsPXLPackageToolStripMenuItem1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'ToolStripMenuItemExit
        '
        Me.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit"
        resources.ApplyResources(Me.ToolStripMenuItemExit, "ToolStripMenuItemExit")
        '
        'mnuView
        '
        Me.mnuView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemDetails, Me.ToolStripMenuItemLargeIcons, Me.cmdSmallIcons, Me.ToolStripMenuItem8, Me.cmdShowGroups})
        resources.ApplyResources(Me.mnuView, "mnuView")
        Me.mnuView.Name = "mnuView"
        '
        'ToolStripMenuItemDetails
        '
        Me.ToolStripMenuItemDetails.Checked = True
        Me.ToolStripMenuItemDetails.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItemDetails.Name = "ToolStripMenuItemDetails"
        resources.ApplyResources(Me.ToolStripMenuItemDetails, "ToolStripMenuItemDetails")
        '
        'ToolStripMenuItemLargeIcons
        '
        Me.ToolStripMenuItemLargeIcons.Name = "ToolStripMenuItemLargeIcons"
        resources.ApplyResources(Me.ToolStripMenuItemLargeIcons, "ToolStripMenuItemLargeIcons")
        '
        'cmdSmallIcons
        '
        Me.cmdSmallIcons.Name = "cmdSmallIcons"
        resources.ApplyResources(Me.cmdSmallIcons, "cmdSmallIcons")
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        resources.ApplyResources(Me.ToolStripMenuItem8, "ToolStripMenuItem8")
        '
        'cmdShowGroups
        '
        Me.cmdShowGroups.Checked = Global.iPhoneBrowser.itouchBrowser.My.MySettings.Default.ShowGroups
        Me.cmdShowGroups.CheckOnClick = True
        Me.cmdShowGroups.Name = "cmdShowGroups"
        resources.ApplyResources(Me.cmdShowGroups, "cmdShowGroups")
        '
        'mnuGoTo
        '
        Me.mnuGoTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuGoTo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripGoTo1, Me.toolStripGoTo2, Me.ToolStripSeparator5, Me.toolStripGoTo3, Me.ToolStripMenuItem2, Me.ToolStripSeparator4, Me.mnuStdApps, Me.mnuThirdPartyApps, Me.ToolStripSeparator6, Me.CameraRollToolStripMenuItem, Me.toolStripGoTo19})
        resources.ApplyResources(Me.mnuGoTo, "mnuGoTo")
        Me.mnuGoTo.Name = "mnuGoTo"
        Me.mnuGoTo.Tag = "ar"
        '
        'toolStripGoTo1
        '
        Me.toolStripGoTo1.Name = "toolStripGoTo1"
        resources.ApplyResources(Me.toolStripGoTo1, "toolStripGoTo1")
        Me.toolStripGoTo1.Tag = "/Library/Ringtones"
        '
        'toolStripGoTo2
        '
        Me.toolStripGoTo2.Name = "toolStripGoTo2"
        resources.ApplyResources(Me.toolStripGoTo2, "toolStripGoTo2")
        Me.toolStripGoTo2.Tag = "/System/Library/Audio/UISounds"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        '
        'toolStripGoTo3
        '
        Me.toolStripGoTo3.Name = "toolStripGoTo3"
        resources.ApplyResources(Me.toolStripGoTo3, "toolStripGoTo3")
        Me.toolStripGoTo3.Tag = "/System/Library/CoreServices/SpringBoard.app"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        Me.ToolStripMenuItem2.Tag = "/var/root/Library/Summerboard/Themes"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'mnuStdApps
        '
        Me.mnuStdApps.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripGoTo20, Me.toolStripGoTo4, Me.toolStripGoTo6, Me.toolStripGoTo13, Me.toolStripGoTo14, Me.toolStripGoTo8, Me.toolStripGoTo7, Me.toolStripGoTo5, Me.toolStripGoTo9, Me.toolStripGoTo10, Me.toolStripGoTo12, Me.toolStripGoTo15, Me.toolStripGoTo11, Me.toolStripGoTo16, Me.toolStripGoTo17, Me.toolStripGoTo18})
        Me.mnuStdApps.Name = "mnuStdApps"
        resources.ApplyResources(Me.mnuStdApps, "mnuStdApps")
        '
        'toolStripGoTo20
        '
        Me.toolStripGoTo20.Name = "toolStripGoTo20"
        resources.ApplyResources(Me.toolStripGoTo20, "toolStripGoTo20")
        Me.toolStripGoTo20.Tag = "/var/mobile/Media/iTunes_Control/Music"
        '
        'toolStripGoTo4
        '
        Me.toolStripGoTo4.Name = "toolStripGoTo4"
        resources.ApplyResources(Me.toolStripGoTo4, "toolStripGoTo4")
        Me.toolStripGoTo4.Tag = "/Applications/Calculator.app"
        '
        'toolStripGoTo6
        '
        Me.toolStripGoTo6.Name = "toolStripGoTo6"
        resources.ApplyResources(Me.toolStripGoTo6, "toolStripGoTo6")
        Me.toolStripGoTo6.Tag = "/Applications/MobileCal.app"
        '
        'toolStripGoTo13
        '
        Me.toolStripGoTo13.Name = "toolStripGoTo13"
        resources.ApplyResources(Me.toolStripGoTo13, "toolStripGoTo13")
        Me.toolStripGoTo13.Tag = "/Applications/MobileSlideShow.app"
        '
        'toolStripGoTo14
        '
        Me.toolStripGoTo14.Name = "toolStripGoTo14"
        resources.ApplyResources(Me.toolStripGoTo14, "toolStripGoTo14")
        Me.toolStripGoTo14.Tag = "/Applications/MobileTimer.app"
        '
        'toolStripGoTo8
        '
        Me.toolStripGoTo8.Name = "toolStripGoTo8"
        resources.ApplyResources(Me.toolStripGoTo8, "toolStripGoTo8")
        Me.toolStripGoTo8.Tag = "/Applications/MobileMusicPlayer.app"
        '
        'toolStripGoTo7
        '
        Me.toolStripGoTo7.Name = "toolStripGoTo7"
        resources.ApplyResources(Me.toolStripGoTo7, "toolStripGoTo7")
        Me.toolStripGoTo7.Tag = "/Applications/MobileMail.app"
        '
        'toolStripGoTo5
        '
        Me.toolStripGoTo5.Name = "toolStripGoTo5"
        resources.ApplyResources(Me.toolStripGoTo5, "toolStripGoTo5")
        Me.toolStripGoTo5.Tag = "/Applications/Maps.app"
        '
        'toolStripGoTo9
        '
        Me.toolStripGoTo9.Name = "toolStripGoTo9"
        resources.ApplyResources(Me.toolStripGoTo9, "toolStripGoTo9")
        Me.toolStripGoTo9.Tag = "/Applications/MobileNotes.app"
        '
        'toolStripGoTo10
        '
        Me.toolStripGoTo10.Name = "toolStripGoTo10"
        resources.ApplyResources(Me.toolStripGoTo10, "toolStripGoTo10")
        Me.toolStripGoTo10.Tag = "/Applications/MobilePhone.app"
        '
        'toolStripGoTo12
        '
        Me.toolStripGoTo12.Name = "toolStripGoTo12"
        resources.ApplyResources(Me.toolStripGoTo12, "toolStripGoTo12")
        Me.toolStripGoTo12.Tag = "/Applications/MobileSafari.app"
        '
        'toolStripGoTo15
        '
        Me.toolStripGoTo15.Name = "toolStripGoTo15"
        resources.ApplyResources(Me.toolStripGoTo15, "toolStripGoTo15")
        Me.toolStripGoTo15.Tag = "/Applications/Preferences.app"
        '
        'toolStripGoTo11
        '
        Me.toolStripGoTo11.Name = "toolStripGoTo11"
        resources.ApplyResources(Me.toolStripGoTo11, "toolStripGoTo11")
        Me.toolStripGoTo11.Tag = "/Applications/MobileSMS.app"
        '
        'toolStripGoTo16
        '
        Me.toolStripGoTo16.Name = "toolStripGoTo16"
        resources.ApplyResources(Me.toolStripGoTo16, "toolStripGoTo16")
        Me.toolStripGoTo16.Tag = "/Applications/Stocks.app"
        '
        'toolStripGoTo17
        '
        Me.toolStripGoTo17.Name = "toolStripGoTo17"
        resources.ApplyResources(Me.toolStripGoTo17, "toolStripGoTo17")
        Me.toolStripGoTo17.Tag = "/Applications/Weather.app"
        '
        'toolStripGoTo18
        '
        Me.toolStripGoTo18.Name = "toolStripGoTo18"
        resources.ApplyResources(Me.toolStripGoTo18, "toolStripGoTo18")
        Me.toolStripGoTo18.Tag = "/Applications/YouTube.app"
        '
        'mnuThirdPartyApps
        '
        Me.mnuThirdPartyApps.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.DockSwapDocksToolStripMenuItem, Me.EBooksToolStripMenuItem, Me.FrotzGamesToolStripMenuItem, Me.cmdGBAROMs, Me.ToolStripMenuItem6, Me.InstallerPackageSourcesToolStripMenuItem, Me.ISwitcherThemesToolStripMenuItem, Me.NESROMSToolStripMenuItem, Me.TTRToolStripMenuItem, Me.WeDictDictionariesToolStripMenuItem})
        Me.mnuThirdPartyApps.Name = "mnuThirdPartyApps"
        resources.ApplyResources(Me.mnuThirdPartyApps, "mnuThirdPartyApps")
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        resources.ApplyResources(Me.ToolStripMenuItem5, "ToolStripMenuItem5")
        Me.ToolStripMenuItem5.Tag = "/var/root/Library/Customize"
        '
        'DockSwapDocksToolStripMenuItem
        '
        Me.DockSwapDocksToolStripMenuItem.Name = "DockSwapDocksToolStripMenuItem"
        resources.ApplyResources(Me.DockSwapDocksToolStripMenuItem, "DockSwapDocksToolStripMenuItem")
        Me.DockSwapDocksToolStripMenuItem.Tag = "/var/root/Library/DockSwap"
        '
        'EBooksToolStripMenuItem
        '
        Me.EBooksToolStripMenuItem.Name = "EBooksToolStripMenuItem"
        resources.ApplyResources(Me.EBooksToolStripMenuItem, "EBooksToolStripMenuItem")
        Me.EBooksToolStripMenuItem.Tag = "/var/root/Media/EBooks"
        '
        'FrotzGamesToolStripMenuItem
        '
        Me.FrotzGamesToolStripMenuItem.Name = "FrotzGamesToolStripMenuItem"
        resources.ApplyResources(Me.FrotzGamesToolStripMenuItem, "FrotzGamesToolStripMenuItem")
        Me.FrotzGamesToolStripMenuItem.Tag = "/var/root/Media/Frotz/Games"
        '
        'cmdGBAROMs
        '
        Me.cmdGBAROMs.Name = "cmdGBAROMs"
        resources.ApplyResources(Me.cmdGBAROMs, "cmdGBAROMs")
        Me.cmdGBAROMs.Tag = "/var/root/Media/ROMs/GBA"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        resources.ApplyResources(Me.ToolStripMenuItem6, "ToolStripMenuItem6")
        Me.ToolStripMenuItem6.Tag = "/var/root/Library/iFlashCards"
        '
        'InstallerPackageSourcesToolStripMenuItem
        '
        Me.InstallerPackageSourcesToolStripMenuItem.Name = "InstallerPackageSourcesToolStripMenuItem"
        resources.ApplyResources(Me.InstallerPackageSourcesToolStripMenuItem, "InstallerPackageSourcesToolStripMenuItem")
        Me.InstallerPackageSourcesToolStripMenuItem.Tag = "/var/root/Library/Installer"
        '
        'ISwitcherThemesToolStripMenuItem
        '
        Me.ISwitcherThemesToolStripMenuItem.Name = "ISwitcherThemesToolStripMenuItem"
        resources.ApplyResources(Me.ISwitcherThemesToolStripMenuItem, "ISwitcherThemesToolStripMenuItem")
        Me.ISwitcherThemesToolStripMenuItem.Tag = "/var/root/Media/Themes"
        '
        'NESROMSToolStripMenuItem
        '
        Me.NESROMSToolStripMenuItem.Name = "NESROMSToolStripMenuItem"
        resources.ApplyResources(Me.NESROMSToolStripMenuItem, "NESROMSToolStripMenuItem")
        Me.NESROMSToolStripMenuItem.Tag = "/var/root/Media/ROMs/NES"
        '
        'TTRToolStripMenuItem
        '
        Me.TTRToolStripMenuItem.Name = "TTRToolStripMenuItem"
        resources.ApplyResources(Me.TTRToolStripMenuItem, "TTRToolStripMenuItem")
        Me.TTRToolStripMenuItem.Tag = "/var/root/Media/TTR"
        '
        'WeDictDictionariesToolStripMenuItem
        '
        Me.WeDictDictionariesToolStripMenuItem.Name = "WeDictDictionariesToolStripMenuItem"
        resources.ApplyResources(Me.WeDictDictionariesToolStripMenuItem, "WeDictDictionariesToolStripMenuItem")
        Me.WeDictDictionariesToolStripMenuItem.Tag = "/var/root/Libary/weDict"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        '
        'CameraRollToolStripMenuItem
        '
        Me.CameraRollToolStripMenuItem.Name = "CameraRollToolStripMenuItem"
        resources.ApplyResources(Me.CameraRollToolStripMenuItem, "CameraRollToolStripMenuItem")
        Me.CameraRollToolStripMenuItem.Tag = "/var/root/Media/DCIM"
        '
        'toolStripGoTo19
        '
        Me.toolStripGoTo19.Name = "toolStripGoTo19"
        resources.ApplyResources(Me.toolStripGoTo19, "toolStripGoTo19")
        Me.toolStripGoTo19.Tag = "/System/Library/Fonts"
        '
        'mnuFavorites
        '
        Me.mnuFavorites.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuFavorites.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToFavoritesToolStripMenuItem, Me.OrganizeFavoritesToolStripMenuItem, Me.ToolStripMenuItem7})
        resources.ApplyResources(Me.mnuFavorites, "mnuFavorites")
        Me.mnuFavorites.Name = "mnuFavorites"
        '
        'AddToFavoritesToolStripMenuItem
        '
        Me.AddToFavoritesToolStripMenuItem.Name = "AddToFavoritesToolStripMenuItem"
        resources.ApplyResources(Me.AddToFavoritesToolStripMenuItem, "AddToFavoritesToolStripMenuItem")
        '
        'OrganizeFavoritesToolStripMenuItem
        '
        Me.OrganizeFavoritesToolStripMenuItem.Name = "OrganizeFavoritesToolStripMenuItem"
        resources.ApplyResources(Me.OrganizeFavoritesToolStripMenuItem, "OrganizeFavoritesToolStripMenuItem")
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        resources.ApplyResources(Me.ToolStripMenuItem7, "ToolStripMenuItem7")
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfirmDeletionsToolStripMenuItem, Me.IgnoreThumbsdbToolStripMenuItem, Me.IgnoreDSStoreToolStripMenuItem, Me.ConvertPNGsToolStripMenuItem, Me.ToolStripSeparator8, Me.ShowPreviewsToolStripMenuItem, Me.PictureBackgroundToolStripMenuItem})
        resources.ApplyResources(Me.ToolStripDropDownButton2, "ToolStripDropDownButton2")
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        '
        'ConfirmDeletionsToolStripMenuItem
        '
        Me.ConfirmDeletionsToolStripMenuItem.Checked = True
        Me.ConfirmDeletionsToolStripMenuItem.CheckOnClick = True
        Me.ConfirmDeletionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ConfirmDeletionsToolStripMenuItem.Name = "ConfirmDeletionsToolStripMenuItem"
        resources.ApplyResources(Me.ConfirmDeletionsToolStripMenuItem, "ConfirmDeletionsToolStripMenuItem")
        '
        'IgnoreThumbsdbToolStripMenuItem
        '
        Me.IgnoreThumbsdbToolStripMenuItem.Checked = True
        Me.IgnoreThumbsdbToolStripMenuItem.CheckOnClick = True
        Me.IgnoreThumbsdbToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IgnoreThumbsdbToolStripMenuItem.Name = "IgnoreThumbsdbToolStripMenuItem"
        resources.ApplyResources(Me.IgnoreThumbsdbToolStripMenuItem, "IgnoreThumbsdbToolStripMenuItem")
        '
        'IgnoreDSStoreToolStripMenuItem
        '
        Me.IgnoreDSStoreToolStripMenuItem.Checked = True
        Me.IgnoreDSStoreToolStripMenuItem.CheckOnClick = True
        Me.IgnoreDSStoreToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IgnoreDSStoreToolStripMenuItem.Name = "IgnoreDSStoreToolStripMenuItem"
        resources.ApplyResources(Me.IgnoreDSStoreToolStripMenuItem, "IgnoreDSStoreToolStripMenuItem")
        '
        'ConvertPNGsToolStripMenuItem
        '
        Me.ConvertPNGsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IPhoneToPCToolStripMenuItem, Me.PCToIPhoneToolStripMenuItem, Me.ConvertBothToolStripMenuItem})
        Me.ConvertPNGsToolStripMenuItem.Name = "ConvertPNGsToolStripMenuItem"
        resources.ApplyResources(Me.ConvertPNGsToolStripMenuItem, "ConvertPNGsToolStripMenuItem")
        '
        'IPhoneToPCToolStripMenuItem
        '
        Me.IPhoneToPCToolStripMenuItem.Checked = True
        Me.IPhoneToPCToolStripMenuItem.CheckOnClick = True
        Me.IPhoneToPCToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IPhoneToPCToolStripMenuItem.Name = "IPhoneToPCToolStripMenuItem"
        resources.ApplyResources(Me.IPhoneToPCToolStripMenuItem, "IPhoneToPCToolStripMenuItem")
        '
        'PCToIPhoneToolStripMenuItem
        '
        Me.PCToIPhoneToolStripMenuItem.CheckOnClick = True
        resources.ApplyResources(Me.PCToIPhoneToolStripMenuItem, "PCToIPhoneToolStripMenuItem")
        Me.PCToIPhoneToolStripMenuItem.Name = "PCToIPhoneToolStripMenuItem"
        '
        'ConvertBothToolStripMenuItem
        '
        resources.ApplyResources(Me.ConvertBothToolStripMenuItem, "ConvertBothToolStripMenuItem")
        Me.ConvertBothToolStripMenuItem.Name = "ConvertBothToolStripMenuItem"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        resources.ApplyResources(Me.ToolStripSeparator8, "ToolStripSeparator8")
        '
        'ShowPreviewsToolStripMenuItem
        '
        Me.ShowPreviewsToolStripMenuItem.Checked = True
        Me.ShowPreviewsToolStripMenuItem.CheckOnClick = True
        Me.ShowPreviewsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowPreviewsToolStripMenuItem.Name = "ShowPreviewsToolStripMenuItem"
        resources.ApplyResources(Me.ShowPreviewsToolStripMenuItem, "ShowPreviewsToolStripMenuItem")
        '
        'PictureBackgroundToolStripMenuItem
        '
        Me.PictureBackgroundToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlackToolStripMenuItem, Me.GrayToolStripMenuItem, Me.WhiteToolStripMenuItem})
        Me.PictureBackgroundToolStripMenuItem.Name = "PictureBackgroundToolStripMenuItem"
        resources.ApplyResources(Me.PictureBackgroundToolStripMenuItem, "PictureBackgroundToolStripMenuItem")
        '
        'BlackToolStripMenuItem
        '
        Me.BlackToolStripMenuItem.CheckOnClick = True
        Me.BlackToolStripMenuItem.Name = "BlackToolStripMenuItem"
        resources.ApplyResources(Me.BlackToolStripMenuItem, "BlackToolStripMenuItem")
        '
        'GrayToolStripMenuItem
        '
        Me.GrayToolStripMenuItem.CheckOnClick = True
        Me.GrayToolStripMenuItem.Name = "GrayToolStripMenuItem"
        resources.ApplyResources(Me.GrayToolStripMenuItem, "GrayToolStripMenuItem")
        '
        'WhiteToolStripMenuItem
        '
        Me.WhiteToolStripMenuItem.CheckOnClick = True
        Me.WhiteToolStripMenuItem.Name = "WhiteToolStripMenuItem"
        resources.ApplyResources(Me.WhiteToolStripMenuItem, "WhiteToolStripMenuItem")
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        resources.ApplyResources(Me.ToolStripDropDownButton1, "ToolStripDropDownButton1")
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        '
        'fileSaveDialog
        '
        Me.fileSaveDialog.AddExtension = False
        '
        'menuRightClickFolders
        '
        Me.menuRightClickFolders.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemNewFolder, Me.ToolStripSeparator9, Me.BackupFolderToolStripMenuItem, Me.ToolStripMenuItemSaveFolderIn, Me.cmdRenameFolder, Me.ToolStripSeparator10, Me.ToolStripMenuItemDeleteFolder})
        Me.menuRightClickFolders.Name = "menuRightClickFolders"
        resources.ApplyResources(Me.menuRightClickFolders, "menuRightClickFolders")
        '
        'ToolStripMenuItemNewFolder
        '
        Me.ToolStripMenuItemNewFolder.Name = "ToolStripMenuItemNewFolder"
        resources.ApplyResources(Me.ToolStripMenuItemNewFolder, "ToolStripMenuItemNewFolder")
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        resources.ApplyResources(Me.ToolStripSeparator9, "ToolStripSeparator9")
        '
        'BackupFolderToolStripMenuItem
        '
        Me.BackupFolderToolStripMenuItem.Name = "BackupFolderToolStripMenuItem"
        resources.ApplyResources(Me.BackupFolderToolStripMenuItem, "BackupFolderToolStripMenuItem")
        '
        'ToolStripMenuItemSaveFolderIn
        '
        Me.ToolStripMenuItemSaveFolderIn.Name = "ToolStripMenuItemSaveFolderIn"
        resources.ApplyResources(Me.ToolStripMenuItemSaveFolderIn, "ToolStripMenuItemSaveFolderIn")
        '
        'cmdRenameFolder
        '
        Me.cmdRenameFolder.Name = "cmdRenameFolder"
        resources.ApplyResources(Me.cmdRenameFolder, "cmdRenameFolder")
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        resources.ApplyResources(Me.ToolStripSeparator10, "ToolStripSeparator10")
        '
        'ToolStripMenuItemDeleteFolder
        '
        Me.ToolStripMenuItemDeleteFolder.Name = "ToolStripMenuItemDeleteFolder"
        resources.ApplyResources(Me.ToolStripMenuItemDeleteFolder, "ToolStripMenuItemDeleteFolder")
        '
        'folderBrowserDialog
        '
        resources.ApplyResources(Me.folderBrowserDialog, "folderBrowserDialog")
        Me.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'Timer1
        '
        Me.Timer1.Interval = 350
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.splMain)
        Me.Controls.Add(Me.toolStrip)
        Me.Controls.Add(Me.tlbStatusStrip)
        Me.Name = "frmMain"
        Me.splMain.Panel1.ResumeLayout(False)
        Me.splMain.Panel2.ResumeLayout(False)
        Me.splMain.ResumeLayout(False)
        Me.grpFolders.ResumeLayout(False)
        Me.splFiles.Panel1.ResumeLayout(False)
        Me.splFiles.Panel2.ResumeLayout(False)
        Me.splFiles.ResumeLayout(False)
        Me.grpFiles.ResumeLayout(False)
        Me.menuRightClickFiles.ResumeLayout(False)
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picFileDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.qtPlugin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbStatusStrip.ResumeLayout(False)
        Me.tlbStatusStrip.PerformLayout()
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        Me.menuRightClickFolders.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlbStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents tlbStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlbProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents imgFolders As System.Windows.Forms.ImageList
    Friend WithEvents toolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripMenuItemFile As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItemExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItemDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemLargeIcons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRightClickFiles As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuRightSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRightBackupFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRightRestoreFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fileSaveDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuRightReplaceFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fileOpenDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents menuRightDeleteFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemCleanUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemLoading As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemViewBackups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents splMain As System.Windows.Forms.SplitContainer
    Friend WithEvents grpFolders As System.Windows.Forms.GroupBox
    Friend WithEvents trvFolders As System.Windows.Forms.TreeView
    Friend WithEvents splFiles As System.Windows.Forms.SplitContainer
    Friend WithEvents grpFiles As System.Windows.Forms.GroupBox
    Friend WithEvents lstFiles As System.Windows.Forms.ListView
    Friend WithEvents cohFilename As System.Windows.Forms.ColumnHeader
    Friend WithEvents cohSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents cohFiletype As System.Windows.Forms.ColumnHeader
    Friend WithEvents grpDetails As System.Windows.Forms.GroupBox
    Friend WithEvents qtPlugin As AxQTOControlLib.AxQTControl
    Friend WithEvents txtFileDetails As System.Windows.Forms.TextBox
    Friend WithEvents mnuGoTo As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents toolStripGoTo1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripGoTo19 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRightClickFolders As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemNewFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemDeleteFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStdApps As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo15 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo16 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo17 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo18 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuThirdPartyApps As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DockSwapDocksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EBooksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FrotzGamesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ISwitcherThemesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NESROMSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TTRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InstallerPackageSourcesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfirmDeletionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WeDictDictionariesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConvertPNGsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents folderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents PictureBackgroundToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WhiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuSaveSummerboardTheme As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsSummerboardFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsPXLPackageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsCustomizeFoldersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsPXLPackageToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IPhoneToPCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PCToIPhoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConvertBothToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowPreviewsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSaveFolderIn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BackupFolderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents IgnoreThumbsdbToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IgnoreDSStoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdRenameFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdRenameFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFavorites As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents AddToFavoritesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrganizeFavoritesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents chkPreviewEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdSmallIcons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdShowGroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdGBAROMs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CameraRollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlbProgress0 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents picFileDetails As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TSDDBtnCancel As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents toolStripGoTo20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebBrws As System.Windows.Forms.WebBrowser
    Friend WithEvents imgFilesLarge As System.Windows.Forms.ImageList
    Friend WithEvents imgFilesSmall As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton

End Class
