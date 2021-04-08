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
	public class UIEditAlg : UIEditBase
	{
		[Category("AE")]
		public string Value
		{
			get
			{
				if ((IsUsed)&&(this.Visible))
				{
					return m_alg.Value;
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
				if (m_alg.Value != value)
				{
					m_alg.Value = value;
				}
			}
		}
		UIEditBaseAlg m_alg = new UIEditBaseAlg();
		public UIEditAlg()
		{
			this.Size = new Size(320, 23);
			CaptionWidth = 90;
			m_alg.Size = new Size(225, 23);
			this.Controls.Add(m_alg);
			m_alg.ValueChanged += M_alg_ValueChanged;
		}

		private void M_alg_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(new EventArgs());
		}
	}
}