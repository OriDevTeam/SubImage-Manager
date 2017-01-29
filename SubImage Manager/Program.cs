using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SubImage_Manager.Scripts;
using SubImage_Manager.Forms;

namespace iCyber_Uploader
{
    static class Program
    {
        private static Mutex m_Mutex;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool isNewMutex;
            m_Mutex = new Mutex(true, @"Global\SubImageManager", out isNewMutex);

            if (!isNewMutex)
                return;

            UIManager.Instance.MainForm = new MainForm();

            MainManager.Instance.WakeUp();

            if (!UIManager.Instance.MainForm.IsDisposed || UIManager.Instance.MainForm != null)
                Application.Run(UIManager.Instance.MainForm);
        }
    }
}
