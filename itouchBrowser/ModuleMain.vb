Option Explicit On
Option Strict On

Imports System.IO
Imports System.Drawing.Imaging
Imports System.Text
Imports Manzana
Imports SCW_iPhonePNG

Module ModuleMain

    Friend Const STRING_ROOT As String = "[root]"
    Friend Const MAX_PROG_DEPTH As Integer = 1
    Friend Const BACKUP_DIRECTORY As String = "touchBrowser"
    Friend FILE_TEMPORARY_VIEWER As String = "iPhone.temp"

    Friend objMain As frmMain
    Friend iPhoneInterface As iPhone
    Friend bShowPreview As Boolean, bIgnoreThumbsFile As Boolean, bIgnoreDSStoreFile As Boolean
    Friend bConvertToiPhonePNG As Boolean, bConvertToPNG As Boolean
    Friend ProgressDepth As Integer
    Friend ProgressBars(MAX_PROG_DEPTH) As ToolStripProgressBar
    Friend ProgressValue(MAX_PROG_DEPTH) As Integer
    Friend escapeFlg As Boolean = False
    Friend bNowConnected As Boolean = False
    Friend bConnectionChanged As Boolean = False

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

    Friend Sub StatusNormal(ByVal msg As String)
        objMain.tlbStatusLabel.Image = Nothing
        objMain.tlbStatusLabel.Text = msg
    End Sub

    Friend Sub StatusWarning(ByVal msg As String)
        objMain.tlbStatusLabel.Image = My.Resources.warning
        objMain.tlbStatusLabel.Text = msg
        MessageBeep(MessageBeepType.Warning)
    End Sub

    Friend Function StartStatus(ByVal iMax As Integer) As Integer
        ProgressDepth += 1
        If ProgressDepth <= MAX_PROG_DEPTH Then
            If ProgressDepth = 0 Then ' first bar - turn all on
                For j1 As Integer = MAX_PROG_DEPTH To 0 Step -1
                    With ProgressBars(j1)
                        .Visible = True
                        .Value = 0
                    End With
                Next
                objMain.BtnCancel.Visible = True
                escapeFlg = False
            End If
            ProgressBars(ProgressDepth).Maximum = iMax + 1
            ProgressValue(ProgressDepth) = 0
            objMain.Timer1.Enabled = True
        End If
        Return ProgressDepth
    End Function

    Friend Sub EndStatus()
        If ProgressDepth >= 0 Then
            If ProgressDepth <= MAX_PROG_DEPTH Then
                If ProgressDepth = 0 Then
                    objMain.Timer1.Enabled = False
                End If
                ProgressBars(ProgressDepth).Value = 0

                If ProgressDepth = 0 Then ' first bar - turn all off
                    For j1 As Integer = 0 To MAX_PROG_DEPTH
                        ProgressBars(j1).Visible = False
                    Next
                    objMain.BtnCancel.Visible = False
                End If
            End If
            ProgressDepth -= 1
        End If
        objMain.tlbStatusStrip.Refresh()
    End Sub

    Friend Function IncrementStatus() As Boolean
        If ProgressDepth <= MAX_PROG_DEPTH Then
            Try
                ProgressValue(ProgressDepth) += 1
                Application.DoEvents()
            Catch
                escapeFlg = True
            End Try
        End If
        Return escapeFlg
    End Function

    Friend Function NodeiPhonePath(ByVal aNode As TreeNode) As String
        Dim sTemp As String = aNode.FullPath
        If sTemp <> STRING_ROOT Then
            sTemp = sTemp.Substring(STRING_ROOT.Length).Replace("\", "/")
        Else
            sTemp = "/"
        End If

        Return sTemp
    End Function

    Friend Function CopyFromPhone(ByVal sourceOnPhone As String, ByVal destinationOnComputer As String) As Integer
        Dim sBuffer(8191) As Byte
        Dim iDataBytes As Integer
        Dim iPhoneFileInterface As iPhoneFile
        Dim fileTemp As FileStream
        Dim bReturn As Integer = -1

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
            Dim depth As Integer = StartStatus(CInt(iPhoneInterface.FileSize(sourceOnPhone) / sBuffer.Length)) 'show our progress bar

            'open a connection to the file and read it
            Try
                iPhoneInterface.CurrentDirectory = "/"
                iPhoneFileInterface = iPhoneFile.OpenRead(iPhoneInterface, sourceOnPhone)

            Catch ex As Exception
                ResetiPhone()
                Return bReturn
            End Try

            Try
                If depth = 0 Then objMain.lstFiles.Enabled = False
                fileTemp = File.OpenWrite(destinationOnComputer)
                iDataBytes = iPhoneFileInterface.Read(sBuffer, 0, sBuffer.Length)
                While iDataBytes > 0
                    fileTemp.Write(sBuffer, 0, iDataBytes)
                    iDataBytes = iPhoneFileInterface.Read(sBuffer, 0, sBuffer.Length)
                    If IncrementStatus() Then Exit While 'increment our progressbar
                End While
                EndStatus() 'fill our progressbar

                iPhoneFileInterface.Close()
                iPhoneFileInterface.Dispose()
                fileTemp.Close()

                bReturn = 0

            Catch exio As IOException
                StatusWarning(exio.Message)
            Catch ex As Exception
                StatusWarning(ex.Message)
            Finally
                If depth = 0 Then
                    objMain.lstFiles.Enabled = True
                    objMain.lstFiles.Focus()
                End If
            End Try
        End If

        Return bReturn
    End Function

    Friend Function CopyFromPhoneMakePNG(ByVal sPhone As String, ByVal dComputer As String) As Integer
        Dim tmpOnPC As String = GetTempFilename(sPhone)
        Dim ans As Integer = CopyFromPhone(sPhone, tmpOnPC)
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

    Friend Function CopyFromPhonePNG(ByVal sPhone As String, ByVal dComputer As String) As Integer
        If bConvertToPNG AndAlso sPhone.ToLower.EndsWith(".png") Then
            Dim tmpOnPC As String = GetTempFilename(sPhone)
            Dim ans As Integer = CopyFromPhone(sPhone, tmpOnPC)
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
        Dim sBuffer(8191) As Byte, iDataBytes As Integer

        If bIgnoreThumbsFile AndAlso Path.GetFileName(sPC) = "Thumbs.db" Then
            Return True ' pretend copying was ok, but don't copy thumbs
        End If

        If bIgnoreDSStoreFile AndAlso Path.GetFileName(sPC) = ".DS_Store" Then
            Return True ' pretend copying was ok, but don't copy .DS_Store files
        End If

        'see if the destination file exists
        If iPhoneInterface.Exists(dPhone) Then
            'it exists, back it up before overwriting
            'sPath = Microsoft.VisualBasic.Left(dPhone, InStrRev(dPhone, "/"))
            sPath = dPhone.Substring(0, dPhone.LastIndexOf("/") + 1)
            'sFile = Mid(dPhone, InStrRev(dPhone, "/") + 1)
            sFile = dPhone.Substring(dPhone.LastIndexOf("/") + 2)
            backupFileFromPhone(sPath, sFile)
        End If

        'open a connection to the file and write it
        iPhoneFileInterface = iPhoneFile.OpenWrite(iPhoneInterface, dPhone)
        'open a connection locally for read
        fileTemp = File.OpenRead(sPC)
        startStatus(CInt(fileTemp.Length / sBuffer.Length)) 'show our progress bar

        iDataBytes = fileTemp.Read(sBuffer, 0, sBuffer.Length)
        While iDataBytes > 0
            If incrementStatus() Then Exit While 'increment our progressbar
            iPhoneFileInterface.Write(sBuffer, 0, iDataBytes)
            iDataBytes = fileTemp.Read(sBuffer, 0, sBuffer.Length)
        End While
        endStatus() 'fill our progressbar
        iPhoneFileInterface.Close()
        fileTemp.Close()

        Return True
    End Function

    Friend Function CopyToPhone(ByVal sourceOnComputer As String, ByVal destinationOnPhone As String, ByVal fixPNG As Boolean) As Boolean
        Dim ans As Boolean = copyToPhoneAt(sourceOnComputer, destinationOnPhone, fixPNG, DateTime.Now)
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
            objMain.addFoldersBeneath()

            bReturn = True
        End If

        copyToPhoneAt = bReturn
    End Function

    Friend Function BackupFileFromPhone(ByVal sSourcePath As String, ByVal sSourceFile As String) As Integer
        'copies a file from the phone and backs it up in the appropriate directory
        'grab the file then save it with an extra extension
        Dim sDestinationPath As String, sDestinationFile As String

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
            Dim rc As Integer = CopyFromPhone(sSourcePath & sSourceFile, sDestinationPath & sDestinationFile)

            StatusNormal("Backed up as '" & sDestinationFile & "'.")

            Return rc

        Catch ex As Exception
            StatusWarning(ex.Message)
            ResetiPhone()
            Return -1

        End Try

    End Function

    'Private Sub backupFileFromPhone(ByVal sSourcePath As String, ByVal sSourceFile As String)
    '    backupFileFromPhoneAt(sSourcePath, sSourceFile)
    'End Sub

    Friend Sub BackupDirectory(ByVal sPath As String)
        StartStatus(iPhoneInterface.GetDirectories(sPath).Length)
        BackupDirectory(sPath, 0)
        EndStatus()
    End Sub

    Private Function backupDirectory(ByVal sPath As String, ByVal depth As Integer) As Integer
        Try
            Dim rc As Integer = 0
            Dim tmp As String() = iPhoneInterface.GetFiles(sPath)

            For Each sFile As String In tmp
                If BackupFileFromPhone(sPath, sFile) <> 0 Then
                    ResetiPhone()
                    Exit For
                End If
            Next
            tmp = iPhoneInterface.GetDirectories(sPath)
            For Each sDir As String In tmp
                rc = backupDirectory(sPath & "/" & sDir, depth + 1)
                If depth = 0 AndAlso IncrementStatus() Then Exit For
                If rc <> 0 Then Exit For
            Next

            Return 0

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
            sPath = PhoneGetDirectoryName(sourceOnPhone)
            sFile = Path.GetFileName(sourceOnPhone)
            BackupFileFromPhone(sPath, sFile)

            iPhoneInterface.DeleteFile(sourceOnPhone)

            bReturn = True
        End If

        DelFromPhone = bReturn
    End Function

    Private Sub needDir(ByVal aDir As String)
        If Not Directory.Exists(aDir) Then
            Directory.CreateDirectory(aDir)
        End If
    End Sub

    Friend Sub doSaveFolderIn(ByVal sPath As String, ByVal dPath As String)
        needDir(dPath)
        dPath = dPath & "\"

        ' save the files
        Dim phFiles() As String = iPhoneInterface.GetFiles(sPath)
        sPath = sPath & "/"
        For Each phF As String In phFiles
            CopyFromPhone(sPath & phF, dPath & FixPhoneFilename(Path.GetFileName(phF)))
        Next

        Dim phDirs() As String = iPhoneInterface.GetDirectories(sPath)
        For Each phD As String In phDirs
            doSaveFolderIn(sPath & phD, dPath & phD)
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
        'Dim sTemp As String = Mid(sFile, InStrRev(sFile, "/") + 1)
        Dim sTemp As String = sFile.Substring(sFile.LastIndexOf("/"))
        'so we skip over the files without extensions but inside folders with extensions
        If sTemp.IndexOf(".") > -1 Then
            'sTemp = Mid(sFile, InStrRev(sFile, "."))
            sTemp = sFile.Substring(sFile.LastIndexOf("."))
        Else
            sTemp = ".temp"
        End If

        sTemp = FixPhoneFilename(sTemp)

        Return FILE_TEMPORARY_VIEWER & sTemp
    End Function

    Friend Sub ResetiPhone()
        'iPhoneInterface = New iPhone
        'bNowConnected = False
        'objMain.iPhoneConnected_Details()
        iPhoneInterface.CurrentDirectory = "/"
        'iPhoneInterface.Is
        EndStatus()
    End Sub

    Private backupSubPath As String = ""

    Friend Sub setBackupPath(ByVal aTime As Date)
        backupSubPath = BACKUP_DIRECTORY & "\BACKUPS" & Format(aTime, ".yyyyMMdd.HHmmss")
    End Sub

    Friend Function GetBackupPath(ByVal show As Boolean) As String
        If show Then
            Return Path.Combine(My.Settings.BackupPath, BACKUP_DIRECTORY)
        Else
            Return Path.Combine(My.Settings.BackupPath, backupSubPath)
        End If
    End Function

    Friend Function convertcd(ByVal str As String) As String
        Dim unicodeString As String = str

        Return str

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

        'Return asciiString
    End Function

End Module
