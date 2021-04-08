using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace AE_UI
{
	public class UITreeNode :TreeNode
	{

		private UIParams m_Params = new UIParams();
		public UIParams Params { get { return m_Params; } }
		public void SetParams(UIParams value)
		{
			m_Params.CopyFrom(value);
			this.Text = m_Params.Caption;
		}
		public string ToJson()
		{
			return JsonSerializer.Serialize(m_Params);
		}

	}
}
