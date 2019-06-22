namespace application.Controls.InsertPanel
{
    partial class InsertPanel
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
            this.flowLayoutPanelSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelShow = new System.Windows.Forms.FlowLayoutPanel();
            this.listViewItems = new System.Windows.Forms.ListView();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // flowLayoutPanelSearch
            // 
            this.flowLayoutPanelSearch.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanelSearch.Location = new System.Drawing.Point(0, 470);
            this.flowLayoutPanelSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanelSearch.Name = "flowLayoutPanelSearch";
            this.flowLayoutPanelSearch.Size = new System.Drawing.Size(1209, 168);
            this.flowLayoutPanelSearch.TabIndex = 6;
            // 
            // flowLayoutPanelShow
            // 
            this.flowLayoutPanelShow.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanelShow.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelShow.Name = "flowLayoutPanelShow";
            this.flowLayoutPanelShow.Size = new System.Drawing.Size(1209, 168);
            this.flowLayoutPanelShow.TabIndex = 5;
            // 
            // listViewItems
            // 
            this.listViewItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(47)))), ((int)(((byte)(86)))));
            this.listViewItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewItems.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listViewItems.ForeColor = System.Drawing.Color.White;
            this.listViewItems.Location = new System.Drawing.Point(0, 174);
            this.listViewItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewItems.Name = "listViewItems";
            this.listViewItems.Size = new System.Drawing.Size(1209, 290);
            this.listViewItems.TabIndex = 4;
            this.listViewItems.UseCompatibleStateImageBehavior = false;
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(103)))), ((int)(((byte)(0)))));
            this.buttonInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInsert.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonInsert.ForeColor = System.Drawing.Color.White;
            this.buttonInsert.Location = new System.Drawing.Point(1082, 649);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(127, 32);
            this.buttonInsert.TabIndex = 7;
            this.buttonInsert.Text = "Insert";
            this.buttonInsert.UseVisualStyleBackColor = false;
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(47)))), ((int)(((byte)(86)))));
            this.comboBoxTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTables.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxTables.ForeColor = System.Drawing.Color.White;
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Items.AddRange(new object[] {
            "Players",
            "Clubs",
            "Coaches",
            "Stadiums",
            "Crests",
            "Kits"});
            this.comboBoxTables.Location = new System.Drawing.Point(0, 653);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(286, 26);
            this.comboBoxTables.TabIndex = 8;
            // 
            // InsertPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.flowLayoutPanelSearch);
            this.Controls.Add(this.flowLayoutPanelShow);
            this.Controls.Add(this.listViewItems);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InsertPanel";
            this.Size = new System.Drawing.Size(1209, 689);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSearch;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelShow;
        private System.Windows.Forms.ListView listViewItems;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.ComboBox comboBoxTables;
    }
}
