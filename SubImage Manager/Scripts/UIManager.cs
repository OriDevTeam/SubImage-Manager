using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SubImage_Manager.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace SubImage_Manager.Scripts
{
    class UIManager
    {
        //////////////////////////////////////////////////////////////////
        ///// Constructor
        public static readonly UIManager Instance = new UIManager();
        public MainForm MainForm;

        static bool wokeUp = false;

        public void WakeUp()
        {
            if (!wokeUp)
            {
                wokeUp = true;

                MakeUIForm();
                LoadSettingsForm();
            }
        }

        //////////////////////////////////////////////////////////////////
        ///// UI Preparing Operations

        public void MakeUIForm()
        {
            MainForm.MaximizeBox = false;
            MainForm.openSubToolStripMenuItem.Enabled = false;
            MainForm.saveSubToolStripMenuItem.Enabled = false;
            MainForm.saveAllToolStripMenuItem.Enabled = false;
            MainForm.SubImageStripDropDown.Enabled = false;
            MainForm.ImageToolStripDropDown.Enabled = false;
        }

        public void LoadSettingsForm()
        {
            /*
            SettingsForm.windowsStartCheckBox.Checked = SettingsManager.Instance.GetBool(SettingsOptions.START_AT_WINDOWS_KEYWORD);
            SettingsForm.minimizedStartCheckBox.Checked = SettingsManager.Instance.GetBool(SettingsOptions.START_MINIMIZED_KEYWORD);
            SettingsForm.trayIconShowCheckBox.Checked = SettingsManager.Instance.GetBool(SettingsOptions.SHOW_TRAY_ICON_KEYWORD);
            SettingsForm.screenCaptureUploadCheckBox.Checked = SettingsManager.Instance.GetBool(SettingsOptions.AUTOMATIC_UPLOAD_ON_CUT_KEYWORD);

            SettingsForm.autoUpdateCheckBox.Checked = SettingsManager.Instance.GetBool(SettingsOptions.AUTOMATIC_UPDATE_KEYWORD);
            SettingsForm.notifyUpdateCheckBox.Checked = SettingsManager.Instance.GetBool(SettingsOptions.NOTIFY_UPDATE_KEYWORD);
            SettingsForm.notifyTestVersionsCheckBox.Checked = SettingsManager.Instance.GetBool(SettingsOptions.NOTIFY_TESTS_KEYWORD);

            SettingsForm.imageCaptureFormatComboBox.SelectedIndex = (int)SettingsManager.Instance.GetDouble(SettingsOptions.IMAGE_CUT_FORMAT_KEYWORD);
            */
        }

        public void LoadLocalImageFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Select an image file";

            ofd.AddExtension = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;

            ofd.DefaultExt = "*.dds";
            ofd.Filter = "DirectDraw Surface file (DDS) (*.dds)|*.dds|" +
                         "Portable Network Graphics (PNG) (*.png)|*.png|" +
                         "Truevision Targa (TGA) (*.tga)|*.tga";

            ofd.InitialDirectory = Environment.SpecialFolder.DesktopDirectory.ToString();

            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            ImageManager.Instance.SetImage(ofd.FileName);
        }

        public void LoadLocalSubFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Select a sub file";

            ofd.AddExtension = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;

            ofd.DefaultExt = "*.sub";
            ofd.Filter = "SubImage File (SUB) (*.sub)|*.sub";

            ofd.InitialDirectory = Environment.SpecialFolder.DesktopDirectory.ToString();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            SubImageManager.Instance.loadingSubs = true;
            foreach (var filePath in ofd.FileNames)
            {
                SubImage subImage;
                if (SubImageParser.ReadSubImageFile(filePath, out subImage))
                    SubImageManager.Instance.AddSubImage(subImage);
            }
            SubImageManager.Instance.loadingSubs = false;
            UIManager.Instance.RefreshUI();
        }

        public void SaveSubImage()
        {
            SaveFileDialog sf = new SaveFileDialog();

            sf.FileName = "Select a folder to save";

            if (sf.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            string savePath = Path.GetDirectoryName(sf.FileName);

            SubImageManager.Instance.SaveSelectedSubImage(savePath);
        }

        public void SaveAllSubImages()
        {
            SaveFileDialog sf = new SaveFileDialog();

            sf.FileName = "Select a folder to save";

            if (sf.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            string savePath = Path.GetDirectoryName(sf.FileName);
            SubImageManager.Instance.SaveAllSubImages(savePath);
        }

        //////////////////////////////////////////////////////////////////
        ///// Manager Operations

        public void RefreshUI()
        {
            if (SubImageManager.Instance.loadingSubs)
                return;

            if(ImageManager.Instance.image != null)
            {
                MainForm.openSubToolStripMenuItem.Enabled = true;
                MainForm.saveSubToolStripMenuItem.Enabled = true;
                MainForm.saveAllToolStripMenuItem.Enabled = true;
                MainForm.SubImageStripDropDown.Enabled = true;
                MainForm.ImageToolStripDropDown.Enabled = true;
            }

            if(SubImageManager.Instance.subImageList.Count() == 0)
            {
                MainForm.editSubToolStripMenuItem.Enabled = false;
                MainForm.removeSubToolStripMenuItem.Enabled = false;
            }
            else
            {
                MainForm.editSubToolStripMenuItem.Enabled = true;
                MainForm.removeSubToolStripMenuItem.Enabled = true;
                MainForm.editSubToolStripMenuItem.DropDownItems.Clear();
                MainForm.removeSubToolStripMenuItem.DropDownItems.Clear();

                for (int i = 0; i < SubImageManager.Instance.subImageList.Count; i++)
                {
                    SubImage subImage = SubImageManager.Instance.subImageList[i];

                    ToolStripMenuItem removeOption = new ToolStripMenuItem();
                    removeOption.Text = subImage.name;
                    removeOption.Tag = i;
                    removeOption.MouseUp += OnRemoveSubClick;


                    ToolStripMenuItem editOption = new ToolStripMenuItem();
                    editOption.Text = subImage.name;
                    editOption.Tag = i;
                    editOption.MouseUp += OnEditSubClick;

                    if (SubImageManager.Instance.selectedSubIndex == i)
                    {
                        removeOption.Image = Properties.Resources._600px_Green_check_svg;
                        editOption.Image = Properties.Resources._600px_Green_check_svg;
                    }

                    MainForm.removeSubToolStripMenuItem.DropDownItems.Add(removeOption);
                    MainForm.editSubToolStripMenuItem.DropDownItems.Add(editOption);
                }
            }

            MainForm.displayImageBox.Invalidate();
        }

        public void ShowImage(Bitmap image)
        {
            int imageX = 0, imageY = 0;
            int width = 20, height = 10;

            if (image.Width < 405)
            {
                width += 405;
                imageX = (MainForm.panel1.Width / 2) - (image.Width / 2);
            }
            else
            {
                width += image.Width;
            }

            if (image.Height < 331)
            {
                height += 331;
                imageY = (MainForm.panel1.Height / 2) - (image.Height / 2);
            }
            else
            {
                height += image.Height;
            }

            MainForm.Size = new Size(width, height + 10);

            MainForm.displayImageBox.Location = new Point(imageX, imageY + 10);

            MainForm.displayImageBox.Size = new Size(image.Width, image.Height);

            RefreshUI();
        }

        public void ShowSettingsForm()
        {
            LoadSettingsForm();
            //SettingsForm.Show();
        }

        public void QuitUI()
        {
            if (MainForm == null)
                return;

            MainForm.Close();
            MainForm.Dispose();
        }

        public void HideUI()
        {
            if (MainForm == null)
                return;

            MainForm.Hide();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            //EditForm.Show();
        }

        //////////////////////////////////////////////////////////////////
        ///// Trigger Operations

        public string Result;
        public void OnLinkClick(object sender, EventArgs ea)
        {
            DialogResult msgbox = MessageBox.Show("Deseja abrir o URL no browser(Yes) ou copiar para a area de transferênçia(No)?", "Link da Imagem", MessageBoxButtons.YesNoCancel);

            if (msgbox == DialogResult.Yes)
                System.Diagnostics.Process.Start(Result);
            else if (msgbox == DialogResult.No)
                Clipboard.SetText(Result);
        }

        public void OnRemoveSubClick(object sender, MouseEventArgs e)
        {
            SubImageManager.Instance.RemoveSubImage((int)((ToolStripMenuItem)sender).Tag);
        }

        public void OnEditSubClick(object sender, EventArgs ea)
        {
        
        }
    }
}
