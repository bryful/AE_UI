using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;

namespace AE_UI
{
	public class AppPrefFile
	{

		public Point Loc { get; set; }
		public Size Size { get; set; }
		public string FileName { get; set; }

		public void SetForm(Form f)
		{
			this.Loc = f.Location;
			this.Size = f.Size;
		}

	}
	public class PrefFile
	{
		public AppPrefFile AppPref { set; get; }
		public string PrefPath { set; get; }

		public PrefFile()
		{
			string ap = AppName();
			string p = AppFolder(ap);

			PrefPath = Path.Combine(p, ap + ".json");
			AppPref = new AppPrefFile();
		}
		// ***************************************************************
		static public string AppName()
		{
			return Path.GetFileNameWithoutExtension(Application.ExecutablePath);
		}
		// ***************************************************************
		static public string AppFolder(string a="")
		{
			string p = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			if (a == "")
			{
				a = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
			}

			string p2 = Path.Combine(p, a);
			if (Directory.Exists(p2)==false)
			{
				Directory.CreateDirectory(p2);
			}
			return p2;

		}
		// ***************************************************************
		public bool Save(string p = "")
		{
			bool ret = false;
			if (p == "")
			{
				string ap = AppName();
				p = Path.Combine(AppFolder(ap), ap + ".json");
			}
			try
			{
				var options = new JsonSerializerOptions
				{
					Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
					WriteIndented = true
				};
				string js = JsonSerializer.Serialize(AppPref, options);
				File.WriteAllText(PrefPath, js, Encoding.GetEncoding("utf-8"));
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// ***************************************************************
		public bool Load(string p="")
		{
			bool ret = false;
			if (p == "")
			{
				string ap = AppName();
				p = Path.Combine(AppFolder(ap), ap + ".json");
			}

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
						AppPrefFile ld = JsonSerializer.Deserialize<AppPrefFile>(str, options);
						AppPref = ld;
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
		// ***************************************************************
	}

}
