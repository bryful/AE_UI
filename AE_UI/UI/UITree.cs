using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;

namespace AE_UI
{
	public class UITree :TreeView
	{
		// カット&ペースト用
		private UIParams m_CopyBuf = new UIParams();
		private bool m_IsCopy = false;
		[Category("AE")]
		public bool IsCopy { get { return m_IsCopy; } }
		//private bool refFlag = false;

		public readonly string BaseCode =
		"(function (me){\r\n" +
		"var winObj = (me instanceof Panel)? me : new Window('palette{text:\"Test\",orientation : \"column\", properties : {resizeable : true} }');\r\n" +
		"var res1 =\r\n" +
		"$CODE;\r\n" +
		"winObj.gr = winObj.add(res1 );\r\n" +
		"winObj.layout.layout();\r\n" +
		"winObj.onResize = function()\r\n" +
		"{\r\n" +
		"  winObj.layout.resize();\r\n" +
		"}\r\n" +
		"if(winObj instanceof Window ) winObj.show();\r\n" +
		"})(this);\r\n";

		#region control
// **********************************************
private TextBox m_Debug = null;
		[Category("AE")]
		public TextBox Debug
		{
			get { return m_Debug; }
			set
			{
				m_Debug = value;
				if (m_Debug != null)
				{
				}
			}
		}
		// **********************************************
		private Button m_DelBtn = null;
		[Category("AE")]
		public Button DelBtn
		{
			get { return m_DelBtn; }
			set
			{
				m_DelBtn = value;
				if(m_DelBtn!=null)
				{
					m_DelBtn.Enabled = (this.SelectedNode != null);
					m_DelBtn.Click += M_DelBtn_Click;
				}
			}
		}
		// **********************************************
		private void M_DelBtn_Click(object sender, EventArgs e)
		{
			Del();
		}
		// **********************************************
		private Button m_MoveUpBtn = null;
		[Category("AE")]
		public Button MoveUpBtn
		{
			get { return m_MoveUpBtn; }
			set
			{
				m_MoveUpBtn = value;
				if (m_MoveUpBtn != null)
				{
					m_MoveUpBtn.Enabled = (this.SelectedNode != null);
					m_MoveUpBtn.Click += M_MoveUpBtn_Click;
				}
			}
		}

		private void M_MoveUpBtn_Click(object sender, EventArgs e)
		{
			MoveUp();
		}
		// **********************************************
		private Button m_MoveDownBtn = null;
		[Category("AE")]
		public Button MoveDownBtn
		{
			get { return m_MoveDownBtn; }
			set
			{
				m_MoveDownBtn = value;
				if (m_MoveDownBtn != null)
				{
					m_MoveDownBtn.Enabled = (this.SelectedNode != null);
					m_MoveDownBtn.Click += M_MoveDownBtn_Click;
				}
			}
		}

		private void M_MoveDownBtn_Click(object sender, EventArgs e)
		{
			MoveDown();
		}
		// **********************************************
		private UIPanelEdits m_PanelEdit = null;
		[Category("AE")]
		public UIPanelEdits PanelEdit
		{
			get { return m_PanelEdit; }
			set
			{
				m_PanelEdit = value;
				if(m_PanelEdit!=null)
				{
					m_PanelEdit.ValueChanged += PanelEdit_ValueChanged;
				}
			}
		}
		private void PanelEdit_ValueChanged(object sender, EventArgs e)
		{
			if (this.SelectedNode != null)
			{
				bool IsRoot = (m_root.Handle == this.SelectedNode.Handle);
				UITreeNode tn = (UITreeNode)this.SelectedNode;


				UIParams p = m_PanelEdit.GetParams();
				if (p.UIName=="") p.UIName = "Untitle";

				//= m_PanelEdit.GetParams();

				if (IsRoot)
				{
					p.UIType = UIType.Group;
				}


				tn.SetParams(p);
				DebugOut();

			}
		}
		// **********************************************
		private UIAddBtn m_UIAddBtn = null;
		[Category("AE")]
		public UIAddBtn UIAddBtn
		{
			get { return m_UIAddBtn; }
			set
			{
				m_UIAddBtn = value;
				if(m_UIAddBtn != null)
				{
					m_UIAddBtn.Exec += M_UIAddBtn_Exec;
				}

			}
		}

