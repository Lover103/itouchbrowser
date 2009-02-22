Option Explicit On
Option Strict On

Imports System.IO
Imports System.Drawing.Imaging
Imports System.Text
Imports System.Threading
Imports Manzana
Imports SCW_iPhonePNG

Module ModuleMain

    Friend Const STRING_ROOT As String = "[root]"
    Friend Const STRING_APPL As String = "[Applications]"
    Friend Const MAX_PROG_DEPTH As Integer = 1
    Friend Const BACKUP_DIRECTORY As String = "touchBrowser\"
    Friend FILE_TEMPORARY_VIEWER As String = "iPhone.temp"

    Friend objMain As frmMain
    Friend iPhoneInterface As iPhone
    Friend ProgressDepth As Integer
    Friend ProgressBars(MAX_PROG_DEPTH) As ToolStripProgressBar
    Friend ProgressValue(MAX_PROG_DEPTH) As Integer
    Friend ProgressEscapeFlg As Boolean = False
    Friend ProgressFullSize As Long = 0
    Friend ProgressSize As Long = 0

    Public Structure structConfig
        Friend bShowPreview As Boolean
        Friend bIgnoreThumbsFile As Boolean
        Friend bIgnoreDSStoreFile As Boolean
        Friend bIgnoreCacheFile As Boolean
        Friend bConvertToiPhonePNG As Boolean
        Friend bConvertToPNG As Boolean
        Friend bBackupControled As Boolean
        Friend bShowSongTitle As Boolean
    End Structure

    Friend Config As structConfig

    ' import some functions
    Public Enum MessageBeepType
        [Default] = -1
        OK = &H0
        [Error] = &H10
        Question = &H20
        Warning = &H30
        Information = &H40
    End Enum

    ' This allows you to 'beep' using one of the sounds mapped using the
    ' sound mapper in control panel.
    <Runtime.InteropServices.DllImport("USER32.DLL", setlasterror:=True)> _
    Private Function MessageBeep(ByVal type As MessageBeepType) As Boolean
    End Function


    <STAThread()> _
    Public Sub Main()
        Dim message As String

        Try
            Application.EnableVisualStyles()

            Dim objSplash As New frmSplashScreen
            objSplash.Show()
            objSplash.SetProgressMessage("Initializing...")
            Application.DoEvents()

            objMain = New frmMain(objSplash.lblMessage)
            objMain.Cursor = Cursors.WaitCursor
            'objMain.Enabled = False

            If My.Settings.BackupControl Then
                objSplash.SetProgressMessage("Reading of a backup list...")
                Config.bBackupControled = True
                Dim dbThread As New Thread(New ThreadStart(AddressOf ModuleMain.dbInitialize))
                dbThread.Start()
            Else
                objMain.cohAttribute.Width = 0
            End If

            objSplash.SetProgressMessage("Show the window...")
            objMain.Show()

            'Logon...
            'objMain.Refresh()
            objMain.Enabled = True

            objSplash.Close()
            objSplash.Dispose()

            If ObjDb Is Nothing Then
                objMain.tsmCleanUp.Enabled = False
            ElseIf ObjDb.FileCount <= 0 Then
                message = My.Resources.String41 & vbCrLf & My.Resources.String42
                If MsgBox(message, MsgBoxStyle.Information Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim dialog As New BackupDirDialog
                    Dim rc As DialogResult = dialog.ShowDialog(objMain)
                    dialog.Dispose()
                    If rc = DialogResult.OK Then
                        objMain.restructureDB()
                    Else
                        objMain.tsmBackupControl.Checked = False
                    End If
                Else
                    objMain.tsmBackupControl.Checked = False
                End If
            End If

            objMain.Cursor = Cursors.Default

            If iPhoneInterface IsNot Nothing Then
                System.Windows.Forms.Application.Run(objMain)
            End If

            If ObjDb IsNot Nothing Then
                ObjDb.ExportDB()
            End If

            Exit Sub

        Catch ex As Exception
            message = ex.Message
            MsgBox(message, MsgBoxStyle.Critical)

        End Try

    End Sub

    Private Sub dbInitialize()
        ObjDb = ModuleMain.GetBackupList()
    End Sub

    Friend Sub StatusNormal(ByVal msg As String)
        objMain.tslStatusLabel.Image = Nothing
        objMain.tslStatusLabel.Text = msg
    End Sub

    Friend Sub StatusWarning(ByVal msg As String)
        objMain.tslStatusLabel.Image = My.Resources.warning
        objMain.tslStatusLabel.Text = msg
        MessageBeep(MessageBeepType.Warning)
    End Sub

    Friend Sub ResetStatus()
        objMain.Timer1.Enabled = False
        ProgressDepth = -1
    End Sub

    Friend Function StartStatus(ByVal iMax As Integer, ByVal fileSize As Long) As Integer
        ProgressDepth += 1
        If ProgressDepth <= MAX_PROG_DEPTH Then
            If ProgressDepth = 0 Then ' first bar - turn all on
                For j1 As Integer = MAX_PROG_DEPTH To 0 Step -1
                    With ProgressBars(j1)
                        .Visible = True
                        .Value = 0
                    End With
                Next
                objMain.btnCancel.Visible = True
                objMain.tslProgress.Text = ""
                objMain.tslProgress.Visible = True
                ProgressEscapeFlg = False
            End If
            ProgressBars(ProgressDepth).Maximum = iMax + 1
            ProgressValue(ProgressDepth) = 0
            objMain.Timer1.Enabled = True
        End If
        ProgressFullSize = fileSize

        Return ProgressDepth
    End Function

    Friend Sub EndStatus()
        If ProgressDepth >= 0 Then
            If ProgressDepth <= MAX_PROG_DEPTH Then
                If ProgressDepth = 0 Then
                    objMain.Timer1.Enabled = False
                End If
                Try
                    ProgressBars(ProgressDepth).Value = 0
                Catch ex As Exception
                    Exit Sub
                End Try

                If ProgressDepth = 0 Then ' first bar - turn all off
                    For j1 As Integer = 0 To MAX_PROG_DEPTH
                        ProgressBars(j1).Visible = False
                    Next
                    objMain.btnCancel.Visible = False
                    objMain.tslProgress.Visible = False
                    ProgressFullSize = 0
                End If
            End If
            ProgressDepth -= 1
        End If
        objMain.tlbStatusStrip.Refresh()
    End Sub

    Friend Function IncrementStatus(ByVal curVal As Long) As Boolean
        If ProgressDepth <= MAX_PROG_DEPTH Then
            Try
                ProgressValue(ProgressDepth) += 1
                ProgressSize = curVal
            Catch
                'ProgressEscapeFlg = True
            End Try
        Else
            ProgressSize = curVal
        End If
        Application.DoEvents()

        Return ProgressEscapeFlg
    End Function

    Friend Function NodeiPhonePath(ByVal aNode As TreeNode) As String
        If aNode Is Nothing Then
            Return ""
        End If
        Dim sTemp As String = aNode.FullPath

        If sTemp <> STRING_ROOT Then
            sTemp = sTemp.Substring(STRING_ROOT.Length) '.Replace("\", "/")
        Else
            sTemp = "/"
        End If

        Return sTemp
    End Function

    ''' <summary>
    ''' File copy from iPhone
    ''' </summary>
    ''' <param name="sourceOnPhone"></param>
    ''' <param name="destinationOnComputer"></param>
    ''' <returns>
    '''    integer >0 file size
    '''            -1 Error
    '''            -2 Escaped
    ''' </returns>
    ''' <remarks></remarks>
    Friend Function CopyFromPhone(ByVal sourceOnPhone As String, ByVal destinationOnComputer As String) As Long
        Dim sBuffer(32767) As Byte
        Dim iDataBytes As Integer
        Dim iPhoneFileInterface As iPhoneFile
        Dim fileTemp As FileStream
        Dim bReturn As Long = -1    'Error

        If Config.bIgnoreCacheFile AndAlso sourceOnPhone.EndsWith(".cache") Then
            Return -2 'No copy. pretend copying was ok, but don't copy cache.
        End If

        'remove our local file if it exists
        If File.Exists(destinationOnComputer) Then
            Try
                My.Computer.FileSystem.DeleteFile(destinationOnComputer)
            Catch
                Return bReturn
            End Try
        End If

        'make sure the source file exists
        If iPhoneInterface.Exists(sourceOnPhone) Then
            Dim fSize As Long = iPhoneInterface.FileSize(sourceOnPhone)

            'open a connection to the file and read it
            Try
                iPhoneInterface.CurrentDirectory = "/"
                iPhoneFileInterface = iPhoneFile.OpenRead(iPhoneInterface, sourceOnPhone)

            Catch ex As Exception
                ResetiPhone()
                EndStatus() 'fill our progressbar
                Return bReturn
            End Try

            Dim buffSize As Integer = sBuffer.Length
            Dim cnt As Integer = CInt(fSize / buffSize)
            If cnt > 100 Then
                buffSize *= 2
                cnt \= 2
                If cnt > 500 Then
                    buffSize *= 2
                    cnt \= 2
                End If
                ReDim sBuffer(buffSize - 1)
            End If

            Dim depth As Integer = StartStatus(cnt, fSize) 'show our progress bar

            Try
                Dim curSize As Long = 0
                If depth = 0 Then objMain.lstFiles.Enabled = False
                fileTemp = File.OpenWrite(destinationOnComputer)
                iDataBytes = iPhoneFileInterface.Read(sBuffer, 0, sBuffer.Length)
                While iDataBytes > 0
                    fileTemp.Write(sBuffer, 0, iDataBytes)
                    curSize += iDataBytes
                    iDataBytes = iPhoneFileInterface.Read(sBuffer, 0, sBuffer.Length)
                    If IncrementStatus(curSize) Then
                        fSize = -2
                        Exit While 'increment our progressbar
                    End If
                End While

                iPhoneFileInterface.Close()
                iPhoneFileInterface.Dispose()
                fileTemp.Close()
                If fSize = -2 Then
                    File.Delete(destinationOnComputer)
                End If

                bReturn = fSize

            Catch exio As IOException
                StatusWarning(exio.Message)
                bReturn = -1
            Catch ex As Exception
                StatusWarning(ex.Message)
                bReturn = -1
            Finally
                EndStatus() 'fill our progressbar
                If depth = 0 Then
                    objMain.lstFiles.Enabled = True
                    objMain.lstFiles.Focus()
                End If
            End Try
        Else
            fileTemp = File.OpenWrite(destinationOnComputer)
            fileTemp.Close()
            bReturn = 0
        End If

        Return bReturn
    End Function

    Friend Function CopyQueueFromPhone(ByVal sourceOnPhone As String, ByRef destinationOnComputer As String) As Integer
        'Dim sBuffer(8191) As Byte
        Dim sBuffer(65535) As Byte
        Dim iDataBytes As Integer
        Dim iPhoneFileInterface As iPhoneFile
        Dim fileTemp As FileStream
        Dim bReturn As Integer = -1
        Dim destname As String = destinationOnComputer
        Dim i As Integer

        For i = 1 To 5
            'remove our local file if it exists
            If File.Exists(destinationOnComputer) Then
                Try
                    File.Delete(destinationOnComputer)
                    Exit For
                Catch
                    Dim ext As String = destname.Substring(destname.LastIndexOf("."))
                    destinationOnComputer = destname.Substring(0, destname.Length - ext.Length) & "." & i.ToString() & ext
                End Try
            Else
                Exit For
            End If
        Next
        If i = 6 Then
            Return bReturn
        End If

        'make sure the source file exists
        If iPhoneInterface.Exists(sourceOnPhone) Then

            'open a connection to the file and read it
            Try
                iPhoneInterface.CurrentDirectory = "/"
                iPhoneFileInterface = iPhoneFile.OpenRead(iPhoneInterface, sourceOnPhone)

            Catch ex As Exception
                ResetiPhone()
                Return bReturn
            End Try

            'show our progress bar
            Dim buffSize As Integer = sBuffer.Length
            Dim fSize As Long = iPhoneInterface.FileSize(sourceOnPhone)
            Dim cnt As Integer = CInt(fSize / buffSize)
            If cnt > 100 Then
                buffSize *= 2
                cnt \= 2
                ReDim sBuffer(buffSize - 1)
            End If
            Dim depth As Integer = StartStatus(cnt, fSize)

            Try
                If depth = 0 Then objMain.lstFiles.Enabled = False
                fileTemp = File.OpenWrite(destinationOnComputer)

            Catch exio As IOException
                EndStatus() 'fill our progressbar
                StatusWarning(exio.Message)
                Return bReturn
            End Try

            Try
                Dim curSize As Long = 0
                iDataBytes = iPhoneFileInterface.Read(sBuffer, 0, buffSize)
                While iDataBytes > 0
                    curSize += iDataBytes
                    fileTemp.Write(sBuffer, 0, iDataBytes)
                    If IncrementStatus(curSize) Then
                        bReturn = 1
                        Exit Try 'increment our progressbar
                    End If
                    iDataBytes = iPhoneFileInterface.Read(sBuffer, 0, buffSize)
                End While

                bReturn = 0

            Catch ex As Exception
                StatusWarning(ex.Message)

            Finally
                iPhoneFileInterface.Close()
                iPhoneFileInterface.Dispose()
                fileTemp.Close()
                fileTemp.Dispose()
                EndStatus() 'fill our progressbar

                If depth = 0 Then
                    objMain.lstFiles.Enabled = True
                    objMain.lstFiles.Focus()
                End If
            End Try
        End If

        Return bReturn
    End Function

    Friend Function CopyFromPhoneMakePNG(ByVal sPhone As String, ByVal dComputer As String) As Long
        Dim tmpOnPC As String = GetTempFilename(sPhone)
        Dim ans As Long = CopyFromPhone(sPhone, tmpOnPC)
        If ans = 0 Then
            Try
                Dim cvtImage As Image = iPhonePNG.ImageFromFile(tmpOnPC)
                cvtImage.Save(dComputer, ImageFormat.Png)
            Catch
                ans = CopyFromPhone(sPhone, dComputer)
            End Try
        End If

        Return ans
    End Function

    Friend Function CopyFromPhonePNG(ByVal sPhone As String, ByVal dComputer As String) As Long
        If Config.bConvertToPNG AndAlso sPhone.ToLower.EndsWith(".png") Then
            Dim tmpOnPC As String = GetTempFilename(sPhone)
            Dim ans As Long = CopyFromPhone(sPhone, tmpOnPC)
            If ans = 0 Then
                Try
                    Dim cvtImage As Image = iPhonePNG.ImageFromFile(tmpOnPC)
                    cvtImage.Save(dComputer, ImageFormat.Png)
                Catch
                    ans = CopyFromPhone(sPhone, dComputer)
                End Try
                My.Computer.FileSystem.DeleteFile(tmpOnPC)
            End If

            Return ans
        Else
            Return CopyFromPhone(sPhone, dComputer)
        End If
    End Function

    Private Function copy1ToPhonePNGAt(ByVal sComputer As String, ByVal dPhone As String, ByVal aBackupTime As Date) As Boolean
        Dim ans As Boolean = True

        If sComputer.ToLower.EndsWith(".png") Then
            Dim tmpOnPC As String = Path.GetTempFileName
            Try
                Dim cvtImage As Image = iPhonePNG.ImageFromFile(sComputer)
                iPhonePNG.Save(cvtImage, tmpOnPC)
            Catch
                ans = False
            End Try

            If ans Then
                If dPhone.EndsWith("/") Then
                    dPhone &= Path.GetFileName(sComputer)
                End If
                ans = copyToPhoneAt(tmpOnPC, dPhone, False, aBackupTime)
                My.Computer.FileSystem.DeleteFile(tmpOnPC)
            Else
                ans = copyToPhoneAt(sComputer, dPhone, False, aBackupTime)
            End If
        Else
            ans = copyToPhoneAt(sComputer, dPhone, False, aBackupTime)
        End If

        Return ans
    End Function

    Private Function copy1ToPhoneAt(ByVal sPC As String, ByVal dPhone As String) As Boolean
        Dim iPhoneFileInterface As iPhoneFile
        Dim sPath As String, sFile As String
        Dim fileTemp As FileStream
        'Dim sBuffer(8191) As Byte
        Dim sBuffer(32767) As Byte
        Dim iDataBytes As Integer

        If Config.bIgnoreThumbsFile AndAlso sPC.EndsWith("\Thumbs.db") Then
            Return True ' pretend copying was ok, but don't copy thumbs
        End If

        If Config.bIgnoreDSStoreFile AndAlso sPC.EndsWith("\.DS_Store") Then
            Return True ' pretend copying was ok, but don't copy .DS_Store files
        End If

        If Config.bIgnoreCacheFile AndAlso sPC.EndsWith(".cache") Then
            Return True ' pretend copying was ok, but don't copy *.cache files
        End If

        'see if the destination file exists
        If iPhoneInterface.Exists(dPhone) Then
            'it exists, back it up before overwriting
            sPath = dPhone.Substring(0, dPhone.LastIndexOf("/") + 1)
            sFile = dPhone.Substring(dPhone.LastIndexOf("/") + 2)
            BackupFileFromPhone(sPath, sFile)
        End If

        'open a connection to the file and write it
        iPhoneFileInterface = iPhoneFile.OpenWrite(iPhoneInterface, dPhone)
        'open a connection locally for read
        fileTemp = File.OpenRead(sPC)

        Dim buffSize As Integer = sBuffer.Length
        Dim cnt As Integer = CInt(fileTemp.Length / buffSize)
        If cnt > 100 Then
            buffSize *= 2
            cnt \= 2
            If cnt > 500 Then
                buffSize *= 2
                cnt \= 2
            End If
            ReDim sBuffer(buffSize - 1)
        End If

        StartStatus(cnt, fileTemp.Length) 'show our progress bar

        Dim curSize As Long = 0
        iDataBytes = fileTemp.Read(sBuffer, 0, sBuffer.Length)
        While iDataBytes > 0
            curSize += iDataBytes
            If IncrementStatus(curSize) Then Exit While 'increment our progressbar
            iPhoneFileInterface.Write(sBuffer, 0, iDataBytes)
            iDataBytes = fileTemp.Read(sBuffer, 0, sBuffer.Length)
        End While
        EndStatus() 'fill our progressbar
        iPhoneFileInterface.Close()
        fileTemp.Close()

        Return True
    End Function

    Friend Function CopyToPhone(ByVal sourceOnComputer As String, ByVal destinationOnPhone As String, ByVal fixPNG As Boolean) As Boolean
        Return copyToPhoneAt(sourceOnComputer, destinationOnPhone, fixPNG, DateTime.Now)
        'Me.Cursor = Cursors.Arrow
    End Function

    Private Function copyToPhoneAt(ByVal sourceOnComputer As String, ByVal destinationOnPhone As String, ByVal fixPNG As Boolean, ByVal aBackupTime As Date) As Boolean
        Dim bReturn As Boolean = False
        Dim sPath As String, sFile As String, dPath As String

        'get the details out
        sPath = Path.GetDirectoryName(sourceOnComputer)
        sFile = Path.GetFileName(sourceOnComputer)

        If destinationOnPhone.EndsWith("/") Then
            'they did not pass a specific file name, so add the source filename
            destinationOnPhone &= UnfixPhoneFilename(sFile)
        End If

        'update the status bar
        StatusNormal(My.Resources.String12 & sourceOnComputer & "'...")

        'are we copying a file?
        If File.Exists(sourceOnComputer) Then
            If fixPNG Then
                bReturn = copy1ToPhonePNGAt(sourceOnComputer, destinationOnPhone, aBackupTime)
            Else
                bReturn = copy1ToPhoneAt(sourceOnComputer, destinationOnPhone)
            End If
        ElseIf Directory.Exists(sourceOnComputer) Then
            ' Create matching directory on phone
            If Not iPhoneInterface.Exists(destinationOnPhone) Then
                iPhoneInterface.CreateDirectory(destinationOnPhone)
            End If

            dPath = destinationOnPhone & "/"

            ' copy all files over recursively
            For Each filepath As String In Directory.GetFiles(sourceOnComputer)
                'Application.DoEvents() ' make sure screen updates
                copyToPhoneAt(filepath, dPath, fixPNG, aBackupTime)
            Next

            ' copy all directories over recursively
            For Each dirpath As String In Directory.GetDirectories(sourceOnComputer)
                copyToPhoneAt(dirpath, dPath, fixPNG, aBackupTime)
            Next

            ' update TreeView
            ModuleMain.AddFoldersBeneath(objMain.trvFolders.SelectedNode)

            bReturn = True
        End If

        Return bReturn

    End Function

    Friend Function BackupFileFromPhone(ByVal sSourcePath As String, ByVal sSourceFile As String) As Integer
        'copies a file from the phone and backs it up in the appropriate directory
        'grab the file then save it with an extra extension
        Dim sDestinationPath As String, sDestinationFile As String
        Dim rc As Integer = -1

        StatusNormal(My.Resources.String13 & sSourceFile & "'.")
        'make sure it ends in a /
        If Not sSourcePath.EndsWith("/") Then sSourcePath &= "/"

        Try
            sDestinationFile = FixPhoneFilename(sSourceFile)
            sDestinationPath = GetBackupPath(False) & sSourcePath.Replace("/", "\")

            'Create the directory if it does not already exist
            If Not Directory.Exists(sDestinationPath) Then
                Directory.CreateDirectory(sDestinationPath)
            Else
                ' make sure there isn't a file conflict - create a new backup dir if necessary
                If File.Exists(sDestinationPath & sDestinationFile) Then
                    'SetBackupPath(aTime)
                    sDestinationPath = GetBackupPath(False) & sSourcePath.Replace("/", "\")
                    Directory.CreateDirectory(sDestinationPath)
                End If
            End If

            'copy file into the backup directory
            Dim len As Long = ModuleMain.CopyFromPhone(sSourcePath & sSourceFile, sDestinationPath & sDestinationFile)
            If ObjDb IsNot Nothing Then
                If len > -1 Then
                    ObjDb.AddFilenameToDB(Now, mvarBackupSubPath, sSourcePath & sSourceFile, len)
                ElseIf len = -1 Then    'error
                    ObjDb.AddFilenameToDB(Now, "Error", sSourcePath & sSourceFile, len)
                Else
                    'NOP Skip copy (escaped)
                End If
            End If
            rc = 0
            'StatusNormal("Backed up as '" & sDestinationFile & "'.")

        Catch ex As DirectoryNotFoundException
            StatusWarning(ex.Message)
            Dim dialog As New BackupDirDialog
            dialog.Show(objMain)
            Return -1

        Catch ex As Exception
            StatusWarning(ex.Message)
            ResetiPhone()
            Return -1

        End Try

        Return rc

    End Function

    'Private Sub backupFileFromPhone(ByVal sSourcePath As String, ByVal sSourceFile As String)
    '    backupFileFromPhoneAt(sSourcePath, sSourceFile)
    'End Sub

    Friend Function BackupDirectory(ByVal sPath As String) As Integer
        Dim rc As Integer

        rc = BackupDirectory(sPath, 0)

        'redraw file list
        objMain.LoadFiles()

        Return rc

    End Function

    Private Function backupDirectory(ByVal sPath As String, ByVal depth As Integer) As Integer
        Try
            Dim rc As Integer = 0
            Dim tmp As iPhone.strDir() = iPhoneInterface.GetFiles(sPath)
            Dim canceled As Boolean = False

            StartStatus(tmp.Length, 0)
            For Each sFile As iPhone.strDir In tmp
                If BackupFileFromPhone(sPath, sFile.Dir) < 0 Then
                    'ResetiPhone()
                    'Exit For
                    ProgressEscapeFlg = False
                End If
                If IncrementStatus(0) Then
                    canceled = True
                End If
                Exit For
            Next
            EndStatus()

            Dim tmp2 As iPhone.strDir() = iPhoneInterface.GetDirectories(sPath)
            StartStatus(tmp.Length, 0)
            For Each sDir As iPhone.strDir In tmp2
                If sDir.IsSLink = False Then
                    rc = backupDirectory(sPath & "/" & sDir.Dir, depth + 1)
                    If IncrementStatus(0) AndAlso depth = 0 Then Exit For
                    If rc <> 0 Then Exit For
                End If
            Next
            EndStatus()

            If canceled Then
                Return -2
            Else
                Return rc
            End If

        Catch ex As Exception
            StatusWarning(ex.Message & "[" & sPath & "]")
            Return -1

        End Try
    End Function

    'Private Sub BackupDirectory(ByVal sPath As String)
    '    BackupDirectoryAt(sPath)
    'End Sub

    Friend Function PhoneGetDirectoryName(ByVal phonePath As String) As String
        'Return Microsoft.VisualBasic.Left(phonePath, InStrRev(phonePath, "/") - 1)
        Return phonePath.Substring(0, phonePath.LastIndexOf("/"))
    End Function

    ' just use Path.GetFileName instead...
    '    Private Function PhoneGetFileName(ByVal phonePath As String) As String
    '        Return Mid(phonePath, InStrRev(phonePath, "/") + 1)
    '    End Function
    Friend Function DelFromPhone(ByVal sourceOnPhone As String) As Boolean
        Dim sPath As String, sFile As String
        Dim bReturn As Boolean = False

        'make sure the source file exists
        If iPhoneInterface.Exists(sourceOnPhone) Then
            sPath = ModuleMain.PhoneGetDirectoryName(sourceOnPhone)
            sFile = Path.GetFileName(sourceOnPhone)
            ModuleMain.BackupFileFromPhone(sPath, sFile)

            iPhoneInterface.DeleteFile(sourceOnPhone)

            bReturn = True
        End If

        Return bReturn

    End Function

    Friend Sub needDir(ByVal aDir As String)
        If Not Directory.Exists(aDir) Then
            Directory.CreateDirectory(aDir)
        End If
    End Sub

    Friend Sub doSaveFolderIn(ByVal sPath As String, ByVal dPath As String)
        needDir(dPath)
        dPath = dPath & "\"

        ' save the files
        Dim phFiles() As iPhone.strDir = iPhoneInterface.GetFiles(sPath)
        sPath = sPath & "/"
        For Each phF As iPhone.strDir In phFiles
            CopyFromPhone(sPath & phF.Dir, dPath & FixPhoneFilename(Path.GetFileName(phF.Dir)))
        Next

        Dim phDirs() As iPhone.strDir = iPhoneInterface.GetDirectories(sPath)
        For Each phD As iPhone.strDir In phDirs
            doSaveFolderIn(sPath & phD.dir, dPath & phD.dir)
        Next
    End Sub

    Friend Sub SaveCustomizeToFolder(ByVal frmOptions As frmCustomizeOptions, ByVal destPath As String)
        Dim sb As String = "/System/Library/CoreServices/SpringBoard.app/"
        With frmOptions
            Dim themeName As String = "\" & .txtThemeName.Text
            Dim catName As String = "\" & .txtCategory.Text
            needDir(destPath)
            destPath = destPath & "\"
            If .chkDock.Checked Then
                Dim destDock As String = destPath & "DockSwap" & catName
                needDir(destDock)
                CopyFromPhonePNG(sb & "SBDockBG2.png", destDock & themeName & ".png")
            End If

            destPath = destPath & "Customize"
            needDir(destPath)
            destPath = destPath & "\"

            If .chkCarrier.Checked Then
                Dim destCarrier As String = destPath & "CarrierImages" & catName
                needDir(destCarrier)
                Dim curCarrier As String = "_CARRIER_" & .cbCarriers.SelectedItem.ToString & ".png"

                CopyFromPhonePNG(sb & "FSO" & curCarrier, destCarrier & themeName & ".png")
                CopyFromPhonePNG(sb & "Default" & curCarrier, destCarrier & themeName & "-1.png")
            End If

            Dim sTypes() As String = {"FSO_", "Default_"}

            If .chkBars.Checked Then
                Dim destBars As String = destPath & "BarsImages" & catName
                needDir(destBars)
                destBars = destBars & themeName

                ' Default_[0-5]_Bars.png -> ThemeName.png - ThemeName-4.png
                ' FSO_[0-5]_Bars.png -> themeName-5.png - themeName-11.png
                For j2 As Integer = 0 To 1
                    For j1 As Integer = 0 To 5
                        Dim destNum As String = ".png"
                        If j1 <> 0 OrElse j2 <> 0 Then
                            destNum = "-" & (j1 + 6 * j2).ToString() & destNum
                        End If
                        CopyFromPhonePNG(sb & sTypes(j2) & j1.ToString() & "_Bars.png", destBars & destNum)
                    Next
                Next
            End If

            If .chkWiFi.Checked Then
                Dim destBars As String = destPath & "WiFiImages" & catName
                needDir(destBars)
                destBars = destBars & themeName

                ' Default_[0-5]_Bars.png -> ThemeName.png - ThemeName-4.png
                ' FSO_[0-5]_Bars.png -> themeName-5.png - themeName-11.png
                For j2 As Integer = 0 To 1
                    For j1 As Integer = 0 To 3
                        Dim destNum As String = ".png"
                        If j1 <> 0 OrElse j2 <> 0 Then
                            destNum = "-" & (j1 + 6 * j2).ToString() & destNum
                        End If
                        CopyFromPhonePNG(sb & sTypes(j2) & j1.ToString() & "_AirPort.png", destBars & destNum)
                    Next
                Next
            End If

            If .chkBadge.Checked Then
                Dim dest As String = destPath & "BadgeImages" & catName
                needDir(dest)
                CopyFromPhonePNG(sb & "SBBadgeBG.png", dest & themeName & ".png")
            End If

            If .chkBattery.Checked Then
                Dim dest As String = destPath & "BatteryImages" & catName
                needDir(dest)
                ' 17 is used as default
                CopyFromPhonePNG(sb & "BatteryBG_17.png", dest & themeName & ".png")

                For j1 As Integer = 1 To 16
                    CopyFromPhonePNG(sb & "BatteryBG_" & j1.ToString() & ".png", dest & themeName & "-" & j1.ToString() & ".png")
                Next
            End If

            If .chkSound.Checked Then
                Dim dest As String = destPath & "SoundImages" & catName
                needDir(dest)
                CopyFromPhonePNG(sb & "ring.png", dest & themeName & ".png")
                CopyFromPhonePNG(sb & "mute.png", dest & themeName & "-1.png")
                CopyFromPhonePNG(sb & "silent.png", dest & themeName & "-2.png")
                CopyFromPhonePNG(sb & "speaker.png", dest & themeName & "-3.png")
            End If

            If .chkBalloons.Checked Then
                Dim dest As String = destPath & "Chat1Images" & catName
                needDir(dest)
                CopyFromPhonePNG("/Applications/MobileSMS.app/Balloon_1.png", dest & themeName & ".png")

                dest = destPath & "Chat2Images" & catName
                needDir(dest)
                CopyFromPhonePNG("/Applications/MobileSMS.app/Balloon_2.png", dest & themeName & ".png")
            End If
            If .chkKeypad.Checked Then
                Dim dest As String = destPath & "DialerImages" & catName
                needDir(dest)
                CopyFromPhonePNG("/Applications/MobilePhone.app/BarDialer_Sel.png", dest & themeName & ".png")
            End If

            If .chkMainSlider.Checked Then
                Dim dest As String = destPath & "MainSliderImages" & catName
                needDir(dest)
                CopyFromPhonePNG("/System/Library/Frameworks/TelephonyUI.Framework/bottombarknobgrey.png", dest & themeName & ".png")
            End If
            If .chkPowerSlider.Checked Then
                Dim dest As String = destPath & "PowerSliderImages" & catName
                needDir(dest)
                CopyFromPhonePNG("/System/Library/Frameworks/TelephonyUI.Framework/bottombarknobred.png", dest & themeName & ".png")
            End If
            If .chkCallSlider.Checked Then
                Dim dest As String = destPath & "CallSliderImages" & catName
                needDir(dest)
                CopyFromPhonePNG("/System/Library/Frameworks/TelephonyUI.Framework/bottombarknobgreen.png", dest & themeName & ".png")
            End If
            If .chkHiMask.Checked Then
                Dim dest As String = destPath & "MaskSliderImages" & catName
                needDir(dest)
                CopyFromPhonePNG("/System/Library/Frameworks/TelephonyUI.Framework/bottombarlocktextmask.png", dest & themeName & ".png")
            End If

            If .cbSounds.CheckedItems.Count > 0 Then
                Dim dest As String = destPath & "AudioFiles" & catName
                needDir(dest)

                Dim sndNameArray() As String = {"Unlock", "Lock", "Received", "Sent", "Voicemail", "Alarm", _
                    "BeepBeep", "LowPower", "Mail", "NewMail", "Photo", "SMSReceived"}
                Dim sndArray() As String = {"unlock", "lock", "ReceivedMessage", "SentMessage", "Voicemail", "alarm", _
                    "beep-beep", "low_power", "mail-sent", "New-mail", "photoShutter", "sms-received"}

                For Each cb As String In .cbSounds.CheckedItems
                    Dim j1 As Integer = Array.IndexOf(sndNameArray, cb.Substring(0, cb.Length - 6))
                    CopyFromPhonePNG("/System/Library/Audio/UISounds/" & sndArray(j1) & ".caf", dest & themeName & "_" & sndNameArray(j1) & ".aif")
                Next
            End If
        End With
    End Sub


    Private Function fileCompare(ByVal fileName1 As String, ByVal fileName2 As String) As Boolean
        ' This method accepts two strings that represent two files to compare.
        Dim file1byte As Integer, file2byte As Integer
        Dim fs1 As FileStream, fs2 As FileStream

        ' Determine if the same file was referenced two times.
        If (fileName1 = fileName2) Then
            Return True
        End If

        ' Open the two files.
        fs1 = New FileStream(fileName1, FileMode.Open)
        fs2 = New FileStream(fileName2, FileMode.Open)

        ' Check the file sizes. If they are not the same, the files
        ' are not equal.
        If (fs1.Length <> fs2.Length) Then
            ' Close the file
            fs1.Close()
            fs2.Close()

            Return False
        End If

        ' Read and compare a byte from each file until either a
        ' non-matching set of bytes is found or until the end of the
        ' files is reached.
        Do
            ' Read one byte from each file.
            file1byte = fs1.ReadByte()
            file2byte = fs2.ReadByte()
        Loop While (file1byte = file2byte) AndAlso (file1byte <> -1)

        ' Close the files.
        fs1.Close()
        fs2.Close()

        ' Return the success of the comparison. "file1byte" is
        ' equal to "file2byte" at this point only if the files are 
        ' the same.
        Return (file1byte = file2byte)
    End Function

    Friend Function FixPhoneFilename(ByVal aName As String) As String
        Dim ans As String = aName
        For Each c As Char In "%:/\*?<>|"""
            'ans = Replace(ans, c, "%" & Hex(Asc(c)))
            ans = ans.Replace(c, "%" & Hex(Asc(c)))
        Next

        Return ans
    End Function

    Private Function UnfixPhoneFilename(ByVal aName As String) As String
        Dim ans As String = aName
        For Each c As Char In ":/\*?<>|""%"
            ans = ans.Replace("%" & Hex(Asc(c)), c)
        Next

        Return ans
    End Function

    Friend Function GetTempFilename(ByVal sFile As String) As String
        'grab the extension
        Dim sTemp As String = sFile.Substring(sFile.LastIndexOf("/"))

        'so we skip over the files without extensions but inside folders with extensions
        If sTemp.IndexOf(".") > -1 Then
            sTemp = sFile.Substring(sFile.LastIndexOf("."))
        Else
            sTemp = ".temp"
        End If

        sTemp = FixPhoneFilename(sTemp)

        Return FILE_TEMPORARY_VIEWER & sTemp
    End Function

    Friend Sub ResetiPhone()
        Try
            objMain.iPhoneDisconnect()
            Application.DoEvents()
            iPhoneInterface = New iPhone
            objMain.iPhoneConnect(True)
        Catch ex As Exception
        Finally
            'EndStatus()
        End Try
    End Sub

    Private mvarBackupSubPath As String = ""

    Friend Sub setBackupPath(ByVal aTime As Date)
        mvarBackupSubPath = "BACKUPS" & Format(aTime, ".yyyyMMdd.HHmmss")
    End Sub

    Friend Function GetBackupPath(ByVal root As Boolean) As String
        Dim dir As String
        If root Then
            dir = My.Settings.BackupPath & "\" & BACKUP_DIRECTORY
        Else
            dir = My.Settings.BackupPath & "\" & BACKUP_DIRECTORY & mvarBackupSubPath
        End If

        If dir.EndsWith("\") Then
            dir = dir.Substring(0, dir.Length - 1)
        End If

        Return dir

    End Function

    Friend Sub AddFoldersBeneath(ByVal aNode As TreeNode)

        aNode.Nodes.Clear()
        aNode.Nodes.Add(New TreeNode("dummy"))
        aNode.Tag = False
        aNode.Checked = False

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <param name="selectedNode"></param>
    ''' <param name="iDepth"></param>
    ''' <remarks></remarks>
    Friend Sub AddFolders(ByVal selectedNode As TreeNode, ByVal iDepth As Integer)
        'This function is recursive to add one level of folders to the tree view
        ' you give it one folder and will drill down and add one level of folders
        Dim sFolders() As iPhone.strDir
        Dim newNode As TreeNode
        Dim sbpath As String
        Dim bSkip As Boolean = False

        Try
            Dim sPath As String = ModuleMain.NodeiPhonePath(selectedNode)
            If sPath = "/" Then ' handle root special case
                sPath = ""
            End If

            'get the data from the phone
            sFolders = iPhoneInterface.GetDirectories(sPath)

            selectedNode.Nodes.Clear() ' remove any existing nodes

            If sFolders.Length > 0 Then
                Try
                    StartStatus(sFolders.Length, 0)

                    For Each strFolder As iPhone.strDir In sFolders
                        sbpath = sPath & "/" & strFolder.Dir
                        'create the new node
                        newNode = New TreeNode(strFolder.Dir)
                        newNode.Name = sbpath
                        newNode.ContextMenuStrip = objMain.menuRightClickFolders
                        If strFolder.IsSLink Then
                            newNode.ForeColor = Color.Blue
                        End If

                        If strFolder.IsDir Then
                            selectedNode.Nodes.Add(newNode)
                        End If

                        'now make the recursive call on this folder
                        If iDepth = -2 Then
                            bSkip = True
                        ElseIf iDepth < 1 Then ' only load first tree level beneath
                            'ModuleMain.AddFolders(sbpath, newNode, iDepth + 1)
                            ModuleMain.Add1stFolder(sbpath, newNode)
                        Else
                            'bSkip = True
                            'Exit For        '// <==
                        End If

                        If IncrementStatus(0) Then Exit For
                    Next

                Finally
                    EndStatus()
                End Try
            End If

            If bSkip Then
                selectedNode.Tag = False
            Else
                selectedNode.Tag = True
            End If
            Application.DoEvents()

        Catch ex As Exception
            StatusWarning(My.Resources.String35)

        End Try

    End Sub

    Friend Sub Add1stFolder(ByVal sPath As String, ByVal selectedNode As TreeNode)
        'This function is recursive to add one level of folders to the tree view
        ' you give it one folder and will drill down and add one level of folders
        Dim sFolder As String
        Dim newNode As TreeNode
        Dim sbpath As String

        If sPath = "/" Then ' handle root special case
            sPath = ""
        End If

        Try
            'get the data from the phone
            sFolder = iPhoneInterface.Get1stDirectory(sPath)

            selectedNode.Nodes.Clear() ' remove any existing nodes

            If sFolder <> "" Then
                sbpath = sPath & "/" & sFolder
                'create the new node
                newNode = New TreeNode(sFolder)
                newNode.Name = sbpath
                'newNode.ContextMenuStrip = objMain.menuRightClickFolders

                selectedNode.Nodes.Add(newNode)
            End If

            selectedNode.Tag = False

        Catch ex As Exception
            'Ç±Ç±ÇÃÉGÉâÅ[Ç≈ê⁄ë±Ç™íÜífÇ≥ÇÍÇƒåpë±Ç≈Ç´Ç»Ç≠Ç»ÇÈÅB
            StatusWarning(My.Resources.String35)
        End Try

    End Sub

    Friend Function convertcd(ByVal str As String) As String
        'Dim unicodeBytes As Byte() = str

        'Return str.Normalize()
        Dim byteArray As Byte()
        'Code Page 932 = Shift_JISÇ‡Ç«Ç´
        'Code Page 65001 = UTF-8
        byteArray = Encoding.GetEncoding(932).GetBytes(str)
        'byteArray = Encoding.ASCII.GetBytes(str)

        ' Get different encodings.
        'Dim u7 As Encoding = Encoding.UTF7
        Dim u8 As Encoding = Encoding.UTF8
        'Dim u81 As Encoding = Encoding.GetEncoding(65001)
        'Dim u16LE As Encoding = Encoding.Unicode
        'Dim u16BE As Encoding = Encoding.BigEndianUnicode
        'Dim u32 As Encoding = Encoding.UTF32

        ' Encode the entire array, and print out the counts and the resulting bytes.
        'str = PrintCountsAndBytes(myChars, u7)
        'str = PrintCountsAndBytes(myChars, u8)
        'str = PrintCountsAndBytes(myChars, u16LE)
        'str = PrintCountsAndBytes(myChars, u16BE)
        'str = PrintCountsAndBytes(myChars, u32)

        ' Encode the array of chars.
        str = u8.GetString(byteArray)
        'Console.WriteLine(str)

        '' Create two different encodings.
        'Dim ascii As System.Text.Encoding = Encoding.GetEncoding(437)
        'Dim [unicode] As Encoding = Encoding.GetEncoding(932)

        '' Convert the string into a byte[].
        'Dim unicodeBytes As Byte() = [unicode].GetBytes(unicodeString)

        '' Perform the conversion from one encoding to the other.
        'Dim asciiBytes As Byte() = Encoding.Convert([unicode], ascii, unicodeBytes)

        '' Convert the new byte[] into a char[] and then into a string.
        '' This is a slightly different approach to converting to illustrate
        '' the use of GetCharCount/GetChars.
        'Dim asciiChars(ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)) As Char
        'ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0)
        'Dim asciiString As New String(asciiChars)

        '' Display the strings created before and after the conversion.
        'Console.WriteLine("Original string: {0}", unicodeString)
        'Console.WriteLine("Ascii converted string: {0}", asciiString)

        Return str  'asciiString
    End Function

    Friend Function convertcd(ByVal bstr As Byte()) As String
        ' Get different encodings.
        Dim u8 As Encoding = Encoding.UTF8
        ' Encode the array of chars.
        Dim str As String = u8.GetString(bstr)
        Dim p As Integer = str.IndexOf(Chr(0))
        str = str.Substring(0, p)

        Return str  'asciiString
    End Function

    Public Function PrintCountsAndBytes(ByVal chars() As Char, ByVal enc As Encoding) As String

        ' Display the name of the encoding used.
        Console.Write("{0,-30} :", enc.ToString())

        ' Display the exact byte count.
        Dim iBC As Integer = enc.GetByteCount(chars)
        Console.Write(" {0,-3}", iBC)

        ' Display the maximum byte count.
        Dim iMBC As Integer = enc.GetMaxByteCount(chars.Length)
        Console.Write(" {0,-3} :", iMBC)

        ' Encode the array of chars.
        Dim bytes As Byte() = enc.GetBytes(chars)

        ' Display all the encoded bytes.
        PrintHexBytes(bytes)

        Return enc.GetString(bytes)

        'Return bytes.ToString

    End Function 'PrintCountsAndBytes

    Public Sub PrintHexBytes(ByVal bytes() As Byte)

        If bytes Is Nothing OrElse bytes.Length = 0 Then
            Console.WriteLine("<none>")
        Else
            Dim i As Integer
            For i = 0 To bytes.Length - 1
                Console.Write("{0:X2} ", bytes(i))
            Next i
            Console.WriteLine()
        End If

    End Sub 'PrintHexBytes 


    Friend Function fileSizeAsInteger(ByVal size As String) As Integer
        Dim rVal As Integer = 0

        Select Case True
            Case size.EndsWith("MB")
                rVal = CInt(size.Substring(0, size.Length - 3)) * 1024000
            Case size.EndsWith("KB")
                rVal = CInt(size.Substring(0, size.Length - 3)) * 1024
            Case Else
                rVal = CInt(size.Substring(0, size.Length - 2))
        End Select

        Return rVal

    End Function

    Friend ObjDb As DbManager

    Friend Function GetDbInstance(ByVal sql As String, ByVal key As String) As DbManager
        Dim rc As Integer = 0
        Dim oDb As New DbManager("Microsoft.Jet.OLEDB.4.0")
        Dim dbSource As String = My.Settings.DbPath

        If dbSource = "" Then
            dbSource = ModuleMain.GetBackupPath(True)
            My.Settings.DbPath = dbSource
        End If
        oDb.Source = dbSource

        oDb.SelectOLEDB(sql, key)
        'oDb.Sort = "BackupFolder, FileName"    ', tstp desc"

        Return oDb

    End Function

    Friend Function GetBackupList() As DbManager
        Dim message As String = ""
        Dim sql As String = "SELECT * FROM list.txt ORDER BY FileName, tstp desc"
        Dim sortKey As String = "FileName,tstp"
        Dim oDb As DbManager = Nothing

        Try
            oDb = ModuleMain.GetDbInstance(sql, sortKey)
            If oDb Is Nothing Then
                message = String.Format(My.Resources.String43, My.Settings.DbPath)  'GetBackupPath(True))
                If MsgBox(message, MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim dialog As New BackupDirDialog
                    dialog.ShowDialog(objMain)
                    dialog.Dispose()
                    oDb = ModuleMain.GetDbInstance(sql, sortKey)
                End If
            Else
                oDb.DbFileName = "list.txt"
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        Return oDb

    End Function

End Module
