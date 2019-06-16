using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace application.DBdata
{
    class Coach
    {
        public int? Id { get; set; } // zabezpieczenie przed nullem
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }


        public Coach() { }

        public Coach(IDataReader dataReader)
        {
            // dataReader.Read()
            Id = (int)dataReader["id_u"];
            FirstName = (string)dataReader["name"];
            LastName = (string)dataReader["lastname"];
            BirthDate = (DateTime)dataReader["dateofbirth"];
            Nationality = (string)dataReader["nationality"];
        }

        public Tuple<int, string, string, DateTime, string> GetCoach()
        {
            return new Tuple<int, string, string, DateTime, string>((int)Id, FirstName, LastName, BirthDate, Nationality);
        }
    }
}
