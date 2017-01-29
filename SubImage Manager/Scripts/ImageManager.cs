using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SubImage_Manager.Forms;
using System.Drawing;
using SubImage_Manager.ExternalScripts;
using CSharpImageLibrary;
using System.IO;

namespace SubImage_Manager.Scripts
{
    class ImageManager
    {
        //////////////////////////////////////////////////////////////////
        ///// Constructor
        public static readonly ImageManager Instance = new ImageManager();
        public ImageEngineImage image;
        public bool imageLoaded = false;

        static bool wokeUp = false;

        public void WakeUp()
        {
            if (!wokeUp)
            {
                wokeUp = true;
                imageLoaded = false;
            }
        }

        //////////////////////////////////////////////////////////////////
        ///// UI Preparing Operations

   

        //////////////////////////////////////////////////////////////////
        ///// Manager Operations

        public void SetImage(string imagePath)
        {
            byte[] bytes = null;
            try
            {
                bytes = File.ReadAllBytes(imagePath);
                image = new ImageEngineImage(bytes);
                UIManager.Instance.ShowImage(UsefulThings.WinForms.Imaging.CreateBitmap(image.GetWPFBitmap(), false));
            }
            catch (Exception)
            {

                LogManager.Instance.MsgError("Cannot load image: " + imagePath);
                throw;
            }
        }

        public void SetImage(Bitmap bmp)
        {
            using (var stream = new MemoryStream())
            {
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] bytes = stream.ToArray();
                image = new ImageEngineImage(bytes);
                UIManager.Instance.ShowImage(UsefulThings.WinForms.Imaging.CreateBitmap(image.GetWPFBitmap(), false));
            }
        }

        public Bitmap GetImage()
        {
            return UsefulThings.WinForms.Imaging.CreateBitmap(image.GetWPFBitmap(), false);
        }
    }
}
