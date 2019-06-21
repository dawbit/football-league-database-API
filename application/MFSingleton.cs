using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application
{
    class MFSingleton
    {
        private static MFSingleton instance = null;

        public static MFSingleton Instance
        {
            get
            {
                return instance ?? (instance = new MFSingleton());
            }
        }

        public IMainForm view { get; private set; }

        private MFSingleton()
        {
            view = new FormMain();
        }
    }
}
