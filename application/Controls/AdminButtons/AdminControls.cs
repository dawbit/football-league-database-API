using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.Controls.AdminButtons
{
    public partial class AdminControls : UserControl, IAdminControl
    {
        public AdminControls()
        {
            InitializeComponent();

            #region BORDER Removal
            buttonInsert.TabStop = false;
            buttonInsert.FlatStyle = FlatStyle.Flat;
            buttonInsert.FlatAppearance.BorderSize = 0;
            buttonInsert.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            buttonDelete.TabStop = false;
            buttonDelete.FlatStyle = FlatStyle.Flat;
            buttonDelete.FlatAppearance.BorderSize = 0;
            buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            buttonUpdate.TabStop = false;
            buttonUpdate.FlatStyle = FlatStyle.Flat;
            buttonUpdate.FlatAppearance.BorderSize = 0;
            buttonUpdate.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            buttonSelect.TabStop = false;
            buttonSelect.FlatStyle = FlatStyle.Flat;
            buttonSelect.FlatAppearance.BorderSize = 0;
            buttonSelect.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            #endregion
        }

        public event Action Load_SelectPanel;
        public event Action Load_InsertPanel;
        public event Action Load_DeletePanel;
        public event Action Load_UpdatePanel;


        private void buttonSelect_Click(object sender, EventArgs e)
        {
            Load_SelectPanel?.Invoke();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Load_InsertPanel.Method.Name);
            Load_InsertPanel?.Invoke();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Load_DeletePanel?.Invoke();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Load_UpdatePanel?.Invoke();
        }
    }
}
