using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace AE_UI
{
	public partial class ResultForm : Form
	{
		public string ResultText
		{
			get { return textBox1.Text; }
			set
			{
				textBox1.Text = value;
			}
		}
		public ResultForm()
		{
			InitializeComponent();
		}
		// ********************************************************************
		static public void Show(string s,string title="")
		{
			ResultForm dlg = new ResultForm();
			if(title!="")
			{
				dlg.Text = title;
			}
			dlg.ResultText = s;
			try
			{
				if (dlg.ShowDialog()==DialogResult.OK)
				{

				}
			}
			finally
			{
				dlg.Dispose();
			}
		}
		// ********************************************************************
		private void btnExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = "Export";

			if (dlg.ShowDialog()==DialogResult.OK)
			{
				try
				{
					File.WriteAllText(dlg.FileName, textBox1.Text, Encoding.GetEncoding("utf-8"));
				}
				catch
				{
				}
			}
		}
		// ********************************************************************
		private void btnCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(textBox1.Text);
		}
		// ********************************************************************
	}
}
