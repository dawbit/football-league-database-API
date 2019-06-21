namespace application
{
    partial class FormMain
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonExit = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.mainApplicationPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonMenuPanel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(1177, 12);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(45, 36);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "X";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Transparent;
            this.panelLogo.BackgroundImage = global::application.Properties.Resources.lotto_logo;
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLogo.Location = new System.Drawing.Point(12, 12);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(224, 36);
            this.panelLogo.TabIndex = 1;
            // 
            // mainApplicationPanel
            // 
            this.mainApplicationPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainApplicationPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mainApplicationPanel.ForeColor = System.Drawing.Color.White;
            this.mainApplicationPanel.Location = new System.Drawing.Point(12, 59);
            this.mainApplicationPanel.Name = "mainApplicationPanel";
            this.mainApplicationPanel.Size = new System.Drawing.Size(1210, 690);
            this.mainApplicationPanel.TabIndex = 4;
            // 
            // buttonMenuPanel
            // 
            this.buttonMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(103)))), ((int)(((byte)(0)))));
            this.buttonMenuPanel.BackgroundImage = global::application.Properties.Resources.start;
            this.buttonMenuPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMenuPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenuPanel.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonMenuPanel.ForeColor = System.Drawing.Color.White;
            this.buttonMenuPanel.Location = new System.Drawing.Point(268, 12);
            this.buttonMenuPanel.Name = "buttonMenuPanel";
            this.buttonMenuPanel.Size = new System.Drawing.Size(36, 36);
            this.buttonMenuPanel.TabIndex = 5;
            this.buttonMenuPanel.UseVisualStyleBackColor = false;
            this.buttonMenuPanel.Click += new System.EventHandler(this.buttonMenuPanel_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::application.Properties.Resources.background_swapped;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1234, 761);
            this.Controls.Add(this.buttonMenuPanel);
            this.Controls.Add(this.mainApplicationPanel);
            this.Controls.Add(this.panelLogo);
            this.Controls.Add(this.buttonExit);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekstraklasa";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.FlowLayoutPanel mainApplicationPanel;
        private System.Windows.Forms.Button buttonMenuPanel;
    }
}

