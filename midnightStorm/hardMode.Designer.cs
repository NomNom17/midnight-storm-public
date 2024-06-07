namespace midnightStorm
{
    partial class hardMode
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(hardMode));
            this.player = new System.Windows.Forms.PictureBox();
            this.gameTimer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.missed_label = new System.Windows.Forms.Label();
            this.score_label = new System.Windows.Forms.Label();
            this.poisondrop = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.backgroundPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poisondrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::midnightStorm.Properties.Resources.player_right;
            this.player.Location = new System.Drawing.Point(253, 536);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(119, 160);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 23;
            this.player.TabStop = false;
            // 
            // gameTimer2
            // 
            this.gameTimer2.Enabled = true;
            this.gameTimer2.Interval = 20;
            this.gameTimer2.Tick += new System.EventHandler(this.GameTick);
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Image = global::midnightStorm.Properties.Resources.raindrop;
            this.pictureBox12.Location = new System.Drawing.Point(494, 125);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(46, 58);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 30;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Tag = "raindrop";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = global::midnightStorm.Properties.Resources.raindrop;
            this.pictureBox8.Location = new System.Drawing.Point(253, 84);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(46, 58);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 28;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Tag = "raindrop";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::midnightStorm.Properties.Resources.random_raindrop;
            this.pictureBox5.Location = new System.Drawing.Point(170, 146);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(46, 58);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 27;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Tag = "randomdrop";
            // 
            // missed_label
            // 
            this.missed_label.AutoSize = true;
            this.missed_label.BackColor = System.Drawing.Color.Transparent;
            this.missed_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missed_label.ForeColor = System.Drawing.Color.White;
            this.missed_label.Location = new System.Drawing.Point(524, 553);
            this.missed_label.Name = "missed_label";
            this.missed_label.Size = new System.Drawing.Size(85, 20);
            this.missed_label.TabIndex = 32;
            this.missed_label.Text = "Missed: 0";
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.BackColor = System.Drawing.Color.Transparent;
            this.score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_label.ForeColor = System.Drawing.Color.White;
            this.score_label.Location = new System.Drawing.Point(9, 553);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(173, 20);
            this.score_label.TabIndex = 31;
            this.score_label.Text = "Rain Drop Caught: 0";
            // 
            // poisondrop
            // 
            this.poisondrop.BackColor = System.Drawing.Color.Transparent;
            this.poisondrop.Image = global::midnightStorm.Properties.Resources.bad_raindrop;
            this.poisondrop.Location = new System.Drawing.Point(112, -8);
            this.poisondrop.Name = "poisondrop";
            this.poisondrop.Size = new System.Drawing.Size(46, 58);
            this.poisondrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.poisondrop.TabIndex = 35;
            this.poisondrop.TabStop = false;
            this.poisondrop.Tag = "poisondrop";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::midnightStorm.Properties.Resources.bad_raindrop;
            this.pictureBox1.Location = new System.Drawing.Point(389, -8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "poisondrop";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::midnightStorm.Properties.Resources.bad_raindrop;
            this.pictureBox2.Location = new System.Drawing.Point(326, 193);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "poisondrop";
            // 
            // backgroundPlayer
            // 
            this.backgroundPlayer.Enabled = true;
            this.backgroundPlayer.Location = new System.Drawing.Point(367, 396);
            this.backgroundPlayer.Name = "backgroundPlayer";
            this.backgroundPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("backgroundPlayer.OcxState")));
            this.backgroundPlayer.Size = new System.Drawing.Size(75, 23);
            this.backgroundPlayer.TabIndex = 38;
            this.backgroundPlayer.Visible = false;
            // 
            // hardMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::midnightStorm.Properties.Resources.background_hard;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(612, 702);
            this.Controls.Add(this.backgroundPlayer);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.poisondrop);
            this.Controls.Add(this.player);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.missed_label);
            this.Controls.Add(this.score_label);
            this.DoubleBuffered = true;
            this.Name = "hardMode";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sunrising Storm (Hard Mode)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.hardMode_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poisondrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer gameTimer2;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label missed_label;
        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.PictureBox poisondrop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private AxWMPLib.AxWindowsMediaPlayer backgroundPlayer;
    }
}