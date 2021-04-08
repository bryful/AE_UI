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
	public class UIEditBaseMarin : Control
	{
		private bool refFlag = false;
		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		
		[Category("AE")]
		public bool  IsMode4
		{
			get { return m_num1.Visible; }
			set { SetIsMode4(value); }
		}
		public double[] GetValues()
		{
			double[] ret = new double[4];
			ret[0] = (double)m_num0.Value;
			ret[1] = (double)m_num1.Value;
			ret[2] = (double)m_num2.Value;
			ret[3] = (double)m_num3.Value;
			return ret;
		}
		public void SetValues(double[] value)
		{
			refFlag = true;
			if (value.Length >= 1) m_num0.Value = (decimal)value[0];
			if (value.Length >= 2) m_num1.Value = (decimal)value[1];
			if (value.Length >= 3) m_num2.Value = (decimal)value[2];
			if (value.Length >= 4) m_num3.Value = (decimal)value[3];
			refFlag = false;
			OnValueChanged(new EventArgs());

		}

		[Category("AE")]
		public string Value
		{
			get
			{
				if (IsMode4)
				{
					return string.Format("[{0},{1},{2},{3}]",
						m_num0.Value, m_num1.Value, m_num2.Value, m_num3.Value);
				}
				else
				{
					return string.Format("{0}", m_num0.Value);
				}
			}
			set
			{
				string s = value.Trim();
				if (s == "") return;
				if(s[0]=='[')
				{
					double[] v = UIParams.StrToArrayNum(s);
					if (v.Length > 0)
					{
						SetIsMode4(true);
						SetValues(v);
					}
				}
				else
				{
					double d = 0;
					if (double.TryParse(s,out d))
					{
						SetIsMode4(false);
						m_num0.Value = (decimal)d;
					}

				}
			}
		}
		NumericUpDown m_num0 = new NumericUpDown();
		NumericUpDown m_num1 = new NumericUpDown();
		NumericUpDown m_num2 = new NumericUpDown();
		NumericUpDown m_num3 = new NumericUpDown();
		Button m_btn = new Button();
		public UIEditBaseMarin()
		{
			this.Size = new Size(150, 23);
			int w = (this.Width - 25) / 4;
			m_num0.AutoSize = false;
			m_num0.Location = new Point(0, 0);
			m_num0.Margin = new Padding(0);
			m_num0.Size = new Size(w, 23);
			m_num0.Visible = true;
			m_num0.Font = new Font(this.Font.FontFamily, 12f);

			m_num1.AutoSize = false;
			m_num1.Location = new Point(w, 0);
			m_num1.Margin = new Padding(0);
			m_num1.Size = new Size(w, 23);
			m_num1.Visible = true;
			m_num1.Font = m_num0.Font;

			m_num2.AutoSize = false;
			m_num2.Location = new Point(w*2, 0);
			m_num2.Margin = new Padding(0);
			m_num2.Size = new Size(w, 23);
			m_num2.Visible = true;
			m_num2.Font = m_num0.Font;

			m_num3.AutoSize = false;
			m_num3.Location = new Point(w * 3, 0);
			m_num3.Margin = new Padding(0);
			m_num3.Size = new Size(w, 23);
			m_num3.Visible = true;
			m_num3.Font = m_num0.Font;

			m_btn.AutoSize = false;
			m_btn.Location = new Point(w * 4, 0);
			m_btn.Margin = new Padding(0);
			m_btn.Size = new Size(23, 23);
			m_btn.Visible = true;
			m_btn.Text= "m";

			this.Controls.Add(m_num0);
			this.Controls.Add(m_num1);
			this.Controls.Add(m_num2);
			this.Controls.Add(m_num3);
			this.Controls.Add(m_btn);
			ChkSize();

			m_btn.Click += M_btn_Click;
			m_num0.ValueChanged += M_num0_ValueChanged;
			m_num1.ValueChanged += M_num0_ValueChanged;
			m_num2.ValueChanged += M_num0_ValueChanged;
			m_num3.ValueChanged += M_num0_ValueChanged;
		}

		private void M_num0_ValueChanged(object sender, EventArgs e)
		{
			if (refFlag) return;
			OnValueChanged(new EventArgs());
		}

		private void M_btn_Click(object sender, EventArgs e)
		{
			SetIsMode4(!IsMode4);
			OnValueChanged(new EventArgs());
		}

		public void SetIsMode4(bool b)
		{
			m_num1.Visible = b;
			m_num2.Visible = b;
			m_num3.Visible = b;
			ChkSize();
		}
		public void ChkSize()
		{
			int t = (this.Height - 23) / 2;
			if (IsMode4)
			{
				int w = (this.Width - 25 -12 ) / 4;
				m_num0.Width = w;
				m_num1.Width = w;
				m_num2.Width = w;
				m_num3.Width = w;
				m_num0.Location = new Point(0,t);
				m_num1.Location = new Point(w+3 , t);
				m_num2.Location = new Point((w+3)*2, t);
				m_num3.Location = new Point((w+3) * 3, t); ;
				m_btn.Location = new Point((w + 3) * 4 + 2, t);
			}
			else
			{
				m_num0.Width = this.Width - 25;
				m_num0.Top = t;
				m_btn.Location = new Point(m_num0.Width + 2, t);
			}
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkSize();
		}

	}
}
