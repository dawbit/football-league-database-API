using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Login
{
    interface ILogin
    {
        string Login { get; set; }
        string Password { get; }

        event Func<string> LoginCheck;
    }
}
