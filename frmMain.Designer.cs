namespace JonasJohn.Tools.Files2Text
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.label2 = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.fcFolder = new JonasJohn.Controls.FolderChooser();
			this.label1 = new System.Windows.Forms.Label();
			this.btnExit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Choose a folder:";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(12, 101);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(129, 23);
			this.btnStart.TabIndex = 9;
			this.btnStart.Text = "&Create text file";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// fcFolder
			// 
			this.fcFolder.Folder = ((System.IO.DirectoryInfo)(resources.GetObject("fcFolder.Folder")));
			this.fcFolder.Location = new System.Drawing.Point(12, 64);
			this.fcFolder.Name = "fcFolder";
			this.fcFolder.Size = new System.Drawing.Size(304, 21);
			this.fcFolder.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(307, 30);
			this.label1.TabIndex = 14;
			this.label1.Text = "This tool copies all filenames of a given folder into a text file and renames the" +
				" changed files afterwards.";
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(147, 101);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(98, 23);
			this.btnExit.TabIndex = 16;
			this.btnExit.Text = "&Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(328, 131);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.fcFolder);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnStart);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Files2Text";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private JonasJohn.Controls.FolderChooser fcFolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnExit;
    }
}

