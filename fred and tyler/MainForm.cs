﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameSystemServices;

namespace fred_and_tyler
{
    public partial class MainForm : Form
    {
        bool fullScreen = false;  // true: program runs fullscreen || false: program runs in window

        public MainForm()
        {
            InitializeComponent();

            Cursor.Hide();

            // open the main menu for the game
            MenuScreen ms = new MenuScreen();
            this.Controls.Add(ms);

            #region open in full screen or not
            if (fullScreen)
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;

                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
                // centre the new screen in the middle of the form
                ms.Location = new Point((screenWidth - ms.Width) / 2, (screenHeight - ms.Height) / 2);
            }
            else
            {
                // centre the new screen in the middle of the form
                ms.Location = new Point((this.Width - ms.Width) / 2, (this.Height - ms.Height) / 2);
            }
            #endregion
        }

        /// <summary>
        /// Will remove the current UserControl on the screen and replace it with
        /// a new one
        /// </summary>
        /// <param name="current">The UserControl to be closed</param>
        /// <param name="next">The name of the UserControl to be opened</param>
        public static void ChangeScreen(UserControl current, string next)
        {
            //f is set to the form that the current control is on
            Form f = current.FindForm();
            f.Controls.Remove(current);
            UserControl ns = null;

            ///If any screens, (UserControls), are added to the program they need to
            ///be added within this switch block as well.
            switch (next)
            {
                case "MenuScreen":
                    ns = new MenuScreen();
                    break;
                case "GameScreen":
                    ns = new GameScreen();
                    break;
                case "ScoreScreen":
                    ns = new ScoreScreen();
                    break;
            }

            //centres the control on the screen
            ns.Location = new Point((f.Width - ns.Width) / 2, (f.Height / 2 - ns.Height / 2));

            f.Controls.Add(ns);
            ns.Focus();
        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Font impact = new Font("Impact", 20);
            SolidBrush white = new SolidBrush(Color.White);

            e.Graphics.DrawString("BETA", impact, white, (this.Width / 2) - 34, 30);
        }
        SoundPlayer backSound = new SoundPlayer(Properties.Resources.tetrisBackground);

        private void MainForm_Load(object sender, EventArgs e)
        {
            backSound.Play();
        }

        private void backSoundTimer_Tick(object sender, EventArgs e)
        {
            backSound.Play();
        }
    }
}