namespace GroupDocs.Viewer.Forms.UI
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openFileBtn = new System.Windows.Forms.ToolStripButton();
            this.firstPageBtn = new System.Windows.Forms.ToolStripButton();
            this.prevPageBtn = new System.Windows.Forms.ToolStripButton();
            this.pagesStatusLabel = new System.Windows.Forms.ToolStripLabel();
            this.nextPageBtn = new System.Windows.Forms.ToolStripButton();
            this.lastPageBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.licenseStatusLabel = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            //this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 39, 3, 3);
            this.pictureBox.MinimumSize = new System.Drawing.Size(20, 39);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(823, 666);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileBtn,
            this.firstPageBtn,
            this.prevPageBtn,
            this.pagesStatusLabel,
            this.nextPageBtn,
            this.lastPageBtn,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.licenseStatusLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(823, 39);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openFileBtn
            // 
            this.openFileBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openFileBtn.Image = global::GroupsDocs.Viewer.Forms.UI.Properties.Resources.open_file;
            this.openFileBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(36, 36);
            this.openFileBtn.Text = "Open file";
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // firstPageBtn
            // 
            this.firstPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.firstPageBtn.Image = global::GroupsDocs.Viewer.Forms.UI.Properties.Resources.first;
            this.firstPageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.firstPageBtn.Name = "firstPageBtn";
            this.firstPageBtn.Size = new System.Drawing.Size(36, 36);
            this.firstPageBtn.Text = "First page";
            this.firstPageBtn.Click += new System.EventHandler(this.FirstPageBtn_Click);
            // 
            // prevPageBtn
            // 
            this.prevPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prevPageBtn.Image = global::GroupsDocs.Viewer.Forms.UI.Properties.Resources.prev;
            this.prevPageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.prevPageBtn.Name = "prevPageBtn";
            this.prevPageBtn.Size = new System.Drawing.Size(36, 36);
            this.prevPageBtn.Text = "Previous page";
            this.prevPageBtn.Click += new System.EventHandler(this.PrevPageBtn_Click);
            // 
            // pagesStatusLabel
            // 
            this.pagesStatusLabel.Name = "pagesStatusLabel";
            this.pagesStatusLabel.Size = new System.Drawing.Size(22, 36);
            this.pagesStatusLabel.Text = "     ";
            // 
            // nextPageBtn
            // 
            this.nextPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextPageBtn.Image = global::GroupsDocs.Viewer.Forms.UI.Properties.Resources.next;
            this.nextPageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextPageBtn.Name = "nextPageBtn";
            this.nextPageBtn.Size = new System.Drawing.Size(36, 36);
            this.nextPageBtn.Text = "Next page";
            this.nextPageBtn.Click += new System.EventHandler(this.NextPageBtn_Click);
            // 
            // lastPageBtn
            // 
            this.lastPageBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lastPageBtn.Image = global::GroupsDocs.Viewer.Forms.UI.Properties.Resources.last;
            this.lastPageBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lastPageBtn.Name = "lastPageBtn";
            this.lastPageBtn.Size = new System.Drawing.Size(36, 36);
            this.lastPageBtn.Text = "Last page";
            this.lastPageBtn.Click += new System.EventHandler(this.LastPageBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(83, 36);
            this.toolStripLabel2.Text = "License status:";
            // 
            // licenseStatusLabel
            // 
            this.licenseStatusLabel.Name = "licenseStatusLabel";
            this.licenseStatusLabel.Size = new System.Drawing.Size(73, 36);
            this.licenseStatusLabel.Text = "Not licensed";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 666);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 705);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(839, 744);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Viewer for .NET Windows Forms";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton openFileBtn;
        private System.Windows.Forms.ToolStripButton firstPageBtn;
        private System.Windows.Forms.ToolStripButton prevPageBtn;
        private System.Windows.Forms.ToolStripButton nextPageBtn;
        private System.Windows.Forms.ToolStripButton lastPageBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel licenseStatusLabel;
        private System.Windows.Forms.ToolStripLabel pagesStatusLabel;
        private System.Windows.Forms.Panel panel1;
    }
}

