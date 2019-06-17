using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.UserControls
{
    public partial class AdminControls : UserControl
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
    }
}
