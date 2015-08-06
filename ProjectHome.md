itouchBrowser - Windows based GUI for manipulating files on the iPhone/iPod touch.

This changes iPhoneBrowser (http://code.google.com/p/iphonebrowser/) into Japanese. This can be used in English mode also except Japanese environment.
The feature is as follows.

# Feature #
  * レスポンスの向上       - Improvement of response
  * 表示機能の強化         - Enhancement of a display function
  * バックアップファイルの一覧確認 - The list check of backup files
  * 重複ファイルの削除可能     - Deletion of the duplication backup files
  * 日本語対応             - Compatible with Japanese
  * 異常終了を削減         - An abnormal end is cut down
  * USB & SSH接続対応      - USB and SSH connection

# Supported format #
  * Image:   png, jpg, jpeg, gif
  * Text:    string, conf, txt, script, pl, h, awk, tcl, css, m4, c, sh, js, py, el
  * Database: db, sqlite, sqlitedb, itdb, zip
  * Audio:   aiff, amr, aif, caf, wav
  * Music:   m4a, m4p, mp3, aac
  * Movie:   mp4, mov, 3gp, tga, m4v
  * Web:     htm, html, plist, thm, xml, pdf

Note: If you install to not Japanese environment, it will change to an English display automatically.

# Ver. 1.8.3.31 #
http://itouchbrowser.googlecode.com/files/screenshot_18331.JPG

# Ver. 1.8.0.18 #
http://itouchbrowser.googlecode.com/files/itouchBrowser18018.PNG

On English environment.
http://itouchbrowser.googlecode.com/files/itouchBrowser18018En.PNG


# Modification history #

**v1.92.36 12/30/2009** =sugi=
  * when the backup directory was not specified, the fault out of which the error of 'a table 0 is not found' comes was corrected
  * iTunes and an App tab can be updated by F5 key
  * when App was chosen, the problem from which the form of a mouse pointer does not return was corrected
  * holder deletion corrected the problem shich was not completed normally
  * the sucking function of artist data was corrected

**v1.92.35 11/23/2009** =sugi=
  * correspondence to F/W 3.0

**v1.91.34 9/13/2009** =sugi=
  * intention of correspondence in iTunes8.2

**v1.90.33 6/13/2009** =sugi=
  * Improved compatiblity with iTunes 8.2
  * change of a holder icon
  * improvement in the quality of a thumbnail display
  * all applications were displayed by selection of an App tab
> > (the application in a '/Applications' holder is a blue display)
  * when expansion and the standard of a preview screen were repeated in Jailbreak, the holder view corrected the trouble which become small
  * although it was not reflected unless it rebooted after completing a SSH setup, it corrected so that it might connect immediately

**v1.83.32 5/24/2009** =sugi=
  * possible in the SSH connectin using the private key and the public key
  * generation of the private key and public key of SSH and the function of automatic deployment were added
  * in order to also include a file attribute, the backup function of the holder using tar was added (it is automatic transmission to PC after compression)
  * the history reference fucntion was added to SSH command line (reference of the past is possible by the vertical arrow key)
  * also display a holder in a file view
  * the processing at the device connection was optimized
  * the icon at the time of holder selection was changed
  * wallpaper and the theme were added to the menu
  * the falt which did not display full screen icon in the English environment was corrected

**v1.83.31 4/29/2009** =sugi=
  * in the Jailbreak environment, SSH connection can be performed simultaneously with USB
  * the dialog box of file property was added
  * possible in change of a file attribute (access authority)
  * add a SSH command line function

**v1.82.30 4/17/2009** =sugi=
  * the test version summarized to one file
> > it is the version which should execute only by iTunes and .NET Framework 2.0
  * if the picture of web is dropped with a direct file list, it can take into iPhoen or iPod touch
  * the file list in a Zip file can be displayed
  * the contents of a bunary file can be displayed with the hex number
  * the problem which has not displayed a file list even if it chose the holder, after displaying a backup file in a list, when backup control is effective was corrected
  * product ID of AMDevice was distinguished

**v1.82.29 4/4/2009** =sugi=
**v1.82.28 4/3/2009** =sugi=
  * the test version for the problem which cannot display a file of iPhone

**v1.82.27 3/22/2009** =sugi=
  * the reference function of a file was added
  * the option menu was iconized on right side of a menu bar
  * the expansion button of a detailed pane was added also to right side of a menu bar
  * added the function in which a change history can be referred to from a menu
  * full screen display modes were added (upper right icon click)
  * the menu of SummerBoard and Customize is abolished (inheritance to 1.1.4)
  * change a compiler into VS2008
  * the poor display at the creation of a folder was corrected. bug fix
  * the fault which was not able to use the fucntion of "spacifying and saving a name" was corrected. bug fix

**v1.81.26 3/2/2009** =sugi=
  * the file display of python and emacs was enabled
  * the thumbnail display of an image file was enabled
  * the icon display was changed
  * the background color of a file list was changed
  * a holder display is accelerated further
  * correct that backup of a folder was not completed. bug fix

**v1.81.25 2/21/2009** =sugi=
  * it changed so that a Japnese file name with a voiced consonant mark could be dealt with
  * the function which carries out file deletion without backup was added
  * an App tab is added and it enabled to move to a holder from an application name
  * it indicated that it was not able to display Symbolic Link by FW 2.x
  * Symbolic Link is blue displayed
  * the number of files, the amount used, and the number of holders in a holder are displayed on property
  * a holder is expanded in a double click
  * since it become late by the Symbolic Link judging, holder operation was optimized agein

**v1.81.24 1/27/2009** =sugi=
  * the class of an album name was added to the bottom of an artist name with the iTunes tab
  * the file to which the album name is not set corrected the problem which was not displayed with an iTunes tab
  * it changed so that an artist name might be compared strictly
  * it changed so that the SQLDB contents might be displayed still in detail
  * by the animation file with words, it changed so that both an animation and words could be displayed
  * starting processing was changed a little
  * the width of a words display was restored next time starting

**v1.81.23 1/1/2009** =sugi=
  * the poor display of a Japanese holder name and a file name has been improved
> > (the voiced consonant mark has not corresponded)
  * the problem which a music name did not display to an iTunes list at backup management functional OFF is corrected
  * optimize reproduction of an animation
  * when URL is put into an address bar, the internet page will open
  * it corrects becoming an error, when two or more iPod are disconnect and connected
  * the title was changed into itouchBrowser in English mode
> > To an English environment. I'm sorry that you confuse this and iPhoneBrowser.
  * the starting sequence was changed and it accelerated
  * correct a fine portion

**v1.81.22 12/17/2008** =sugi=
  * the information embedded to the music is displayed under playing
  * display the art work under palying
  * it changed so that reproduction might be stopped at the time of Movie Export
  * the problem to which maximization of an animation was invalid corrected
  * the icon of the kind of file was changed
  * jailbreak menu is hidden when non-jailbreak iPod is connected
  * enable it to display the last.fm information during the performance of music.

**v1.81.21 11/30/2008** =sugi=
  * it will be displayed if the words embedded to the music under playing are found
  * accelerate the backup speed of a huge file
  * freezing under backup of a huge file has been improved
  * the trouble which movie playing does not stop even if a view changes was corrected
  * corrected the abnormal end under file sorting in iTunes mode
  * corrected that the 2nd progress bar display was not completed

**v1.81.20 11/09/2008** =sugi=
  * correct the trouble which has not displayed a file without an extension
  * corrent the trouble which has not displayed the file name of 100 or more characters
  * added the function which writes out a file by the music name
  * added the format conversion function of animation file
> > (it is a menu display by right click during a playing)
  * the information display of music and an animation was extended
  * optimized Manzana and accelerated (support to two byte code)
  * accelerate expansion of a holder
  * support to sucking of iPod nano data

**v1.81.19 11/01/2008** =sugi=
  * a Japanese, Chinese etc. files name can be displayed
  * acquire and display the iTunes information in iTunes TAB
  * accelerate the display of a singer, a music name, and an album name

**v1.80.18 10/13/2008** =sugi=
  * the problem which carried out the abnormal end by file deletion and holder deletion has improved
  * accelerated the transmission speed between PC and touch/iPhone
  * the transmission size at the file transder was displayed
  * display a backup file list at high speed
  * add the file deletion function by the right click of a backup file list

**v1.80.17 10/5/2008** =sugi=
  * the directory which records the managemant database of a backup file can be specified
  * the mode which does not manage backup file is added
  * add the flag which dose not backup a cache file
  * a music name list display is enabled in music file list
  * update Manzana to the latest version
  * It corrected that the English message was not able to be setup.
  * added handling for >2GB file sizes
  * Try /var/mobile first, then /var/root
  * another change to work with iTunes 8.x (iTunes 8.0.1 + touch 2G finishing an operation check)

**v1.71.16 8/24/2008** =sugi=
  * when the file of SQLite is chosen, display the data in a database
  * display a music or animation title at the playing file
  * reappear the last chosen holder
  * when the character which cannot be dealt with by Windows is included in a file name, the problem which cannot display it has been improved
  * screen expansion of an animation is enabled
  * when the file of symbolic link is in a backup holder, correct the problem for which backup processing is interrupted

**v1.70.15 8/10/2008** =sugi=
  * display the directory which has backed up on the file list
  * look through a duplication file
  * purge BACKUPS folders of duplicate files
> > (comparing the contents of a file, a different file does not delete)
  * a display of a support web page is enebaled from a help menu
> > (if you get a problem while in use, please add a situation to the ISSUES tab)

**v1.60.14 7/25/2008** =sugi=
  * when a backup directory does not exist, display the setting dialog box of a directory
  * extend the kind of file which can be displayed
  * the next file can be read, when playing an animation

**v1.60.13 7/7/2008** =sugi=
  * the text display also of an unknown file is enabled with a display button

**v1.60.12 7/5/2008** =sugi=
  * Extension dealing with two byte code (Japanese, etc.)
  * change of the preservation directory of backup file is enabled from a menu
  * Add the discontinuation function of a file transfer

**v1.60.10 6/28/2008** =sugi=
  * two byte code correspondence
  * processing is optimized and it accelerates
  * extend a display function
  * many abnormal ends were cut down

v1.60   2/19/2008 Pete Wilson
  * fixed Location menu to try both /var/root and /var/mobile
  * modified Theme creation to use home dir based on /var/mobile/Media existance
  * fixed Delete Folder to work when afc2 not setup
  * modified startup to detect connected iPhone better

v1.52   1/14/2008 Pete Wilson
  * fixed Camera Roll Goto Location menu option
  * moved temp preview files to Windows temp folder

v1.51   1/9/2008 Pete Wilson
  * fixed bug in JIT load of folder tree for folders with one child
  * added two level progress bars to better show operations
  * fixed bug in Goto Location not loading child folders
  * fixed bug to only ask create directory question if directory is not on iPhone

v1.50	1/7/2008 Pete Wilson
  * Confirm deletion option disables confirmation for folders without sub-folders as well as files
  * added option to ignore .DS\_Store files
  * fixed some file list synch bugs
  * moved backup folders to custom UserAppDataPath (Local Settings\Application Data\Cranium\iPhoneBrowser)
  * moved temp files to custom UserAppDataPath
  * now only creates one backup folder per run unless a filename conflict occurs
  * improved many display refresh issues - collapsing nodes should work correctly now
  * added options to rename files and folders
  * added conversion of illegal Windows filenames in both directions
  * added grouping to file list view
  * added better control over auto preview and limited auto preview to 100kb
  * improved event handling when right-clicking file
  * added user settable bookmarks
  * improved performance of file copies from/to iphone for large files
  * reduced tree icons to 16x16 to decrease tree space for deep hierarchies
  * improved progress bar update/display process for copying files
  * added F5 to refresh current tree node and children manually
  * improved search for iTunesMobileDevice.DLL to use US location if localized location doesn't work

v1.40	10/03/2007	Pete Wilson
  * Re-arranged locations and added new locations for Third-Party Applications and SummerBoard
  * File right-click menu handles multiple selections
  * Added option for delete confirmation
  * Added option to set preview background color (not remembered)
  * Handles deletion of multiple files and folders with contents - all backed up
  * Preview iPhone PNGs and convert from iPhone PNGs to stock
  * NOTE: conversion does not recompute CRCs or compute correct Zlib checksums
  * NOTE: conversion does not remove premultiplied alpha if present
  * Added command to save SpringBoard view as a SummerBoard theme folder
  * Added some more third party app folder locations
  * Added commands to Save or Backup Folders
  * Changed backup scheme to use BACKUPS.date.time to make restores easier
  * added option to ignore Thumbs.db files

v1.31	9/14/2007	Pete Wilson
  * Correct major bug when drag/drop multiple directories

v1.3	9/13/2007	Pete Wilson
  * Fixed Audio Preview of second file, Fixed minimize/resize of window
  * improved image preview to shrink if too large
  * improved TreeView/File Details to eliminate flashing
  * improved file preview to eliminate flashing
  * added .aif as Audio File, changed m4a to Music File
  * added Hourglass cursor when busy
  * improved event handling
  * added sorting to files view
  * improved context menu handling
  * replaced some alerts with status updates
  * added warning icon and beep to status warnings
  * added drag and drop of directories to the iPhone   **add eBooks and apps easily**

V1.2	8/19/2007	Kevin Hightower
-Added 'Go To Location' feature that automatically selects common locations
-Added preview of audio files using quicktime plugin
-Added creation and deletion of folders (empty ones only)
-Corrected and optimized UI for speed and clarity

V1.1	8/7/2007 	Kevin Hightower
  * Added some loggin during startup and extra support for older machines

V1.0 	8/5/2007 	Kevin Hightower
  * Initial release