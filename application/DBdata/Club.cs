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

        public Club() { }

        public Club(int Id, string Name, string City, short Founded, string League)
        {
            this.Id = Id;
            this.Name = Name;
            this.City = City;
            this.Founded = Founded;
            this.League = League;
        }
    }
}
