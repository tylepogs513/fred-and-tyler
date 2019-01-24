namespace fred_and_tyler
{
    partial class ScoreScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.yellowButt = new System.Windows.Forms.PictureBox();
            this.redButt = new System.Windows.Forms.PictureBox();
            this.greenButt = new System.Windows.Forms.PictureBox();
            this.blueButt = new System.Windows.Forms.PictureBox();
            this.yellowLab = new System.Windows.Forms.Label();
            this.redLab = new System.Windows.Forms.Label();
            this.greenLab = new System.Windows.Forms.Label();
            this.blueLab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.yellowButt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redButt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenButt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueButt)).BeginInit();
            this.SuspendLayout();
            // 
            // yellowButt
            // 
            this.yellowButt.Image = global::fred_and_tyler.Properties.Resources.yellow_50x50;
            this.yellowButt.Location = new System.Drawing.Point(125, 75);
            this.yellowButt.Name = "yellowButt";
            this.yellowButt.Size = new System.Drawing.Size(50, 50);
            this.yellowButt.TabIndex = 10;
            this.yellowButt.TabStop = false;
            // 
            // redButt
            // 
            this.redButt.Image = global::fred_and_tyler.Properties.Resources.red_50x50;
            this.redButt.Location = new System.Drawing.Point(175, 125);
            this.redButt.Name = "redButt";
            this.redButt.Size = new System.Drawing.Size(50, 50);
            this.redButt.TabIndex = 11;
            this.redButt.TabStop = false;
            // 
            // greenButt
            // 
            this.greenButt.Image = global::fred_and_tyler.Properties.Resources.green_50x50;
            this.greenButt.Location = new System.Drawing.Point(125, 175);
            this.greenButt.Name = "greenButt";
            this.greenButt.Size = new System.Drawing.Size(50, 50);
            this.greenButt.TabIndex = 12;
            this.greenButt.TabStop = false;
            // 
            // blueButt
            // 
            this.blueButt.Image = global::fred_and_tyler.Properties.Resources.blue_50x50;
            this.blueButt.Location = new System.Drawing.Point(75, 125);
            this.blueButt.Name = "blueButt";
            this.blueButt.Size = new System.Drawing.Size(50, 50);
            this.blueButt.TabIndex = 13;
            this.blueButt.TabStop = false;
            // 
            // yellowLab
            // 
            this.yellowLab.AutoSize = true;
            this.yellowLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yellowLab.Location = new System.Drawing.Point(41, 56);
            this.yellowLab.Name = "yellowLab";
            this.yellowLab.Size = new System.Drawing.Size(216, 16);
            this.yellowLab.TabIndex = 14;
            this.yellowLab.Text = "Rotates 90 degrees clockwise";
            // 
            // redLab
            // 
            this.redLab.AutoSize = true;
            this.redLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redLab.Location = new System.Drawing.Point(231, 134);
            this.redLab.MaximumSize = new System.Drawing.Size(70, 0);
            this.redLab.Name = "redLab";
            this.redLab.Size = new System.Drawing.Size(63, 32);
            this.redLab.TabIndex = 15;
            this.redLab.Text = "Moves tile right";
            // 
            // greenLab
            // 
            this.greenLab.AutoSize = true;
            this.greenLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greenLab.Location = new System.Drawing.Point(68, 229);
            this.greenLab.Name = "greenLab";
            this.greenLab.Size = new System.Drawing.Size(161, 16);
            this.greenLab.TabIndex = 16;
            this.greenLab.Text = "Drops piece to bottom";
            // 
            // blueLab
            // 
            this.blueLab.AutoSize = true;
            this.blueLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blueLab.Location = new System.Drawing.Point(11, 134);
            this.blueLab.MaximumSize = new System.Drawing.Size(70, 0);
            this.blueLab.Name = "blueLab";
            this.blueLab.Size = new System.Drawing.Size(58, 32);
            this.blueLab.TabIndex = 17;
            this.blueLab.Text = "Moves tile left";
            // 
            // ScoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.Controls.Add(this.blueLab);
            this.Controls.Add(this.greenLab);
            this.Controls.Add(this.redLab);
            this.Controls.Add(this.yellowLab);
            this.Controls.Add(this.blueButt);
            this.Controls.Add(this.greenButt);
            this.Controls.Add(this.redButt);
            this.Controls.Add(this.yellowButt);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ScoreScreen";
            this.Size = new System.Drawing.Size(300, 300);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ScoreScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.yellowButt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redButt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenButt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueButt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox yellowButt;
        private System.Windows.Forms.PictureBox redButt;
        private System.Windows.Forms.PictureBox greenButt;
        private System.Windows.Forms.PictureBox blueButt;
        private System.Windows.Forms.Label yellowLab;
        private System.Windows.Forms.Label redLab;
        private System.Windows.Forms.Label greenLab;
        private System.Windows.Forms.Label blueLab;
    }
}
