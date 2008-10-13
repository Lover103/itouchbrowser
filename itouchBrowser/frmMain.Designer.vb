<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    '<System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        With My.Settings
            .ConfirmDeletions = tsmConfirmDeletions.Checked
            .PCToiPhonePNG = Config.bConvertToiPhonePNG
            .iPhoneToPCPNG = Config.bConvertToPNG
            .ShowPreviews = Config.bShowPreview
            .IgnoreThumbsFile = Config.bIgnoreThumbsFile
            .IgnoreDSStoreFile = Config.bIgnoreDSStoreFile
            .IgnoreCacheFile = Config.bIgnoreCacheFile
            .ShowSongTitle = Config.bShowSongTitle
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
        Me.picDelete = New System.Windows.Forms.PictureBox
        Me.picBusy = New System.Windows.Forms.PictureBox
        Me.lstFiles = New System.Windows.Forms.ListView
        Me.cohFilename = New System.Windows.Forms.ColumnHeader
        Me.cohSize = New System.Windows.Forms.ColumnHeader
        Me.cohAttribute = New System.Windows.Forms.ColumnHeader
        Me.cohFiletype = New System.Windows.Forms.ColumnHeader
        Me.menuRightClickFiles = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuRightSaveAs = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.menuRightBackupFile = New System.Windows.Forms.ToolStripMenuItem
        Me.menuRightRestoreFile = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemLoading = New System.Windows.Forms.ToolStripMenuItem
        Me.menuRightDeleteBackupedFile = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdRenameFile = New System.Windows.Forms.ToolStripMenuItem
        Me.menuRightReplaceFile = New System.Windows.Forms.ToolStripMenuItem
        Me.menuRightDeleteFile = New System.Windows.Forms.ToolStripMenuItem
        Me.imgFilesLarge = New System.Windows.Forms.ImageList(Me.components)
        Me.imgFilesSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.grpDetails = New System.Windows.Forms.GroupBox
        Me.pnlQt = New System.Windows.Forms.Panel
        Me.menuRightClickQt = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmQtFullscreen = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmQtExportDialog = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmQtMovieInfo = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmQuickTimeInfo = New System.Windows.Forms.ToolStripMenuItem
        Me.lblMovieName = New System.Windows.Forms.Label
        Me.chkZoom = New System.Windows.Forms.CheckBox
        Me.chkPreviewEnabled = New System.Windows.Forms.CheckBox
        Me.btnPreview = New System.Windows.Forms.Button
        Me.txtFileDetails = New System.Windows.Forms.TextBox
        Me.WebBrws = New System.Windows.Forms.WebBrowser
        Me.picFileDetails = New System.Windows.Forms.PictureBox
        Me.tlbStatusStrip = New System.Windows.Forms.StatusStrip
        Me.tlbStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.BtnCancel = New System.Windows.Forms.ToolStripDropDownButton
        Me.tlbProgress0 = New System.Windows.Forms.ToolStripProgressBar
        Me.tlbProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.toolStrip = New System.Windows.Forms.ToolStrip
        Me.tsmFile = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmCleanUp = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmFileList = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmRestructureDB = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmCleanUpBackupFiles = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemViewBackups = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.menuSaveSummerboardTheme = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmAsSummerboardFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmAsPXLPackage = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmAsCustomizeFolders = New System.Windows.Forms.ToolStripMenuItem
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
        Me.tsmCustomizeFiles = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDockSwapDocks = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmEBooks = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmFrotzGames = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmGBAROMs = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmIFlashCards = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmInstallerPackageSources = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmISwitcherThemes = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmNESROMS = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmTTR = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmWeDictDictionaries = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmCameraRoll = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo19 = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuFavorites = New System.Windows.Forms.ToolStripDropDownButton
        Me.AddToFavoritesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OrganizeFavoritesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmConfirmDeletions = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmIgnoreThumbsdb = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmIgnoreDSStore = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmIgnoreCacheFile = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmBackupControl = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmConvertPNGs = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmIPhoneToPC = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmPCToIPhone = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmConvertBoth = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmDisplaySongTitle = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmShowPreviews = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmPictureBackground = New System.Windows.Forms.ToolStripMenuItem
        Me.BlackToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GrayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WhiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmBackupDirectory = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmHomePage = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.tslAddress = New System.Windows.Forms.ToolStripLabel
        Me.tstAddress = New System.Windows.Forms.ToolStripTextBox
        Me.tsbAddress = New System.Windows.Forms.ToolStripButton
        Me.fileSaveDialog = New System.Windows.Forms.SaveFileDialog
        Me.fileOpenDialog = New System.Windows.Forms.OpenFileDialog
        Me.menuRightClickFolders = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemNewFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmBackupFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSaveFolderIn = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdRenameFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemDeleteFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.qtPlugin = New iPhoneBrowser.itouchBrowser.QtWrapper
        Me.qtBuff = New iPhoneBrowser.itouchBrowser.QtWrapper
        Me.splMain.Panel1.SuspendLayout()
        Me.splMain.Panel2.SuspendLayout()
        Me.splMain.SuspendLayout()
        Me.grpFolders.SuspendLayout()
        Me.splFiles.Panel1.SuspendLayout()
        Me.splFiles.Panel2.SuspendLayout()
        Me.splFiles.SuspendLayout()
        Me.grpFiles.SuspendLayout()
        CType(Me.picDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBusy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuRightClickFiles.SuspendLayout()
        Me.grpDetails.SuspendLayout()
        Me.pnlQt.SuspendLayout()
        Me.menuRightClickQt.SuspendLayout()
        CType(Me.picFileDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlbStatusStrip.SuspendLayout()
        Me.toolStrip.SuspendLayout()
        Me.menuRightClickFolders.SuspendLayout()
        CType(Me.qtPlugin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.qtBuff, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.grpFiles.Controls.Add(Me.picDelete)
        Me.grpFiles.Controls.Add(Me.picBusy)
        Me.grpFiles.Controls.Add(Me.lstFiles)
        resources.ApplyResources(Me.grpFiles, "grpFiles")
        Me.grpFiles.Name = "grpFiles"
        Me.grpFiles.TabStop = False
        '
        'picDelete
        '
        Me.picDelete.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.picDelete, "picDelete")
        Me.picDelete.Name = "picDelete"
        Me.picDelete.TabStop = False
        '
        'picBusy
        '
        Me.picBusy.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.picBusy, "picBusy")
        Me.picBusy.Name = "picBusy"
        Me.picBusy.TabStop = False
        '
        'lstFiles
        '
        Me.lstFiles.AllowColumnReorder = True
        Me.lstFiles.AllowDrop = True
        resources.ApplyResources(Me.lstFiles, "lstFiles")
        Me.lstFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cohFilename, Me.cohSize, Me.cohAttribute, Me.cohFiletype})
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
        'cohAttribute
        '
        resources.ApplyResources(Me.cohAttribute, "cohAttribute")
        '
        'cohFiletype
        '
        resources.ApplyResources(Me.cohFiletype, "cohFiletype")
        '
        'menuRightClickFiles
        '
        Me.menuRightClickFiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRightSaveAs, Me.ToolStripSeparator2, Me.menuRightBackupFile, Me.menuRightRestoreFile, Me.menuRightDeleteBackupedFile, Me.ToolStripSeparator1, Me.cmdRenameFile, Me.menuRightReplaceFile, Me.menuRightDeleteFile})
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
        'menuRightDeleteBackupedFile
        '
        resources.ApplyResources(Me.menuRightDeleteBackupedFile, "menuRightDeleteBackupedFile")
        Me.menuRightDeleteBackupedFile.Name = "menuRightDeleteBackupedFile"
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
        Me.grpDetails.Controls.Add(Me.pnlQt)
        Me.grpDetails.Controls.Add(Me.chkZoom)
        Me.grpDetails.Controls.Add(Me.chkPreviewEnabled)
        Me.grpDetails.Controls.Add(Me.qtBuff)
        Me.grpDetails.Controls.Add(Me.btnPreview)
        Me.grpDetails.Controls.Add(Me.txtFileDetails)
        Me.grpDetails.Controls.Add(Me.WebBrws)
        Me.grpDetails.Controls.Add(Me.picFileDetails)
        resources.ApplyResources(Me.grpDetails, "grpDetails")
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.TabStop = False
        '
        'pnlQt
        '
        resources.ApplyResources(Me.pnlQt, "pnlQt")
        Me.pnlQt.ContextMenuStrip = Me.menuRightClickQt
        Me.pnlQt.Controls.Add(Me.qtPlugin)
        Me.pnlQt.Controls.Add(Me.lblMovieName)
        Me.pnlQt.Name = "pnlQt"
        '
        'menuRightClickQt
        '
        Me.menuRightClickQt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmQtFullscreen, Me.tsmQtExportDialog, Me.tsmQtMovieInfo, Me.tsmQuickTimeInfo})
        Me.menuRightClickQt.Name = "menuRightClickQt"
        resources.ApplyResources(Me.menuRightClickQt, "menuRightClickQt")
        '
        'tsmQtFullscreen
        '
        Me.tsmQtFullscreen.CheckOnClick = True
        Me.tsmQtFullscreen.Name = "tsmQtFullscreen"
        resources.ApplyResources(Me.tsmQtFullscreen, "tsmQtFullscreen")
        '
        'tsmQtExportDialog
        '
        Me.tsmQtExportDialog.Name = "tsmQtExportDialog"
        resources.ApplyResources(Me.tsmQtExportDialog, "tsmQtExportDialog")
        '
        'tsmQtMovieInfo
        '
        Me.tsmQtMovieInfo.Name = "tsmQtMovieInfo"
        resources.ApplyResources(Me.tsmQtMovieInfo, "tsmQtMovieInfo")
        '
        'tsmQuickTimeInfo
        '
        Me.tsmQuickTimeInfo.Name = "tsmQuickTimeInfo"
        resources.ApplyResources(Me.tsmQuickTimeInfo, "tsmQuickTimeInfo")
        '
        'lblMovieName
        '
        resources.ApplyResources(Me.lblMovieName, "lblMovieName")
        Me.lblMovieName.ContextMenuStrip = Me.menuRightClickQt
        Me.lblMovieName.Name = "lblMovieName"
        '
        'chkZoom
        '
        resources.ApplyResources(Me.chkZoom, "chkZoom")
        Me.chkZoom.Name = "chkZoom"
        Me.chkZoom.TabStop = False
        Me.chkZoom.UseVisualStyleBackColor = True
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
        'btnPreview
        '
        resources.ApplyResources(Me.btnPreview, "btnPreview")
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.TabStop = False
        Me.btnPreview.UseVisualStyleBackColor = True
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
        'picFileDetails
        '
        resources.ApplyResources(Me.picFileDetails, "picFileDetails")
        Me.picFileDetails.BackColor = System.Drawing.SystemColors.Control
        Me.picFileDetails.Name = "picFileDetails"
        Me.picFileDetails.TabStop = False
        '
        'tlbStatusStrip
        '
        Me.tlbStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlbStatusLabel, Me.BtnCancel, Me.tlbProgress0, Me.tlbProgressBar})
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
        'BtnCancel
        '
        Me.BtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        resources.ApplyResources(Me.BtnCancel, "BtnCancel")
        Me.BtnCancel.MergeIndex = 0
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.ShowDropDownArrow = False
        '
        'tlbProgress0
        '
        Me.tlbProgress0.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        resources.ApplyResources(Me.tlbProgress0, "tlbProgress0")
        Me.tlbProgress0.BackColor = System.Drawing.SystemColors.Desktop
        Me.tlbProgress0.Margin = New System.Windows.Forms.Padding(0, 4, 4, 4)
        Me.tlbProgress0.MergeIndex = 1
        Me.tlbProgress0.Name = "tlbProgress0"
        Me.tlbProgress0.Step = 1
        '
        'tlbProgressBar
        '
        Me.tlbProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        resources.ApplyResources(Me.tlbProgressBar, "tlbProgressBar")
        Me.tlbProgressBar.Margin = New System.Windows.Forms.Padding(0, 4, 10, 4)
        Me.tlbProgressBar.MergeIndex = 2
        Me.tlbProgressBar.Name = "tlbProgressBar"
        Me.tlbProgressBar.Step = 1
        '
        'toolStrip
        '
        resources.ApplyResources(Me.toolStrip, "toolStrip")
        Me.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFile, Me.mnuView, Me.mnuGoTo, Me.mnuFavorites, Me.ToolStripDropDownButton2, Me.ToolStripDropDownButton1, Me.ToolStripSeparator11, Me.tslAddress, Me.tstAddress, Me.tsbAddress})
        Me.toolStrip.Name = "toolStrip"
        '
        'tsmFile
        '
        Me.tsmFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsmFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmCleanUp, Me.ToolStripMenuItemViewBackups, Me.ToolStripSeparator7, Me.menuSaveSummerboardTheme, Me.ToolStripMenuItem4, Me.ToolStripSeparator3, Me.ToolStripMenuItemExit})
        resources.ApplyResources(Me.tsmFile, "tsmFile")
        Me.tsmFile.Name = "tsmFile"
        '
        'tsmCleanUp
        '
        Me.tsmCleanUp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFileList, Me.tsmRestructureDB, Me.tsmCleanUpBackupFiles})
        Me.tsmCleanUp.Name = "tsmCleanUp"
        resources.ApplyResources(Me.tsmCleanUp, "tsmCleanUp")
        '
        'tsmFileList
        '
        Me.tsmFileList.Name = "tsmFileList"
        resources.ApplyResources(Me.tsmFileList, "tsmFileList")
        '
        'tsmRestructureDB
        '
        Me.tsmRestructureDB.Name = "tsmRestructureDB"
        resources.ApplyResources(Me.tsmRestructureDB, "tsmRestructureDB")
        '
        'tsmCleanUpBackupFiles
        '
        Me.tsmCleanUpBackupFiles.Name = "tsmCleanUpBackupFiles"
        resources.ApplyResources(Me.tsmCleanUpBackupFiles, "tsmCleanUpBackupFiles")
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
        Me.menuSaveSummerboardTheme.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAsSummerboardFolder, Me.tsmAsPXLPackage})
        Me.menuSaveSummerboardTheme.Name = "menuSaveSummerboardTheme"
        resources.ApplyResources(Me.menuSaveSummerboardTheme, "menuSaveSummerboardTheme")
        '
        'tsmAsSummerboardFolder
        '
        Me.tsmAsSummerboardFolder.Name = "tsmAsSummerboardFolder"
        resources.ApplyResources(Me.tsmAsSummerboardFolder, "tsmAsSummerboardFolder")
        '
        'tsmAsPXLPackage
        '
        resources.ApplyResources(Me.tsmAsPXLPackage, "tsmAsPXLPackage")
        Me.tsmAsPXLPackage.Name = "tsmAsPXLPackage"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAsCustomizeFolders, Me.AsPXLPackageToolStripMenuItem1})
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'tsmAsCustomizeFolders
        '
        Me.tsmAsCustomizeFolders.Name = "tsmAsCustomizeFolders"
        resources.ApplyResources(Me.tsmAsCustomizeFolders, "tsmAsCustomizeFolders")
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
        Me.mnuGoTo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripGoTo1, Me.toolStripGoTo2, Me.ToolStripSeparator5, Me.toolStripGoTo3, Me.ToolStripMenuItem2, Me.ToolStripSeparator4, Me.mnuStdApps, Me.mnuThirdPartyApps, Me.ToolStripSeparator6, Me.tsmCameraRoll, Me.toolStripGoTo19})
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
        Me.ToolStripMenuItem2.Tag = "/var/mobile/Library/Summerboard/Themes"
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
        Me.mnuThirdPartyApps.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmCustomizeFiles, Me.tsmDockSwapDocks, Me.tsmEBooks, Me.tsmFrotzGames, Me.tsmGBAROMs, Me.tsmIFlashCards, Me.tsmInstallerPackageSources, Me.tsmISwitcherThemes, Me.tsmNESROMS, Me.tsmTTR, Me.tsmWeDictDictionaries})
        Me.mnuThirdPartyApps.Name = "mnuThirdPartyApps"
        resources.ApplyResources(Me.mnuThirdPartyApps, "mnuThirdPartyApps")
        '
        'tsmCustomizeFiles
        '
        Me.tsmCustomizeFiles.Name = "tsmCustomizeFiles"
        resources.ApplyResources(Me.tsmCustomizeFiles, "tsmCustomizeFiles")
        Me.tsmCustomizeFiles.Tag = "/var/mobile/Library/Customize"
        '
        'tsmDockSwapDocks
        '
        Me.tsmDockSwapDocks.Name = "tsmDockSwapDocks"
        resources.ApplyResources(Me.tsmDockSwapDocks, "tsmDockSwapDocks")
        Me.tsmDockSwapDocks.Tag = "/var/mobile/Library/DockSwap"
        '
        'tsmEBooks
        '
        Me.tsmEBooks.Name = "tsmEBooks"
        resources.ApplyResources(Me.tsmEBooks, "tsmEBooks")
        Me.tsmEBooks.Tag = "/var/mobile/Media/EBooks"
        '
        'tsmFrotzGames
        '
        Me.tsmFrotzGames.Name = "tsmFrotzGames"
        resources.ApplyResources(Me.tsmFrotzGames, "tsmFrotzGames")
        Me.tsmFrotzGames.Tag = "/var/mobile/Media/Frotz/Games"
        '
        'tsmGBAROMs
        '
        Me.tsmGBAROMs.Name = "tsmGBAROMs"
        resources.ApplyResources(Me.tsmGBAROMs, "tsmGBAROMs")
        Me.tsmGBAROMs.Tag = "/var/mobile/Media/ROMs/GBA"
        '
        'tsmIFlashCards
        '
        Me.tsmIFlashCards.Name = "tsmIFlashCards"
        resources.ApplyResources(Me.tsmIFlashCards, "tsmIFlashCards")
        Me.tsmIFlashCards.Tag = "/var/mobile/Library/iFlashCards"
        '
        'tsmInstallerPackageSources
        '
        Me.tsmInstallerPackageSources.Name = "tsmInstallerPackageSources"
        resources.ApplyResources(Me.tsmInstallerPackageSources, "tsmInstallerPackageSources")
        Me.tsmInstallerPackageSources.Tag = "/var/mobile/Library/Installer"
        '
        'tsmISwitcherThemes
        '
        Me.tsmISwitcherThemes.Name = "tsmISwitcherThemes"
        resources.ApplyResources(Me.tsmISwitcherThemes, "tsmISwitcherThemes")
        Me.tsmISwitcherThemes.Tag = "/var/mobile/Media/Themes"
        '
        'tsmNESROMS
        '
        Me.tsmNESROMS.Name = "tsmNESROMS"
        resources.ApplyResources(Me.tsmNESROMS, "tsmNESROMS")
        Me.tsmNESROMS.Tag = "/var/mobile/Media/ROMs/NES"
        '
        'tsmTTR
        '
        Me.tsmTTR.Name = "tsmTTR"
        resources.ApplyResources(Me.tsmTTR, "tsmTTR")
        Me.tsmTTR.Tag = "/var/mobile/Media/TTR"
        '
        'tsmWeDictDictionaries
        '
        Me.tsmWeDictDictionaries.Name = "tsmWeDictDictionaries"
        resources.ApplyResources(Me.tsmWeDictDictionaries, "tsmWeDictDictionaries")
        Me.tsmWeDictDictionaries.Tag = "/var/mobile/Libary/weDict"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        '
        'tsmCameraRoll
        '
        Me.tsmCameraRoll.Name = "tsmCameraRoll"
        resources.ApplyResources(Me.tsmCameraRoll, "tsmCameraRoll")
        Me.tsmCameraRoll.Tag = "/var/root/Media/DCIM"
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
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmConfirmDeletions, Me.tsmIgnoreThumbsdb, Me.tsmIgnoreDSStore, Me.tsmIgnoreCacheFile, Me.tsmBackupControl, Me.tsmConvertPNGs, Me.ToolStripSeparator8, Me.tsmDisplaySongTitle, Me.tsmShowPreviews, Me.tsmPictureBackground, Me.tsmBackupDirectory})
        resources.ApplyResources(Me.ToolStripDropDownButton2, "ToolStripDropDownButton2")
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        '
        'tsmConfirmDeletions
        '
        Me.tsmConfirmDeletions.Checked = True
        Me.tsmConfirmDeletions.CheckOnClick = True
        Me.tsmConfirmDeletions.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmConfirmDeletions.Name = "tsmConfirmDeletions"
        resources.ApplyResources(Me.tsmConfirmDeletions, "tsmConfirmDeletions")
        '
        'tsmIgnoreThumbsdb
        '
        Me.tsmIgnoreThumbsdb.Checked = True
        Me.tsmIgnoreThumbsdb.CheckOnClick = True
        Me.tsmIgnoreThumbsdb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmIgnoreThumbsdb.Name = "tsmIgnoreThumbsdb"
        resources.ApplyResources(Me.tsmIgnoreThumbsdb, "tsmIgnoreThumbsdb")
        '
        'tsmIgnoreDSStore
        '
        Me.tsmIgnoreDSStore.Checked = True
        Me.tsmIgnoreDSStore.CheckOnClick = True
        Me.tsmIgnoreDSStore.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmIgnoreDSStore.Name = "tsmIgnoreDSStore"
        resources.ApplyResources(Me.tsmIgnoreDSStore, "tsmIgnoreDSStore")
        '
        'tsmIgnoreCacheFile
        '
        Me.tsmIgnoreCacheFile.Checked = True
        Me.tsmIgnoreCacheFile.CheckOnClick = True
        Me.tsmIgnoreCacheFile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmIgnoreCacheFile.Name = "tsmIgnoreCacheFile"
        resources.ApplyResources(Me.tsmIgnoreCacheFile, "tsmIgnoreCacheFile")
        '
        'tsmBackupControl
        '
        Me.tsmBackupControl.Checked = True
        Me.tsmBackupControl.CheckOnClick = True
        Me.tsmBackupControl.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmBackupControl.Name = "tsmBackupControl"
        resources.ApplyResources(Me.tsmBackupControl, "tsmBackupControl")
        '
        'tsmConvertPNGs
        '
        Me.tsmConvertPNGs.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmIPhoneToPC, Me.tsmPCToIPhone, Me.tsmConvertBoth})
        Me.tsmConvertPNGs.Name = "tsmConvertPNGs"
        resources.ApplyResources(Me.tsmConvertPNGs, "tsmConvertPNGs")
        '
        'tsmIPhoneToPC
        '
        Me.tsmIPhoneToPC.Checked = True
        Me.tsmIPhoneToPC.CheckOnClick = True
        Me.tsmIPhoneToPC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmIPhoneToPC.Name = "tsmIPhoneToPC"
        resources.ApplyResources(Me.tsmIPhoneToPC, "tsmIPhoneToPC")
        '
        'tsmPCToIPhone
        '
        Me.tsmPCToIPhone.CheckOnClick = True
        resources.ApplyResources(Me.tsmPCToIPhone, "tsmPCToIPhone")
        Me.tsmPCToIPhone.Name = "tsmPCToIPhone"
        '
        'tsmConvertBoth
        '
        resources.ApplyResources(Me.tsmConvertBoth, "tsmConvertBoth")
        Me.tsmConvertBoth.Name = "tsmConvertBoth"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        resources.ApplyResources(Me.ToolStripSeparator8, "ToolStripSeparator8")
        '
        'tsmDisplaySongTitle
        '
        Me.tsmDisplaySongTitle.Checked = True
        Me.tsmDisplaySongTitle.CheckOnClick = True
        Me.tsmDisplaySongTitle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmDisplaySongTitle.Name = "tsmDisplaySongTitle"
        resources.ApplyResources(Me.tsmDisplaySongTitle, "tsmDisplaySongTitle")
        '
        'tsmShowPreviews
        '
        Me.tsmShowPreviews.Checked = True
        Me.tsmShowPreviews.CheckOnClick = True
        Me.tsmShowPreviews.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmShowPreviews.Name = "tsmShowPreviews"
        resources.ApplyResources(Me.tsmShowPreviews, "tsmShowPreviews")
        '
        'tsmPictureBackground
        '
        Me.tsmPictureBackground.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlackToolStripMenuItem, Me.GrayToolStripMenuItem, Me.WhiteToolStripMenuItem})
        Me.tsmPictureBackground.Name = "tsmPictureBackground"
        resources.ApplyResources(Me.tsmPictureBackground, "tsmPictureBackground")
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
        'tsmBackupDirectory
        '
        Me.tsmBackupDirectory.Name = "tsmBackupDirectory"
        resources.ApplyResources(Me.tsmBackupDirectory, "tsmBackupDirectory")
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.tsmHomePage})
        resources.ApplyResources(Me.ToolStripDropDownButton1, "ToolStripDropDownButton1")
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        '
        'tsmHomePage
        '
        Me.tsmHomePage.Name = "tsmHomePage"
        resources.ApplyResources(Me.tsmHomePage, "tsmHomePage")
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        resources.ApplyResources(Me.ToolStripSeparator11, "ToolStripSeparator11")
        '
        'tslAddress
        '
        resources.ApplyResources(Me.tslAddress, "tslAddress")
        Me.tslAddress.Name = "tslAddress"
        '
        'tstAddress
        '
        resources.ApplyResources(Me.tstAddress, "tstAddress")
        Me.tstAddress.Name = "tstAddress"
        '
        'tsbAddress
        '
        Me.tsbAddress.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.tsbAddress, "tsbAddress")
        Me.tsbAddress.Name = "tsbAddress"
        '
        'fileSaveDialog
        '
        Me.fileSaveDialog.AddExtension = False
        '
        'menuRightClickFolders
        '
        Me.menuRightClickFolders.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemNewFolder, Me.ToolStripSeparator9, Me.tsmBackupFolder, Me.tsmSaveFolderIn, Me.cmdRenameFolder, Me.ToolStripSeparator10, Me.ToolStripMenuItemDeleteFolder})
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
        'tsmBackupFolder
        '
        Me.tsmBackupFolder.Name = "tsmBackupFolder"
        resources.ApplyResources(Me.tsmBackupFolder, "tsmBackupFolder")
        '
        'tsmSaveFolderIn
        '
        Me.tsmSaveFolderIn.Name = "tsmSaveFolderIn"
        resources.ApplyResources(Me.tsmSaveFolderIn, "tsmSaveFolderIn")
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
        'qtPlugin
        '
        resources.ApplyResources(Me.qtPlugin, "qtPlugin")
        Me.qtPlugin.ContextMenuStrip = Me.menuRightClickQt
        Me.qtPlugin.EventEnabled = True
        Me.qtPlugin.Name = "qtPlugin"
        Me.qtPlugin.OcxState = CType(resources.GetObject("qtPlugin.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'qtBuff
        '
        resources.ApplyResources(Me.qtBuff, "qtBuff")
        Me.qtBuff.EventEnabled = True
        Me.qtBuff.MaximumSize = New System.Drawing.Size(150, 50)
        Me.qtBuff.Name = "qtBuff"
        Me.qtBuff.OcxState = CType(resources.GetObject("qtBuff.OcxState"), System.Windows.Forms.AxHost.State)
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
        CType(Me.picDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBusy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuRightClickFiles.ResumeLayout(False)
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        Me.pnlQt.ResumeLayout(False)
        Me.menuRightClickQt.ResumeLayout(False)
        CType(Me.picFileDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlbStatusStrip.ResumeLayout(False)
        Me.tlbStatusStrip.PerformLayout()
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        Me.menuRightClickFolders.ResumeLayout(False)
        CType(Me.qtPlugin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.qtBuff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlbStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents tlbStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tlbProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents imgFolders As System.Windows.Forms.ImageList
    Friend WithEvents toolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsmFile As System.Windows.Forms.ToolStripDropDownButton
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
    Friend WithEvents tsmCleanUp As System.Windows.Forms.ToolStripMenuItem
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
    'Friend WithEvents qtPlugin As AxQTOControlLib.AxQTControl
    Friend WithEvents qtBuff As QtWrapper
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
    Friend WithEvents tsmDockSwapDocks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmEBooks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmFrotzGames As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmISwitcherThemes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmNESROMS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTTR As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmInstallerPackageSources As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmConfirmDeletions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmWeDictDictionaries As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmConvertPNGs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents folderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents tsmPictureBackground As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlackToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WhiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuSaveSummerboardTheme As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmAsSummerboardFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmAsPXLPackage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmAsCustomizeFolders As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsPXLPackageToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCustomizeFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmIFlashCards As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmIPhoneToPC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmPCToIPhone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmConvertBoth As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmShowPreviews As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSaveFolderIn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmBackupFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmIgnoreThumbsdb As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmIgnoreDSStore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdRenameFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdRenameFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFavorites As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents AddToFavoritesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrganizeFavoritesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents chkPreviewEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSmallIcons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdShowGroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmGBAROMs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCameraRoll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlbProgress0 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents picFileDetails As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BtnCancel As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents toolStripGoTo20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebBrws As System.Windows.Forms.WebBrowser
    Friend WithEvents imgFilesLarge As System.Windows.Forms.ImageList
    Friend WithEvents imgFilesSmall As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmBackupDirectory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cohAttribute As System.Windows.Forms.ColumnHeader
    Friend WithEvents tsmFileList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmRestructureDB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picBusy As System.Windows.Forms.PictureBox
    Friend WithEvents tsmCleanUpBackupFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picDelete As System.Windows.Forms.PictureBox
    Friend WithEvents tsmHomePage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkZoom As System.Windows.Forms.CheckBox
    Friend WithEvents lblMovieName As System.Windows.Forms.Label
    Friend WithEvents tsmBackupControl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmIgnoreCacheFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDisplaySongTitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRightDeleteBackupedFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tslAddress As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tstAddress As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsbAddress As System.Windows.Forms.ToolStripButton
    Friend WithEvents menuRightClickQt As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmQtFullscreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmQtExportDialog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmQtMovieInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlQt As System.Windows.Forms.Panel
    Friend WithEvents tsmQuickTimeInfo As System.Windows.Forms.ToolStripMenuItem
    Protected Friend WithEvents qtPlugin As iPhoneBrowser.itouchBrowser.QtWrapper

End Class
