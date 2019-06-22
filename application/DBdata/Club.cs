using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace application.DBdata
{
    class Club
    {
        public int Id { get; set; } // zabezpieczenie przed nullem
        public string Name { get; set; }
        public string City { get; set; }
        public short Founded { get; set; } // 0 to 65,535
        public string League { get; set; }

        public List<Player> Players { get; set; }
        public List<Player> Coach { get; set; }
        public List<Player> Kits { get; set; }
        public List<Player> Crests { get; set; }

        public Club() { }

        public Club(IDataReader dataReader)
        {
            Id = int.Parse(dataReader["id"].ToString());
            Name = dataReader["name"].ToString();
            City = dataReader["city"].ToString();
            Founded = short.Parse(dataReader["founded"].ToString());
            League = dataReader["active"].ToString();
        }

        public Tuple<int, string, string, short, string> GetInfo()
        {
            return new Tuple<int, string, string, short, string>((int)Id, Name, City, Founded, League);
        }
    }
}
