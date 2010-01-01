// Software License Agreement (BSD License)
// 
// Copyright (c) 2007, Peter Dennis Bartok <PeterDennisBartok@gmail.com>
// All rights reserved.
// 
// Redistribution and use of this software in source and binary forms, with or without modification, are
// permitted provided that the following conditions are met:
// 
// * Redistributions of source code must retain the above
//   copyright notice, this list of conditions and the
//   following disclaimer.
// 
// * Redistributions in binary form must reproduce the above
//   copyright notice, this list of conditions and the
//   following disclaimer in the documentation and/or other
//   materials provided with the distribution.
// 
// * Neither the name of Peter Dennis Bartok nor the names of its
//   contributors may be used to endorse or promote products
//   derived from this software without specific prior
//   written permission of Yahoo! Inc.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
// ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace itouchBrowser.Manzana
{
    /// <summary>
    /// Exposes access to the Apple iPhone
    /// </summary>
    public class iPhone
    {
        #region Locals
        private DeviceNotificationCallback dnc;
        private DeviceRestoreNotificationCallback drn1;
        private DeviceRestoreNotificationCallback drn2;
        private DeviceRestoreNotificationCallback drn3;
        private DeviceRestoreNotificationCallback drn4;

        unsafe internal void* iPhoneHandle;
        unsafe internal void* hAFC;
        unsafe internal void* hService;
        private bool connected;
        private string current_directory;
        private bool wasAFC2 = false;
        #endregion	// Locals

        #region publics
        /// <summary>
        /// Directory structure
        /// </summary>
        public struct strDir
        {
            /// <summary>
            /// directory name
            /// </summary>
            public string Dir;
            /// <summary>
            /// is directory
            /// </summary>
            public bool IsDir;
            /// <summary>
            /// is symbolic link
            /// </summary>
            public bool IsSLink;
        }
        #endregion  //publics

        #region Constructors
        /// <summary>
        /// Initializes a new iPhone object.
        /// </summary>
        unsafe private void doConstruction()
        {
            dnc = new DeviceNotificationCallback(NotifyCallback);
            drn1 = new DeviceRestoreNotificationCallback(DfuConnectCallback);
            drn2 = new DeviceRestoreNotificationCallback(RecoveryConnectCallback);
            drn3 = new DeviceRestoreNotificationCallback(DfuDisconnectCallback);
            drn4 = new DeviceRestoreNotificationCallback(RecoveryDisconnectCallback);

            void* notification;
            int ret = MobileDevice.AMDeviceNotificationSubscribe(dnc, 0, 0, 0, out notification);
            if (ret != 0)
            {
                throw new Exception("AMDeviceNotificationSubscribe failed with error " + ret);
            }

            ret = MobileDevice.AMRestoreRegisterForDeviceNotifications(drn1, drn2, drn3, drn4, 0, null);
            if (ret != 0)
            {
                throw new Exception("AMRestoreRegisterForDeviceNotifications failed with error " + ret);
            }
            current_directory = "/";
        }

        /// <summary>
        /// Creates a new iPhone object. If an iPhone is connected to the computer, a connection will automatically be opened.
        /// </summary>
        public iPhone()
        {
            doConstruction();
        }

        #endregion	// Constructors

        #region Properties
        /// <summary>
        /// Gets the current activation state of the phone
        /// </summary>
        unsafe public string ActivationState
        {
            get
            {
                return MobileDevice.AMDeviceCopyValue(iPhoneHandle, 0, "ActivationState");
            }
        }

        /// <summary>
        /// Returns true if an iPhone is connected to the computer
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return connected;
            }
        }

        /// <summary>
        /// Returns the Device information about the connected iPhone
        /// </summary>
        unsafe public void* Device
        {
            get
            {
                return iPhoneHandle;
            }
        }

        ///<summary>
        /// Returns the 40-character UUID of the device
        ///</summary>
        unsafe public string DeviceId
        {
            get
            {
                return MobileDevice.AMDeviceCopyValue(iPhoneHandle, 0, "UniqueDeviceID");
            }
        }

        ///<summary>
        /// Returns the type of the device, should be either 'iPhone' or 'iPod'.
        ///</summary>
        unsafe public string DeviceType
        {
            get
            {
                return MobileDevice.AMDeviceCopyValue(iPhoneHandle, 0, "DeviceClass");
            }
        }

        ///<summary>
        /// Returns the current OS version running on the device (2.0, 2.2, 3.0, 3.1, etc).
        ///</summary>
        unsafe public string DeviceVersion
        {
            get
            {
                return MobileDevice.AMDeviceCopyValue(iPhoneHandle, 0, "ProductVersion");
            }
        }
        ///<summary>
        /// Returns the name of the device, like "Dan's iPhone"
        ///</summary>
        unsafe public string DeviceName
        {
            get
            {
                return MobileDevice.AMDeviceCopyValue(iPhoneHandle, 0, "DeviceName");
            }
        }

        /// <summary>
        /// Returns the handle to the iPhone com.apple.afc service
        /// </summary>
        unsafe public void* AFCHandle
        {
            get
            {
                return hAFC;
            }
        }

        /// <summary>
        /// Returns if we are connected to jailbroken iphone
        /// </summary>
        public Boolean IsJailbreak
        {
            get
            {
                return wasAFC2 || (connected ? Exists("/Applications") : false);
            }
        }

        /// <summary>
        /// Gets/Sets the current working directory, used by all file and directory methods
        /// </summary>
        public string CurrentDirectory
        {
            get
            {
                return current_directory;
            }

            set
            {
                current_directory = value;
            }
        }
        #endregion	// Properties

        #region Events
        /// <summary>
        /// The <c>Connect</c> event is triggered when a iPhone is connected to the computer
        /// </summary>
        public event ConnectEventHandler Connect;

        /// <summary>
        /// Raises the <see>Connect</see> event.
        /// </summary>
        /// <param name="args">A <see cref="ConnectEventArgs"/> that contains the event data.</param>
        protected void OnConnect(ConnectEventArgs args)
        {
            ConnectEventHandler handler = Connect;

            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// The <c>Disconnect</c> event is triggered when the iPhone is disconnected from the computer
        /// </summary>
        public event ConnectEventHandler Disconnect;

        /// <summary>
        /// Raises the <see>Disconnect</see> event.
        /// </summary>
        /// <param name="args">A <see cref="ConnectEventArgs"/> that contains the event data.</param>
        protected void OnDisconnect(ConnectEventArgs args)
        {
            ConnectEventHandler handler = Disconnect;

            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// Write Me
        /// </summary>
        public event EventHandler DfuConnect;

        /// <summary>
        /// Raises the <see>DfuConnect</see> event.
        /// </summary>
        /// <param name="args">A <see cref="DeviceNotificationEventArgs"/> that contains the event data.</param>
        protected void OnDfuConnect(DeviceNotificationEventArgs args)
        {
            EventHandler handler = DfuConnect;

            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// Write Me
        /// </summary>
        public event EventHandler DfuDisconnect;

        /// <summary>
        /// Raises the <see>DfiDisconnect</see> event.
        /// </summary>
        /// <param name="args">A <see cref="DeviceNotificationEventArgs"/> that contains the event data.</param>
        protected void OnDfuDisconnect(DeviceNotificationEventArgs args)
        {
            EventHandler handler = DfuDisconnect;

            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// The RecoveryModeEnter event is triggered when the attached iPhone enters Recovery Mode
        /// </summary>
        public event EventHandler RecoveryModeEnter;

        /// <summary>
        /// Raises the <see>RecoveryModeEnter</see> event.
        /// </summary>
        /// <param name="args">A <see cref="DeviceNotificationEventArgs"/> that contains the event data.</param>
        protected void OnRecoveryModeEnter(DeviceNotificationEventArgs args)
        {
            EventHandler handler = RecoveryModeEnter;

            if (handler != null)
            {
                handler(this, args);
            }
        }

        /// <summary>
        /// The RecoveryModeLeave event is triggered when the attached iPhone leaves Recovery Mode
        /// </summary>
        public event EventHandler RecoveryModeLeave;

        /// <summary>
        /// Raises the <see>RecoveryModeLeave</see> event.
        /// </summary>
        /// <param name="args">A <see cref="DeviceNotificationEventArgs"/> that contains the event data.</param>
        protected void OnRecoveryModeLeave(DeviceNotificationEventArgs args)
        {
            EventHandler handler = RecoveryModeLeave;

            if (handler != null)
            {
                handler(this, args);
            }
        }

        #endregion	// Events

        #region Filesystem

        /// <summary>
        /// 
        /// </summary>
        public struct strFileInfo
        {
            /// <summary>
            /// file name byte array
            /// </summary>
            public byte[] name;
            /// <summary>
            /// file size
            /// </summary>
            public ulong size;
            /// <summary>
            /// is directory
            /// </summary>
            public Boolean isDir;
            /// <summary>
            /// is symbolic link
            /// </summary>
            public bool isSLink;
        }

        public struct strStatVfs
        {
            public int Namemax;
            public int Bsize;
            public float Btotal;
            public float Bfree;
        }
        //unsafe public bool GetStatFs(ref strStatVfs stbuf)
        //{
        //    string name;
        //    string value;

        //    //memset(stbuf, 0, sizeof(struct statvfs));
        //    //afc_dictionary info;
        //    IntPtr info = new IntPtr();

        //    int ret = MobileDevice.AFCDeviceInfoOpen(hAFC, ref info);
        //    if (ret != 0)
        //    {
        //        //cerr << "AFCDeviceInfoOpen: " << ret << endl;
        //        return false;
        //    }
        //    Dictionary<string, string> info_map = new Dictionary<string, string>();
        //    while (MobileDevice.AFCKeyValueRead(info, out name, out value) == 0
        //        && name != null && value != null)
        //    {
        //        info_map.Add(name, value);
        //    }

        //    MobileDevice.AFCKeyValueClose(info);

        //    if (info_map["FSTotalBytes"] == null)
        //    {
        //        //cerr << "AFCDeviceInfoOpen: Missing FSTotalBytes";
        //        return false;
        //    }
        //    if (info_map["FSBlockSize"] == null)
        //    {
        //        //cerr << "AFCDeviceInfoOpen: Missing FSBlockSize";
        //        return false;
        //    }
        //    if (info_map["Model"] == null)
        //    {
        //        //cerr << "AFCDeviceInfoOpen: Missing Model";
        //        return false;
        //    }

        //    int blockSize = int.Parse(info_map["FSBlockSize"].ToString());
        //    ulong totalBytes = ulong.Parse(info_map["FSTotalBytes"].ToString());
        //    ulong freeBytes = ulong.Parse(info_map["FSFreeBytes"].ToString());
        //    stbuf.Namemax = 255;
        //    stbuf.Bsize = blockSize;
        //    stbuf.Btotal = (float)totalBytes /blockSize;
        //    stbuf.Bfree = (float)freeBytes/ blockSize;

        //    return true;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        unsafe public List<strFileInfo> GetFolderInfo(string path)
        {
            Byte[] buffer;
            List<strFileInfo> paths = new List<strFileInfo>();
            string full_path;
            int len;

            if (!connected)
            {
                throw new Exception("Not connected to phone");
            }

            //IntPtr hAFCDir = IntPtr.Zero;
            void* hAFCDir = null; 
            full_path = FullPath(current_directory, path);

            if (MobileDevice.AFCDirectoryOpen(hAFC, string2bytes(full_path), ref hAFCDir) != 0)
            {
                throw new Exception("Path does not exist");
            }

            buffer = null;

            len = MobileDevice.AFCDirectoryRead(hAFC, hAFCDir, ref buffer);

            if (full_path.Length > 1) full_path += "/";

            while (buffer != null)
            {
                bool isDir;
                bool isSLink;
                ulong size;
                try
                {
                    this.GetFileInfo(full_path, buffer, len, out size, out isDir, out isSLink);
                    if (!((buffer[0] == '.' && len == 1) || (buffer[0] == '.' && buffer[1] == '.' && len == 2)))
                    {
                        strFileInfo tmp;
                        tmp.name = buffer;
                        tmp.isDir = isDir;
                        tmp.isSLink = isSLink;
                        tmp.size = size;
                        paths.Add(tmp);
                    }
                    len = MobileDevice.AFCDirectoryRead(hAFC, hAFCDir, ref buffer);
                }
                catch
                {
                    //Debug.WriteLinw(ex.Message);
                }
            }
            MobileDevice.AFCDirectoryClose(hAFC, hAFCDir);
            return paths;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        unsafe public List<strFileInfo> GetFilesInfo(string path)
        {
            Byte[] buffer;
            List<strFileInfo> paths = new List<strFileInfo>();
            string full_path;
            int len;

            if (!connected)
            {
                throw new Exception("Not connected to phone");
            }

            //IntPtr hAFCDir = IntPtr.Zero;
            void* hAFCDir = null; 
            full_path = FullPath(current_directory, path);

            if (MobileDevice.AFCDirectoryOpen(hAFC, string2bytes(full_path), ref hAFCDir) != 0)
            {
                throw new Exception("Path does not exist");
            }

            buffer = null;

            len = MobileDevice.AFCDirectoryRead(hAFC, hAFCDir, ref buffer);

            if (full_path.Length > 1) full_path += "/";

            while (buffer != null)
            {
                bool isDir;
                bool isSLink;
                ulong size;
                try
                {
                    this.GetFileInfo(full_path, buffer, len, out size, out isDir, out isSLink);
                    //if (!isDir)
                    {
                        strFileInfo tmp;
                        tmp.name = buffer;
                        tmp.isDir = isDir;
                        tmp.isSLink = isSLink;
                        tmp.size = size;
                        paths.Add(tmp);
                    }
                    len = MobileDevice.AFCDirectoryRead(hAFC, hAFCDir, ref buffer);
                }
                catch
                {
                    //Debug.WriteLinw(ex.Message);
                }
            }
            MobileDevice.AFCDirectoryClose(hAFC, hAFCDir);
            return paths;
        }

        /// <summary>
        /// Returns the names of files in a specified directory
        /// </summary>
        /// <param name="path">The directory from which to retrieve the files.</param>
        /// <returns>A <c>String</c> array of file names in the specified directory. Names are relative to the provided directory</returns>
        unsafe public strDir[] GetFiles(string path)
        {
            byte[] bbuffer;
            strDir buffer;
            List<strDir> paths;
            string full_path;

            if (!connected)
            {
                throw new Exception("Not connected to phone");
            }

            //IntPtr hAFCDir = IntPtr.Zero;
            void* hAFCDir = null;
            full_path = FullPath(current_directory, path);

            if (MobileDevice.AFCDirectoryOpen(hAFC, string2bytes(full_path), ref hAFCDir) != 0)
            {
                throw new Exception("Path does not exist");
            }

            bbuffer = null;
            paths = new List<strDir>();
            MobileDevice.AFCDirectoryRead(hAFC, hAFCDir, ref bbuffer);
            buffer.Dir = byte2string(bbuffer).Normalize();

            while (bbuffer != null)
            {
                bool isLink;
                if (!IsDirectory(FullPath(full_path, buffer.Dir), out isLink))
                {
                    buffer.IsDir = false;
                    buffer.IsSLink = isLink;
                    paths.Add(buffer);
                }
                MobileDevice.AFCDirectoryRead(hAFC, hAFCDir, ref bbuffer);
                if (bbuffer == null) break;
                buffer.Dir = byte2string(bbuffer);
            }
            MobileDevice.AFCDirectoryClose(hAFC, hAFCDir);
            return paths.ToArray();
        }

        /// <summary>
        /// Returns the FileInfo dictionary
        /// </summary>
        /// <param name="path">The file or directory for which to retrieve information.</param>
        unsafe public Dictionary<string, string> GetFileInfo(string path)
        {
            int ret;
            Dictionary<string, string> ans = new Dictionary<string, string>();
            void* data = null;

            ret = MobileDevice.AFCFileInfoOpen(hAFC, string2bytes(path), ref data);
            if (ret != 0)
            {
                return null;
            }

            try
            {
                void* pname, pvalue;
                while (MobileDevice.AFCKeyValueRead(data, out pname, out pvalue) == 0
                    && pname != null && pvalue != null)
                {
                    string name = Marshal.PtrToStringAnsi(new IntPtr(pname));
                    string value = Marshal.PtrToStringAnsi(new IntPtr(pvalue));
                    ans.Add(name, value);
                }

            }
            catch (Exception)
            {
                //int a = 0;
            }
            finally
            {
                MobileDevice.AFCKeyValueClose(data);
            }

            return ans;
        }

        /// <summary>
        /// Returns the size and type of the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to retrieve information.</param>
        /// <param name="fname">file name.</param>
        /// <param name="len">file name.</param>
        /// <param name="size">Returns the size of the specified file or directory</param>
        /// <param name="directory">Returns <c>true</c> if the given path describes a directory, false if it is a file.</param>
        /// <param name="isSLink">is symbolic link</param>
        unsafe public void GetFileInfo(string path, byte[] fname, int len, out ulong size, out bool directory, out bool isSLink)
        {
            int blocks = 0;
            int ret;
            bool SLink = false;

            void* data = null;

            size = 0;
            directory = false;
            isSLink = false;
            path += byte2string(fname);

            ret = MobileDevice.AFCFileInfoOpen(hAFC, string2bytes(path), ref data);
            if (ret != 0)
            {
                return;
            }

            try
            {
                void* pname, pvalue;
                while (MobileDevice.AFCKeyValueRead(data, out pname, out pvalue) == 0
                    && pname != null && pvalue != null)
                {
                    string name = Marshal.PtrToStringAnsi(new IntPtr(pname));
                    string value = Marshal.PtrToStringAnsi(new IntPtr(pvalue));
                    switch (name)
                    {
                        case "st_size":
                            size = UInt64.Parse(value);
                            break;
                        case "st_blocks":
                            try
                            {
                                blocks = Int32.Parse(value);
                            }
                            catch
                            {
                                blocks = 0;
                            }
                            break;
                        case "st_ifmt":
                            switch (value)
                            {
                                case "S_IFDIR":
                                    directory = true;
                                    break;
                                case "S_IFLNK":
                                    SLink = true;
                                    break;
                            }
                            break;
                        default:
                            //SLink = false;
                            break;
                    }

                }

            }
            catch (Exception)
            {
                //int a = 0;
            }
            finally
            {
                MobileDevice.AFCKeyValueClose(data);
            }

            if (SLink)
            { // test for symbolic directory link
                //IntPtr hAFCDir = IntPtr.Zero;
                void* hAFCDir = null;

                if (directory = (MobileDevice.AFCDirectoryOpen(hAFC, string2bytes(path), ref hAFCDir) == 0))
                    MobileDevice.AFCDirectoryClose(hAFC, hAFCDir);
            }
            isSLink = SLink;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="size"></param>
        /// <param name="directory"></param>
        unsafe public void GetFileInfo(string path, out ulong size, out bool directory)
        {
            int blocks = 0;
            int ret;
            bool SLink = false;

            void* data = null;

            size = 0;
            directory = false;
            ret = MobileDevice.AFCFileInfoOpen(hAFC, string2bytes(path), ref data);
            if (ret != 0)
            {
                return;
            }

            try
            {
                void* pname, pvalue;
                while (MobileDevice.AFCKeyValueRead(data, out pname, out pvalue) == 0
                    && pname != null && pvalue != null)
                {
                    string name = Marshal.PtrToStringAnsi(new IntPtr(pname));
                    string value = Marshal.PtrToStringAnsi(new IntPtr(pvalue));
                    switch (name)
                    {
                        case "st_size":
                            size = UInt64.Parse(value);
                            break;
                        case "st_blocks":
                            try
                            {
                                blocks = Int32.Parse(value);
                            }
                            catch
                            {
                                blocks = 0;
                            }
                            break;
                        case "st_ifmt":
                            switch (value)
                            {
                                case "S_IFDIR": directory = true; break;
                                case "S_IFLNK": SLink = true; break;
                            }
                            break;
                        default:
                            SLink = false;
                            break;
                    }
                }

            }
            catch (Exception)
            {
                //int a = 0;
            }
            finally
            {
                MobileDevice.AFCKeyValueClose(data);
            }

            if (SLink)
            { // test for symbolic directory link
                //IntPtr hAFCDir = IntPtr.Zero;
                void* hAFCDir = null;
                if (directory = (MobileDevice.AFCDirectoryOpen(hAFC, string2bytes(path), ref hAFCDir) == 0))
                    MobileDevice.AFCDirectoryClose(hAFC, hAFCDir);
            }
        }

        /// <summary>
        /// Returns the size of the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory for which to obtain the size.</param>
        /// <returns></returns>
        public ulong FileSize(string path)
        {
            bool is_dir;
            ulong size;

            this.GetFileInfo(path, out size, out is_dir);
            return size;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">file path</param>
        /// <param name="fname">file name byte array</param>
        /// <param name="len">file name length</param>
        /// <returns></returns>
        public ulong FileSize(string path, byte[] fname, int len)
        {
            bool isDir;
            bool isSLink;
            ulong size;

            this.GetFileInfo(path, fname, len, out size, out isDir, out isSLink);
            return size;
        }

        /// <summary>
        /// Creates the directory specified in path
        /// </summary>
        /// <param name="path">The directory path to create</param>
        /// <returns>true if directory was created</returns>
        unsafe public bool CreateDirectory(string path)
        {
            string full_path;

            full_path = FullPath(current_directory, path);
            if (MobileDevice.AFCDirectoryCreate(hAFC, string2bytes(full_path)) != 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the names of subdirectories in a specified directory.
        /// </summary>
        /// <param name="path">The path for which an array of subdirectory names is returned.</param>
        /// <returns>An array of type <c>String</c> containing the names of subdirectories in <c>path</c>.</returns>
        unsafe public strDir[] GetDirectories(string path)
        {
            byte[] bbuffer;
            strDir buffer;
            List<strDir> paths;
            string full_path;
            bool isLink;

            if (!connected)
            {
                throw new Exception("Not connected to phone");
            }

            //IntPtr hAFCDir = IntPtr.Zero;
            void* hAFCDir = null; 
            full_path = FullPath(current_directory, path);

            if (MobileDevice.AFCDirectoryOpen(hAFC, string2bytes(full_path), ref hAFCDir) != 0)
            {
                throw new Exception("Path does not exist");
            }

            bbuffer = null;
            paths = new List<strDir>();
            MobileDevice.AFCDirectoryRead(hAFC, hAFCDir, ref bbuffer);

            buffer = new strDir();
            while (bbuffer != null)
            {
                string dir = byte2string(bbuffer);
                if ((dir != ".") && (dir != ".."))
                {
                    if (IsDirectory(FullPath(full_path, dir), out isLink))
                    {
                        buffer.Dir = dir;
                        buffer.IsDir = true;
                        buffer.IsSLink = isLink;
                        paths.Add(buffer);
                    }
                }
                MobileDevice.AFCDirectoryRead(hAFC, hAFCDir, ref bbuffer);
            }
            MobileDevice.AFCDirectoryClose(hAFC, hAFCDir);
            return paths.ToArray();
        }

        /// <summary>
        /// Get first directory name
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        unsafe public string Get1stDirectory(string path)
        {
            byte[] bbuffer;
            string buffer;
            string dirpath;
            string full_path;
            int cnt = 0;

            if (!connected)
            {
                throw new Exception("Not connected to phone");
            }

            //IntPtr hAFCDir = IntPtr.Zero;
            void* hAFCDir = null; 
            full_path = FullPath(current_directory, path);

            if (MobileDevice.AFCDirectoryOpen(hAFC, string2bytes(full_path), ref hAFCDir) != 0)
            {
                throw new Exception("Path does not exist");
            }

            bbuffer = null;
            dirpath = "";
            MobileDevice.AFCDirectoryRead(hAFC, hAFCDir, ref bbuffer);

            while (bbuffer != null)
            {
                buffer = byte2string(bbuffer);
                if ((buffer != ".") && (buffer != ".."))
                {
                    bool isLink;
                    if (IsDirectory(FullPath(full_path, buffer), out isLink))
                    {
                        dirpath = buffer;
                        break;
                    }
                }
                MobileDevice.AFCDirectoryRead(hAFC, hAFCDir, ref bbuffer);
                if (cnt++ > 15) break;
            }
            MobileDevice.AFCDirectoryClose(hAFC, hAFCDir);
            return dirpath;
        }

        /// <summary>
        /// Moves a file or a directory and its contents to a new location or renames a file or directory if the old and new parent path matches.
        /// </summary>
        /// <param name="sourceName">The path of the file or directory to move or rename.</param>
        /// <param name="destName">The path to the new location for <c>sourceName</c>.</param>
        ///	<remarks>Files cannot be moved across filesystem boundaries.</remarks>
        unsafe public bool Rename(string sourceName, string destName)
        {
            return MobileDevice.AFCRenamePath(hAFC, string2bytes(FullPath(current_directory, sourceName)), string2bytes(FullPath(current_directory, destName))) == 0;
        }

        /// <summary>
        /// FIXME
        /// </summary>
        /// <param name="sourceName"></param>
        /// <param name="destName"></param>
        public void Copy(string sourceName, string destName)
        {

        }

        /// <summary>
        /// Returns the root information for the specified path. 
        /// </summary>
        /// <param name="path">The path of a file or directory.</param>
        /// <returns>A string containing the root information for the specified path. </returns>
        public string GetDirectoryRoot(string path)
        {
            return "/";
        }

        /// <summary>
        /// Determines whether the given path refers to an existing file or directory on the phone. 
        /// </summary>
        /// <param name="path">The path to test.</param>
        /// <returns><c>true</c> if path refers to an existing file or directory, otherwise <c>false</c>.</returns>
        unsafe public bool Exists(string path)
        {
            void* data = null;

            int ret = MobileDevice.AFCFileInfoOpen(hAFC, string2bytes(path), ref data);
            if (ret == 0)
                MobileDevice.AFCKeyValueClose(data);

            return (ret == 0);
        }

        /// <summary>
        /// Determines whether the given path refers to an existing directory on the phone. 
        /// </summary>
        /// <param name="path">The path to test.</param>
        /// <param name="fname">file name</param>
        /// <param name="len">file name length.</param>
        /// <param name="isSLink">return is symbolic link</param>
        /// <returns><c>true</c> if path refers to an existing directory, otherwise <c>false</c>.</returns>
        public bool IsDirectory(string path, byte[] fname, int len, out bool isSLink)
        {
            bool is_dir;
            is_dir = IsDirectory(path + byte2string(fname), out isSLink);

            return is_dir;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="isSLink">return is symbolic link</param>
        /// <returns></returns>
        unsafe public bool IsDirectory(string path, out bool isSLink)
        {
            int ret;

            void* data = null;
            bool is_dir = false;
            isSLink = false;

            ret = MobileDevice.AFCFileInfoOpen(hAFC, string2bytes(path), ref data);
            if (ret != 0)
            {
                return is_dir;
            }

            try
            {
                void* pname, pvalue;
                while (MobileDevice.AFCKeyValueRead(data, out pname, out pvalue) == 0
                    && pname != null && pvalue != null)
                {
                    string name = Marshal.PtrToStringAnsi(new IntPtr(pname));
                    string value = Marshal.PtrToStringAnsi(new IntPtr(pvalue));
                    if (name == "st_ifmt")
                    {
                        switch (value)
                        {
                            case "S_IFDIR":
                                is_dir = true;
                                break;
                            case "S_IFLNK":
                                isSLink = true;
                                break;
                        }
                        break;
                    }
                }

            }
            catch (Exception)
            {
                //int a = 0;
            }
            finally
            {
                MobileDevice.AFCKeyValueClose(data);
            }

            if (isSLink)
            { // test for symbolic directory link
                //IntPtr hAFCDir = IntPtr.Zero;
                void* hAFCDir = null;

                if (MobileDevice.AFCDirectoryOpen(hAFC, string2bytes(path), ref hAFCDir) == 0)
                {
                    MobileDevice.AFCDirectoryClose(hAFC, hAFCDir);
                    is_dir = true;
                }
                else
                    is_dir = false;
            }

            return is_dir;
        }

        /// <summary>
        /// Deletes an empty directory from a specified path.
        /// </summary>
        /// <param name="path">The name of the empty directory to remove. This directory must be writable and empty.</param>
        unsafe public void DeleteDirectory(string path)
        {
            string full_path;

            full_path = FullPath(current_directory, path);
            bool isSLink;
            if (IsDirectory(full_path, out isSLink))
            {
                MobileDevice.AFCRemovePath(hAFC, string2bytes(full_path));
            }
        }

        /// <summary>
        /// Deletes the specified directory and, if indicated, any subdirectories in the directory.
        /// </summary>
        /// <param name="path">The name of the directory to remove.</param>
        /// <param name="recursive"><c>true</c> to remove directories, subdirectories, and files in path; otherwise, <c>false</c>. </param>
        public void DeleteDirectory(string path, bool recursive)
        {
            string full_path;

            if (!recursive)
            {
                DeleteDirectory(path);
                return;
            }

            full_path = FullPath(current_directory, path);
            bool isSLink;
            if (IsDirectory(full_path, out isSLink))
            {
                this.internalDeleteDirectory(path);
            }

        }

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="path">The name of the file to remove.</param>
        unsafe public void DeleteFile(string path)
        {
            string full_path;

            full_path = FullPath(current_directory, path);
            if (Exists(full_path))
            {
                MobileDevice.AFCRemovePath(hAFC, string2bytes(full_path));
            }
        }

        /// <summary>
        /// Gets the current working directory of the object. 
        /// </summary>
        /// <returns>A <c>string</c> containing the path of the current working directory. </returns>
        public string GetCurrentDirectory()
        {
            return current_directory;
        }

        /// <summary>
        /// Sets the application's current working directory to the specified directory.
        /// </summary>
        /// <param name="path">The path to which the current working directory should be set.</param>
        public void SetCurrentDirectory(string path)
        {
            string new_path;

            new_path = FullPath(current_directory, path);
            bool isSLink;
            if (!IsDirectory(new_path, out isSLink))
            {
                throw new Exception("Invalid directory specified");
            }
            current_directory = new_path;
        }

        internal static byte[] string2bytes(string str)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(str);
            return byteArray;
        }

        internal static string byte2string(byte[] bstr)
        {
            byte[] b = bstr;
            int p = 0;

            for (int i = 0; i < bstr.Length; i++)
            {
                if (bstr[i] == 0) break;
                //System.Diagnostics.Debug.Write(String.Format("{0:x},", bstr[i]));
                if (bstr[i] == 0xe3)
                {
                    if (bstr[i + 1] == 0x82)
                    {
                        if (bstr[i + 2] == 0x99)
                        {
                            bstr[p - 1]++;
                            i += 3;
                        }
                        else if (bstr[i + 2] == 0x9A)
                        {
                            bstr[p - 1] += 2;
                            i += 3;
                        }
                    }
                }
                b[p++] = bstr[i];
            }
            b[p] = 0;
            // Encode the array of chars.
            string str = Encoding.UTF8.GetString(bstr);
            p = str.IndexOf('\0');
            str = str.Substring(0, p);

            //System.Diagnostics.Debug.WriteLine(" " + str);

            return str;  //asciiString
        }
        #endregion	// Filesystem

        #region Private Methods
        unsafe private bool connectToPhone()
        {
            if (MobileDevice.AMDeviceConnect(iPhoneHandle) == 1)
            {
                throw new Exception("Phone in recovery mode, support not yet implemented");
                //int connid = MobileDevice.AMDeviceGetConnectionID(ref iPhoneHandle);
                //MobileDevice.AMRestoreModeDeviceCreate(0, connid, 0);
                //return false;
            }
            if (MobileDevice.AMDeviceIsPaired(iPhoneHandle) == 0)
            {
                return false;
            }
            int chk = MobileDevice.AMDeviceValidatePairing(iPhoneHandle);
            if (chk != 0)
            {
                return false;
            }

            if (MobileDevice.AMDeviceStartSession(iPhoneHandle) == 1)
            {
                return false;
            }

            bool isAfc2 = 0 == MobileDevice.AMDeviceStartService(iPhoneHandle,
                MobileDevice.__CFStringMakeConstantString(MobileDevice.StringToCString("com.apple.afc2")), ref hService, null);
            if (!isAfc2)
            {
                bool isAfc = 0 == MobileDevice.AMDeviceStartService(iPhoneHandle,
                    MobileDevice.__CFStringMakeConstantString(MobileDevice.StringToCString("com.apple.afc")), ref hService, null);
                if (!isAfc)
                {
                    return false;
                }
            }
            else
            {
                this.wasAFC2 = true;
            }
            if (MobileDevice.AFCConnectionOpen(hService, 0, ref hAFC) != 0)
            {
                return false;
            }

            connected = true;
            return true;
        }

        unsafe private void NotifyCallback(ref AMDeviceNotificationCallbackInfo callback)
        {
            if (callback.msg == NotificationMessage.Connected)
            {
                iPhoneHandle = callback.dev;
                if (this.connectToPhone())
                {
                    this.OnConnect(new ConnectEventArgs(callback));
                }
            }
            else if (callback.msg == NotificationMessage.Disconnected)
            {
                connected = false;
                this.OnDisconnect(new ConnectEventArgs(callback));
            }
        }

        private void DfuConnectCallback(ref AMRecoveryDevice callback)
        {
            OnDfuConnect(new DeviceNotificationEventArgs(callback));
        }

        private void DfuDisconnectCallback(ref AMRecoveryDevice callback)
        {
            OnDfuDisconnect(new DeviceNotificationEventArgs(callback));
        }

        private void RecoveryConnectCallback(ref AMRecoveryDevice callback)
        {
            OnRecoveryModeEnter(new DeviceNotificationEventArgs(callback));
        }

        private void RecoveryDisconnectCallback(ref AMRecoveryDevice callback)
        {
            OnRecoveryModeLeave(new DeviceNotificationEventArgs(callback));
        }

        private void internalDeleteDirectory(string path)
        {
            string full_path;
            strDir[] contents;

            full_path = FullPath(current_directory, path);
            contents = GetFiles(path);
            for (int i = 0; i < contents.Length; i++)
            {
                DeleteFile(full_path + "/" + contents[i].Dir);
            }

            contents = GetDirectories(path);
            for (int i = 0; i < contents.Length; i++)
            {
                this.internalDeleteDirectory(full_path + "/" + contents[i].Dir);
            }

            DeleteDirectory(path);
        }

        static char[] path_separators = { '/' };
        internal string FullPath(string path1, string path2)
        {
            string[] path_parts;
            string[] result_parts;
            int target_index;

            if ((path1 == null) || (path1 == String.Empty))
            {
                path1 = "/";
            }

            if ((path2 == null) || (path2 == String.Empty))
            {
                path2 = "/";
            }

            if (path2[0] == '/')
            {
                path_parts = path2.Split(path_separators);
            }
            else if (path1[0] == '/')
            {
                path_parts = (path1 + "/" + path2).Split(path_separators);
            }
            else
            {
                path_parts = ("/" + path1 + "/" + path2).Split(path_separators);
            }
            result_parts = new string[path_parts.Length];
            target_index = 0;

            for (int i = 0; i < path_parts.Length; i++)
            {
                if (path_parts[i] == "..")
                {
                    if (target_index > 0)
                    {
                        target_index--;
                    }
                }
                else if ((path_parts[i] == ".") || (path_parts[i] == ""))
                {
                    // Do nothing
                }
                else
                {
                    result_parts[target_index++] = path_parts[i];
                }
            }

            return "/" + String.Join("/", result_parts, 0, target_index);
        }

        #endregion	// Private Methods
    }
}
