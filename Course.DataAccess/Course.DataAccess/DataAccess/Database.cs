using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course.DataAccess.DataAccess
{
    public class Database
    {

        static SQLiteConnection connection;
        public static SQLiteConnection Instance
        {
            get
            {
                return connection ??
                    (connection = createConnection());
            }
        }

        private static SQLiteConnection createConnection()
        {
            var a = App.DATA_DIR;

            var dbPath = System.IO.Path.Combine(a, "database.db3");

            // var b = File.ReadAllText(dbPAth);

            SQLiteConnection conn = new SQLiteConnection(dbPath);
            conn.CreateTable<DbItem>();

            return conn;
        }
    }
}
