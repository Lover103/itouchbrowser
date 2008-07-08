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
        Me.BtnCancel = New System.Windows.Forms.ToolStripDropDownButton
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
        Me.BackupDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
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
        Me.splMain.AccessibleDescription = Nothing
        Me.splMain.AccessibleName = Nothing
        Me.splMain.AllowDrop = True
        resources.ApplyResources(Me.splMain, "splMain")
        Me.splMain.BackgroundImage = Nothing
        Me.splMain.Font = Nothing
        Me.splMain.MinimumSize = New System.Drawing.Size(100, 92)
        Me.splMain.Name = "splMain"
        '
        'splMain.Panel1
        '
        Me.splMain.Panel1.AccessibleDescription = Nothing
        Me.splMain.Panel1.AccessibleName = Nothing
        resources.ApplyResources(Me.splMain.Panel1, "splMain.Panel1")
        Me.splMain.Panel1.BackgroundImage = Nothing
        Me.splMain.Panel1.Controls.Add(Me.grpFolders)
        Me.splMain.Panel1.Font = Nothing
        '
        'splMain.Panel2
        '
        Me.splMain.Panel2.AccessibleDescription = Nothing
        Me.splMain.Panel2.AccessibleName = Nothing
        resources.ApplyResources(Me.splMain.Panel2, "splMain.Panel2")
        Me.splMain.Panel2.BackgroundImage = Nothing
        Me.splMain.Panel2.Controls.Add(Me.splFiles)
        Me.splMain.Panel2.Font = Nothing
        '
        'grpFolders
        '
        Me.grpFolders.AccessibleDescription = Nothing
        Me.grpFolders.AccessibleName = Nothing
        resources.ApplyResources(Me.grpFolders, "grpFolders")
        Me.grpFolders.BackgroundImage = Nothing
        Me.grpFolders.Controls.Add(Me.trvFolders)
        Me.grpFolders.Font = Nothing
        Me.grpFolders.Name = "grpFolders"
        Me.grpFolders.TabStop = False
        '
        'trvFolders
        '
        Me.trvFolders.AccessibleDescription = Nothing
        Me.trvFolders.AccessibleName = Nothing
        resources.ApplyResources(Me.trvFolders, "trvFolders")
        Me.trvFolders.BackgroundImage = Nothing
        Me.trvFolders.Font = Nothing
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
        Me.splFiles.AccessibleDescription = Nothing
        Me.splFiles.AccessibleName = Nothing
        resources.ApplyResources(Me.splFiles, "splFiles")
        Me.splFiles.BackgroundImage = Nothing
        Me.splFiles.Font = Nothing
        Me.splFiles.MinimumSize = New System.Drawing.Size(100, 92)
        Me.splFiles.Name = "splFiles"
        '
        'splFiles.Panel1
        '
        Me.splFiles.Panel1.AccessibleDescription = Nothing
        Me.splFiles.Panel1.AccessibleName = Nothing
        resources.ApplyResources(Me.splFiles.Panel1, "splFiles.Panel1")
        Me.splFiles.Panel1.BackgroundImage = Nothing
        Me.splFiles.Panel1.Controls.Add(Me.grpFiles)
        Me.splFiles.Panel1.Font = Nothing
        '
        'splFiles.Panel2
        '
        Me.splFiles.Panel2.AccessibleDescription = Nothing
        Me.splFiles.Panel2.AccessibleName = Nothing
        resources.ApplyResources(Me.splFiles.Panel2, "splFiles.Panel2")
        Me.splFiles.Panel2.BackgroundImage = Nothing
        Me.splFiles.Panel2.Controls.Add(Me.grpDetails)
        Me.splFiles.Panel2.Font = Nothing
        '
        'grpFiles
        '
        Me.grpFiles.AccessibleDescription = Nothing
        Me.grpFiles.AccessibleName = Nothing
        resources.ApplyResources(Me.grpFiles, "grpFiles")
        Me.grpFiles.BackgroundImage = Nothing
        Me.grpFiles.Controls.Add(Me.lstFiles)
        Me.grpFiles.Font = Nothing
        Me.grpFiles.Name = "grpFiles"
        Me.grpFiles.TabStop = False
        '
        'lstFiles
        '
        Me.lstFiles.AccessibleDescription = Nothing
        Me.lstFiles.AccessibleName = Nothing
        resources.ApplyResources(Me.lstFiles, "lstFiles")
        Me.lstFiles.AllowColumnReorder = True
        Me.lstFiles.AllowDrop = True
        Me.lstFiles.BackgroundImage = Nothing
        Me.lstFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cohFilename, Me.cohSize, Me.cohFiletype})
        Me.lstFiles.ContextMenuStrip = Me.menuRightClickFiles
        Me.lstFiles.Font = Nothing
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
        Me.menuRightClickFiles.AccessibleDescription = Nothing
        Me.menuRightClickFiles.AccessibleName = Nothing
        resources.ApplyResources(Me.menuRightClickFiles, "menuRightClickFiles")
        Me.menuRightClickFiles.BackgroundImage = Nothing
        Me.menuRightClickFiles.Font = Nothing
        Me.menuRightClickFiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuRightSaveAs, Me.ToolStripSeparator2, Me.menuRightBackupFile, Me.menuRightRestoreFile, Me.ToolStripSeparator1, Me.cmdRenameFile, Me.menuRightReplaceFile, Me.menuRightDeleteFile})
        Me.menuRightClickFiles.Name = "menuRightClickFiles"
        '
        'menuRightSaveAs
        '
        Me.menuRightSaveAs.AccessibleDescription = Nothing
        Me.menuRightSaveAs.AccessibleName = Nothing
        resources.ApplyResources(Me.menuRightSaveAs, "menuRightSaveAs")
        Me.menuRightSaveAs.BackgroundImage = Nothing
        Me.menuRightSaveAs.Name = "menuRightSaveAs"
        Me.menuRightSaveAs.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AccessibleDescription = Nothing
        Me.ToolStripSeparator2.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        '
        'menuRightBackupFile
        '
        Me.menuRightBackupFile.AccessibleDescription = Nothing
        Me.menuRightBackupFile.AccessibleName = Nothing
        resources.ApplyResources(Me.menuRightBackupFile, "menuRightBackupFile")
        Me.menuRightBackupFile.BackgroundImage = Nothing
        Me.menuRightBackupFile.Name = "menuRightBackupFile"
        Me.menuRightBackupFile.ShortcutKeyDisplayString = Nothing
        '
        'menuRightRestoreFile
        '
        Me.menuRightRestoreFile.AccessibleDescription = Nothing
        Me.menuRightRestoreFile.AccessibleName = Nothing
        resources.ApplyResources(Me.menuRightRestoreFile, "menuRightRestoreFile")
        Me.menuRightRestoreFile.BackgroundImage = Nothing
        Me.menuRightRestoreFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemLoading})
        Me.menuRightRestoreFile.Name = "menuRightRestoreFile"
        Me.menuRightRestoreFile.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripMenuItemLoading
        '
        Me.ToolStripMenuItemLoading.AccessibleDescription = Nothing
        Me.ToolStripMenuItemLoading.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItemLoading, "ToolStripMenuItemLoading")
        Me.ToolStripMenuItemLoading.BackgroundImage = Nothing
        Me.ToolStripMenuItemLoading.Name = "ToolStripMenuItemLoading"
        Me.ToolStripMenuItemLoading.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AccessibleDescription = Nothing
        Me.ToolStripSeparator1.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'cmdRenameFile
        '
        Me.cmdRenameFile.AccessibleDescription = Nothing
        Me.cmdRenameFile.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdRenameFile, "cmdRenameFile")
        Me.cmdRenameFile.BackgroundImage = Nothing
        Me.cmdRenameFile.Name = "cmdRenameFile"
        Me.cmdRenameFile.ShortcutKeyDisplayString = Nothing
        '
        'menuRightReplaceFile
        '
        Me.menuRightReplaceFile.AccessibleDescription = Nothing
        Me.menuRightReplaceFile.AccessibleName = Nothing
        resources.ApplyResources(Me.menuRightReplaceFile, "menuRightReplaceFile")
        Me.menuRightReplaceFile.BackgroundImage = Nothing
        Me.menuRightReplaceFile.Name = "menuRightReplaceFile"
        Me.menuRightReplaceFile.ShortcutKeyDisplayString = Nothing
        '
        'menuRightDeleteFile
        '
        Me.menuRightDeleteFile.AccessibleDescription = Nothing
        Me.menuRightDeleteFile.AccessibleName = Nothing
        resources.ApplyResources(Me.menuRightDeleteFile, "menuRightDeleteFile")
        Me.menuRightDeleteFile.BackgroundImage = Nothing
        Me.menuRightDeleteFile.Name = "menuRightDeleteFile"
        Me.menuRightDeleteFile.ShortcutKeyDisplayString = Nothing
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
        Me.grpDetails.AccessibleDescription = Nothing
        Me.grpDetails.AccessibleName = Nothing
        resources.ApplyResources(Me.grpDetails, "grpDetails")
        Me.grpDetails.BackgroundImage = Nothing
        Me.grpDetails.Controls.Add(Me.Panel1)
        Me.grpDetails.Controls.Add(Me.txtFileDetails)
        Me.grpDetails.Controls.Add(Me.WebBrws)
        Me.grpDetails.Controls.Add(Me.qtPlugin)
        Me.grpDetails.Controls.Add(Me.picFileDetails)
        Me.grpDetails.Font = Nothing
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.AccessibleDescription = Nothing
        Me.Panel1.AccessibleName = Nothing
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BackgroundImage = Nothing
        Me.Panel1.Controls.Add(Me.btnPreview)
        Me.Panel1.Controls.Add(Me.chkPreviewEnabled)
        Me.Panel1.Font = Nothing
        Me.Panel1.Name = "Panel1"
        '
        'btnPreview
        '
        Me.btnPreview.AccessibleDescription = Nothing
        Me.btnPreview.AccessibleName = Nothing
        resources.ApplyResources(Me.btnPreview, "btnPreview")
        Me.btnPreview.BackgroundImage = Nothing
        Me.btnPreview.Font = Nothing
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.TabStop = False
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'chkPreviewEnabled
        '
        Me.chkPreviewEnabled.AccessibleDescription = Nothing
        Me.chkPreviewEnabled.AccessibleName = Nothing
        resources.ApplyResources(Me.chkPreviewEnabled, "chkPreviewEnabled")
        Me.chkPreviewEnabled.BackgroundImage = Nothing
        Me.chkPreviewEnabled.Checked = Global.iPhoneBrowser.itouchBrowser.My.MySettings.Default.ShowPreviews
        Me.chkPreviewEnabled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPreviewEnabled.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.iPhoneBrowser.itouchBrowser.My.MySettings.Default, "ShowPreviews", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkPreviewEnabled.Font = Nothing
        Me.chkPreviewEnabled.Name = "chkPreviewEnabled"
        Me.chkPreviewEnabled.TabStop = False
        Me.chkPreviewEnabled.UseVisualStyleBackColor = True
        '
        'picFileDetails
        '
        Me.picFileDetails.AccessibleDescription = Nothing
        Me.picFileDetails.AccessibleName = Nothing
        resources.ApplyResources(Me.picFileDetails, "picFileDetails")
        Me.picFileDetails.BackColor = System.Drawing.SystemColors.Control
        Me.picFileDetails.BackgroundImage = Nothing
        Me.picFileDetails.Font = Nothing
        Me.picFileDetails.Name = "picFileDetails"
        Me.picFileDetails.TabStop = False
        '
        'txtFileDetails
        '
        Me.txtFileDetails.AccessibleDescription = Nothing
        Me.txtFileDetails.AccessibleName = Nothing
        resources.ApplyResources(Me.txtFileDetails, "txtFileDetails")
        Me.txtFileDetails.BackgroundImage = Nothing
        Me.txtFileDetails.Name = "txtFileDetails"
        Me.txtFileDetails.ReadOnly = True
        '
        'WebBrws
        '
        Me.WebBrws.AccessibleDescription = Nothing
        Me.WebBrws.AccessibleName = Nothing
        resources.ApplyResources(Me.WebBrws, "WebBrws")
        Me.WebBrws.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrws.Name = "WebBrws"
        '
        'qtPlugin
        '
        Me.qtPlugin.AccessibleDescription = Nothing
        Me.qtPlugin.AccessibleName = Nothing
        resources.ApplyResources(Me.qtPlugin, "qtPlugin")
        Me.qtPlugin.Font = Nothing
        Me.qtPlugin.Name = "qtPlugin"
        Me.qtPlugin.OcxState = CType(resources.GetObject("qtPlugin.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'tlbStatusStrip
        '
        Me.tlbStatusStrip.AccessibleDescription = Nothing
        Me.tlbStatusStrip.AccessibleName = Nothing
        resources.ApplyResources(Me.tlbStatusStrip, "tlbStatusStrip")
        Me.tlbStatusStrip.BackgroundImage = Nothing
        Me.tlbStatusStrip.Font = Nothing
        Me.tlbStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlbStatusLabel, Me.BtnCancel, Me.tlbProgress0, Me.tlbProgressBar})
        Me.tlbStatusStrip.Name = "tlbStatusStrip"
        Me.tlbStatusStrip.ShowItemToolTips = True
        '
        'tlbStatusLabel
        '
        Me.tlbStatusLabel.AccessibleDescription = Nothing
        Me.tlbStatusLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.tlbStatusLabel, "tlbStatusLabel")
        Me.tlbStatusLabel.BackgroundImage = Nothing
        Me.tlbStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.tlbStatusLabel.Image = Global.iPhoneBrowser.itouchBrowser.My.Resources.Resources.warning
        Me.tlbStatusLabel.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.tlbStatusLabel.Name = "tlbStatusLabel"
        Me.tlbStatusLabel.Spring = True
        '
        'BtnCancel
        '
        Me.BtnCancel.AccessibleDescription = Nothing
        Me.BtnCancel.AccessibleName = Nothing
        Me.BtnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        resources.ApplyResources(Me.BtnCancel, "BtnCancel")
        Me.BtnCancel.BackgroundImage = Nothing
        Me.BtnCancel.MergeIndex = 0
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.ShowDropDownArrow = False
        '
        'tlbProgress0
        '
        Me.tlbProgress0.AccessibleDescription = Nothing
        Me.tlbProgress0.AccessibleName = Nothing
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
        Me.tlbProgressBar.AccessibleDescription = Nothing
        Me.tlbProgressBar.AccessibleName = Nothing
        Me.tlbProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        resources.ApplyResources(Me.tlbProgressBar, "tlbProgressBar")
        Me.tlbProgressBar.Margin = New System.Windows.Forms.Padding(0, 4, 10, 4)
        Me.tlbProgressBar.MergeIndex = 2
        Me.tlbProgressBar.Name = "tlbProgressBar"
        Me.tlbProgressBar.Step = 1
        '
        'toolStrip
        '
        Me.toolStrip.AccessibleDescription = Nothing
        Me.toolStrip.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStrip, "toolStrip")
        Me.toolStrip.BackgroundImage = Nothing
        Me.toolStrip.Font = Nothing
        Me.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemFile, Me.mnuView, Me.mnuGoTo, Me.mnuFavorites, Me.ToolStripDropDownButton2, Me.ToolStripDropDownButton1})
        Me.toolStrip.Name = "toolStrip"
        '
        'ToolStripMenuItemFile
        '
        Me.ToolStripMenuItemFile.AccessibleDescription = Nothing
        Me.ToolStripMenuItemFile.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItemFile, "ToolStripMenuItemFile")
        Me.ToolStripMenuItemFile.BackgroundImage = Nothing
        Me.ToolStripMenuItemFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripMenuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCleanUp, Me.ToolStripMenuItemViewBackups, Me.ToolStripSeparator7, Me.menuSaveSummerboardTheme, Me.ToolStripMenuItem4, Me.ToolStripSeparator3, Me.ToolStripMenuItemExit})
        Me.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile"
        '
        'ToolStripMenuItemCleanUp
        '
        Me.ToolStripMenuItemCleanUp.AccessibleDescription = Nothing
        Me.ToolStripMenuItemCleanUp.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItemCleanUp, "ToolStripMenuItemCleanUp")
        Me.ToolStripMenuItemCleanUp.BackgroundImage = Nothing
        Me.ToolStripMenuItemCleanUp.Name = "ToolStripMenuItemCleanUp"
        Me.ToolStripMenuItemCleanUp.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripMenuItemViewBackups
        '
        Me.ToolStripMenuItemViewBackups.AccessibleDescription = Nothing
        Me.ToolStripMenuItemViewBackups.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItemViewBackups, "ToolStripMenuItemViewBackups")
        Me.ToolStripMenuItemViewBackups.BackgroundImage = Nothing
        Me.ToolStripMenuItemViewBackups.Name = "ToolStripMenuItemViewBackups"
        Me.ToolStripMenuItemViewBackups.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.AccessibleDescription = Nothing
        Me.ToolStripSeparator7.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        '
        'menuSaveSummerboardTheme
        '
        Me.menuSaveSummerboardTheme.AccessibleDescription = Nothing
        Me.menuSaveSummerboardTheme.AccessibleName = Nothing
        resources.ApplyResources(Me.menuSaveSummerboardTheme, "menuSaveSummerboardTheme")
        Me.menuSaveSummerboardTheme.BackgroundImage = Nothing
        Me.menuSaveSummerboardTheme.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsSummerboardFolderToolStripMenuItem, Me.AsPXLPackageToolStripMenuItem})
        Me.menuSaveSummerboardTheme.Name = "menuSaveSummerboardTheme"
        Me.menuSaveSummerboardTheme.ShortcutKeyDisplayString = Nothing
        '
        'AsSummerboardFolderToolStripMenuItem
        '
        Me.AsSummerboardFolderToolStripMenuItem.AccessibleDescription = Nothing
        Me.AsSummerboardFolderToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.AsSummerboardFolderToolStripMenuItem, "AsSummerboardFolderToolStripMenuItem")
        Me.AsSummerboardFolderToolStripMenuItem.BackgroundImage = Nothing
        Me.AsSummerboardFolderToolStripMenuItem.Name = "AsSummerboardFolderToolStripMenuItem"
        Me.AsSummerboardFolderToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'AsPXLPackageToolStripMenuItem
        '
        Me.AsPXLPackageToolStripMenuItem.AccessibleDescription = Nothing
        Me.AsPXLPackageToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.AsPXLPackageToolStripMenuItem, "AsPXLPackageToolStripMenuItem")
        Me.AsPXLPackageToolStripMenuItem.BackgroundImage = Nothing
        Me.AsPXLPackageToolStripMenuItem.Name = "AsPXLPackageToolStripMenuItem"
        Me.AsPXLPackageToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.AccessibleDescription = Nothing
        Me.ToolStripMenuItem4.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        Me.ToolStripMenuItem4.BackgroundImage = Nothing
        Me.ToolStripMenuItem4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsCustomizeFoldersToolStripMenuItem, Me.AsPXLPackageToolStripMenuItem1})
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.ShortcutKeyDisplayString = Nothing
        '
        'AsCustomizeFoldersToolStripMenuItem
        '
        Me.AsCustomizeFoldersToolStripMenuItem.AccessibleDescription = Nothing
        Me.AsCustomizeFoldersToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.AsCustomizeFoldersToolStripMenuItem, "AsCustomizeFoldersToolStripMenuItem")
        Me.AsCustomizeFoldersToolStripMenuItem.BackgroundImage = Nothing
        Me.AsCustomizeFoldersToolStripMenuItem.Name = "AsCustomizeFoldersToolStripMenuItem"
        Me.AsCustomizeFoldersToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'AsPXLPackageToolStripMenuItem1
        '
        Me.AsPXLPackageToolStripMenuItem1.AccessibleDescription = Nothing
        Me.AsPXLPackageToolStripMenuItem1.AccessibleName = Nothing
        resources.ApplyResources(Me.AsPXLPackageToolStripMenuItem1, "AsPXLPackageToolStripMenuItem1")
        Me.AsPXLPackageToolStripMenuItem1.BackgroundImage = Nothing
        Me.AsPXLPackageToolStripMenuItem1.Name = "AsPXLPackageToolStripMenuItem1"
        Me.AsPXLPackageToolStripMenuItem1.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.AccessibleDescription = Nothing
        Me.ToolStripSeparator3.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        '
        'ToolStripMenuItemExit
        '
        Me.ToolStripMenuItemExit.AccessibleDescription = Nothing
        Me.ToolStripMenuItemExit.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItemExit, "ToolStripMenuItemExit")
        Me.ToolStripMenuItemExit.BackgroundImage = Nothing
        Me.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit"
        Me.ToolStripMenuItemExit.ShortcutKeyDisplayString = Nothing
        '
        'mnuView
        '
        Me.mnuView.AccessibleDescription = Nothing
        Me.mnuView.AccessibleName = Nothing
        resources.ApplyResources(Me.mnuView, "mnuView")
        Me.mnuView.BackgroundImage = Nothing
        Me.mnuView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemDetails, Me.ToolStripMenuItemLargeIcons, Me.cmdSmallIcons, Me.ToolStripMenuItem8, Me.cmdShowGroups})
        Me.mnuView.Name = "mnuView"
        '
        'ToolStripMenuItemDetails
        '
        Me.ToolStripMenuItemDetails.AccessibleDescription = Nothing
        Me.ToolStripMenuItemDetails.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItemDetails, "ToolStripMenuItemDetails")
        Me.ToolStripMenuItemDetails.BackgroundImage = Nothing
        Me.ToolStripMenuItemDetails.Checked = True
        Me.ToolStripMenuItemDetails.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItemDetails.Name = "ToolStripMenuItemDetails"
        Me.ToolStripMenuItemDetails.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripMenuItemLargeIcons
        '
        Me.ToolStripMenuItemLargeIcons.AccessibleDescription = Nothing
        Me.ToolStripMenuItemLargeIcons.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItemLargeIcons, "ToolStripMenuItemLargeIcons")
        Me.ToolStripMenuItemLargeIcons.BackgroundImage = Nothing
        Me.ToolStripMenuItemLargeIcons.Name = "ToolStripMenuItemLargeIcons"
        Me.ToolStripMenuItemLargeIcons.ShortcutKeyDisplayString = Nothing
        '
        'cmdSmallIcons
        '
        Me.cmdSmallIcons.AccessibleDescription = Nothing
        Me.cmdSmallIcons.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdSmallIcons, "cmdSmallIcons")
        Me.cmdSmallIcons.BackgroundImage = Nothing
        Me.cmdSmallIcons.Name = "cmdSmallIcons"
        Me.cmdSmallIcons.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.AccessibleDescription = Nothing
        Me.ToolStripMenuItem8.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItem8, "ToolStripMenuItem8")
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        '
        'cmdShowGroups
        '
        Me.cmdShowGroups.AccessibleDescription = Nothing
        Me.cmdShowGroups.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdShowGroups, "cmdShowGroups")
        Me.cmdShowGroups.BackgroundImage = Nothing
        Me.cmdShowGroups.Checked = Global.iPhoneBrowser.itouchBrowser.My.MySettings.Default.ShowGroups
        Me.cmdShowGroups.CheckOnClick = True
        Me.cmdShowGroups.Name = "cmdShowGroups"
        Me.cmdShowGroups.ShortcutKeyDisplayString = Nothing
        '
        'mnuGoTo
        '
        Me.mnuGoTo.AccessibleDescription = Nothing
        Me.mnuGoTo.AccessibleName = Nothing
        resources.ApplyResources(Me.mnuGoTo, "mnuGoTo")
        Me.mnuGoTo.BackgroundImage = Nothing
        Me.mnuGoTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuGoTo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripGoTo1, Me.toolStripGoTo2, Me.ToolStripSeparator5, Me.toolStripGoTo3, Me.ToolStripMenuItem2, Me.ToolStripSeparator4, Me.mnuStdApps, Me.mnuThirdPartyApps, Me.ToolStripSeparator6, Me.CameraRollToolStripMenuItem, Me.toolStripGoTo19})
        Me.mnuGoTo.Name = "mnuGoTo"
        Me.mnuGoTo.Tag = "ar"
        '
        'toolStripGoTo1
        '
        Me.toolStripGoTo1.AccessibleDescription = Nothing
        Me.toolStripGoTo1.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo1, "toolStripGoTo1")
        Me.toolStripGoTo1.BackgroundImage = Nothing
        Me.toolStripGoTo1.Name = "toolStripGoTo1"
        Me.toolStripGoTo1.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo1.Tag = "/Library/Ringtones"
        '
        'toolStripGoTo2
        '
        Me.toolStripGoTo2.AccessibleDescription = Nothing
        Me.toolStripGoTo2.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo2, "toolStripGoTo2")
        Me.toolStripGoTo2.BackgroundImage = Nothing
        Me.toolStripGoTo2.Name = "toolStripGoTo2"
        Me.toolStripGoTo2.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo2.Tag = "/System/Library/Audio/UISounds"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.AccessibleDescription = Nothing
        Me.ToolStripSeparator5.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        '
        'toolStripGoTo3
        '
        Me.toolStripGoTo3.AccessibleDescription = Nothing
        Me.toolStripGoTo3.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo3, "toolStripGoTo3")
        Me.toolStripGoTo3.BackgroundImage = Nothing
        Me.toolStripGoTo3.Name = "toolStripGoTo3"
        Me.toolStripGoTo3.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo3.Tag = "/System/Library/CoreServices/SpringBoard.app"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.AccessibleDescription = Nothing
        Me.ToolStripMenuItem2.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        Me.ToolStripMenuItem2.BackgroundImage = Nothing
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.ShortcutKeyDisplayString = Nothing
        Me.ToolStripMenuItem2.Tag = "/var/root/Library/Summerboard/Themes"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.AccessibleDescription = Nothing
        Me.ToolStripSeparator4.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        '
        'mnuStdApps
        '
        Me.mnuStdApps.AccessibleDescription = Nothing
        Me.mnuStdApps.AccessibleName = Nothing
        resources.ApplyResources(Me.mnuStdApps, "mnuStdApps")
        Me.mnuStdApps.BackgroundImage = Nothing
        Me.mnuStdApps.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripGoTo20, Me.toolStripGoTo4, Me.toolStripGoTo6, Me.toolStripGoTo13, Me.toolStripGoTo14, Me.toolStripGoTo8, Me.toolStripGoTo7, Me.toolStripGoTo5, Me.toolStripGoTo9, Me.toolStripGoTo10, Me.toolStripGoTo12, Me.toolStripGoTo15, Me.toolStripGoTo11, Me.toolStripGoTo16, Me.toolStripGoTo17, Me.toolStripGoTo18})
        Me.mnuStdApps.Name = "mnuStdApps"
        Me.mnuStdApps.ShortcutKeyDisplayString = Nothing
        '
        'toolStripGoTo20
        '
        Me.toolStripGoTo20.AccessibleDescription = Nothing
        Me.toolStripGoTo20.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo20, "toolStripGoTo20")
        Me.toolStripGoTo20.BackgroundImage = Nothing
        Me.toolStripGoTo20.Name = "toolStripGoTo20"
        Me.toolStripGoTo20.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo20.Tag = "/var/mobile/Media/iTunes_Control/Music"
        '
        'toolStripGoTo4
        '
        Me.toolStripGoTo4.AccessibleDescription = Nothing
        Me.toolStripGoTo4.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo4, "toolStripGoTo4")
        Me.toolStripGoTo4.BackgroundImage = Nothing
        Me.toolStripGoTo4.Name = "toolStripGoTo4"
        Me.toolStripGoTo4.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo4.Tag = "/Applications/Calculator.app"
        '
        'toolStripGoTo6
        '
        Me.toolStripGoTo6.AccessibleDescription = Nothing
        Me.toolStripGoTo6.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo6, "toolStripGoTo6")
        Me.toolStripGoTo6.BackgroundImage = Nothing
        Me.toolStripGoTo6.Name = "toolStripGoTo6"
        Me.toolStripGoTo6.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo6.Tag = "/Applications/MobileCal.app"
        '
        'toolStripGoTo13
        '
        Me.toolStripGoTo13.AccessibleDescription = Nothing
        Me.toolStripGoTo13.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo13, "toolStripGoTo13")
        Me.toolStripGoTo13.BackgroundImage = Nothing
        Me.toolStripGoTo13.Name = "toolStripGoTo13"
        Me.toolStripGoTo13.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo13.Tag = "/Applications/MobileSlideShow.app"
        '
        'toolStripGoTo14
        '
        Me.toolStripGoTo14.AccessibleDescription = Nothing
        Me.toolStripGoTo14.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo14, "toolStripGoTo14")
        Me.toolStripGoTo14.BackgroundImage = Nothing
        Me.toolStripGoTo14.Name = "toolStripGoTo14"
        Me.toolStripGoTo14.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo14.Tag = "/Applications/MobileTimer.app"
        '
        'toolStripGoTo8
        '
        Me.toolStripGoTo8.AccessibleDescription = Nothing
        Me.toolStripGoTo8.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo8, "toolStripGoTo8")
        Me.toolStripGoTo8.BackgroundImage = Nothing
        Me.toolStripGoTo8.Name = "toolStripGoTo8"
        Me.toolStripGoTo8.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo8.Tag = "/Applications/MobileMusicPlayer.app"
        '
        'toolStripGoTo7
        '
        Me.toolStripGoTo7.AccessibleDescription = Nothing
        Me.toolStripGoTo7.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo7, "toolStripGoTo7")
        Me.toolStripGoTo7.BackgroundImage = Nothing
        Me.toolStripGoTo7.Name = "toolStripGoTo7"
        Me.toolStripGoTo7.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo7.Tag = "/Applications/MobileMail.app"
        '
        'toolStripGoTo5
        '
        Me.toolStripGoTo5.AccessibleDescription = Nothing
        Me.toolStripGoTo5.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo5, "toolStripGoTo5")
        Me.toolStripGoTo5.BackgroundImage = Nothing
        Me.toolStripGoTo5.Name = "toolStripGoTo5"
        Me.toolStripGoTo5.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo5.Tag = "/Applications/Maps.app"
        '
        'toolStripGoTo9
        '
        Me.toolStripGoTo9.AccessibleDescription = Nothing
        Me.toolStripGoTo9.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo9, "toolStripGoTo9")
        Me.toolStripGoTo9.BackgroundImage = Nothing
        Me.toolStripGoTo9.Name = "toolStripGoTo9"
        Me.toolStripGoTo9.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo9.Tag = "/Applications/MobileNotes.app"
        '
        'toolStripGoTo10
        '
        Me.toolStripGoTo10.AccessibleDescription = Nothing
        Me.toolStripGoTo10.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo10, "toolStripGoTo10")
        Me.toolStripGoTo10.BackgroundImage = Nothing
        Me.toolStripGoTo10.Name = "toolStripGoTo10"
        Me.toolStripGoTo10.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo10.Tag = "/Applications/MobilePhone.app"
        '
        'toolStripGoTo12
        '
        Me.toolStripGoTo12.AccessibleDescription = Nothing
        Me.toolStripGoTo12.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo12, "toolStripGoTo12")
        Me.toolStripGoTo12.BackgroundImage = Nothing
        Me.toolStripGoTo12.Name = "toolStripGoTo12"
        Me.toolStripGoTo12.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo12.Tag = "/Applications/MobileSafari.app"
        '
        'toolStripGoTo15
        '
        Me.toolStripGoTo15.AccessibleDescription = Nothing
        Me.toolStripGoTo15.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo15, "toolStripGoTo15")
        Me.toolStripGoTo15.BackgroundImage = Nothing
        Me.toolStripGoTo15.Name = "toolStripGoTo15"
        Me.toolStripGoTo15.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo15.Tag = "/Applications/Preferences.app"
        '
        'toolStripGoTo11
        '
        Me.toolStripGoTo11.AccessibleDescription = Nothing
        Me.toolStripGoTo11.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo11, "toolStripGoTo11")
        Me.toolStripGoTo11.BackgroundImage = Nothing
        Me.toolStripGoTo11.Name = "toolStripGoTo11"
        Me.toolStripGoTo11.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo11.Tag = "/Applications/MobileSMS.app"
        '
        'toolStripGoTo16
        '
        Me.toolStripGoTo16.AccessibleDescription = Nothing
        Me.toolStripGoTo16.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo16, "toolStripGoTo16")
        Me.toolStripGoTo16.BackgroundImage = Nothing
        Me.toolStripGoTo16.Name = "toolStripGoTo16"
        Me.toolStripGoTo16.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo16.Tag = "/Applications/Stocks.app"
        '
        'toolStripGoTo17
        '
        Me.toolStripGoTo17.AccessibleDescription = Nothing
        Me.toolStripGoTo17.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo17, "toolStripGoTo17")
        Me.toolStripGoTo17.BackgroundImage = Nothing
        Me.toolStripGoTo17.Name = "toolStripGoTo17"
        Me.toolStripGoTo17.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo17.Tag = "/Applications/Weather.app"
        '
        'toolStripGoTo18
        '
        Me.toolStripGoTo18.AccessibleDescription = Nothing
        Me.toolStripGoTo18.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo18, "toolStripGoTo18")
        Me.toolStripGoTo18.BackgroundImage = Nothing
        Me.toolStripGoTo18.Name = "toolStripGoTo18"
        Me.toolStripGoTo18.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo18.Tag = "/Applications/YouTube.app"
        '
        'mnuThirdPartyApps
        '
        Me.mnuThirdPartyApps.AccessibleDescription = Nothing
        Me.mnuThirdPartyApps.AccessibleName = Nothing
        resources.ApplyResources(Me.mnuThirdPartyApps, "mnuThirdPartyApps")
        Me.mnuThirdPartyApps.BackgroundImage = Nothing
        Me.mnuThirdPartyApps.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.DockSwapDocksToolStripMenuItem, Me.EBooksToolStripMenuItem, Me.FrotzGamesToolStripMenuItem, Me.cmdGBAROMs, Me.ToolStripMenuItem6, Me.InstallerPackageSourcesToolStripMenuItem, Me.ISwitcherThemesToolStripMenuItem, Me.NESROMSToolStripMenuItem, Me.TTRToolStripMenuItem, Me.WeDictDictionariesToolStripMenuItem})
        Me.mnuThirdPartyApps.Name = "mnuThirdPartyApps"
        Me.mnuThirdPartyApps.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.AccessibleDescription = Nothing
        Me.ToolStripMenuItem5.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItem5, "ToolStripMenuItem5")
        Me.ToolStripMenuItem5.BackgroundImage = Nothing
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.ShortcutKeyDisplayString = Nothing
        Me.ToolStripMenuItem5.Tag = "/var/root/Library/Customize"
        '
        'DockSwapDocksToolStripMenuItem
        '
        Me.DockSwapDocksToolStripMenuItem.AccessibleDescription = Nothing
        Me.DockSwapDocksToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.DockSwapDocksToolStripMenuItem, "DockSwapDocksToolStripMenuItem")
        Me.DockSwapDocksToolStripMenuItem.BackgroundImage = Nothing
        Me.DockSwapDocksToolStripMenuItem.Name = "DockSwapDocksToolStripMenuItem"
        Me.DockSwapDocksToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        Me.DockSwapDocksToolStripMenuItem.Tag = "/var/root/Library/DockSwap"
        '
        'EBooksToolStripMenuItem
        '
        Me.EBooksToolStripMenuItem.AccessibleDescription = Nothing
        Me.EBooksToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.EBooksToolStripMenuItem, "EBooksToolStripMenuItem")
        Me.EBooksToolStripMenuItem.BackgroundImage = Nothing
        Me.EBooksToolStripMenuItem.Name = "EBooksToolStripMenuItem"
        Me.EBooksToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        Me.EBooksToolStripMenuItem.Tag = "/var/root/Media/EBooks"
        '
        'FrotzGamesToolStripMenuItem
        '
        Me.FrotzGamesToolStripMenuItem.AccessibleDescription = Nothing
        Me.FrotzGamesToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.FrotzGamesToolStripMenuItem, "FrotzGamesToolStripMenuItem")
        Me.FrotzGamesToolStripMenuItem.BackgroundImage = Nothing
        Me.FrotzGamesToolStripMenuItem.Name = "FrotzGamesToolStripMenuItem"
        Me.FrotzGamesToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        Me.FrotzGamesToolStripMenuItem.Tag = "/var/root/Media/Frotz/Games"
        '
        'cmdGBAROMs
        '
        Me.cmdGBAROMs.AccessibleDescription = Nothing
        Me.cmdGBAROMs.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdGBAROMs, "cmdGBAROMs")
        Me.cmdGBAROMs.BackgroundImage = Nothing
        Me.cmdGBAROMs.Name = "cmdGBAROMs"
        Me.cmdGBAROMs.ShortcutKeyDisplayString = Nothing
        Me.cmdGBAROMs.Tag = "/var/root/Media/ROMs/GBA"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.AccessibleDescription = Nothing
        Me.ToolStripMenuItem6.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItem6, "ToolStripMenuItem6")
        Me.ToolStripMenuItem6.BackgroundImage = Nothing
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.ShortcutKeyDisplayString = Nothing
        Me.ToolStripMenuItem6.Tag = "/var/root/Library/iFlashCards"
        '
        'InstallerPackageSourcesToolStripMenuItem
        '
        Me.InstallerPackageSourcesToolStripMenuItem.AccessibleDescription = Nothing
        Me.InstallerPackageSourcesToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.InstallerPackageSourcesToolStripMenuItem, "InstallerPackageSourcesToolStripMenuItem")
        Me.InstallerPackageSourcesToolStripMenuItem.BackgroundImage = Nothing
        Me.InstallerPackageSourcesToolStripMenuItem.Name = "InstallerPackageSourcesToolStripMenuItem"
        Me.InstallerPackageSourcesToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        Me.InstallerPackageSourcesToolStripMenuItem.Tag = "/var/root/Library/Installer"
        '
        'ISwitcherThemesToolStripMenuItem
        '
        Me.ISwitcherThemesToolStripMenuItem.AccessibleDescription = Nothing
        Me.ISwitcherThemesToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.ISwitcherThemesToolStripMenuItem, "ISwitcherThemesToolStripMenuItem")
        Me.ISwitcherThemesToolStripMenuItem.BackgroundImage = Nothing
        Me.ISwitcherThemesToolStripMenuItem.Name = "ISwitcherThemesToolStripMenuItem"
        Me.ISwitcherThemesToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        Me.ISwitcherThemesToolStripMenuItem.Tag = "/var/root/Media/Themes"
        '
        'NESROMSToolStripMenuItem
        '
        Me.NESROMSToolStripMenuItem.AccessibleDescription = Nothing
        Me.NESROMSToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.NESROMSToolStripMenuItem, "NESROMSToolStripMenuItem")
        Me.NESROMSToolStripMenuItem.BackgroundImage = Nothing
        Me.NESROMSToolStripMenuItem.Name = "NESROMSToolStripMenuItem"
        Me.NESROMSToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        Me.NESROMSToolStripMenuItem.Tag = "/var/root/Media/ROMs/NES"
        '
        'TTRToolStripMenuItem
        '
        Me.TTRToolStripMenuItem.AccessibleDescription = Nothing
        Me.TTRToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.TTRToolStripMenuItem, "TTRToolStripMenuItem")
        Me.TTRToolStripMenuItem.BackgroundImage = Nothing
        Me.TTRToolStripMenuItem.Name = "TTRToolStripMenuItem"
        Me.TTRToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        Me.TTRToolStripMenuItem.Tag = "/var/root/Media/TTR"
        '
        'WeDictDictionariesToolStripMenuItem
        '
        Me.WeDictDictionariesToolStripMenuItem.AccessibleDescription = Nothing
        Me.WeDictDictionariesToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.WeDictDictionariesToolStripMenuItem, "WeDictDictionariesToolStripMenuItem")
        Me.WeDictDictionariesToolStripMenuItem.BackgroundImage = Nothing
        Me.WeDictDictionariesToolStripMenuItem.Name = "WeDictDictionariesToolStripMenuItem"
        Me.WeDictDictionariesToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        Me.WeDictDictionariesToolStripMenuItem.Tag = "/var/root/Libary/weDict"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.AccessibleDescription = Nothing
        Me.ToolStripSeparator6.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        '
        'CameraRollToolStripMenuItem
        '
        Me.CameraRollToolStripMenuItem.AccessibleDescription = Nothing
        Me.CameraRollToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.CameraRollToolStripMenuItem, "CameraRollToolStripMenuItem")
        Me.CameraRollToolStripMenuItem.BackgroundImage = Nothing
        Me.CameraRollToolStripMenuItem.Name = "CameraRollToolStripMenuItem"
        Me.CameraRollToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        Me.CameraRollToolStripMenuItem.Tag = "/var/root/Media/DCIM"
        '
        'toolStripGoTo19
        '
        Me.toolStripGoTo19.AccessibleDescription = Nothing
        Me.toolStripGoTo19.AccessibleName = Nothing
        resources.ApplyResources(Me.toolStripGoTo19, "toolStripGoTo19")
        Me.toolStripGoTo19.BackgroundImage = Nothing
        Me.toolStripGoTo19.Name = "toolStripGoTo19"
        Me.toolStripGoTo19.ShortcutKeyDisplayString = Nothing
        Me.toolStripGoTo19.Tag = "/System/Library/Fonts"
        '
        'mnuFavorites
        '
        Me.mnuFavorites.AccessibleDescription = Nothing
        Me.mnuFavorites.AccessibleName = Nothing
        resources.ApplyResources(Me.mnuFavorites, "mnuFavorites")
        Me.mnuFavorites.BackgroundImage = Nothing
        Me.mnuFavorites.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.mnuFavorites.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToFavoritesToolStripMenuItem, Me.OrganizeFavoritesToolStripMenuItem, Me.ToolStripMenuItem7})
        Me.mnuFavorites.Name = "mnuFavorites"
        '
        'AddToFavoritesToolStripMenuItem
        '
        Me.AddToFavoritesToolStripMenuItem.AccessibleDescription = Nothing
        Me.AddToFavoritesToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.AddToFavoritesToolStripMenuItem, "AddToFavoritesToolStripMenuItem")
        Me.AddToFavoritesToolStripMenuItem.BackgroundImage = Nothing
        Me.AddToFavoritesToolStripMenuItem.Name = "AddToFavoritesToolStripMenuItem"
        Me.AddToFavoritesToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'OrganizeFavoritesToolStripMenuItem
        '
        Me.OrganizeFavoritesToolStripMenuItem.AccessibleDescription = Nothing
        Me.OrganizeFavoritesToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.OrganizeFavoritesToolStripMenuItem, "OrganizeFavoritesToolStripMenuItem")
        Me.OrganizeFavoritesToolStripMenuItem.BackgroundImage = Nothing
        Me.OrganizeFavoritesToolStripMenuItem.Name = "OrganizeFavoritesToolStripMenuItem"
        Me.OrganizeFavoritesToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.AccessibleDescription = Nothing
        Me.ToolStripMenuItem7.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItem7, "ToolStripMenuItem7")
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.AccessibleDescription = Nothing
        Me.ToolStripDropDownButton2.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripDropDownButton2, "ToolStripDropDownButton2")
        Me.ToolStripDropDownButton2.BackgroundImage = Nothing
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfirmDeletionsToolStripMenuItem, Me.IgnoreThumbsdbToolStripMenuItem, Me.IgnoreDSStoreToolStripMenuItem, Me.ConvertPNGsToolStripMenuItem, Me.ToolStripSeparator8, Me.ShowPreviewsToolStripMenuItem, Me.PictureBackgroundToolStripMenuItem, Me.BackupDirectoryToolStripMenuItem})
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        '
        'ConfirmDeletionsToolStripMenuItem
        '
        Me.ConfirmDeletionsToolStripMenuItem.AccessibleDescription = Nothing
        Me.ConfirmDeletionsToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.ConfirmDeletionsToolStripMenuItem, "ConfirmDeletionsToolStripMenuItem")
        Me.ConfirmDeletionsToolStripMenuItem.BackgroundImage = Nothing
        Me.ConfirmDeletionsToolStripMenuItem.Checked = True
        Me.ConfirmDeletionsToolStripMenuItem.CheckOnClick = True
        Me.ConfirmDeletionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ConfirmDeletionsToolStripMenuItem.Name = "ConfirmDeletionsToolStripMenuItem"
        Me.ConfirmDeletionsToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'IgnoreThumbsdbToolStripMenuItem
        '
        Me.IgnoreThumbsdbToolStripMenuItem.AccessibleDescription = Nothing
        Me.IgnoreThumbsdbToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.IgnoreThumbsdbToolStripMenuItem, "IgnoreThumbsdbToolStripMenuItem")
        Me.IgnoreThumbsdbToolStripMenuItem.BackgroundImage = Nothing
        Me.IgnoreThumbsdbToolStripMenuItem.Checked = True
        Me.IgnoreThumbsdbToolStripMenuItem.CheckOnClick = True
        Me.IgnoreThumbsdbToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IgnoreThumbsdbToolStripMenuItem.Name = "IgnoreThumbsdbToolStripMenuItem"
        Me.IgnoreThumbsdbToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'IgnoreDSStoreToolStripMenuItem
        '
        Me.IgnoreDSStoreToolStripMenuItem.AccessibleDescription = Nothing
        Me.IgnoreDSStoreToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.IgnoreDSStoreToolStripMenuItem, "IgnoreDSStoreToolStripMenuItem")
        Me.IgnoreDSStoreToolStripMenuItem.BackgroundImage = Nothing
        Me.IgnoreDSStoreToolStripMenuItem.Checked = True
        Me.IgnoreDSStoreToolStripMenuItem.CheckOnClick = True
        Me.IgnoreDSStoreToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IgnoreDSStoreToolStripMenuItem.Name = "IgnoreDSStoreToolStripMenuItem"
        Me.IgnoreDSStoreToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'ConvertPNGsToolStripMenuItem
        '
        Me.ConvertPNGsToolStripMenuItem.AccessibleDescription = Nothing
        Me.ConvertPNGsToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.ConvertPNGsToolStripMenuItem, "ConvertPNGsToolStripMenuItem")
        Me.ConvertPNGsToolStripMenuItem.BackgroundImage = Nothing
        Me.ConvertPNGsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IPhoneToPCToolStripMenuItem, Me.PCToIPhoneToolStripMenuItem, Me.ConvertBothToolStripMenuItem})
        Me.ConvertPNGsToolStripMenuItem.Name = "ConvertPNGsToolStripMenuItem"
        Me.ConvertPNGsToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'IPhoneToPCToolStripMenuItem
        '
        Me.IPhoneToPCToolStripMenuItem.AccessibleDescription = Nothing
        Me.IPhoneToPCToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.IPhoneToPCToolStripMenuItem, "IPhoneToPCToolStripMenuItem")
        Me.IPhoneToPCToolStripMenuItem.BackgroundImage = Nothing
        Me.IPhoneToPCToolStripMenuItem.Checked = True
        Me.IPhoneToPCToolStripMenuItem.CheckOnClick = True
        Me.IPhoneToPCToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IPhoneToPCToolStripMenuItem.Name = "IPhoneToPCToolStripMenuItem"
        Me.IPhoneToPCToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'PCToIPhoneToolStripMenuItem
        '
        Me.PCToIPhoneToolStripMenuItem.AccessibleDescription = Nothing
        Me.PCToIPhoneToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.PCToIPhoneToolStripMenuItem, "PCToIPhoneToolStripMenuItem")
        Me.PCToIPhoneToolStripMenuItem.BackgroundImage = Nothing
        Me.PCToIPhoneToolStripMenuItem.CheckOnClick = True
        Me.PCToIPhoneToolStripMenuItem.Name = "PCToIPhoneToolStripMenuItem"
        Me.PCToIPhoneToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'ConvertBothToolStripMenuItem
        '
        Me.ConvertBothToolStripMenuItem.AccessibleDescription = Nothing
        Me.ConvertBothToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.ConvertBothToolStripMenuItem, "ConvertBothToolStripMenuItem")
        Me.ConvertBothToolStripMenuItem.BackgroundImage = Nothing
        Me.ConvertBothToolStripMenuItem.Name = "ConvertBothToolStripMenuItem"
        Me.ConvertBothToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.AccessibleDescription = Nothing
        Me.ToolStripSeparator8.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripSeparator8, "ToolStripSeparator8")
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        '
        'ShowPreviewsToolStripMenuItem
        '
        Me.ShowPreviewsToolStripMenuItem.AccessibleDescription = Nothing
        Me.ShowPreviewsToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.ShowPreviewsToolStripMenuItem, "ShowPreviewsToolStripMenuItem")
        Me.ShowPreviewsToolStripMenuItem.BackgroundImage = Nothing
        Me.ShowPreviewsToolStripMenuItem.Checked = True
        Me.ShowPreviewsToolStripMenuItem.CheckOnClick = True
        Me.ShowPreviewsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowPreviewsToolStripMenuItem.Name = "ShowPreviewsToolStripMenuItem"
        Me.ShowPreviewsToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'PictureBackgroundToolStripMenuItem
        '
        Me.PictureBackgroundToolStripMenuItem.AccessibleDescription = Nothing
        Me.PictureBackgroundToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.PictureBackgroundToolStripMenuItem, "PictureBackgroundToolStripMenuItem")
        Me.PictureBackgroundToolStripMenuItem.BackgroundImage = Nothing
        Me.PictureBackgroundToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlackToolStripMenuItem, Me.GrayToolStripMenuItem, Me.WhiteToolStripMenuItem})
        Me.PictureBackgroundToolStripMenuItem.Name = "PictureBackgroundToolStripMenuItem"
        Me.PictureBackgroundToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'BlackToolStripMenuItem
        '
        Me.BlackToolStripMenuItem.AccessibleDescription = Nothing
        Me.BlackToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.BlackToolStripMenuItem, "BlackToolStripMenuItem")
        Me.BlackToolStripMenuItem.BackgroundImage = Nothing
        Me.BlackToolStripMenuItem.CheckOnClick = True
        Me.BlackToolStripMenuItem.Name = "BlackToolStripMenuItem"
        Me.BlackToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'GrayToolStripMenuItem
        '
        Me.GrayToolStripMenuItem.AccessibleDescription = Nothing
        Me.GrayToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.GrayToolStripMenuItem, "GrayToolStripMenuItem")
        Me.GrayToolStripMenuItem.BackgroundImage = Nothing
        Me.GrayToolStripMenuItem.CheckOnClick = True
        Me.GrayToolStripMenuItem.Name = "GrayToolStripMenuItem"
        Me.GrayToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'WhiteToolStripMenuItem
        '
        Me.WhiteToolStripMenuItem.AccessibleDescription = Nothing
        Me.WhiteToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.WhiteToolStripMenuItem, "WhiteToolStripMenuItem")
        Me.WhiteToolStripMenuItem.BackgroundImage = Nothing
        Me.WhiteToolStripMenuItem.CheckOnClick = True
        Me.WhiteToolStripMenuItem.Name = "WhiteToolStripMenuItem"
        Me.WhiteToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'BackupDirectoryToolStripMenuItem
        '
        Me.BackupDirectoryToolStripMenuItem.AccessibleDescription = Nothing
        Me.BackupDirectoryToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.BackupDirectoryToolStripMenuItem, "BackupDirectoryToolStripMenuItem")
        Me.BackupDirectoryToolStripMenuItem.BackgroundImage = Nothing
        Me.BackupDirectoryToolStripMenuItem.Name = "BackupDirectoryToolStripMenuItem"
        Me.BackupDirectoryToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.AccessibleDescription = Nothing
        Me.ToolStripDropDownButton1.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripDropDownButton1, "ToolStripDropDownButton1")
        Me.ToolStripDropDownButton1.BackgroundImage = Nothing
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.AccessibleDescription = Nothing
        Me.AboutToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.AboutToolStripMenuItem, "AboutToolStripMenuItem")
        Me.AboutToolStripMenuItem.BackgroundImage = Nothing
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'fileSaveDialog
        '
        Me.fileSaveDialog.AddExtension = False
        resources.ApplyResources(Me.fileSaveDialog, "fileSaveDialog")
        '
        'fileOpenDialog
        '
        resources.ApplyResources(Me.fileOpenDialog, "fileOpenDialog")
        '
        'menuRightClickFolders
        '
        Me.menuRightClickFolders.AccessibleDescription = Nothing
        Me.menuRightClickFolders.AccessibleName = Nothing
        resources.ApplyResources(Me.menuRightClickFolders, "menuRightClickFolders")
        Me.menuRightClickFolders.BackgroundImage = Nothing
        Me.menuRightClickFolders.Font = Nothing
        Me.menuRightClickFolders.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemNewFolder, Me.ToolStripSeparator9, Me.BackupFolderToolStripMenuItem, Me.ToolStripMenuItemSaveFolderIn, Me.cmdRenameFolder, Me.ToolStripSeparator10, Me.ToolStripMenuItemDeleteFolder})
        Me.menuRightClickFolders.Name = "menuRightClickFolders"
        '
        'ToolStripMenuItemNewFolder
        '
        Me.ToolStripMenuItemNewFolder.AccessibleDescription = Nothing
        Me.ToolStripMenuItemNewFolder.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItemNewFolder, "ToolStripMenuItemNewFolder")
        Me.ToolStripMenuItemNewFolder.BackgroundImage = Nothing
        Me.ToolStripMenuItemNewFolder.Name = "ToolStripMenuItemNewFolder"
        Me.ToolStripMenuItemNewFolder.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.AccessibleDescription = Nothing
        Me.ToolStripSeparator9.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripSeparator9, "ToolStripSeparator9")
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        '
        'BackupFolderToolStripMenuItem
        '
        Me.BackupFolderToolStripMenuItem.AccessibleDescription = Nothing
        Me.BackupFolderToolStripMenuItem.AccessibleName = Nothing
        resources.ApplyResources(Me.BackupFolderToolStripMenuItem, "BackupFolderToolStripMenuItem")
        Me.BackupFolderToolStripMenuItem.BackgroundImage = Nothing
        Me.BackupFolderToolStripMenuItem.Name = "BackupFolderToolStripMenuItem"
        Me.BackupFolderToolStripMenuItem.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripMenuItemSaveFolderIn
        '
        Me.ToolStripMenuItemSaveFolderIn.AccessibleDescription = Nothing
        Me.ToolStripMenuItemSaveFolderIn.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItemSaveFolderIn, "ToolStripMenuItemSaveFolderIn")
        Me.ToolStripMenuItemSaveFolderIn.BackgroundImage = Nothing
        Me.ToolStripMenuItemSaveFolderIn.Name = "ToolStripMenuItemSaveFolderIn"
        Me.ToolStripMenuItemSaveFolderIn.ShortcutKeyDisplayString = Nothing
        '
        'cmdRenameFolder
        '
        Me.cmdRenameFolder.AccessibleDescription = Nothing
        Me.cmdRenameFolder.AccessibleName = Nothing
        resources.ApplyResources(Me.cmdRenameFolder, "cmdRenameFolder")
        Me.cmdRenameFolder.BackgroundImage = Nothing
        Me.cmdRenameFolder.Name = "cmdRenameFolder"
        Me.cmdRenameFolder.ShortcutKeyDisplayString = Nothing
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.AccessibleDescription = Nothing
        Me.ToolStripSeparator10.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripSeparator10, "ToolStripSeparator10")
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        '
        'ToolStripMenuItemDeleteFolder
        '
        Me.ToolStripMenuItemDeleteFolder.AccessibleDescription = Nothing
        Me.ToolStripMenuItemDeleteFolder.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripMenuItemDeleteFolder, "ToolStripMenuItemDeleteFolder")
        Me.ToolStripMenuItemDeleteFolder.BackgroundImage = Nothing
        Me.ToolStripMenuItemDeleteFolder.Name = "ToolStripMenuItemDeleteFolder"
        Me.ToolStripMenuItemDeleteFolder.ShortcutKeyDisplayString = Nothing
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
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.splMain)
        Me.Controls.Add(Me.toolStrip)
        Me.Controls.Add(Me.tlbStatusStrip)
        Me.Font = Nothing
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
    Friend WithEvents BtnCancel As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents toolStripGoTo20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebBrws As System.Windows.Forms.WebBrowser
    Friend WithEvents imgFilesLarge As System.Windows.Forms.ImageList
    Friend WithEvents imgFilesSmall As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripDropDownButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents BackupDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
