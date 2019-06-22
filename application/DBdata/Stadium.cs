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
        //n:m


        public Stadium() { }

        public Stadium(IDataReader dataReader)
        {
            // dataReader.Read()
            Id = int.Parse(dataReader["id"].ToString());
            Name = dataReader["name"].ToString();
            City = dataReader["lastname"].ToString();
            Capacity = int.Parse(dataReader["dateofbirth"].ToString());
        }

        public Tuple<int, string, string, int> GetInfo()
        {
            return new Tuple<int, string, string, int>((int)Id, Name, City, Capacity);
        }
    }
}
