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


        public Stadium() { }

        public Stadium(IDataReader dataReader)
        {
            // dataReader.Read()
            Id = (int)dataReader["id"];
            Name = (string)dataReader["name"];
            City = (string)dataReader["lastname"];
            Capacity = (int)dataReader["dateofbirth"];
        }

        public Tuple<int, string, string, int> GetInfo()
        {
            return new Tuple<int, string, string, int>((int)Id, Name, City, Capacity);
        }
    }
}
