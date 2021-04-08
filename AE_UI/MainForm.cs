using BRY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.Json;

/// <summary>
/// 基本となるアプリのスケルトン
/// </summary>
namespace AE_UI
{
	public partial class MainForm : Form
	{
		private string m_FileName = "";
		//-------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			aeControl1.ClickScript += AeControl1_ClickScript;
		}


		//-------------------------------------------------------------

		/// <summary>
		/// コントロールの初期化はこっちでやる
		/// </summary>
		protected override void InitLayout()
		{
			base.InitLayout();
		}
		//-------------------------------------------------------------
		/// <summary>
		/// フォーム作成時に呼ばれる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			PrefFile pref = new PrefFile();
			if ( pref.Load())
			{
				if (pref.AppPref.Loc != null) this.Location = pref.AppPref.Loc;
				if (pref.AppPref.Size != null) this.Size = pref.AppPref.Size;
				if (pref.AppPref.FileName != null) m_FileName = pref.AppPref.FileName;


			}

			string ap = PrefFile.AppName();
			string defFile= Path.Combine(PrefFile.AppFolder(ap), "def.json");
			if(File.Exists(defFile))
			{
				uiTree1.Load(defFile);
			}

			this.Text = ap;
		}
		//-------------------------------------------------------------
		/// <summary>
		/// フォームが閉じられた時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			PrefFile pref = new PrefFile();
			pref.AppPref.SetForm(this);
			pref.AppPref.FileName = m_FileName;

			pref.Save();

			//設定ファイルの保存
			string ap = PrefFile.AppName();
			string defFile = Path.Combine(PrefFile.AppFolder(ap), "def.json");
			uiTree1.Save(defFile);
			uiTree1.RemoveAll();
		}
		//-------------------------------------------------------------
		/// <summary>
		/// ドラッグ＆ドロップの準備
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		/// <summary>
		/// ドラッグ＆ドロップの本体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			//ここでは単純にファイルをリストアップするだけ
			GetCommand(files);
		}
		//-------------------------------------------------------------
		/// <summary>
		/// ダミー関数
		/// </summary>
		/// <param name="cmd"></param>
		public void GetCommand(string[] cmd)
		{
			if (cmd.Length > 0)
			{
				foreach (string s in cmd)
				{
					//lbInstalled.Items.Add(s);
				}
			}
		}
		/// <summary>
		/// メニューの終了
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//-------------------------------------------------------------
		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AppInfoDialog.ShowAppInfoDialog();
		}
		// ********************************************************************
		public bool SaveToFile()
		{
			bool ret = false;
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = "ファイルの保存";
			dlg.Filter = "jsonファイル(*.json)|*.json|すべてのファイル(*.*)|*.*";
			dlg.DefaultExt = "json";
			if (m_FileName!="")
			{
				dlg.InitialDirectory = Path.GetDirectoryName(m_FileName);
				dlg.FileName = Path.GetFileName(m_FileName);
			}
			try
			{
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = uiTree1.Save(dlg.FileName);
					m_FileName = dlg.FileName;
					ret = true;
				}
			}
			catch
			{
				ret = false;
			}
			finally
			{
				dlg.Dispose();
			}
			return ret;
		}
		// ********************************************************************
		public bool LoadFromFile()
		{
			bool ret = false;
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = "ファイルの読み込み";
			dlg.Filter = "jsonファイル(*.json)|*.json|すべてのファイル(*.*)|*.*";
			dlg.DefaultExt = "json";

			if (m_FileName != "")
			{
				dlg.InitialDirectory = Path.GetDirectoryName(m_FileName);
				dlg.FileName = Path.GetFileName(m_FileName);
			}
			try
			{
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = uiTree1.Load(dlg.FileName);
					m_FileName = dlg.FileName;
					ret = true;
				}
			}
			catch
			{
				ret = false;
			}
			finally
			{
				dlg.Dispose();
			}
			return ret;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LoadFromFile();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveToFile();
		}

		private void resToolStripMenuItem_Click(object sender, EventArgs e)
		{
			uiTree1.GetResAll();
		}
		//-------------------------------------------------------------
		private void AeControl1_ClickScript(object sender, EventArgs e)
		{
			string code = uiTree1.SampleScriptCode();

			aeControl1.ExecScript(code);
		}
		//-------------------------------------------------------------
		private void jsxToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string code = uiTree1.SampleScriptCode();

			ResultForm.Show(code,"ScriptCode");

		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			uiTree1.CopyData();
		}

		private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			uiTree1.PasteData();
		}
		//-------------------------------------------------------------
	}
}
