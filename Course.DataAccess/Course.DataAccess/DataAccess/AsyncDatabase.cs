using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course.DataAccess.DataAccess
{
    public class AsyncDatabase
    {

        static SQLiteAsyncConnection connection;
        public static SQLiteAsyncConnection Instance
        {
            get
            {
                return connection ??
                    (connection = createConnection());
            }
        }

        private static SQLiteAsyncConnection createConnection()
        {
            var a = App.DATA_DIR;

            var dbPath = System.IO.Path.Combine(a, "database.db3");

            // var b = File.ReadAllText(dbPAth);

            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<DbItem>().Wait();

            return conn;
        }
    }
}
