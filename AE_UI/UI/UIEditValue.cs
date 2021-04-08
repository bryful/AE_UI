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
	public class UIEditValue : UIEditBase
	{
		[Category("AE")]
		public bool IsBool
		{
			get { return m_value.IsBool; }
			set { m_value.IsBool = value; }
		}
		[Category("AE")]
		public string Value 
		{
			get
			{
				if ((IsUsed) && (this.Visible))
				{
					return m_value.Value;
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
				if (m_value.Value != value)
				{
					m_value.Value = value;
				}
			}
		}
		UIEditBaseValue m_value = new UIEditBaseValue();
		public UIEditValue ()
		{
			m_value.Left = CaptionWidth;
			m_value.Height = 23;
			this.Controls.Add(m_value);
			ChkResize();

			m_value.ValueChanged += M_value_ValueChanged;

		}

		private void M_value_ValueChanged(object sender, EventArgs e)
		{
			OnValueChanged(new EventArgs());
		}
	}
}
