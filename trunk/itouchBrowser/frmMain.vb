Option Strict On
Option Explicit On

Imports System.Threading
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Text
Imports itouchBrowser.Manzana
Imports SCW_iPhonePNG

Public Class frmMain
    Private Const NO_NAME_LABEL As String = "no name"

    Const IMAGE_FOLDER_CLOSED As Integer = 0
    Const IMAGE_FOLDER_OPEN As Integer = 1
    Const IMAGE_FILE_UNKNOWN As Integer = 0
    Const IMAGE_FILE_MUSIC As Integer = 1
    Const IMAGE_FILE_MOVIE As Integer = 2
    Const IMAGE_FILE_TEXT As Integer = 3
    Const IMAGE_FILE_AUDIO As Integer = 4
    Const IMAGE_FILE_DATABASE As Integer = 5
    'Const IMAGE_FILE_RINGTONE As Integer = 7
    Const IMAGE_FILE_WEBBROWS As Integer = 6
    Const IMAGE_FILE_IMAGE As Integer = 7

    'Private backupPath As String = ""

    Private bNowConnected As Boolean = False
    Private bConnectionChanged As Boolean = False
    Private txtSerial As String
    Private bUpdateInProgress As Boolean = False
    Private bSupressFiles As Boolean = False
    Private wasQTpreview As Boolean = False
    Private prevSelectedFile As String = ""
    Private favNames As Specialized.StringCollection
    Private favPaths As Specialized.StringCollection
    Private IsCollapsing As Boolean
    Private tildeDir As String

    Private lstFilesSortOrder As SortOrder
    Private mvarInProCount As Integer = 0
    Private resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
    Private mvarClickedMouseButton As MouseButtons = Windows.Forms.MouseButtons.None
    Private mvarLnError As Boolean = False
    Private mvarCurrAnnotation As String = ""
    Private mvarItunesMan As New iTunesManager
    Private iTunesPath As String = ""
    Private iTunesRoot As String = ""
    Private mvarItunes As Data.DataTable = Nothing
    Private mvarSplashMsg As Label
    Private mvarFullScreenMode As Boolean = False   ' フルスクリーン表示かどうかのフラグ
    Private prevFormState As FormWindowState        ' フルスクリーン表示前のウィンドウの状態を保存する
    Private prevFormStyle As FormBorderStyle        ' 通常表示時のフォームの境界線スタイルを保存する
    Private prevFormSize As Size                    ' 通常表示時のウィンドウのサイズを保存する


    'CUSTOM  CREATED FUNCTIONS

    Private Delegate Sub NoParmDel()

    Public Sub New(ByVal splashMsg As Label)

        ' この呼び出しは、Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        mvarSplashMsg = splashMsg

    End Sub

    Private Sub delayedConnectionChange()
        Try
            EndStatus()
            bNowConnected = Not bNowConnected
            bConnectionChanged = True
            Me.connectionChange()

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Event iPhoneConnected()
    Public Event iPhoneDisconnected()

    Private Sub frmMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        My.Settings.QTLeftWidth = pnlQt.LeftWidth
        My.Settings.BackupControl = tsmBackupControl.Checked
        My.Settings.LastPath = ModuleMain.NodeiPhonePath(trvFolders.SelectedNode)
        If mvarFullScreenMode = False Then
            My.Settings.Position = Me.Left.ToString() & "," & Me.Top.ToString() & "," & Me.Width.ToString() & "," & Me.Height.ToString()
        End If
        My.Settings.Save()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        pnlQt.Dispose()
        qtBuff.Dispose()
    End Sub

    Public Sub iPhoneConnected_Details() Handles Me.iPhoneConnected
        If Not bNowConnected Then
            txtSerial = iPhoneInterface.Device.serial
            If Me.InvokeRequired Then
                Me.Invoke(New NoParmDel(AddressOf delayedConnectionChange))
            Else
                Me.delayedConnectionChange()
            End If
        End If
    End Sub

    Public Sub iPhoneDisconnected_Details() Handles Me.iPhoneDisconnected
        If bNowConnected Then
            txtSerial = ""
            If Me.InvokeRequired Then
                Me.Invoke(New NoParmDel(AddressOf delayedConnectionChange))
            Else
                Me.delayedConnectionChange()
            End If
        End If
    End Sub

    Private Sub iPhoneConnected_EventHandler(ByVal sender As Object, ByVal args As ConnectEventArgs)
        RaiseEvent iPhoneConnected()
    End Sub

    Private Sub iPhoneDisconnected_EventHandler(ByVal sender As Object, ByVal args As ConnectEventArgs)
        RaiseEvent iPhoneDisconnected()
    End Sub

    Public Sub iPhoneConnect(ByVal lnError As Boolean)
        mvarLnError = lnError
        bNowConnected = False
        RaiseEvent iPhoneConnected()
    End Sub

    Public Sub iPhoneDisconnect()
        RaiseEvent iPhoneDisconnected()
    End Sub

    Private Sub connectionChange()

        If bConnectionChanged Then
            bConnectionChanged = False

            trvFolders.Enabled = bNowConnected
            lstFiles.Enabled = bNowConnected
            txtFileDetails.Enabled = bNowConnected
            mnuGoTo.Enabled = bNowConnected
            mnuFavorites.Enabled = bNowConnected
            tsmNewFolder.Enabled = bNowConnected
            menuDeleteFolder.Enabled = bNowConnected
            tslAddress.Enabled = bNowConnected
            tstAddress.Enabled = bNowConnected
            tsbAddress.Enabled = bNowConnected
            setJailbreakMenuVisibled()

            If mvarLnError Then
                mvarLnError = False
            ElseIf bNowConnected Then
                Me.Opacity = 75
                'the phone was just recognized as connected
                Me.refreshFolders()
                trvFolders.Focus()

                If iPhoneInterface.IsJailbreak Then
                    ' "iPhone is connected and jailbroken"
                    StatusNormal(My.Resources.String3)
                    iTunesPath = "/var/mobile/Media/iTunes_Control/iTunes/iTunesDB"
                    If iPhoneInterface.Exists("/var/root/Media/DCIM") Then
                        tildeDir = "/var/root"
                        iTunesPath = "/var/root/Media/iTunes_Control/iTunes/iTunesDB"
                    End If
                Else
                    ' "iPhone is connected, not jailbroken"
                    StatusWarning(My.Resources.String1)
                    iTunesPath = "/iTunes_Control/iTunes/iTunesDB"
                End If
                iTunesRoot = iTunesPath.Substring(0, iTunesPath.IndexOf("/iTunes_Control/"))

                'Set last path
                If My.Settings.LastPath <> "" _
                    AndAlso My.Settings.LastJailbroken = iPhoneInterface.IsJailbreak Then
                    Me.openPath(My.Settings.LastPath)
                End If
                My.Settings.LastJailbroken = iPhoneInterface.IsJailbreak

                setAMDeviceData()

            Else
                ' "iPhone is NOT connected, please check your connections!"
                StatusWarning(My.Resources.String2)

                trvITunes.Nodes.Clear()
                trvApps.Nodes.Clear()
                rtbAMDevice.Clear()
                My.Settings.LastPath = ModuleMain.NodeiPhonePath(trvFolders.SelectedNode)
                mvarItunesMan.Clear()
                tabFolder.SelectedIndex = 0
                'mvarItunesMan.Dispose()
            End If

        End If
    End Sub

    Private Sub setJailbreakMenuVisibled()
        Dim visibled As Boolean = iPhoneInterface.IsJailbreak

        mnuGoTo.Visible = visibled
        'menuSaveSummerboardTheme.Visible = visibled
        'ToolStripMenuItem4.Visible = visibled
        'ToolStripSeparator7.Visible = visibled

    End Sub

    Private Function getArtists(ByVal dir As String, ByVal label As String) As Boolean
        Dim arts As String() = mvarItunesMan.GetArtists(dir)

        trvITunes.BeginUpdate()
        Try
            trvITunes.Nodes.Clear()
            Dim tn As TreeNode = trvITunes.Nodes.Add(label)
            For i As Integer = 0 To arts.Length - 1
                tn.Nodes.Add(arts(i))
            Next
            tn.ExpandAll()
            btnExport.Enabled = False

            mvarItunes = mvarItunesMan.GetRecSet()

        Finally
            trvITunes.EndUpdate()
        End Try

    End Function

    Private Function getAlbums(ByVal tn As TreeNode, ByVal art As String) As Boolean

        trvITunes.BeginUpdate()
        Try
            If tn.Nodes.Count = 0 Then
                Dim alms As String() = mvarItunesMan.GetAlbums(art)
                For j As Integer = 0 To alms.Length - 1
                    Dim name As String = alms(j)
                    If name = "" Then
                        name = NO_NAME_LABEL
                    End If
                    tn.Nodes.Add(name).Checked = tn.Checked
                Next
            End If
            tn.Expand()

        Finally
            trvITunes.EndUpdate()
        End Try

    End Function

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try
            Dim pos As String = My.Settings.Position
            If pos.IndexOf(",") > 0 Then
                Dim position As String() = pos.Split(","c)
                Me.SetDesktopLocation(CInt(position(0)), CInt(position(1)))
                Me.Size = New Size(CInt(position(2)), CInt(position(3)))
            End If

            Me.Text = My.Resources.String14 & " (v" & Application.ProductVersion & ")"

            ProgressBars(0) = tlbProgress0
            tlbProgress0.Visible = False
            ProgressBars(1) = tlbProgressBar
            tlbProgressBar.Visible = False
            btnCancel.Visible = False
            tslProgress.Visible = False
            ResetStatus()   'ProgressDepth = -1

            ModuleMain.CreateImageList()

            Me.Show()
            Application.DoEvents()

            'APP_PATH = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Cranium\iPhoneBrowser\"
            'APP_PATH = My.Settings.BackupPath & "\touchBrowser\"
            setBackupPath(DateTime.Now)

            FILE_TEMPORARY_VIEWER = Path.GetTempPath & FILE_TEMPORARY_VIEWER

            ' initialize the file list groups
            mvarSplashMsg.Text = "Initialize the file list groups."
            For j1 As Integer = 0 To 7
                Dim lvg As ListViewGroup = New ListViewGroup(Me.getFiletype(j1))
                lstFiles.Groups.Add(lvg)
            Next


            ' load up the user settings
            mvarSplashMsg.Text = "Load up the user settings."
            If My.Settings.CallUpgrade Then
                My.Settings.Upgrade()
                My.Settings.CallUpgrade = False
                My.Settings.Save()
            End If
            tsmConfirmDeletions.Checked = My.Settings.ConfirmDeletions
            Config.bConvertToiPhonePNG = My.Settings.PCToiPhonePNG
            Config.bConvertToPNG = My.Settings.iPhoneToPCPNG
            Config.bShowPreview = My.Settings.ShowPreviews
            Config.bIgnoreThumbsFile = My.Settings.IgnoreThumbsFile
            Config.bIgnoreDSStoreFile = My.Settings.IgnoreDSStoreFile
            Config.bIgnoreCacheFile = My.Settings.IgnoreCacheFile
            Config.bBackupControled = My.Settings.BackupControl
            Config.bShowSongTitle = My.Settings.ShowSongTitle
            tsmIPhoneToPC.Checked = Config.bConvertToPNG
            tsmPCToIPhone.Checked = Config.bConvertToiPhonePNG
            tsmShowPreviews.Checked = Config.bShowPreview
            tsmIgnoreThumbsdb.Checked = Config.bIgnoreThumbsFile
            tsmIgnoreDSStore.Checked = Config.bIgnoreDSStoreFile
            tsmIgnoreCacheFile.Checked = Config.bIgnoreCacheFile
            tsmBackupControl.Checked = Config.bBackupControled
            tsmDisplaySongTitle.Checked = Config.bShowSongTitle
            cmdShowGroups.Checked = My.Settings.ShowGroups
            pnlQt.LeftWidth = My.Settings.QTLeftWidth
            favNames = My.Settings.FavNames
            If favNames Is Nothing Then
                favNames = New Specialized.StringCollection()
            End If
            favPaths = My.Settings.FavPaths
            If favPaths Is Nothing Then
                favPaths = New Specialized.StringCollection()
            End If
            picBusy.Dock = DockStyle.Fill
            picDelete.Dock = DockStyle.Fill

            mvarSplashMsg.Text = "Initialize the QuickTime object."
            Dim qtThread As New Thread(New ThreadStart(AddressOf Me.qtInitialize))
            qtThread.Start()

            LoadFavoritesMenu()

            ' setup the tooltips
            mvarSplashMsg.Text = "Setup the tooltips."
            menuSetTooltips(mnuGoTo)
            menuSetTooltips(mnuStdApps)
            menuSetTooltips(mnuThirdPartyApps)

            cmbOutputDir.Items.Clear()
            cmbOutputDir.Items.Add(My.Resources.String56)
            cmbOutputDir.Items.Add(My.Resources.String57)
            cmbOutputDir.Items.Add(My.Resources.String58)
            cmbOutputDir.Items.Add(My.Resources.String59)
            cmbOutputDir.Text = My.Settings.ExportDir

            tildeDir = "/var/mobile"

            iPhoneInterface = New iPhone( _
                    AddressOf iPhoneConnected_EventHandler, _
                    AddressOf iPhoneDisconnected_EventHandler)

            'setup the event handlers
            'AddHandler iPhoneInterface.Connect, AddressOf iPhoneConnected_EventHandler
            'AddHandler iPhoneInterface.Disconnect, AddressOf iPhoneDisconnected_EventHandler

            prevFormState = FormWindowState.Normal            ' フルスクリーン表示前のウィンドウの状態を保存する
            prevFormStyle = FormBorderStyle.Sizable           ' 通常表示時のフォームの境界線スタイルを保存する
            prevFormSize = New Size(Me.Width, Me.Height)      ' 通常表示時のウィンドウのサイズを保存する

            qtThread.Join()

        Catch ex As Exception
            MsgBox(My.Resources.String15 & ex.Message & My.Resources.String16, MsgBoxStyle.Critical, "Error!")
            Application.Exit()
        End Try

    End Sub

    Private Sub qtInitialize()
        pnlQt.QuickTimeInitialize()
        qtBuff.QuickTimeInitialize()
        qtBuff.AutoPlay = "False"
        qtBuff.EventEnabled = False
    End Sub

    Private Sub refreshChildFolders(ByVal forceRefresh As Boolean)
        If Not bUpdateInProgress Then
            Me.refreshChildFolders(trvFolders.SelectedNode, forceRefresh)
        End If
    End Sub

    Private Sub refreshChildFolders(ByVal rootNode As TreeNode, ByVal forceRefresh As Boolean)
        Dim sWorkingPath As String
        Dim tmpNode As TreeNode

        'If CBool(rootNode.Tag) AndAlso Not forceRefresh Then
        If rootNode.Checked AndAlso Not forceRefresh Then
            Exit Sub
        End If

        If Not bUpdateInProgress Then
            bUpdateInProgress = True
            'Me.Cursor = Cursors.WaitCursor
            trvFolders.SuspendLayout()

            'we need to go through all the children and refresh them
            'StatusNormal("Refreshing folders for " & rootNode.Name & "...")
            StatusNormal(String.Format(My.Resources.String4, rootNode.Name))
            StartStatus(rootNode.Nodes.Count, 0)

            'sWorkingPath = ModuleMain.NodeiPhonePath(rootNode)
            If CBool(rootNode.Tag) = False Then
                ModuleMain.AddFolders(rootNode, -2)
            End If

            Try
                If rootNode.Nodes.Count < 20 Then
                    StartStatus(rootNode.Nodes.Count, 0)

                    For Each tmpNode In rootNode.Nodes
                        If IncrementStatus(0) Then Exit For

                        sWorkingPath = ModuleMain.NodeiPhonePath(tmpNode)

                        tmpNode.Nodes.Clear()
                        'now add it (only if it is not the root)
                        If sWorkingPath <> "/" Then
                            Try
                                ModuleMain.Add1stFolder(sWorkingPath, tmpNode)
                            Catch
                                Try
                                    'rootNode.Nodes(iTemp).Remove()
                                    tmpNode.Remove()        ' someone deleted the folder
                                Catch ex As Exception
                                    StatusWarning(ex.Message)
                                End Try
                            End Try
                        End If
                    Next

                    EndStatus()
                Else
                    For Each tmpNode In rootNode.Nodes
                        tmpNode.Nodes.Add("dummy")
                    Next
                End If

                StatusNormal("")
                If ProgressEscapeFlg = False Then
                    rootNode.Tag = True
                    rootNode.Checked = True
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)

            Finally
                EndStatus()
                trvFolders.ResumeLayout()
                'Me.Cursor = Cursors.Default
                bUpdateInProgress = False
            End Try
        End If

    End Sub

    Private Function fileSizeAsString(ByVal sFilePath As String) As String
        Dim iFileSize As Long = iPhoneInterface.FileSize(sFilePath)
        'make it look pretty
        If iFileSize > 10240000 Then
            Return String.Format("{0:0.##} MB", iFileSize / 1024000)
        ElseIf iFileSize > 10240 Then
            Return String.Format("{0:0.##} KB", iFileSize / 1024)
        Else
            Return String.Format("{0} B", iFileSize)
        End If
    End Function

    Private Function fileSizeAsString(ByVal size As Long) As String
        Dim iFileSize As Long = size
        'make it look pretty
        If iFileSize > 10240000 Then
            Return String.Format("{0:0.##} MB", iFileSize / 1024000)
        ElseIf iFileSize > 10240 Then
            Return String.Format("{0:0.##} KB", iFileSize / 1024)
        Else
            Return String.Format("{0} B", iFileSize)
        End If
    End Function

    Private Structure ItemTitleStruct
        Dim index As Integer
        Dim fileName As String
        Dim subDir As String
    End Structure

    Private escapeProcess As Boolean = True

    Friend Sub LoadFiles()
        Dim bFiles As List(Of iPhone.strFileInfo)
        Dim iPhonePath As String
        Dim lstTemp As ListViewItem
        Dim row As Integer

        If Not bSupressFiles Then
            escapeProcess = False
            'Dim sbpath As New System.Text.StringBuilder
            'loads the files into the list view based on the current directory

            Try
                'first clear out any files that may be there
                mvarInProCount += 1

                iPhonePath = ModuleMain.NodeiPhonePath(trvFolders.SelectedNode)
                tstAddress.Text = iPhonePath
                'StatusNormal("Loading Files for " & iPhonePath & "...")
                StatusNormal(String.Format(My.Resources.String5, iPhonePath))
                'now get the files from the iphone
                bFiles = iPhoneInterface.GetFilesInfo(iPhonePath)

                'now go one by one and add it
                Dim songTitles(bFiles.Count) As ItemTitleStruct
                Dim songCnt As Integer = 0
                Dim thumbnails(bFiles.Count) As ItemTitleStruct
                Dim thumbnailCnt As Integer = 0
                Dim listRow As Integer = 0
                Dim sFileExt As String = ""

                lstFiles.BeginUpdate()
                lstFiles.Items.Clear()
                lstFiles.ListViewItemSorter = Nothing
                lstFilesSortOrder = SortOrder.None

                Try
                    'For Each sFile As String In sFiles
                    For listRow = 0 To bFiles.Count - 1
                        Dim strFileInfo As iPhone.strFileInfo = bFiles(listRow)
                        Dim sFile As String = convertcd(strFileInfo.name)
                        Dim iPhoneFile As String = iPhonePath & "/" & sFile
                        Dim subDirName As String = ""

                        If ObjDb IsNot Nothing Then
                            row = ObjDb.Find("", iPhoneFile)
                            If row > -1 Then
                                subDirName = ObjDb.GetValue(row, 1)
                            End If
                        Else
                            row = -1
                        End If

                        sFileExt = sFile
                        Dim ext As String = ""
                        If sFile.LastIndexOf(".") > -1 Then
                            ext = sFile.Substring(sFile.LastIndexOf(".")).ToLower()
                        End If

                        If Config.bShowSongTitle AndAlso _
                            (ext = ".m4a" _
                            OrElse ext = ".mp3" _
                            OrElse ext = ".m4p" _
                            OrElse ext = ".mp4") Then

                            ' display song title
                            Dim tune As String = mvarItunesMan.Select(iPhoneFile)
                            If tune.Length > 0 Then
                                sFileExt &= tune
                            ElseIf ext <> ".mp4" Then
                                songTitles(songCnt).index = listRow
                                songTitles(songCnt).fileName = sFile
                                songTitles(songCnt).subDir = subDirName
                                songCnt += 1
                                If Not mvarItunesMan.Loaded Then
                                    ProgressEscapeFlg = False
                                    If CopyFromPhone(iTunesPath, My.Settings.DbPath & "\iTunesDB") <> 0 Then
                                        Me.getArtists(My.Settings.DbPath, "All")
                                    End If
                                End If
                            End If
                        End If

                        lstTemp = New ListViewItem(sFileExt)
                        lstTemp.ImageIndex = getImageIndexForFile(sFile)
                        If lstFiles.ShowGroups Then
                            lstTemp.Group = lstFiles.Groups(lstTemp.ImageIndex)
                        End If

                        If strFileInfo.isSLink Then
                            lstTemp.ForeColor = Color.Blue
                        Else
                            If ext = ".png" _
                                OrElse ext = ".jpg" _
                                OrElse ext = ".gif" _
                                OrElse ext = ".jpeg" Then

                                If strFileInfo.size > 0 Then
                                    thumbnails(thumbnailCnt).index = listRow
                                    thumbnails(thumbnailCnt).fileName = sFile
                                    thumbnails(thumbnailCnt).subDir = subDirName
                                    thumbnailCnt += 1
                                End If
                            End If
                        End If

                        ' add the file size
                        lstTemp.SubItems.Add(Me.fileSizeAsString(strFileInfo.size))

                        ' add the backup directory
                        If row = -1 Then
                            lstTemp.SubItems.Add("")
                        Else
                            Dim lvItem As ListViewItem.ListViewSubItem = lstTemp.SubItems.Add(subDirName)
                            If subDirName = "Error" Then
                                lstTemp.ForeColor = Color.Red
                                'lstTemp.SubItems(0).ForeColor = Color.Black
                            End If
                        End If

                        ' add the file type
                        lstTemp.SubItems.Add(getFiletype(lstTemp.ImageIndex))

                        'finally add it to the view
                        lstFiles.Items.Add(lstTemp)

                    Next
                    StatusNormal("")

                Finally
                    lstFiles.EndUpdate()
                    lstFiles.Refresh()
                End Try

                Dim songTitle As String = ""
                lstFiles.Tag = iPhonePath

                Dim img As Image
                Dim imgCnt As Integer = imgFilesLargeNew.Images.Count

                imgThumbnail.Images.Clear()
                imgFilesSmallNew.Images.Clear()
                For row = 0 To imgCnt - 1
                    imgThumbnail.Images.Add(imgFilesLargeNew.Images(row))
                    imgFilesSmallNew.Images.Add(imgFilesLargeNew.Images(row))
                Next
                'If lstFiles.View <> View.Details Then
                StartStatus(imgCnt, 0)
                For row = 0 To thumbnailCnt - 1
                    img = getThumbnail(thumbnails(row).fileName, iPhonePath, thumbnails(row).subDir)
                    If img IsNot Nothing Then
                        imgThumbnail.Images.Add(img)
                        imgFilesSmallNew.Images.Add(createThumbnail(img, 18, 18))
                        lstFiles.Items(thumbnails(row).index).ImageIndex = row + imgCnt
                        If IncrementStatus(0) Then Exit For
                        If escapeProcess Then
                            ProgressEscapeFlg = True
                            Exit For
                        End If
                    End If
                Next
                EndStatus()
                'End If

                StartStatus(songCnt, 0)
                For row = 0 To songCnt - 1
                    'If mvarInProCount > 1 Then Exit For
                    songTitle = Me.getSongTitle(songTitles(row).fileName, iPhonePath, songTitles(row).subDir)
                    lstFiles.Items(songTitles(row).index).Text &= songTitle
                    'lstFiles.Refresh()
                    If IncrementStatus(0) Then Exit For
                    'Application.DoEvents()
                    If iPhonePath <> lstFiles.Tag.ToString Then
                        Exit For
                    End If
                Next
                EndStatus()

                'ClearPreview()
                'grpFiles.Text = "Files on your iPhone in the '" & nodeiPhonePath(trvFolders.SelectedNode) & "' Directory"
                grpFiles.Text = String.Format(My.Resources.String6, ModuleMain.NodeiPhonePath(trvFolders.SelectedNode))
                If mvarInProCount > 0 Then
                    mvarInProCount -= 1
                Else
                    mvarInProCount = 0
                End If

                StatusNormal(lstFiles.Items.Count.ToString & " objects")

            Catch e As IOException
                MsgBox(e.ToString, MsgBoxStyle.Exclamation)

            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & ex.StackTrace, MsgBoxStyle.Exclamation)
                If ex.Message = "Path does not exist" Then
                    StatusWarning(My.Resources.String35)
                    ResetiPhone()
                Else
                    StatusWarning(ex.Message)
                End If

            End Try
            escapeProcess = True

        End If
    End Sub

    Private Function getSongTitle(ByVal sFile As String, ByVal iPhonePath As String, ByVal localPath As String) As String

        Dim mname As String = ""

        Dim i As Integer = 0
        Dim sBuffer(65535) As Byte
        Dim iDataBytes As Integer
        Dim iPhoneFileInterface As iPhoneFile
        Dim fileTemp As FileStream
        Dim fsize As Long = 0
        Dim tmpFile As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\" & sFile

        iPhoneFileInterface = iPhoneFile.OpenRead(iPhoneInterface, iPhonePath & "/" & sFile)
        fileTemp = File.OpenWrite(tmpFile)
        iDataBytes = iPhoneFileInterface.Read(sBuffer, 0, sBuffer.Length)

        While iDataBytes > 0
            fileTemp.Write(sBuffer, 0, iDataBytes)
            fsize += iDataBytes
            iDataBytes = iPhoneFileInterface.Read(sBuffer, 0, sBuffer.Length)
            i += 1 : If i > 4 Then Exit While
        End While

        iPhoneFileInterface.Close()
        iPhoneFileInterface.Dispose()
        fileTemp.Close()

        qtBuff.FileName = tmpFile
        mname = mvarCurrAnnotation      ' qtBuff.GetAnnotation(tmpFile)
        qtBuff.Close()

        File.Delete(tmpFile)

        If mname <> "" Then
            mname = "(" & mname & ")"
        End If

        Return mname

    End Function

    ''' <summary>
    ''' returns the image index for the given file's extension
    ''' </summary>
    ''' <param name="sFilename">file to lookup</param>
    ''' <returns>image index</returns>
    Private Function getImageIndexForFile(ByVal sFilename As String) As Integer
        Dim iReturn As Integer = IMAGE_FILE_UNKNOWN

        'sFilename = Path.GetFileName(sFilename.ToLower())
        Dim sExt As String = sFilename.ToLower.Substring(sFilename.LastIndexOf(".") + 1)

        Select Case sExt
            Case "png", "jpg", "jpeg", "gif"
                iReturn = IMAGE_FILE_IMAGE
            Case "strings", "conf", "txt", "script", "pl", "h", "awk", "tcl", "css", "m4", "c", "sh", "js", "py", "el"
                iReturn = IMAGE_FILE_TEXT
            Case "db", "sqlite", "sqlitedb", "itdb", "sqlite3", "zip"
                iReturn = IMAGE_FILE_DATABASE
            Case "aiff", "amr", "aif", "caf", "wav"
                iReturn = IMAGE_FILE_AUDIO
                'Case "m4r"
                'iReturn = IMAGE_FILE_RINGTONE
            Case "m4a", "m4p", "mp3", "aac"
                iReturn = IMAGE_FILE_MUSIC
            Case "mp4", "mov", "3gp", "tga", "m4v"
                iReturn = IMAGE_FILE_MOVIE
            Case "htm", "html", "plist", "thm", "xml", "pdf"
                iReturn = IMAGE_FILE_WEBBROWS
        End Select
        'If sFilename.EndsWith("iTunesDB") Then
        '    iReturn = IMAGE_FILE_DATABASE
        'End If

        Return iReturn
    End Function

    Private Function getFiletype(ByVal iImageIndex As Integer) As String
        'gets the string file type given the image index
        Dim sReturn As String = "Undefined File Type"

        Select Case iImageIndex
            'Case IMAGE_FILE_RINGTONE
            '    sReturn = "Ringtone"
            Case IMAGE_FILE_AUDIO
                sReturn = "Audio File"
            Case IMAGE_FILE_DATABASE
                sReturn = "Database"
            Case IMAGE_FILE_MOVIE
                sReturn = "Movie File"
            Case IMAGE_FILE_MUSIC
                sReturn = "Music File"
            Case IMAGE_FILE_TEXT
                sReturn = "Text File"
            Case IMAGE_FILE_IMAGE
                sReturn = "Image File"
            Case IMAGE_FILE_WEBBROWS
                sReturn = "Html File"
            Case IMAGE_FILE_UNKNOWN
                sReturn = "Unknown File Type"
            Case Else
                'including image_file_unkonwn
        End Select

        Return sReturn
    End Function

    Private Sub refreshFolders()
        Dim rootNode As TreeNode

        Me.Cursor = Cursors.WaitCursor
        trvFolders.SuspendLayout()

        StartStatus(3, 0)
        trvFolders.Nodes.Clear()
        rootNode = New TreeNode(STRING_ROOT)
        rootNode.ContextMenuStrip = menuRightClickFolders
        rootNode.Name = "/"
        trvFolders.Nodes.Add(rootNode)
        IncrementStatus(0)

        ModuleMain.AddFolders(rootNode, 0)
        IncrementStatus(0)

        rootNode.Expand()
        trvFolders.SelectedNode = rootNode
        IncrementStatus(0)

        trvFolders.ResumeLayout()
        Me.Cursor = Cursors.Arrow
        EndStatus()
    End Sub

    Private Function getSelectedFilename(ByRef isSLink As Boolean) As String
        'returns the currently selected filename
        Dim fn As String = lstFiles.SelectedItems(0).Text
        Dim inx As Integer = fn.IndexOf("(")

        If inx > -1 Then
            fn = fn.Substring(0, inx)
        End If
        If lstFiles.SelectedItems(0).ForeColor = Color.Blue Then
            isSLink = True
        Else
            isSLink = False
        End If

        Return getSelectedPath() & fn

    End Function

    Private Function getSelectedFolder() As String
        If tabFolder.SelectedIndex = 0 Then
            If trvFolders.SelectedNode Is Nothing Then
                Return ""
            Else
                Return trvFolders.SelectedNode.FullPath.Substring(STRING_ROOT.Length)
            End If
        Else
            Return grpFiles.Text
        End If
    End Function

    Private Function getSelectedPath() As String
        'returns the currently selected folder
        Return Me.getSelectedFolder() & "/"
    End Function

    ' courtesy Greg Martin
    Private Function countStr(ByVal sourceString As String, ByVal matchString As String) As Integer
        Try
            'Dim stringExpr As New System.Text.RegularExpressions.Regex(matchString)
            'Return stringExpr.Matches(sourceString).Count
            Dim cnt As Integer = 0
            Dim p As Integer = sourceString.IndexOf(matchString)

            Do While p > -1
                p = sourceString.IndexOf(matchString, p + 1)
                cnt += 1
            Loop

            Return cnt
        Catch
            Return -1
        End Try
    End Function

    Private Function selectSpecificPath(ByVal sPathOnPhone As String) As Boolean
        'selects a specifc path in the tree view
        Dim sTemp As String
        Dim iNode As Integer
        Dim tn() As TreeNode
        Dim bReturn As Boolean = False

        bSupressFiles = True 'so we don't load files until the end

        Try
            ' drop trailing /
            If sPathOnPhone.EndsWith("/") AndAlso sPathOnPhone.Length > 1 Then
                sPathOnPhone = sPathOnPhone.Substring(0, sPathOnPhone.Length - 1)
            End If
            'first, lets try to find it without expanding
            tn = trvFolders.Nodes.Find(sPathOnPhone, True)
            If tn.Length = 0 Then ' we couldn't find it
                StartStatus(Me.countStr(sPathOnPhone, "/"), 0)

                Try
                    'select the root first
                    tn = trvFolders.Nodes.Find("/", True)

                    'go through and load each node
                    If sPathOnPhone.Length = 0 Then
                        iNode = -1
                    Else
                        iNode = sPathOnPhone.IndexOf("/", 1)
                    End If
                    Do While iNode > -1
                        'pull out the full path to the next node
                        sTemp = sPathOnPhone.Substring(0, iNode)
                        iNode += 1

                        tn = tn(0).Nodes.Find(sTemp, False)
                        If tn.Length > 0 Then
                            refreshChildFolders(tn(0), False)
                        Else
                            Exit Do
                        End If
                        If IncrementStatus(0) Then Exit Do
                        iNode = sPathOnPhone.IndexOf("/", iNode)
                    Loop

                    'now it should definitely be available
                    'bSupressFiles = False
                    tn = trvFolders.Nodes.Find(sPathOnPhone, True)
                    If tn.Length > 0 Then
                        tn(0).EnsureVisible()
                        bSupressFiles = False
                        trvFolders.SelectedNode = tn(0)
                        trvFolders.Focus()
                        bReturn = True
                    Else
                        'we couldn't find it
                        bReturn = False
                        bSupressFiles = False

                        ' update files display with our partial location
                        LoadFiles()
                    End If
                Finally
                    EndStatus()
                End Try
            Else
                'we found it first try
                tn(0).EnsureVisible()
                bSupressFiles = False
                trvFolders.SelectedNode = tn(0)
                trvFolders.Focus()
                bReturn = True
            End If

        Finally
            bSupressFiles = False

        End Try

        Return bReturn
    End Function

    'SYSTEM CREATED EVENTS

    Private Sub SetViewChecks()
        tsmViewLargeIcons.Checked = (lstFiles.View = View.LargeIcon)
        tsmViewDetails.Checked = (lstFiles.View = View.Details)
        tsmViewSmallIcons.Checked = (lstFiles.View = View.SmallIcon)
        tsmViewTile.Checked = (lstFiles.View = View.Tile)
    End Sub

    Private Sub ToolStripMenuItemLargeIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmViewLargeIcons.Click

        lstFiles.View = View.LargeIcon
        SetViewChecks()
    End Sub

    Private Sub ToolStripMenuItemDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmViewDetails.Click

        lstFiles.View = View.Details
        SetViewChecks()
    End Sub

    Private Sub cmdSmallIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmViewSmallIcons.Click

        lstFiles.View = View.SmallIcon
        SetViewChecks()
    End Sub

    Private Sub ListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmViewTile.Click

        lstFiles.View = View.Tile
        SetViewChecks()
    End Sub

    Private Sub ToolStripMenuItemExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ToolStripMenuItemExit.Click

        If FILE_TEMPORARY_VIEWER.IndexOf("Local Settings\Temp\iPhone.temp", 20) > 0 Then
            ProgressEscapeFlg = True
            Application.DoEvents()
            'delete temp files
            Try
                For Each foundFile As String In My.Computer.FileSystem.GetFiles( _
                    My.Computer.FileSystem.SpecialDirectories.Temp, _
                    FileIO.SearchOption.SearchTopLevelOnly, "iPhone.temp.*")

                    'My.Computer.FileSystem.DeleteFile(foundFile, _
                    '    FileIO.UIOption.OnlyErrorDialogs, _
                    '    FileIO.RecycleOption.DeletePermanently)
                    File.Delete(foundFile)
                Next

            Catch ex As Exception
                'NOP   演奏中ならここに来る
            End Try
        End If

        'time to go
        Me.Close()
    End Sub

    Private Sub trvFolders_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) _
        Handles trvFolders.AfterExpand

        Me.UseWaitCursor = True
        refreshChildFolders(e.Node, False)
        'e.Node.EnsureVisible()
        ProgressEscapeFlg = True
        Me.UseWaitCursor = False
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub trvFolders_BeforeCollapse(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) _
        Handles trvFolders.BeforeCollapse

        IsCollapsing = True
    End Sub

    Private Sub trvFolders_AfterCollapse(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) _
        Handles trvFolders.AfterCollapse

        IsCollapsing = False
    End Sub

    Private Sub trvFolders_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) _
        Handles trvFolders.AfterSelect

        Dim selNode As TreeNode = e.Node
        'Me.UseWaitCursor = True

        If selNode.Level > 0 AndAlso CBool(selNode.Tag) = False Then
            'Folderの展開でキャンセルしたとき
            ModuleMain.AddFolders(selNode, 1)
            'ModuleMain.Add1stFolder(ModuleMain.NodeiPhonePath(selNode), selNode)
        End If

        Me.LoadFiles()

        'Me.UseWaitCursor = False
    End Sub

    Private Sub trvFolders_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles trvFolders.KeyUp

        If e.KeyCode = Keys.F5 Then
            Me.Cursor = Cursors.WaitCursor
            With Me.trvFolders
                .SelectedNode.Collapse()
                .SuspendLayout()
                ModuleMain.AddFoldersBeneath(.SelectedNode)
                .SelectedNode.Expand()
                .ResumeLayout()
            End With
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub lstFiles_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) _
        Handles lstFiles.DragDrop

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim initFolder As String = getSelectedPath()
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim drops() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
                'StartStatus(drops.Length, 0)
                For Each s As String In drops 'e.Data.GetData(DataFormats.FileDrop)
                    CopyToPhone(s, initFolder, Config.bConvertToiPhonePNG)
                    'If IncrementStatus(0) Then Exit For
                Next
                'EndStatus()
                StatusNormal("")

                Me.selectSpecificPath(initFolder) ' fix up tree view
                LoadFiles() ' refresh the list view
            End If

            If e.Data.GetDataPresent(DataFormats.UnicodeText) Then
                Dim url As String = CType(e.Data.GetData(DataFormats.UnicodeText), String)
                ModuleMain.CopyToPhone(url, initFolder, Config.bConvertToiPhonePNG)

                LoadFiles() ' refresh the list view
            End If

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub lstFiles_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) _
        Handles lstFiles.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
        If e.Data.GetDataPresent(DataFormats.UnicodeText) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub unlockQT()
        'unlock the file so we can load another
        If wasQTpreview Then

            pnlQt.PauseMovie()
            pnlQt.FileName = "" 'to unlock it
            'sugi File.Delete(QTpreviewFile.Replace("localhost\", ""))
            'qtPlugin.Close()
            wasQTpreview = False
        End If
    End Sub

    Private Sub clearPreview()
        unlockQT()

        picFileDetails.Visible = False
        txtFileDetails.Visible = False
        pnlQt.Visible = False
        WebBrws.Visible = False
        WebBrws.DocumentText = "   Processing..."
        tabViewType.Visible = False

        btnPreview.Enabled = True

    End Sub

    Private Sub showFileDetails(ByVal sFile As String, ByVal tmpPath As String, ByVal isSLink As Boolean)
        Dim l As Long = 1
        Dim bo As Boolean

        iPhoneInterface.GetFileInfo(sFile, l, bo)

        txtFileDetails.Text = "Filename: " & Path.GetFileName(sFile) & vbCrLf _
                & "Size: " & fileSizeAsString(sFile) _
                & ",   " & l.ToString() & " Byte"

        If isSLink Then
            txtFileDetails.AppendText(vbCrLf & "Symbolic link.")
        Else
            txtFileDetails.AppendText(vbCrLf & vbCrLf)

            If tmpPath <> "" Then
                Dim fs As FileStream
                ' Open the stream and read it back.
                fs = File.OpenRead(tmpPath)
                Dim b(1023) As Byte
                Dim temp As UTF8Encoding = New UTF8Encoding(True)

                Do While fs.Read(b, 0, b.Length) > 0
                    txtFileDetails.AppendText(temp.GetString(b).Replace(Chr(10), vbCrLf))
                Loop
                fs.Close()
                txtFileDetails.AppendText(vbCrLf & vbCrLf)
                txtFileDetails.SuspendLayout()
                txtFileDetails.Visible = False

                Dim i As Integer '= CInt(l)
                Dim addr As Integer = 0
                Dim c(15) As Byte
                Dim val As New StringBuilder
                Dim str As String

                fs = File.OpenRead(tmpPath)
                StartStatus(CInt(l \ 64), l)
                Do While fs.Read(c, 0, c.Length) > 0
                    Val.Append(addr.ToString("X4")).Append(" ")
                    For i = 0 To c.Length - 1
                        val.Append(c(i).ToString("X2")).Append(" ")
                        If c(i) = 0 Then
                            c(i) = Asc(".")
                        End If
                        If c(i) = 9 Then
                            c(i) = Asc(" ")
                        End If
                    Next
                    val.Append(" ").AppendLine(temp.GetString(c)) '.Replace(Chr(0), ".").Replace(Chr(9), " "))
                    addr += 16
                    If addr Mod 64 = 0 Then
                        If IncrementStatus(addr) Then Exit Do
                        str = val.ToString()
                        txtFileDetails.AppendText(str)
                        val.Length = 0
                    End If
                Loop
                str = val.ToString().Replace(Chr(9), " ")
                txtFileDetails.AppendText(str)

                EndStatus()
                fs.Close()
            End If

        End If

        txtFileDetails.ResumeLayout()
        txtFileDetails.Visible = True

    End Sub

    Private Sub showPreview(ByVal sFile As String, ByVal fromBtn As Boolean, ByVal fsize As Integer)
        Dim picOK As Boolean

        StatusNormal(My.Resources.String28 & sFile)

        Dim tmpOnPC As String = GetTempFilename(sFile)
        Dim imageIdx As Integer = lstFiles.SelectedItems(0).ImageIndex
        Dim backupDir As String = lstFiles.SelectedItems(0).SubItems(2).Text
        Dim copyRC As Integer = 0

        If Not fromBtn Then
            If bNowConnected = False Then
                tmpOnPC = sFile.Replace("/", "\")
            ElseIf backupDir = "" OrElse fsize < 1000000 OrElse tabFolder.SelectedIndex = 1 Then
                copyRC = ModuleMain.CopyQueueFromPhone(sFile, tmpOnPC)
                'Dim dic As Dictionary(Of String, String) = iPhoneInterface.GetFileInfo(sFile)
                'For Each item As KeyValuePair(Of String, String) In dic
                '    Debug.WriteLine("")
                'Next
            Else
                tmpOnPC = ModuleMain.GetBackupPath(True) & "\" & backupDir & sFile.Replace("/", "\")
            End If
            StatusNormal("")
        End If

        Select Case copyRC
            Case 0
                'Dim lastpreview As Boolean = btnPreview.Enabled
                btnPreview.Enabled = False

                Me.clearPreview()

                'File details for '" & sFile & "'.
                grpDetails.Text = String.Format(My.Resources.String29, sFile)
                txtFileDetails.Text = "<UNKNOWN FILE FORMAT>"

                StatusNormal("")
                Try
                    'now we have a temporary file, lets try to read it
                    Select Case imageIdx
                        Case IMAGE_FILE_TEXT

                            showText(tmpOnPC)

                        Case IMAGE_FILE_DATABASE

                            ShowDbInfo(tmpOnPC)

                        Case IMAGE_FILE_UNKNOWN ', IMAGE_FILE_RINGTONE
                            If fromBtn = True Then
                                showText(tmpOnPC)
                            Else
                                showFileDetails(sFile, tmpOnPC, False)
                                btnPreview.Enabled = True
                            End If

                        Case IMAGE_FILE_AUDIO, IMAGE_FILE_MOVIE
                            If ProgressEscapeFlg = False Then
                                pnlQt.LyricVisible = False
                                wasQTpreview = pnlQt.Play(tmpOnPC, "")
                                pnlQt.Visible = True
                            End If

                        Case IMAGE_FILE_MUSIC
                            If ProgressEscapeFlg = False Then
                                Dim comment As String = ""
                                If lstFiles.SelectedItems(0).SubItems.Count > 6 Then
                                    comment = lstFiles.SelectedItems(0).SubItems(8).Text
                                End If
                                wasQTpreview = pnlQt.Play(tmpOnPC, comment)
                                pnlQt.Visible = True
                                tabViewType.SelectedIndex = 0
                                tabViewType.Visible = True
                            End If

                        Case IMAGE_FILE_WEBBROWS
                            Select Case tmpOnPC.Substring(tmpOnPC.LastIndexOf("."))
                                Case ".pdf"
                                    WebBrws.ScriptErrorsSuppressed = False
                                    WebBrws.Navigate(New Uri("file:///" & tmpOnPC))
                                    WebBrws.Visible = True
                                    WebBrws.IsWebBrowserContextMenuEnabled = False

                                Case Else
                                    showText(tmpOnPC)

                                    'StatusNormal(WebBrws.StatusText)
                            End Select

                        Case Else   'IMAGE_FILE_IMAGE
                            Try
                                picOK = True
                                picFileDetails.Image = iPhonePNG.ImageFromFile(tmpOnPC)
                            Catch
                                picOK = False
                            End Try
                            If picOK Then
                                With picFileDetails
                                    If Not .Image Is Nothing Then
                                        If .Image.Width > .Width OrElse .Image.Height > .Height Then
                                            .SizeMode = PictureBoxSizeMode.Zoom
                                        Else
                                            .SizeMode = PictureBoxSizeMode.CenterImage
                                        End If
                                    End If
                                    .Visible = True
                                    txtFileDetails.Visible = False
                                End With
                            End If

                    End Select

                Catch ex As Exception
                    StatusWarning(ex.Message)
                End Try

            Case 1      ' Escape
                'NOP
            Case Else
                'it didn't copy from the phone correctly
                'The program was unable to copy " & sFile & " from the iPhone.  Sorry, try again!
                StatusWarning(String.Format(My.Resources.String30, sFile))
        End Select
    End Sub

    Private Sub showText(ByVal tmpfile As String)

        Dim fn As String = tmpfile.ToLower

        If fn.EndsWith(".htm") OrElse fn.EndsWith(".html") OrElse tmpfile.ToLower.EndsWith(".thm") Then
            WebBrws.ScriptErrorsSuppressed = False
            WebBrws.Navigate(New Uri("file:///" & tmpfile))
            WebBrws.Visible = True
            StatusNormal(WebBrws.StatusText)

        Else
                'clean up the temp file
                Dim sr As StreamReader = My.Computer.FileSystem.OpenTextFileReader(tmpfile)
                Dim str As String = sr.ReadToEnd().Replace(Chr(10), vbCrLf)
                sr.Close()

                If str.StartsWith("<?xml version=") Then
                    WebBrws.ScriptErrorsSuppressed = False
                    WebBrws.Navigate(New Uri("file:///" & tmpfile))
                    WebBrws.Visible = True
                    StatusNormal(WebBrws.StatusText)

                    'txtFileDetails.Text = ModuleMain.EncodePListFile(str).ToString()
                    'WebBrws.Visible = False

                    'ElseIf str.StartsWith("bplist") Then
                    '    Using fs As IO.FileStream = File.Open(tmpfile, FileMode.Open)
                    '        Using bsr As New BinaryReader(fs)
                    '            txtFileDetails.Text = ModuleMain.DecodePListFile(bsr.ReadBytes(CInt(fs.Length)))
                    '        End Using
                    '    End Using
                    '    txtFileDetails.Visible = True

                Else
                    txtFileDetails.Text = str
                    txtFileDetails.Visible = True
                End If
        End If
    End Sub

    Private Sub ShowDbInfo(ByVal tmpfile As String)
        Dim info As String

        If tmpfile.EndsWith(".zip") Then
            Dim txt As New System.Text.StringBuilder

            Dim fis As New java.io.FileInputStream(tmpfile)
            Dim zis As New java.util.zip.ZipInputStream(fis)
            Dim zs As List(Of java.util.zip.ZipEntry) = New List(Of java.util.zip.ZipEntry)
            Dim maxlen As Integer = 12

            'ZIP内のファイル情報を取得
            Dim ze As java.util.zip.ZipEntry = zis.getNextEntry()
            Do While (ze IsNot Nothing)
                If Not ze.isDirectory() Then
                    zs.Add(ze)
                    Dim l As Integer = ze.getName().Length
                    If maxlen < l Then
                        maxlen = l
                    End If
                End If
                ze = zis.getNextEntry()
            Loop

            txt.AppendLine(String.Format("{0," & maxlen.ToString() & "},{1}", " File Name", " Size     ,Comp Size , Date"))
            txt.AppendLine("-----------------------------------------------------------------------")
            For Each ze In zs
                '情報を表示する
                txt.Append(String.Format("{0," & maxlen.ToString() & "},{1,8} b,{2,8} b,", _
                                         ze.getName(), _
                                         ze.getSize(), ze.getCompressedSize()))
                'txt.Append(String.Format("{0:X}, ", ze.getCrc()))
                Dim [date] As New java.util.Date(ze.getTime())
                txt.Append(String.Format(" {0}", [date].ToString()))
                txt.AppendLine()
            Next

            '閉じる
            zis.close()
            fis.close()

            info = txt.ToString()

        Else
            info = DbManager.GetDBInfo(tmpfile)
        End If

        txtFileDetails.Text = info
        txtFileDetails.ScrollBars = ScrollBars.Both
        txtFileDetails.Visible = True

    End Sub

    Private Function doFileSelectedPreview(ByVal anySize As Boolean, ByVal fromBtn As Boolean) As String
        Dim sFile As String = ""
        Dim isSL As Boolean

        If lstFiles.SelectedItems.Count > 0 Then
            sFile = getSelectedFilename(isSL)

            If prevSelectedFile = sFile Then ' make sure we changed selections (handles multi-select better)
                Return sFile
            End If
            prevSelectedFile = sFile

            ' only if it is less than a big file size
            Dim sSize As String = lstFiles.SelectedItems(0).SubItems(1).Text
            If sSize <> "0 B" AndAlso isSL = False Then
                Me.showPreview(sFile, fromBtn, fileSizeAsInteger(sSize))
            Else
                Me.showFileDetails(sFile, "", isSL)
                StatusNormal("The file " & sFile & " is 0 bytes in length")
                btnPreview.Enabled = False
            End If
            'Else
            '    'the file is too big to auto-preview
            '    showFileDetails(sFile)
            '    'StatusWarning("The file " & sFile & " is too large to be previewed")
            '    btnPreview.Enabled = True
            'End If
        End If

        Return sFile

    End Function

    Private Sub showSelectedFileDetails()
        If lstFiles.SelectedItems.Count > 0 Then
            Dim isSL As Boolean
            Dim sFile As String = getSelectedFilename(isSL)

            If prevSelectedFile = sFile Then ' make sure we changed selections (handles multi-selecte better)
                Exit Sub
            End If
            prevSelectedFile = sFile

            clearPreview()

            showFileDetails(sFile, "", isSL)
        End If
    End Sub

    Private Sub pnlQt_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles pnlQt.VisibleChanged

        Try
            Dim vi As Boolean = pnlQt.Visible
            Me.tssSeparator.Visible = vi
            Me.tsmQtExportDialog1.Visible = vi
            Me.tsmQtMovieInfo1.Visible = vi
            Me.tsmQtInfo.Visible = vi

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private splFilesLock As Boolean = False

    Private Sub lstFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles lstFiles.SelectedIndexChanged

        If mvarClickedMouseButton = Windows.Forms.MouseButtons.Right Then
            Exit Sub
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            If Config.bShowPreview AndAlso Not splFilesLock Then
                lstFiles.Cursor = Cursors.No
                splFilesLock = True
                Try
                    Dim sFile As String = Me.doFileSelectedPreview(False, False)

                    Dim row As Integer
                    If ObjDb IsNot Nothing Then
                        row = ObjDb.Find("", sFile)
                    Else
                        row = -1
                    End If
                    If row > -1 Then
                        StatusNormal("Backuped date : " & ObjDb.GetValue(row, 0))  'ObjDb.DataSet.Tables(0).Rows(row).Item(0).ToString())
                    Else
                        'StatusNormal("")
                    End If

                Finally
                    splFilesLock = False
                    lstFiles.Cursor = Cursors.Default
                End Try
                'lstFiles.Focus()
            Else
                Me.showSelectedFileDetails()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub menuRightSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles menuRightSaveAs.Click

        Dim sSaveAsFilename As String, sFolder As String, sFileFromPhone As String

        If lstFiles.SelectedItems.Count = 1 Then
            sFolder = getSelectedPath()
            Dim sItem As ListViewItem = lstFiles.SelectedItems(0)
            'show them the save dialog
            fileSaveDialog.Title = "Save " & sItem.Text & " as ..."
            If tabFolder.SelectedIndex = 0 Then
                fileSaveDialog.FileName = FixPhoneFilename(sItem.Text)
            Else
                Dim ext As String = sItem.Text.Substring(sItem.Text.LastIndexOf("."))
                fileSaveDialog.FileName = FixPhoneFilename(sItem.SubItems(2).Text.Replace(" ", "_") & ext)
            End If
            If fileSaveDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                sSaveAsFilename = fileSaveDialog.FileName
                sFileFromPhone = sFolder & sItem.Text

                StatusNormal("Saving " & sItem.Text & "...")
                CopyFromPhonePNG(sFileFromPhone, sSaveAsFilename)
            End If
        Else
            Dim dFolder As String

            sFolder = getSelectedPath()
            If folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dFolder = folderBrowserDialog.SelectedPath & "\"
                For Each sItem As ListViewItem In lstFiles.SelectedItems
                    'show them the save dialog
                    sSaveAsFilename = dFolder & sItem.Text
                    sFileFromPhone = sFolder & sItem.Text

                    StatusNormal("Saving " & sItem.Text & "...")
                    CopyFromPhonePNG(sFileFromPhone, sSaveAsFilename)
                Next
            End If
        End If
    End Sub

    Private Sub menuRightBackupFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles menuRightBackupFile.Click

        Dim sSourcePath As String

        If lstFiles.SelectedItems.Count > 0 Then
            sSourcePath = getSelectedPath()

            For Each sItem As ListViewItem In lstFiles.SelectedItems
                ModuleMain.BackupFileFromPhone(sSourcePath, sItem.Text)
            Next
            ' redraw list
            Me.LoadFiles()
        End If

    End Sub

    Private Sub tsmDeleteBackupedFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles menuRightDeleteBackupedFile.Click

        Dim sSourcePath As String

        Try
            If lstFiles.SelectedItems.Count > 0 Then
                sSourcePath = getSelectedPath()

                For Each sItem As ListViewItem In lstFiles.SelectedItems
                    Dim path As String = sSourcePath & sItem.Text
                    ObjDb.RemoveRow("", path)

                    Try ' delete backuped file.
                        Dim subDir As String = GetBackupPath(True) & "\" & sItem.SubItems(2).Text
                        File.Delete(subDir & path.Replace("/", "\"))

                    Catch ex As IOException
                        StatusWarning(ex.Message)
                    End Try
                Next
                ' redraw list
                LoadFiles()
                'ObjDb.CommitView()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub menuRightReplaceFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles menuRightReplaceFile.Click

        'replace the selected file with one of their own
        Dim sSourceFilename As String, sFileToPhone As String

        If lstFiles.SelectedItems.Count = 1 Then
            'show them the open dialog
            fileOpenDialog.Title = String.Format(My.Resources.String18, lstFiles.SelectedItems(0).Text)
            fileOpenDialog.FileName = lstFiles.SelectedItems(0).Text
            If fileOpenDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                sSourceFilename = fileOpenDialog.FileName
                'replace the selected file with the source one
                Dim isSL As Boolean
                sFileToPhone = getSelectedFilename(isSL)
                If isSL Then
                    MsgBox("This file is Symbolic Link. Therefore it cannot replace.")
                Else
                    'this function also makes a backup
                    ModuleMain.CopyToPhone(sSourceFilename, sFileToPhone, Config.bConvertToiPhonePNG)
                End If
                'refresh the list view
                LoadFiles()
            End If
        Else
            'Only one file can be replaced at a time
            MsgBox(My.Resources.String24, MsgBoxStyle.Exclamation, "Selection error")
        End If

    End Sub

    Private Sub menuRightDeleteFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles menuRightDeleteFile.Click

        'delete the selected file
        Dim sFolder As String, sDeleteFilename As String, okDel As Boolean

        If lstFiles.SelectedItems.Count > 0 Then
            Try
                sFolder = getSelectedPath()
                For Each sItem As ListViewItem In lstFiles.SelectedItems
                    sDeleteFilename = sFolder & sItem.Text
                    okDel = True
                    If tsmConfirmDeletions.Checked Then
                        'Make them confirm it
                        Dim ans As MsgBoxResult
                        ans = MsgBox(String.Format(My.Resources.String17, sDeleteFilename), MsgBoxStyle.YesNoCancel, "Delete file?")
                        If ans = MsgBoxResult.No Then
                            okDel = False
                        ElseIf ans = MsgBoxResult.Cancel Then
                            Exit For
                        End If
                    End If
                    If okDel Then
                        ModuleMain.DelFromPhone(sDeleteFilename)
                    End If
                Next

                'refresh the list view
                LoadFiles()

            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
            End Try
        End If

    End Sub

    Private Sub menuDeleteFileWithoutSaving_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles menuDeleteFileWithoutSaving.Click

        'delete the selected file
        Dim sFolder As String, sDeleteFilename As String
        Dim okDel As Boolean

        If lstFiles.SelectedItems.Count > 0 Then
            Try
                sFolder = getSelectedPath()
                For Each sItem As ListViewItem In lstFiles.SelectedItems
                    sDeleteFilename = sFolder & sItem.Text
                    okDel = True
                    If tsmConfirmDeletions.Checked Then
                        'Make them confirm it
                        Dim ans As MsgBoxResult
                        ans = MsgBox(String.Format(My.Resources.String17, sDeleteFilename), MsgBoxStyle.YesNoCancel, "Delete file?")
                        If ans = MsgBoxResult.No Then
                            okDel = False
                        ElseIf ans = MsgBoxResult.Cancel Then
                            Exit For
                        End If
                    End If
                    If okDel Then
                        'make sure the source file exists
                        If iPhoneInterface.Exists(sDeleteFilename) Then
                            iPhoneInterface.DeleteFile(sDeleteFilename)
                        End If
                    End If
                Next

                'refresh the list view
                LoadFiles()

            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
            End Try
        End If

    End Sub

    Private Sub tsmCleanUpBackupFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmCleanUpBackupFiles.Click

        'this function goes through the backup files and cleans them, comparing them to others in the same folder with the same name
        Dim sMessage As String

        'sMessage = "This function goes through all of your backup files and attempts to remove the duplicates to save space." & vbCrLf & _
        '    "You really don't have to do this, it is better to have more backups then less...but press ok if you've got a lot of backups."
        sMessage = My.Resources.String7 & vbCrLf & My.Resources.String8 & vbCrLf

        If MsgBox(sMessage, MsgBoxStyle.OkCancel Or MsgBoxStyle.Information, "Confirm cleanup") = MsgBoxResult.Ok Then
            cleanupBackupFiles()
        End If

    End Sub

    Private Sub cleanupBackupFiles()

        StatusNormal(My.Resources.String44)
        Me.picDelete.Visible = True
        Me.Cursor = Cursors.WaitCursor
        Me.splFiles.Panel2Collapsed = True
        Try

            DbManager.PackDB(ModuleMain.GetBackupPath(True))
            Dim dg As frmBackupFiles = New frmBackupFiles
            dg.Show(Me)
            StatusNormal("")

        Catch ex As Exception
            StatusWarning(ex.Message)

        Finally
            Me.picDelete.Visible = False
            Me.splFiles.Panel2Collapsed = False
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub ToolStripMenuItemViewBackups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemViewBackups.Click
        Shell("explorer """ & GetBackupPath(True) & """", AppWinStyle.NormalFocus)
    End Sub

    Private Sub toolStripGoTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles toolStripGoTo1.Click, toolStripGoTo2.Click, toolStripGoTo3.Click, _
        toolStripGoTo19.Click, toolStripGoTo9.Click, toolStripGoTo8.Click, _
        toolStripGoTo7.Click, toolStripGoTo6.Click, toolStripGoTo5.Click, toolStripGoTo4.Click, _
        toolStripGoTo18.Click, toolStripGoTo17.Click, toolStripGoTo16.Click, toolStripGoTo15.Click, _
        toolStripGoTo14.Click, toolStripGoTo13.Click, toolStripGoTo12.Click, toolStripGoTo11.Click, _
        toolStripGoTo10.Click, ToolStripMenuItem2.Click, tsmITunesMusic.Click, tsmTTR.Click, _
        tsmNESROMS.Click, tsmISwitcherThemes.Click, tsmInstallerPackageSources.Click, _
        tsmFrotzGames.Click, tsmEBooks.Click, tsmDockSwapDocks.Click, _
        tsmCustomizeFiles.Click, tsmIFlashCards.Click, tsmGBAROMs.Click, tsmCameraRoll.Click

        Dim sPath As String
        Dim ts As ToolStripMenuItem

        ts = CType(sender, ToolStripMenuItem)
        sPath = CStr(ts.Tag())

        openPath(sPath)

    End Sub

    Private Sub openPath(ByVal sPath As String)
        Dim orgPath As String = sPath

        If Not Me.selectSpecificPath(sPath) Then
            If sPath.StartsWith("/var/mobile/") Then
                sPath = "/var/root" & sPath.Substring(11)
            End If
            If Not Me.selectSpecificPath(sPath) Then
                If iPhoneInterface.IsJailbreak Then
                    If Not iPhoneInterface.Exists(orgPath) Then
                        'Do you want to create " & sPath & "?"
                        If MsgBox(String.Format(My.Resources.String27, orgPath), MsgBoxStyle.YesNo, "Create Special Folder") = MsgBoxResult.Yes Then
                            If iPhoneInterface.CreateDirectory(orgPath) Then
                                If Not Me.selectSpecificPath(orgPath) Then
                                    'Error: The program could not find the path '" & sPath & "' on your iPhone.  Creation appeared to be successful
                                    MsgBox(String.Format(My.Resources.String25, orgPath), MsgBoxStyle.Critical)
                                End If
                            Else
                                '"Error: The program could not create the path '" & sPath & "' on your iPhone.  Have you successfully used jailbreak?
                                MsgBox(String.Format(My.Resources.String26, orgPath), MsgBoxStyle.Critical)
                            End If
                        End If
                    End If
                Else
                    MsgBox(String.Format(My.Resources.String26, orgPath), MsgBoxStyle.Critical)
                End If
            End If
        Else
            Dim nd As TreeNode() = trvFolders.Nodes.Find(sPath, True)
            If nd.Length = 1 Then
                nd(0).Tag = False
                nd(0).Expand()
            End If
        End If

    End Sub

    Private Sub tsmNewFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmNewFolder.Click

        Dim sPath As String, sNewFolder As String, bValid As Boolean = False
        Dim sNewPath As String

        sPath = getSelectedPath()
        sNewFolder = InputBox(String.Format(My.Resources.String21, sPath), "Create Folder In " & sPath, "NewFolder")
        sNewPath = sPath & sNewFolder

        'make sure it is valid
        If sNewFolder = "" Then
            ' user canceled
        ElseIf sNewFolder = "NewFolder" Then
            'MsgBox("You didn't change the default name, I am pretty sure you don't want a 'NewFolder' folder name...", MsgBoxStyle.Information, "Canceled")
            MsgBox(My.Resources.String46, MsgBoxStyle.Information, "Canceled")
        ElseIf sNewFolder.IndexOf("/") > -1 OrElse sNewFolder.IndexOf("\") > -1 _
                OrElse sNewFolder.IndexOf("*") > -1 OrElse sNewFolder.IndexOf("?") > -1 _
                OrElse sNewFolder.IndexOf("[") > -1 OrElse sNewFolder.IndexOf("]") > -1 Then
            'No spaces, slashes or other special characters are allowed in the folder name.
            MsgBox(My.Resources.String22, MsgBoxStyle.Information, "Canceled")
        ElseIf iPhoneInterface.Exists(sNewPath) Then
            'The path '{0}' already exists.
            MsgBox(String.Format(My.Resources.String23, sNewPath), MsgBoxStyle.Information, "Canceled")
        Else
            bValid = True
        End If

        If bValid Then
            'lets create the directory
            If iPhoneInterface.CreateDirectory(sNewPath) Then
                'it created successfully
                Me.trvFolders.SelectedNode.Collapse()
                ModuleMain.AddFoldersBeneath(trvFolders.SelectedNode)
                Me.trvFolders.SelectedNode.Expand()
                Me.selectSpecificPath(sPath)
            Else
                'it failed
                MsgBox("The path '" & sNewPath & "' failed to create due to an unknown interface failure.", MsgBoxStyle.Information, "Canceled")
            End If
        End If
    End Sub

    Private Sub menuDeleteFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles menuDeleteFolder.Click

        Dim tNode As TreeNode
        Dim sPath As String
        Dim bValid As Boolean = False
        Dim findNode() As TreeNode

        sPath = getSelectedFolder()
        tNode = trvFolders.SelectedNode

        If lstFiles.Items.Count > 0 OrElse tNode.Nodes.Count > 0 Then
            If tsmConfirmDeletions.Checked Then
                If MsgBox(String.Format(My.Resources.String19, sPath) & vbCrLf & vbCrLf _
                        & My.Resources.String20, MsgBoxStyle.YesNo, _
                        "Confirm Folder Deletion") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If

        If tNode.Nodes.Count > 0 Then ' always ask for folders with sub-folders
            If MsgBox("Are you absolutely sure you wish to delete this folder (" & sPath & ")?" & vbCrLf & vbCrLf _
                    & "This cannot be (easily) undone." & vbCrLf & vbCrLf _
                    & My.Resources.String20, MsgBoxStyle.YesNo, _
                    "Are you Sure?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            If ModuleMain.BackupDirectory(sPath) = 0 Then
                iPhoneInterface.DeleteDirectory(sPath, True)

                findNode = trvFolders.Nodes.Find(sPath, True)
                If findNode.Length = 0 Then
                    'could not find it for some reason, refresh the whole thing
                    Me.refreshFolders()
                Else
                    ' select the parent path
                    Dim sNewFolder As String = sPath.Substring(0, sPath.LastIndexOf("/"))
                    If sNewFolder = "" Then
                        sNewFolder = "/"
                    End If
                    trvFolders.Nodes.Remove(findNode(0)) ' delete the selected node

                    Me.selectSpecificPath(sNewFolder)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub menuDeleteFolderWithoutSaving_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles menuDeleteFolderWithoutSaving.Click

        Dim tNode As TreeNode
        Dim sPath As String
        Dim bValid As Boolean = False
        Dim findNode() As TreeNode

        sPath = getSelectedFolder()
        tNode = trvFolders.SelectedNode

        If lstFiles.Items.Count > 0 OrElse tNode.Nodes.Count > 0 Then
            If tsmConfirmDeletions.Checked Then
                If MsgBox(String.Format(My.Resources.String19, sPath) & vbCrLf & vbCrLf _
                        & My.Resources.String20, MsgBoxStyle.YesNo, _
                        "Confirm Folder Deletion") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        End If

        If tNode.Nodes.Count > 0 Then ' always ask for folders with sub-folders
            If MsgBox("Are you absolutely sure you wish to delete this folder (" & sPath & ")?" & vbCrLf & vbCrLf _
                    & "This cannot be (easily) undone." & vbCrLf & vbCrLf _
                    & My.Resources.String20, MsgBoxStyle.YesNo, _
                    "Are you Sure?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            'If ModuleMain.BackupDirectory(sPath) = 0 Then
            iPhoneInterface.DeleteDirectory(sPath, True)

            findNode = trvFolders.Nodes.Find(sPath, True)
            If findNode.Length = 0 Then
                'could not find it for some reason, refresh the whole thing
                Me.refreshFolders()
            Else
                ' select the parent path
                Dim sNewFolder As String = sPath.Substring(0, sPath.LastIndexOf("/"))
                If sNewFolder = "" Then
                    sNewFolder = "/"
                End If
                trvFolders.Nodes.Remove(findNode(0)) ' delete the selected node

                Me.selectSpecificPath(sNewFolder)
            End If
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub picFileDetails_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If picFileDetails.Visible Then
            If Not picFileDetails.Image Is Nothing Then
                If picFileDetails.Image.Width > picFileDetails.Width OrElse picFileDetails.Image.Height > picFileDetails.Height Then
                    picFileDetails.SizeMode = PictureBoxSizeMode.Zoom
                Else
                    picFileDetails.SizeMode = PictureBoxSizeMode.Normal
                End If
            End If
        End If
    End Sub

    Private Sub lstFiles_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) _
        Handles lstFiles.ColumnClick

        ' Set the ListViewItemSorter property to a new ListViewItemComparer 
        ' object. Setting this property immediately sorts the 
        ' ListView using the ListViewItemComparer object.
        Try
            ' turn off grouping when sorting
            If cmdShowGroups.Checked AndAlso tabFolder.SelectedIndex = 0 Then
                cmdShowGroups_Click(sender, e)
            End If
            If lstFilesSortOrder = SortOrder.None OrElse lstFilesSortOrder = SortOrder.Descending Then
                lstFilesSortOrder = SortOrder.Ascending
            Else
                lstFilesSortOrder = SortOrder.Descending
            End If
            Select Case lstFiles.Columns(e.Column).Text
                Case My.Resources.String31      'Size
                    Me.lstFiles.ListViewItemSorter = New ListViewSizeComparer(e.Column, lstFilesSortOrder)
                Case My.Resources.String52      'Track Number
                    Me.lstFiles.ListViewItemSorter = New ListViewIntComparer(e.Column, lstFilesSortOrder)
                Case Else
                    Me.lstFiles.ListViewItemSorter = New ListViewStringComparer(e.Column, lstFilesSortOrder)
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    ''' <summary>
    ''' ツリーノードのマウスクリック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub trvFolders_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) _
        Handles trvFolders.NodeMouseClick

        If e.Button = Windows.Forms.MouseButtons.Right Then
            trvFolders.SelectedNode = e.Node
        End If
    End Sub

    Private Sub menuRightClickFiles_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles menuRightClickFiles.Opening

        menuRightDeleteBackupedFile.Enabled = tsmBackupControl.Checked

        Select Case lstFiles.SelectedItems.Count
            Case 0
                e.Cancel = True
            Case 1
                If lstFiles.SelectedItems(0).SubItems(2).Text = "" Then
                    menuRightDeleteBackupedFile.Enabled = False
                End If
            Case Else
                Dim found As Boolean = False
                For Each itm As ListViewItem In lstFiles.SelectedItems
                    If itm.SubItems(2).Text <> "" Then
                        found = True
                    End If
                Next
                If Not found Then
                    menuRightDeleteBackupedFile.Enabled = False
                End If
        End Select

    End Sub

    Private Sub ColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles BlackToolStripMenuItem.Click, WhiteToolStripMenuItem.Click, GrayToolStripMenuItem.Click

        Dim s As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If s.Checked Then
            Select Case s.Text
                Case My.Resources.String32      '"Black"
                    picFileDetails.BackColor = Color.Black
                    GrayToolStripMenuItem.Checked = False
                    WhiteToolStripMenuItem.Checked = False

                Case My.Resources.String33      '"Gray"
                    picFileDetails.BackColor = Color.Gray
                    BlackToolStripMenuItem.Checked = False
                    WhiteToolStripMenuItem.Checked = False

                Case My.Resources.String34      '"White"
                    picFileDetails.BackColor = Color.White
                    BlackToolStripMenuItem.Checked = False
                    GrayToolStripMenuItem.Checked = False

            End Select
        Else
            picFileDetails.BackColor = PictureBox.DefaultBackColor
        End If
    End Sub

    'Private Sub menuSaveSummerboardTheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    '    Handles tsmAsSummerboardFolder.Click

    '    Dim dFolder As String, sSaveAsFilename As String, sFileFromPhone As String
    '    Dim sPath As String, strFolders() As iPhone.strDir

    '    If My.Settings.SummerboardPath <> "" Then
    '        folderBrowserDialog.SelectedPath = My.Settings.SummerboardPath
    '    End If
    '    folderBrowserDialog.Description = My.Resources.String45

    '    If folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        Me.Cursor = Cursors.WaitCursor
    '        Application.DoEvents() ' update display

    '        My.Settings.SummerboardPath = Path.GetDirectoryName(folderBrowserDialog.SelectedPath) ' save the parent

    '        dFolder = folderBrowserDialog.SelectedPath & "\"
    '        ' save wallpaper jpg as PNG (~/Library/LockBackground.jpg)
    '        StatusNormal(My.Resources.String9)
    '        CopyFromPhoneMakePNG(tildeDir + "/Library/LockBackground.jpg", dFolder & "Wallpaper.png")

    '        ' save Dock Background (SBDockBG2.png -> Dock.png)
    '        StatusNormal(My.Resources.String10)
    '        CopyFromPhonePNG("/System/Library/CoreServices/SpringBoard.app/SBDockBG2.png", dFolder & "Dock.png")

    '        ' save Icons for applications

    '        Dim appFolders() As String = {"MobileCal", "MobileMail", "MobileMusicPlayer", "MobileNotes", "MobilePhone", "MobileSafari", "MobileSMS", "MobileTimer", "Preferences"}
    '        Dim appNames() As String = {"Calendar", "Mail", "iPod", "Notes", "Phone", "Safari", "Text", "Clock", "Settings"}
    '        Dim newIconName As String

    '        dFolder = dFolder & "Icons\"
    '        Directory.CreateDirectory(dFolder)
    '        sPath = "/Applications/"
    '        strFolders = iPhoneInterface.GetDirectories(sPath)
    '        For Each sFolder As iPhone.strDir In strFolders
    '            If sFolder.Dir.EndsWith(".app") Then
    '                StatusNormal(My.Resources.String11 + sFolder.Dir)
    '                If sFolder.Dir = "MobileSlideShow.app" Then
    '                    Dim iNames() As String = {"icon-Photos.png", "icon-Camera.png"}
    '                    For Each sIcon As String In (iNames)
    '                        sFileFromPhone = sPath & sFolder.Dir & "/" & sIcon
    '                        sSaveAsFilename = dFolder & sIcon.Substring(5, 6) & ".png"
    '                        CopyFromPhonePNG(sFileFromPhone, sSaveAsFilename)
    '                    Next
    '                Else
    '                    sFileFromPhone = sPath & sFolder.Dir & "/icon.png"
    '                    newIconName = Microsoft.VisualBasic.Left(sFolder.Dir, sFolder.Dir.Length - 4)
    '                    Dim nii As Integer = Array.IndexOf(appFolders, newIconName)
    '                    If nii >= 0 Then
    '                        newIconName = appNames(nii)
    '                    End If
    '                    sSaveAsFilename = dFolder & newIconName & ".png"
    '                    CopyFromPhonePNG(sFileFromPhone, sSaveAsFilename)
    '                End If
    '            End If
    '        Next
    '        StatusNormal("")
    '        Me.Cursor = Cursors.Arrow
    '    End If
    'End Sub

    'Private Sub tsmAsCustomizeFolders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    '    Handles tsmAsCustomizeFolders.Click

    '    Dim frmOptions As frmCustomizeOptions = New frmCustomizeOptions()
    '    If frmOptions.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        If frmOptions.HasChecked() Then
    '            folderBrowserDialog.SelectedPath = My.Settings.CustomizePath
    '            If folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '                My.Settings.CustomizePath = folderBrowserDialog.SelectedPath
    '                Me.Cursor = Cursors.WaitCursor
    '                Application.DoEvents() ' show cursor
    '                SaveCustomizeToFolder(frmOptions, folderBrowserDialog.SelectedPath)
    '                Me.Cursor = Cursors.Arrow
    '            End If
    '        End If
    '    End If
    '    frmOptions.Dispose()
    'End Sub

    Private Sub tsmIPhoneToPC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmIPhoneToPC.Click

        Config.bConvertToPNG = tsmIPhoneToPC.Checked
    End Sub

    Private Sub tsmPCToIPhone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmPCToIPhone.Click

        Config.bConvertToiPhonePNG = tsmPCToIPhone.Checked
    End Sub

    Private splDistance As Integer = 330

    Private Sub PreviewChanged()
        chkPreviewEnabled.Checked = Config.bShowPreview
        tsmShowPreviews.Checked = Config.bShowPreview
        btnPreview.Enabled = Config.bShowPreview
        If Config.bShowPreview Then
            doFileSelectedPreview(False, False)
            'splFiles.SplitterDistance = splDistance
        Else
            splDistance = splFiles.SplitterDistance
            clearPreview()
            prevSelectedFile = "" ' force preview next time
            'splFiles.SplitterDistance = splFiles.Height - 95
        End If
    End Sub

    Private Sub tsmShowPreviews_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmShowPreviews.Click

        Config.bShowPreview = tsmShowPreviews.Checked
        PreviewChanged()
    End Sub

    Private Sub tsmBackupControl_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles tsmBackupControl.CheckedChanged

        Config.bBackupControled = tsmBackupControl.Checked
        tsmCleanUp.Enabled = tsmBackupControl.Checked

    End Sub

    Private Sub tsmBackupControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles tsmBackupControl.Click

        'Config.bBackupControled = tsmBackupControl.Checked
        'tsmCleanUp.Enabled = tsmBackupControl.Checked

    End Sub

    Private Sub chkPreviewEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkPreviewEnabled.CheckedChanged

        Config.bShowPreview = chkPreviewEnabled.Checked
        PreviewChanged()
    End Sub

    Private Sub tsmSaveFolderIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmSaveFolderIn.Click

        folderBrowserDialog.SelectedPath = My.Settings.SaveFolderPath
        If folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Dim dPath As String = folderBrowserDialog.SelectedPath
            My.Settings.SaveFolderPath = dPath
            Dim sPath As String = getSelectedFolder()
            dPath &= "\" & Path.GetFileName(sPath)
            doSaveFolderIn(sPath, dPath)
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub tsmBackupFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmBackupFolder.Click

        Me.Cursor = Cursors.WaitCursor
        ModuleMain.BackupDirectory(getSelectedFolder())
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cmdRenameFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cmdRenameFile.Click

        Dim isSL As Boolean
        Dim oldPath As String = getSelectedFilename(isSL)
        Dim newPath As String
        Dim newName As String = InputBox("Enter new folder name:", "Rename file ", Path.GetFileName(oldPath))
        If newName <> "" Then
            If newName.IndexOf("/") > -1 Then
                StatusWarning("Can not use rename to move a file")
                Exit Sub
            End If
            newPath = PhoneGetDirectoryName(oldPath) & "/" & newName
            If iPhoneInterface.Rename(oldPath, newPath) Then
                LoadFiles()
            End If
        End If

    End Sub

    Private Sub tsmRenameFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmRenameFolder.Click

        Dim oldPath As String = getSelectedFolder(), newPath As String
        Dim newName As String = InputBox(My.Resources.String48, "Rename folder", Path.GetFileName(oldPath)) '"Enter new folder name:"
        If newName <> "" Then
            If newName.IndexOf("/") > -1 Then
                StatusWarning(My.Resources.String47)    '"Can not use rename to move a folder"
                Exit Sub
            End If
            newPath = PhoneGetDirectoryName(oldPath) & "/" & newName
            If iPhoneInterface.Rename(oldPath, newPath) Then
                Dim tNode As TreeNode = trvFolders.SelectedNode
                tNode.Text = newName
                tNode.Name = newPath
            End If
        End If
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnPreview.Click

        lstFiles.Select()
        prevSelectedFile = "" ' force preview
        doFileSelectedPreview(True, True)
    End Sub

    Private Sub chkPreviewEnabled_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkPreviewEnabled.Enter

        lstFiles.Select()
    End Sub

    Private Sub cmdShowGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cmdShowGroups.Click

        lstFiles.ShowGroups = Not lstFiles.ShowGroups
        cmdShowGroups.Checked = lstFiles.ShowGroups
        If lstFiles.ShowGroups AndAlso bNowConnected Then
            LoadFiles()
        End If
    End Sub

    Private Sub cmdFavorite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim anItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Me.selectSpecificPath(anItem.Tag.ToString())
    End Sub

    Private Sub AddNewFavorite(ByVal favName As String, ByVal favPath As String)
        favNames.Add(favName)
        favPaths.Add(favPath)
        Dim newFav As ToolStripMenuItem = CType(mnuFavorites.DropDownItems.Add(favName, Nothing, AddressOf cmdFavorite_Click), ToolStripMenuItem)
        newFav.Tag = favPath
        newFav.ToolTipText = favPath
    End Sub

    Private Sub AddToFavoritesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles AddToFavoritesToolStripMenuItem.Click

        If getSelectedFolder() <> "" Then
            Dim frmFav As frmAddFavorite = New frmAddFavorite(getSelectedFolder())
            If frmFav.ShowDialog() = Windows.Forms.DialogResult.OK Then
                AddNewFavorite(frmFav.favName, frmFav.favPath)
            End If
        End If
    End Sub

    Private Sub mnuFavorites_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles mnuFavorites.DropDownOpening

        AddToFavoritesToolStripMenuItem.Enabled = (getSelectedFolder() <> "")
        OrganizeFavoritesToolStripMenuItem.Enabled = (favNames.Count > 0)
    End Sub

    Private Sub menuSetTooltips(ByVal aMenu As ToolStripDropDownItem)
        ' setup tooltips
        For Each anItem As ToolStripItem In aMenu.DropDownItems
            If TypeOf anItem Is ToolStripMenuItem Then
                anItem.ToolTipText = CStr(anItem.Tag)
            End If
        Next
    End Sub

    Private Sub LoadFavoritesMenu()
        ' clear any existing menuitems
        For j1 As Integer = mnuFavorites.DropDownItems.Count - 1 To 3 Step -1
            mnuFavorites.DropDownItems.RemoveAt(j1)
        Next

        ' load up the favorite menu items
        For j1 As Integer = 0 To favNames.Count - 1
            Dim newFav As ToolStripMenuItem = CType(mnuFavorites.DropDownItems.Add(favNames(j1), Nothing, AddressOf cmdFavorite_Click), ToolStripMenuItem)
            newFav.Tag = favPaths(j1)
            newFav.ToolTipText = favPaths(j1)
        Next
    End Sub

    Private Sub OrganizeFavoritesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles OrganizeFavoritesToolStripMenuItem.Click

        Dim orgDialog As New frmOrganizeFavorites(favNames, favPaths)

        If orgDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            favNames.Clear()
            favPaths.Clear()
            For Each m As String In orgDialog.favNames
                favNames.Add(m)
            Next
            For Each m As String In orgDialog.favPaths
                favPaths.Add(m)
            Next
        End If
        LoadFavoritesMenu()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles Timer1.Tick

        Static lastval0 As Integer = -1
        Static lastval1 As Integer = -1

        Try
            If ProgressDepth <= MAX_PROG_DEPTH Then
                With ProgressBars(ProgressDepth)
                    If ProgressValue(ProgressDepth) < .Maximum Then
                        '.PerformStep()
                        .Value = ProgressValue(ProgressDepth)
                        'If lastval0 <> ProgressValue(0) Then
                        lastval0 = ProgressValue(0)
                        ProgressBars(0).Value = lastval0
                        'tlbStatusStrip.Refresh()
                        If ProgressFullSize > 1024 Then
                            tslProgress.Text = CInt(ProgressSize / 1024).ToString() & " of " & CInt(ProgressFullSize / 1024).ToString() & " KByte "
                        ElseIf lastval0 > 50 Then
                            tslProgress.Text = lastval0.ToString() & "/" & .Maximum.ToString()
                        End If
                        'End If
                    End If
                End With
            Else
                If ProgressFullSize > 1024 Then
                    tslProgress.Text = CInt(ProgressSize / 1024).ToString() & " of " & CInt(ProgressFullSize / 1024).ToString() & " KByte "
                End If
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnCancel.Click

        Try
            ProgressEscapeFlg = True
            btnCancel.Visible = False
            tslProgress.Visible = False
            ProgressBars(0).Visible = False
            ProgressBars(1).Visible = False
            ResetStatus()       'ProgressDepth = -1
            mvarInProCount = 0

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles AboutToolStripMenuItem.Click

        Dim dialog As AboutBox = New AboutBox
        dialog.ShowDialog()
    End Sub

    Private Sub tsmBackupDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmBackupDirectory.Click

        Dim dbDir As String = My.Settings.DbPath
        Dim dialog As New BackupDirDialog
        Dim rc As DialogResult = dialog.ShowDialog(Me)

        If rc = Windows.Forms.DialogResult.OK Then
            tsmBackupControl.Checked = Config.bBackupControled
            If dbDir <> My.Settings.DbPath AndAlso Config.bBackupControled Then
                restructureDB()
            End If
        End If

    End Sub

    Private Sub menuRightClickFolders_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles menuRightClickFolders.VisibleChanged

        If menuRightClickFolders.Visible = True Then
            Dim enable As Boolean = Not (trvFolders.SelectedNode.FullPath = "[root]")
            menuRightSaveAs.Visible = enable
            menuRightBackupFile.Visible = enable
            cmdRenameFile.Visible = enable
            menuRightReplaceFile.Visible = enable
            menuRightDeleteFile.Visible = enable
        End If
    End Sub

    Private Sub tsmFileList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmFileList.Click

        Dim dg As frmBackupFiles = New frmBackupFiles()

        Me.Refresh()
        ObjDb.ExportDB()

        dg.ShowDialog(Me)
        dg.Dispose()

    End Sub

    Private Sub lstFiles_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles lstFiles.MouseDown

        mvarClickedMouseButton = e.Button

    End Sub

    Private Delegate Sub refreshDBDelegate()
    Private processingFlg As Boolean = False

    Private Sub tsmRestructureDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmRestructureDB.Click

        restructureDB()
    End Sub

    Public Sub restructureDB()
        Me.Refresh()
        Me.picBusy.Visible = True
        Me.Cursor = Cursors.WaitCursor
        Me.splFiles.Panel2Collapsed = True

        Try
            processingFlg = True

            Dim td As New refreshDBDelegate(AddressOf refreshDB)
            td.BeginInvoke(Nothing, Nothing) 'Runs on a worker thread from the pool

            Thread.Sleep(800)
            Do
                Thread.Sleep(200)
                StatusNormal(My.Resources.String40 & ObjDb.FileCount.ToString())
                Application.DoEvents()
            Loop While processingFlg = True
            Me.picBusy.Visible = False
            StatusNormal(My.Resources.String39)

            Dim dg As New frmBackupFiles
            dg.ShowDialog(Me)
            dg.Dispose()
            StatusNormal("")

        Catch ex As Exception
            StatusWarning(ex.Message)

        Finally
            Me.picBusy.Visible = False
            Me.splFiles.Panel2Collapsed = False
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub refreshDB()
        Try
            Dim backupFilePath As String = GetBackupPath(True)
            If ObjDb Is Nothing Then
                ObjDb = ModuleMain.GetBackupList()
            End If
            ObjDb.Source = My.Settings.DbPath
            ObjDb.RefreshDB(backupFilePath)

        Finally
            processingFlg = False
        End Try
    End Sub

    'Menu > Help > HomePage
    Private Sub tsmHomePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmHomePage.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            WebBrws.ScriptErrorsSuppressed = False
            WebBrws.Navigate(New Uri(My.Settings.HomepageURL))
            WebBrws.Visible = True
            WebBrws.IsWebBrowserContextMenuEnabled = False
            txtFileDetails.Visible = False
            pnlQt.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    'Menu > Help > Check a latest version
    Private Sub tsmCheckALatestVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmCheckALatestVersion.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            WebBrws.ScriptErrorsSuppressed = False
            WebBrws.Navigate(New Uri(My.Settings.DownloadURL))
            WebBrws.Visible = True
            WebBrws.IsWebBrowserContextMenuEnabled = False
            txtFileDetails.Visible = False
            pnlQt.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    'Menu > Help > Modification history
    Private Sub tsmModificationHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmModificationHistory.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            WebBrws.ScriptErrorsSuppressed = False
            WebBrws.Navigate(New Uri(My.Settings.ModHistoryURL))
            WebBrws.Visible = True
            WebBrws.IsWebBrowserContextMenuEnabled = False
            txtFileDetails.Visible = False
            pnlQt.Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private zoomflg As Boolean = True
    Private Sub chkZoom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkZoom.CheckedChanged, tsbZoom.CheckedChanged

        Dim checked As Boolean

        If sender.GetType() Is GetType(CheckBox) Then
            If chkZoom.Checked Then
                checked = True
            Else
                checked = False
            End If
            tsbZoom.Checked = checked
        Else
            If tsbZoom.Checked Then
                checked = True
            Else
                checked = False
            End If
            chkZoom.Checked = checked
        End If

        pnlQt.SuspendLayout()
        splFiles.Panel1Collapsed = checked
        splMain.Panel1Collapsed = checked
        pnlQt.ResumeLayout()

    End Sub

    Private Sub tsbFullScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsbFullScreen.Click

        If mvarFullScreenMode = False Then
            ' ＜フルスクリーン表示への切り替え処理＞

            ' ウィンドウの状態を保存する
            prevFormState = Me.WindowState
            ' 境界線スタイルを保存する
            prevFormStyle = Me.FormBorderStyle

            ' 0. 「最大化表示」→「フルスクリーン表示」では
            ' タスク・バーが消えないので、いったん「通常表示」を行う
            If Me.WindowState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
            End If

            ' フォームのサイズを保存する
            prevFormSize = New Size(Me.Width, Me.Height)

            ' 1. フォームの境界線スタイルを「None」にする
            Me.FormBorderStyle = FormBorderStyle.None
            ' 2. フォームのウィンドウ状態を「最大化」する
            Me.WindowState = FormWindowState.Maximized

            ' ボタンの表示を変更する
            'Me.tsbFullScreen.Text = "通常表示する"

            ' フルスクリーン表示をONにする
            mvarFullScreenMode = True

        Else
            ' ＜通常表示／最大化表示への切り替え処理＞

            ' フォームのウィンドウのサイズを元に戻す
            Me.Size = prevFormSize

            ' 0. 最大化表示に戻す場合にはいったん通常表示を行う
            ' （フルスクリーン表示の処理とのバランスと取るため）
            If prevFormState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
            End If

            ' 1. フォームの境界線スタイルを元に戻す
            Me.FormBorderStyle = prevFormStyle

            ' 2. フォームのウィンドウ状態を元に戻す
            Me.WindowState = prevFormState

            ' ボタンの表示を変更する
            'Me.tsbFullScreen.Text = "フルスクリーン表示する"

            ' フルスクリーン表示をOFFにする
            mvarFullScreenMode = False

        End If

    End Sub

    Private Sub qtPlugin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        tsmQtFullscreen.Checked = False
        pnlQt.QT.FullScreen = False
        'qtPlugin.BorderStyle = QTOControlLib.BorderStylesEnum.bsPlain

        'qtPlugin.Visible = False
    End Sub

    Private Sub qtPlugin_ShowStatusString(ByVal message As String)

        StatusNormal(message)

    End Sub

    Private Sub WebBrws_StatusTextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles WebBrws.StatusTextChanged

        StatusNormal(WebBrws.StatusText)
    End Sub

    Private Sub tsmFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles tsmFile.Click

        tsmCleanUp.Enabled = (Config.bBackupControled And (ObjDb IsNot Nothing))
    End Sub

    Private Sub tsmDisplaySongTitle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmDisplaySongTitle.Click

        Config.bShowSongTitle = tsmDisplaySongTitle.Checked
    End Sub

    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Resize

        If Me.Width > 600 Then
            tstAddress.Width = Me.Width - 500
        End If
    End Sub

    Private Sub qtBuff_AnnotationUpdate(ByVal annotation As String) _
        Handles qtBuff.AnnotationUpdate

        mvarCurrAnnotation = annotation
    End Sub

    Private Sub tsmQtFullscreen_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles tsmQtFullscreen.CheckedChanged

        pnlQt.QT.FullScreen = tsmQtFullscreen.Checked
    End Sub

    Private Sub tsbAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsbAddress.Click

        Dim sPath As String = tstAddress.Text
        If sPath.StartsWith("http://") Then
            Process.Start(sPath)
        Else
            openPath(sPath)
        End If
    End Sub

    Private Sub tstAddress_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tstAddress.KeyUp
        If e.KeyCode = 13 Then
            openPath(tstAddress.Text)
        End If
    End Sub

    Private Sub trvITunes_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) _
        Handles trvITunes.AfterCheck

        Static processing As Boolean = False

        'If TreeNode.ReferenceEquals(e.Node, trvITunes.Nodes(0)) Then
        Dim checked As Boolean = e.Node.Checked

        If processing Then Exit Sub

        Try
            Select Case e.Node.Level
                Case 0
                    For Each node As TreeNode In trvITunes.Nodes(0).Nodes
                        node.Checked = checked
                        For Each sNode As TreeNode In node.Nodes
                            sNode.Checked = checked
                        Next
                    Next
                Case 1
                    For Each node As TreeNode In e.Node.Nodes
                        node.Checked = checked
                    Next
                Case 2
                    If checked = False Then
                        processing = True
                        e.Node.Parent.Checked = False
                        processing = False
                    End If
            End Select

            If e.Node.Checked Then
                btnExport.Enabled = True
                cmbOutputDir.Enabled = True
            Else
                Dim actvated As Boolean = False
                For Each node As TreeNode In trvITunes.Nodes(0).Nodes
                    If node.Checked Then
                        actvated = True
                        Exit For
                    End If
                    For Each sNode As TreeNode In node.Nodes
                        If sNode.Checked Then
                            actvated = True
                            Exit For
                        End If
                    Next
                Next
                btnExport.Enabled = actvated
                cmbOutputDir.Enabled = actvated
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub trvITunes_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) _
        Handles trvITunes.AfterSelect

        Dim lstTemp As ListViewItem
        Dim selNode As TreeNode = e.Node
        Dim listRow As Integer = 0
        Dim files As IPod.Music.TrackItem()

        Try
            If selNode.Text = NO_NAME_LABEL Then
                files = mvarItunesMan.GetSongs("")
            Else
                files = mvarItunesMan.GetSongs(selNode.Text)
            End If
            lstFiles.BeginUpdate()
            lstFiles.Items.Clear()
            For listRow = 0 To files.Length - 1
                Dim item As IPod.Music.TrackItem = files(listRow)
                lstTemp = New ListViewItem(item.Location.Replace("\", "/"))
                lstTemp.ImageIndex = getImageIndexForFile(item.Location)
                With lstTemp.SubItems
                    .Add(Me.fileSizeAsString(item.FileSize))
                    .Add(item.Title)
                    .Add(getFiletype(lstTemp.ImageIndex))
                    .Add(item.Album)
                    .Add(item.TrackNumber.ToString)
                    .Add(item.Genre)
                    .Add(item.FileType)
                    .Add(item.Commnet)
                End With
                If item.Album = "" Then
                    If item.Artist = e.Node.Parent.Text Then
                        lstFiles.Items.Add(lstTemp)
                    End If
                Else
                    lstFiles.Items.Add(lstTemp)
                End If
            Next

            StatusNormal(files.Length.ToString & " files found")
            Dim ind As Integer = iTunesPath.IndexOf("/iTunes_Control/")
            If ind = -1 Then
                ind = iTunesPath.IndexOf("\iPod_Control\")
                If ind > -1 Then
                    grpFiles.Text = iTunesPath.Substring(0, ind)
                End If
            Else
                grpFiles.Text = iTunesRoot
            End If

            Me.getAlbums(selNode, selNode.Text)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lstFiles.EndUpdate()
        End Try

    End Sub

    Private Sub tabFolder_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles tabFolder.SelectedIndexChanged

        Static lastAttributeWidth As Integer = 150

        Try
            With Me.lstFiles
                .SuspendLayout()
                If Config.bBackupControled OrElse tabFolder.SelectedIndex = 1 Then
                    cohAttribute.Width = lastAttributeWidth
                Else
                    'Hide attribute column
                    If cohAttribute.Width > 0 Then
                        lastAttributeWidth = cohAttribute.Width
                    End If
                    cohAttribute.Width = 0
                End If

                Select Case tabFolder.SelectedIndex
                    Case 0      ' Folder
                        .Columns(2).Text = My.Resources.String49    'Backup path
                        .Columns(3).Width = 110
                        .Columns.RemoveByKey("Album")
                        .Columns.RemoveByKey("TrackNumber")
                        .Columns.RemoveByKey("Genre")
                        .Columns.RemoveByKey("Type")
                        .Columns.RemoveByKey("Comment")

                    Case 1      ' iTunes
                        .Columns(2).Text = My.Resources.String50    'Song name
                        .Columns(3).Width = 0
                        If .Columns.Count = 4 Then
                            .Columns.Add("Album", My.Resources.String51, 150)
                            .Columns.Add("TrackNumber", My.Resources.String52, 70, HorizontalAlignment.Right, "")
                            .Columns.Add("Genre", My.Resources.String53, 60)
                            .Columns.Add("Type", My.Resources.String54, 120)
                            .Columns.Add("Comment", My.Resources.String55, 160)
                        End If

                        If bNowConnected = False AndAlso trvITunes.Nodes.Count = 0 Then
                            iTunesRoot = ITunesDb.GetIPodRoot()

                            If iTunesRoot <> "" Then
                                Dim dr As New DriveInfo(iTunesRoot)
                                Me.getArtists(iTunesRoot & "iPod_Control\iTunes", dr.VolumeLabel)
                                iTunesPath = iTunesRoot & "iPod_Control\iTunes"
                            Else
                                Me.btnExport.Enabled = False
                                Me.cmbOutputDir.Enabled = False
                            End If
                        End If

                        If Not mvarItunesMan.Loaded AndAlso iTunesPath <> "" Then
                            If CopyFromPhone(iTunesPath, My.Settings.DbPath & "\iTunesDB") <> 0 Then
                                Me.getArtists(My.Settings.DbPath, "All")
                            End If
                        End If

                    Case 2      ' App
                        .Columns(2).Text = My.Resources.String49    'Backup path
                        .Columns(3).Width = 110
                        .Columns.RemoveByKey("Album")
                        .Columns.RemoveByKey("TrackNumber")
                        .Columns.RemoveByKey("Genre")
                        .Columns.RemoveByKey("Type")
                        .Columns.RemoveByKey("Comment")

                        If bNowConnected = True AndAlso trvApps.Nodes.Count = 0 Then
                            Me.setApps("/private/var/mobile/Applications")
                        End If

                    Case 3      ' AMDevice

                End Select
                .Items.Clear()
                .ResumeLayout()
            End With

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Function setApps(ByVal dir As String) As Boolean

        If Not iPhoneInterface.Exists(dir) Then
            trvApps.Nodes.Add("Apps not found.")
            Return False
        End If

        Dim rootNode As TreeNode
        Dim appNode As TreeNode

        Me.UseWaitCursor = True
        trvApps.BeginUpdate()
        Try
            dir &= "/"
            trvApps.Nodes.Clear()
            rootNode = New TreeNode(STRING_APPL)
            rootNode.ContextMenuStrip = menuRightClickFolders
            rootNode.Name = "/"
            trvApps.Nodes.Add(rootNode)
            IncrementStatus(0)

            Dim tn As TreeNode = trvApps.Nodes(0)
            Dim sFolders As iPhone.strDir() = iPhoneInterface.GetDirectories(dir)
            Dim listRow As Integer = 0

            StartStatus(sFolders.Length, sFolders.Length)
            For Each item As iPhone.strDir In sFolders
                If item.IsDir Then
                    For Each app As iPhone.strDir In iPhoneInterface.GetDirectories(dir & item.Dir)
                        If app.IsDir AndAlso app.Dir.EndsWith(".app") Then
                            appNode = tn.Nodes.Add(app.Dir)
                            appNode.Tag = dir & item.Dir
                            Exit For
                        End If
                    Next
                End If
                IncrementStatus(listRow)
                listRow += 1
            Next
            trvApps.Sort()
            rootNode.Expand()

        Finally
            EndStatus()
            trvApps.EndUpdate()
            Me.UseWaitCursor = False
        End Try

    End Function

    'Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For Each node As TreeNode In trvITunes.Nodes
    '        node.Checked = False
    '    Next
    'End Sub

    'Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For Each node As TreeNode In trvITunes.Nodes
    '        node.Checked = True
    '    Next
    'End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles btnExport.Click

        Dim sRootPath As String = ""
        Dim escaped As Boolean = False
        Dim dr As DialogResult

        Dim fb As New FolderBrowserDialog
        fb.Description = My.Resources.String60
        Select Case cmbOutputDir.Text
            Case My.Resources.String56
                fb.RootFolder = Environment.SpecialFolder.MyMusic
            Case My.Resources.String57
                fb.RootFolder = Environment.SpecialFolder.DesktopDirectory
            Case My.Resources.String58
                fb.RootFolder = Environment.SpecialFolder.MyComputer
            Case My.Resources.String59
                fb.RootFolder = Environment.SpecialFolder.MyDocuments
            Case Else
                fb.SelectedPath = cmbOutputDir.Text
        End Select
        dr = fb.ShowDialog()
        If dr = Windows.Forms.DialogResult.OK Then
            sRootPath = fb.SelectedPath
            My.Settings.ExportDir = cmbOutputDir.Text
        Else
            Exit Sub
        End If

        Try
            If trvITunes.Nodes.Count = 0 Then Exit Sub

            For Each node As TreeNode In trvITunes.Nodes(0).Nodes
                If node.Checked Then
                    escaped = Me.exportFiles(node, sRootPath)
                    If escaped Then
                        Exit For
                    End If
                Else
                    For Each sNode As TreeNode In node.Nodes
                        If sNode.Checked Then
                            escaped = Me.exportFiles(sNode, sRootPath)
                            If escaped Then
                                Exit For
                            End If
                        End If
                    Next
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)

        End Try

    End Sub

    Private Function exportFiles(ByVal node As TreeNode, ByVal sRootPath As String) As Boolean
        Dim escaped As Boolean = False

        StatusNormal(node.Text)
        Dim listRow As Integer = 0
        Dim files As IPod.Music.TrackItem() = mvarItunesMan.GetSongs(node.Text)
        Dim sSourcePath As String = iTunesRoot & "/"
        Dim sDestinationPath As String = ""
        Dim artist As String = node.Text

        If node.Level = 2 Then
            artist = node.Parent.Text
        End If
        If files.Length > 0 Then
            sDestinationPath = sRootPath & "\" & artist & "\"
            ModuleMain.needDir(sDestinationPath)
        End If
        StartStatus(files.Length, files.Length)
        Try
            For listRow = 0 To files.Length - 1
                Dim item As IPod.Music.TrackItem = files(listRow)
                If artist = item.Artist Then
                    StatusNormal(item.Artist & " - " & item.Album & " - " & item.Title)

                    Dim sSourceFile As String = item.Location.Replace("\", "/")
                    Dim ext As String = sSourceFile.Substring(sSourceFile.LastIndexOf("."))
                    Dim subPath As String = sDestinationPath & item.Album.Replace("/", "_") & "\"
                    Dim destFileName As String = subPath & item.TrackNumber.ToString("00.") _
                                & FixPhoneFilename(item.Title.Replace(" ", "_")) & ext
                    Dim rc As Long = 0

                    ModuleMain.needDir(subPath)
                    If bNowConnected Then
                        rc = ModuleMain.CopyFromPhone(sSourcePath & sSourceFile, destFileName)
                    Else
                        File.Copy((iTunesRoot & sSourceFile).Replace("/", "\"), destFileName, True)
                    End If

                    If rc = -2 Then
                        escaped = True
                        Exit Try
                    End If
                    If IncrementStatus(listRow) Then
                        escaped = True
                        Exit Try 'increment our progressbar
                    End If
                End If
            Next
        Finally
            EndStatus()
            StatusNormal("")
        End Try

        Return escaped

    End Function

    Private Const WM_DEVICECHANGE As Integer = &H219
    Private Const DBT_DEVNODES_CHANGED As Integer = &H7
    Private Const DBT_DEVICEARRIVAL As Integer = &H8000
    Private Const DBT_DEVICEREMOVECOMPLETE As Integer = &H8004

    <DebuggerStepThrough()> _
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        If m.Msg = WM_DEVICECHANGE AndAlso bNowConnected = False Then
            Debug.WriteLine(String.Format("Msg=0x{0:X}:WParam=0x{1:X}", m.Msg, m.WParam.ToInt32()))
            Select Case m.WParam.ToInt32()
                Case DBT_DEVNODES_CHANGED
                    Debug.WriteLine("any devnode changed occur")
                    iTunesRoot = ITunesDb.GetIPodRoot()
                    If iTunesRoot = "" Then
                        trvITunes.Nodes.Clear()
                        Me.btnExport.Enabled = False
                        Me.cmbOutputDir.Enabled = False
                    End If
                Case DBT_DEVICEARRIVAL
                    Debug.WriteLine("system detected a new device")
                    iTunesRoot = ITunesDb.GetIPodRoot()

                    If iTunesRoot <> "" Then
                        tabFolder.SelectedIndex = 1
                        Dim dr As New DriveInfo(iTunesRoot)
                        Me.getArtists(iTunesRoot & "iPod_Control\iTunes", dr.VolumeLabel)
                        iTunesPath = iTunesRoot & "iPod_Control\iTunes"
                    Else
                        Me.btnExport.Enabled = False
                        Me.cmbOutputDir.Enabled = False
                    End If
                Case DBT_DEVICEREMOVECOMPLETE
                    Debug.WriteLine("device is gone")
                    iTunesRoot = ITunesDb.GetIPodRoot()
                    If iTunesRoot = "" Then
                        trvITunes.Nodes.Clear()
                        Me.btnExport.Enabled = False
                        Me.cmbOutputDir.Enabled = False
                    End If
                Case Else
                    Debug.WriteLine("other")
            End Select
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub tsmQtExportDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmQtExportDialog.Click, tsmQtExportDialog1.Click

        Me.Enabled = False
        Try
            pnlQt.ShowExportDialog()
        Finally
            Me.Enabled = True
        End Try

    End Sub

    Private Sub tsmQtMovieInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmQtMovieInfo.Click, tsmQtMovieInfo1.Click

        pnlQt.QT.ShowPropertyPages()
    End Sub

    Private Sub tsmQuickTimeInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmQuickTimeInfo.Click, tsmQtInfo.Click

        pnlQt.QT.ShowAboutBox()
    End Sub

    Private Sub tabViewType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles tabViewType.SelectedIndexChanged

        Static lastChecked As Boolean = False

        If tabViewType.SelectedIndex = 0 Then
            pnlQt.Visible = True
            WebBrws.Visible = False
            chkZoom.Checked = lastChecked
        Else
            WebBrws.ScriptErrorsSuppressed = False
            pnlQt.Visible = False
            Dim address As String = "http://ws.audioscrobbler.com/2.0/artist/" & pnlQt.ArtistName & "/info.xml"
            address = "http://www.lastfm.jp/music/" & pnlQt.ArtistName
            Try
                tstAddress.Text = address
                WebBrws.Navigate(New Uri(address))
                lastChecked = chkZoom.Checked
                chkZoom.Checked = True
            Catch ex As System.UriFormatException
                Return
            End Try
            WebBrws.Visible = True
        End If
    End Sub

    Private Sub setAMDeviceData()
        Dim dat As New System.Text.StringBuilder()
        Dim i As Integer

        Dim st As String = iPhoneInterface.ActivationState

        With iPhoneInterface.Device
            rtbAMDevice.Text = ""
            rtbAMDevice.SelectionColor = Color.Blue
            rtbAMDevice.AppendText("Activation State: " & st & vbCrLf)
            'dat.Append("Device ID: ").Append(.device_id).Append(vbCrLf)

            rtbAMDevice.SelectionColor = Color.Blue
            rtbAMDevice.AppendText("Device ID: ")
            rtbAMDevice.SelectionColor = Color.Black
            rtbAMDevice.AppendText(.device_id.ToString & vbCrLf)
            'dat.Append("Product ID: ").Append(.product_id).Append(vbCrLf)

            rtbAMDevice.SelectionColor = Color.Blue
            rtbAMDevice.AppendText("Product ID: ")
            rtbAMDevice.SelectionColor = Color.Black
            rtbAMDevice.AppendText(.product_id.ToString)
            Dim prodid As String
            Select Case .product_id
                Case &H1290
                    prodid = "iPhone First Gen"
                Case &H1291
                    prodid = "iPod touch 1G"
                Case &H1292
                    prodid = "iPhone 3G"
                Case &H1293
                    prodid = "iPod touch 2G"
                Case &H1294
                    prodid = "iPhone 2.1"
                Case &H1295
                    prodid = "iProd 0.1"
                Case &H1296
                    prodid = "iPod 2.2"
                Case &H1297
                    prodid = "iPhone 3.1"
                Case &H1298
                    prodid = "iFPGA"
                Case &H1299
                    prodid = "iPod 3.1"
                Case Else
                    prodid = "Unknown"
            End Select
            rtbAMDevice.AppendText(" (" & prodid & ")" & vbCrLf)
            'dat.Append("Serial: ").Append(iPhoneInterface.Device.serial).Append(vbCrLf)

            rtbAMDevice.SelectionColor = Color.Blue
            rtbAMDevice.AppendText("Serial: ")
            rtbAMDevice.SelectionColor = Color.Black
            rtbAMDevice.AppendText(.serial & vbCrLf)

            rtbAMDevice.SelectionColor = Color.Blue
            rtbAMDevice.AppendText("unknown1: ")
            rtbAMDevice.SelectionColor = Color.Black
            rtbAMDevice.AppendText(.unknown1 & vbCrLf)

            rtbAMDevice.SelectionColor = Color.Blue
            rtbAMDevice.AppendText("unknown2: ")
            rtbAMDevice.SelectionColor = Color.Black
            For i = 0 To .unknown2.Length - 1
                dat.Append(.unknown2(i)).Append(" ")
            Next
            dat.Append(vbCrLf)
            rtbAMDevice.AppendText(dat.ToString)

            rtbAMDevice.SelectionColor = Color.Blue
            rtbAMDevice.AppendText("lockdown_conn: ")
            rtbAMDevice.SelectionColor = Color.Black
            rtbAMDevice.AppendText(.lockdown_conn & vbCrLf)

            rtbAMDevice.SelectionColor = Color.Blue
            rtbAMDevice.AppendText("unknown3: " & vbCrLf)
            rtbAMDevice.SelectionColor = Color.Black

            dat.Length = 0
            For i = 0 To .unknown3.Length - 1
                dat.Append(" [").Append(i).Append("] ").Append(Conversion.Hex(.unknown3(i))).Append("H ").Append(.unknown3(i)).Append(" ").Append(vbCrLf)  '.Append(Chr(.unknown2(i))).Append(vbCrLf)
            Next
            dat.Append("unknown4: ").Append(vbCrLf)
            For i = 0 To .unknown4.Length - 1
                dat.Append(" [").Append(i).Append("] ").Append(Conversion.Hex(.unknown4(i))).Append("H ").Append(.unknown4(i)).Append(" ").Append(vbCrLf)  '.Append(Chr(.unknown4(i))).Append(vbCrLf)
            Next
            dat.Append("unknown5: ").Append(vbCrLf)
            For i = 0 To .unknown5.Length - 1
                dat.Append(" [").Append(i).Append("] ").Append(Conversion.Hex(.unknown5(i))).Append("H ").Append(.unknown5(i)).Append(" ").Append(vbCrLf)  '.Append(Chr(.unknown2(i))).Append(vbCrLf)
            Next
        End With

        rtbAMDevice.AppendText(dat.ToString)
    End Sub

    Private Sub rtbAMDevice_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles rtbAMDevice.DoubleClick

        setAMDeviceData()
    End Sub

    Private Sub cmbOutputDir_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles cmbOutputDir.SelectedIndexChanged

        My.Settings.ExportDir = cmbOutputDir.Text
    End Sub

    Private Sub tsmProperty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmProperty.Click

        Dim path As String = Me.getSelectedFolder()
        Dim frmFolderProp As New frmFolderProperty

        frmFolderProp.CurrentPath = path
        frmFolderProp.Show(Me)
        frmFolderProp.txtFolderName.Text = path.Substring(path.LastIndexOf("/") + 1)

    End Sub

    Private Sub trvApps_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) _
        Handles trvApps.AfterSelect

        Dim selNode As TreeNode = e.Node
        Me.UseWaitCursor = True

        Try
            If selNode.Tag IsNot Nothing Then
                tabFolder.SelectedIndex = 0
                Me.openPath(selNode.Tag.ToString)
            End If
        Finally
            Me.UseWaitCursor = False
        End Try

    End Sub

    Private Function findFile(ByVal sPath As String, ByVal fname As String) As String
        Dim sbpath As String
        Dim ret As String = ""

        Try
            'get the data from the phone
            For Each strFiles As iPhone.strFileInfo In iPhoneInterface.GetFolderInfo(sPath)
                Dim fileName As String = convertcd(strFiles.name)
                If strFiles.isDir Then
                    sbpath = sPath & "/" & fileName

                    'If Not strFiles.isSLink Then
                    StatusNormal(sbpath)
                    ret = findFile(sbpath, fname)
                    'End If
                    If ret.Length > 0 Then
                        Exit Try
                    End If
                Else
                    If fileName.IndexOf(fname) > -1 Then
                        ret = sPath & "/" & fileName
                        Exit For
                    End If
                    Application.DoEvents()
                End If
                If ProgressEscapeFlg Then
                    Exit For
                End If
            Next
            'folderCount += 1
            Thread.Sleep(1)

        Catch ex As Exception
            StatusWarning(My.Resources.String35)

        End Try

        Return ret

    End Function

    Private Sub txtFind_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtFind.GotFocus

        txtFind.SelectionStart = 0
        txtFind.SelectionLength = txtFind.Text.Length

    End Sub

    Private Sub txtFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtFind.TextChanged

        If txtFind.Text.Length > 0 Then
            btnFind.Enabled = True
        Else
            btnFind.Enabled = False
        End If
    End Sub

    Private Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles btnFind.Click

        Dim spath As String
        Dim f As String

        Me.Cursor = Cursors.WaitCursor
        Try
            btnFind.Enabled = False
            spath = Me.getSelectedFolder()

            If spath = "" Then
                Exit Sub
            End If

            tlbProgress0.Visible = True
            tlbProgress0.Style = ProgressBarStyle.Marquee
            btnCancel.Visible = True

            f = Me.findFile(spath, txtFind.Text)

            If f.Length > 0 Then
                f = f.Substring(0, f.LastIndexOf("/"))
                Me.openPath(f)
            Else
                StatusNormal("The file was not found.")
            End If

        Finally
            btnCancel.Visible = False
            tlbProgress0.Style = ProgressBarStyle.Blocks
            tlbProgress0.Visible = False

            btnFind.Enabled = True
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    'Private Sub frmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) _
    '    Handles Me.Activated

    '    Me.Opacity = 1.0
    'End Sub

    'Private Sub frmMain_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) _
    '    Handles Me.Deactivate

    '    Me.Opacity = 0.5
    'End Sub

End Class

