namespace midnightStorm
{
    partial class select_level
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
            this.easyMode = new System.Windows.Forms.Button();
            this.mediumMode = new System.Windows.Forms.Button();
            this.hardMode = new System.Windows.Forms.Button();
            this.extreme_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // easyMode
            // 
            this.easyMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.easyMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyMode.ForeColor = System.Drawing.Color.White;
            this.easyMode.Location = new System.Drawing.Point(3, 2);
            this.easyMode.Name = "easyMode";
            this.easyMode.Size = new System.Drawing.Size(99, 84);
            this.easyMode.TabIndex = 0;
            this.easyMode.Text = "Easy (Midnight Level)";
            this.easyMode.UseVisualStyleBackColor = true;
            this.easyMode.Click += new System.EventHandler(this.button1_Click);
            // 
            // mediumMode
            // 
            this.mediumMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mediumMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediumMode.ForeColor = System.Drawing.Color.White;
            this.mediumMode.Location = new System.Drawing.Point(108, 2);
            this.mediumMode.Name = "mediumMode";
            this.mediumMode.Size = new System.Drawing.Size(99, 84);
            this.mediumMode.TabIndex = 1;
            this.mediumMode.Text = "Medium (Morning Level)";
            this.mediumMode.UseVisualStyleBackColor = true;
            this.mediumMode.Click += new System.EventHandler(this.mediumMode_Click);
            // 
            // hardMode
            // 
            this.hardMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hardMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardMode.ForeColor = System.Drawing.Color.White;
            this.hardMode.Location = new System.Drawing.Point(213, 2);
            this.hardMode.Name = "hardMode";
            this.hardMode.Size = new System.Drawing.Size(99, 84);
            this.hardMode.TabIndex = 2;
            this.hardMode.Text = "Hard (Sunrise Level)";
            this.hardMode.UseVisualStyleBackColor = true;
            this.hardMode.Click += new System.EventHandler(this.hardMode_Click_1);
            // 
            // extreme_button
            // 
            this.extreme_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.extreme_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extreme_button.ForeColor = System.Drawing.Color.White;
            this.extreme_button.Location = new System.Drawing.Point(310, 2);
            this.extreme_button.Name = "extreme_button";
            this.extreme_button.Size = new System.Drawing.Size(99, 84);
            this.extreme_button.TabIndex = 3;
            this.extreme_button.Text = "Extreme (Sunset Level)";
            this.extreme_button.UseVisualStyleBackColor = true;
            this.extreme_button.Click += new System.EventHandler(this.extreme_button_click);
            // 
            // select_level
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(421, 96);
            this.Controls.Add(this.extreme_button);
            this.Controls.Add(this.hardMode);
            this.Controls.Add(this.mediumMode);
            this.Controls.Add(this.easyMode);
            this.MaximizeBox = false;
            this.Name = "select_level";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select a Level!";
            this.Load += new System.EventHandler(this.select_level_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button easyMode;
        internal System.Windows.Forms.Button mediumMode;
        internal System.Windows.Forms.Button hardMode;
        internal System.Windows.Forms.Button extreme_button;
    }
}