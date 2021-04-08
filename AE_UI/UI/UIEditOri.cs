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
	public class UIEditOri : UIEditBase
	{
		[Category("AE")]
		public string Value
		{
			get
			{
				if ((IsUsed) && (this.Visible))
				{
					return m_cmb.Value;
				}
				else
				{
					return "";
				}
			}
			set
			{
				if (value == null) value = "";
				IsUsed = (value != "");
				if (m_cmb.Value != value)
				{
					m_cmb.Value = value;
				}
			}
		}
		UIOriCmb m_cmb = new UIOriCmb();
		public UIEditOri()
		{
			this.Size = new Size(320, 24);
			CaptionWidth = 90;
			m_cmb.Size = new Size(225, 24);
			m_cmb.Location = new Point(CaptionWidth, 0);
			m_cmb.Font = new Font(this.Font.FontFamily, 12f);
			this.Controls.Add(m_cmb);

			m_cmb.SelectedIndexChanged += M_cmb_SelectedIndexChanged;
		}

		private void M_cmb_SelectedIndexChanged(object sender, EventArgs e)
		{
			OnValueChanged(new EventArgs());
		}
	}
}