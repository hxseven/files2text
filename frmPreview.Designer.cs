namespace JonasJohn.Tools.Files2Text
{
	partial class frmPreview
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
            this.lvChangedFileNames = new System.Windows.Forms.ListView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRenameFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvChangedFileNames
            // 
            this.lvChangedFileNames.FullRowSelect = true;
            this.lvChangedFileNames.GridLines = true;
            this.lvChangedFileNames.Location = new System.Drawing.Point(12, 12);
            this.lvChangedFileNames.Name = "lvChangedFileNames";
            this.lvChangedFileNames.Size = new System.Drawing.Size(478, 230);
            this.lvChangedFileNames.TabIndex = 0;
            this.lvChangedFileNames.UseCompatibleStateImageBehavior = false;
            this.lvChangedFileNames.View = System.Windows.Forms.View.Details;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(113, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRenameFiles
            // 
            this.btnRenameFiles.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRenameFiles.Location = new System.Drawing.Point(12, 248);
            this.btnRenameFiles.Name = "btnRenameFiles";
            this.btnRenameFiles.Size = new System.Drawing.Size(95, 23);
            this.btnRenameFiles.TabIndex = 1;
            this.btnRenameFiles.Text = "&Rename files";
            this.btnRenameFiles.UseVisualStyleBackColor = true;
            // 
            // frmPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 279);
            this.Controls.Add(this.btnRenameFiles);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lvChangedFileNames);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preview";
            this.Load += new System.EventHandler(this.frmPreview_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lvChangedFileNames;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnRenameFiles;
	}
}