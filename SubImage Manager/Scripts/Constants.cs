using System.IO;
using System;

namespace SubImage_Manager.Scripts
{
    public class Constants
    {
        //////////////////////////////////////////////////////////////////
        ///// LOGMANAGER CONSTANTS

        public static readonly string SYS_ERROR_FILE_PATH = Directory.GetCurrentDirectory() + @"\syserr.txt";
        public static readonly string SYS_LOG_FILE_PATH = Directory.GetCurrentDirectory() + @"\syslog.txt";
    }
}