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
	public class UIEditMargin : UIEditBase
	{
		private bool refFlag = false;

		public string Value
		{
			get
			{
				if ((IsUsed) && (this.Visible))
				{
					return m_marin.Value;
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
				if (m_marin.Value != value)
				{
					m_marin.Value = value;
				}
			}
		}

		UIEditBaseMarin m_marin = new UIEditBaseMarin();
		public UIEditMargin()
		{
			this.Size = new Size(320, 23);
			CaptionWidth = 90;
			m_marin.Size = new Size(225, 23);


			this.Controls.Add(m_marin);
			m_marin.ValueChanged += M_marin_ValueChanged;
		}

		private void M_marin_ValueChanged(object sender, EventArgs e)
		{
			if (refFlag) return;
			OnValueChanged(new EventArgs());
		}

		protected override void InitLayout()
		{
			base.InitLayout();
			this.Size = new Size(320, 23);
		}
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			m_marin.Location = new Point(CaptionWidth, (this.Height-23)/2);
			m_marin.Size = new Size(this.Width - CaptionWidth, 23);
		}
	}
}