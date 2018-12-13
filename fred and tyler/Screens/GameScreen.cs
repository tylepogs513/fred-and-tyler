﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GameSystemServices;

namespace fred_and_tyler
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;

        //TODO create your global game variables here
        int heroX, heroY, heroSize, heroSpeed, gravitySpeed;
        SolidBrush heroBrush = new SolidBrush(Color.Red);

        public GameScreen()
        {
            InitializeComponent();
            InitializeGameValues();
        }

        public void InitializeGameValues()
        {
            //TODO - setup all your initial game values here. Use this method
            // each time you restart your game to reset all values.
            heroX = 100;
            heroY = 100;
            heroSize = 10;
            heroSpeed = 1;
            gravitySpeed = 10;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // opens a pause screen is escape is pressed. Depending on what is pressed
            // on pause screen the program will either continue or exit to main menu
            if (e.KeyCode == Keys.Escape && gameTimer.Enabled)
            {
                gameTimer.Enabled = false;
                rightArrowDown = leftArrowDown = upArrowDown = downArrowDown = false;

                DialogResult result = PauseForm.Show();

                if (result == DialogResult.Cancel)
                {
                    gameTimer.Enabled = true;
                }
                else if (result == DialogResult.Abort)
                {
                    MainForm.ChangeScreen(this, "MenuScreen");
                }
            }

            //TODO - basic player 1 key down bools set below. Add remainging key down
            // required for player 1 or player 2 here.

            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                case Keys.M:
                    mDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO - basic player 1 key up bools set below. Add remainging key up
            // required for player 1 or player 2 here.

            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
            }
        }

        /// <summary>
        /// This is the Game Engine and repeats on each interval of the timer. For example
        /// if the interval is set to 16 then it will run each 16ms or approx. 50 times
        /// per second
        /// </summary>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            g.FillRectangle(blueBrush, 0, 299, 320, 10);
            if (heroY <= 260 && heroY >= 100)
            {
                g.FillRectangle(blueBrush, 0, 299, 320, 10);
                heroY = heroY + gravitySpeed;
                Thread.Sleep(1000);
            }
            //TODO move main character 
            if (leftArrowDown == true)
            {
                heroX = heroX - gravitySpeed;
                Thread.Sleep(100);

                if (heroY <= 260 && heroY >= 100)
                {
                    heroY = heroY + gravitySpeed;
                    Thread.Sleep(1000);
                }
            }
            if (rightArrowDown == true)
            {
                heroX = heroX + gravitySpeed;
                Thread.Sleep(100);

                if (heroY <= 260 && heroY >= 100)
                {
                    heroY = heroY + gravitySpeed;
                    Thread.Sleep(1000);
                }
            }
            if (downArrowDown == true)
            {
                heroY = heroY + gravitySpeed;
                Thread.Sleep(100);
                if (heroY <= 260 && heroY >= 100)
                {
                    heroY = heroY + gravitySpeed;
                    Thread.Sleep(1000);
                }
            }

            if (heroY >= 300)
            {
                heroY = 300;
                if (leftArrowDown == true)
                {
                    heroX = heroX - gravitySpeed;
                    Thread.Sleep(100);
                    if (heroX <= 0)
                    {
                        heroX = 0;
                    }
                }
                if (rightArrowDown == true)
                {
                    heroX = heroX + gravitySpeed;
                    Thread.Sleep(100);
                    if (heroX >= 290)
                    {
                        heroX = 290;
                    }
                }
            }

            //TODO collisions checks 


            //calls the GameScreen_Paint method to draw the screen.
            Refresh();
        }

        //Everything that is to be drawn on the screen should be done here
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw rectangle to screen
            e.Graphics.FillRectangle(heroBrush, heroX, heroY, heroSize, heroSize);
        }
    }
}
