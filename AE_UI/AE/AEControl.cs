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
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace AE_Util_skelton
{
	public class AEControl : Control
	{
		private NFsAE NFsAE = new NFsAE();
		#region Event
		public event EventHandler InstalledAFXIndexChanged;

		protected virtual void OnInstalledAFXIndexChanged(EventArgs e)
		{
			if (InstalledAFXIndexChanged != null)
			{
				InstalledAFXIndexChanged(this, e);
			}
		}
		public event EventHandler RunningAFXIndexChanged;

		protected virtual void OnRunningAFXIndexChanged(EventArgs e)
		{
			if (RunningAFXIndexChanged != null)
			{
				RunningAFXIndexChanged(this, e);
			}
		}
		public event EventHandler ClickScript;

		protected virtual void OnClickScript(EventArgs e)
		{
			if (ClickScript != null)
			{
				ClickScript(this, e);
			}
		}
		#endregion


		#region installed
		[Category("AE")]
		public int InstalledCount
		{
			get { return NFsAE.InstalledCount; }
		}
		public string[] InstalledAFX
		{
			get
			{
				return NFsAE.InstalledAFX;
			}
		}
		#endregion
		/// <summary>
		/// インストールされているバージョンで、選ばれている文字
		/// </summary>
		[Category("AE")]
		public string InstalledAFXStr
		{
			get
			{
				return NFsAE.InstalledAFXStr;
			}
			set
			{
				NFsAE.InstalledAFXStr = value;
			}
		}
		/// <summary>
		/// インストールされているバージョンで選ばれているインデックス番号
		/// </summary>
		[Category("AE")]
		public int InstalledAFXIndex
		{
			get { return NFsAE.InstalledAFXIndex; }
			set
			{
				if (NFsAE.InstalledAFXIndex != value)
				{
					NFsAE.InstalledAFXIndex = value;
					if (m_CombInstalled != null)
					{
						if (m_CombInstalled.SelectedIndex != InstalledAFXIndex)
						{
							m_CombInstalled.SelectedIndex = InstalledAFXIndex;
						}

					}
					OnInstalledAFXIndexChanged(new EventArgs());
				}
			}
		}
		/// <summary>
		/// インストールされているバージョンで選ばれているものの実行ファイルのパス
		/// </summary>
		[Category("AE")]
		public string AfterFXPath
		{
			get
			{
				return NFsAE.AfterFXPath;
			}
		}
		/// <summary>
		/// インストールされているバージョンで選ばれているもののaerender.exeのパス
		/// </summary>
		[Category("AE")]
		public string AerenderPath
		{
			get
			{
				return NFsAE.AerenderPath;
			}
		}

		// ******************************************************************************
		private Label label1 = new Label();
		private ComboBox m_CombInstalled = new ComboBox();
		private Button m_BtnRun = new Button();
		private Label label2 = new Label();
		private ComboBox m_CombRunning = new ComboBox();
		private Button m_BtnMax = new Button();
		private Button m_BtnMin = new Button();
		private Label label3 = new Label();
		private Label label4 = new Label();

		private Button m_BtnScript = new Button();

		public string ScriptCode { get; set; }
		// ****************************************************************************
		public AEControl()
		{
			NFsAE.FindInstalledAFX();
			NFsAE.InstalledAFXChanged += NFsAE_InstalledAFXChanged;
			NFsAE.InstalledAFXIndexChanged += NFsAE_TargetAEIndexChanged;

			NFsAE.RunningAFXChanged += NFsAE_RunningAFXChanged;
			NFsAE.RunningAFXIndexChanged += NFsAE_RunningAFXIndexChanged;


			int x = 0;
			int y0 = 0;
			int y1 = 12;
			this.Size = new Size(330, 12+23);


			m_CombInstalled.Location = new Point(x, y1+2);
			m_CombInstalled.Size = new Size(70, 20);
			x += m_CombInstalled.Width + 5;

			m_BtnRun.Location = new Point(x, y1);
			m_BtnRun.Size = new Size(40, 23);
			m_BtnRun.Text = "Run";
			x += m_BtnRun.Width;

			m_CombRunning.Location = new Point(x, y1+2);
			m_CombRunning.Size = new Size(60, 20);
			x += m_CombRunning.Width+5;

			m_BtnMax.Location = new Point(x, y1);
			m_BtnMax.Size = new Size(35, 23);
			m_BtnMax.Text = "Max";
			x += m_BtnMax.Width +5;

			m_BtnMin.Location = new Point(x, y1);
			m_BtnMin.Size = new Size(35, 23);
			m_BtnMin.Text = "Min";
			x += m_BtnMin.Width + 15;

			m_BtnScript.Location = new Point(x, y1);
			m_BtnScript.Size = new Size(60, 23);
			m_BtnScript.Text = "Send";
			x += m_BtnMin.Width;

			label1.AutoSize = false;
			label1.Location = new Point(m_CombInstalled.Left, y0);
			label1.Size = new Size(100, 12);
			label1.Text = "Installed";
			label1.TextAlign = ContentAlignment.BottomLeft;

			label2.AutoSize = false;
			label2.Location = new Point(m_CombRunning.Left, y0);
			label2.Size = new Size(60, 12);
			label2.Text = "Running";
			label2.TextAlign = ContentAlignment.BottomLeft;

			label3.AutoSize = false;
			label3.Location = new Point(m_BtnMax.Left, y0);
			label3.Size = new Size(60, 12);
			label3.Text = "Window";
			label3.TextAlign = ContentAlignment.BottomLeft;

			label4.AutoSize = false;
			label4.Location = new Point(m_BtnScript.Left, y0);
			label4.Size = new Size(60, 12);
			label4.Text = "Script";
			label4.TextAlign = ContentAlignment.BottomLeft;


			this.Controls.Add(label1);
			this.Controls.Add(label2);
			this.Controls.Add(label3);
			this.Controls.Add(label4);
			this.Controls.Add(m_CombInstalled);
			this.Controls.Add(m_BtnRun);
			this.Controls.Add(m_CombRunning);
			this.Controls.Add(m_BtnMax);
			this.Controls.Add(m_BtnMin);
			this.Controls.Add(m_BtnScript);

			//
			m_CombInstalled.DropDownStyle = ComboBoxStyle.DropDownList;
			m_CombInstalled.Items.Clear();
			if (NFsAE.InstalledCount > 0)
			{
				m_CombInstalled.Items.Clear();
				m_CombInstalled.Items.AddRange(NFsAE.InstalledAFX);
				if ((NFsAE.InstalledAFXIndex >= 0) && (NFsAE.InstalledAFXIndex < m_CombInstalled.Items.Count))
				{
					m_CombInstalled.SelectedIndex = NFsAE.InstalledAFXIndex;
				}
				m_CombInstalled.SelectedIndexChanged += M_CombInstalled_SelectedIndexChanged;
			}
			//
			m_BtnRun.Enabled = (NFsAE.InstalledAFXIndex >= 0);
			m_BtnRun.Click += M_BtnRun_Click;
			//
			m_CombRunning.DropDownStyle = ComboBoxStyle.DropDownList;
			m_CombRunning.Items.Clear();
			if (NFsAE.RunningCount > 0)
			{
				m_CombRunning.Items.Clear();
				m_CombRunning.Items.AddRange(NFsAE.RunningAFXStr);
				if ((NFsAE.RunningAFXIndex >= 0) && (NFsAE.RunningAFXIndex < m_CombRunning.Items.Count))
				{
					m_CombRunning.SelectedIndex = NFsAE.RunningAFXIndex;
				}
				m_CombRunning.SelectedIndexChanged += M_CombRunning_SelectedIndexChanged;
			}
			m_BtnMax.Enabled = false;
			m_BtnMax.Click += M_BtnMax_Click;
			m_BtnMin.Enabled = false;
			m_BtnMin.Click += M_BtnMin_Click;
			m_BtnScript.Enabled = false;
			m_BtnScript.Click += M_BtnScript_Click; ;

		}

		// ****************************************************************************
		private void M_BtnScript_Click(object sender, EventArgs e)
		{
			OnClickScript(new EventArgs());
		}
		// ****************************************************************************
		protected override void InitLayout()
		{
			base.InitLayout();
			this.Size = new Size(330, 23 +12);
			//this.MinimumSize = this.Size;
			//this.MaximumSize = this.Size;

		}
		// ******************************************************************************
		private void NFsAE_RunningAFXIndexChanged(object sender, EventArgs e)
		{
			OnRunningAFXIndexChanged(new EventArgs());
			int idx = m_CombRunning.SelectedIndex;
			bool ok = ((idx >= 0) && (idx < NFsAE.InstalledCount));
			m_BtnMax.Enabled = ok;
			m_BtnMin.Enabled = ok;
			m_BtnScript.Enabled = ok;


		}
		// ******************************************************************************
		private void NFsAE_RunningAFXChanged(object sender, EventArgs e)
		{
			if (m_CombRunning != null)
			{
				m_CombRunning.Items.Clear();
				m_CombRunning.Items.AddRange(NFsAE.RunningAFXStr);
				int idx = m_CombRunning.SelectedIndex;
				bool ok = ((idx >= 0) && (idx < NFsAE.InstalledCount));
				m_BtnMax.Enabled = ok;
				m_BtnMin.Enabled = ok;
				m_BtnScript.Enabled = ok;

			}
		}

		// ******************************************************************************
		private void NFsAE_InstalledAFXChanged(object sender, EventArgs e)
		{
			if (m_CombInstalled != null)
			{
				m_CombInstalled.Items.Clear();
				if (NFsAE.InstalledCount > 0)
				{
					m_CombInstalled.Items.Clear();
					m_CombInstalled.Items.AddRange(NFsAE.InstalledAFX);
				}
			}
		}
		// ******************************************************************************
		private void NFsAE_TargetAEIndexChanged(object sender, EventArgs e)
		{
			if (m_CombInstalled != null)
			{
				if (m_CombInstalled.SelectedIndex != NFsAE.InstalledAFXIndex)
				{
					m_CombInstalled.SelectedIndex = NFsAE.InstalledAFXIndex;
				}
			}
		}      
		// ****************************************************************************
		private void M_CombInstalled_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = (ComboBox)sender;
			int idx = cmb.SelectedIndex;
			bool ok = ((idx >= 0) && (idx < NFsAE.InstalledCount));
			if (ok)
			{
				if (InstalledAFXIndex != idx)
				{
					InstalledAFXIndex = idx;
				}
			}
			m_BtnRun.Enabled = ok;
		}
		// ****************************************************************************
		private void M_BtnRun_Click(object sender, EventArgs e)
		{
			Run(true);
			NFsAE.FindRunningAFX();
			int idx = m_CombRunning.SelectedIndex;
			bool ok = ((idx >= 0) && (idx < NFsAE.RunningCount));
			m_BtnMax.Enabled = ok;
			m_BtnMin.Enabled = ok;
			m_BtnScript.Enabled = ok;
		}
		// ******************************************************************************
		private void M_CombRunning_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = (ComboBox)sender;
			int idx = cmb.SelectedIndex;
			bool ok = ((idx >= 0) && (idx < NFsAE.RunningCount));
			if (NFsAE.RunningAFXIndex != idx)
			{
				NFsAE.RunningAFXIndex = idx;
			}
			m_BtnMax.Enabled = ok;
			m_BtnMin.Enabled = ok;
			m_BtnScript.Enabled = ok;

		}
		// ******************************************************************************
		public AEStutas Run(bool IsShowMes = false)
		{
			AEStutas ret = AEStutas.None;
			ret = NFsAE.Run();
			if (IsShowMes)
			{
				string mes = "";
				switch (ret)
				{
					case AEStutas.None:
						mes = "起動失敗？";
						break;
					case AEStutas.IsRunning:
						mes = "既に起動しています。";
						break;
					case AEStutas.IsRunStart:
						mes = "起動します。";
						break;
				}
				MessageBox.Show(mes, "AfterFX起動");
			}
			int idx = m_CombRunning.SelectedIndex;
			bool ok = ((idx >= 0) && (idx < NFsAE.RunningCount));
			m_BtnMax.Enabled = ok;
			m_BtnMin.Enabled = ok;
			m_BtnScript.Enabled = ok;
			return ret;
		}
		// ******************************************************************************
		public Process CallAerender(string aep, string op = "")
		{
			return NFsAE.CallAerender(aep, op);
		}
		// ******************************************************************************
		public bool ExecScriptFile(string appTag,string p)
		{

			return NFsAE.ExecScriptFile(appTag,p);

		}
		// ******************************************************************************
		public bool ExecScript(string code)
		{
			bool ret = false;
			string tpath = Path.Combine(Path.GetTempPath(), "tmp0000.jsx");

			int idx = m_CombRunning.SelectedIndex;
			string appTag = "";
			if (idx >= 0)
			{
				appTag = m_CombRunning.Items[idx].ToString();
			}

			if (File.Exists(tpath))
			{
				File.Delete(tpath);
			}
			try
			{
				File.WriteAllText(tpath, code, Encoding.GetEncoding("utf-8"));
				if (File.Exists(tpath))
				{
					ret = NFsAE.ExecScriptFile(appTag, tpath);
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// ******************************************************************************
		public bool ExecScriptCode(string p)
		{
			return NFsAE.ExecScriptCode(p);

		}
		// *************************************************************************************
		public void ForegroundWindow()
		{
			if (NFsAE.RunningAFXIndex >= 0)
			{
				NFsAE.RunningAFX[NFsAE.RunningAFXIndex].SetForegroundWindow();
			}
		}
		public void WindowMax()
		{
			if (NFsAE.RunningAFXIndex >= 0)
			{
				NFsAE.RunningAFX[NFsAE.RunningAFXIndex].WindowMax();
				NFsAE.RunningAFX[NFsAE.RunningAFXIndex].SetForegroundWindow();
			}
		}
		public void WindowMin()
		{
			if (NFsAE.RunningAFXIndex >= 0)
			{
				NFsAE.RunningAFX[NFsAE.RunningAFXIndex].WindowMin();
			}
		}
		private void M_BtnMax_Click(object sender, EventArgs e)
		{
			WindowMax();
		}
		private void M_BtnMin_Click(object sender, EventArgs e)
		{
			WindowMin();
		}
	}
}
