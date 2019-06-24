using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using application.DAL;
using System.Windows.Forms;
using application.Controls.SelectPanel;
using application.DBdata;
using System.Data;

namespace application
{
    class Model
    {
        private readonly DBconnection _connection = DBconnection.Instance;

        public Player GetPlayer(int id)
        {
            if (_connection.OpenConnection())
            {
                Dictionary<string, int> par = new Dictionary<string, int>()
                {
                    { "@id", id }
                };

                Player result = _connection.GetPlayer($"select players.id, lastname, players.name pname, dateofbirth, " +
                    $"position, height, weight, nationality, clubs.name cname from players, clubs where players.club = clubs.id and players.id=@id", par);
                _connection.CloseConnection();
                return result;
            }
            else
            {
                return new Player();
            }
        }

        public List<Player> GetPlayers()
        {
            if (_connection.OpenConnection())
            {
                List<Player> queryResult = _connection.GetPlayers($"select players.id, lastname, players.name pname, dateofbirth, " +
                    $"position, height, weight, nationality, clubs.name cname from players, clubs where players.club = clubs.id");

                _connection.CloseConnection();

                return queryResult;
            }
            else
            {
                return new List<Player>();
            }
        }
    }
}
