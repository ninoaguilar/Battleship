namespace battleship
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.startScreen = new System.Windows.Forms.PictureBox();
            this.beginButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(318, -26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(449, 125);
            this.pictureBox2.TabIndex = 248;
            this.pictureBox2.TabStop = false;
            // 
            // startScreen
            // 
            this.startScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startScreen.BackgroundImage")));
            this.startScreen.Location = new System.Drawing.Point(0, 0);
            this.startScreen.Name = "startScreen";
            this.startScreen.Size = new System.Drawing.Size(1100, 700);
            this.startScreen.TabIndex = 249;
            this.startScreen.TabStop = false;
            // 
            // beginButton
            // 
            this.beginButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.beginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beginButton.ForeColor = System.Drawing.Color.White;
            this.beginButton.Location = new System.Drawing.Point(460, 579);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(164, 70);
            this.beginButton.TabIndex = 250;
            this.beginButton.Text = "Begin";
            this.beginButton.UseVisualStyleBackColor = false;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.beginButton);
            this.Controls.Add(this.startScreen);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox startScreen;
        private System.Windows.Forms.Button beginButton;
    }
}

