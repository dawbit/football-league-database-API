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


        public Crest() { }

        public Crest(IDataReader dataReader)
        {
            // dataReader.Read()
            Id = (int)dataReader["id"];
            Image = (byte[])dataReader["name"];

            //byteArrayToImage(dr.GetSqlBytes(dr.GetOrdinal("img")).Buffer);
        }

        public Tuple<int, byte[]> GetCrest()
        {
            return new Tuple<int, byte[]>((int)Id, Image);
        }
    }
}
