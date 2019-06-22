using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace application.DBdata
{
    class Crest
    {
        public int? Id { get; set; } // zabezpieczenie przed nullem
        public byte[] Image { get; set; }
        public int? ClubCrest { get; set; }


        public Crest() { }

        public Crest(IDataReader dataReader)
        {
            // dataReader.Read()
            Id = (int)dataReader["id"];
            Image = (byte[])dataReader["name"];
            ClubCrest = (int)dataReader["club"];

            //byteArrayToImage(dr.GetSqlBytes(dr.GetOrdinal("img")).Buffer);
        }

        public Tuple<int, byte[], int> GetInfo()
        {
            return new Tuple<int, byte[], int>((int)Id, Image, (int)ClubCrest);
        }
    }
}
