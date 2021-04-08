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
	public class UIAddBtn :Control
	{
		public event EventHandler Exec;

		protected virtual void OnExec(EventArgs e)
		{
			if (Exec != null)
			{
				Exec(this, e);
			}
		}
		private UITypeCmb m_cmb = new UITypeCmb();
		private TextBox m_name = new TextBox();
		private Button m_btn = new Button();



		
		public UIAddBtn()
		{
			int x = 0;
			int y = 0;
			int h = 25;
			this.Size = new Size(250, h);

			m_cmb.Location = new Point(x, y);
			m_cmb.MinimumSize = new Size(90, h);
			m_cmb.MaximumSize = new Size(90, h);
			m_cmb.Size = new Size(90, h);

			x += m_cmb.Width+5;

			m_name.Location =  new Point(x, y);
			m_name.Size = new Size(90, h);
			m_name.Font = new Font(this.Font.FontFamily, 12f);
			x += m_name.Width+5;

			m_btn.Location = new Point(x, y);
			m_btn.Size = new Size(50, h);
			m_btn.Text = "Add";
			m_btn.Enabled = false;
			x += m_btn.Width;

			this.Controls.Add(m_cmb);
			this.Controls.Add(m_name);
			this.Controls.Add(m_btn);

			m_name.TextChanged += M_name_TextChanged;
			m_btn.Click += M_btn_Click;
		}

		// *********************************************************
		private void M_btn_Click(object sender, EventArgs e)
		{
			OnExec(new EventArgs());
		}

		// *********************************************************
		private void M_name_TextChanged(object sender, EventArgs e)
		{
			TextBox tb = (TextBox)sender;

			m_btn.Enabled = (tb.Text != "");
		}

		// *********************************************************
		protected override void InitLayout()
		{
			base.InitLayout();
			this.Size = new Size(250, 25);
			this.MinimumSize = new Size(250, 25);
		}
		// *********************************************************

		
		public UIParams Params
		{
			get
			{
				UIParams prm = new UIParams();
				prm.UIName = m_name.Text.Trim();
				prm.UIType = m_cmb.UIType;


				if ((prm.UIType == UIType.Group)|| (prm.UIType == UIType.Panel))
				{
					prm.orientation = "row";
				}
				if (
					(prm.UIType == UIType.Panel)
					|| (prm.UIType == UIType.Button)
					|| (prm.UIType == UIType.Checkbox)
					|| (prm.UIType == UIType.RadioButton)
					|| (prm.UIType == UIType.StaticText)
					)
				{
					prm.text = "\"name\"";
				}

				return prm;
			}
		}
		


	}
}
