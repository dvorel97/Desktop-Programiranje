using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NotesApp {
    class Notes {
        public static List<Note> GetNotes() {
            List<Note> notes = new List<Note>();
            string query = "SELECT * FROM Notes ORDER BY Name";

            using (SqlConnection sqlConnection = new SqlConnection(Baza.KonekcijskiString())) {
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                foreach (DataRow redak in ds.Tables[0].Rows) {
                    notes.Add(new Note(
                        redak["Id"],
                        redak["Content"],
                        redak["Name"]
                    ));
                }
            }
            return notes;
        }

        public static bool AddNote(Note note) {
            string query = "INSERT INTO Notes (Content, Name) VALUES (@Content, @Name)";

            using (SqlConnection sqlConnection = new SqlConnection(Baza.KonekcijskiString())) {
                using (SqlCommand command = new SqlCommand(query, sqlConnection)) {
                    command.Parameters.AddWithValue("@Content", note.Content);
                    command.Parameters.AddWithValue("@Name", note.Name);

                    sqlConnection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result < 0) {
                        return false;
                    }
                }
            }
            return true;

        }

        public static Note GetNote(int id)
        {
            string query = "SELECT Id, Content, Name FROM Notes WHERE Id = @Id";

            using (SqlConnection sqlConnection = new SqlConnection(Baza.KonekcijskiString()))
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Id", id);

                sqlConnection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        return new Note(); // ili baci exception

                    return new Note(
                        reader.GetInt32(reader.GetOrdinal("Id")),
                        reader.GetString(reader.GetOrdinal("Content")),
                        reader.GetString(reader.GetOrdinal("Name"))
                    );
                }
            }
        }

        public static bool UpdateNote(Note note, string newContent) {
            string query = "UPDATE Notes SET Name=@name, Content=@content WHERE Id = @Id";

            using (SqlConnection sqlConnection = new SqlConnection(Baza.KonekcijskiString()))
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Id", note.Id);
                command.Parameters.AddWithValue("@name", note.Name);
                command.Parameters.AddWithValue("@content", newContent);

                sqlConnection.Open();
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool DeleteNote(Note note) {
            string query = "DELETE FROM Notes WHERE Id = @Id";

            using (SqlConnection sqlConnection = new SqlConnection(Baza.KonekcijskiString()))
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Id", note.Id);

                sqlConnection.Open();
                int result = command.ExecuteNonQuery();
                if (result < 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
