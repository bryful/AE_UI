using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace AE_UI
{
	public enum UIType
	{
		Group = 0,
		Panel,
		Tab,
		TabbedPanel,

		Button,
		Checkbox,
		DropDownList,
		EditText,
		IconButton,
		Image,
		ListBox,
		Progressbar,
		RadioButton,
		Scrollbar,
		Slider,
		StaticText,
		TreeView
	}

	public enum ALGN_HOR
	{
		left,
		center,
		right,
		full
	}
	public enum ALGN_VUR
	{
		top,
		center,
		bottom,
		full
	}
	public enum Orientation
	{
		row,
		column,
		stack

	}

	public class UIParams
	{
		[JsonIgnore]
		static public readonly string[] UITypeTag = new string[]
		   {
			"Group",
			"Panel",
			"Tab",
			"TabbedPanel",
			"Button",
			"Checkbox",
			"DropDownList",
			"EditText",
			"IconButton",
			"Image",
			"ListBox",
			"Progressbar",
			"RadioButton",
			"Scrollbar",
			"Slider",
			"StaticText",
			"TreeView"
		   };
		[JsonIgnore]
		static public string[] PropTag = new string[]
		{
			"alignChildren",
			"alignment",
			"characters",
			"enabled",
			"icon",
			"image",
			"indent",
			"justify",
			"margins",
			"maximumSize",
			"minimumSize",
			"orientation",
			"preferredSize",
			"spacing",
			"text",
			"value",
			"visible",
			"properties"
		};
		[JsonIgnore]
		static public readonly string[] ALGN_HORTAG = new string[]
		{
			"left",
			"center",
			"right",
			"fill"
		};
		[JsonIgnore]
		static public readonly string[] ALGN_VURTAG = new string[]
		{
			"top",
			"center",
			"bottom",
			"fill"
		};
		static public readonly string[] ALGN_TAG = new string[]
		{
			"left",
			"top",
			"right",
			"bottom",
			"center",
			"fill"
		};
		[JsonIgnore]
		static public readonly string[] OriTAG = new string[]
		{
			"row",
			"column",
			"stack"
		};
		static public readonly string[] JUSTIFY_TAG = new string[]
		{
			"left",
			"center",
			"right"
		};
		/// <summary>
		/// 01
		/// </summary>
		public UIType UIType { get; set; }
		[JsonIgnore]
		public string UITypeStr
		{
			get { return UITypeTag[(int)UIType]; }
			set
			{
				UIType ret = UIType.Group;
				for (int i = 0; i < UITypeTag.Length; i++)
				{
					if (value == UITypeTag[i])
					{
						ret = (UIType)i;
						break;
					}
				}
				return;
			}
		}
		/// <summary>
		/// 02
		/// </summary>
		public string UIName { get; set; }
		[JsonIgnore]
		public string Caption{get { return UITypeStr + ":" + UIName; }}

		public string alignChildren { get; set; }
		public string alignment { get; set; }
		public string characters { get; set; }
		public string enabled { get; set; }
		public string icon { get; set; }
		public string image { get; set; }
		public string indent { get; set; }
		public string justify { get; set; }
		public string margins { get; set; }
		public string maximumSize { get; set; }
		public string minimumSize { get; set; }
		public string orientation { get; set; }
		public string preferredSize { get; set; }
		public string spacing { get; set; }
		public string text { get; set; }
		public string value { get; set; }
		public string visible { get; set; }
		public string properties { get; set; }
		//public 
		public UIParams[] Items { get; set; }



		public UIParams()
		{
			UIName = "";
			UIType = UIType.Group;
			alignChildren = "";
			alignment = "";
			characters = "";
			enabled = "";
			icon = "";
			image = "";
			indent = "";
			justify = "";
			margins = "";
			maximumSize = "";
			minimumSize = "";
			orientation = "";
			preferredSize = "";
			spacing = "";
			text = "";
			value = "";
			visible = "";
			properties = "";
			Items = new UIParams[0];
		}
		public void CopyFrom(UIParams prm)
		{
			this.UIName = prm.UIName;

			this.UIType = prm.UIType;
			this.alignChildren = prm.alignChildren;
			this.alignment = prm.alignment;
			this.characters = prm.characters;
			this.enabled = prm.enabled;
			this.icon = prm.icon;
			this.image = prm.image;
			this.indent = prm.indent;
			this.justify = prm.justify;
			this.margins = prm.margins;
			this.maximumSize = prm.maximumSize;
			this.minimumSize = prm.minimumSize;
			this.orientation = prm.orientation;
			this.preferredSize = prm.preferredSize;
			this.spacing = prm.spacing;
			this.text = prm.text;
			this.value = prm.value;
			this.visible = prm.visible;
			this.properties = prm.properties;

			if (this.UIName == null) this.UIName = "";
			if (this.alignChildren == null) this.alignChildren = "";
			if (this.alignment == null) this.alignment = "";
			if (this.characters == null) this.characters = "";
			if (this.enabled == null) this.enabled = "";
			if (this.icon == null) this.icon = "";
			if (this.image == null) this.image = "";
			if (this.indent == null) this.indent = "";
			if (this.justify == null) this.justify = "";
			if (this.margins == null) this.margins = "";
			if (this.maximumSize == null) this.maximumSize = "";
			if (this.minimumSize == null) this.minimumSize = "";
			if (this.orientation == null) this.orientation = "";
			if (this.preferredSize == null) this.preferredSize = "";
			if (this.spacing == null) this.spacing = "";
			if (this.text == null) this.text = "";
			if (this.value == null) this.value = "";
			if (this.visible == null) this.visible = "";
			if (this.properties == null) this.properties = "";

		}
		static public string WAdd(string s)
		{
			s = s.Trim();
			if (s == "\"\"") return s;
			if (s == "\"") return "\"\"";

			if (s.Length>0)
			{
				if (s[0] != '\"') s = "\"" + s;
				if (s[s.Length - 1] != '\"') s = s + "\"";
			}
			return s;
		}
		static public string WDel(string s)
		{
			s = s.Trim();
			if (s.Length>0)
			{
				if (s[0] == '\"') s = s.Substring(1);
			}
			if (s.Length > 0)
			{
				if (s[s.Length-1] == '\"') s = s.Substring(0,s.Length-1);
			}
			return s;
		}

	

		// **************************************************************
		static public double[] StrToArrayNum(string s)
		{
			string a = s.Trim();
			if (s.Length <= 2) return new double[0];
			if ((s[0]=='[')&& (s[s.Length-1] == ']'))
			{
				s = s.Substring(1, s.Length - 2).Trim();
			}
			else
			{
				return new double[0];
			}
			if (s=="") return new double[0];
			string[] sa = s.Split(',');
			double[] ret = new double[sa.Length];

			for ( int i=0; i< sa.Length; i++)
			{
				double v = 0;
				if (double.TryParse(sa[i], out v))
				{
					ret[i] = v;
				}
				else
				{
					ret[i] = 0;
				}
			}
			return ret;

		}
	}
}
