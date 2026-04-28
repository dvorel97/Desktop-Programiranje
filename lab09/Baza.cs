using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp {
    class Baza {
        //    public static string KonekcijskiString() {
        //        return string.Format(
        //            "Data Source = {0}; Initial Catalog = {1}; User ID = {2}; Password = {3}",
        //            server,
        //            baza,
        //            korisnickoIme,
        //            lozinka
        //        );
        //    }

        //    private const string server = "sql.vub.zone,14330";
        //    private const string baza = "dvorel";
        //    private const string korisnickoIme = "sa";
        //    private const string lozinka = "yFxr3yPRxhc7iOvS8K6ZP2XkBEiP";
        //}

        public static string KonekcijskiString()
        {
            // čitamo iz environment varijabli – sigurno!
            string server = Environment.GetEnvironmentVariable("DB_SERVER")
                               ?? @".\SQLEXPRESS";   // fallback
            string database = Environment.GetEnvironmentVariable("DB_DATABASE")
                               ?? "dvorel";
            string user = Environment.GetEnvironmentVariable("DB_USER")
                               ?? "sa";
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD")
                               ?? "";

            return $"Data Source={server}; Initial Catalog={database}; "
                 + $"User ID={user}; Password={password}";
        }
    }

}
