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
        public int? ClubKit { get; set; }


        public Kit() { }

        public Kit(IDataReader dataReader)
        {
            Id = int.Parse(dataReader["id"].ToString());
            HomeKit = dataReader["home"].ToString();
            AwayKit = dataReader["away"].ToString();
            ClubColors = dataReader["clubcolours"].ToString();
            ClubKit = int.Parse(dataReader["club"].ToString());
        }

        public Tuple<int, string, string, string, int> GetInfo()
        {
            return new Tuple<int, string, string, string, int>((int)Id, HomeKit, AwayKit, ClubColors, (int)ClubKit);
        }
    }
}
