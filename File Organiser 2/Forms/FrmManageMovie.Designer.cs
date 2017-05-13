namespace File_Organiser_2
{
    partial class FrmManageMovie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmManageMovie));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateBackdropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theMovieDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInTheMovieDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCollection = new System.Windows.Forms.Label();
            this.lblGenres = new System.Windows.Forms.Label();
            this.lblOverview = new System.Windows.Forms.Label();
            this.lblDateAndRunningTime = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblVote = new System.Windows.Forms.Label();
            this.pnlContent1 = new System.Windows.Forms.Panel();
            this.lblActors = new System.Windows.Forms.Label();
            this.pnlBackdrop = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlContent1.SuspendLayout();
            this.pnlBackdrop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(246, 372);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(7, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(223, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "A Clockwork Orange";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.theMovieDBToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateBackdropToolStripMenuItem,
            this.generateOverviewToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // generateBackdropToolStripMenuItem
            // 
            this.generateBackdropToolStripMenuItem.Name = "generateBackdropToolStripMenuItem";
            this.generateBackdropToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.generateBackdropToolStripMenuItem.Text = "GenerateBackdrop";
            this.generateBackdropToolStripMenuItem.Click += new System.EventHandler(this.generateBackdropToolStripMenuItem_Click);
            // 
            // generateOverviewToolStripMenuItem
            // 
            this.generateOverviewToolStripMenuItem.Name = "generateOverviewToolStripMenuItem";
            this.generateOverviewToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.generateOverviewToolStripMenuItem.Text = "Generate Overview";
            this.generateOverviewToolStripMenuItem.Click += new System.EventHandler(this.generateOverviewToolStripMenuItem_Click);
            // 
            // theMovieDBToolStripMenuItem
            // 
            this.theMovieDBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDataToolStripMenuItem,
            this.openInTheMovieDBToolStripMenuItem});
            this.theMovieDBToolStripMenuItem.Name = "theMovieDBToolStripMenuItem";
            this.theMovieDBToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.theMovieDBToolStripMenuItem.Text = "The Movie DB";
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.importDataToolStripMenuItem.Text = "Import Data";
            this.importDataToolStripMenuItem.Click += new System.EventHandler(this.importDataToolStripMenuItem_Click);
            // 
            // openInTheMovieDBToolStripMenuItem
            // 
            this.openInTheMovieDBToolStripMenuItem.Name = "openInTheMovieDBToolStripMenuItem";
            this.openInTheMovieDBToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openInTheMovieDBToolStripMenuItem.Text = "Open in TheMovieDB";
            this.openInTheMovieDBToolStripMenuItem.Click += new System.EventHandler(this.openInTheMovieDBToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // lblCollection
            // 
            this.lblCollection.AutoSize = true;
            this.lblCollection.BackColor = System.Drawing.Color.Transparent;
            this.lblCollection.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollection.Location = new System.Drawing.Point(82, 36);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.Size = new System.Drawing.Size(148, 17);
            this.lblCollection.TabIndex = 3;
            this.lblCollection.Text = "21 Jump Street Collection";
            // 
            // lblGenres
            // 
            this.lblGenres.AutoSize = true;
            this.lblGenres.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenres.ForeColor = System.Drawing.Color.White;
            this.lblGenres.Location = new System.Drawing.Point(4, 6);
            this.lblGenres.MaximumSize = new System.Drawing.Size(600, 17);
            this.lblGenres.MinimumSize = new System.Drawing.Size(600, 17);
            this.lblGenres.Name = "lblGenres";
            this.lblGenres.Size = new System.Drawing.Size(600, 17);
            this.lblGenres.TabIndex = 4;
            this.lblGenres.Text = "ACTION | THRILLER | CRIME";
            // 
            // lblOverview
            // 
            this.lblOverview.AutoEllipsis = true;
            this.lblOverview.AutoSize = true;
            this.lblOverview.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverview.Location = new System.Drawing.Point(3, 149);
            this.lblOverview.MaximumSize = new System.Drawing.Size(616, 100);
            this.lblOverview.MinimumSize = new System.Drawing.Size(616, 100);
            this.lblOverview.Name = "lblOverview";
            this.lblOverview.Size = new System.Drawing.Size(616, 100);
            this.lblOverview.TabIndex = 5;
            this.lblOverview.Text = "Overview";
            // 
            // lblDateAndRunningTime
            // 
            this.lblDateAndRunningTime.AutoSize = true;
            this.lblDateAndRunningTime.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateAndRunningTime.Location = new System.Drawing.Point(3, 29);
            this.lblDateAndRunningTime.Name = "lblDateAndRunningTime";
            this.lblDateAndRunningTime.Size = new System.Drawing.Size(135, 21);
            this.lblDateAndRunningTime.TabIndex = 6;
            this.lblDateAndRunningTime.Text = "1972    137 minutes";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(7, 59);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // lblVote
            // 
            this.lblVote.AutoSize = true;
            this.lblVote.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVote.Location = new System.Drawing.Point(35, 60);
            this.lblVote.Name = "lblVote";
            this.lblVote.Size = new System.Drawing.Size(22, 25);
            this.lblVote.TabIndex = 8;
            this.lblVote.Text = "8";
            // 
            // pnlContent1
            // 
            this.pnlContent1.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent1.Controls.Add(this.lblActors);
            this.pnlContent1.Controls.Add(this.lblGenres);
            this.pnlContent1.Controls.Add(this.lblVote);
            this.pnlContent1.Controls.Add(this.lblOverview);
            this.pnlContent1.Controls.Add(this.pictureBox2);
            this.pnlContent1.Controls.Add(this.lblDateAndRunningTime);
            this.pnlContent1.Location = new System.Drawing.Point(7, 56);
            this.pnlContent1.Name = "pnlContent1";
            this.pnlContent1.Size = new System.Drawing.Size(632, 308);
            this.pnlContent1.TabIndex = 9;
            // 
            // lblActors
            // 
            this.lblActors.AutoEllipsis = true;
            this.lblActors.AutoSize = true;
            this.lblActors.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActors.Location = new System.Drawing.Point(2, 89);
            this.lblActors.MaximumSize = new System.Drawing.Size(616, 50);
            this.lblActors.MinimumSize = new System.Drawing.Size(616, 50);
            this.lblActors.Name = "lblActors";
            this.lblActors.Size = new System.Drawing.Size(616, 50);
            this.lblActors.TabIndex = 9;
            this.lblActors.Text = "actor1, actor 2";
            // 
            // pnlBackdrop
            // 
            this.pnlBackdrop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBackdrop.Controls.Add(this.lblCollection);
            this.pnlBackdrop.Controls.Add(this.pnlContent1);
            this.pnlBackdrop.Controls.Add(this.lblTitle);
            this.pnlBackdrop.Location = new System.Drawing.Point(245, 24);
            this.pnlBackdrop.Name = "pnlBackdrop";
            this.pnlBackdrop.Size = new System.Drawing.Size(639, 372);
            this.pnlBackdrop.TabIndex = 10;
            // 
            // FrmManageMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(884, 396);
            this.Controls.Add(this.pnlBackdrop);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmManageMovie";
            this.Text = "FrmManageMovie";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlContent1.ResumeLayout(false);
            this.pnlContent1.PerformLayout();
            this.pnlBackdrop.ResumeLayout(false);
            this.pnlBackdrop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theMovieDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.Label lblCollection;
        private System.Windows.Forms.Label lblGenres;
        private System.Windows.Forms.Label lblOverview;
        private System.Windows.Forms.Label lblDateAndRunningTime;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblVote;
        private System.Windows.Forms.Panel pnlContent1;
        private System.Windows.Forms.ToolStripMenuItem openInTheMovieDBToolStripMenuItem;
        private System.Windows.Forms.Panel pnlBackdrop;
        private System.Windows.Forms.ToolStripMenuItem generateBackdropToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateOverviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Label lblActors;
    }
}