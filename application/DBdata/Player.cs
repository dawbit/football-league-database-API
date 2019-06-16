using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace application.DBdata
{
    class Player
    {
        public int? Id { get; set; } // zabezpieczenie przed nullem
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int Height { get; set; } 
        public int Weight { get; set; }

        private int number;

        public Player() { }

        public Player(IDataReader dataReader)
        {
            // dataReader.Read()
            Id = (int)dataReader["id_u"];
            FirstName = (string)dataReader["name"];
            LastName = (string)dataReader["lastname"];
            BirthDate = (DateTime)dataReader["dateofbirth"];
            Position = (string)dataReader["position"];

            if (dataReader["height"] == null) Height = 0;
            else Height = (int)dataReader["height"];

            if (dataReader["weight"] == null) Weight = 0;
            else Weight = (int)dataReader["height"];
        }

        public Tuple<int, string, string, DateTime, int, int> GetAnswer()
        {
            return new Tuple<int, string, string, DateTime, int, int>((int)Id, FirstName, LastName, BirthDate, Height, Weight);
        }
    }
}
