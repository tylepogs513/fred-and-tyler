using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace fred_and_tyler
{
    public partial class GameScreen : UserControl
    {
        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, bDown, nDown, mDown, spaceDown;

        //player2 button control keys - DO NOT CHANGE
        Boolean aDown, sDown, dDown, wDown, cDown, vDown, xDown, zDown;

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }


        //TODO create your global game variables here
        int heroX, heroY, heroSize, heroSpeed, bottom, rotationCount;
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
            heroSize = 20;
            heroSpeed = 20;
            bottom = 280;
            rotationCount = 0;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // opens a pause screen is escape is pressed. Depending on what is pressed
            // on pause screen the program will either continue or exit to main menu
            if (e.KeyCode == Keys.Escape && gameTimer.Enabled)
            {
                gameTimer.Enabled = true;
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

        private void gravityTimer_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            g.FillRectangle(blueBrush, 0, 299, 320, 10);
            int counter = 0;

            if (counter <= 10 || heroY <= bottom)
            {
                counter++;
                heroY = heroY + heroSize;
            }

            if (heroY >= bottom)
            {
                heroY = bottom;
                g.FillRectangle(heroBrush, heroX, heroY, heroSize, heroSize);
                heroX = 100;
                heroY = 100;
            }
        }

        /// <summary>
        /// This is the Game Engine and repeats on each interval of the timer. For example
        /// if the interval is set to 16 then it will run each 16ms or approx. 50 times
        /// per second
        /// </summary>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Rectangle bottomBlock = new Rectangle(0, 300, 320, 1);
            Rectangle playBlock = new Rectangle(heroX, heroY, heroSize, heroSize);
            Graphics g = this.CreateGraphics();
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            g.FillRectangle(blueBrush, 0, 299, 320, 10);
            ////TODO move main character 

            if (leftArrowDown == true)
            {
                heroX = heroX - heroSpeed;
                Thread.Sleep(100);
                if (heroX <= 0)
                {
                    heroX = 0;
                }
            }
            if (rightArrowDown == true)
            {
                heroX = heroX + heroSpeed;
                Thread.Sleep(100);
                if (heroX >= 280)
                {
                    heroX = 280;
                }
            }
            if (downArrowDown == true)
            {
                heroY = bottom;
                Thread.Sleep(100);
            }
                        
            if (heroY >= bottom)
            {
                heroY = bottom;
                g.FillRectangle(heroBrush, heroX, heroY, heroSize, heroSize);
                heroX = 100;
                heroY = 100;
            }

            //TODO collisions checks 
            while (bottomBlock.IntersectsWith(playBlock))
            {
                if (leftArrowDown == true)
                {
                    heroSpeed = 0;
                }
                if (rightArrowDown == true)
                {
                    heroSpeed = 0;
                }
                heroX = 100;
                heroY = 100; 
            }
            //calls the GameScreen_Paint method to draw the screen.
            Refresh();
        }
        private void rotationTimer_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            if (upArrowDown == true)
            {
                if (rotationCount == 0)
                {
                    g.Clear(Color.LightSteelBlue);
                    g.FillRectangle(heroBrush, heroX, heroY, heroSize, heroSize);
                    g.FillRectangle(heroBrush, heroX + 20, heroY, heroSize, heroSize);
                    g.FillRectangle(heroBrush, heroX - 20, heroY, heroSize, heroSize);
                    g.FillRectangle(heroBrush, heroX, heroY - 20, heroSize, heroSize);
                    Thread.Sleep(500);
                    rotationCount++;
                }

                else if (rotationCount == 1)
                {
                    g.Clear(Color.LightSteelBlue);
                    g.FillRectangle(heroBrush, heroX, heroY, heroSize, heroSize);
                    g.FillRectangle(heroBrush, heroX + 20, heroY, heroSize, heroSize);
                    g.FillRectangle(heroBrush, heroX, heroY + 20, heroSize, heroSize);
                    g.FillRectangle(heroBrush, heroX, heroY - 20, heroSize, heroSize);
                    Thread.Sleep(500);
                    rotationCount++;
                }

                else if (rotationCount == 2)
                {
                    g.Clear(Color.LightSteelBlue);
                    g.FillRectangle(heroBrush, heroX, heroY, heroSize, heroSize);
                    g.FillRectangle(heroBrush, heroX + 20, heroY, heroSize, heroSize);
                    g.FillRectangle(heroBrush, heroX, heroY + 20, heroSize, heroSize);
                    g.FillRectangle(heroBrush, heroX - 20, heroY, heroSize, heroSize);
                    Thread.Sleep(500);
                    rotationCount++;
                }

                else if (rotationCount == 3)
                {
                    g.Clear(Color.LightSteelBlue);
                    g.FillRectangle(heroBrush, heroX, heroY, heroSize, heroSize);
                    g.FillRectangle(heroBrush, heroX - 20, heroY, heroSize, heroSize);
                    g.FillRectangle(heroBrush, heroX, heroY + 20, heroSize, heroSize);
                    g.FillRectangle(heroBrush, heroX, heroY - 20, heroSize, heroSize);
                    Thread.Sleep(500);
                    rotationCount = 0;
                }
            }
        }

        //Everything that is to be drawn on the screen should be done here
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw rectangle to screen
            e.Graphics.FillRectangle(heroBrush, heroX, heroY, heroSize, heroSize);
        }
    }
}
