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
        public string ClubPlayer { get; set; }

        public Player() { }

        public Player(int Id, string FirstName, string LastName, DateTime BirthDate, string Position, int Height, int Weight, string Nationality, string ClubPlayer)

        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate.Date;
            this.Position = Position;
            this.Height = Height;
            this.Weight = Weight;
            this.Nationality = Nationality;
            this.ClubPlayer = ClubPlayer;

        }

        public Tuple<int, string, string, DateTime, string, int, int, string> GetInfo()
        {
            return new Tuple<int, string, string, DateTime, string, int, int, string>((int)Id, FirstName, LastName, BirthDate.Date, Position, Height, Weight, Nationality);
        }

        public override string ToString()
        {
            return $"{Id} {FirstName}\t{LastName}\t{BirthDate.ToString("dd-MM-yyyy")}\t{Position}\t{Height}\t{Weight}\t{Nationality}\t{ClubPlayer}";
        }
    }
}
