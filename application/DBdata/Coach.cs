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
        public string ClubCoach { get; set; }


        public Coach() { }

        public Coach(int Id, string FirstName, string LastName, DateTime BirthDate, string Nationality, string ClubCoach)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDate = BirthDate.Date;
            this.Nationality = Nationality;
            this.ClubCoach = ClubCoach;
        }

        public override string ToString()
        {
            return $"{Id} {FirstName}\t{LastName}\t{BirthDate.ToString("dd-MM-yyyy")}\t{Nationality}\t{ClubCoach}";
        }
    }
}
