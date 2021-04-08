using GetBigShellIcon; // https://www.ipentec.com/document/csharp-shell-namespace-get-big-icon-from-file-path 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRY
{
	public partial class AppInfoDialog : Form
	{
		public AppInfoDialog()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterParent;



			WindowsShellAPI.SHFILEINFO shinfo = new WindowsShellAPI.SHFILEINFO();

			IntPtr hImg = WindowsShellAPI.SHGetFileInfo(Application.ExecutablePath, 0, out shinfo, (uint)Marshal.SizeOf(typeof(WindowsShellAPI.SHFILEINFO)), WindowsShellAPI.SHGFI.SHGFI_SYSICONINDEX);

			WindowsShellAPI.SHIL currentshil = WindowsShellAPI.SHIL.SHIL_JUMBO;


			WindowsShellAPI.IImageList imglist = null;
			//int rsult = WindowsShellAPI.SHGetImageList(WindowsShellAPI.SHIL.SHIL_EXTRALARGE, ref WindowsShellAPI.IID_IImageList, out imglist);
			//int rsult = WindowsShellAPI.SHGetImageList(WindowsShellAPI.SHIL.SHIL_JUMBO, ref WindowsShellAPI.IID_IImageList, out imglist);
			int rsult = WindowsShellAPI.SHGetImageList(currentshil, ref WindowsShellAPI.IID_IImageList, out imglist);

			IntPtr hicon = IntPtr.Zero;
			imglist.GetIcon(shinfo.iIcon, (int)WindowsShellAPI.ImageListDrawItemConstants.ILD_TRANSPARENT, ref hicon);

			Icon myIcon = Icon.FromHandle(hicon);
			Bitmap buf = new Bitmap(128, 128);
			Graphics g = Graphics.FromImage(buf);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(myIcon.ToBitmap(), 0, 0, 128, 128);



			pictureBox1.Image = buf;




			/*
			Bitmap buf = new Bitmap(128, 128);
			Graphics g = Graphics.FromImage(buf);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			g.DrawImage(ico.ToBitmap(), 0, 0, 128, 128);
			*/

			Text = "AE_UI" + " のバージョン情報";
			lbCanpany.Text = "bry-ful";
			lbProduct.Text = "AE_UI";
			lbVersion.Text = "Version 1.00";
			lbCopyright.Text = "coppyright 2021(c) bry-ful";
			lbDescription.Text = "";
		}
		static public void ShowAppInfoDialog()
		{
			using (AppInfoDialog dlg = new AppInfoDialog())
			{
				dlg.ShowDialog();
			}
		}

		private void AppInfoDialog_Load(object sender, EventArgs e)
		{

		}
	}


}
