using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Solution.MouseMover.WinFormsApp
{
  public partial class ApplicationForm : Form
  {

    private bool _animationEnabled = true;
    private bool _applicationExit = false;
    private int _frameCounter = 1;
    private MouseMoverEngine _mouseMoverEngine;
    private EventHandler _mouseMoveEventHandler;
    private EventHandler _animationEventHandler;

    public ApplicationForm()
    {
      this._mouseMoverEngine = new MouseMoverEngine();
      InitializeComponent();
      this._animationEventHandler = new System.EventHandler(this.AnimationEventHandler);
      this._mouseMoveEventHandler = new System.EventHandler(this.MouseMoveEventHandler);
      this.cbxAnimate.CheckedChanged += this._animationEventHandler;
      this.mnuTrayAnimate.Click += this._animationEventHandler;
      this.cbxMouseMove.CheckedChanged += this._mouseMoveEventHandler;
      this.mnuTrayMouseMove.Click += this._mouseMoveEventHandler;
    }



    private void ApplicationForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!this._applicationExit)
      {
        this.Visible = false;
        e.Cancel = true;
        this.ShowBalloonTip();
      }
    }

    private void ShowBalloonTip()
    {
      this.systemTrayIcon.ShowBalloonTip(5000,"MouseMover","MouseMover is still running. Double-click the icon to show or hide MouseMover. Right-click the icon for additional options.",ToolTipIcon.Info);
    }



    private void systemTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (e.Button == System.Windows.Forms.MouseButtons.Left)
      {
        this.Visible = !this.Visible;
      }
    }



    private void mnuExit_Click(object sender, EventArgs e)
    {
      this.ApplicationExit();
    }

    private void ApplicationExit()
    {
      this._applicationExit = true;
      Application.Exit();
    }

    private void mnuFileMinimize_Click(object sender, EventArgs e)
    {
      this.Close();
    }



    private void AnimationEventHandler(object sender, EventArgs e)
    {
      this.cbxAnimate.CheckedChanged -= this._animationEventHandler;
      this.mnuTrayAnimate.Click -= this._animationEventHandler;

      this._animationEnabled = !this._animationEnabled;
      this.cbxAnimate.Checked = this._animationEnabled;
      this.mnuTrayAnimate.Checked = this._animationEnabled;

      this.cbxAnimate.CheckedChanged += this._animationEventHandler;
      this.mnuTrayAnimate.Click += this._animationEventHandler;
    }



    private void MouseMoveEventHandler(object sender, EventArgs e)
    {
      this.mnuTrayMouseMove.Click -= this._mouseMoveEventHandler;
      this.cbxMouseMove.CheckedChanged -= this._mouseMoveEventHandler;

      this.tmrMouseMove.Enabled = !this.tmrMouseMove.Enabled;
      this.tmrMouseIcon.Enabled = !this.tmrMouseIcon.Enabled;
      this.cbxMouseMove.Checked = this.tmrMouseMove.Enabled;
      this.mnuTrayMouseMove.Checked = this.tmrMouseMove.Enabled;
      this._frameCounter = 1;
      this.systemTrayIcon.Icon = Properties.Resources.MouseIcon05_01;

      this.mnuTrayMouseMove.Click += this._mouseMoveEventHandler;
      this.cbxMouseMove.CheckedChanged += this._mouseMoveEventHandler;
    }



    private void tmrMouseMove_Tick(object sender, EventArgs e)
    {
      try
      {
        this._mouseMoverEngine.Move();
      }
      catch(Exception exception)
      {
        // TODO: Logging
        MessageBox.Show(exception.ToString());
      }
    }

    private void tmrMouseIcon_Tick(object sender, EventArgs e)
    {
      #region ANIMATION
      if (this._animationEnabled)
      {
        switch (this._frameCounter)
        {
          case 1:
            this.systemTrayIcon.Icon = Properties.Resources.MouseIcon05_01;
            break;
          case 2:
            this.systemTrayIcon.Icon = Properties.Resources.MouseIcon05_02;
            break;
          case 3:
            this.systemTrayIcon.Icon = Properties.Resources.MouseIcon05_01;
            break;
          case 4:
            this.systemTrayIcon.Icon = Properties.Resources.MouseIcon05_03;
            break;
        }
        if (_frameCounter < 4)
        {
          _frameCounter++;
        }
        else
        {
          _frameCounter = 1;
        }
      }
      else
      {
        // Set icon in case someone switches the property in the middle of an animation 
        // sequence. There are more efficient ways to do this but this is a simple way.
        this.systemTrayIcon.Icon = Properties.Resources.MouseIcon05_01;
      }
      #endregion ANIMATION
    }



  }
}
