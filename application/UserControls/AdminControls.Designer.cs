namespace application.UserControls
{
    partial class AdminControls
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
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(6)))), ((int)(((byte)(41)))));
            this.buttonInsert.BackgroundImage = global::application.Properties.Resources._001_plus;
            this.buttonInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsert.ForeColor = System.Drawing.Color.Transparent;
            this.buttonInsert.Location = new System.Drawing.Point(56, 1);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(34, 34);
            this.buttonInsert.TabIndex = 0;
            this.buttonInsert.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(6)))), ((int)(((byte)(41)))));
            this.buttonDelete.BackgroundImage = global::application.Properties.Resources._002_minus;
            this.buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.ForeColor = System.Drawing.Color.Transparent;
            this.buttonDelete.Location = new System.Drawing.Point(109, 1);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(34, 34);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(6)))), ((int)(((byte)(41)))));
            this.buttonUpdate.BackgroundImage = global::application.Properties.Resources._004_refresh;
            this.buttonUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.ForeColor = System.Drawing.Color.Transparent;
            this.buttonUpdate.Location = new System.Drawing.Point(162, 1);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(34, 34);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonSelect
            // 
            this.buttonSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(6)))), ((int)(((byte)(41)))));
            this.buttonSelect.BackgroundImage = global::application.Properties.Resources._003_list;
            this.buttonSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelect.ForeColor = System.Drawing.Color.Transparent;
            this.buttonSelect.Location = new System.Drawing.Point(3, 1);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(34, 34);
            this.buttonSelect.TabIndex = 3;
            this.buttonSelect.UseVisualStyleBackColor = false;
            // 
            // AdminControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonInsert);
            this.Name = "AdminControls";
            this.Size = new System.Drawing.Size(200, 36);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSelect;
    }
}
