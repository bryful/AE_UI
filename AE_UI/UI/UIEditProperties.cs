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
	public class UIEditProperties : UIEditBase
	{
		[Category("AE")]
		public string Value
		{
			get
			{
				if ((IsUsed) && (this.Visible))
				{
					return m_text.Value;
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
				if (m_text.Value != value)
				{
					m_text.Value = value;
				}
			}
		}

		UIEditBaseProperties m_text = new UIEditBaseProperties();
		public UIEditProperties()
		{
			this.Size = new Size(320, 23);
			CaptionWidth = 90;
			m_text.Size = new Size(225, 23);
			m_text.Font = new Font(this.Font.FontFamily, 12f);
			this.Controls.Add(m_text);
			m_text.ValueChanged += M_text_ValueChanged;

		}

		private void M_text_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(new EventArgs());
		}
	}
}