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
	public class UIEditBaseValue : Control
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
		public bool IsBool
		{
			get { return m_rb1.Visible; }
			set{	SetIsBool(value);}
		}
		[Category("AE")]
		public string Value
		{
			get
			{
				if (IsBool)
				{
					if (m_rb1.Checked) return "true";
					else return "false";
				}
				else
				{
					return string.Format("{0}", m_num.Value);
				}
			}
			set
			{
				bool b = false;
				refFlag = true;
				if(IsBool)
				{
					string s = value.Trim().ToLower();
					if  (s == "true")
					{
						if (m_rb1.Checked != true)
						{
							m_rb1.Checked = true;
							b = true;
						}
					}
					else
					{
						if (m_rb2.Checked != true)
						{
							m_rb2.Checked = true;
							b = true;
						}
					}

				}
				else
				{
					double v = 0;
					if (double.TryParse(value, out v))
					{
						if (m_num.Value != (decimal)v) {
							m_num.Value = (decimal)v;
							b = true;
						}
					}
				}
				refFlag = false;
				if (b) OnValueChanged(new EventArgs());
			}
		}
		RadioButton m_rb1 = new RadioButton();
		RadioButton m_rb2 = new RadioButton();
		NumericUpDown m_num = new NumericUpDown();
		public UIEditBaseValue()
		{
			this.Size = new Size(150, 23);

			int w = (this.Width) / 2;

			m_rb1.AutoSize = false;
			m_rb1.Location = new Point(0, 0);
			m_rb1.Margin = new Padding(0);
			m_rb1.Size = new Size(w, 23);
			m_rb1.Visible = true;
			m_rb1.Text = "true";
			m_rb1.Checked = true;

			m_rb2.AutoSize = false;
			m_rb2.Location = new Point(m_rb1.Width, 0);
			m_rb2.Margin = new Padding(0);
			m_rb2.Size = new Size(w, 23);
			m_rb2.Visible = true;
			m_rb2.Text = "false";
			m_rb1.Checked = false;

			m_num.AutoSize = false;
			m_num.Size = new Size(this.Width, 23);
			m_num.Location = new Point(0, 0);
			m_num.Margin = new Padding(0);
			m_num.Padding = new Padding(0);
			m_num.Visible = false;
			m_num.Minimum = 0;
			m_num.Maximum = 65536;
			m_num.Font = new Font(this.Font.FontFamily,12f);


			this.Controls.Add(m_rb1);
			this.Controls.Add(m_rb2);
			this.Controls.Add(m_num);

			m_rb1.CheckedChanged += ValuesChanged;
			m_rb2.CheckedChanged += ValuesChanged;
			m_num.ValueChanged += ValuesChanged;
		}


		private void ValuesChanged(object sender, EventArgs e)
		{
			if (refFlag) return;
			OnValueChanged(new EventArgs());
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			int w = (this.Width) / 2;
			m_rb1.Location = new Point(0, 0);
			m_rb1.Size = new Size(w, this.Height);
			m_rb2.Location = new Point(w, 0);
			m_rb2.Size = m_rb1.Size;

			m_num.Location = new Point(0, 0);
			m_num.Size = new Size(this.Width,this.Height);
			
		}

		public void SetIsBool(bool b)
		{
			m_rb1.Visible = b;
			m_rb2.Visible = b;

			m_num.Visible = !b;

		}
	}
}
