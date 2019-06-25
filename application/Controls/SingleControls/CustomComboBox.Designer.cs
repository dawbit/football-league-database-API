namespace application.Controls.SingleControls
{
    partial class CustomComboBox
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
            this.cbClubs = new System.Windows.Forms.ComboBox();
            this.labelText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbClubs
            // 
            this.cbClubs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClubs.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbClubs.FormattingEnabled = true;
            this.cbClubs.Location = new System.Drawing.Point(78, 1);
            this.cbClubs.Name = "cbClubs";
            this.cbClubs.Size = new System.Drawing.Size(199, 26);
            this.cbClubs.TabIndex = 0;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.labelText.Location = new System.Drawing.Point(6, 6);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(0, 18);
            this.labelText.TabIndex = 1;
            // 
            // ComboBoxClubs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(47)))), ((int)(((byte)(86)))));
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.cbClubs);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ComboBoxClubs";
            this.Size = new System.Drawing.Size(278, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClubs;
        private System.Windows.Forms.Label labelText;
    }
}
