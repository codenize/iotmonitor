using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite.Internal;

namespace IoTMonitor.Services
{
    class DataManager
    {
        private void BuildDatabase()
        {
            SqliteEngine.UseWinSqlite3(); //Configuring library to use SDK version of SQLite
            using (SqliteConnection db = new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY AUTOINCREMENT, Text_Entry NVARCHAR(2048) NULL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                try
                {
                    createTable.ExecuteReader();

                    AddData();
                }
                catch (SqliteException e)
                {
                    //Do nothing
                }
            }
        }
        private void AddData()
        {
            //"C:\\Users\\adavi\\AppData\\Local\\Packages\\A3D19B1F-DED5-48E7-AAF3-CCE415D2C4E5_pq2t9pa7etqaa\\LocalState\\sqliteSample.db"
            //		ConnectionString	"Filename=sqliteSample.db"	string

            using (SqliteConnection db = new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                //Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Entry);";
                insertCommand.Parameters.AddWithValue("@Entry", "hello world");

                try
                {
                    insertCommand.ExecuteReader();
                }
                catch (SqliteException error)
                {
                    //Handle error
                    return;
                }
                db.Close();
            }
        }
    }
}
