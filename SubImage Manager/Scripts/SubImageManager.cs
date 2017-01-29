using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SubImage_Manager.Forms;
using System.Drawing;
using SubImage_Manager.ExternalScripts;
using CSharpImageLibrary;
using System.Drawing.Imaging;
using System.IO;

namespace SubImage_Manager.Scripts
{
    class SubImageManager
    {
        //////////////////////////////////////////////////////////////////
        ///// Constructor
        public static readonly SubImageManager Instance = new SubImageManager();
        public List<SubImage> subImageList;
        public int selectedSubIndex;
        public bool loadingSubs = false;

        static bool wokeUp = false;

        public void WakeUp()
        {
            if (!wokeUp)
            {
                wokeUp = true;
                subImageList = new List<SubImage>();
                selectedSubIndex = -1;
            }
        }

        //////////////////////////////////////////////////////////////////
        ///// Manager Operations

        public void AddSubImage(SubImage subImage)
        {
            subImageList.Add(subImage);

            if (selectedSubIndex == -1 || selectedSubIndex == subImageList.Count - 1)
                selectedSubIndex += 1;

            UIManager.Instance.RefreshUI();
        }

        public void RemoveSubImage(int index)
        {
            subImageList.RemoveAt(index);
            UIManager.Instance.RefreshUI();
        }

        public void SaveAllSubImages(string path)
        {
            foreach (var subImage in subImageList)
            {
                SaveSubImage(subImage, path, "dds");
            }
        }

        public void SaveSelectedSubImage(string path)
        {
            if (selectedSubIndex != -1)
                SaveSubImage(subImageList[selectedSubIndex], path, "dds");
        }

        public void SaveSubImage(SubImage subImage, string path, string extension)
        {
            Bitmap bmp = UsefulThings.WinForms.Imaging.CreateBitmap(ImageManager.Instance.image.GetWPFBitmap(), false);
            UIManager.Instance.MainForm.displayImageBox.Image = bmp;
            int top = 0, bottom = 0, left = 0, right = 0;

            foreach (var property in subImage.properties)
            {
                if (property.name == "top")
                    top = Convert.ToInt32(property.value);

                if (property.name == "bottom")
                    bottom = Convert.ToInt32(property.value);

                if (property.name == "left")
                    left = Convert.ToInt32(property.value);

                if (property.name == "right")
                    right = Convert.ToInt32(property.value);
            }

            Rectangle rect = Rectangle.FromLTRB(left, top, right, bottom);

            if (rect.Width <= 0 || rect.Height <= 0)
            {
                LogManager.Instance.MsgError("Invalid sub image on file " + subImage.path);
                return;
            }

            try
            {

                bmp = bmp.Clone(rect, bmp.PixelFormat);

                using (var stream = new MemoryStream())
                {
                    bmp.Save(stream, ImageFormat.Png);
                    ImageEngineImage img = new ImageEngineImage(stream.ToArray());
                    img.Save(path + @"\" + subImage.name + "." + extension, ImageEngineFormat.DDS_DXT3, MipHandling.KeepExisting, 0, 0, false);
                }
            }
            catch (Exception e)
            {
                LogManager.Instance.MsgError("Could not save image " + path + @"\" + subImage.name + "." + extension
                    + "\nError: " + e.Message);
            }
        }
    }
}
