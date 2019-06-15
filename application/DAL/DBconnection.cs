﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace application.DAL
{
    class DBconnection
    {
        private static DBconnection _singleton = null;

        private readonly string _login;
        private readonly string _password;

        public MySqlConnection Connection { get; private set; }

        private DBconnection(string login, string password)
        {
            this._login = login;
            this._password = password;

            MySqlConnectionStringBuilder connStrBuilder = new MySqlConnectionStringBuilder();
            connStrBuilder.Port = uint.Parse(DBinfo.port);
            connStrBuilder.UserID = _login;
            connStrBuilder.Password = _password;
            connStrBuilder.Server = DBinfo.server;
            connStrBuilder.Database = DBinfo.database;

            Connection = new MySqlConnection(connStrBuilder.ToString());
        }

        public static DBconnection Instance()
        {
            return _singleton;
        }

        public static DBconnection Init(string login, string password)
        {
            if (_singleton != null)
            {
                return _singleton;
            }

            _singleton = new DBconnection(login, password);
            return _singleton;
        }
    }
}
