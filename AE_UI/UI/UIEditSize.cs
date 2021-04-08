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
	public class UIEditSize : UIEditBase
	{

		public string Value
		{
			get
			{
				if ((IsUsed) && (this.Visible))
				{
					return m_size.Value;
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
				if (m_size.Value != value)
				{
					m_size.Value = value;
				}
			}
		}
		UIEditBaseSize m_size = new UIEditBaseSize();
		public UIEditSize()
		{
			this.Size = new Size(320, 23);
			CaptionWidth = 90;
			m_size.Size = new Size(225, 23);


			this.Controls.Add(m_size);
			m_size.ValueChanged += M_size_ValueChanged;
		}

		private void M_size_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(new EventArgs());
		}

		protected override void InitLayout()
		{
			base.InitLayout();
			this.Size = new Size(320, 23);
		}

	}
}
