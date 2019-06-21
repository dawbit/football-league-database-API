﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.Controls.MenuPanel
{
    class PresenterMenuPanel
    {
        IMenuPanel view;
        Model model;

        public PresenterMenuPanel(IMenuPanel view, Model model)
        {
            this.view = view;
            this.model = model;
        }
    }
}
