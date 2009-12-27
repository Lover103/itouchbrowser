<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.splMain = New System.Windows.Forms.SplitContainer
        Me.grpFolders = New System.Windows.Forms.GroupBox
        Me.tabFolder = New System.Windows.Forms.TabControl
        Me.ftabFolder = New System.Windows.Forms.TabPage
        Me.btnFind = New System.Windows.Forms.Button
        Me.txtFind = New System.Windows.Forms.TextBox
        Me.trvFolders = New System.Windows.Forms.TreeView
        Me.imgFolders = New System.Windows.Forms.ImageList(Me.components)
        Me.ftabiTunes = New System.Windows.Forms.TabPage
        Me.cmbOutputDir = New System.Windows.Forms.ComboBox
        Me.btnExport = New System.Windows.Forms.Button
        Me.trvITunes = New System.Windows.Forms.TreeView
        Me.ftabApp = New System.Windows.Forms.TabPage
        Me.trvApps = New System.Windows.Forms.TreeView
        Me.splFiles = New System.Windows.Forms.SplitContainer
        Me.pnlSSL = New System.Windows.Forms.Panel
        Me.tsSSH = New System.Windows.Forms.ToolStrip
        Me.tsbSSH = New System.Windows.Forms.ToolStripButton
        Me.tsbSSHCmd = New System.Windows.Forms.ToolStripButton
        Me.tslIPAddr = New System.Windows.Forms.ToolStripLabel
        Me.tstIPAddress = New System.Windows.Forms.ToolStripTextBox
        Me.tsbSSHConfig = New System.Windows.Forms.ToolStripButton
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
        Me.menuDeleteFileWithoutSaving = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmFileProperty = New System.Windows.Forms.ToolStripMenuItem
        Me.imgThumbnail = New System.Windows.Forms.ImageList(Me.components)
        Me.imgThumbnailSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.qtBuff = New iPhoneBrowser.itouchBrowser.QtWrapper
        Me.grpDetails = New System.Windows.Forms.GroupBox
        Me.pnlQt = New iPhoneBrowser.itouchBrowser.PlayPanel
        Me.chkZoom = New System.Windows.Forms.CheckBox
        Me.chkPreviewEnabled = New System.Windows.Forms.CheckBox
        Me.btnPreview = New System.Windows.Forms.Button
        Me.tabViewType = New System.Windows.Forms.TabControl
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.picFileDetails = New System.Windows.Forms.PictureBox
        Me.txtFileDetails = New System.Windows.Forms.TextBox
        Me.WebBrws = New System.Windows.Forms.WebBrowser
        Me.imgFilesSmallNew = New System.Windows.Forms.ImageList(Me.components)
        Me.imgFilesLargeNew = New System.Windows.Forms.ImageList(Me.components)
        Me.menuRightClickQt = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmQtFullscreen = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmQtExportDialog = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmQtMovieInfo = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmQuickTimeInfo = New System.Windows.Forms.ToolStripMenuItem
        Me.tlbStatusStrip = New System.Windows.Forms.StatusStrip
        Me.tslStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslProgress = New System.Windows.Forms.ToolStripStatusLabel
        Me.btnCancel = New System.Windows.Forms.ToolStripDropDownButton
        Me.tlbProgress0 = New System.Windows.Forms.ToolStripProgressBar
        Me.tlbProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.toolStrip = New System.Windows.Forms.ToolStrip
        Me.tsmFile = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmCleanUp = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmFileList = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmRestructureDB = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmCleanUpBackupFiles = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemViewBackups = New System.Windows.Forms.ToolStripMenuItem
        Me.tssSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.tsmQtExportDialog1 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmQtMovieInfo1 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmQtInfo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemExit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuView = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmViewDetails = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmViewLargeIcons = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmViewSmallIcons = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmViewTile = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator
        Me.cmdShowGroups = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuGoTo = New System.Windows.Forms.ToolStripDropDownButton
        Me.toolStripGoTo1 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripGoTo2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.toolStripGoTo3 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmThemes = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmWallpaper = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuStdApps = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmITunesMusic = New System.Windows.Forms.ToolStripMenuItem
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
        Me.IComicToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
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
        Me.tsmCheckALatestVersion = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmModificationHistory = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.tslAddress = New System.Windows.Forms.ToolStripLabel
        Me.tstAddress = New System.Windows.Forms.ToolStripTextBox
        Me.tsbAddress = New System.Windows.Forms.ToolStripButton
        Me.tsbZoom = New System.Windows.Forms.ToolStripButton
        Me.tsbFullScreen = New System.Windows.Forms.ToolStripButton
        Me.fileSaveDialog = New System.Windows.Forms.SaveFileDialog
        Me.fileOpenDialog = New System.Windows.Forms.OpenFileDialog
        Me.menuRightClickFolders = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmNewFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmBackupFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSaveFolderIn = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmRenameFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.menuDeleteFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.menuDeleteFolderWithoutSaving = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmProperty = New System.Windows.Forms.ToolStripMenuItem
        Me.folderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.splMain.Panel1.SuspendLayout()
        Me.splMain.Panel2.SuspendLayout()
        Me.splMain.SuspendLayout()
        Me.grpFolders.SuspendLayout()
        Me.tabFolder.SuspendLayout()
        Me.ftabFolder.SuspendLayout()
        Me.ftabiTunes.SuspendLayout()
        Me.ftabApp.SuspendLayout()
        Me.splFiles.Panel1.SuspendLayout()
        Me.splFiles.Panel2.SuspendLayout()
        Me.splFiles.SuspendLayout()
        Me.pnlSSL.SuspendLayout()
        Me.tsSSH.SuspendLayout()
        Me.grpFiles.SuspendLayout()
        CType(Me.picDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBusy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuRightClickFiles.SuspendLayout()
        CType(Me.qtBuff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetails.SuspendLayout()
        Me.tabViewType.SuspendLayout()
        CType(Me.picFileDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.menuRightClickQt.SuspendLayout()
        Me.tlbStatusStrip.SuspendLayout()
        Me.toolStrip.SuspendLayout()
        Me.menuRightClickFolders.SuspendLayout()
        Me.SuspendLayout()
        '
        'splMain
        '
        Me.splMain.AllowDrop = True
        Me.splMain.BackColor = System.Drawing.SystemColors.Control
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
        Me.grpFolders.Controls.Add(Me.tabFolder)
        resources.ApplyResources(Me.grpFolders, "grpFolders")
        Me.grpFolders.Name = "grpFolders"
        Me.grpFolders.TabStop = False
        '
        'tabFolder
        '
        Me.tabFolder.Controls.Add(Me.ftabFolder)
        Me.tabFolder.Controls.Add(Me.ftabiTunes)
        Me.tabFolder.Controls.Add(Me.ftabApp)
        resources.ApplyResources(Me.tabFolder, "tabFolder")
        Me.tabFolder.Name = "tabFolder"
        Me.tabFolder.SelectedIndex = 0
        '
        'ftabFolder
        '
        Me.ftabFolder.Controls.Add(Me.btnFind)
        Me.ftabFolder.Controls.Add(Me.txtFind)
        Me.ftabFolder.Controls.Add(Me.trvFolders)
        resources.ApplyResources(Me.ftabFolder, "ftabFolder")
        Me.ftabFolder.Name = "ftabFolder"
        Me.ftabFolder.UseVisualStyleBackColor = True
        '
        'btnFind
        '
        resources.ApplyResources(Me.btnFind, "btnFind")
        Me.btnFind.Name = "btnFind"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtFind
        '
        resources.ApplyResources(Me.txtFind, "txtFind")
        Me.txtFind.Name = "txtFind"
        '
        'trvFolders
        '
        resources.ApplyResources(Me.trvFolders, "trvFolders")
        Me.trvFolders.HideSelection = False
        Me.trvFolders.ImageList = Me.imgFolders
        Me.trvFolders.ItemHeight = 16
        Me.trvFolders.Name = "trvFolders"
        Me.trvFolders.PathSeparator = "/"
        Me.trvFolders.ShowRootLines = False
        '
        'imgFolders
        '
        Me.imgFolders.ImageStream = CType(resources.GetObject("imgFolders.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgFolders.TransparentColor = System.Drawing.Color.Empty
        Me.imgFolders.Images.SetKeyName(0, "XPfolder_closed.bmp")
        Me.imgFolders.Images.SetKeyName(1, "XPfolder_Open.bmp")
        '
        'ftabiTunes
        '
        Me.ftabiTunes.Controls.Add(Me.cmbOutputDir)
        Me.ftabiTunes.Controls.Add(Me.btnExport)
        Me.ftabiTunes.Controls.Add(Me.trvITunes)
        resources.ApplyResources(Me.ftabiTunes, "ftabiTunes")
        Me.ftabiTunes.Name = "ftabiTunes"
        Me.ftabiTunes.UseVisualStyleBackColor = True
        '
        'cmbOutputDir
        '
        resources.ApplyResources(Me.cmbOutputDir, "cmbOutputDir")
        Me.cmbOutputDir.FormattingEnabled = True
        Me.cmbOutputDir.Items.AddRange(New Object() {resources.GetString("cmbOutputDir.Items"), resources.GetString("cmbOutputDir.Items1"), resources.GetString("cmbOutputDir.Items2")})
        Me.cmbOutputDir.Name = "cmbOutputDir"
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Name = "btnExport"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'trvITunes
        '
        resources.ApplyResources(Me.trvITunes, "trvITunes")
        Me.trvITunes.CheckBoxes = True
        Me.trvITunes.HideSelection = False
        Me.trvITunes.Name = "trvITunes"
        Me.trvITunes.ShowRootLines = False
        '
        'ftabApp
        '
        Me.ftabApp.Controls.Add(Me.trvApps)
        resources.ApplyResources(Me.ftabApp, "ftabApp")
        Me.ftabApp.Name = "ftabApp"
        Me.ftabApp.UseVisualStyleBackColor = True
        '
        'trvApps
        '
        resources.ApplyResources(Me.trvApps, "trvApps")
        Me.trvApps.HideSelection = False
        Me.trvApps.ImageList = Me.imgFolders
        Me.trvApps.ItemHeight = 16
        Me.trvApps.Name = "trvApps"
        Me.trvApps.PathSeparator = "/"
        Me.trvApps.ShowRootLines = False
        '
        'splFiles
        '
        Me.splFiles.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.splFiles, "splFiles")
        Me.splFiles.MinimumSize = New System.Drawing.Size(100, 92)
        Me.splFiles.Name = "splFiles"
        '
        'splFiles.Panel1
        '
        Me.splFiles.Panel1.Controls.Add(Me.pnlSSL)
        Me.splFiles.Panel1.Controls.Add(Me.grpFiles)
        '
        'splFiles.Panel2
        '
        Me.splFiles.Panel2.Controls.Add(Me.grpDetails)
        '
        'pnlSSL
        '
        Me.pnlSSL.Controls.Add(Me.tsSSH)
        resources.ApplyResources(Me.pnlSSL, "pnlSSL")
        Me.pnlSSL.Name = "pnlSSL"
        '
        'tsSSH
        '
        Me.tsSSH.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSSH, Me.tsbSSHCmd, Me.tslIPAddr, Me.tstIPAddress, Me.tsbSSHConfig})
        resources.ApplyResources(Me.tsSSH, "tsSSH")
        Me.tsSSH.Name = "tsSSH"
        '
        'tsbSSH
        '
        Me.tsbSSH.CheckOnClick = True
        Me.tsbSSH.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.SecurityLock1
        Me.tsbSSH.Name = "tsbSSH"
        resources.ApplyResources(Me.tsbSSH, "tsbSSH")
        '
        'tsbSSHCmd
        '
        Me.tsbSSHCmd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.tsbSSHCmd, "tsbSSHCmd")
        Me.tsbSSHCmd.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.window
        Me.tsbSSHCmd.Name = "tsbSSHCmd"
        '
        'tslIPAddr
        '
        Me.tslIPAddr.Name = "tslIPAddr"
        resources.ApplyResources(Me.tslIPAddr, "tslIPAddr")
        '
        'tstIPAddress
        '
        Me.tstIPAddress.CausesValidation = False
        Me.tstIPAddress.Name = "tstIPAddress"
        resources.ApplyResources(Me.tstIPAddress, "tstIPAddress")
        '
        'tsbSSHConfig
        '
        Me.tsbSSHConfig.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbSSHConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSSHConfig.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.AddOnIcon
        resources.ApplyResources(Me.tsbSSHConfig, "tsbSSHConfig")
        Me.tsbSSHConfig.Name = "tsbSSHConfig"
        '
        'grpFiles
        '
        resources.ApplyResources(Me.grpFiles, "grpFiles")
        Me.grpFiles.Controls.Add(Me.picDelete)
        Me.grpFiles.Controls.Add(Me.picBusy)
        Me.grpFiles.Controls.Add(Me.lstFiles)
        Me.grpFiles.Controls.Add(Me.qtBuff)
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
        Me.lstFiles.AllowDrop = True
        resources.ApplyResources(Me.lstFiles, "lstFiles")
        Me.lstFiles.BackColor = System.Drawing.Color.PowderBlue
        Me.lstFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cohFilename, Me.cohSize, Me.cohAttribute, Me.cohFiletype})
        Me.lstFiles.ContextMenuStrip = Me.menuRightClickFiles
        Me.lstFiles.LargeImageList = Me.imgThumbnail
        Me.lstFiles.Name = "lstFiles"
        Me.lstFiles.ShowGroups = False
        Me.lstFiles.SmallImageList = Me.imgThumbnailSmall
        Me.lstFiles.UseCompatibleStateImageBehavior = False
        Me.lstFiles.View = System.Windows.Forms.View.Details
        Me.lstFiles.VirtualListSize = 30
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
        Me.menuRightClickFiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRightSaveAs, Me.ToolStripSeparator2, Me.menuRightBackupFile, Me.menuRightRestoreFile, Me.menuRightDeleteBackupedFile, Me.ToolStripSeparator1, Me.cmdRenameFile, Me.menuRightReplaceFile, Me.menuRightDeleteFile, Me.menuDeleteFileWithoutSaving, Me.tsmFileProperty})
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
        'menuDeleteFileWithoutSaving
        '
        Me.menuDeleteFileWithoutSaving.Name = "menuDeleteFileWithoutSaving"
        resources.ApplyResources(Me.menuDeleteFileWithoutSaving, "menuDeleteFileWithoutSaving")
        '
        'tsmFileProperty
        '
        resources.ApplyResources(Me.tsmFileProperty, "tsmFileProperty")
        Me.tsmFileProperty.Name = "tsmFileProperty"
        '
        'imgThumbnail
        '
        Me.imgThumbnail.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        resources.ApplyResources(Me.imgThumbnail, "imgThumbnail")
        Me.imgThumbnail.TransparentColor = System.Drawing.Color.PowderBlue
        '
        'imgThumbnailSmall
        '
        Me.imgThumbnailSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        resources.ApplyResources(Me.imgThumbnailSmall, "imgThumbnailSmall")
        Me.imgThumbnailSmall.TransparentColor = System.Drawing.Color.White
        '
        'qtBuff
        '
        resources.ApplyResources(Me.qtBuff, "qtBuff")
        Me.qtBuff.EventEnabled = True
        Me.qtBuff.MaximumSize = New System.Drawing.Size(150, 50)
        Me.qtBuff.Name = "qtBuff"
        Me.qtBuff.OcxState = CType(resources.GetObject("qtBuff.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'grpDetails
        '
        Me.grpDetails.Controls.Add(Me.pnlQt)
        Me.grpDetails.Controls.Add(Me.chkZoom)
        Me.grpDetails.Controls.Add(Me.chkPreviewEnabled)
        Me.grpDetails.Controls.Add(Me.btnPreview)
        Me.grpDetails.Controls.Add(Me.tabViewType)
        Me.grpDetails.Controls.Add(Me.picFileDetails)
        Me.grpDetails.Controls.Add(Me.txtFileDetails)
        Me.grpDetails.Controls.Add(Me.WebBrws)
        resources.ApplyResources(Me.grpDetails, "grpDetails")
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.TabStop = False
        '
        'pnlQt
        '
        resources.ApplyResources(Me.pnlQt, "pnlQt")
        Me.pnlQt.BottomHeight = 29
        Me.pnlQt.FileName = ""
        Me.pnlQt.ImageLocation = Nothing
        Me.pnlQt.LeftWidth = 115
        Me.pnlQt.Lyric = ""
        Me.pnlQt.LyricVisible = True
        Me.pnlQt.MovieInfo = ""
        Me.pnlQt.Name = "pnlQt"
        Me.pnlQt.PictureVisible = False
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
        'tabViewType
        '
        resources.ApplyResources(Me.tabViewType, "tabViewType")
        Me.tabViewType.Controls.Add(Me.TabPage3)
        Me.tabViewType.Controls.Add(Me.TabPage4)
        Me.tabViewType.Name = "tabViewType"
        Me.tabViewType.SelectedIndex = 0
        '
        'TabPage3
        '
        resources.ApplyResources(Me.TabPage3, "TabPage3")
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        resources.ApplyResources(Me.TabPage4, "TabPage4")
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
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
        'imgFilesSmallNew
        '
        Me.imgFilesSmallNew.ImageStream = CType(resources.GetObject("imgFilesSmallNew.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgFilesSmallNew.TransparentColor = System.Drawing.Color.Transparent
        Me.imgFilesSmallNew.Images.SetKeyName(0, "help.png")
        '
        'imgFilesLargeNew
        '
        Me.imgFilesLargeNew.ImageStream = CType(resources.GetObject("imgFilesLargeNew.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgFilesLargeNew.TransparentColor = System.Drawing.Color.Transparent
        Me.imgFilesLargeNew.Images.SetKeyName(0, "help.png")
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
        'tlbStatusStrip
        '
        Me.tlbStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslStatusLabel, Me.tslProgress, Me.btnCancel, Me.tlbProgress0, Me.tlbProgressBar})
        resources.ApplyResources(Me.tlbStatusStrip, "tlbStatusStrip")
        Me.tlbStatusStrip.Name = "tlbStatusStrip"
        Me.tlbStatusStrip.ShowItemToolTips = True
        '
        'tslStatusLabel
        '
        resources.ApplyResources(Me.tslStatusLabel, "tslStatusLabel")
        Me.tslStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tslStatusLabel.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.tslStatusLabel.Name = "tslStatusLabel"
        Me.tslStatusLabel.Spring = True
        '
        'tslProgress
        '
        Me.tslProgress.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslProgress.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tslProgress.Name = "tslProgress"
        resources.ApplyResources(Me.tslProgress, "tslProgress")
        '
        'btnCancel
        '
        Me.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.MergeIndex = 0
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.ShowDropDownArrow = False
        '
        'tlbProgress0
        '
        Me.tlbProgress0.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        resources.ApplyResources(Me.tlbProgress0, "tlbProgress0")
        Me.tlbProgress0.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tlbProgress0.Margin = New System.Windows.Forms.Padding(0, 4, 4, 4)
        Me.tlbProgress0.MergeIndex = 0
        Me.tlbProgress0.Name = "tlbProgress0"
        Me.tlbProgress0.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always
        Me.tlbProgress0.Step = 1
        '
        'tlbProgressBar
        '
        Me.tlbProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        resources.ApplyResources(Me.tlbProgressBar, "tlbProgressBar")
        Me.tlbProgressBar.Margin = New System.Windows.Forms.Padding(0, 4, 4, 4)
        Me.tlbProgressBar.MergeIndex = 0
        Me.tlbProgressBar.Name = "tlbProgressBar"
        Me.tlbProgressBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always
        Me.tlbProgressBar.Step = 1
        '
        'toolStrip
        '
        resources.ApplyResources(Me.toolStrip, "toolStrip")
        Me.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFile, Me.mnuView, Me.mnuGoTo, Me.mnuFavorites, Me.ToolStripDropDownButton2, Me.ToolStripDropDownButton1, Me.ToolStripSeparator11, Me.tslAddress, Me.tstAddress, Me.tsbAddress, Me.tsbZoom, Me.tsbFullScreen})
        Me.toolStrip.Name = "toolStrip"
        '
        'tsmFile
        '
        Me.tsmFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsmFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmCleanUp, Me.ToolStripMenuItemViewBackups, Me.tssSeparator, Me.tsmQtExportDialog1, Me.tsmQtMovieInfo1, Me.tsmQtInfo, Me.ToolStripSeparator3, Me.ToolStripMenuItemExit})
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
        'tssSeparator
        '
        Me.tssSeparator.Name = "tssSeparator"
        resources.ApplyResources(Me.tssSeparator, "tssSeparator")
        '
        'tsmQtExportDialog1
        '
        Me.tsmQtExportDialog1.Name = "tsmQtExportDialog1"
        resources.ApplyResources(Me.tsmQtExportDialog1, "tsmQtExportDialog1")
        '
        'tsmQtMovieInfo1
        '
        Me.tsmQtMovieInfo1.Name = "tsmQtMovieInfo1"
        resources.ApplyResources(Me.tsmQtMovieInfo1, "tsmQtMovieInfo1")
        '
        'tsmQtInfo
        '
        Me.tsmQtInfo.Name = "tsmQtInfo"
        resources.ApplyResources(Me.tsmQtInfo, "tsmQtInfo")
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
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmViewDetails, Me.tsmViewLargeIcons, Me.tsmViewSmallIcons, Me.tsmViewTile, Me.ToolStripMenuItem8, Me.cmdShowGroups})
        resources.ApplyResources(Me.mnuView, "mnuView")
        Me.mnuView.Name = "mnuView"
        '
        'tsmViewDetails
        '
        Me.tsmViewDetails.Checked = True
        Me.tsmViewDetails.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmViewDetails.Name = "tsmViewDetails"
        resources.ApplyResources(Me.tsmViewDetails, "tsmViewDetails")
        '
        'tsmViewLargeIcons
        '
        Me.tsmViewLargeIcons.Name = "tsmViewLargeIcons"
        resources.ApplyResources(Me.tsmViewLargeIcons, "tsmViewLargeIcons")
        '
        'tsmViewSmallIcons
        '
        Me.tsmViewSmallIcons.Name = "tsmViewSmallIcons"
        resources.ApplyResources(Me.tsmViewSmallIcons, "tsmViewSmallIcons")
        '
        'tsmViewTile
        '
        Me.tsmViewTile.Name = "tsmViewTile"
        resources.ApplyResources(Me.tsmViewTile, "tsmViewTile")
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
        Me.mnuGoTo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripGoTo1, Me.toolStripGoTo2, Me.ToolStripSeparator5, Me.toolStripGoTo3, Me.tsmThemes, Me.tsmWallpaper, Me.ToolStripMenuItem2, Me.ToolStripSeparator4, Me.mnuStdApps, Me.mnuThirdPartyApps, Me.ToolStripSeparator6, Me.tsmCameraRoll, Me.toolStripGoTo19})
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
        'tsmThemes
        '
        Me.tsmThemes.Name = "tsmThemes"
        resources.ApplyResources(Me.tsmThemes, "tsmThemes")
        Me.tsmThemes.Tag = "/Library/Themes"
        '
        'tsmWallpaper
        '
        Me.tsmWallpaper.Name = "tsmWallpaper"
        resources.ApplyResources(Me.tsmWallpaper, "tsmWallpaper")
        Me.tsmWallpaper.Tag = "/Library/Wallpaper"
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
        Me.mnuStdApps.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmITunesMusic, Me.toolStripGoTo4, Me.toolStripGoTo6, Me.toolStripGoTo13, Me.toolStripGoTo14, Me.toolStripGoTo8, Me.toolStripGoTo7, Me.toolStripGoTo5, Me.toolStripGoTo9, Me.toolStripGoTo10, Me.toolStripGoTo12, Me.toolStripGoTo15, Me.toolStripGoTo11, Me.toolStripGoTo16, Me.toolStripGoTo17, Me.toolStripGoTo18})
        Me.mnuStdApps.Name = "mnuStdApps"
        resources.ApplyResources(Me.mnuStdApps, "mnuStdApps")
        '
        'tsmITunesMusic
        '
        Me.tsmITunesMusic.Name = "tsmITunesMusic"
        resources.ApplyResources(Me.tsmITunesMusic, "tsmITunesMusic")
        Me.tsmITunesMusic.Tag = "/private/var/mobile/Media/iTunes_Control/Music"
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
        Me.mnuThirdPartyApps.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmCustomizeFiles, Me.tsmDockSwapDocks, Me.IComicToolStripMenuItem, Me.tsmEBooks, Me.tsmFrotzGames, Me.tsmGBAROMs, Me.tsmIFlashCards, Me.tsmInstallerPackageSources, Me.tsmISwitcherThemes, Me.tsmNESROMS, Me.tsmTTR, Me.tsmWeDictDictionaries})
        Me.mnuThirdPartyApps.Name = "mnuThirdPartyApps"
        resources.ApplyResources(Me.mnuThirdPartyApps, "mnuThirdPartyApps")
        '
        'tsmCustomizeFiles
        '
        Me.tsmCustomizeFiles.Name = "tsmCustomizeFiles"
        resources.ApplyResources(Me.tsmCustomizeFiles, "tsmCustomizeFiles")
        Me.tsmCustomizeFiles.Tag = "/private/var/mobile/Library/Customize"
        '
        'tsmDockSwapDocks
        '
        Me.tsmDockSwapDocks.Name = "tsmDockSwapDocks"
        resources.ApplyResources(Me.tsmDockSwapDocks, "tsmDockSwapDocks")
        Me.tsmDockSwapDocks.Tag = "/private/var/mobile/Library/DockSwap"
        '
        'IComicToolStripMenuItem
        '
        Me.IComicToolStripMenuItem.Name = "IComicToolStripMenuItem"
        resources.ApplyResources(Me.IComicToolStripMenuItem, "IComicToolStripMenuItem")
        Me.IComicToolStripMenuItem.Tag = "/private/var/mobile/Media/Comic"
        '
        'tsmEBooks
        '
        Me.tsmEBooks.Name = "tsmEBooks"
        resources.ApplyResources(Me.tsmEBooks, "tsmEBooks")
        Me.tsmEBooks.Tag = "/private/var/mobile/Media/EBooks"
        '
        'tsmFrotzGames
        '
        Me.tsmFrotzGames.Name = "tsmFrotzGames"
        resources.ApplyResources(Me.tsmFrotzGames, "tsmFrotzGames")
        Me.tsmFrotzGames.Tag = "/private/var/mobile/Media/Frotz/Games"
        '
        'tsmGBAROMs
        '
        Me.tsmGBAROMs.Name = "tsmGBAROMs"
        resources.ApplyResources(Me.tsmGBAROMs, "tsmGBAROMs")
        Me.tsmGBAROMs.Tag = "/private/var/mobile/Media/ROMs/GBA"
        '
        'tsmIFlashCards
        '
        Me.tsmIFlashCards.Name = "tsmIFlashCards"
        resources.ApplyResources(Me.tsmIFlashCards, "tsmIFlashCards")
        Me.tsmIFlashCards.Tag = "/private/var/mobile/Library/iFlashCards"
        '
        'tsmInstallerPackageSources
        '
        Me.tsmInstallerPackageSources.Name = "tsmInstallerPackageSources"
        resources.ApplyResources(Me.tsmInstallerPackageSources, "tsmInstallerPackageSources")
        Me.tsmInstallerPackageSources.Tag = "/private/var/mobile/Library/Installer"
        '
        'tsmISwitcherThemes
        '
        Me.tsmISwitcherThemes.Name = "tsmISwitcherThemes"
        resources.ApplyResources(Me.tsmISwitcherThemes, "tsmISwitcherThemes")
        Me.tsmISwitcherThemes.Tag = "/private/var/mobile/Media/Themes"
        '
        'tsmNESROMS
        '
        Me.tsmNESROMS.Name = "tsmNESROMS"
        resources.ApplyResources(Me.tsmNESROMS, "tsmNESROMS")
        Me.tsmNESROMS.Tag = "/private/var/mobile/Media/ROMs/NES"
        '
        'tsmTTR
        '
        Me.tsmTTR.Name = "tsmTTR"
        resources.ApplyResources(Me.tsmTTR, "tsmTTR")
        Me.tsmTTR.Tag = "/private/var/mobile/Media/TTR"
        '
        'tsmWeDictDictionaries
        '
        Me.tsmWeDictDictionaries.Name = "tsmWeDictDictionaries"
        resources.ApplyResources(Me.tsmWeDictDictionaries, "tsmWeDictDictionaries")
        Me.tsmWeDictDictionaries.Tag = "/private/var/mobile/Libary/weDict"
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
        Me.tsmCameraRoll.Tag = "/private/var/mobile/Media/DCIM"
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
        Me.ToolStripDropDownButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        resources.ApplyResources(Me.ToolStripDropDownButton2, "ToolStripDropDownButton2")
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmConfirmDeletions, Me.tsmIgnoreThumbsdb, Me.tsmIgnoreDSStore, Me.tsmIgnoreCacheFile, Me.tsmBackupControl, Me.tsmConvertPNGs, Me.ToolStripSeparator8, Me.tsmDisplaySongTitle, Me.tsmShowPreviews, Me.tsmPictureBackground, Me.tsmBackupDirectory})
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
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.tsmHomePage, Me.tsmCheckALatestVersion, Me.tsmModificationHistory})
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
        'tsmCheckALatestVersion
        '
        Me.tsmCheckALatestVersion.Name = "tsmCheckALatestVersion"
        resources.ApplyResources(Me.tsmCheckALatestVersion, "tsmCheckALatestVersion")
        '
        'tsmModificationHistory
        '
        Me.tsmModificationHistory.Name = "tsmModificationHistory"
        resources.ApplyResources(Me.tsmModificationHistory, "tsmModificationHistory")
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
        'tsbZoom
        '
        Me.tsbZoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbZoom.CheckOnClick = True
        Me.tsbZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.tsbZoom, "tsbZoom")
        Me.tsbZoom.Name = "tsbZoom"
        '
        'tsbFullScreen
        '
        Me.tsbFullScreen.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbFullScreen.CheckOnClick = True
        Me.tsbFullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbFullScreen.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.FullScreen
        Me.tsbFullScreen.Name = "tsbFullScreen"
        resources.ApplyResources(Me.tsbFullScreen, "tsbFullScreen")
        '
        'fileSaveDialog
        '
        Me.fileSaveDialog.AddExtension = False
        '
        'menuRightClickFolders
        '
        Me.menuRightClickFolders.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmNewFolder, Me.ToolStripSeparator9, Me.tsmBackupFolder, Me.tsmSaveFolderIn, Me.tsmRenameFolder, Me.ToolStripSeparator10, Me.menuDeleteFolder, Me.menuDeleteFolderWithoutSaving, Me.ToolStripSeparator12, Me.tsmProperty})
        Me.menuRightClickFolders.Name = "menuRightClickFolders"
        resources.ApplyResources(Me.menuRightClickFolders, "menuRightClickFolders")
        '
        'tsmNewFolder
        '
        Me.tsmNewFolder.Name = "tsmNewFolder"
        resources.ApplyResources(Me.tsmNewFolder, "tsmNewFolder")
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
        'tsmRenameFolder
        '
        Me.tsmRenameFolder.Name = "tsmRenameFolder"
        resources.ApplyResources(Me.tsmRenameFolder, "tsmRenameFolder")
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        resources.ApplyResources(Me.ToolStripSeparator10, "ToolStripSeparator10")
        '
        'menuDeleteFolder
        '
        Me.menuDeleteFolder.Name = "menuDeleteFolder"
        resources.ApplyResources(Me.menuDeleteFolder, "menuDeleteFolder")
        '
        'menuDeleteFolderWithoutSaving
        '
        Me.menuDeleteFolderWithoutSaving.Name = "menuDeleteFolderWithoutSaving"
        resources.ApplyResources(Me.menuDeleteFolderWithoutSaving, "menuDeleteFolderWithoutSaving")
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        resources.ApplyResources(Me.ToolStripSeparator12, "ToolStripSeparator12")
        '
        'tsmProperty
        '
        Me.tsmProperty.Name = "tsmProperty"
        resources.ApplyResources(Me.tsmProperty, "tsmProperty")
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
        Me.tabFolder.ResumeLayout(False)
        Me.ftabFolder.ResumeLayout(False)
        Me.ftabFolder.PerformLayout()
        Me.ftabiTunes.ResumeLayout(False)
        Me.ftabApp.ResumeLayout(False)
        Me.splFiles.Panel1.ResumeLayout(False)
        Me.splFiles.Panel2.ResumeLayout(False)
        Me.splFiles.ResumeLayout(False)
        Me.pnlSSL.ResumeLayout(False)
        Me.pnlSSL.PerformLayout()
        Me.tsSSH.ResumeLayout(False)
        Me.tsSSH.PerformLayout()
        Me.grpFiles.ResumeLayout(False)
        CType(Me.picDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBusy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuRightClickFiles.ResumeLayout(False)
        CType(Me.qtBuff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        Me.tabViewType.ResumeLayout(False)
        CType(Me.picFileDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.menuRightClickQt.ResumeLayout(False)
        Me.tlbStatusStrip.ResumeLayout(False)
        Me.tlbStatusStrip.PerformLayout()
        Me.toolStrip.ResumeLayout(False)
        Me.toolStrip.PerformLayout()
        Me.menuRightClickFolders.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlbProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripMenuItemExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmViewDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmViewLargeIcons As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents splFiles As System.Windows.Forms.SplitContainer
    Friend WithEvents cohFilename As System.Windows.Forms.ColumnHeader
    Friend WithEvents cohSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents cohFiletype As System.Windows.Forms.ColumnHeader
    'Friend WithEvents qtPlugin As AxQTOControlLib.AxQTControl
    Friend WithEvents qtBuff As QtWrapper
    Friend WithEvents txtFileDetails As System.Windows.Forms.TextBox
    Friend WithEvents toolStripGoTo1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripGoTo3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripGoTo19 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmNewFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDeleteFolder As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents tsmRenameFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdRenameFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToFavoritesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrganizeFavoritesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmViewSmallIcons As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdShowGroups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmGBAROMs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCameraRoll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picFileDetails As System.Windows.Forms.PictureBox
    Friend WithEvents tsmITunesMusic As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebBrws As System.Windows.Forms.WebBrowser
    Friend WithEvents tsmBackupDirectory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cohAttribute As System.Windows.Forms.ColumnHeader
    Friend WithEvents tsmFileList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmRestructureDB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picBusy As System.Windows.Forms.PictureBox
    Friend WithEvents tsmCleanUpBackupFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picDelete As System.Windows.Forms.PictureBox
    Friend WithEvents tsmHomePage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmBackupControl As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmIgnoreCacheFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDisplaySongTitle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuRightDeleteBackupedFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmQtFullscreen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmQtExportDialog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmQtMovieInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmQuickTimeInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ftabFolder As System.Windows.Forms.TabPage
    Friend WithEvents ftabiTunes As System.Windows.Forms.TabPage
    Friend WithEvents trvITunes As System.Windows.Forms.TreeView
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents cmbOutputDir As System.Windows.Forms.ComboBox
    Friend WithEvents tsmViewTile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IComicToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tssSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmQtExportDialog1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmQtMovieInfo1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmQtInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents menuDeleteFileWithoutSaving As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuDeleteFolderWithoutSaving As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ftabApp As System.Windows.Forms.TabPage
    Friend WithEvents trvApps As System.Windows.Forms.TreeView
    Friend WithEvents tsmProperty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCheckALatestVersion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmModificationHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmFileProperty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmThemes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmWallpaper As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStrip As System.Windows.Forms.ToolStrip
    Private WithEvents tsmFile As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents mnuView As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents grpFolders As System.Windows.Forms.GroupBox
    Private WithEvents mnuGoTo As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents mnuFavorites As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents tslAddress As System.Windows.Forms.ToolStripLabel
    Private WithEvents tstAddress As System.Windows.Forms.ToolStripTextBox
    Private WithEvents tsbAddress As System.Windows.Forms.ToolStripButton
    Private WithEvents tabFolder As System.Windows.Forms.TabControl
    Private WithEvents tsbZoom As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbFullScreen As System.Windows.Forms.ToolStripButton
    Private WithEvents tsSSH As System.Windows.Forms.ToolStrip
    Private WithEvents tsbSSH As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbSSHCmd As System.Windows.Forms.ToolStripButton
    Private WithEvents imgFolders As System.Windows.Forms.ImageList
    Private WithEvents menuRightClickFiles As System.Windows.Forms.ContextMenuStrip
    Private WithEvents grpFiles As System.Windows.Forms.GroupBox
    Private WithEvents grpDetails As System.Windows.Forms.GroupBox
    Private WithEvents btnPreview As System.Windows.Forms.Button
    Private WithEvents chkPreviewEnabled As System.Windows.Forms.CheckBox
    Private WithEvents tlbProgress0 As System.Windows.Forms.ToolStripProgressBar
    Private WithEvents chkZoom As System.Windows.Forms.CheckBox
    Private WithEvents menuRightClickQt As System.Windows.Forms.ContextMenuStrip
    Private WithEvents pnlQt As iPhoneBrowser.itouchBrowser.PlayPanel
    Private WithEvents tabViewType As System.Windows.Forms.TabControl
    Private WithEvents imgThumbnail As System.Windows.Forms.ImageList
    Private WithEvents txtFind As System.Windows.Forms.TextBox
    Private WithEvents btnFind As System.Windows.Forms.Button
    Private WithEvents tslIPAddr As System.Windows.Forms.ToolStripLabel
    Private WithEvents tstIPAddress As System.Windows.Forms.ToolStripTextBox
    Private WithEvents pnlSSL As System.Windows.Forms.Panel
    Private WithEvents imgThumbnailSmall As System.Windows.Forms.ImageList
    Friend WithEvents tslStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents tlbStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents lstFiles As System.Windows.Forms.ListView
    Friend WithEvents menuRightClickFolders As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents imgFilesLargeNew As System.Windows.Forms.ImageList
    Friend WithEvents imgFilesSmallNew As System.Windows.Forms.ImageList
    Friend WithEvents tslProgress As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents trvFolders As System.Windows.Forms.TreeView
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents tsbSSHConfig As System.Windows.Forms.ToolStripButton

End Class
