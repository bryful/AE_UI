using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AE_UI
{
	public class UIEditBaseAlg : Control
	{
		private bool refFlag = false;
		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged(EventArgs e)
		{
			if (refFlag) return;
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		[Category("AE")]
		public bool IsMode2
		{
			get { return m_hor.Visible; }
			set
			{
				SetIsMode2(value);
			}
		}
		[Category("AE")]
		public string Value
		{
			get
			{
				if (IsMode2)
				{
					return "[" + m_hor.Value + "," + m_vur.Value + "]";
				}
				else
				{
					return m_alg.Value;
				}
			}
			set
			{
				string s = value.Trim();
				if (s == "") return;
				refFlag = true;
				if((s[0]=='[')&&(s[s.Length-1] == ']'))
				{
					SetIsMode2(true);
					s = s.Substring(1, s.Length - 2);
					string[] sa = s.Split(',');
					if (sa.Length>=2)
					{
						m_hor.Value = sa[0];
						m_vur.Value = sa[1];
					}

				}
				else
				{
					SetIsMode2(false);
					m_alg.Value = s;
				}
				refFlag = false;
			}
		}
		private UIAlgHorCmb m_hor = new UIAlgHorCmb();
		private UIAlgVurCmb m_vur = new UIAlgVurCmb();
		private UIAlgCmb m_alg = new UIAlgCmb();
		private Button m_btn = new Button();

		public UIEditBaseAlg()
		{
			this.Size = new Size(150, 23);
			int w = (this.Width - 28) / 2;
			m_hor.AutoSize = false;
			m_hor.Location = new Point(0, 0);
			m_hor.Margin = new Padding(0);
			m_hor.Size = new Size(w, 23);
			m_hor.Visible = true;
			m_hor.Font = new Font(this.Font.FontFamily, 12f);

			m_vur.AutoSize = false;
			m_vur.Location = new Point(w+3, 0);
			m_vur.Margin = new Padding(0);
			m_vur.Size = new Size(w, 23);
			m_vur.Visible = true;
			m_vur.Font = new Font(this.Font.FontFamily, 12f);

			m_alg.AutoSize = false;
			m_alg.Location = new Point(0, 0);
			m_alg.Margin = new Padding(0);
			m_alg.Size = new Size(this.Width-25, 23);
			m_alg.Visible = false;
			m_alg.Font = new Font(this.Font.FontFamily, 12f);

			m_btn.AutoSize = false;
			m_btn.Location = new Point(this.Width-23, 0);
			m_btn.Margin = new Padding(0);
			m_btn.Size = new Size(23, 23);
			m_btn.Text = "m";

			this.Controls.Add(m_hor);
			this.Controls.Add(m_vur);
			this.Controls.Add(m_alg);
			this.Controls.Add(m_btn);

			ChkSize();

			m_hor.SelectedIndexChanged += M_hor_SelectedIndexChanged;
			m_vur.SelectedIndexChanged += M_hor_SelectedIndexChanged;
			m_alg.SelectedIndexChanged += M_hor_SelectedIndexChanged;

			m_btn.Click += M_btn_Click;
		}

		private void M_btn_Click(object sender, EventArgs e)
		{
			SetIsMode2(! IsMode2);
			OnValueChanged(new EventArgs());
		}

		private void M_hor_SelectedIndexChanged(object sender, EventArgs e)
		{
			OnValueChanged(new EventArgs());
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
		private void ChkSize()
		{
			if (IsMode2)
			{
				int w = (this.Width - 28) / 2;
				m_hor.Size = new Size(w, this.Height);
				m_hor.Location = new Point(0, 0);
				m_vur.Size = new Size(w, this.Height);
				m_vur.Location = new Point(w+3, 0);

				m_btn.Location = new Point(this.Width - 23, (this.Height - 23) / 2);
			}
			else
			{
				int w = (this.Width - 25);
				m_alg.Size = new Size(w, this.Height);
				m_alg.Location = new Point(0, 0);
				m_btn.Location = new Point(this.Width - 23, (this.Height - 23) / 2);

			}
		}
		public void SetIsMode2(bool md)
		{
			m_hor.Visible = md;
			m_vur.Visible = md;
			m_alg.Visible = ! md;
			ChkSize();
		}
	}
}
