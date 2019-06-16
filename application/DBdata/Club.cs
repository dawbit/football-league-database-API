using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DBdata
{
    class Club
    {
        public int? Id { get; set; } // zabezpieczenie przed nullem
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public User() { }

        public User(IDataReader dataReader)
        {
            // dataReader.Read()
            Id = (int)dataReader["id_u"];
            FirstName = (string)dataReader["fname"];
            LastName = (string)dataReader["lname"];
            BirthDate = (DateTime)dataReader["bdate"];
        }

        public override string ToString()
        {
            // return string.Format("ID: {0}, First name: {1}, Last name: {2}, Birth Date: {3}.", Id, FirstName, LastName, BirthDate);
            return $"{Id} {FirstName} {LastName} {BirthDate.Date.Year}";
        }
    }
}
