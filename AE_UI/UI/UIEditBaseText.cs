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
	public class UIEditBaseText :TextBox
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
		public string Value
		{
			get
			{
				if (m_IsQValue)
				{
					return UIParams.WAdd(this.Text.Trim());
				}
				else
				{
					return this.Text;
				}
			}
			set 
			{
				if (m_IsQValue)
				{
					this.Text = UIParams.WDel(value);
				}
				else
				{
					this.Text = value;
				}
			}
		}
		private bool m_IsQValue = true;
		[Category("AE")]
		public bool IsQValue
		{
			get { return m_IsQValue; }
			set
			{
				m_IsQValue = value;
				OnValueChanged(new EventArgs());
			}
		}
		public UIEditBaseText()
		{
			this.Size = new Size(150, 23);

			this.TextChanged += UIEditBaseText_TextChanged;
		}

		private void UIEditBaseText_TextChanged(object sender, EventArgs e)
		{
			OnValueChanged(new EventArgs());
		}
	}
}
