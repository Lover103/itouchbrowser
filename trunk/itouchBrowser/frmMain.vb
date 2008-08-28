Option Strict On
Option Explicit On

Imports System.Threading
Imports System.IO
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
    Private exitFlg As Boolean = False
    Private resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
    Private mvarClickedMouseButton As MouseButtons = Windows.Forms.MouseButtons.None
    Private mvarLnError As Boolean = False

    'CUSTOM  CREATED FUNCTIONS

    Private Delegate Sub NoParmDel()

    Public Sub DelayedConnectionChange()
        Try
            If ProgressDepth > -1 Then
                EndStatus()
            End If
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
        My.Settings.LastPath = NodeiPhonePath(trvFolders.SelectedNode)
        My.Settings.Position = Me.Left.ToString() & "," & Me.Top.ToString() & "," & Me.Width.ToString() & "," & Me.Height.ToString()
        My.Settings.Save()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        qtPlugin.Dispose()
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

            If mvarLnError Then
                mvarLnError = False
            ElseIf bNowConnected Then
                'the phone was just recognized as connected
                refreshFolders()
                trvFolders.Focus()

                If iPhoneInterface.IsJailbreak Then
                    'StatusNormal("iPhone is connected and jailbroken")
                    StatusNormal(My.Resources.String3)
                    If iPhoneInterface.Exists("/var/mobile/Media/DCIM") Then
                        tildeDir = "/var/mobile"
                    End If
                Else
                    'StatusWarning("iPhone is connected, not jailbroken")
                    StatusWarning(My.Resources.String1)
                End If
                'Set last path
                If My.Settings.LastPath <> "" Then
                    openPath(My.Settings.LastPath)
                End If
            Else
                'StatusWarning("iPhone is NOT connected, please check your connections!")
                StatusWarning(My.Resources.String2)

                My.Settings.LastPath = NodeiPhonePath(trvFolders.SelectedNode)
            End If

        End If
    End Sub

    Private Sub refreshChildFolders(ByVal forceRefresh As Boolean)
        If Not bUpdateInProgress Then
            refreshChildFolders(trvFolders.SelectedNode, forceRefresh)
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
            startStatus(rootNode.Nodes.Count)

            Try
                For Each tmpNode In rootNode.Nodes
                    If IncrementStatus() Then Exit For

                    sWorkingPath = NodeiPhonePath(tmpNode)

                    tmpNode.Nodes.Clear()
                    'now add it (only if it is not the root)
                    If sWorkingPath <> "/" Then
                        Try
                            AddFolders(sWorkingPath, tmpNode, 1)
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
        Dim iFileSize As Integer = iPhoneInterface.FileSize(sFilePath)
        'make it look pretty
        If iFileSize > 10240000 Then
            Return String.Format("{0:0.##} MB", iFileSize / 1024000)
        ElseIf iFileSize > 10240 Then
            Return String.Format("{0:0.##} KB", iFileSize / 1024)
        Else
            Return String.Format("{0} B", iFileSize)
        End If
    End Function

    Friend Sub LoadFiles()
        Dim sFiles() As String
        Dim iPhonePath As String
        Dim lstTemp As ListViewItem

        If Not bSupressFiles Then
            'Dim sbpath As New System.Text.StringBuilder
            'loads the files into the list view based on the current directory

            Try
                'first clear out any files that may be there
                exitFlg = False
                lstFiles.BeginUpdate()
                lstFiles.Items.Clear()
                lstFiles.ListViewItemSorter = Nothing
                lstFilesSortOrder = SortOrder.None

                iPhonePath = nodeiPhonePath(trvFolders.SelectedNode)
                'StatusNormal("Loading Files for " & iPhonePath & "...")
                StatusNormal(String.Format(My.Resources.String5, iPhonePath))
                'now get the files from the iphone
                sFiles = iPhoneInterface.GetFiles(iPhonePath)

                'now go one by one and add it
                startStatus(sFiles.Length)
                For Each sFile As String In sFiles
                    If incrementStatus() Then Exit For

                    lstTemp = New ListViewItem(sFile)
                    lstTemp.ImageIndex = getImageIndexForFile(sFile)
                    If lstFiles.ShowGroups Then
                        lstTemp.Group = lstFiles.Groups(lstTemp.ImageIndex)
                    End If

                    ' add the file size
                    sFile = convertcd(sFile)
                    lstTemp.SubItems.Add(fileSizeAsString(iPhonePath & "/" & sFile))
                    ' add the backup directory
                    Dim row As Integer = ObjDb.Find(iPhonePath & "/" & sFile)
                    If row = -1 Then
                        lstTemp.SubItems.Add("")
                    Else
                        Dim dirName As String = ObjDb.GetValue(row, 1)
                        Dim lvItem As ListViewItem.ListViewSubItem = lstTemp.SubItems.Add(dirName)
                        If dirName = "Error" Then
                            lstTemp.ForeColor = Color.Red
                            'lstTemp.SubItems(0).ForeColor = Color.Black
                        End If
                    End If
                    ' add the file type
                    lstTemp.SubItems.Add(getFiletype(lstTemp.ImageIndex))

                    'ここで中断する
                    If exitFlg Then
                        Exit For
                    End If

                    'finally add it to the view
                    lstFiles.Items.Add(lstTemp)

                Next
                StatusNormal("")

                exitFlg = True

                'ClearPreview()
                'grpFiles.Text = "Files on your iPhone in the '" & nodeiPhonePath(trvFolders.SelectedNode) & "' Directory"
                grpFiles.Text = String.Format(My.Resources.String6, nodeiPhonePath(trvFolders.SelectedNode))

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
                EndStatus()
                lstFiles.EndUpdate()
            End Try

        End If
    End Sub

    ''' <summary>
    ''' returns the image index for the given file's extension
    ''' </summary>
    ''' <param name="sFilename">file to lookup</param>
    ''' <returns>image index</returns>
    Private Function getImageIndexForFile(ByVal sFilename As String) As Integer
        Dim iReturn As Integer = IMAGE_FILE_UNKNOWN

        sFilename = Path.GetFileName(sFilename.ToLower())
        Dim sExt As String = sFilename.Substring(sFilename.LastIndexOf(".") + 1)

        Select Case sExt
            Case "png", "jpg", "jpeg", "gif"
                iReturn = IMAGE_FILE_IMAGE
            Case "strings", "conf", "txt", "script", "pl", "h", "awk", "tcl", "css", "m4", "c"
                iReturn = IMAGE_FILE_TEXT
            Case "db", "sqlite", "sqlitedb"
                iReturn = IMAGE_FILE_DATABASE
            Case "aiff", "amr", "aif", "caf", "wav"
                iReturn = IMAGE_FILE_AUDIO
            Case "m4r"
                'iReturn = IMAGE_FILE_RINGTONE
            Case "m4a", "m4p", "mp3", "aac"
                iReturn = IMAGE_FILE_MUSIC
            Case "mp4", "mov", "3gp", "tga"
                iReturn = IMAGE_FILE_MOVIE
            Case "htm", "html", "plist", "thm", "xml", "pdf"
                iReturn = IMAGE_FILE_WEBBROWS
        End Select

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

        startStatus(3)
        trvFolders.Nodes.Clear()
        rootNode = New TreeNode(STRING_ROOT)
        rootNode.ContextMenuStrip = menuRightClickFolders
        rootNode.Name = "/"
        trvFolders.Nodes.Add(rootNode)
        incrementStatus()

        addFolders("", rootNode)
        incrementStatus()

        rootNode.Expand()
        trvFolders.SelectedNode = rootNode
        incrementStatus()

        trvFolders.ResumeLayout()
        Me.Cursor = Cursors.Arrow
        endStatus()
    End Sub

    'Friend Sub addFoldersBeneath()
    '    If trvFolders IsNot Nothing Then
    '        Dim aNode As TreeNode = trvFolders.SelectedNode
    '        addFolders(NodeiPhonePath(aNode), aNode)
    '    End If
    'End Sub

    'Private Sub addFoldersBeneath(ByVal aNode As TreeNode)
    '    addFolders(nodeiPhonePath(aNode), aNode)
    'End Sub

    '''' <summary>
    '''' 
    '''' </summary>
    '''' <param name="sPath"></param>
    '''' <param name="selectedNode"></param>
    '''' <param name="iDepth"></param>
    '''' <remarks></remarks>
    'Private Sub addFolders(ByVal sPath As String, ByVal selectedNode As TreeNode, Optional ByVal iDepth As Integer = 0)
    '    'This function is recursive to add one level of folders to the tree view
    '    ' you give it one folder and will drill down and add one level of folders
    '    Dim sFolders() As String
    '    Dim newNode As TreeNode
    '    Dim sbpath As New System.Text.StringBuilder

    '    If sPath = "/" Then ' handle root special case
    '        sPath = ""
    '    End If

    '    Try
    '        'get the data from the phone
    '        sFolders = iPhoneInterface.GetDirectories(sPath)

    '        startStatus(sFolders.Length)

    '        selectedNode.Nodes.Clear() ' remove any existing nodes

    '        For Each sFolder As String In sFolders
    '            sbpath.Length = 0
    '            sbpath.Append(sPath).Append("/").Append(sFolder)
    '            'create the new node
    '            newNode = New TreeNode(sFolder)
    '            newNode.Name = sbpath.ToString()
    '            newNode.ContextMenuStrip = menuRightClickFolders

    '            selectedNode.Nodes.Add(newNode)

    '            'now make the recursive call on this folder
    '            If iDepth < 1 Then ' only load first tree level beneath
    '                addFolders(sbpath.ToString(), newNode, iDepth + 1)
    '            End If

    '            If incrementStatus() Then Exit For
    '        Next
    '        If escapeFlg OrElse iDepth > 0 Then
    '            selectedNode.Tag = False
    '        Else
    '            selectedNode.Tag = True
    '        End If

    '    Catch ex As Exception
    '        'ここのエラーで接続が中断されて継続できなくなる。
    '        StatusWarning(My.Resources.String35)
    '        'StatusWarning(ex.Message)

    '    Finally
    '        endStatus()
    '    End Try

    'End Sub

    Private Function getSelectedFilename() As String
        'returns the currently selected filename
        Return getSelectedPath() & lstFiles.SelectedItems(0).Text
    End Function

    Private Function getSelectedFolder() As String
        'Return Mid(trvFolders.SelectedNode.FullPath, STRING_ROOT.Length + 1)
        Return trvFolders.SelectedNode.FullPath.Substring(STRING_ROOT.Length)
    End Function

    Private Function getSelectedPath() As String
        'returns the currently selected folder
        Return getSelectedFolder() & "/"
    End Function

    ' courtesy Greg Martin
    Private Function CountStr(ByVal InStr As String, ByVal MatchString As String) As Integer
        Try
            Dim SourceString As String = InStr
            Dim StringExpr As New System.Text.RegularExpressions.Regex(MatchString)
            Return StringExpr.Matches(SourceString).Count
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
            If sPathOnPhone.EndsWith("/") Then
                sPathOnPhone = sPathOnPhone.Substring(0, sPathOnPhone.Length - 1)
            End If
            'first, lets try to find it without expanding
            tn = trvFolders.Nodes.Find(sPathOnPhone, True)
            If tn.Length = 0 Then ' we couldn't find it
                StartStatus(CountStr(sPathOnPhone, "/"))

                Try
                    'select the root first
                    tn = trvFolders.Nodes.Find("/", True)

                    'go through and load each node
                    'iNode = 1
                    'Do While sPathOnPhone.IndexOf("/", iNode) > -1
                    '    'pull out the full path to the next node
                    '    sTemp = sPathOnPhone.Substring(0, sPathOnPhone.IndexOf("/", iNode))
                    '    iNode = sPathOnPhone.IndexOf("/", iNode) + 1

                    '    tn = tn(0).Nodes.Find(sTemp, False)
                    '    If tn.Length > 0 Then
                    '        refreshChildFolders(tn(0), False)
                    '    Else
                    '        Exit Do
                    '    End If
                    '    If IncrementStatus() Then Exit Do
                    'Loop
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
                        If IncrementStatus() Then Exit Do
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
                        loadFiles()
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

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
            BtnCancel.Visible = False
            ProgressDepth = -1

            'APP_PATH = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\Cranium\iPhoneBrowser\"
            'APP_PATH = My.Settings.BackupPath & "\touchBrowser\"
            setBackupPath(DateTime.Now)

            FILE_TEMPORARY_VIEWER = Path.GetTempPath & FILE_TEMPORARY_VIEWER

            Me.Text = My.Resources.String14 & " (v" & Application.ProductVersion & ")"

            ' initialize the file list groups
            For j1 As Integer = 0 To 7
                Dim lvg As ListViewGroup = New ListViewGroup(getFiletype(j1))
                lstFiles.Groups.Add(lvg)
            Next

            ' load up the user settings
            If My.Settings.CallUpgrade Then
                My.Settings.Upgrade()
                My.Settings.CallUpgrade = False
                My.Settings.Save()
            End If
            ConfirmDeletionsToolStripMenuItem.Checked = My.Settings.ConfirmDeletions
            Config.bConvertToiPhonePNG = My.Settings.PCToiPhonePNG
            Config.bConvertToPNG = My.Settings.iPhoneToPCPNG
            Config.bShowPreview = My.Settings.ShowPreviews
            Config.bIgnoreThumbsFile = My.Settings.IgnoreThumbsFile
            Config.bIgnoreDSStoreFile = My.Settings.IgnoreDSStoreFile
            tsmIPhoneToPC.Checked = Config.bConvertToPNG
            tsmPCToIPhone.Checked = Config.bConvertToiPhonePNG
            ShowPreviewsToolStripMenuItem.Checked = Config.bShowPreview
            IgnoreThumbsdbToolStripMenuItem.Checked = Config.bIgnoreThumbsFile
            IgnoreDSStoreToolStripMenuItem.Checked = Config.bIgnoreDSStoreFile
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

            LoadFavoritesMenu()

            ' setup the tooltips
            menuSetTooltips(mnuGoTo)
            menuSetTooltips(mnuStdApps)
            menuSetTooltips(mnuThirdPartyApps)

            tildeDir = "/var/root"

            iPhoneInterface = New iPhone

            'setup the event handlers
            AddHandler iPhoneInterface.Connect, AddressOf iPhoneConnected_EventHandler
            AddHandler iPhoneInterface.Disconnect, AddressOf iPhoneDisconnected_EventHandler

        Catch ex As Exception
            MsgBox(My.Resources.String15 & ex.Message & My.Resources.String16, MsgBoxStyle.Critical, "Error!")
            Me.Close()

        End Try

    End Sub

    Private Sub SetViewChecks()
        ToolStripMenuItemLargeIcons.Checked = (lstFiles.View = View.LargeIcon)
        ToolStripMenuItemDetails.Checked = (lstFiles.View = View.Details)
        cmdSmallIcons.Checked = (lstFiles.View = View.SmallIcon)
    End Sub

    Private Sub ToolStripMenuItemLargeIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemLargeIcons.Click
        lstFiles.View = View.LargeIcon
        SetViewChecks()
    End Sub

    Private Sub ToolStripMenuItemDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDetails.Click
        lstFiles.View = View.Details
        SetViewChecks()
    End Sub

    Private Sub cmdSmallIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSmallIcons.Click
        lstFiles.View = View.SmallIcon
        SetViewChecks()
    End Sub

    Private Sub ToolStripMenuItemExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemExit.Click

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

    Private Sub trvFolders_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvFolders.AfterExpand
        refreshChildFolders(e.Node, False)
    End Sub

    Private Sub trvFolders_BeforeCollapse(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles trvFolders.BeforeCollapse
        IsCollapsing = True
    End Sub

    Private Sub trvFolders_AfterCollapse(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvFolders.AfterCollapse
        IsCollapsing = False
    End Sub

    Private Sub trvFolders_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trvFolders.AfterSelect
        Dim selNode As TreeNode = e.Node

        If Not IsCollapsing AndAlso (Not selNode.IsExpanded()) Then
            trvFolders.SelectedNode.Expand()
        End If
        If selNode.Level > 0 AndAlso CBool(selNode.Tag) = False Then
            'AddFoldersBeneath(selNode)
            'Folderの展開でキャンセルしたとき
            AddFolders(NodeiPhonePath(selNode), selNode, 1)
        End If
        loadFiles()
    End Sub

    Private Sub lstFiles_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstFiles.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Me.Cursor = Cursors.WaitCursor
            Dim initFolder As String = getSelectedPath()
            Dim drops() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
            startStatus(drops.Length)
            For Each s As String In drops 'e.Data.GetData(DataFormats.FileDrop)
                CopyToPhone(s, initFolder, Config.bConvertToiPhonePNG)
                If incrementStatus() Then Exit For
            Next
            endStatus()
            StatusNormal("")

            selectSpecificPath(initFolder) ' fix up tree view
            loadFiles() ' refresh the list view
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub lstFiles_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lstFiles.DragEnter
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
        qtPlugin.Visible = False
        WebBrws.Visible = False

        btnPreview.Enabled = True
    End Sub

    Private Sub showFileDetails(ByVal sFile As String)
        Dim i As Integer = 1
        Dim bo As Boolean

        iPhoneInterface.GetFileInfo(sFile, i, bo)
        'Dim status As String = Convert.ToString(i, 2)
        'Debug.WriteLine(status)

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
            If backupDir = "" OrElse fsize < 1000000 Then
                copyRC = CopyQueueFromPhone(sFile, tmpOnPC)
                'Dim dic As Dictionary(Of String, String) = iPhoneInterface.GetFileInfo(sFile)
                'For Each item As KeyValuePair(Of String, String) In dic
                '    Debug.WriteLine("")
                'Next
            Else
                tmpOnPC = GetBackupPath(True) & backupDir & sFile.Replace("/", "\")
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
                                    'qtPlugin.Visible = False
                                    txtFileDetails.Visible = False
                                End With
                            End If

                        Case IMAGE_FILE_AUDIO, IMAGE_FILE_MOVIE, IMAGE_FILE_MUSIC
                            If ProgressEscapeFlg = False Then
                                'qtPlugin.FileName = tmpOnPC
                                'qtPlugin.Sizing = QTOControlLib.QTSizingModeEnum.qtMovieFitsControlMaintainAspectRatio
                                'qtPlugin.AutoPlay = CStr(True)
                                'qtPlugin.Visible = True
                                'qtPlugin.Refresh()
                                wasQTpreview = qtPlugin.Play(tmpOnPC)
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

            If prevSelectedFile = sFile Then ' make sure we changed selections (handles multi-selecte better)
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

    Private Sub lstFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFiles.SelectedIndexChanged
        If mvarClickedMouseButton = Windows.Forms.MouseButtons.Right Then
            Exit Sub
        End If
        If Config.bShowPreview AndAlso Not splFilesLock Then
            lstFiles.Cursor = Cursors.No
            splFilesLock = True
            Dim sFile As String = doFileSelectedPreview(False, False)
            'Dim iPhonePath As String = NodeiPhonePath(trvFolders.SelectedNode)

            Dim row As Integer = ObjDb.Find(sFile)
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
    End Sub

    Private Sub menuRightSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRightSaveAs.Click
        Dim sSaveAsFilename As String, sFolder As String, sFileFromPhone As String

        If lstFiles.SelectedItems.Count = 1 Then
            sFolder = getSelectedPath()
            Dim sItem As ListViewItem = lstFiles.SelectedItems(0)
            'show them the save dialog
            fileSaveDialog.Title = "Save " & sItem.Text & " as ..."
            fileSaveDialog.FileName = FixPhoneFilename(sItem.Text)
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

    Private Sub menuRightBackupFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRightBackupFile.Click
        Dim sSourcePath As String

        If lstFiles.SelectedItems.Count > 0 Then
            sSourcePath = getSelectedPath()
            'Dim aTime As Date = DateTime.Now

            For Each sItem As ListViewItem In lstFiles.SelectedItems
                BackupFileFromPhone(sSourcePath, sItem.Text)
            Next
            'backup dataの再取得
            ObjDb.ReSelect()
            '再描画
            loadFiles()
        End If

    End Sub

    Private Sub menuRightReplaceFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRightReplaceFile.Click
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
                CopyToPhone(sSourceFilename, sFileToPhone, Config.bConvertToiPhonePNG)
                'refresh the list view
                loadFiles()
            End If
        Else
            'Only one file can be replaced at a time
            MsgBox(My.Resources.String24, MsgBoxStyle.Exclamation, "Selection error")
        End If

    End Sub

    Private Sub menuRightDeleteFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRightDeleteFile.Click
        'delete the selected file
        Dim sFolder As String, sDeleteFilename As String, okDel As Boolean

        If lstFiles.SelectedItems.Count > 0 Then
            sFolder = getSelectedPath()
            For Each sItem As ListViewItem In lstFiles.SelectedItems
                sDeleteFilename = sFolder & sItem.Text
                okDel = True
                If ConfirmDeletionsToolStripMenuItem.Checked Then
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
                    DelFromPhone(sDeleteFilename)
                End If
            Next

            'refresh the list view
            loadFiles()
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
            StatusNormal(My.Resources.String44)
            Me.picDelete.Visible = True
            Me.Cursor = Cursors.WaitCursor
            Me.splFiles.Panel2Collapsed = True
            Try
                DbManager.PackDB(GetBackupPath(True))
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
        End If
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
        toolStripGoTo10.Click, ToolStripMenuItem2.Click, toolStripGoTo20.Click, TTRToolStripMenuItem.Click, NESROMSToolStripMenuItem.Click, ISwitcherThemesToolStripMenuItem.Click, InstallerPackageSourcesToolStripMenuItem.Click, FrotzGamesToolStripMenuItem.Click, EBooksToolStripMenuItem.Click, DockSwapDocksToolStripMenuItem.Click, ToolStripMenuItem5.Click, ToolStripMenuItem6.Click, cmdGBAROMs.Click, CameraRollToolStripMenuItem.Click

        Dim sPath As String
        Dim ts As ToolStripMenuItem
        'Dim try2 As Boolean = False

        ts = CType(sender, ToolStripMenuItem)
        sPath = CStr(ts.Tag())
        'try2 = Microsoft.VisualBasic.Left(sPath, 10) = "/var/root/"
        openPath(sPath)

    End Sub

    Private Sub openPath(ByVal sPath As String)
        If Not selectSpecificPath(sPath) Then
            If sPath.StartsWith("/var/root/") Then
                sPath = "/var/mobile" & sPath.Substring(9)
            End If
            If Not selectSpecificPath(sPath) Then
                If iPhoneInterface.IsJailbreak Then
                    If Not iPhoneInterface.Exists(sPath) Then
                        'Do you want to create " & sPath & "?"
                        If MsgBox(String.Format(My.Resources.String27, sPath), MsgBoxStyle.YesNo, "Create Special Folder") = MsgBoxResult.Yes Then
                            If iPhoneInterface.CreateDirectory(sPath) Then
                                If Not selectSpecificPath(sPath) Then
                                    'Error: The program could not find the path '" & sPath & "' on your iPhone.  Creation appeared to be successful
                                    MsgBox(String.Format(My.Resources.String25, sPath), MsgBoxStyle.Critical)
                                End If
                            Else
                                '"Error: The program could not create the path '" & sPath & "' on your iPhone.  Have you successfully used jailbreak?
                                MsgBox(String.Format(My.Resources.String26, sPath), MsgBoxStyle.Critical)
                            End If
                        End If
                    End If
                Else
                    MsgBox(String.Format(My.Resources.String26, sPath), MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItemNewFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemNewFolder.Click
        Dim sPath As String, sNewFolder As String, bValid As Boolean = False

        sPath = getSelectedPath()
        sNewFolder = InputBox(String.Format(My.Resources.String21, sPath), "Create Folder In " & sPath, "NewFolder")
        sPath = sPath & sNewFolder

        'make sure it is valid
        If sNewFolder = "" Then
            ' user canceled
        ElseIf sNewFolder = "NewFolder" Then
            MsgBox("You didn't change the default name, I am pretty sure you don't want a 'NewFolder' folder name...", MsgBoxStyle.Information, "Canceled")
        ElseIf sNewFolder.IndexOf(" ") > -1 OrElse sNewFolder.IndexOf("/") > -1 OrElse sNewFolder.IndexOf("\") > -1 OrElse _
                sNewFolder.IndexOf("*") > -1 OrElse sNewFolder.IndexOf("?") > -1 OrElse sNewFolder.IndexOf("[") > -1 OrElse sNewFolder.IndexOf("]") > -1 Then
            'No spaces, slashes or other special characters are allowed in the folder name.
            MsgBox(My.Resources.String22, MsgBoxStyle.Information, "Canceled")
        ElseIf iPhoneInterface.Exists(sPath) Then
            'The path '{0}' already exists.
            MsgBox(String.Format(My.Resources.String23, sPath), MsgBoxStyle.Information, "Canceled")
        Else
            bValid = True
        End If

        If bValid Then
            'lets create the directory
            If iPhoneInterface.CreateDirectory(sPath) Then
                'it created successfully
                selectSpecificPath(sPath)
            Else
                'it failed
                MsgBox("The path '" & sPath & "' failed to create due to an unknown interface failure.", MsgBoxStyle.Information, "Canceled")
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItemDeleteFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemDeleteFolder.Click
        Dim tNode As TreeNode, sPath As String, bValid As Boolean = False, findNode() As TreeNode

        sPath = getSelectedFolder()
        tNode = trvFolders.SelectedNode

        If lstFiles.Items.Count > 0 OrElse tNode.Nodes.Count > 0 Then
            If ConfirmDeletionsToolStripMenuItem.Checked Then
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
            refreshFolders()
        Else
            ' select the parent path
            Dim sNewFolder As String = sPath.Substring(0, sPath.LastIndexOf("/"))
            If sNewFolder = "" Then
                sNewFolder = "/"
            End If
            trvFolders.Nodes.Remove(findNode(0)) ' delete the selected node

            selectSpecificPath(sNewFolder)
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

    Private Sub lstFiles_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstFiles.ColumnClick
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
    Private Sub trvFolders_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles trvFolders.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            trvFolders.SelectedNode = e.Node
        End If
    End Sub

    Private Sub menuRightClickFiles_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles menuRightClickFiles.Opening
        If lstFiles.SelectedItems.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub ColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlackToolStripMenuItem.Click, WhiteToolStripMenuItem.Click, GrayToolStripMenuItem.Click
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

    Private Sub menuSaveSummerboardTheme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAsSummerboardFolder.Click
        Dim dFolder As String, sSaveAsFilename As String, sFileFromPhone As String
        Dim sPath As String, sFolders() As String

        If My.Settings.SummerboardPath <> "" Then
            folderBrowserDialog.SelectedPath = My.Settings.SummerboardPath
        End If

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

    Private Sub AsCustomizeFoldersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAsCustomizeFolders.Click
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

    Private Sub IPhoneToPCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmIPhoneToPC.Click
        Config.bConvertToPNG = tsmIPhoneToPC.Checked
    End Sub

    Private Sub PCToIPhoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmPCToIPhone.Click
        Config.bConvertToiPhonePNG = tsmPCToIPhone.Checked
    End Sub

    Private Sub PreviewChanged()
        chkPreviewEnabled.Checked = Config.bShowPreview
        ShowPreviewsToolStripMenuItem.Checked = Config.bShowPreview
        btnPreview.Enabled = Config.bShowPreview
        If Config.bShowPreview Then
            doFileSelectedPreview(False, False)
        Else
            clearPreview()
            prevSelectedFile = "" ' force preview next time
        End If
    End Sub

    Private Sub ShowPreviewsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowPreviewsToolStripMenuItem.Click
        Config.bShowPreview = ShowPreviewsToolStripMenuItem.Checked
        PreviewChanged()
    End Sub

    Private Sub chkPreviewEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPreviewEnabled.CheckedChanged
        Config.bShowPreview = chkPreviewEnabled.Checked
        PreviewChanged()
    End Sub

    Private Sub ToolStripMenuItemSaveFolderIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemSaveFolderIn.Click
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

    Private Sub BackupFolderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupFolderToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        BackupDirectory(getSelectedFolder())
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cmdRenameFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRenameFile.Click
        Dim oldPath As String = getSelectedFilename(), newPath As String
        Dim newName As String = InputBox("Enter new folder name:", "Rename file ", Path.GetFileName(oldPath))
        If newName <> "" Then
            If newName.IndexOf("/") > -1 Then
                StatusWarning("Can not use rename to move a file")
                Exit Sub
            End If
            newPath = PhoneGetDirectoryName(oldPath) & "/" & newName
            If iPhoneInterface.Rename(oldPath, newPath) Then
                loadFiles()
            End If
        End If

    End Sub

    Private Sub cmdRenameFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRenameFolder.Click
        Dim oldPath As String = getSelectedFolder(), newPath As String
        Dim newName As String = InputBox("Enter new folder name:", "Rename folder", Path.GetFileName(oldPath))
        If newName <> "" Then
            If newName.IndexOf("/") > -1 Then
                StatusWarning("Can not use rename to move a folder")
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

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        lstFiles.Select()
        prevSelectedFile = "" ' force preview
        doFileSelectedPreview(True, True)
    End Sub

    Private Sub chkPreviewEnabled_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPreviewEnabled.Enter
        lstFiles.Select()
    End Sub

    Private Sub cmdShowGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowGroups.Click
        lstFiles.ShowGroups = Not lstFiles.ShowGroups
        cmdShowGroups.Checked = lstFiles.ShowGroups
        If lstFiles.ShowGroups Then
            loadFiles()
        End If
    End Sub

    Private Sub cmdFavorite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim anItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        selectSpecificPath(anItem.Tag.ToString())
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
            addFoldersBeneath(trvFolders.SelectedNode)
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

    Private Sub OrganizeFavoritesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrganizeFavoritesToolStripMenuItem.Click
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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static lastval0 As Integer = -1
        Static lastval1 As Integer = -1

        If ProgressDepth <= MAX_PROG_DEPTH Then
            With ProgressBars(ProgressDepth)
                If ProgressValue(ProgressDepth) < .Maximum Then
                    '.PerformStep()
                    .Value = ProgressValue(ProgressDepth)
                    If lastval0 <> ProgressValue(0) Then
                        lastval0 = ProgressValue(0)
                        ProgressBars(0).Value = lastval0
                        'tlbStatusStrip.Refresh()
                        If lastval0 > 500 Then
                            tlbStatusLabel.Text = lastval0.ToString() & "/" & .Maximum.ToString()
                        End If
                    End If
                End If
            End With
        End If

    End Sub

    Private Sub ToolStripDropDownButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles BtnCancel.Click
        ProgressEscapeFlg = True
        BtnCancel.Visible = False
        ProgressBars(0).Visible = False
        ProgressBars(1).Visible = False
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim dialog As AboutBox = New AboutBox
        dialog.ShowDialog()
    End Sub

    Private Sub BackupDirectoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupDirectoryToolStripMenuItem.Click
        Dim dialog As New BackupDirDialog
        dialog.Show(Me)
    End Sub

    Private Sub menuRightClickFolders_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuRightClickFolders.VisibleChanged
        If menuRightClickFolders.Visible = True Then
            Dim enable As Boolean = Not (trvFolders.SelectedNode.FullPath = "[root]")
            menuRightSaveAs.Visible = enable
            menuRightBackupFile.Visible = enable
            cmdRenameFile.Visible = enable
            menuRightReplaceFile.Visible = enable
            menuRightDeleteFile.Visible = enable
        End If
    End Sub

    Private Sub tsmFileList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmFileList.Click
        Dim dg As frmBackupFiles = New frmBackupFiles

        Me.Refresh()
        dg.ShowDialog(Me)
        dg.Dispose()

    End Sub

    Private Sub lstFiles_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstFiles.MouseDown
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
            Dim backupPath As String = GetBackupPath(True)
            ObjDb.RefreshDB(backupPath & "list.txt", backupPath)
        Finally
            processingFlg = False
        End Try
    End Sub

    'Menu > Help > HomePage
    Private Sub tsmHomePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmHomePage.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            WebBrws.ScriptErrorsSuppressed = False
            WebBrws.Navigate(New Uri(My.Settings.HomepageURL))
            WebBrws.Visible = True
            WebBrws.IsWebBrowserContextMenuEnabled = False

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chkZoom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkZoom.CheckedChanged
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

        lblMovieName.Text = annotation

    End Sub

    Private Sub qtPlugin_ShowStatusString(ByVal message As String) Handles qtPlugin.ShowStatusString
        StatusNormal(message)
    End Sub

    Private Sub qtPlugin_VisibleChanged(ByVal visibled As Boolean) Handles qtPlugin.VisibleChanged
        chkZoom.Visible = visibled
        lblMovieName.Visible = visibled
    End Sub

End Class

