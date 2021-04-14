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
	public class UIEditBaseSize : Control
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
		private string m_ValueStr = "";
		private string m_ValueStrSet() { return string.Format("[{0},{1}]", m_num0.Value, m_num1.Value); }
		[Category("AE")]
		public string Value
		{
			get {
				m_ValueStr = m_ValueStrSet();
				return m_ValueStr;
			}
			set
			{
				string s = value.Trim();
				if (s.Length <= 2) return;
				if (s == m_ValueStr) return;

				if (s[0] == '[') s = s.Substring(1);
				if (s[s.Length-1]==']') s = s.Substring(0,s.Length-1);
				string[] sa = s.Split(',');
				if (sa.Length < 2) return;
				double d = 0;
				bool b = false;
				refFlag = true;

				if(double.TryParse(sa[0],out d))
				{
					if (m_num0.Value != (decimal)d)
					{
						m_num0.Value = (decimal)d;
						b = true;
					}
				}
				if (double.TryParse(sa[1], out d))
				{
					if (m_num1.Value != (decimal)d)
					{
						m_num1.Value = (decimal)d;
						b = true;
					}
				}
				refFlag = false;
				if (b)
				{
					OnValueChanged(new EventArgs());
				}

			}
		}
		private NumericUpDown m_num0 = new NumericUpDown();
		private NumericUpDown m_num1 = new NumericUpDown();
		public UIEditBaseSize()
		{
			this.Size = new Size(150, 23);
			int w = (this.Width ) / 2;
			m_num0.AutoSize = false;
			m_num0.Location = new Point(0, 0);
			m_num0.Margin = new Padding(0);
			m_num0.Size = new Size(w, 23);
			m_num0.Font = new Font(this.Font.FontFamily, 12f);
			m_num0.Maximum = 65536;

			m_num1.AutoSize = false;
			m_num1.Location = new Point(w, 0);
			m_num1.Margin = new Padding(0);
			m_num1.Size = new Size(w, 23);
			m_num1.Font = new Font(this.Font.FontFamily, 12f);
			m_num1.Maximum = 65536;

			this.Controls.Add(m_num0);
			this.Controls.Add(m_num1);

			ChkSize();
			m_num0.ValueChanged += M_num0_ValueChanged;
			m_num1.ValueChanged += M_num0_ValueChanged;

		}

		private void M_num0_ValueChanged(object sender, EventArgs e)
		{
			m_ValueStr = m_ValueStrSet();
			if (refFlag) return;
			OnValueChanged(new EventArgs());
		}

		private void ChkSize()
		{
			int w = (this.Width-5) / 2;
			m_num0.Location = new Point(0, 0);
			m_num0.Size = new Size(w, this.Height);
			m_num1.Location = new Point(w+5, 0);
			m_num1.Size = new Size(w, this.Height);

		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}
	}
}
