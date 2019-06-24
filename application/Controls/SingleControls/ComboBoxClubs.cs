using application.DAL;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace application.Controls.SingleControls
{
    public partial class ComboBoxClubs : UserControl
    {
        private readonly DBconnection _connection = DBconnection.Instance;

        public ComboBoxClubs()
        {
            InitializeComponent();
            Clubs();
        }

        public int GetClubIndex
        {
            get
            {
                if (cbClubs.SelectedIndex > 0)
                    return cbClubs.SelectedIndex; //na pozycji 1 będzie pusty, co oznacza jakikolwiek klub
                else return 0;
            }
        }

        private void Clubs()
        {
            string query = "select clubs.name from clubs order by clubs.id";
            if (_connection.OpenConnection())
            {
                cbClubs.Items.Add("");

                using (var cmd = new MySqlCommand(query, DBconnection.Instance.Connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        cbClubs.Items.Add(dataReader["name"].ToString());
                    }
                }

                _connection.CloseConnection();
            }
            else
            {
                return;
            }
        }
    }
}
