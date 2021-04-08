using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace AE_UI
{

	public partial class UIPanelEdits : UserControl
	{
		private bool refFlag = false;
		public event EventHandler ValueChanged;

		protected virtual void OnValueChanged(EventArgs e)
		{
			if (refFlag) return;
			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}
		}
		public UIParams GetParams()
		{
			UIParams ret = new UIParams();
			ret.UIName = TbUIName.Text.Trim();
			ret.UIType = CmbUIType.UIType;

			ret.enabled = PeEnabled.Value;
			ret.visible = PeVisible.Value;
			ret.text = PeText.Value;
			ret.justify = PeJustify.Value;
			ret.value = PeValue.Value;
			ret.image = PeImage.Value;
			ret.icon = PeIcon.Value;
			ret.orientation = PeOrientation.Value;
			ret.preferredSize = PePreferredSize.Value;
			ret.characters = PeCharacters.Value;
			ret.alignment = PeAlignment.Value;
			ret.alignChildren = PeAlignChildren.Value;
			ret.margins = PeMargin.Value;
			ret.spacing = PeSpacing.Value;
			ret.indent = PeIndent.Value;
			ret.minimumSize = PeMinimumSize.Value;
			ret.maximumSize = PeMaximumSize.Value;

			return ret;
		}
		public void SetParams(UIParams value)
		{
			refFlag = true;

			TbUIName.Text = value.UIName;
			CmbUIType.UIType = value.UIType;
			PeEnabled.Value = value.enabled;
			PeVisible.Value = value.visible;
			PeText.Value = value.text;
			PeJustify.Value = value.justify;
			PeValue.Value = value.value;
			PeImage.Value = value.image;
			PeOrientation.Value = value.orientation;
			PePreferredSize.Value = value.preferredSize;
			PeCharacters.Value = value.characters;
			PeAlignment.Value = value.alignment;
			PeAlignChildren.Value = value.alignChildren;
			PeMargin.Value = value.margins;
			PeSpacing.Value = value.spacing;
			PeIndent.Value = value.indent;
			PeMaximumSize.Value = value.maximumSize;
			PeMinimumSize.Value = value.minimumSize;
			PeIcon.Value = value.icon;

			refFlag = false;


		}
		public UIPanelEdits()
		{
			InitializeComponent();

			TbUIName.TextChanged += TbUIName_TextChanged;
			PeEnabled.ValueChanged += TbUIName_TextChanged;
			PeVisible.ValueChanged += TbUIName_TextChanged;
			PeText.ValueChanged += TbUIName_TextChanged;
			PeJustify.ValueChanged += TbUIName_TextChanged;
			PeValue.ValueChanged += TbUIName_TextChanged;
			PeImage.ValueChanged += TbUIName_TextChanged;
			PeOrientation.ValueChanged += TbUIName_TextChanged;
			PePreferredSize.ValueChanged += TbUIName_TextChanged;
			PeCharacters.ValueChanged += TbUIName_TextChanged;
			PeAlignment.ValueChanged += TbUIName_TextChanged;
			PeAlignChildren.ValueChanged += TbUIName_TextChanged;
			PeMargin.ValueChanged += TbUIName_TextChanged;
			PeSpacing.ValueChanged += TbUIName_TextChanged;
			PeIndent.ValueChanged += TbUIName_TextChanged;

			PeIcon.ValueChanged += TbUIName_TextChanged;
			PeMaximumSize.ValueChanged += TbUIName_TextChanged;
			PeMinimumSize.ValueChanged += TbUIName_TextChanged;


			SetMode(CmbUIType.UIType);

			CmbUIType.SelectedIndexChanged += CmbUIType_SelectedIndexChanged;
		}

		private void CmbUIType_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetMode(CmbUIType.UIType);
			OnValueChanged(new EventArgs());
		}

		private void TbUIName_TextChanged(object sender, EventArgs e)
		{
			OnValueChanged(new EventArgs());
		}
		public void SetMode(UIType tp)
		{
			switch(tp)
			{
				case UIType.Panel:
				case UIType.TabbedPanel:
				case UIType.Tab:
					PeAlignChildren.Visible = true;
					PeAlignment.Visible = true;
					PeCharacters.Visible = true;
					PeEnabled.Visible = true;
					PeIcon.Visible = false;
					PeImage.Visible = false;
					PeJustify.Visible = false;
					PeMargin.Visible = true;
					PeMaximumSize.Visible = true;
					PeMinimumSize.Visible = true;
					PeOrientation.Visible = true;
					PePreferredSize.Visible = true;
					PeSpacing.Visible = true;
					PeText.Visible = true;
					PeValue.Visible = false;
					PeVisible.Visible = true;
					break;
				case UIType.Group:
					PeAlignChildren.Visible = true;
					PeAlignment.Visible = true;
					PeCharacters.Visible = true;
					PeEnabled.Visible = true;
					PeIcon.Visible = false;
					PeImage.Visible = false;
					PeJustify.Visible = false;
					PeMargin.Visible = true;
					PeMaximumSize.Visible = true;
					PeMinimumSize.Visible = true;
					PeOrientation.Visible = true;
					PePreferredSize.Visible = true;
					PeSpacing.Visible = true;
					PeText.Visible = false;
					PeValue.Visible = false;
					PeVisible.Visible = true;
					break;
				case UIType.Button:
				case UIType.EditText:
					PeAlignChildren.Visible = false;
					PeAlignment.Visible = true;
					PeCharacters.Visible = false;
					PeEnabled.Visible = true;
					PeIcon.Visible = false;
					PeImage.Visible = false;
					PeJustify.Visible = true;
					PeMargin.Visible = false;
					PeMaximumSize.Visible = true;
					PeMinimumSize.Visible = true;
					PeOrientation.Visible = false;
					PePreferredSize.Visible = true;
					PeSpacing.Visible = false;
					PeText.Visible = true;
					PeValue.Visible = false;
					PeVisible.Visible = true;
					break;
				case UIType.Scrollbar:
					PeAlignChildren.Visible = false;
					PeAlignment.Visible = true;
					PeCharacters.Visible = false;
					PeEnabled.Visible = true;
					PeIcon.Visible = false;
					PeImage.Visible = false;
					PeJustify.Visible = false;
					PeMargin.Visible = false;
					PeMaximumSize.Visible = true;
					PeMinimumSize.Visible = true;
					PeOrientation.Visible = false;
					PePreferredSize.Visible = true;
					PeSpacing.Visible = false;
					PeText.Visible = false;
					PeValue.Visible = true;
					PeVisible.Visible = true;

					PeValue.IsBool =false;

					break;
				case UIType.Progressbar:
				case UIType.Slider:
					PeAlignChildren.Visible = false;
					PeAlignment.Visible = true;
					PeCharacters.Visible = false;
					PeEnabled.Visible = true;
					PeIcon.Visible = false;
					PeImage.Visible = false;
					PeJustify.Visible = false;
					PeMargin.Visible = false;
					PeMaximumSize.Visible = true;
					PeMinimumSize.Visible = true;
					PeOrientation.Visible = false;
					PePreferredSize.Visible = true;
					PeSpacing.Visible = false;
					PeText.Visible = true;
					PeValue.Visible = true;
					PeVisible.Visible = true;

					PeValue.IsBool = false;

					break;
				case UIType.TreeView:
				case UIType.ListBox:
					PeAlignChildren.Visible = false;
					PeAlignment.Visible = true;
					PeCharacters.Visible = false;
					PeEnabled.Visible = true;
					PeIcon.Visible = false;
					PeImage.Visible = false;
					PeJustify.Visible = false;
					PeMargin.Visible = false;
					PeMaximumSize.Visible = true;
					PeMinimumSize.Visible = true;
					PeOrientation.Visible = false;
					PePreferredSize.Visible = true;
					PeSpacing.Visible = false;
					PeText.Visible = false;
					PeValue.Visible = false;
					PeVisible.Visible = true;
					break;
				case UIType.RadioButton:
					PeAlignChildren.Visible = false;
					PeAlignment.Visible = true;
					PeCharacters.Visible = false;
					PeEnabled.Visible = true;
					PeIcon.Visible = false;
					PeImage.Visible = false;
					PeJustify.Visible = true;
					PeMargin.Visible = false;
					PeMaximumSize.Visible = true;
					PeMinimumSize.Visible = true;
					PeOrientation.Visible = false;
					PePreferredSize.Visible = true;
					PeSpacing.Visible = false;
					PeText.Visible = true;
					PeValue.Visible = true;
					PeVisible.Visible = true;

					PeValue.IsBool = true;

					break;
				case UIType.DropDownList:
					PeAlignChildren.Visible = false;
					PeAlignment.Visible = true;
					PeCharacters.Visible = false;
					PeEnabled.Visible = true;
					PeIcon.Visible = false;
					PeImage.Visible = false;
					PeJustify.Visible = false;
					PeMargin.Visible = false;
					PeMaximumSize.Visible = true;
					PeMinimumSize.Visible = true;
					PeOrientation.Visible = false;
					PePreferredSize.Visible = true;
					PeSpacing.Visible = false;
					PeText.Visible = true;
					PeValue.Visible = false;
					PeVisible.Visible = true;
					break;
				case UIType.StaticText:
					PeAlignChildren.Visible = false;
					PeAlignment.Visible = true;
					PeCharacters.Visible = false;
					PeEnabled.Visible = true;
					PeIcon.Visible = false;
					PeImage.Visible = false;
					PeJustify.Visible = true;
					PeMargin.Visible = false;
					PeMaximumSize.Visible = true;
					PeMinimumSize.Visible = true;
					PeOrientation.Visible = false;
					PePreferredSize.Visible = true;
					PeSpacing.Visible = false;
					PeText.Visible = true;
					PeValue.Visible = false;
					PeVisible.Visible = true;
					break;
				case UIType.Checkbox:
					PeAlignChildren.Visible = false;
					PeAlignment.Visible = true;
					PeCharacters.Visible = false;
					PeEnabled.Visible = true;
					PeIcon.Visible = false;
					PeImage.Visible = false;
					PeJustify.Visible = true;
					PeMargin.Visible = false;
					PeMaximumSize.Visible = true;
					PeMinimumSize.Visible = true;
					PeOrientation.Visible = false;
					PePreferredSize.Visible = true;
					PeSpacing.Visible = false;
					PeText.Visible = true;
					PeValue.Visible = true;
					PeVisible.Visible = true;

					PeValue.IsBool = true;

					break;
				case UIType.Image:
					PeAlignChildren.Visible = false;
					PeAlignment.Visible = true;
					PeCharacters.Visible = false;
					PeEnabled.Visible = true;
					PeIcon.Visible = true;
					PeImage.Visible = true;
					PeJustify.Visible = false;
					PeMargin.Visible = false;
					PeMaximumSize.Visible = true;
					PeMinimumSize.Visible = true;
					PeOrientation.Visible = false;
					PePreferredSize.Visible = true;
					PeSpacing.Visible = false;
					PeText.Visible = false;
					PeValue.Visible = false;
					PeVisible.Visible = true;
					break;
				case UIType.IconButton:
					PeAlignChildren.Visible = false;
					PeAlignment.Visible = true;
					PeCharacters.Visible = false;
					PeEnabled.Visible = true;
					PeIcon.Visible = true;
					PeImage.Visible = true;
					PeJustify.Visible = false;
					PeMargin.Visible = false;
					PeMaximumSize.Visible = true;
					PeMinimumSize.Visible = true;
					PeOrientation.Visible = false;
					PePreferredSize.Visible = true;
					PeSpacing.Visible = false;
					PeText.Visible = false;
					PeValue.Visible = true;
					PeVisible.Visible = true;
					break;
			}
			ChkLoc();
		}

		public void ChkLoc()
		{
			int start = this.Controls.IndexOf(PeAlignChildren);
			int end = this.Controls.Count -1;

			int x = 0;
			int y = 30;
			int cnt = 0;
			for ( int i=start; i<=end;i++)
			{
				if (this.Controls[i].Visible)
				{
					this.Controls[i].Location = new Point(x, y);
					cnt++;
					y += 30;
				}

			}
		}
	}
}
