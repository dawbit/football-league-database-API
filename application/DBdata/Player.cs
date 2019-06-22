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
        public byte Height { get; set; } // 0 to 255
        public byte Weight { get; set; }
        public string Nationality { get; set; }

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
            else Height = (byte)dataReader["height"];

            if (dataReader["weight"] == null) Weight = 0;
            else Weight = (byte)dataReader["height"];

            Nationality = (string)dataReader["nationality"];
        }

        public Tuple<int, string, string, DateTime, string, byte, byte, string> GetInfo()
        {
            return new Tuple<int, string, string, DateTime, string, byte, byte, string>((int)Id, FirstName, LastName, BirthDate, Position, Height, Weight, Nationality);
        }
    }
}
