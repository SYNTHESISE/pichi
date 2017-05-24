namespace File_Organiser_2.Forms
{
    partial class frmMovieScanImporter
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
            this.lstMovies = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblCheckAll = new System.Windows.Forms.Label();
            this.lblCheckNone = new System.Windows.Forms.Label();
            this.chkImportData = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMovies
            // 
            this.lstMovies.CheckOnClick = true;
            this.lstMovies.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMovies.FormattingEnabled = true;
            this.lstMovies.Location = new System.Drawing.Point(155, 12);
            this.lstMovies.Name = "lstMovies";
            this.lstMovies.Size = new System.Drawing.Size(1021, 412);
            this.lstMovies.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.lblCheckNone);
            this.panel1.Controls.Add(this.lblCheckAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 470);
            this.panel1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(1101, 435);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCheckAll
            // 
            this.lblCheckAll.AutoSize = true;
            this.lblCheckAll.Location = new System.Drawing.Point(12, 27);
            this.lblCheckAll.Name = "lblCheckAll";
            this.lblCheckAll.Size = new System.Drawing.Size(74, 21);
            this.lblCheckAll.TabIndex = 0;
            this.lblCheckAll.Text = "Check All";
            this.lblCheckAll.Click += new System.EventHandler(this.lblCheckAll_Click);
            this.lblCheckAll.MouseEnter += new System.EventHandler(this.lblCheckAll_MouseEnter);
            this.lblCheckAll.MouseLeave += new System.EventHandler(this.lblCheckAll_MouseLeave);
            // 
            // lblCheckNone
            // 
            this.lblCheckNone.AutoSize = true;
            this.lblCheckNone.Location = new System.Drawing.Point(12, 58);
            this.lblCheckNone.Name = "lblCheckNone";
            this.lblCheckNone.Size = new System.Drawing.Size(94, 21);
            this.lblCheckNone.TabIndex = 1;
            this.lblCheckNone.Text = "Check None";
            this.lblCheckNone.Click += new System.EventHandler(this.lblCheckNone_Click);
            this.lblCheckNone.MouseEnter += new System.EventHandler(this.lblCheckAll_MouseEnter);
            this.lblCheckNone.MouseLeave += new System.EventHandler(this.lblCheckAll_MouseLeave);
            // 
            // chkImportData
            // 
            this.chkImportData.AutoSize = true;
            this.chkImportData.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImportData.Location = new System.Drawing.Point(155, 433);
            this.chkImportData.Name = "chkImportData";
            this.chkImportData.Size = new System.Drawing.Size(201, 25);
            this.chkImportData.TabIndex = 3;
            this.chkImportData.Text = "Import TheMovieDB Data";
            this.chkImportData.UseVisualStyleBackColor = true;
            // 
            // frmMovieScanImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1188, 470);
            this.Controls.Add(this.chkImportData);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstMovies);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1204, 509);
            this.MinimumSize = new System.Drawing.Size(1204, 509);
            this.Name = "frmMovieScanImporter";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "frmMovieScanImporter";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstMovies;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblCheckNone;
        private System.Windows.Forms.Label lblCheckAll;
        private System.Windows.Forms.CheckBox chkImportData;
    }
}