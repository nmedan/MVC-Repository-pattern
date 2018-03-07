using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Banka.Repository.Interfaces;
using System.Data.SqlClient;
using System.Data;
using Banka.Models;
using Banka.Repository.Interfaces;
namespace Banka.Repository
{
    public class RacunRepo : IRacunRepo
    {
        private SqlConnection con;
        private void Connection()
        {
            string constr = "Data Source=localhost\\SQLEXPRESS; Database=Banka; Integrated Security = True; MultipleActiveResultSets=True";
            con = new SqlConnection(constr);
        }

        public IEnumerable<Racun> GetAll()
        {
            string query = "SELECT * FROM Racun";
            DataTable dt = new DataTable(); // objekti u 
            DataSet ds = new DataSet();     // koje smestam podatke
            Connection();

            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = query;

                SqlDataAdapter dadapter = new SqlDataAdapter(); // bitan objekat pomocu koga preuzimamo podatke i izvrsavamo upit
                dadapter.SelectCommand = cmd;                   // nakon izvrsenog upita

                // Fill(...) metoda je bitna, jer se prilikom poziva te metode izvrsava upit nad bazom podataka
                dadapter.Fill(ds, "Racun"); // 'ProductCategory' je naziv tabele u dataset-u
                dt = ds.Tables["Racun"];    // formiraj DataTable na osnovu ProductCategory tabele u DataSet-u
                con.Close();                  // zatvori konekciju
            }

            List<Racun> racuni = new List<Racun>();

            foreach (DataRow dataRow in dt.Rows)            // izvuci podatke iz svakog reda tj. zapisa tabele
            {
                int RacunId = int.Parse(dataRow["RacunId"].ToString());    // iz svake kolone datog reda izvuci vrednost
                string NosilacRacuna = dataRow["NosilacRacuna"].ToString();
                string BrojRacuna = dataRow["BrojRacuna"].ToString();
                bool Aktivan = bool.Parse(dataRow["AktivanRacun"].ToString());
                bool Online = bool.Parse(dataRow["OnlineBanking"].ToString());
                racuni.Add(new Racun(RacunId, NosilacRacuna, BrojRacuna, Aktivan, Online) );
            }
            return racuni;
        }

        public void Create(Racun r)
        {
            string query = "INSERT INTO Racun (NosilacRacuna, BrojRacuna, AktivanRacun, OnlineBanking) VALUES ('" + r.NosilacRacuna + ", "+r.BrojRacuna+", "+r.Aktivan+", "+r.Online+"');";
            query += " SELECT SCOPE_IDENTITY()";        // selektuj id novododatog zapisa nakon upisa u bazu
            Connection();
            using (SqlCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = query;    // ovde dodeljujemo upit koji ce se izvrsiti nad bazom podataka
                con.Open();
                var a = cmd.ExecuteScalar();              // izvrsi upit nad bazom, vraca id novododatog zapisa
                con.Close();                                                        // zatvori konekciju
            }
        }

        public void Edit()
        {

        }

        public void Delete()
        {

        }

        public Racun GetById(int id)
        {
            Racun racun = new Racun();
            return racun;
        }
    }
}