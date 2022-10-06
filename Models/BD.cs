using TP_Final.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

namespace TPN07.Models;

public class BD{

private static string _connectionString = @"Server=A-PHZ2-CIDI-013;DataBase=AlmacenVideoJuegos;Trusted_Connection=True";

public static List<Videojuego> ObtenerPreguntas(string nombre){
    List<Videojuego> lista = new List<Videojuego>();
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        string sql = "SELECT * FROM Videojuego WHERE Nombre = %@vNombre%";
        lista = db.Query<Videojuego>(sql, new{vNombre = nombre}).ToList();
    }
    return lista;
}

}