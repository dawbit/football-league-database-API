﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    class MainFormPresenter
    {
        IMainForm view;
        Model model;

        public MainFormPresenter(IMainForm view, Model model)
        {
            this.view = view;
            this.model = model;

        }
    }
}
