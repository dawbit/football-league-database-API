using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;

namespace application.DBdata
{
    class Player
    {
        public int? Id { get; set; } // zabezpieczenie przed nullem
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int Height { get; set; } // 0 to 255
        public int Weight { get; set; }
        public string Nationality { get; set; }
        public int? ClubPlayer { get; set; }

        private int number;


        public Player() { }

        //public Player(IDataReader dataReader)
        //{
        //    Id = int.Parse(dataReader["id"].ToString());
        //    FirstName = dataReader["pname"].ToString();
        //    LastName = dataReader["lastname"].ToString();
        //    BirthDate = DateTime.Parse(dataReader["dateofbirth"].ToString());
        //    Position = dataReader["position"].ToString();

        //    if (dataReader["height"].ToString() == "") Height = 0;
        //    else Height = int.Parse(dataReader["height"].ToString());

        //    if (dataReader["weight"].ToString() == "") Weight = 0;
        //    else Weight = int.Parse(dataReader["weight"].ToString());

        //    Nationality = dataReader["nationality"].ToString();
        //}

        public Player(int Id, string FirstName, string LastName, DateTime BirthDate, string Position, int Height, int Weight, string Nationality)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate;
            this.Position = Position;
            this.Height = Height;
            this.Weight = Weight;
            this.Nationality = Nationality;
        }

        public Tuple<int, string, string, DateTime, string, int, int, string> GetInfo()
        {
            return new Tuple<int, string, string, DateTime, string, int, int, string>((int)Id, FirstName, LastName, BirthDate, Position, Height, Weight, Nationality);
        }

        public override string ToString()
        {
            return $"{Id} \t {FirstName} \t {LastName} \t {BirthDate} \t {Position} \t {Height} \t {Weight} \t {Nationality}";
        }
    }
}
