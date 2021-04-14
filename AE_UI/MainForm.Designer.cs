
namespace AE_UI
{
	partial class MainForm
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

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.jsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnDel = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUP = new System.Windows.Forms.Button();
			this.uiAddBtn1 = new AE_UI.UIAddBtn();
			this.aeControl1 = new AE_Util_skelton.AEControl();
			this.uiPanelEdits1 = new AE_UI.UIPanelEdits();
			this.uiTree1 = new AE_UI.UITree();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(614, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.resToolStripMenuItem,
            this.jsxToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// resToolStripMenuItem
			// 
			this.resToolStripMenuItem.Name = "resToolStripMenuItem";
			this.resToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.resToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.resToolStripMenuItem.Text = "Resource Disp";
			this.resToolStripMenuItem.Click += new System.EventHandler(this.resToolStripMenuItem_Click);
			// 
			// jsxToolStripMenuItem
			// 
			this.jsxToolStripMenuItem.Name = "jsxToolStripMenuItem";
			this.jsxToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
			this.jsxToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.jsxToolStripMenuItem.Text = "Jsx Disp";
			this.jsxToolStripMenuItem.Click += new System.EventHandler(this.jsxToolStripMenuItem_Click);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// btnDel
			// 
			this.btnDel.Enabled = false;
			this.btnDel.Location = new System.Drawing.Point(219, 58);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(41, 23);
			this.btnDel.TabIndex = 5;
			this.btnDel.Text = "Del";
			this.btnDel.UseVisualStyleBackColor = true;
			// 
			// btnDown
			// 
			this.btnDown.Enabled = false;
			this.btnDown.Location = new System.Drawing.Point(60, 57);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(41, 23);
			this.btnDown.TabIndex = 10;
			this.btnDown.Text = "Down";
			this.btnDown.UseVisualStyleBackColor = true;
			// 
			// btnUP
			// 
			this.btnUP.Enabled = false;
			this.btnUP.Location = new System.Drawing.Point(13, 57);
			this.btnUP.Name = "btnUP";
			this.btnUP.Size = new System.Drawing.Size(41, 23);
			this.btnUP.TabIndex = 9;
			this.btnUP.Text = "Up";
			this.btnUP.UseVisualStyleBackColor = true;
			// 
			// uiAddBtn1
			// 
			this.uiAddBtn1.Location = new System.Drawing.Point(12, 26);
			this.uiAddBtn1.MinimumSize = new System.Drawing.Size(250, 25);
			this.uiAddBtn1.Name = "uiAddBtn1";
			this.uiAddBtn1.Size = new System.Drawing.Size(250, 25);
			this.uiAddBtn1.TabIndex = 13;
			this.uiAddBtn1.Text = "uiAddBtn1";
			// 
			// aeControl1
			// 
			this.aeControl1.InstalledAFXIndex = -1;
			this.aeControl1.InstalledAFXStr = "";
			this.aeControl1.Location = new System.Drawing.Point(273, 27);
			this.aeControl1.Name = "aeControl1";
			this.aeControl1.ScriptCode = null;
			this.aeControl1.Size = new System.Drawing.Size(330, 35);
			this.aeControl1.TabIndex = 12;
			this.aeControl1.Text = "aeControl1";
			// 
			// uiPanelEdits1
			// 
			this.uiPanelEdits1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.uiPanelEdits1.Location = new System.Drawing.Point(266, 87);
			this.uiPanelEdits1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.uiPanelEdits1.Name = "uiPanelEdits1";
			this.uiPanelEdits1.Size = new System.Drawing.Size(337, 397);
			this.uiPanelEdits1.TabIndex = 2;
			// 
			// uiTree1
			// 
			this.uiTree1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.uiTree1.Debug = null;
			this.uiTree1.DelBtn = this.btnDel;
			this.uiTree1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.uiTree1.FullRowSelect = true;
			this.uiTree1.HideSelection = false;
			this.uiTree1.Location = new System.Drawing.Point(12, 87);
			this.uiTree1.MoveDownBtn = this.btnDown;
			this.uiTree1.MoveUpBtn = this.btnUP;
			this.uiTree1.Name = "uiTree1";
			this.uiTree1.PanelEdit = this.uiPanelEdits1;
			this.uiTree1.Size = new System.Drawing.Size(248, 397);
			this.uiTree1.TabIndex = 1;
			this.uiTree1.UIAddBtn = this.uiAddBtn1;
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(614, 496);
			this.Controls.Add(this.uiAddBtn1);
			this.Controls.Add(this.aeControl1);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUP);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.uiPanelEdits1);
			this.Controls.Add(this.uiTree1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(630, 4000);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(630, 530);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "AE_UI";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private UITree uiTree1;
		private UIPanelEdits uiPanelEdits1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnUP;
		private AE_Util_skelton.AEControl aeControl1;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private UIAddBtn uiAddBtn1;
		private System.Windows.Forms.ToolStripMenuItem resToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem jsxToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
	}
}

