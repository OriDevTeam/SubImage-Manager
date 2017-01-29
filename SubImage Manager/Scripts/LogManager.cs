using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SubImage_Manager.Scripts
{
    class LogManager
    {
        public static readonly LogManager Instance = new LogManager();
        public static bool wokeUp = false;

        public void WakeUp()
        {
            if (!wokeUp)
            {
                wokeUp = true;
                if(File.Exists(Constants.SYS_LOG_FILE_PATH))
                {
                    File.Delete(Constants.SYS_LOG_FILE_PATH);
                    Log("Cleaned old logs");
                }

                if (File.Exists(Constants.SYS_ERROR_FILE_PATH))
                {
                    File.Delete(Constants.SYS_ERROR_FILE_PATH);
                    Log("Cleaned old error logs");
                }
            }
        }

        public void WriteToFile(string filePath, string sufix, string msg)
        {
            string dir = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            StreamWriter writer = null;
            StringBuilder strBulder = null;

            strBulder = new StringBuilder(sufix + " - " + DateTime.Now + ": " + msg + "\n");

            writer = new StreamWriter(filePath, true);
            writer.Write(strBulder);
            writer.Close();
        }

        public void MsgLog(string title, string msg)
        {
            Log(msg);
            MessageBox.Show(msg, title);
        }

        public void MsgLog(string msg)
        {
            MsgLog("", msg);
        }

        public void MsgError(string msg)
        {
            Error(msg);
            MessageBox.Show(msg);
        }

        public void Log(string msg)
        {
            WriteToFile(Constants.SYS_LOG_FILE_PATH, "SYS_LOG", msg);
        }

        public void Error(string msg)
        {
            WriteToFile(Constants.SYS_LOG_FILE_PATH, "SYS_ERR", msg);
            WriteToFile(Constants.SYS_ERROR_FILE_PATH, "SYS_ERR", msg);
        }
    }
}
