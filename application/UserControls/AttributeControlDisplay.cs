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
    public partial class AttributeControlDisplay : UserControl
    {
        public AttributeControlDisplay()
        {
            InitializeComponent();
        }

        public string AttributeName
        {
            get
            {
                return labelAttributeName.Text;
            }
            set
            {
                labelAttributeName.Text = value;
            }
        }

        public string AttributValue
        {
            get
            {
                return labelAttributeValue.Text;
            }
            set
            {
                labelAttributeValue.Text = value;
            }
        }
    }
}
