namespace File_Organiser_2
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.lstAllMovies = new System.Windows.Forms.ListView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tVShowsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sortModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theMovieDBImportingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tVShowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playMovieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMovieCount = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstAllMovies
            // 
            this.lstAllMovies.AllowDrop = true;
            this.lstAllMovies.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstAllMovies.Location = new System.Drawing.Point(12, 67);
            this.lstAllMovies.Name = "lstAllMovies";
            this.lstAllMovies.Size = new System.Drawing.Size(582, 550);
            this.lstAllMovies.TabIndex = 0;
            this.lstAllMovies.TileSize = new System.Drawing.Size(550, 23);
            this.lstAllMovies.UseCompatibleStateImageBehavior = false;
            this.lstAllMovies.View = System.Windows.Forms.View.Tile;
            this.lstAllMovies.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.lstAllMovies.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.lstAllMovies.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstAllMovies_MouseClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(373, 41);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(221, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(323, 43);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(50, 17);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.manageToolStripMenuItem1,
            this.sortModeToolStripMenuItem,
            this.theMovieDBImportingToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.filterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(606, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // manageToolStripMenuItem1
            // 
            this.manageToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moviesToolStripMenuItem,
            this.tVShowsToolStripMenuItem1});
            this.manageToolStripMenuItem1.Name = "manageToolStripMenuItem1";
            this.manageToolStripMenuItem1.Size = new System.Drawing.Size(62, 20);
            this.manageToolStripMenuItem1.Text = "Manage";
            // 
            // moviesToolStripMenuItem
            // 
            this.moviesToolStripMenuItem.Name = "moviesToolStripMenuItem";
            this.moviesToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.moviesToolStripMenuItem.Text = "Movies";
            // 
            // tVShowsToolStripMenuItem1
            // 
            this.tVShowsToolStripMenuItem1.Name = "tVShowsToolStripMenuItem1";
            this.tVShowsToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.tVShowsToolStripMenuItem1.Text = "TV Shows";
            // 
            // sortModeToolStripMenuItem
            // 
            this.sortModeToolStripMenuItem.Name = "sortModeToolStripMenuItem";
            this.sortModeToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.sortModeToolStripMenuItem.Text = "Sort Mode";
            // 
            // theMovieDBImportingToolStripMenuItem
            // 
            this.theMovieDBImportingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moviesToolStripMenuItem1,
            this.tVShowsToolStripMenuItem});
            this.theMovieDBImportingToolStripMenuItem.Name = "theMovieDBImportingToolStripMenuItem";
            this.theMovieDBImportingToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.theMovieDBImportingToolStripMenuItem.Text = "Batch Importing";
            // 
            // moviesToolStripMenuItem1
            // 
            this.moviesToolStripMenuItem1.Name = "moviesToolStripMenuItem1";
            this.moviesToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.moviesToolStripMenuItem1.Text = "Movies";
            this.moviesToolStripMenuItem1.Click += new System.EventHandler(this.moviesToolStripMenuItem1_Click);
            // 
            // tVShowsToolStripMenuItem
            // 
            this.tVShowsToolStripMenuItem.Name = "tVShowsToolStripMenuItem";
            this.tVShowsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.tVShowsToolStripMenuItem.Text = "TV Shows";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageToolStripMenuItem,
            this.playMovieToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 48);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.manageToolStripMenuItem.Text = "Manage";
            this.manageToolStripMenuItem.Click += new System.EventHandler(this.manageToolStripMenuItem_Click);
            // 
            // playMovieToolStripMenuItem
            // 
            this.playMovieToolStripMenuItem.Name = "playMovieToolStripMenuItem";
            this.playMovieToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.playMovieToolStripMenuItem.Text = "Play Movie";
            this.playMovieToolStripMenuItem.Click += new System.EventHandler(this.playMovieToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(577, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblMovieCount
            // 
            this.lblMovieCount.AutoSize = true;
            this.lblMovieCount.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieCount.Location = new System.Drawing.Point(12, 37);
            this.lblMovieCount.Name = "lblMovieCount";
            this.lblMovieCount.Size = new System.Drawing.Size(85, 25);
            this.lblMovieCount.TabIndex = 6;
            this.lblMovieCount.Text = "0 Movies";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(606, 629);
            this.Controls.Add(this.lblMovieCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lstAllMovies);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstAllMovies;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMovieCount;
        private System.Windows.Forms.ToolStripMenuItem playMovieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sortModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moviesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theMovieDBImportingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tVShowsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moviesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tVShowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
    }
}

