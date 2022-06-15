using System;
using System.Collections.Generic;
using MySqlConnector;

namespace BuchDatenbank
{
    public class BuchRepository : IBuchRepository
    {
        private string _connectionString;

        public BuchRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public List<BuchDTO> HoleAlleBuecher()
        {
            using var datenbankVerbindung = new MySqlConnection(_connectionString);
            datenbankVerbindung.Open();

            const string query = "SELECT id, buch_name, autor FROM aktuelle_buecher";
            using var kommando = new MySqlCommand(query, datenbankVerbindung);
            var reader = kommando.ExecuteReader();

            List<BuchDTO> buecher = new List<BuchDTO>();
            while (reader.Read())
            {
                var buch = new BuchDTO();
                buch.Id = reader.GetInt32(0);
                buch.titel = reader.GetString(1);
                buch.autor = reader.GetString(2);

                buecher.Add(buch);
            }

            return buecher;
        }

        public void FuegeBuecherEin(string titel, string autor)
        {
            using var datenbankVerbinung = new MySqlConnection(_connectionString);
            datenbankVerbinung.Open();

            const string query = "INSERT INTO aktuelle_buecher (buch_name, autor) " +
                "VALUES (@buch_name, @autor);";
            using var kommando = new MySqlCommand(query, datenbankVerbinung);
            kommando.Parameters.AddWithValue("@buch_name", titel);
            kommando.Parameters.AddWithValue("@autor", autor);
            kommando.ExecuteNonQuery();
        }

        
        public void AktualisiereBuecher(int id, string titel, string autor)
        {
            using var datenbankVerbinung = new MySqlConnection(_connectionString);
            datenbankVerbinung.Open();

            const string query = "UPDATE aktuelle_buecher SET buch_name = @buch_name, autor = @autor WHERE id = @id;";
            using var kommando = new MySqlCommand(query, datenbankVerbinung);
            kommando.Parameters.AddWithValue("@id", id);
            kommando.Parameters.AddWithValue("@buch_name", titel);
            kommando.Parameters.AddWithValue("@buch_name", titel);
            kommando.ExecuteNonQuery();
        }
       
    }
}
