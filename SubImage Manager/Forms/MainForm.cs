using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SubImage_Manager.Scripts;
using System.Drawing.Drawing2D;

namespace SubImage_Manager.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        //These variables control the mouse position
        int selectX;
        int selectY;
        public Pen selectPen;

        //This variable control when you start the right click
        bool start = false;
        private void DisplayImageMouseMove(object sender, MouseEventArgs e)
        {
            //validate if there is an image
            if (ImageManager.Instance.image == null)
                return;

            //validate if right-click was trigger
            if (start)
            {

                Point NewPoint = e.Location;

                //refresh picture box
                displayImageBox.Refresh();

                int drawX, drawY, drawWidth, drawHeight;

                //set corner square to mouse coordinates
                if (e.X > selectX)
                {
                    drawX = selectX;
                    drawWidth = e.X - selectX;
                }
                else
                {
                    drawX = e.X;
                    drawWidth = selectX - e.X;
                }

                if (e.Y > selectY)
                {
                    drawY = selectY;
                    drawHeight = e.Y - selectY;
                }
                else
                {
                    drawY = e.Y;
                    drawHeight = selectY - e.Y;
                }

                if (!((PictureBox)sender).ClientRectangle.Contains(NewPoint))
                {
                    if (e.X > displayImageBox.ClientRectangle.Right)
                        drawWidth = displayImageBox.Width - selectX - 1;

                    if (e.Y > displayImageBox.ClientRectangle.Bottom)
                    {
                        drawHeight = displayImageBox.Height - selectY - 1;
                    }

                    if (e.X < displayImageBox.ClientRectangle.Left)
                    {
                        drawWidth = selectX;
                        drawX = displayImageBox.ClientRectangle.Left;
                    }
                    

                    if (e.Y < displayImageBox.ClientRectangle.Top)
                    {
                        drawHeight = selectY;
                        drawY = displayImageBox.ClientRectangle.Top;
                    }
                }


                //draw dotted rectangle
                displayImageBox.CreateGraphics().DrawRectangle(selectPen,
                          drawX, drawY, drawWidth, drawHeight);

                widthLabel.Text = "Width: " + drawWidth;
                heightLabel.Text = "Height: " + drawHeight;
                xLabel.Text = "X: " + e.X;
                yLabel.Text = "Y: " + e.Y;

            }
        }

        private void DisplayImageMouseDown(object sender, MouseEventArgs e)
        {
            //validate if there is image
            if (ImageManager.Instance.image == null)
                return;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //starts coordinates for rectangle
                selectX = e.X;
                selectY = e.Y;
                selectPen = new Pen(Color.Green, 1);
                selectPen.DashStyle = DashStyle.Solid;
            }

            //refresh picture box
            displayImageBox.Refresh();
            //start control variable for draw rectangle
            start = true;
        }

        private void DisplayImageMouseUp(object sender, MouseEventArgs e)
        {
            start = false;
        }

        private void DisplayImageMouseEnter(object sender, EventArgs e)
        {
            //Change to Cross Cursor
            Cursor = Cursors.Cross;
        }

        private void DisplayImageMouseLeave(object sender, EventArgs e)
        {
            //Change to Cross Cursor
            Cursor = Cursors.Default;
        }

        private void DisplayImagePaint(object sender, PaintEventArgs e)
        {
            if (ImageManager.Instance.image == null)
                return;

            Graphics g = e.Graphics;
            Bitmap image = ImageManager.Instance.GetImage();
            g.DrawImage(image, 0, 0);

            for (int i = 0; i < SubImageManager.Instance.subImageList.Count(); i++)
			{
                SubImage subImage = SubImageManager.Instance.subImageList[i];

			    int top = 0, bottom = 0, left = 0, right = 0, width = 0, height = 0;

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

                width = right - left;
                height = bottom - top;
                Rectangle rect = Rectangle.FromLTRB(left, top, right, bottom);

                Pen pen;
                if (SubImageManager.Instance.selectedSubIndex == i)
                    pen = new Pen(Color.Green, 2);
                else
                    pen = new Pen(Color.Red, 1);

                g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
			}

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ImageManager.Instance.image != null)
            {
                var window = MessageBox.Show("Close the window?", "Are you sure?", MessageBoxButtons.YesNo);
                e.Cancel = window == DialogResult.No;
            }
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIManager.Instance.LoadLocalImageFile();
        }

        private void openSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIManager.Instance.LoadLocalSubFile();
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogManager.Instance.MsgLog("Credits", "SubImage Manager\n\nVersion 1.0\nCreator: NewWars");
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIManager.Instance.SaveAllSubImages();
        }

        private void saveSubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIManager.Instance.SaveSubImage();
        }
    }
}
