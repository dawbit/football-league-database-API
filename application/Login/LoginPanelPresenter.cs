using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Login
{
    class LoginPanelPresenter
    {
        ILogin view;
        Model model;

        public LoginPanelPresenter(ILogin view, Model model)
        {
            this.view = view;
            this.model = model;

            this.view.LoginCheck += View_LoginCheck;
        }

        private string View_LoginCheck()
        {
            return model.AccountType(this.view.Login, this.view.Password);
        }
    }
}
