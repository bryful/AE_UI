
namespace AE_UI
{
	partial class UIPanelEdits
	{
		/// <summary> 
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.lb = new System.Windows.Forms.Label();
			this.TbUIName = new AE_UI.UIEditBaseText();
			this.CmbUIType = new AE_UI.UITypeCmb();
			this.PeAlignChildren = new AE_UI.UIEditAlg();
			this.PeAlignment = new AE_UI.UIEditAlg();
			this.PeCharacters = new AE_UI.UIEditValue();
			this.PeEnabled = new AE_UI.UIEditValue();
			this.PeIcon = new AE_UI.UIEditText();
			this.PeImage = new AE_UI.UIEditText();
			this.PeIndent = new AE_UI.UIEditValue();
			this.PeJustify = new AE_UI.UIEditJustify();
			this.PeMargin = new AE_UI.UIEditMargin();
			this.PeMaximumSize = new AE_UI.UIEditSize();
			this.PeMinimumSize = new AE_UI.UIEditSize();
			this.PeOrientation = new AE_UI.UIEditOri();
			this.PePreferredSize = new AE_UI.UIEditSize();
			this.PeSpacing = new AE_UI.UIEditMargin();
			this.PeText = new AE_UI.UIEditText();
			this.PeValue = new AE_UI.UIEditValue();
			this.PeVisible = new AE_UI.UIEditValue();
			this.SuspendLayout();
			// 
			// lb
			// 
			this.lb.AutoSize = true;
			this.lb.Location = new System.Drawing.Point(148, 5);
			this.lb.Name = "lb";
			this.lb.Size = new System.Drawing.Size(29, 12);
			this.lb.TabIndex = 42;
			this.lb.Text = "種類";
			// 
			// TbUIName
			// 
			this.TbUIName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TbUIName.IsQValue = false;
			this.TbUIName.Location = new System.Drawing.Point(0, 0);
			this.TbUIName.Name = "TbUIName";
			this.TbUIName.Size = new System.Drawing.Size(140, 23);
			this.TbUIName.TabIndex = 65;
			this.TbUIName.Value = "";
			// 
			// CmbUIType
			// 
			this.CmbUIType.DropDownHeight = 400;
			this.CmbUIType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbUIType.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.CmbUIType.FormattingEnabled = true;
			this.CmbUIType.IntegralHeight = false;
			this.CmbUIType.Items.AddRange(new object[] {
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
            "TreeView"});
			this.CmbUIType.Location = new System.Drawing.Point(184, 0);
			this.CmbUIType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.CmbUIType.MaximumSize = new System.Drawing.Size(110, 0);
			this.CmbUIType.MinimumSize = new System.Drawing.Size(110, 0);
			this.CmbUIType.Name = "CmbUIType";
			this.CmbUIType.Size = new System.Drawing.Size(110, 24);
			this.CmbUIType.TabIndex = 27;
			this.CmbUIType.UIType = AE_UI.UIType.Group;
			this.CmbUIType.Value = "Group";
			// 
			// PeAlignChildren
			// 
			this.PeAlignChildren.Caption = "alignChildren";
			this.PeAlignChildren.CaptionWidth = 95;
			this.PeAlignChildren.IsUsed = false;
			this.PeAlignChildren.Location = new System.Drawing.Point(0, 30);
			this.PeAlignChildren.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PeAlignChildren.Name = "PeAlignChildren";
			this.PeAlignChildren.Size = new System.Drawing.Size(303, 24);
			this.PeAlignChildren.TabIndex = 56;
			this.PeAlignChildren.Text = "uiEditAlg2";
			this.PeAlignChildren.Value = "";
			// 
			// PeAlignment
			// 
			this.PeAlignment.Caption = "alignment";
			this.PeAlignment.CaptionWidth = 95;
			this.PeAlignment.IsUsed = false;
			this.PeAlignment.Location = new System.Drawing.Point(0, 60);
			this.PeAlignment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PeAlignment.Name = "PeAlignment";
			this.PeAlignment.Size = new System.Drawing.Size(303, 24);
			this.PeAlignment.TabIndex = 55;
			this.PeAlignment.Text = "uiEditAlg1";
			this.PeAlignment.Value = "";
			// 
			// PeCharacters
			// 
			this.PeCharacters.Caption = "characters";
			this.PeCharacters.CaptionWidth = 95;
			this.PeCharacters.IsBool = false;
			this.PeCharacters.IsUsed = false;
			this.PeCharacters.Location = new System.Drawing.Point(0, 87);
			this.PeCharacters.Name = "PeCharacters";
			this.PeCharacters.Size = new System.Drawing.Size(221, 23);
			this.PeCharacters.TabIndex = 63;
			this.PeCharacters.Text = "PeCharacters";
			this.PeCharacters.Value = "";
			// 
			// PeEnabled
			// 
			this.PeEnabled.Caption = "enabled";
			this.PeEnabled.CaptionWidth = 95;
			this.PeEnabled.IsBool = true;
			this.PeEnabled.IsUsed = false;
			this.PeEnabled.Location = new System.Drawing.Point(0, 113);
			this.PeEnabled.Name = "PeEnabled";
			this.PeEnabled.Size = new System.Drawing.Size(211, 23);
			this.PeEnabled.TabIndex = 66;
			this.PeEnabled.Text = "uiEditValue1";
			this.PeEnabled.Value = "";
			// 
			// PeIcon
			// 
			this.PeIcon.Caption = "icon";
			this.PeIcon.CaptionWidth = 95;
			this.PeIcon.IsUsed = false;
			this.PeIcon.Location = new System.Drawing.Point(0, 168);
			this.PeIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PeIcon.Name = "PeIcon";
			this.PeIcon.Size = new System.Drawing.Size(320, 23);
			this.PeIcon.TabIndex = 70;
			this.PeIcon.Text = "uiEditText1";
			this.PeIcon.Value = "";
			// 
			// PeImage
			// 
			this.PeImage.Caption = "image";
			this.PeImage.CaptionWidth = 95;
			this.PeImage.IsUsed = false;
			this.PeImage.Location = new System.Drawing.Point(0, 141);
			this.PeImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PeImage.Name = "PeImage";
			this.PeImage.Size = new System.Drawing.Size(320, 23);
			this.PeImage.TabIndex = 51;
			this.PeImage.Text = "uiEditText1";
			this.PeImage.Value = "";
			// 
			// PeIndent
			// 
			this.PeIndent.Caption = "indent";
			this.PeIndent.CaptionWidth = 95;
			this.PeIndent.IsBool = false;
			this.PeIndent.IsUsed = false;
			this.PeIndent.Location = new System.Drawing.Point(0, 193);
			this.PeIndent.Name = "PeIndent";
			this.PeIndent.Size = new System.Drawing.Size(221, 23);
			this.PeIndent.TabIndex = 64;
			this.PeIndent.Text = "uiEditValue1";
			this.PeIndent.Value = "";
			// 
			// PeJustify
			// 
			this.PeJustify.Caption = "justify";
			this.PeJustify.CaptionWidth = 95;
			this.PeJustify.IsUsed = false;
			this.PeJustify.Location = new System.Drawing.Point(0, 221);
			this.PeJustify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PeJustify.Name = "PeJustify";
			this.PeJustify.Size = new System.Drawing.Size(211, 24);
			this.PeJustify.TabIndex = 49;
			this.PeJustify.Text = "uiEditJustify1";
			this.PeJustify.Value = "";
			// 
			// PeMargin
			// 
			this.PeMargin.Caption = "margin";
			this.PeMargin.CaptionWidth = 95;
			this.PeMargin.IsUsed = false;
			this.PeMargin.Location = new System.Drawing.Point(-1, 248);
			this.PeMargin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PeMargin.Name = "PeMargin";
			this.PeMargin.Size = new System.Drawing.Size(320, 23);
			this.PeMargin.TabIndex = 57;
			this.PeMargin.Text = "uiEditMargin1";
			this.PeMargin.Value = "";
			// 
			// PeMaximumSize
			// 
			this.PeMaximumSize.Caption = "maximumSize";
			this.PeMaximumSize.CaptionWidth = 95;
			this.PeMaximumSize.IsUsed = false;
			this.PeMaximumSize.Location = new System.Drawing.Point(-1, 275);
			this.PeMaximumSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PeMaximumSize.Name = "PeMaximumSize";
			this.PeMaximumSize.Size = new System.Drawing.Size(320, 23);
			this.PeMaximumSize.TabIndex = 68;
			this.PeMaximumSize.Text = "uiEditSize1";
			this.PeMaximumSize.Value = "";
			// 
			// PeMinimumSize
			// 
			this.PeMinimumSize.Caption = "minimumSize";
			this.PeMinimumSize.CaptionWidth = 95;
			this.PeMinimumSize.IsUsed = false;
			this.PeMinimumSize.Location = new System.Drawing.Point(0, 302);
			this.PeMinimumSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PeMinimumSize.Name = "PeMinimumSize";
			this.PeMinimumSize.Size = new System.Drawing.Size(320, 23);
			this.PeMinimumSize.TabIndex = 69;
			this.PeMinimumSize.Text = "uiEditSize1";
			this.PeMinimumSize.Value = "";
			// 
			// PeOrientation
			// 
			this.PeOrientation.Caption = "orientation";
			this.PeOrientation.CaptionWidth = 95;
			this.PeOrientation.IsUsed = false;
			this.PeOrientation.Location = new System.Drawing.Point(-1, 329);
			this.PeOrientation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PeOrientation.Name = "PeOrientation";
			this.PeOrientation.Size = new System.Drawing.Size(320, 24);
			this.PeOrientation.TabIndex = 52;
			this.PeOrientation.Text = "uiEditOri1";
			this.PeOrientation.Value = "";
			// 
			// PePreferredSize
			// 
			this.PePreferredSize.Caption = "preferredSize";
			this.PePreferredSize.CaptionWidth = 95;
			this.PePreferredSize.IsUsed = false;
			this.PePreferredSize.Location = new System.Drawing.Point(-1, 356);
			this.PePreferredSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PePreferredSize.Name = "PePreferredSize";
			this.PePreferredSize.Size = new System.Drawing.Size(320, 23);
			this.PePreferredSize.TabIndex = 53;
			this.PePreferredSize.Text = "uiEditSize1";
			this.PePreferredSize.Value = "";
			// 
			// PeSpacing
			// 
			this.PeSpacing.Caption = "spacing";
			this.PeSpacing.CaptionWidth = 95;
			this.PeSpacing.IsUsed = false;
			this.PeSpacing.Location = new System.Drawing.Point(0, 383);
			this.PeSpacing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PeSpacing.Name = "PeSpacing";
			this.PeSpacing.Size = new System.Drawing.Size(320, 23);
			this.PeSpacing.TabIndex = 62;
			this.PeSpacing.Text = "uiEditMargin1";
			this.PeSpacing.Value = "";
			// 
			// PeText
			// 
			this.PeText.Caption = "text";
			this.PeText.CaptionWidth = 95;
			this.PeText.IsUsed = false;
			this.PeText.Location = new System.Drawing.Point(-1, 411);
			this.PeText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.PeText.Name = "PeText";
			this.PeText.Size = new System.Drawing.Size(303, 23);
			this.PeText.TabIndex = 48;
			this.PeText.Text = "uiEditText1";
			this.PeText.Value = "";
			// 
			// PeValue
			// 
			this.PeValue.Caption = "value";
			this.PeValue.CaptionWidth = 95;
			this.PeValue.IsBool = true;
			this.PeValue.IsUsed = false;
			this.PeValue.Location = new System.Drawing.Point(-1, 439);
			this.PeValue.Name = "PeValue";
			this.PeValue.Size = new System.Drawing.Size(221, 23);
			this.PeValue.TabIndex = 60;
			this.PeValue.Text = "uiEditValue1";
			this.PeValue.Value = "";
			// 
			// PeVisible
			// 
			this.PeVisible.Caption = "visible";
			this.PeVisible.CaptionWidth = 95;
			this.PeVisible.IsBool = true;
			this.PeVisible.IsUsed = false;
			this.PeVisible.Location = new System.Drawing.Point(0, 468);
			this.PeVisible.Name = "PeVisible";
			this.PeVisible.Size = new System.Drawing.Size(221, 23);
			this.PeVisible.TabIndex = 67;
			this.PeVisible.Text = "uiEditValue1";
			this.PeVisible.Value = "";
			// 
			// UIPanelEdits
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.TbUIName);
			this.Controls.Add(this.lb);
			this.Controls.Add(this.CmbUIType);
			this.Controls.Add(this.PeAlignChildren);
			this.Controls.Add(this.PeAlignment);
			this.Controls.Add(this.PeCharacters);
			this.Controls.Add(this.PeEnabled);
			this.Controls.Add(this.PeIcon);
			this.Controls.Add(this.PeImage);
			this.Controls.Add(this.PeIndent);
			this.Controls.Add(this.PeJustify);
			this.Controls.Add(this.PeMargin);
			this.Controls.Add(this.PeMaximumSize);
			this.Controls.Add(this.PeMinimumSize);
			this.Controls.Add(this.PeOrientation);
			this.Controls.Add(this.PePreferredSize);
			this.Controls.Add(this.PeSpacing);
			this.Controls.Add(this.PeText);
			this.Controls.Add(this.PeValue);
			this.Controls.Add(this.PeVisible);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "UIPanelEdits";
			this.Size = new System.Drawing.Size(328, 512);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private UITypeCmb CmbUIType;
		private System.Windows.Forms.Label lb;
		private UIEditBaseText TbUIName;

		private UIEditAlg PeAlignChildren;
		private UIEditAlg PeAlignment;
		private UIEditValue PeCharacters;
		private UIEditText PeImage;
		private UIEditValue PeIndent;
		private UIEditJustify PeJustify;
		private UIEditMargin PeMargin;
		private UIEditOri PeOrientation;
		private UIEditSize PePreferredSize;
		private UIEditMargin PeSpacing;
		private UIEditText PeText;
		private UIEditValue PeValue;
		private UIEditValue PeEnabled;
		private UIEditValue PeVisible;
		private UIEditSize PeMaximumSize;
		private UIEditSize PeMinimumSize;
		private UIEditText PeIcon;
	}
}
