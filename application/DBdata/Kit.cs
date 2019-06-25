using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace application.DBdata
{
    class Kit
    {
        public int? Id { get; set; } // zabezpieczenie przed nullem
        public string HomeKit { get; set; }
        public string AwayKit { get; set; }
        public string ClubColors { get; set; }
        public string ClubKit { get; set; }


        public Kit() { }

        public Kit(int Id, string HomeKit, string AwayKit, string ClubColors, string ClubKit)
        {
            this.Id = Id;
            this.HomeKit = HomeKit;
            this.AwayKit = AwayKit;
            this.ClubColors = ClubColors;
            this.ClubKit = ClubKit;
        }
    }
}
