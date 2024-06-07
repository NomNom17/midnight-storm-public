namespace midnightStorm
{
    partial class mediumMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mediumMode));
            this.player = new System.Windows.Forms.PictureBox();
            this.lightningstrike = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.missed_label = new System.Windows.Forms.Label();
            this.score_label = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.poisondrop = new System.Windows.Forms.PictureBox();
            this.gameTimer1 = new System.Windows.Forms.Timer(this.components);
            this.turbo_label = new System.Windows.Forms.Label();
            this.backgroundPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightningstrike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poisondrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::midnightStorm.Properties.Resources.player_right;
            this.player.Location = new System.Drawing.Point(377, 503);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(119, 160);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 21;
            this.player.TabStop = false;
            // 
            // lightningstrike
            // 
            this.lightningstrike.BackColor = System.Drawing.Color.Transparent;
            this.lightningstrike.Image = global::midnightStorm.Properties.Resources.Lightning;
            this.lightningstrike.Location = new System.Drawing.Point(336, 278);
            this.lightningstrike.Name = "lightningstrike";
            this.lightningstrike.Size = new System.Drawing.Size(185, 247);
            this.lightningstrike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lightningstrike.TabIndex = 28;
            this.lightningstrike.TabStop = false;
            this.lightningstrike.Visible = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Image = global::midnightStorm.Properties.Resources.raindrop;
            this.pictureBox12.Location = new System.Drawing.Point(618, 92);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(46, 58);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 25;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Tag = "raindrop";
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Image = global::midnightStorm.Properties.Resources.raindrop;
            this.pictureBox10.Location = new System.Drawing.Point(526, 81);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(46, 58);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 24;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Tag = "raindrop";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = global::midnightStorm.Properties.Resources.raindrop;
            this.pictureBox8.Location = new System.Drawing.Point(371, 40);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(46, 58);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 23;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Tag = "raindrop";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::midnightStorm.Properties.Resources.raindrop;
            this.pictureBox5.Location = new System.Drawing.Point(165, 60);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(46, 58);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Tag = "raindrop";
            // 
            // missed_label
            // 
            this.missed_label.AutoSize = true;
            this.missed_label.BackColor = System.Drawing.Color.Transparent;
            this.missed_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missed_label.ForeColor = System.Drawing.Color.White;
            this.missed_label.Location = new System.Drawing.Point(770, 549);
            this.missed_label.Name = "missed_label";
            this.missed_label.Size = new System.Drawing.Size(85, 20);
            this.missed_label.TabIndex = 27;
            this.missed_label.Text = "Missed: 0";
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.BackColor = System.Drawing.Color.Transparent;
            this.score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_label.ForeColor = System.Drawing.Color.White;
            this.score_label.Location = new System.Drawing.Point(3, 549);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(173, 20);
            this.score_label.TabIndex = 26;
            this.score_label.Text = "Rain Drop Caught: 0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::midnightStorm.Properties.Resources.raindrop;
            this.pictureBox1.Location = new System.Drawing.Point(27, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "raindrop";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::midnightStorm.Properties.Resources.raindrop;
            this.pictureBox3.Location = new System.Drawing.Point(716, 40);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(46, 58);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 31;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "raindrop";
            // 
            // poisondrop
            // 
            this.poisondrop.BackColor = System.Drawing.Color.Transparent;
            this.poisondrop.Image = global::midnightStorm.Properties.Resources.bad_raindrop;
            this.poisondrop.Location = new System.Drawing.Point(266, 92);
            this.poisondrop.Name = "poisondrop";
            this.poisondrop.Size = new System.Drawing.Size(46, 58);
            this.poisondrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.poisondrop.TabIndex = 32;
            this.poisondrop.TabStop = false;
            this.poisondrop.Tag = "bad_raindrop";
            // 
            // gameTimer1
            // 
            this.gameTimer1.Enabled = true;
            this.gameTimer1.Interval = 20;
            this.gameTimer1.Tick += new System.EventHandler(this.GameTick);
            // 
            // turbo_label
            // 
            this.turbo_label.AutoSize = true;
            this.turbo_label.BackColor = System.Drawing.Color.Transparent;
            this.turbo_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turbo_label.Location = new System.Drawing.Point(12, 181);
            this.turbo_label.Name = "turbo_label";
            this.turbo_label.Size = new System.Drawing.Size(386, 39);
            this.turbo_label.TabIndex = 33;
            this.turbo_label.Text = "Turbo Mode Activated!";
            this.turbo_label.Visible = false;
            // 
            // backgroundPlayer
            // 
            this.backgroundPlayer.Enabled = true;
            this.backgroundPlayer.Location = new System.Drawing.Point(102, 468);
            this.backgroundPlayer.Name = "backgroundPlayer";
            this.backgroundPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("backgroundPlayer.OcxState")));
            this.backgroundPlayer.Size = new System.Drawing.Size(75, 23);
            this.backgroundPlayer.TabIndex = 34;
            this.backgroundPlayer.Visible = false;
            // 
            // mediumMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::midnightStorm.Properties.Resources.Background_medium;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(867, 702);
            this.Controls.Add(this.backgroundPlayer);
            this.Controls.Add(this.poisondrop);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.player);
            this.Controls.Add(this.lightningstrike);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.missed_label);
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.turbo_label);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mediumMode";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evening Storm (Medium Mode)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mediumMode_FormClosed);
            this.Load += new System.EventHandler(this.mediumMode_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightningstrike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poisondrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox lightningstrike;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label missed_label;
        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox poisondrop;
        private System.Windows.Forms.Timer gameTimer1;
        private System.Windows.Forms.Label turbo_label;
        private AxWMPLib.AxWindowsMediaPlayer backgroundPlayer;
    }
}