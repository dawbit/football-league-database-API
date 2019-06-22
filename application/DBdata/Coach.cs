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
        public int? ClubCoach { get; set; }


        public Coach() { }

        public Coach(IDataReader dataReader)
        {
            // dataReader.Read()
            Id = int.Parse(dataReader["id"].ToString());
            FirstName = (string)dataReader["name"].ToString();
            LastName = (string)dataReader["lastname"].ToString();
            BirthDate = DateTime.Parse(dataReader["dateofbirth"].ToString());
            Nationality = (string)dataReader["nationality"].ToString();
            ClubCoach = int.Parse(dataReader["club"].ToString());
        }

        public Tuple<int, string, string, DateTime, string, int> GetInfo()
        {
            return new Tuple<int, string, string, DateTime, string, int>((int)Id, FirstName, LastName, BirthDate, Nationality, (int)ClubCoach);
        }
    }
}
