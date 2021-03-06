﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Win32;

namespace MouseMover.WindowsApp
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
            SystemEvents.SessionEnding += new SessionEndingEventHandler(SystemEvents_SessionEnding);
            this.chkWindowsStartup.Checked = this.IsRunOnWindowsStartupEnabled();
        }

        private void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            if (Environment.HasShutdownStarted)
            {
                //Tackle Shutdown
            }
            else
            {
                //Tackle log off
            }
            this.ApplicationExit();
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
            this.systemTrayIcon.ShowBalloonTip(5000, "MouseMover", "MouseMover is still running. Double-click the icon to show or hide MouseMover. Right-click the icon for additional options.", ToolTipIcon.Info);
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
            this.tmrMouseMove.Stop();
            this.tmrMouseIcon.Stop();
            try
            {
                this.systemTrayIcon.Dispose();
            }
            catch
            {
            }
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
            catch (Exception exception)
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

        private const string COPYRIGHT = " \u00A9 ";

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog(this);
        }

        private void chkWindowsStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (!SetRunOnWindowsStartup(this.chkWindowsStartup.Checked))
            {
                MessageBox.Show(this, "There was an error changing the Load on Startup option." );
            }
        }


        #region Run on Windows Startup

        /// <summary>
        /// Shortcut function.
        /// </summary>
        /// <returns></returns>
        private RegistryKey GetRunOnWindowsStartupRegistryKey()
        {
            return Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }

        /// <summary>
        /// Modify the Registry to set whether or not the application is set to run when Windows starts up.
        /// </summary>
        /// <param name="runOnStartup">Whether or not the application should run when Windows starts up.</param>
        /// <returns>FALSE if the application could not be set to run on startup. Probably due to Registry access issue.</returns>
        private bool SetRunOnWindowsStartup(bool runOnStartup)
        {
            try
            {
                if (runOnStartup)
                {
                    this.GetRunOnWindowsStartupRegistryKey().SetValue(Application.ProductName, Application.ExecutablePath);
                }
                else
                {
                    this.GetRunOnWindowsStartupRegistryKey().DeleteValue(Application.ProductName);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check the Registry to confirm whether or not the application is set to run when Windows starts up.
        /// </summary>
        /// <returns>TRUE if MouseMover will run when Windows starts up.</returns>
        private bool IsRunOnWindowsStartupEnabled()
        {
            try
            {
                object val = this.GetRunOnWindowsStartupRegistryKey().GetValue(Application.ProductName);
                return val != null && !string.IsNullOrEmpty(val.ToString());
            }
            catch
            {
                return false;
            }
        }

        #endregion


    }
}
