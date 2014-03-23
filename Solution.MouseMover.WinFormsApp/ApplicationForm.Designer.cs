namespace Solution.MouseMover.WinFormsApp
{
  partial class ApplicationForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationForm));
        this.tmrMouseMove = new System.Windows.Forms.Timer(this.components);
        this.systemTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
        this.mnuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.mnuTrayMouseMove = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuTrayAnimate = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuTraySeparator01 = new System.Windows.Forms.ToolStripSeparator();
        this.mnuTrayExit = new System.Windows.Forms.ToolStripMenuItem();
        this.mnu = new System.Windows.Forms.MenuStrip();
        this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuFileMinimize = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuFileSeparator01 = new System.Windows.Forms.ToolStripSeparator();
        this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
        this.cbxMouseMove = new System.Windows.Forms.CheckBox();
        this.tmrMouseIcon = new System.Windows.Forms.Timer(this.components);
        this.cbxAnimate = new System.Windows.Forms.CheckBox();
        this.chkWindowsStartup = new System.Windows.Forms.CheckBox();
        this.mnuTray.SuspendLayout();
        this.mnu.SuspendLayout();
        this.SuspendLayout();
        // 
        // tmrMouseMove
        // 
        this.tmrMouseMove.Interval = 757;
        this.tmrMouseMove.Tick += new System.EventHandler(this.tmrMouseMove_Tick);
        // 
        // systemTrayIcon
        // 
        this.systemTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
        this.systemTrayIcon.BalloonTipText = "systemTrayIcon";
        this.systemTrayIcon.BalloonTipTitle = "systemTrayIcon";
        this.systemTrayIcon.ContextMenuStrip = this.mnuTray;
        this.systemTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("systemTrayIcon.Icon")));
        this.systemTrayIcon.Text = "MouseMover";
        this.systemTrayIcon.Visible = true;
        this.systemTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.systemTrayIcon_MouseDoubleClick);
        // 
        // mnuTray
        // 
        this.mnuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTrayMouseMove,
            this.mnuTrayAnimate,
            this.mnuTraySeparator01,
            this.mnuTrayExit});
        this.mnuTray.Name = "systemTrayMenu";
        this.mnuTray.Size = new System.Drawing.Size(213, 76);
        // 
        // mnuTrayMouseMove
        // 
        this.mnuTrayMouseMove.Name = "mnuTrayMouseMove";
        this.mnuTrayMouseMove.Size = new System.Drawing.Size(212, 22);
        this.mnuTrayMouseMove.Text = "&Move Mouse Cursor";
        // 
        // mnuTrayAnimate
        // 
        this.mnuTrayAnimate.Checked = true;
        this.mnuTrayAnimate.CheckState = System.Windows.Forms.CheckState.Checked;
        this.mnuTrayAnimate.Name = "mnuTrayAnimate";
        this.mnuTrayAnimate.Size = new System.Drawing.Size(212, 22);
        this.mnuTrayAnimate.Text = "&Animate System Tray Icon";
        // 
        // mnuTraySeparator01
        // 
        this.mnuTraySeparator01.Name = "mnuTraySeparator01";
        this.mnuTraySeparator01.Size = new System.Drawing.Size(209, 6);
        // 
        // mnuTrayExit
        // 
        this.mnuTrayExit.Name = "mnuTrayExit";
        this.mnuTrayExit.Size = new System.Drawing.Size(212, 22);
        this.mnuTrayExit.Text = "&Exit";
        this.mnuTrayExit.Click += new System.EventHandler(this.mnuExit_Click);
        // 
        // mnu
        // 
        this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
        this.mnu.Location = new System.Drawing.Point(0, 0);
        this.mnu.Name = "mnu";
        this.mnu.Size = new System.Drawing.Size(304, 24);
        this.mnu.TabIndex = 0;
        this.mnu.Text = "menuStrip1";
        // 
        // mnuFile
        // 
        this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileMinimize,
            this.mnuFileSeparator01,
            this.mnuFileExit});
        this.mnuFile.Name = "mnuFile";
        this.mnuFile.Size = new System.Drawing.Size(37, 20);
        this.mnuFile.Text = "&File";
        // 
        // mnuFileMinimize
        // 
        this.mnuFileMinimize.Name = "mnuFileMinimize";
        this.mnuFileMinimize.Size = new System.Drawing.Size(204, 22);
        this.mnuFileMinimize.Text = "Minimize to System Tray";
        this.mnuFileMinimize.Click += new System.EventHandler(this.mnuFileMinimize_Click);
        // 
        // mnuFileSeparator01
        // 
        this.mnuFileSeparator01.Name = "mnuFileSeparator01";
        this.mnuFileSeparator01.Size = new System.Drawing.Size(201, 6);
        // 
        // mnuFileExit
        // 
        this.mnuFileExit.Name = "mnuFileExit";
        this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
        this.mnuFileExit.Size = new System.Drawing.Size(204, 22);
        this.mnuFileExit.Text = "E&xit";
        this.mnuFileExit.Click += new System.EventHandler(this.mnuExit_Click);
        // 
        // mnuHelp
        // 
        this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
        this.mnuHelp.Name = "mnuHelp";
        this.mnuHelp.Size = new System.Drawing.Size(44, 20);
        this.mnuHelp.Text = "&Help";
        // 
        // mnuHelpAbout
        // 
        this.mnuHelpAbout.Name = "mnuHelpAbout";
        this.mnuHelpAbout.Size = new System.Drawing.Size(107, 22);
        this.mnuHelpAbout.Text = "&About";
        this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
        // 
        // cbxMouseMove
        // 
        this.cbxMouseMove.AutoSize = true;
        this.cbxMouseMove.Location = new System.Drawing.Point(13, 28);
        this.cbxMouseMove.Name = "cbxMouseMove";
        this.cbxMouseMove.Size = new System.Drawing.Size(121, 17);
        this.cbxMouseMove.TabIndex = 1;
        this.cbxMouseMove.Text = "Move Mouse Cursor";
        this.cbxMouseMove.UseVisualStyleBackColor = true;
        // 
        // tmrMouseIcon
        // 
        this.tmrMouseIcon.Interval = 223;
        this.tmrMouseIcon.Tick += new System.EventHandler(this.tmrMouseIcon_Tick);
        // 
        // cbxAnimate
        // 
        this.cbxAnimate.AutoSize = true;
        this.cbxAnimate.Checked = true;
        this.cbxAnimate.CheckState = System.Windows.Forms.CheckState.Checked;
        this.cbxAnimate.Location = new System.Drawing.Point(13, 51);
        this.cbxAnimate.Name = "cbxAnimate";
        this.cbxAnimate.Size = new System.Drawing.Size(149, 17);
        this.cbxAnimate.TabIndex = 2;
        this.cbxAnimate.Text = "Animate System Tray Icon";
        this.cbxAnimate.UseVisualStyleBackColor = true;
        // 
        // chkWindowsStartup
        // 
        this.chkWindowsStartup.AutoSize = true;
        this.chkWindowsStartup.Location = new System.Drawing.Point(13, 74);
        this.chkWindowsStartup.Name = "chkWindowsStartup";
        this.chkWindowsStartup.Size = new System.Drawing.Size(102, 17);
        this.chkWindowsStartup.TabIndex = 3;
        this.chkWindowsStartup.Text = "Load on Startup";
        this.chkWindowsStartup.UseVisualStyleBackColor = true;
        this.chkWindowsStartup.CheckedChanged += new System.EventHandler(this.chkWindowsStartup_CheckedChanged);
        // 
        // ApplicationForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(304, 115);
        this.Controls.Add(this.chkWindowsStartup);
        this.Controls.Add(this.cbxAnimate);
        this.Controls.Add(this.cbxMouseMove);
        this.Controls.Add(this.mnu);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MainMenuStrip = this.mnu;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ApplicationForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "MouseMover";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ApplicationForm_FormClosing);
        this.mnuTray.ResumeLayout(false);
        this.mnu.ResumeLayout(false);
        this.mnu.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NotifyIcon systemTrayIcon;
    private System.Windows.Forms.MenuStrip mnu;
    private System.Windows.Forms.ToolStripMenuItem mnuFile;
    private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
    private System.Windows.Forms.ContextMenuStrip mnuTray;
    private System.Windows.Forms.ToolStripMenuItem mnuTrayMouseMove;
    private System.Windows.Forms.ToolStripMenuItem mnuTrayExit;
    private System.Windows.Forms.CheckBox cbxMouseMove;
    private System.Windows.Forms.Timer tmrMouseMove;
    private System.Windows.Forms.Timer tmrMouseIcon;
    private System.Windows.Forms.CheckBox cbxAnimate;
    private System.Windows.Forms.ToolStripMenuItem mnuTrayAnimate;
    private System.Windows.Forms.ToolStripSeparator mnuTraySeparator01;
    private System.Windows.Forms.ToolStripMenuItem mnuFileMinimize;
    private System.Windows.Forms.ToolStripMenuItem mnuHelp;
    private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
    private System.Windows.Forms.ToolStripSeparator mnuFileSeparator01;
    private System.Windows.Forms.CheckBox chkWindowsStartup;


  }
}

