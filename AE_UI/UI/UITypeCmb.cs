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

	public class UITypeCmb :ComboBox
	{
		[Category("AE")]
		public UIType UIType
		{
			get { return (UIType)this.SelectedIndex; }
			set
			{
				if (this.SelectedIndex != (int)value)
				{
					this.SelectedIndex = (int)value;
				}
			}
		}
		[Category("AE")]
		public string Value
		{
			get { return UIParams.UITypeTag[this.SelectedIndex]; }

			set
			{
				string v = value.ToLower().Trim();
				int idx = 0;
				for ( int i=0; i< UIParams.UITypeTag.Length;i++)
				{
					if (UIParams.UITypeTag[i].ToLower()==v)
					{
						idx = i;
						break;
					}
				}
				if (this.SelectedIndex != idx)
				{
					this.SelectedIndex = idx;
				}
			}

		}

		public UITypeCmb()
		{
			this.Font = new Font(this.Font.FontFamily, 12f);
		}
		protected override void InitLayout()
		{
			base.InitLayout();
			this.Items.Clear();
			this.Items.AddRange(UIParams.UITypeTag);
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.SelectedIndex = 0;
			this.DropDownHeight = 400;
			this.Size = new Size(110, 23);
		}
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			base.OnSelectedIndexChanged(e);
		}
	}
}
