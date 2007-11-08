using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace JonasJohn.Tools.Files2Text
{
	// Helper classes
	
	public class FileList
	{
		
		#region [rgn] Fields (3)

		private List<FileItem> files = new List<FileItem>();
		private DirectoryInfo selectedFolder;
		private string tempFilePath = "";

		#endregion [rgn]

		#region [rgn] Properties (1)

		/// <summary>
		/// Gets or sets the selected folder.
		/// </summary>
		/// <value>The selected folder.</value>
		public DirectoryInfo SelectedFolder
		{
			get { return selectedFolder; }
			set { selectedFolder = value; }
		}
		
		#endregion [rgn]

		#region [rgn] Methods (11)

		// [rgn] Public Methods (5)

		/// <summary>
		/// Fills the temp file.
		/// </summary>
		public void FillTempFile()
		{
			try
			{
				File.WriteAllText(tempFilePath, this.GetFileList());
			}
			catch {
				throw new Exception("Could not create temporary file '" + tempFilePath + "'!");
			}
		}
		
		/// <summary>
		/// Gets the file count.
		/// </summary>
		/// <returns></returns>
		public int GetFileCount()
		{
			return this.files.Count;
		}
		
		/// <summary>
		/// Gets the file list.
		/// </summary>
		/// <returns></returns>
		public string GetFileList()
		{
			StringBuilder FileList = new StringBuilder();

			foreach (FileItem File in this.files)
				FileList.AppendLine(File.OldName);

			return FileList.ToString();
		}
		
		/// <summary>
		/// Gets the files.
		/// </summary>
		/// <returns></returns>
		public List<FileItem> GetFiles()
		{
			return this.files;
		}
		
		/// <summary>
		/// Renames the files.
		/// </summary>
		public void RenameFiles()
		{
			StringBuilder ErrorFiles = new StringBuilder();

			foreach (FileItem FileObj in this.files) {
				try
				{
					FileObj.RenameFile();
				}
				catch {
					ErrorFiles.AppendLine("- " + FileObj.OldName);
				}
			}

			if (ErrorFiles.Length > 0)
				throw new RenameProcessFailedException(ErrorFiles.ToString());
		}
		
		// [rgn] Internal Methods (6)

		/// <summary>
		/// Cleanups this instance.
		/// </summary>
		internal void CleanupTempFile()
		{
			if (File.Exists(tempFilePath))
				File.Delete(tempFilePath);

			//this.files.Clear();
			this.tempFilePath = "";
		}
		
		/// <summary>
		/// Gets the file item by line position.
		/// </summary>
		/// <param name="LinePos">The line pos.</param>
		/// <returns></returns>
		internal FileItem GetFileItemByLinePosition(int LinePos)
		{
			foreach (FileItem File in this.files) {
				if (File.LinePosition == LinePos)
					return File;
			}
			return null;
		}
		
		/// <summary>
		/// Writes the temp file.
		/// </summary>
		internal string GetTempFilePath(string ParentFolder)
		{
			tempFilePath = ParentFolder;
			tempFilePath += new Random().Next(1111, 9999).ToString();
			tempFilePath += Guid.NewGuid().ToString().Substring(1, 4);
			tempFilePath += ".txt";

			return tempFilePath;
		}
		
		/// <summary>
		/// Determines whether this instance is drive.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if this instance is drive; otherwise, <c>false</c>.
		/// </returns>
		internal bool IsDrive()
		{
			Match RootFolderCheck = Regex.Match(this.SelectedFolder.FullName.ToLower(), "^[a-z]:" + Regex.Escape(Path.DirectorySeparatorChar.ToString()) + "?$");
			return RootFolderCheck.Success;
		}
		
		/// <summary>
		/// Loads the files.
		/// </summary>
		internal void LoadFiles()
		{
			int Pos = 0;
			foreach (FileInfo FileObj in this.SelectedFolder.GetFiles())
			{
				FileItem NewFile = new FileItem();

				NewFile.LinePosition = Pos;
				NewFile.OrginalFile = FileObj;

				this.files.Add(NewFile);

				Pos++;
			}
		}
		
		/// <summary>
		/// Reads the temp file.
		/// </summary>
		internal void ReadTempFile()
		{
			if (!File.Exists(tempFilePath))
				throw new TempFileDoesNotExistException(tempFilePath);

			string[] Lines = File.ReadAllLines(tempFilePath);

			if (Lines.Length != this.files.Count)
				throw new LinesDontMatchException(Lines.Length.ToString());

			int Pos = 0;
			foreach (string Line in Lines) {

				FileItem FileObj = this.GetFileItemByLinePosition(Pos);

				if (FileObj == null)
					throw new Exception("The file for the line #" + Pos.ToString() + " was not found!");

				FileObj.NewName = Line.Trim();

				Pos++;
			}

		}
		
		#endregion [rgn]

	}

	public class FileItem
	{		
		
		#region [rgn] Fields (4)

		private int linePosition = 0;
		private bool modified = false;
		private string newName = "";
		private FileInfo orginalFile;

		#endregion [rgn]

		#region [rgn] Properties (5)

		public int LinePosition
		{
			get { return linePosition; }
			set {
				if (value < 0)
					throw new Exception("Line number should not be lower than zero.");

				linePosition = value; 
			}
		}
		
		public bool Modified
		{
			get { return modified; }
		}
		
		public string NewName
		{
			get { return newName; }
			set {

				if (value != this.OldName)
					this.modified = true;

				newName = value;
			}
		}
		
		public string OldName {
			get { return this.OrginalFile.Name; }
		}
		
		public FileInfo OrginalFile
		{
			get { return orginalFile; }
			set { orginalFile = value; }
		}
		
		#endregion [rgn]

		#region [rgn] Methods (1)

		// [rgn] Public Methods (1)

		public void RenameFile() {

			if (!this.Modified)
				return;

			string OldPath = this.OrginalFile.FullName;
			string NewPath = Path.Combine(this.OrginalFile.DirectoryName, this.NewName);

			try
			{
				File.Move(OldPath, NewPath);
			}
			catch (Exception ex) {
				throw new Exception("Could not rename file: " + this.OldName, ex);
			}

		}
		
		#endregion [rgn]

	}
}
