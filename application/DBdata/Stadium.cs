using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace application.DBdata
{
    class Stadium
    {
        public int? Id { get; set; } // zabezpieczenie przed nullem
        public string Name { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public int YearOfBuilt { get; set; }
        public string ClubStadium { get; set; } 


        public Stadium() { }

        public Stadium(int Id, string Name, string City, int Capacity, int YearOfBuilt, string ClubStadium)
        {
            this.Id = Id;
            this.Name = Name;
            this.City = City;
            this.Capacity = Capacity;
            this.YearOfBuilt = YearOfBuilt;
            this.ClubStadium = ClubStadium;
        }

    }
}
