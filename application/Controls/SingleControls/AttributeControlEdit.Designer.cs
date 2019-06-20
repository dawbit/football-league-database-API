namespace application.Controls
{
    partial class AttributeControlEdit
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
            this.textBoxEdit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelAttributeName
            // 
            this.labelAttributeName.AutoSize = true;
            this.labelAttributeName.BackColor = System.Drawing.Color.Transparent;
            this.labelAttributeName.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAttributeName.ForeColor = System.Drawing.Color.White;
            this.labelAttributeName.Location = new System.Drawing.Point(5, 1);
            this.labelAttributeName.Name = "labelAttributeName";
            this.labelAttributeName.Size = new System.Drawing.Size(0, 22);
            this.labelAttributeName.TabIndex = 1;
            // 
            // textBoxEdit
            // 
            this.textBoxEdit.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxEdit.Location = new System.Drawing.Point(68, 1);
            this.textBoxEdit.Name = "textBoxEdit";
            this.textBoxEdit.Size = new System.Drawing.Size(205, 23);
            this.textBoxEdit.TabIndex = 2;
            // 
            // AttributeControlEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(47)))), ((int)(((byte)(86)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textBoxEdit);
            this.Controls.Add(this.labelAttributeName);
            this.Font = new System.Drawing.Font("Trebuchet MS", 11.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AttributeControlEdit";
            this.Size = new System.Drawing.Size(276, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAttributeName;
        private System.Windows.Forms.TextBox textBoxEdit;
    }
}
