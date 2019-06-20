using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using application.Controls.ListViewControl;

namespace application.Controls
{
    public partial class DataControl : UserControl, IDataControl
    {
        public DataControl()
        {
            InitializeComponent();
        }
    }
}
