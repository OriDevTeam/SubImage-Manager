using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubImage_Manager.Scripts
{
    class MainManager
    {
        //////////////////////////////////////////////////////////////////
        ///// Constructor
        public static readonly MainManager Instance = new MainManager();
        public static bool exitApplication { get; private set; }
        public static bool wokeUp = false;

        public void WakeUp()
        {
            if (!wokeUp)
            {
                wokeUp = true;

                LogManager.Instance.WakeUp();
                LogManager.Instance.Log("Waking up all managers");

                UIManager.Instance.WakeUp();
                ImageManager.Instance.WakeUp();
                SubImageManager.Instance.WakeUp();
            }
        }

        //////////////////////////////////////////////////////////////////
        ///// SOA & EOP

        private void Terminate()
        {
            exitApplication = true;
        }

        public void ShutdownApplication()
        {
            LogManager.Instance.Log("Quitting application...\n" +
                                    "Application end-time, cya next time.\n");
            UIManager.Instance.QuitUI();
            Terminate();
        }

        //////////////////////////////////////////////////////////////////
    }
}