		private void M_UIAddBtn_Exec(object sender, EventArgs e)
		{
			if (m_UIAddBtn != null)
			{
				AddUI(m_UIAddBtn.Params);
			}
		}
		#endregion

		// ***************************************************************************************
		// ***************************************************************************************
		/// <summary>
		/// ルート
		/// </summary>
		private UITreeNode m_root = new UITreeNode();
		public UITree()
		{

			this.FullRowSelect = true;
			this.HideSelection = false;
			this.AfterSelect += AEUITree_AfterSelect;
			if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Runtime)
			{
				RemoveAll();
			}
		}
		protected override void InitLayout()
		{
			base.InitLayout();
			if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Runtime)
			{
				RemoveAll();
			}
		}
		// ***************************************************************************************
		// ***************************************************************************************
		public void RemoveAll()
		{
			if (this.Nodes.Count>0)
			{
				for (int i = this.Nodes.Count - 1; i >= 0; i--) this.Nodes[i].Remove();
			}
		}
		private void DebugOut()
		{
			if (m_Debug != null)
			{
				if (this.SelectedNode != null)
				{
					m_Debug.Text = ((UITreeNode)this.SelectedNode).ToJson();
					//m_Debug.Text = this.SelectedNode.Handle.ToString() + ":" + this.SelectedNode.FullPath;
				}
			}
		}
		// ***************************************************************************************

		private void AEUITree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if(m_PanelEdit !=null)
			{
				if (this.SelectedNode != null)
				{
					UITreeNode tn = (UITreeNode)this.SelectedNode;
					if (tn.Handle == m_root.Handle)
					{
						tn.Params.UIType = UIType.Group;
						tn.Params.alignment = " [\"fill\", \"fill\" ]";
					}
					m_PanelEdit.SetParams(tn.Params);
				}
			}
			if(m_DelBtn !=null)
			{
				m_DelBtn.Enabled = (this.SelectedNode != null);
			}
			if(m_MoveUpBtn!=null)
			{
				m_MoveUpBtn.Enabled = (this.SelectedNode != null);
			}
			if (m_MoveDownBtn != null)
			{
				m_MoveDownBtn.Enabled = (this.SelectedNode != null);
			}
			DebugOut();
		}
		// ***************************************************************************************


		public void AddUI(UIParams prm)
		{
			// 何もなかったらRootを作成
			if(this.Nodes.Count<=0)
			{
				AddRoot();
			}

			if (prm.UIName == "") prm.UIName = "unname";
			UITreeNode tn = new UITreeNode();
			tn.SetParams(prm);

			if (this.SelectedNode ==null)
			{
				m_root.Nodes.Add(tn);
				m_root.Expand();
			}
			else
			{
				UITreeNode p = (UITreeNode)this.SelectedNode;
				if( (p.Params.UIType== UIType.Group)|| (p.Params.UIType == UIType.Panel)
					|| (p.Params.UIType == UIType.Tab) || (p.Params.UIType == UIType.TabbedPanel))
				{
					this.SelectedNode.Nodes.Add(tn);
					this.SelectedNode.Expand();

				}
				else
				{
					UITreeNode tnp = (UITreeNode)this.SelectedNode.Parent;
					if (tnp != null)
					{
						tnp.Nodes.Insert(this.SelectedNode.Index + 1,tn);
						this.SelectedNode = tn;
						tnp.Expand();
					}
				}
			}
		}
		public void Del()
		{
			if (this.SelectedNode!=null)
			{
				if (this.SelectedNode.Handle != m_root.Handle)
				{
					this.SelectedNode.Remove();
				}
			}
		}
		public void MoveUp()
		{
			if (this.SelectedNode != null)
			{
				var tn = this.SelectedNode;
				var parentNode = tn.Parent;
				var index = parentNode.Nodes.IndexOf(tn);
				var cnt = parentNode.Nodes.Count;
				if ( index>0)
				{
					tn.Remove();
					parentNode.Nodes.Insert(index - 1, tn);
					this.SelectedNode = tn;
				}
			}
		}
		public void MoveDown()
		{
			if (this.SelectedNode != null)
			{
				var tn = this.SelectedNode;
				var parentNode = tn.Parent;
				var index = parentNode.Nodes.IndexOf(tn);
				var cnt = parentNode.Nodes.Count;
					tn.Remove();
				parentNode.Nodes.Insert(index+1, tn);
				this.SelectedNode = tn;
			}
		}
		// ***********************************************************************
		public void AddRoot()
		{
			if( this.Nodes.Count>0)
			{
				for(int i= this.Nodes.Count-1; i>=0;i--)
				{
					this.Nodes[i].Remove();
				}
			}

			UIParams p = new UIParams();
			p.UIType = UIType.Group;
			p.UIName = "root";
			p.orientation = "\"row\"";
			p.alignment = "[\"fill\",\"fill\"]";

			m_root.SetParams(p);
			this.Nodes.Add(m_root);

		}
		public UIParams GetParams(UITreeNode tn)
		{
			UIParams ret = new UIParams();
			ret.CopyFrom(tn.Params);

			if (tn.Nodes.Count>0)
			{
				UIParams[] items = new UIParams[tn.Nodes.Count];
				for (int i=0; i< tn.Nodes.Count; i++)
				{
					UIParams pp = new UIParams();
					pp = GetParams((UITreeNode)tn.Nodes[i]);
					items[i] = pp;
				}
				ret.Items = items;
			}
			return ret;
		}
		public string GetSaveData()
		{
			UIParams prm = GetParams(m_root);
			var options = new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
				WriteIndented = true
			};
			string js = JsonSerializer.Serialize(prm, options);
			return js;

		}
		// ***************************************************************************************************
		public bool Save(string p)
		{
			bool ret = false;

			UIParams prm = GetParams(m_root);
			var options = new JsonSerializerOptions
			{
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
				WriteIndented = true
			};
			string js = JsonSerializer.Serialize(prm, options);

			try
			{
				File.WriteAllText(p, js, Encoding.GetEncoding("utf-8"));
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}

		// ***************************************************************************************************
		public bool Load(string p)
		{
			bool ret = false;

			try
			{
				if (File.Exists(p) == true)
				{
					string str = File.ReadAllText(p, Encoding.GetEncoding("utf-8"));
					if (str != "")
					{
						var options = new JsonSerializerOptions
						{
							Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
						};
						UIParams prm = JsonSerializer.Deserialize<UIParams>(str, options);
						AddRoot();
						SetParams(m_root, prm);
						ret = true;
					}
				}
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// ***************************************************************************************************
		public void SetParams(UITreeNode tn, UIParams prm)
		{
			tn.SetParams(prm);

			if (tn.Nodes.Count>0)
			{
				for (int i = tn.Nodes.Count-1; i >=0; i--)
				{
					tn.Nodes[i].Remove();
				}

			}

			if (prm.Items.Length>0)
			{
				for (int i=0;i< prm.Items.Length;i++)
				{
					UITreeNode ttn = new UITreeNode();
					tn.Nodes.Add(ttn);
					SetParams(ttn, prm.Items[i]);
				}
				tn.Expand();
			}

		}
		// ***************************************************************************************************
		public void GetResAll()
		{
			UIParams prm = GetParams(m_root);

			string s = GetRes(prm, false);
			s = "'" + s + "';";
			ResultForm.Show(s,"Resource");
		}
		// ***************************************************************************************************
		public string SampleScriptCode()
		{
			UIParams prm = GetParams(m_root);
			string s = GetRes(prm, false);
			s = "'" + s + "'";
			string ret = BaseCode;
			return ret.Replace("$CODE", s);

		}
		// ***************************************************************************************************
		public string GetRes(UIParams prms,bool IsName = true)
		{
			string ret = "";


			if (prms.alignChildren !="")
			{
				if (ret != "") ret += ",";
				ret += "alignChildren" + ":" + prms.alignChildren;

			}
			if (prms.alignment != "")
			{
				if (ret != "") ret += ",";
				ret += "alignment" + ":" + prms.alignment;

			}
			if (prms.characters != "")
			{
				if (ret != "") ret += ",";
				ret += "characters" + ":" + prms.characters;

			}
			if (prms.enabled != "")
			{
				if (ret != "") ret += ",";
				ret += "enabled" + ":" + prms.enabled;

			}
			if (prms.icon != "")
			{
				if (ret != "") ret += ",";
				ret += "icon" + ":" + prms.icon;
			}
			if (prms.image != "")
			{
				if (ret != "") ret += ",";
				ret += "image" + ":" + prms.image;
			}
			if (prms.indent != "")
			{
				if (ret != "") ret += ",";
				ret += "indent" + ":" + prms.indent;
			}
			if (prms.justify != "")
			{
				if (ret != "") ret += ",";
				ret += "justify" + ":" + prms.justify;
			}
			if (prms.margins != "")
			{
				if (ret != "") ret += ",";
				ret += "margins" + ":" + prms.margins;
			}
			if (prms.maximumSize != "")
			{
				if (ret != "") ret += ",";
				ret += "maximumSize" + ":" + prms.maximumSize;
			}
			if (prms.minimumSize != "")
			{
				if (ret != "") ret += ",";
				ret += "minimumSize" + ":" + prms.minimumSize;
			}
			if (prms.orientation != "")
			{
				if (ret != "") ret += ",";
				ret += "orientation" + ":" + prms.orientation;
			}
			if (prms.preferredSize != "")
			{
				if (ret != "") ret += ",";
				ret += "preferredSize" + ":" + prms.preferredSize;
			}
			if (prms.spacing != "")
			{
				if (ret != "") ret += ",";
				ret += "spacing" + ":" + prms.spacing;
			}
			if (prms.text != "")
			{
				if (ret != "") ret += ",";
				ret += "text" + ":" + prms.text;
			}
			if (prms.value != "")
			{
				if (ret != "") ret += ",";
				ret += "value" + ":" + prms.value;
			}
			if (prms.visible != "")
			{
				if (ret != "") ret += ",";
				ret += "visible" + ":" + prms.visible;
			}
			if (prms.properties != "")
			{
				if (ret != "") ret += ",";
				ret += "properties" + ":" + prms.properties;
			}



			string b = "";
			if (prms.Items.Length>0)
			{
				for (int i=0; i < prms.Items.Length; i++)
				{
					if (b != "") b += ",";
					b += GetRes(prms.Items[i]);
				}
			}
			if (b != "") b = ","  + b;

			if (IsName)
			{
				ret = prms.UITypeStr + "{" + ret + b + "}";
				ret = "\\\r\n" + prms.UIName + ":" + ret;
			}
			else
			{
				ret = prms.UITypeStr + "{" + ret + b + "\\\r\n}";
			}
			return ret;
		}
		// ***************************************************************************************************
		public void CopyData()
		{
			if((this.SelectedNode != null) && (this.SelectedNode.Handle != m_root.Handle))
			{
				UITreeNode tn = (UITreeNode)this.SelectedNode;
				m_CopyBuf.CopyFrom(tn.Params);
				m_IsCopy = true;
			}
		}
		// ***************************************************************************************************
		public void PasteData()
		{
			if(m_IsCopy)
			{
				AddUI(m_CopyBuf);
			}
		}
	}
}
