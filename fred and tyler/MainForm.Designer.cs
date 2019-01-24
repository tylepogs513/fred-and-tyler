namespace fred_and_tyler
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.creatorsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // creatorsLabel
            // 
            this.creatorsLabel.AutoSize = true;
            this.creatorsLabel.BackColor = System.Drawing.Color.Black;
            this.creatorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F);
            this.creatorsLabel.ForeColor = System.Drawing.Color.White;
            this.creatorsLabel.Location = new System.Drawing.Point(225, 439);
            this.creatorsLabel.Name = "creatorsLabel";
            this.creatorsLabel.Size = new System.Drawing.Size(119, 7);
            this.creatorsLabel.TabIndex = 5;
            this.creatorsLabel.Text = "By Fred Hammerl and Tyler Pogson";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(560, 455);
            this.Controls.Add(this.creatorsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P.A.L.N. Faller";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label creatorsLabel;
    }
}

