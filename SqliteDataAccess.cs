using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BL3_Loot_Tracker
{
    public class SqliteDataAccess
    {
        public static List<Runs> LoadRuns()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Runs>("select * from Tracker", new DynamicParameters());

                return output.ToList();
            }
        }

        public static void SaveRuns(Runs run)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Tracker (Date, Boss, Time, Loot) values (@Date, @Boss, @Time, @Loot)", run);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
