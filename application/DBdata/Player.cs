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
        public int Id { get; set; } // zabezpieczenie przed nullem
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
    }
}
