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
		public class UIEditBase :Control
	{
		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged(EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		[Category("AE")]
		public string Caption
		{
			get { return m_CB.Text; }
			set { m_CB.Text = value; }
		}
		[Category("AE")]
		public bool IsUsed
		{
			get { return m_CB.Checked; }
			set
			{
				if (m_CB.Checked != value)
				{
					m_CB.Checked = value;
				}
				if (this.Controls.Count > 1)
				{
					for (int i = 1; i < this.Controls.Count; i++)
					{
						this.Controls[i].Enabled = m_CB.Checked;
					}
				}
			}
		}
		[Category("AE")]
		public int CaptionWidth
		{
			get { return m_CB.Width; }
			set
			{
				m_CB.Width = value;
				ChkResize();
			}
		}
		// **************************************************************
		CheckBox m_CB = new CheckBox();

		// **************************************************************
		public UIEditBase()
		{
			this.Size = new Size(320, 23);
			m_CB.AutoSize = false;
			m_CB.Text = "params";
			m_CB.TextAlign = ContentAlignment.MiddleLeft;
			m_CB.Location = new Point(0, 0);
			m_CB.Size = new Size(90, 23);


			this.Controls.Add(m_CB);
			m_CB.CheckStateChanged += M_CB_CheckStateChanged;
			m_CB.Checked = true;
		}
		// **************************************************************
		protected override void InitLayout()
		{
			base.InitLayout();

		}
		private void M_CB_CheckStateChanged(object sender, EventArgs e)
		{
			if (this.Controls.Count > 1)
			{
				for (int i = 1; i < this.Controls.Count; i++)
				{
					this.Controls[i].Enabled = m_CB.Checked;
				}
			}
			OnValueChanged(new EventArgs());
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			ChkResize();
		}
		public void ChkResize()
		{
			m_CB.Height = this.Height;
			if (this.Controls.Count>1)
			{
				this.Controls[1].Left = m_CB.Width;
				this.Controls[1].Width = this.Width - m_CB.Width;
				this.Controls[1].Height = this.Height;
			}
		}
		// **************************************************************
	}
}
