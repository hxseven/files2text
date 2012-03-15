using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

// File2Text - Source code
// http://code.google.com/p/files2text/

// Icon source:
// http://www.iconlet.com/info/8815_text_padding_bottom_16x16

namespace JonasJohn.Tools.Files2Text
{
    public partial class frmMain : Form
    {        
		
		#region [rgn] Fields (3)

		Process EditTextProcess;
		FileList FileList;

		#endregion [rgn]

		#region [rgn] Constructors (1)

		/// <summary>
		/// Initializes a new instance of the <see cref="frmMain"/> class.
		/// </summary>
        public frmMain()
        {
            InitializeComponent();
        }
		
		#endregion [rgn]

		#region [rgn] Methods (14)

		// [rgn] Public Methods (5)

		public void ClosedApplication() {

			if (MessageBox.Show(this, "Process the changed text file?", this.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
			{
				try
				{
					this.FileList.ReadTempFile();
				}
				catch (TempFileDoesNotExistException Ex)
				{
					ResetGui();
					this.Cleanup();
					MessageBox.Show(this, "The temporary file '" + Ex.Message + "' list could not be found!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				catch (LinesDontMatchException Ex)
				{
					ResetGui();
					this.Cleanup();
					MessageBox.Show(this, "The line count does not match file the file count!\n\nThe text file contains " + Ex.Message + " lines but there are " + this.FileList.GetFileCount().ToString() + " files.", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				catch (Exception Ex)
				{
					ResetGui();
					this.Cleanup();
					MessageBox.Show(this, "A error occured:\n" + Ex.Message, this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				this.Cleanup();

				this.PreviewRename();

			}
			else
			{
				ResetGui();
				this.Cleanup();
			}
		}		
		
		// [rgn] Private Methods (9)

		/// <summary>
		/// Handles the Click event of the btnStart control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnStart_Click(object sender, EventArgs e)
        {
			this.Start();
        }
		
		/// <summary>
		/// Handles the Click event of the button1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		/// <summary>
		/// Cleanups this instance.
		/// </summary>
		private void Cleanup()
		{
			try
			{
				this.FileList.CleanupTempFile();
			}
			catch (Exception Ex)
			{				
				MessageBox.Show(this, "A error occured while cleaning up:\n" + Ex.Message, this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}			
		}
		
		/// <summary>
		/// Handles the DragDrop event of the Form1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.DragEventArgs"/> instance containing the event data.</param>
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (s.Length == 1)
                this.fcFolder.Folder = new DirectoryInfo(s[0]);
       
        }
		
		/// <summary>
		/// Handles the DragEnter event of the Form1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.Forms.DragEventArgs"/> instance containing the event data.</param>
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            else
                e.Effect = DragDropEffects.Copy;		
        }
		
		/// <summary>
		/// Handles the Load event of the Form1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {

			this.Text += " - v" + this.ProductVersion.Substring(0, 7);

			string[] CommandLineArgs = Environment.GetCommandLineArgs();

			if (CommandLineArgs.Length > 1) {

				try
				{
					string folder = "";

					// silent mode
					if (CommandLineArgs[1].ToLower().Contains("-silent"))
					{
						folder = CommandLineArgs[2];
						
						//this.SilentMode = true;
					}
					else
						folder = CommandLineArgs[1];

					folder = folder.Trim('"');
					
					this.fcFolder.Folder = new DirectoryInfo(folder);

				}
				catch {
					//this.SilentMode = false;
					MessageBox.Show("Error: The given folder does not seem to be valid.");
				}
			
			}


        }
		
		/// <summary>
		/// Handles the Exited event of the Pr control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		void Pr_Exited(object sender, EventArgs e)
		{
			if (this.InvokeRequired)
				this.Invoke(new ClosedApplicationDelegate(ClosedApplication));
			else
				this.ClosedApplication();
		}
		
		/// <summary>
		/// Previews the rename.
		/// </summary>
		private void PreviewRename()
		{
			frmPreview previewWindow = new frmPreview();

			previewWindow.SetFileList(this.FileList);

			if (previewWindow.ShowDialog() == DialogResult.OK)
			{
				try
				{
					this.FileList.RenameFiles();
					
					MessageBox.Show(this, "Job done!\n\nEverything worked!", this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (RenameProcessFailedException Ex) 
				{
					MessageBox.Show(this, "Could not rename these files:\n\n" + Ex.Message, this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception Ex)
				{
					MessageBox.Show(this, "A error occured during the rename process:\n" + Ex.Message, this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}	
			}

			previewWindow.Dispose();

			ResetGui();

		}
		
		/// <summary>
		/// Starts this instance.
		/// </summary>
		private void Start()
		{		
			// Reset
			this.FileList = new FileList();

			DisableGui();
			
			this.FileList.SelectedFolder = this.fcFolder.Folder;
			
			if (this.FileList.IsDrive())
			{
				if (MessageBox.Show(this, "Warning!\n\nYou are trying to remove all sub folders from\n your entire drive \"" + this.FileList.SelectedFolder.FullName + "\"\n\nThis will destroy your operating system!\n\n\nDo you really want to continue?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
				{
					this.ResetGui();
					return;
				}
			}

			try
			{
				this.FileList.LoadFiles();
			}
			catch (Exception Ex)
			{
				MessageBox.Show(this, "A error occured while trying to read the file list:\n" + Ex.Message, this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				ResetGui();
				return;
			}													

			try
			{
				string TempPath = this.FileList.GetTempFilePath();	

				FileList.FillTempFile();

				//Pr = Process.Start(@"C:\programme\Scintilla Text Editor\SciTE.exe", TempPath);
				EditTextProcess = Process.Start(TempPath);
				EditTextProcess.EnableRaisingEvents = true;
				EditTextProcess.Exited += new EventHandler(Pr_Exited);

			}
			catch (Exception Ex)
			{
				ResetGui();	
				this.Cleanup();
				MessageBox.Show(this, "A error occured while writing the temporary file:\n" + Ex.Message, this.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}					

					


		}

		/// <summary>
		/// Disables the GUI.
		/// </summary>
		private void DisableGui()
		{
			this.fcFolder.Enabled = false;
			this.btnStart.Enabled = false;
		}

		/// <summary>
		/// Resets the GUI.
		/// </summary>
		private void ResetGui()
		{
			this.fcFolder.Enabled = true;
			this.btnStart.Enabled = true;
		}
		
		#endregion [rgn]

		private delegate void ClosedApplicationDelegate();
    }
}