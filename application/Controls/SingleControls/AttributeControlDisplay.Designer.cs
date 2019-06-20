namespace application.Controls
{
    partial class AttributeControlDisplay
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
            this.labelAttributeName = new System.Windows.Forms.Label();
            this.labelAttributeValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAttributeName
            // 
            this.labelAttributeName.AutoSize = true;
            this.labelAttributeName.BackColor = System.Drawing.Color.Transparent;
            this.labelAttributeName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAttributeName.ForeColor = System.Drawing.Color.White;
            this.labelAttributeName.Location = new System.Drawing.Point(5, 3);
            this.labelAttributeName.Name = "labelAttributeName";
            this.labelAttributeName.Size = new System.Drawing.Size(0, 22);
            this.labelAttributeName.TabIndex = 0;
            // 
            // labelAttributeValue
            // 
            this.labelAttributeValue.AutoSize = true;
            this.labelAttributeValue.BackColor = System.Drawing.Color.Transparent;
            this.labelAttributeValue.ForeColor = System.Drawing.Color.White;
            this.labelAttributeValue.Location = new System.Drawing.Point(67, 5);
            this.labelAttributeValue.Name = "labelAttributeValue";
            this.labelAttributeValue.Size = new System.Drawing.Size(0, 20);
            this.labelAttributeValue.TabIndex = 1;
            // 
            // AttributeControlDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(47)))), ((int)(((byte)(86)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelAttributeValue);
            this.Controls.Add(this.labelAttributeName);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AttributeControlDisplay";
            this.Size = new System.Drawing.Size(278, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAttributeName;
        private System.Windows.Forms.Label labelAttributeValue;
    }
}
