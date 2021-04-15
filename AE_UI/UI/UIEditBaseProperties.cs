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
	public class UIEditBaseProperties : TextBox
	{
		public string CBAdd(string s)
		{
			if (s == "") return "{}";

			if (s[0] != '{') s = "{" + s;
			if (s[s.Length - 1] != '}') s = s + "}";
			return s;
		}
		public string CBDel(string s)
		{
			if (s == "") return "";

			if (s[0] == '{') s = s.Substring(1);
			if (s.Length > 0)
			{
				if (s[s.Length - 1] == '}') 
					s = s.Substring(0, s.Length - 1);
			}
			return s;
		}
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
				return CBAdd(this.Text.Trim());
			}
			set
			{
				this.Text = CBDel(value);
			}
		}
		public UIEditBaseProperties()
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
