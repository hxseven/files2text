using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JonasJohn.Tools.Files2Text
{
	public partial class frmPreview : Form
	{
		FileList fileList;

		public frmPreview()
		{
			InitializeComponent();
		}

		internal void SetFileList(FileList List)
		{
			this.fileList = List;
		}

		private void frmPreview_Load(object sender, EventArgs e)
		{
			this.listView1.Columns.Add("Old name", this.listView1.Width / 2);
			this.listView1.Columns.Add("New name", this.listView1.Width / 2);

			foreach (FileItem File in this.fileList.GetFiles()) {

				string[] Row = new string[] { File.OldName, File.NewName };

				ListViewItem NewItem = new ListViewItem(Row);

				if (File.Modified)
					NewItem.ForeColor = Color.Red;

				this.listView1.Items.Add(NewItem);			
			}

		}
	}
}