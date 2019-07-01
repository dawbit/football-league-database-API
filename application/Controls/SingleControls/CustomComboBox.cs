using application.DAL;
using application.DBdata;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using static application.DBdata.Player;

namespace application.Controls.SingleControls
{
    public partial class CustomComboBox : UserControl
    {
        private readonly DBconnection _connection = DBconnection.Instance;

        public CustomComboBox()
        {
            InitializeComponent();
        }

        public string Type { get; private set; }

        public int GetComboBoxIndex
        {
            get
            {
                if (cbItems.SelectedIndex > 0)
                    return cbItems.SelectedIndex; //na pozycji 1 będzie pusty, co oznacza jakikolwiek klub
                else return 0;
            }
        }

        public string GetComboBoxValue
        {
            get
            {
                if (cbItems.SelectedIndex > 0)
                    return cbItems.GetItemText(this.cbItems.SelectedItem); //na pozycji 1 będzie pusty, co oznacza jakakolwiek pozycja
                else return "";
            }
        }


        public string SetCurrentIndex
        {
            set
            {
                cbItems.SelectedIndex = cbItems.FindStringExact(value);
            }
        }

        public void Clubs()
        {
            labelText.Text = "Club";
            Type = "Club";
            string query = "select clubs.name from clubs order by clubs.id";
            if (_connection.OpenConnection())
            {
                cbItems.Items.Add("");

                using (var cmd = new MySqlCommand(query, DBconnection.Instance.Connection))
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        cbItems.Items.Add(dataReader["name"].ToString());
                    }
                }

                _connection.CloseConnection();
            }
            else
            {
                return;
            }
        }

        public void Position()
        {
            labelText.Text = "Position";
            Type = "Position";
            cbItems.Items.Add("");
            for (int i = 0; i < Enum.GetNames(typeof(Position)).Length; i++)
            {
                cbItems.Items.Add(Enum.GetValues(typeof(Position)).GetValue(i));
            }
        }
    }
}
