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
            // dataReader.Read()
            Id = (int)dataReader["id_u"];
            HomeKit = (string)dataReader["home"];
            AwayKit = (string)dataReader["away"];
            ClubColors = (string)dataReader["clubcolours"];
            ClubKit = (int)dataReader["club"];
        }

        public Tuple<int, string, string, string, int> GetInfo()
        {
            return new Tuple<int, string, string, string, int>((int)Id, HomeKit, AwayKit, ClubColors, (int)ClubKit);
        }
    }
}
