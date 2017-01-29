namespace SubImage_Manager.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.widthLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.heightLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.xLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.yLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.FileToolStripDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ImageToolStripDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SubImageStripDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.createSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutToolStripDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayImageBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatusStrip.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayImageBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.widthLabel,
            this.heightLabel,
            this.xLabel,
            this.yLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 271);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.StatusStrip.Size = new System.Drawing.Size(389, 22);
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "status";
            // 
            // widthLabel
            // 
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(42, 17);
            this.widthLabel.Text = "Width:";
            // 
            // heightLabel
            // 
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(46, 17);
            this.heightLabel.Text = "Height:";
            // 
            // xLabel
            // 
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(17, 17);
            this.xLabel.Text = "X:";
            // 
            // yLabel
            // 
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(17, 17);
            this.yLabel.Text = "Y:";
            // 
            // ToolStrip
            // 
            this.ToolStrip.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripDropDown,
            this.toolStripSeparator2,
            this.ImageToolStripDropDown,
            this.toolStripSeparator3,
            this.SubImageStripDropDown,
            this.toolStripSeparator1,
            this.AboutToolStripDropDown});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(389, 25);
            this.ToolStrip.TabIndex = 1;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // FileToolStripDropDown
            // 
            this.FileToolStripDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileToolStripDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.openSubToolStripMenuItem,
            this.saveSubToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.saveToolStripMenuItem1});
            this.FileToolStripDropDown.Image = ((System.Drawing.Image)(resources.GetObject("FileToolStripDropDown.Image")));
            this.FileToolStripDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileToolStripDropDown.Name = "FileToolStripDropDown";
            this.FileToolStripDropDown.Size = new System.Drawing.Size(38, 22);
            this.FileToolStripDropDown.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openImageToolStripMenuItem.Text = "Open Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // openSubToolStripMenuItem
            // 
            this.openSubToolStripMenuItem.Name = "openSubToolStripMenuItem";
            this.openSubToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openSubToolStripMenuItem.Text = "Open Sub";
            this.openSubToolStripMenuItem.Click += new System.EventHandler(this.openSubToolStripMenuItem_Click);
            // 
            // saveSubToolStripMenuItem
            // 
            this.saveSubToolStripMenuItem.Name = "saveSubToolStripMenuItem";
            this.saveSubToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveSubToolStripMenuItem.Text = "Save Sub As";
            this.saveSubToolStripMenuItem.Click += new System.EventHandler(this.saveSubToolStripMenuItem_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveAllToolStripMenuItem.Text = "Save All Subs As";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.saveToolStripMenuItem1.Text = "Exit";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ImageToolStripDropDown
            // 
            this.ImageToolStripDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ImageToolStripDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.resizeImageToolStripMenuItem,
            this.toolStripMenuItem9});
            this.ImageToolStripDropDown.Image = ((System.Drawing.Image)(resources.GetObject("ImageToolStripDropDown.Image")));
            this.ImageToolStripDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ImageToolStripDropDown.Name = "ImageToolStripDropDown";
            this.ImageToolStripDropDown.Size = new System.Drawing.Size(53, 22);
            this.ImageToolStripDropDown.Text = "Image";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem8.Text = "Add Image";
            // 
            // resizeImageToolStripMenuItem
            // 
            this.resizeImageToolStripMenuItem.Name = "resizeImageToolStripMenuItem";
            this.resizeImageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resizeImageToolStripMenuItem.Text = "Resize Image";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem9.Text = "Cut Selection";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // SubImageStripDropDown
            // 
            this.SubImageStripDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SubImageStripDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createSubToolStripMenuItem,
            this.editSubToolStripMenuItem,
            this.removeSubToolStripMenuItem});
            this.SubImageStripDropDown.Image = ((System.Drawing.Image)(resources.GetObject("SubImageStripDropDown.Image")));
            this.SubImageStripDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SubImageStripDropDown.Name = "SubImageStripDropDown";
            this.SubImageStripDropDown.Size = new System.Drawing.Size(76, 22);
            this.SubImageStripDropDown.Text = "Sub Image";
            // 
            // createSubToolStripMenuItem
            // 
            this.createSubToolStripMenuItem.Name = "createSubToolStripMenuItem";
            this.createSubToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.createSubToolStripMenuItem.Text = "Create Sub";
            // 
            // editSubToolStripMenuItem
            // 
            this.editSubToolStripMenuItem.Name = "editSubToolStripMenuItem";
            this.editSubToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.editSubToolStripMenuItem.Text = "Edit Sub";
            // 
            // removeSubToolStripMenuItem
            // 
            this.removeSubToolStripMenuItem.Name = "removeSubToolStripMenuItem";
            this.removeSubToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.removeSubToolStripMenuItem.Text = "Remove Sub";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // AboutToolStripDropDown
            // 
            this.AboutToolStripDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AboutToolStripDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.creditsToolStripMenuItem});
            this.AboutToolStripDropDown.Image = ((System.Drawing.Image)(resources.GetObject("AboutToolStripDropDown.Image")));
            this.AboutToolStripDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AboutToolStripDropDown.Name = "AboutToolStripDropDown";
            this.AboutToolStripDropDown.Size = new System.Drawing.Size(53, 22);
            this.AboutToolStripDropDown.Text = "About";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // displayImageBox
            // 
            this.displayImageBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.displayImageBox.Location = new System.Drawing.Point(52, 40);
            this.displayImageBox.Name = "displayImageBox";
            this.displayImageBox.Size = new System.Drawing.Size(266, 170);
            this.displayImageBox.TabIndex = 7;
            this.displayImageBox.TabStop = false;
            this.displayImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayImagePaint);
            this.displayImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DisplayImageMouseDown);
            this.displayImageBox.MouseEnter += new System.EventHandler(this.DisplayImageMouseEnter);
            this.displayImageBox.MouseLeave += new System.EventHandler(this.DisplayImageMouseLeave);
            this.displayImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DisplayImageMouseMove);
            this.displayImageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisplayImageMouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.displayImageBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 246);
            this.panel1.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 293);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.StatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubImage Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayImageBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel widthLabel;
        private System.Windows.Forms.ToolStripStatusLabel heightLabel;
        private System.Windows.Forms.ToolStripStatusLabel xLabel;
        private System.Windows.Forms.ToolStripStatusLabel yLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton FileToolStripDropDown;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton AboutToolStripDropDown;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem resizeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem createSubToolStripMenuItem;
        public System.Windows.Forms.PictureBox displayImageBox;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ToolStrip ToolStrip;
        public System.Windows.Forms.ToolStripMenuItem openSubToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveSubToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        public System.Windows.Forms.ToolStripDropDownButton SubImageStripDropDown;
        public System.Windows.Forms.ToolStripDropDownButton ImageToolStripDropDown;
        public System.Windows.Forms.ToolStripMenuItem editSubToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem removeSubToolStripMenuItem;

    }
}

