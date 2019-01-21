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
        int heroX, heroY, heroSize, heroSpeed, bottom, rotationCount, startX, startY;
        SolidBrush lBrush = new SolidBrush(Color.Red);
        SolidBrush jBrush = new SolidBrush(Color.Blue);
        SolidBrush sBrush = new SolidBrush(Color.Black);
        SolidBrush zBrush = new SolidBrush(Color.Red);
        SolidBrush oBrush = new SolidBrush(Color.Blue);
        SolidBrush tBrush = new SolidBrush(Color.Black);
        Pen outlinePen = new Pen(Color.White);
        Pen outlinePenWhite = new Pen(Color.White);
        Random randGen = new Random(); 
        int shape;
        
        public GameScreen()
        {
            InitializeComponent();
            InitializeGameValues();
        }

        public void InitializeGameValues()
        {
            //TODO - setup all your initial game values here. Use this method
            // each time you restart your game to reset all values.
            startX = 60;
            startY = 120;
            heroX = 100;
            heroY = 100;
            heroSize = 20;
            heroSpeed = 20;
            bottom = 280;
            rotationCount = 1;
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
            int counter = 0;

            if (counter <= 10 || heroY <= bottom)
            {
                counter++;
                heroY = heroY + heroSize;
            }

            if (heroY >= bottom)
            {
                shape = randGen.Next(1, 6);
                heroX = startX;
                heroY = startY;
            }

            Refresh();
        }

        /// <summary>
        /// This is the Game Engine and repeats on each interval of the timer. For example
        /// if the interval is set to 16 then it will run each 16ms or approx. 50 times
        /// per second
        /// </summary>
        public void gameTimer_Tick(object sender, EventArgs e)
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
                if (heroX <= 0)
                {
                    heroX = 0;
                }
            }
            if (rightArrowDown == true)
            {
                heroX = heroX + heroSpeed;
                if (heroX >= 280)
                {
                    heroX = 280;
                }
            }
            if (downArrowDown == true)
            {
                heroY = bottom;
            }
                        
            if (heroY >= bottom)
            {
                heroY = bottom;
                heroX = startX;
                heroY = startY;
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
                shape = randGen.Next(1, 6);
                rotationCount = 0;
            }
            //calls the GameScreen_Paint method to draw the screen.
            Refresh();
        }
        public void rotationTimer_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            if (upArrowDown == true)
            {
                if (rotationCount == 1)
                {
                    rotationCount++;
                }

                else if (rotationCount == 2)
                {
                    rotationCount++;
                }

                else if (rotationCount == 3)
                {
                    rotationCount++;
                }

                else if (rotationCount == 4)
                {
                    rotationCount = 1;
                }
            }
                Refresh();
        }

        //Everything that is to be drawn on the screen should be done here
        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            testLab.Text = shape + "";
            //draw rectangle to screen
            switch (shape)
            {
                case 0:
                    if (rotationCount == 1)//T
                    {
                        e.Graphics.FillRectangle(tBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(tBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(tBrush, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(tBrush, heroX, heroY - 20, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY - 20, heroSize, heroSize);
                    }

                    else if (rotationCount == 2)
                    {
                        e.Graphics.FillRectangle(tBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(tBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(tBrush, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(tBrush, heroX, heroY - 20, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY - 20, heroSize, heroSize);
                    }

                    else if (rotationCount == 3)
                    {
                        e.Graphics.FillRectangle(tBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(tBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(tBrush, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(tBrush, heroX - 20, heroY, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY, heroSize, heroSize);
                    }

                    else if (rotationCount == 4)
                    {
                        e.Graphics.FillRectangle(tBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(tBrush, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(tBrush, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(tBrush, heroX, heroY - 20, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY - 20, heroSize, heroSize);
                    }
                    break;
                case 1://Z
                    if (rotationCount == 1)
                    {
                        e.Graphics.FillRectangle(zBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(zBrush, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(zBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(zBrush, heroX + 20, heroY - 20, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX + 20, heroY - 20, heroSize, heroSize);

                    }
                    else if (rotationCount == 2)
                    {
                        e.Graphics.FillRectangle(zBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(zBrush, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(zBrush, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(zBrush, heroX - 20, heroY - 20, heroSize, heroSize);
                        
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY - 20, heroSize, heroSize);
                    }
                    else if (rotationCount == 3)
                    {
                        e.Graphics.FillRectangle(zBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(zBrush, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(zBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(zBrush, heroX + 20, heroY - 20, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX + 20, heroY - 20, heroSize, heroSize);
                    }
                    else if (rotationCount == 4)
                    {
                        e.Graphics.FillRectangle(zBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(zBrush, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(zBrush, heroX - 20, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(zBrush, heroX - 20, heroY, heroSize, heroSize);
                        
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY - 20, heroSize, heroSize);
                    }
                    break;
                case 2://S
                    if (rotationCount == 1) 
                    {
                        e.Graphics.FillRectangle(sBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(sBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(sBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(sBrush, heroX - 20, heroY - 20, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY - 20, heroSize, heroSize);
                    }
                    else if (rotationCount == 2)
                    {
                        e.Graphics.FillRectangle(sBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(sBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(sBrush, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(sBrush, heroX - 20, heroY + 20, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY + 20, heroSize, heroSize);
                    }
                    else if (rotationCount == 3)
                    {
                        e.Graphics.FillRectangle(sBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(sBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(sBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(sBrush, heroX - 20, heroY - 20, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY - 20, heroSize, heroSize);
                    }
                    else if (rotationCount == 4)
                    {
                        e.Graphics.FillRectangle(sBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(sBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(sBrush, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(sBrush, heroX - 20, heroY + 20, heroSize, heroSize);
                        
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY + 20, heroSize, heroSize);
                    }
                    break;
                case 3://L
                    if (rotationCount == 1)
                    {
                        e.Graphics.FillRectangle(lBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(lBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(lBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(lBrush, heroX, heroY - 40, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY - 40, heroSize, heroSize);
                    }
                    else if (rotationCount == 2)
                    {
                        e.Graphics.FillRectangle(lBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(lBrush, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(lBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(lBrush, heroX + 40, heroY, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX + 40, heroY, heroSize, heroSize);
                    }
                    else if (rotationCount == 3)
                    {
                        e.Graphics.FillRectangle(lBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(lBrush, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(lBrush, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(lBrush, heroX, heroY + 40, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY + 40, heroSize, heroSize);
                    }
                    else if (rotationCount == 4)
                    {
                        e.Graphics.FillRectangle(lBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(lBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(lBrush, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(lBrush, heroX - 40, heroY, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePenWhite, heroX - 40, heroY, heroSize, heroSize);
                    }
                    break;
                case 4://J
                    if (rotationCount == 1) 
                    {
                        e.Graphics.FillRectangle(jBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(jBrush, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(jBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(jBrush, heroX, heroY - 40, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX - 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY - 40, heroSize, heroSize);
                    }
                    else if (rotationCount == 2)
                    {
                        e.Graphics.FillRectangle(jBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(jBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(jBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(jBrush, heroX + 40, heroY, heroSize, heroSize);
                        
                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX + 40, heroY, heroSize, heroSize);
                    }
                    else if (rotationCount == 3)
                    {
                        e.Graphics.FillRectangle(jBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(jBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(jBrush, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(jBrush, heroX, heroY + 40, heroSize, heroSize);
                        
                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY + 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY + 40, heroSize, heroSize);
                    }
                    else if (rotationCount == 4)
                    {
                       e.Graphics.FillRectangle(jBrush, heroX, heroY, heroSize, heroSize);
                       e.Graphics.FillRectangle(jBrush, heroX, heroY + 20, heroSize, heroSize);
                       e.Graphics.FillRectangle(jBrush, heroX - 20, heroY , heroSize, heroSize);
                       e.Graphics.FillRectangle(jBrush, heroX - 40, heroY , heroSize, heroSize);
                                                            
                       e.Graphics.DrawRectangle(outlinePen, heroX, heroY, heroSize, heroSize);
                       e.Graphics.DrawRectangle(outlinePen, heroX, heroY + 20, heroSize, heroSize);
                       e.Graphics.DrawRectangle(outlinePen, heroX - 20, heroY, heroSize, heroSize);
                       e.Graphics.DrawRectangle(outlinePen, heroX - 40, heroY, heroSize, heroSize);
                    }
                    break;
                case 5://O
                    if (rotationCount == 1) 
                    {
                        e.Graphics.FillRectangle(oBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(oBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(oBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(oBrush, heroX + 20, heroY - 20, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX + 20, heroY - 20, heroSize, heroSize);
                    }
                    else if (rotationCount == 2)
                    {
                        e.Graphics.FillRectangle(oBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(oBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(oBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(oBrush, heroX + 20, heroY - 20, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX + 20, heroY - 20, heroSize, heroSize);
                    }
                    else if (rotationCount == 3)
                    {
                        e.Graphics.FillRectangle(oBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(oBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(oBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(oBrush, heroX + 20, heroY - 20, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX + 20, heroY - 20, heroSize, heroSize);
                    }
                    else if (rotationCount == 4)
                    {
                        e.Graphics.FillRectangle(oBrush, heroX, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(oBrush, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.FillRectangle(oBrush, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.FillRectangle(oBrush, heroX + 20, heroY - 20, heroSize, heroSize);

                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX + 20, heroY, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX, heroY - 20, heroSize, heroSize);
                        e.Graphics.DrawRectangle(outlinePen, heroX + 20, heroY - 20, heroSize, heroSize);
                    }
                    break;
            }
        }
    }
}