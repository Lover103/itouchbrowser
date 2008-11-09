Option Strict On
Option Explicit On

Imports System.Threading
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports Manzana
Imports SCW_iPhonePNG

Public Class frmMain
    Const IMAGE_FOLDER_CLOSED As Integer = 0
    Const IMAGE_FOLDER_OPEN As Integer = 1
    Const IMAGE_FILE_UNKNOWN As Integer = 0
    Const IMAGE_FILE_MUSIC As Integer = 1
    Const IMAGE_FILE_MOVIE As Integer = 2
    Const IMAGE_FILE_TEXT As Integer = 3
    Const IMAGE_FILE_IMAGE As Integer = 4
    Const IMAGE_FILE_AUDIO As Integer = 5
    Const IMAGE_FILE_DATABASE As Integer = 6
    'Const IMAGE_FILE_RINGTONE As Integer = 7
    Const IMAGE_FILE_WEBBROWS As Integer = 7

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

    'CUSTOM  CREATED FUNCTIONS

    Private Delegate Sub NoParmDel()

    Public Sub DelayedConnectionChange()
        Try
            EndStatus()
            bNowConnected = Not bNowConnected
            bConnectionChanged = True
            connectionChange()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Event iPhoneConnected()
    Public Event iPhoneDisconnected()

    Private Sub frmMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        My.Settings.BackupControl = tsmBackupControl.Checked
        My.Settings.LastPath = ModuleMain.NodeiPhonePath(trvFolders.SelectedNode)
        My.Settings.Position = Me.Left.ToString() & "," & Me.Top.ToString() & "," & Me.Width.ToString() & "," & Me.Height.ToString()
        My.Settings.Save()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        qtPlugin.Dispose()
        qtBuff.Dispose()
    End Sub

    Public Sub iPhoneConnected_Details() Handles Me.iPhoneConnected
        If Not bNowConnected Then
            txtSerial = iPhoneInterface.Device.serial
            If Me.InvokeRequired Then
                Me.Invoke(New NoParmDel(AddressOf DelayedConnectionChange))
            Else
                DelayedConnectionChange()
            End If
        End If
    End Sub

    Public Sub iPhoneDisconnected_Details() Handles Me.iPhoneDisconnected
        If bNowConnected Then
            txtSerial = ""
            If Me.InvokeRequired Then
                Me.Invoke(New NoParmDel(AddressOf DelayedConnectionChange))
            Else
                DelayedConnectionChange()
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
            ToolStripMenuItemNewFolder.Enabled = bNowConnected
            ToolStripMenuItemDeleteFolder.Enabled = bNowConnected
            tslAddress.Enabled = bNowConnected
            tstAddress.Enabled = bNowConnected
            tsbAddress.Enabled = bNowConnected

            If mvarLnError Then
                mvarLnError = False
            ElseIf bNowConnected Then
                Me.Opacity = 75
                'the phone was just recognized as connected
                Me.refreshFolders()
                trvFolders.Focus()

                If iPhoneInterface.IsJailbreak Then
                    'StatusNormal("iPhone is connected and jailbroken")
                    StatusNormal(My.Resources.String3)
                    iTunesPath = "/var/mobile/Media/iTunes_Control/iTunes/iTunesDB"
                    If iPhoneInterface.Exists("/var/root/Media/DCIM") Then
                        tildeDir = "/var/root"
                        iTunesPath = "/var/root/Media/iTunes_Control/iTunes/iTunesDB"
                    End If
                Else
                    'StatusWarning("iPhone is connected, not jailbroken")
                    StatusWarning(My.Resources.String1)
                    iTunesPath = "/iTunes_Control/iTunes/iTunesDB"
                End If
                iTunesRoot = iTunesPath.Substring(0, iTunesPath.IndexOf("/iTunes_Control/"))

                CopyFromPhonePNG(iTunesPath, My.Settings.DbPath & "\iTunesDB")

                Me.getArtists(My.Settings.DbPath, "All")

                'Dim arts As String() = mvarItunesMan.GetArtists(My.Settings.DbPath)

                'trvITunes.BeginUpdate()
                'trvITunes.Nodes.Clear()
                'Dim tn As TreeNode = trvITunes.Nodes.Add("All")
                'For i As Integer = 0 To arts.Length - 1
                '    tn.Nodes.Add(arts(i))
                'Next
                'tn.ExpandAll()
                'trvITunes.EndUpdate()
                'btnExport.Enabled = False

                'mvarItunes = mvarItunesMan.GetRecSet()

                'Set last path
                If My.Settings.LastPath <> "" Then
                    openPath(My.Settings.LastPath)
                End If

            Else
                'StatusWarning("iPhone is NOT connected, please check your connections!")
                StatusWarning(My.Resources.String2)

                trvITunes.Nodes.Clear()
                My.Settings.LastPath = ModuleMain.NodeiPhonePath(trvFolders.SelectedNode)
                mvarItunesMan.Dispose()
            End If

        End If
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

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try
            Dim pos As String = My.Settings.Position
            If pos.IndexOf(",") > 0 Then
                Dim position As String() = pos.Split(","c)
                Me.SetDesktopLocation(CInt(position(0)), CInt(position(1)))
                Me.Size = New Size(CInt(position(2)), CInt(position(3)))
            End If

            ProgressBars(0) = tlbProgress0
            tlbProgress0.Visible = False
            ProgressBars(1) = tlbProgressBar
            tlbProgressBar.Visible = False
            btnCancel.Visible = False
            tslProgress.Visible = False
            ResetStatus()   'ProgressDepth = -1

            'APP_PATH = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Cranium\iPhoneBrowser\"
            'APP_PATH = My.Settings.BackupPath & "\touchBrowser\"
            setBackupPath(DateTime.Now)

            FILE_TEMPORARY_VIEWER = Path.GetTempPath & FILE_TEMPORARY_VIEWER

            Me.Text = My.Resources.String14 & " (v" & Application.ProductVersion & ")"

            ' initialize the file list groups
            For j1 As Integer = 0 To 7
                Dim lvg As ListViewGroup = New ListViewGroup(Me.getFiletype(j1))
                lstFiles.Groups.Add(lvg)
            Next

            ' load up the user settings
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
            qtPlugin.QuickTimeInitialize()
            qtBuff.QuickTimeInitialize()
            qtBuff.AutoPlay = "False"
            qtBuff.EventEnabled = False

            LoadFavoritesMenu()

            ' setup the tooltips
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

        Catch ex As Exception
            MsgBox(My.Resources.String15 & ex.Message & My.Resources.String16, MsgBoxStyle.Critical, "Error!")
            Me.Close()

        End Try

    End Sub

    Private Sub refreshChildFolders(ByVal forceRefresh As Boolean)
        If Not bUpdateInProgress Then
            Me.refreshChildFolders(trvFolders.SelectedNode, forceRefresh)
        End If
    End Sub

    Private Sub refreshChildFolders(ByVal rootNode As TreeNode, ByVal forceRefresh As Boolean)
        Dim sWorkingPath As String
        Dim tmpNode As TreeNode

        If CBool(rootNode.Tag) AndAlso Not forceRefresh Then
            Exit Sub
        End If

        If Not bUpdateInProgress Then
            bUpdateInProgress = True
            Me.Cursor = Cursors.WaitCursor
            trvFolders.SuspendLayout()

            'we need to go through all the children and refresh them
            'StatusNormal("Refreshing folders for " & rootNode.Name & "...")
            StatusNormal(String.Format(My.Resources.String4, rootNode.Name))
            StartStatus(rootNode.Nodes.Count, 0)

            sWorkingPath = ModuleMain.NodeiPhonePath(rootNode)
            ModuleMain.AddFolders(sWorkingPath, rootNode, -2)

            Try
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
                StatusNormal("")
                If ProgressEscapeFlg = False Then
                    rootNode.Tag = True
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation)

            Finally
                EndStatus()
                trvFolders.ResumeLayout()
                Me.Cursor = Cursors.Arrow
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

    Structure SongTitleStruct
        Dim index As Integer
        Dim fileName As String
        Dim subDir As String
    End Structure

    Friend Sub LoadFiles()
        Dim bFiles As List(Of iPhone.strFileInfo)
        Dim iPhonePath As String
        Dim lstTemp As ListViewItem
        Dim row As Integer

        If Not bSupressFiles Then
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
                bFiles = iPhoneInterface.GetFiles(iPhonePath, 0)

                'now go one by one and add it
                Dim songTitles(bFiles.Count) As SongTitleStruct
                Dim songCnt As Integer = 0
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
                            ext = sFile.Substring(sFile.LastIndexOf("."))
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
                            End If
                        End If

                        lstTemp = New ListViewItem(sFileExt)
                        lstTemp.ImageIndex = getImageIndexForFile(sFile)
                        If lstFiles.ShowGroups Then
                            lstTemp.Group = lstFiles.Groups(lstTemp.ImageIndex)
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
                'Do While mvarInProCount > 1
                '    Timer1.Enabled = False
                '    Application.DoEvents()
                'Loop

                Dim songTitle As String = ""
                lstFiles.Tag = iPhonePath

                StartStatus(songCnt, 0)
                For row = 0 To songCnt - 1
                    'If mvarInProCount > 1 Then Exit For
                    songTitle = Me.getSongTitle(songTitles(row).fileName, iPhonePath, songTitles(row).subDir)
                    lstFiles.Items(songTitles(row).index).Text &= songTitle
                    lstFiles.Refresh()
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

            Catch e As IOException
                MsgBox(e.ToString, MsgBoxStyle.Exclamation)

            Catch ex As Exception
                'MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                If ex.Message = "Path does not exist" Then
                    StatusWarning(My.Resources.String35)
                    ResetiPhone()
                Else
                    StatusWarning(ex.Message)
                End If

            Finally
                StatusNormal(lstFiles.Items.Count.ToString & " objects")
            End Try

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
            Case "strings", "conf", "txt", "script", "pl", "h", "awk", "tcl", "css", "m4", "c", "sh"
                iReturn = IMAGE_FILE_TEXT
            Case "db", "sqlite", "sqlitedb", "itdb"
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

        ModuleMain.AddFolders("", rootNode, 0)
        IncrementStatus(0)

        rootNode.Expand()
        trvFolders.SelectedNode = rootNode
        IncrementStatus(0)

        trvFolders.ResumeLayout()
        Me.Cursor = Cursors.Arrow
        EndStatus()
    End Sub

    Private Function getSelectedFilename() As String
        'returns the currently selected filename
        Return getSelectedPath() & lstFiles.SelectedItems(0).Text
    End Function

    Private Function getSelectedFolder() As String
        If tabFolder.SelectedIndex = 0 Then
            Return trvFolders.SelectedNode.FullPath.Substring(STRING_ROOT.Length)
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

        refreshChildFolders(e.Node, False)
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
        Me.UseWaitCursor = True

        If selNode.Level > 0 AndAlso CBool(selNode.Tag) = False Then
            'AddFoldersBeneath(selNode)
            'Folderの展開でキャンセルしたとき
            AddFolders(ModuleMain.NodeiPhonePath(selNode), selNode, 1)
        End If
        If Not IsCollapsing AndAlso (Not selNode.IsExpanded()) Then
            trvFolders.SelectedNode.Expand()
        End If
        Me.LoadFiles()

        Me.UseWaitCursor = False
    End Sub

    Private Sub lstFiles_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) _
        Handles lstFiles.DragDrop

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Me.Cursor = Cursors.WaitCursor
            Dim initFolder As String = getSelectedPath()
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
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub lstFiles_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) _
        Handles lstFiles.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub unlockQT()
        'unlock the file so we can load another
        If wasQTpreview Then
            qtPlugin.FileName = "" 'to unlock it
            'sugi File.Delete(QTpreviewFile.Replace("localhost\", ""))
            'qtPlugin.Close()
            wasQTpreview = False
        End If
    End Sub

    Private Sub clearPreview()
        'unlockQT()

        picFileDetails.Visible = False
        txtFileDetails.Visible = False
        pnlQt.Visible = False
        WebBrws.Visible = False

        btnPreview.Enabled = True
    End Sub

    Private Sub showFileDetails(ByVal sFile As String)
        Dim i As Long = 1
        Dim bo As Boolean

        iPhoneInterface.GetFileInfo(sFile, i, bo)

        txtFileDetails.Text = "Filename: " & Path.GetFileName(sFile) & vbCrLf _
                & "Size: " & fileSizeAsString(sFile) _
                & ",   " & i.ToString() & " Byte"
        txtFileDetails.Visible = True
    End Sub

    Private Sub showPreview(ByVal sFile As String, ByVal fromBtn As Boolean, ByVal fsize As Integer)
        Dim picOK As Boolean

        StatusNormal(My.Resources.String28 & sFile)

        Dim tmpOnPC As String = GetTempFilename(sFile)
        Dim imageIdx As Integer = lstFiles.SelectedItems(0).ImageIndex
        Dim backupDir As String = lstFiles.SelectedItems(0).SubItems(2).Text

        'If imageIdx = IMAGE_FILE_UNKNOWN OrElse CopyFromPhone(sFile, tmpOnPC) = 0 Then
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

                clearPreview()

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
                                'sr = My.Computer.FileSystem.OpenTextFileReader(tmpOnPC)
                                'txtFileDetails.Text = sr.ReadToEnd().Replace(Chr(10), vbCrLf)
                                'sr.Close()
                            Else
                                showFileDetails(sFile)
                                btnPreview.Enabled = True
                            End If

                        Case IMAGE_FILE_IMAGE
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

                        Case IMAGE_FILE_AUDIO, IMAGE_FILE_MOVIE, IMAGE_FILE_MUSIC
                            If ProgressEscapeFlg = False Then
                                wasQTpreview = qtPlugin.Play(tmpOnPC)
                                pnlQt.Visible = True
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
            Else
                txtFileDetails.Text = str
                txtFileDetails.Visible = True
            End If
        End If
    End Sub

    Private Sub ShowDbInfo(ByVal tmpfile As String)
        Dim info As String = DbManager.GetDBInfo(tmpfile)
        txtFileDetails.Text = info
        txtFileDetails.Visible = True
    End Sub

    Private Function doFileSelectedPreview(ByVal anySize As Boolean, ByVal fromBtn As Boolean) As String
        Dim sFile As String = ""
        If lstFiles.SelectedItems.Count > 0 Then
            sFile = getSelectedFilename()

            Dim p As Integer = sFile.IndexOf("(")
            If p > 0 Then
                sFile = sFile.Substring(0, p)
            End If

            If prevSelectedFile = sFile Then ' make sure we changed selections (handles multi-select better)
                Return sFile
            End If
            prevSelectedFile = sFile

            'clearPreview()

            ' only if it is less than a big file size
            Dim sSize As String = lstFiles.SelectedItems(0).SubItems(1).Text
            'If (sSize.EndsWith("KB") AndAlso Val(sSize) < 1000) OrElse sSize.EndsWith("B") OrElse anySize Then
            If sSize <> "0 B" Then
                showPreview(sFile, fromBtn, fileSizeAsInteger(sSize))
            Else
                showFileDetails(sFile)
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
            Dim sFile As String = getSelectedFilename()

            If prevSelectedFile = sFile Then ' make sure we changed selections (handles multi-selecte better)
                Exit Sub
            End If
            prevSelectedFile = sFile

            clearPreview()

            showFileDetails(sFile)
        End If
    End Sub

    Private splFilesLock As Boolean = False

    Private Sub lstFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles lstFiles.SelectedIndexChanged

        If mvarClickedMouseButton = Windows.Forms.MouseButtons.Right Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        If Config.bShowPreview AndAlso Not splFilesLock Then
            lstFiles.Cursor = Cursors.No
            splFilesLock = True
            Dim sFile As String = doFileSelectedPreview(False, False)

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

            splFilesLock = False
            lstFiles.Cursor = Cursors.Default
            'lstFiles.Focus()
        Else
            showSelectedFileDetails()
        End If
        Me.Cursor = Cursors.Default
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
                BackupFileFromPhone(sSourcePath, sItem.Text)
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
                sFileToPhone = getSelectedFilename()
                'this function also makes a backup
                ModuleMain.CopyToPhone(sSourceFilename, sFileToPhone, Config.bConvertToiPhonePNG)
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
        End If
    End Sub

    Private Sub ToolStripMenuItemNewFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ToolStripMenuItemNewFolder.Click

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
                ModuleMain.AddFoldersBeneath(trvFolders.SelectedNode)
                Me.selectSpecificPath(sPath)
            Else
                'it failed
                MsgBox("The path '" & sNewPath & "' failed to create due to an unknown interface failure.", MsgBoxStyle.Information, "Canceled")
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItemDeleteFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ToolStripMenuItemDeleteFolder.Click

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

        BackupDirectory(sPath)
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

        ' turn off grouping when sorting
        If cmdShowGroups.Checked Then
            cmdShowGroups_Click(sender, e)
        End If
        If lstFilesSortOrder = SortOrder.None OrElse lstFilesSortOrder = SortOrder.Descending Then
            lstFilesSortOrder = SortOrder.Ascending
        Else
            lstFilesSortOrder = SortOrder.Descending
        End If
        If lstFiles.Columns(e.Column).Text = My.Resources.String31 Then
            Me.lstFiles.ListViewItemSorter = New ListViewSizeComparer(e.Column, lstFilesSortOrder)
        Else
            Me.lstFiles.ListViewItemSorter = New ListViewStringComparer(e.Column, lstFilesSortOrder)
        End If
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

    Private Sub menuSaveSummerboardTheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmAsSummerboardFolder.Click

        Dim dFolder As String, sSaveAsFilename As String, sFileFromPhone As String
        Dim sPath As String, sFolders() As String

        If My.Settings.SummerboardPath <> "" Then
            folderBrowserDialog.SelectedPath = My.Settings.SummerboardPath
        End If
        folderBrowserDialog.Description = My.Resources.String45

        If folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents() ' update display

            My.Settings.SummerboardPath = Path.GetDirectoryName(folderBrowserDialog.SelectedPath) ' save the parent

            dFolder = folderBrowserDialog.SelectedPath & "\"
            ' save wallpaper jpg as PNG (~/Library/LockBackground.jpg)
            StatusNormal(My.Resources.String9)
            CopyFromPhoneMakePNG(tildeDir + "/Library/LockBackground.jpg", dFolder & "Wallpaper.png")

            ' save Dock Background (SBDockBG2.png -> Dock.png)
            StatusNormal(My.Resources.String10)
            CopyFromPhonePNG("/System/Library/CoreServices/SpringBoard.app/SBDockBG2.png", dFolder & "Dock.png")

            ' save Icons for applications

            Dim appFolders() As String = {"MobileCal", "MobileMail", "MobileMusicPlayer", "MobileNotes", "MobilePhone", "MobileSafari", "MobileSMS", "MobileTimer", "Preferences"}
            Dim appNames() As String = {"Calendar", "Mail", "iPod", "Notes", "Phone", "Safari", "Text", "Clock", "Settings"}
            Dim newIconName As String

            dFolder = dFolder & "Icons\"
            Directory.CreateDirectory(dFolder)
            sPath = "/Applications/"
            sFolders = iPhoneInterface.GetDirectories(sPath)
            For Each sFolder As String In sFolders
                If sFolder.EndsWith(".app") Then
                    StatusNormal(My.Resources.String11 + sFolder)
                    If sFolder = "MobileSlideShow.app" Then
                        Dim iNames() As String = {"icon-Photos.png", "icon-Camera.png"}
                        For Each sIcon As String In (iNames)
                            sFileFromPhone = sPath & sFolder & "/" & sIcon
                            sSaveAsFilename = dFolder & sIcon.Substring(5, 6) & ".png"
                            CopyFromPhonePNG(sFileFromPhone, sSaveAsFilename)
                        Next
                    Else
                        sFileFromPhone = sPath & sFolder & "/icon.png"
                        newIconName = Microsoft.VisualBasic.Left(sFolder, sFolder.Length - 4)
                        Dim nii As Integer = Array.IndexOf(appFolders, newIconName)
                        If nii >= 0 Then
                            newIconName = appNames(nii)
                        End If
                        sSaveAsFilename = dFolder & newIconName & ".png"
                        CopyFromPhonePNG(sFileFromPhone, sSaveAsFilename)
                    End If
                End If
            Next
            StatusNormal("")
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub tsmAsCustomizeFolders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmAsCustomizeFolders.Click

        Dim frmOptions As frmCustomizeOptions = New frmCustomizeOptions()
        If frmOptions.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If frmOptions.HasChecked() Then
                folderBrowserDialog.SelectedPath = My.Settings.CustomizePath
                If folderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    My.Settings.CustomizePath = folderBrowserDialog.SelectedPath
                    Me.Cursor = Cursors.WaitCursor
                    Application.DoEvents() ' show cursor
                    SaveCustomizeToFolder(frmOptions, folderBrowserDialog.SelectedPath)
                    Me.Cursor = Cursors.Arrow
                End If
            End If
        End If
        frmOptions.Dispose()
    End Sub

    Private Sub IPhoneToPCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmIPhoneToPC.Click

        Config.bConvertToPNG = tsmIPhoneToPC.Checked
    End Sub

    Private Sub PCToIPhoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
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

        If Config.bBackupControled Then
            cohAttribute.Width = 150
        Else
            cohAttribute.Width = 0
        End If

    End Sub

    Private Sub tsmBackupControl_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles tsmBackupControl.Click

        'Config.bBackupControled = tsmBackupControl.Checked
        'tsmCleanUp.Enabled = tsmBackupControl.Checked

        'If Config.bBackupControled Then
        '    cohAttribute.Width = 150
        'Else
        '    cohAttribute.Width = 0
        'End If

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

        Dim oldPath As String = getSelectedFilename(), newPath As String
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

    Private Sub cmdRenameFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cmdRenameFolder.Click

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
        If lstFiles.ShowGroups Then
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

    Private Sub trvFolders_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles trvFolders.KeyUp

        If e.KeyCode = Keys.F5 Then
            ModuleMain.AddFoldersBeneath(trvFolders.SelectedNode)
        End If
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
                        If lastval0 <> ProgressValue(0) Then
                            lastval0 = ProgressValue(0)
                            ProgressBars(0).Value = lastval0
                            'tlbStatusStrip.Refresh()
                            If ProgressFullSize > 1024 Then
                                tslProgress.Text = CInt(ProgressSize / 1024).ToString() & " of " & CInt(ProgressFullSize / 1024).ToString() & " KByte "
                            ElseIf lastval0 > 100 Then
                                tslProgress.Text = lastval0.ToString() & "/" & .Maximum.ToString()
                            End If
                        End If
                    End If
                End With
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ToolStripDropDownButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
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

        Dim dg As frmBackupFiles = New frmBackupFiles

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

    Private Sub chkZoom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkZoom.CheckedChanged

        Dim checked As Boolean

        If chkZoom.Checked Then
            checked = True
        Else
            checked = False
        End If

        splFiles.Panel1Collapsed = checked
        splMain.Panel1Collapsed = checked
    End Sub

    Private Sub qtPlugin_AnnotationUpdate(ByVal annotation As String) _
        Handles qtPlugin.AnnotationUpdate

        txtMovieName.Text = annotation

    End Sub

    Private Sub qtPlugin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles qtPlugin.LostFocus

        tsmQtFullscreen.Checked = False
        qtPlugin.FullScreen = False
        'qtPlugin.BorderStyle = QTOControlLib.BorderStylesEnum.bsPlain

        qtPlugin.Visible = False
    End Sub

    Private Sub qtPlugin_ShowStatusString(ByVal message As String) _
        Handles qtPlugin.ShowStatusString

        StatusNormal(message)
    End Sub

    Private Sub qtPlugin_VisibleChanged(ByVal visibled As Boolean) _
        Handles qtPlugin.VisibleChanged

        chkZoom.Visible = visibled
        txtMovieName.Visible = visibled
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

    Private Sub tsmQtMovieInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmQtMovieInfo.Click

        qtPlugin.ShowPropertyPages()
    End Sub

    Private Sub tsmQtFullscreen_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles tsmQtFullscreen.CheckedChanged

        qtPlugin.FullScreen = tsmQtFullscreen.Checked
    End Sub

    Private Sub tsmQtExportDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmQtExportDialog.Click

        qtPlugin.ShowExportDialog()
    End Sub

    Private Sub pnlQt_Resize(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles pnlQt.Resize

        If pnlQt.Visible AndAlso pnlQt.Width > qtPlugin.Left Then
            qtPlugin.Width = pnlQt.Width - qtPlugin.Left
        End If
    End Sub

    Private Sub QuickTimeInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsmQuickTimeInfo.Click

        qtPlugin.ShowAboutBox()
    End Sub

    Private Sub tsbAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles tsbAddress.Click

        Dim sPath As String = tstAddress.Text
        openPath(sPath)
    End Sub

    Private Sub tstAddress_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tstAddress.KeyUp
        If e.KeyCode = 13 Then
            openPath(tstAddress.Text)
        End If
    End Sub

    Private Sub trvITunes_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) _
        Handles trvITunes.AfterCheck

        If TreeNode.ReferenceEquals(e.Node, trvITunes.Nodes(0)) Then
            Dim checked As Boolean = e.Node.Checked
            For Each node As TreeNode In trvITunes.Nodes(0).Nodes
                node.Checked = checked
            Next
        End If

        If e.Node.Checked Then
            btnExport.Enabled = True
            cmbOutputDir.Enabled = True
        Else
            Dim checked As Boolean = False
            For Each node As TreeNode In trvITunes.Nodes(0).Nodes
                If node.Checked Then
                    checked = True
                    Exit For
                End If
            Next
            btnExport.Enabled = checked
            cmbOutputDir.Enabled = checked
        End If

    End Sub

    Private Sub trvITunes_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) _
        Handles trvITunes.AfterSelect

        Dim lstTemp As ListViewItem
        Dim selNode As TreeNode = e.Node
        Dim listRow As Integer = 0
        Dim files As IPod.Music.TrackItem() = mvarItunesMan.GetSongs(selNode.Text)

        Try
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
                lstFiles.Items.Add(lstTemp)
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

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            lstFiles.EndUpdate()
        End Try

    End Sub

    Private Sub tabFolder_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles tabFolder.SelectedIndexChanged

        With Me.lstFiles
            .SuspendLayout()
            Select Case tabFolder.SelectedIndex
                Case 0
                    .Columns(2).Text = My.Resources.String49
                    .Columns(3).Width = 110
                    .Columns.RemoveByKey("TrackNumber")
                    .Columns.RemoveByKey("Album")
                    .Columns.RemoveByKey("Genre")
                    .Columns.RemoveByKey("Type")
                    .Columns.RemoveByKey("Comment")

                Case 1
                    .Columns(2).Text = My.Resources.String50
                    .Columns(3).Width = 0
                    .Columns.Add("Album", My.Resources.String51, 150)
                    .Columns.Add("TrackNumber", My.Resources.String52, 70, HorizontalAlignment.Right, "")
                    .Columns.Add("Genre", My.Resources.String53, 60)
                    .Columns.Add("Type", My.Resources.String54, 120)
                    .Columns.Add("Comment", My.Resources.String55, 160)

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

            End Select
            .Items.Clear()
            .ResumeLayout()
        End With
    End Sub

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

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim sRootPath As String = ""
        Dim escaped As Boolean = False
        Dim dr As DialogResult
        Dim rc As Long

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

            Dim sSourcePath As String = iTunesRoot & "/"
            For Each node As TreeNode In trvITunes.Nodes(0).Nodes
                If node.Checked Then
                    StatusNormal(node.Text)
                    Dim listRow As Integer = 0
                    Dim files As IPod.Music.TrackItem() = mvarItunesMan.GetSongs(node.Text)

                    Dim sDestinationPath As String = sRootPath & "\" & node.Text & "\"
                    ModuleMain.needDir(sDestinationPath)
                    StartStatus(files.Length, files.Length)
                    Try
                        For listRow = 0 To files.Length - 1
                            Dim item As IPod.Music.TrackItem = files(listRow)
                            StatusNormal(item.Artist & " - " & item.Album & " - " & item.Title)

                            Dim sSourceFile As String = item.Location.Replace("\", "/")
                            Dim ext As String = sSourceFile.Substring(sSourceFile.LastIndexOf("."))
                            Dim subPath As String = sDestinationPath & item.Album.Replace("/", "_") & "\"
                            Dim destFileName As String = subPath & item.TrackNumber.ToString("00.") _
                                        & FixPhoneFilename(item.Title.Replace(" ", "_")) & ext

                            ModuleMain.needDir(subPath)
                            If bNowConnected Then
                                rc = ModuleMain.CopyFromPhone(sSourcePath & sSourceFile, _
                                        destFileName)
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
                        Next
                    Finally
                        EndStatus()
                        StatusNormal("")
                    End Try
                    If escaped Then
                        Exit For
                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)

        End Try

    End Sub

    Private Const WM_DEVICECHANGE As Integer = &H219
    Private Const DBT_DEVNODES_CHANGED As Integer = &H7
    Private Const DBT_DEVICEARRIVAL As Integer = &H8000
    Private Const DBT_DEVICEREMOVECOMPLETE As Integer = &H8004

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

End Class

