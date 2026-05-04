using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class DataBase
    {
        private static string connectionString = "User Id=dvorel;Password=koliko99;Data Source=sys.vub.zone:1521/xe;";

        public static void GetNotes(NoteRepository notes)
        {
            string query = "SELECT * FROM Notes";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                conn.Open();

                using (OracleCommand cmd = new OracleCommand(query, conn))
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        notes.Add(new Note(
                            (string)reader["TITLE"],
                            (string)reader["CONTENT"]
                        ));
                    }
                }
            }
        }
    }


}