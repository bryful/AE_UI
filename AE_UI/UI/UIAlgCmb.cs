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

	public class UIAlgCmb : ComboBox
	{

		[Category("AE")]
		public string Value
		{
			get {
				int idx = this.SelectedIndex;
				if ((idx < 0) || (idx >= UIParams.ALGN_TAG.Length))
				{
					idx = 0;
				}
				return UIParams.WAdd(UIParams.ALGN_TAG[idx]);
			}

			set
			{
				string s = UIParams.WDel(value).ToLower().Trim();
				int idx = 0;

				for (int i = 0; i < UIParams.ALGN_TAG.Length; i++)
				{
					if (UIParams.ALGN_TAG[i] == s)
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
		protected override void InitLayout()
		{
			base.InitLayout();
			this.Items.Clear();
			this.Items.AddRange(UIParams.ALGN_TAG);
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.SelectedIndex = 0;
			this.Size = new Size(120, 23);
		}
	}
	public class UIAlgHorCmb : ComboBox
	{

		[Category("AE")]
		public string Value
		{
			get { return UIParams.WAdd(UIParams.ALGN_HORTAG[this.SelectedIndex]); }

			set
			{
				string s = UIParams.WDel(value).ToLower().Trim();
				int idx = 0;

				for ( int i=0;i< UIParams.ALGN_HORTAG.Length;i++)
				{
					if (UIParams.ALGN_HORTAG[i]==s)
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
		protected override void InitLayout()
		{
			base.InitLayout();
			this.Items.Clear();
			this.Items.AddRange(UIParams.ALGN_HORTAG);
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.SelectedIndex = 0;
			this.Size = new Size(120, 23);
		}
	}
	public class UIAlgVurCmb : ComboBox
	{

		[Category("AE")]
		public string Value
		{
			get { return UIParams.WAdd( UIParams.ALGN_VURTAG[this.SelectedIndex]); }

			set
			{
				string s = UIParams.WDel(value).ToLower().Trim();
				int idx = 0;

				for (int i = 0; i < UIParams.ALGN_VURTAG.Length; i++)
				{
					if (UIParams.ALGN_VURTAG[i] == s)
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
		protected override void InitLayout()
		{
			base.InitLayout();
			this.Items.Clear();
			this.Items.AddRange(UIParams.ALGN_VURTAG);
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.SelectedIndex = 0;
			this.Size = new Size(120, 23);
		}
	}
	public class UIOriCmb : ComboBox
	{
		[Category("AE")]
		public string Value
		{
			get { return UIParams.WAdd( UIParams.OriTAG[this.SelectedIndex]); }

			set
			{
				string s = UIParams.WDel( value).ToLower().Trim();
				int idx = 0;

				for (int i = 0; i < UIParams.OriTAG.Length; i++)
				{
					if (UIParams.OriTAG[i] == s)
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
		protected override void InitLayout()
		{
			base.InitLayout();
			this.Items.Clear();
			this.Items.AddRange(UIParams.OriTAG);
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.SelectedIndex = 0;
			this.Size = new Size(120, 23);
		}
	}
	public class UIJustifyCmb : ComboBox
	{
		[Category("AE")]
		public string Value
		{
			get { return UIParams.WAdd(UIParams.JUSTIFY_TAG[this.SelectedIndex]); }

			set
			{
				string s = UIParams.WDel(value).ToLower().Trim();
				int idx = 0;

				for (int i = 0; i < UIParams.JUSTIFY_TAG.Length; i++)
				{
					if (UIParams.JUSTIFY_TAG[i] == s)
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
		protected override void InitLayout()
		{
			base.InitLayout();
			this.Items.Clear();
			this.Items.AddRange(UIParams.JUSTIFY_TAG);
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.SelectedIndex = 0;
			this.Size = new Size(120, 24);
		}
	}
}
