namespace application.UserControls
{
    partial class MainMenuPanel
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
            this.buttonPlayers = new System.Windows.Forms.Button();
            this.buttonClubs = new System.Windows.Forms.Button();
            this.buttonCoaches = new System.Windows.Forms.Button();
            this.buttonKits = new System.Windows.Forms.Button();
            this.buttonCrests = new System.Windows.Forms.Button();
            this.buttonStadiums = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlayers
            // 
            this.buttonPlayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(47)))), ((int)(((byte)(86)))));
            this.buttonPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayers.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPlayers.ForeColor = System.Drawing.Color.White;
            this.buttonPlayers.Location = new System.Drawing.Point(50, 79);
            this.buttonPlayers.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonPlayers.Name = "buttonPlayers";
            this.buttonPlayers.Size = new System.Drawing.Size(213, 59);
            this.buttonPlayers.TabIndex = 0;
            this.buttonPlayers.Text = "Gracze";
            this.buttonPlayers.UseVisualStyleBackColor = false;
            this.buttonPlayers.Click += new System.EventHandler(this.mainPanelButton_Click);
            // 
            // buttonClubs
            // 
            this.buttonClubs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(47)))), ((int)(((byte)(86)))));
            this.buttonClubs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClubs.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClubs.ForeColor = System.Drawing.Color.White;
            this.buttonClubs.Location = new System.Drawing.Point(50, 266);
            this.buttonClubs.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonClubs.Name = "buttonClubs";
            this.buttonClubs.Size = new System.Drawing.Size(213, 59);
            this.buttonClubs.TabIndex = 1;
            this.buttonClubs.Text = "Kluby";
            this.buttonClubs.UseVisualStyleBackColor = false;
            this.buttonClubs.Click += new System.EventHandler(this.mainPanelButton_Click);
            // 
            // buttonCoaches
            // 
            this.buttonCoaches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(47)))), ((int)(((byte)(86)))));
            this.buttonCoaches.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCoaches.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCoaches.ForeColor = System.Drawing.Color.White;
            this.buttonCoaches.Location = new System.Drawing.Point(50, 453);
            this.buttonCoaches.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonCoaches.Name = "buttonCoaches";
            this.buttonCoaches.Size = new System.Drawing.Size(213, 59);
            this.buttonCoaches.TabIndex = 2;
            this.buttonCoaches.Text = "Trenerzy";
            this.buttonCoaches.UseVisualStyleBackColor = false;
            this.buttonCoaches.Click += new System.EventHandler(this.mainPanelButton_Click);
            // 
            // buttonKits
            // 
            this.buttonKits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(47)))), ((int)(((byte)(86)))));
            this.buttonKits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKits.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonKits.ForeColor = System.Drawing.Color.White;
            this.buttonKits.Location = new System.Drawing.Point(946, 453);
            this.buttonKits.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonKits.Name = "buttonKits";
            this.buttonKits.Size = new System.Drawing.Size(213, 59);
            this.buttonKits.TabIndex = 5;
            this.buttonKits.Text = "Barwy";
            this.buttonKits.UseVisualStyleBackColor = false;
            this.buttonKits.Click += new System.EventHandler(this.mainPanelButton_Click);
            // 
            // buttonCrests
            // 
            this.buttonCrests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(47)))), ((int)(((byte)(86)))));
            this.buttonCrests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCrests.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCrests.ForeColor = System.Drawing.Color.White;
            this.buttonCrests.Location = new System.Drawing.Point(946, 266);
            this.buttonCrests.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonCrests.Name = "buttonCrests";
            this.buttonCrests.Size = new System.Drawing.Size(213, 59);
            this.buttonCrests.TabIndex = 4;
            this.buttonCrests.Text = "Herby";
            this.buttonCrests.UseVisualStyleBackColor = false;
            this.buttonCrests.Click += new System.EventHandler(this.mainPanelButton_Click);
            // 
            // buttonStadiums
            // 
            this.buttonStadiums.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(47)))), ((int)(((byte)(86)))));
            this.buttonStadiums.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStadiums.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStadiums.ForeColor = System.Drawing.Color.White;
            this.buttonStadiums.Location = new System.Drawing.Point(946, 79);
            this.buttonStadiums.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.buttonStadiums.Name = "buttonStadiums";
            this.buttonStadiums.Size = new System.Drawing.Size(213, 59);
            this.buttonStadiums.TabIndex = 3;
            this.buttonStadiums.Text = "Stadiony";
            this.buttonStadiums.UseVisualStyleBackColor = false;
            this.buttonStadiums.Click += new System.EventHandler(this.mainPanelButton_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxLogo.Image = global::application.Properties.Resources.logo_white;
            this.pictureBoxLogo.ImageLocation = "";
            this.pictureBoxLogo.Location = new System.Drawing.Point(409, 164);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(390, 360);
            this.pictureBoxLogo.TabIndex = 8;
            this.pictureBoxLogo.TabStop = false;
            // 
            // MainMenuPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.buttonKits);
            this.Controls.Add(this.buttonCrests);
            this.Controls.Add(this.buttonStadiums);
            this.Controls.Add(this.buttonCoaches);
            this.Controls.Add(this.buttonClubs);
            this.Controls.Add(this.buttonPlayers);
            this.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MainMenuPanel";
            this.Size = new System.Drawing.Size(1209, 689);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlayers;
        private System.Windows.Forms.Button buttonClubs;
        private System.Windows.Forms.Button buttonCoaches;
        private System.Windows.Forms.Button buttonKits;
        private System.Windows.Forms.Button buttonCrests;
        private System.Windows.Forms.Button buttonStadiums;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}
