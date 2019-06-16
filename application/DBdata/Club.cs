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
        public int? Id { get; set; } // zabezpieczenie przed nullem
        public string Name { get; set; }
        public string City { get; set; }
        public short Founded { get; set; } // 0 to 65,535
        public string League { get; set; }

        public Club() { }

        public Club(IDataReader dataReader)
        {
            // dataReader.Read()
            Id = (int)dataReader["id"];
            Name = (string)dataReader["name"];
            City = (string)dataReader["city"];
            Founded = (short)dataReader["founded"];
            League = (string)dataReader["active"];
        }

        public Tuple<int, string, string, short, string> GetClub()
        {
            return new Tuple<int, string, string, short, string>((int)Id, Name, City, Founded, League);
        }
    }
}
