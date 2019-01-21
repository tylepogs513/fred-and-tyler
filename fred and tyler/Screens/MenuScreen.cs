using System;
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
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            MainForm.ChangeScreen(this, "GameScreen");
        }

        private void scoresButton_Click(object sender, EventArgs e)
        {
            MainForm.ChangeScreen(this, "ScoreScreen");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Enter(object sender, EventArgs e)
        {
            //start by changing all the buttons to the default colour
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                    c.BackColor = Color.White;
            }

            //change the current button to the active colour
            Button btn = (Button)sender;
            btn.BackColor = Color.Gold;
        }

        private void titleTimer_Tick(object sender, EventArgs e)
        {

        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {
           
        }

        private void MenuScreen_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush drawRed = new SolidBrush(Color.Red);
            SolidBrush drawBlack = new SolidBrush(Color.Black);
            SolidBrush drawWhite = new SolidBrush(Color.White);
            Font drawFont = new Font("MV Boli", 30, FontStyle.Regular);

            e.Graphics.FillRectangle(drawBlack, 0, 0, 350, 100);
            e.Graphics.DrawString("PALN FALLER", drawFont, drawWhite, 5, 25);
            e.Graphics.DrawString("PALN FALLER", drawFont, drawBlack, 4, 24);
            e.Graphics.DrawString("PALN FALLER", drawFont, drawRed, 3, 23);
        }
    }
}
