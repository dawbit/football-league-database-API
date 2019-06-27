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
            Id = int.Parse(dataReader["id"].ToString());
            Image = (byte[])dataReader["name"];
            ClubCrest = int.Parse(dataReader["club"].ToString());

            //byteArrayToImage(dr.GetSqlBytes(dr.GetOrdinal("img")).Buffer);
        }

    }
}
