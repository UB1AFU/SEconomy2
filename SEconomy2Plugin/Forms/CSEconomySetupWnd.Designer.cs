namespace SEconomy2Plugin.Forms {
	partial class CSEconomySetupWnd {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cRankTreeSetupControl1 = new SEconomy2Plugin.Forms.CRankTreeSetupControl();
			this.cCurrencySetupControl1 = new SEconomy2Plugin.Forms.Controls.CCurrencySetupControl();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ItemSize = new System.Drawing.Size(88, 38);
			this.tabControl1.Location = new System.Drawing.Point(0, 24);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(771, 596);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.cCurrencySetupControl1);
			this.tabPage1.Location = new System.Drawing.Point(4, 42);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(763, 550);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Currencies";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.cRankTreeSetupControl1);
			this.tabPage2.Location = new System.Drawing.Point(4, 42);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(763, 550);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Rank Tree";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(771, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveConfigurationToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// saveConfigurationToolStripMenuItem
			// 
			this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
			this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.saveConfigurationToolStripMenuItem.Text = "Save Configuration";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// cRankTreeSetupControl1
			// 
			this.cRankTreeSetupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cRankTreeSetupControl1.Location = new System.Drawing.Point(3, 3);
			this.cRankTreeSetupControl1.Name = "cRankTreeSetupControl1";
			this.cRankTreeSetupControl1.Size = new System.Drawing.Size(757, 544);
			this.cRankTreeSetupControl1.TabIndex = 1;
			// 
			// cCurrencySetupControl1
			// 
			this.cCurrencySetupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cCurrencySetupControl1.Location = new System.Drawing.Point(3, 3);
			this.cCurrencySetupControl1.Name = "cCurrencySetupControl1";
			this.cCurrencySetupControl1.Size = new System.Drawing.Size(757, 544);
			this.cCurrencySetupControl1.TabIndex = 0;
			// 
			// CSEconomySetupWnd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(771, 620);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "CSEconomySetupWnd";
			this.Text = "CSEconomySetupWnd";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private CRankTreeSetupControl cRankTreeSetupControl1;
		private Controls.CCurrencySetupControl cCurrencySetupControl1;
	}
}