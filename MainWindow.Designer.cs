namespace GifCapture
{
	partial class MainWindow
	{
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
			if (disposing && (components != null))
			{
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.toolContainer = new System.Windows.Forms.ToolStripContainer();
			this.progressTool = new System.Windows.Forms.ToolStrip();
			this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.recordButton = new System.Windows.Forms.ToolStripButton();
			this.pauseButton = new System.Windows.Forms.ToolStripButton();
			this.saveButton = new System.Windows.Forms.ToolStripButton();
			this.eraseButton = new System.Windows.Forms.ToolStripButton();
			this.sizeLabel = new System.Windows.Forms.ToolStripLabel();
			this.storageUse = new System.Windows.Forms.ToolStripLabel();
			this.noFocus = new System.Windows.Forms.ToolStripButton();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.ramLabel = new System.Windows.Forms.ToolStripLabel();
			this.toolContainer.ContentPanel.SuspendLayout();
			this.toolContainer.TopToolStripPanel.SuspendLayout();
			this.toolContainer.SuspendLayout();
			this.progressTool.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolContainer
			// 
			// 
			// toolContainer.ContentPanel
			// 
			this.toolContainer.ContentPanel.Controls.Add(this.progressTool);
			this.toolContainer.ContentPanel.Size = new System.Drawing.Size(640, 480);
			this.toolContainer.ContentPanel.Resize += new System.EventHandler(this.toolContainer_ContentPanel_Resize);
			this.toolContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolContainer.Location = new System.Drawing.Point(0, 0);
			this.toolContainer.Name = "toolContainer";
			this.toolContainer.Size = new System.Drawing.Size(640, 505);
			this.toolContainer.TabIndex = 2;
			this.toolContainer.Text = "toolStripContainer1";
			// 
			// toolContainer.TopToolStripPanel
			// 
			this.toolContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
			// 
			// progressTool
			// 
			this.progressTool.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progressTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
			this.progressTool.Location = new System.Drawing.Point(0, 455);
			this.progressTool.Name = "progressTool";
			this.progressTool.Size = new System.Drawing.Size(640, 25);
			this.progressTool.TabIndex = 0;
			this.progressTool.Text = "toolStrip1";
			this.progressTool.Visible = false;
			// 
			// progressBar
			// 
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(100, 22);
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// toolStrip
			// 
			this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordButton,
            this.pauseButton,
            this.saveButton,
            this.eraseButton,
            this.sizeLabel,
            this.ramLabel,
            this.storageUse,
            this.noFocus});
			this.toolStrip.Location = new System.Drawing.Point(3, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(425, 25);
			this.toolStrip.TabIndex = 0;
			// 
			// recordButton
			// 
			this.recordButton.AutoToolTip = false;
			this.recordButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.recordButton.Image = ((System.Drawing.Image)(resources.GetObject("recordButton.Image")));
			this.recordButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.recordButton.Name = "recordButton";
			this.recordButton.Size = new System.Drawing.Size(23, 22);
			this.recordButton.Text = "Record";
			this.recordButton.Click += new System.EventHandler(this.recordButton_Click);
			// 
			// pauseButton
			// 
			this.pauseButton.AutoToolTip = false;
			this.pauseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.pauseButton.Enabled = false;
			this.pauseButton.Image = ((System.Drawing.Image)(resources.GetObject("pauseButton.Image")));
			this.pauseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pauseButton.Name = "pauseButton";
			this.pauseButton.Size = new System.Drawing.Size(23, 22);
			this.pauseButton.Text = "Pause";
			this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
			// 
			// saveButton
			// 
			this.saveButton.AutoToolTip = false;
			this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
			this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(23, 22);
			this.saveButton.Text = "Save";
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// eraseButton
			// 
			this.eraseButton.AutoToolTip = false;
			this.eraseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.eraseButton.Image = ((System.Drawing.Image)(resources.GetObject("eraseButton.Image")));
			this.eraseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.eraseButton.Name = "eraseButton";
			this.eraseButton.Size = new System.Drawing.Size(23, 22);
			this.eraseButton.Text = "Erase";
			this.eraseButton.Click += new System.EventHandler(this.eraseButton_Click);
			// 
			// sizeLabel
			// 
			this.sizeLabel.Name = "sizeLabel";
			this.sizeLabel.Size = new System.Drawing.Size(48, 22);
			this.sizeLabel.Text = "800x600";
			// 
			// storageUse
			// 
			this.storageUse.Name = "storageUse";
			this.storageUse.Size = new System.Drawing.Size(54, 22);
			this.storageUse.Text = "0 Frames";
			// 
			// noFocus
			// 
			this.noFocus.Checked = true;
			this.noFocus.CheckOnClick = true;
			this.noFocus.CheckState = System.Windows.Forms.CheckState.Checked;
			this.noFocus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.noFocus.Image = ((System.Drawing.Image)(resources.GetObject("noFocus.Image")));
			this.noFocus.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.noFocus.Name = "noFocus";
			this.noFocus.Size = new System.Drawing.Size(153, 22);
			this.noFocus.Text = "Don\'t record while in focus";
			// 
			// timer
			// 
			this.timer.Interval = 10;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "gif";
			this.saveFileDialog.Filter = "GIF|*.gif";
			// 
			// ramLabel
			// 
			this.ramLabel.Name = "ramLabel";
			this.ramLabel.Size = new System.Drawing.Size(66, 22);
			this.ramLabel.Text = "0 MiB RAM";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Magenta;
			this.ClientSize = new System.Drawing.Size(640, 505);
			this.Controls.Add(this.toolContainer);
			this.Name = "MainWindow";
			this.Text = "GifCapture.exe";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.Color.Magenta;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
			this.Load += new System.EventHandler(this.MainWindow_Load);
			this.toolContainer.ContentPanel.ResumeLayout(false);
			this.toolContainer.ContentPanel.PerformLayout();
			this.toolContainer.TopToolStripPanel.ResumeLayout(false);
			this.toolContainer.TopToolStripPanel.PerformLayout();
			this.toolContainer.ResumeLayout(false);
			this.toolContainer.PerformLayout();
			this.progressTool.ResumeLayout(false);
			this.progressTool.PerformLayout();
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStripContainer toolContainer;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton recordButton;
		private System.Windows.Forms.ToolStripButton pauseButton;
		private System.Windows.Forms.ToolStripButton saveButton;
		private System.Windows.Forms.ToolStripLabel sizeLabel;
		private System.Windows.Forms.ToolStripLabel storageUse;
		private System.Windows.Forms.ToolStripButton eraseButton;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStrip progressTool;
		private System.Windows.Forms.ToolStripProgressBar progressBar;
		private System.Windows.Forms.ToolStripButton noFocus;
		private System.Windows.Forms.ToolStripLabel ramLabel;


	}
}

