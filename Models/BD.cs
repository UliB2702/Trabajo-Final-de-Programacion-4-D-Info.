using TP_Final.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

namespace TP_Final.Models;

public class BD{

private static string _connectionString = @"Server=A-PHZ2-AMI-004;DataBase=AlmacenVideoJuegos;Trusted_Connection=True";

public static List<Videojuego> BuscarVideojuegosSegunNombre(string nombre){
    List<Videojuego> lista = new List<Videojuego>();
    using(SqlConnection db = new SqlConnection(_connectionString)){  
        string sql = "SELECT * FROM Videojuego WHERE Nombre LIKE '%' + @vNombre + '%'";
        lista = db.Query<Videojuego>(sql, new{vNombre = nombre}).ToList();
    }
    return lista;
}

public static List<Videojuego> BuscarVideojuegosSegunClasificacion(string nombre){
    List<Videojuego> lista = new List<Videojuego>();
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        string sql = "SELECT * FROM Videojuego v Inner Join Clasificacion c ON v.IdClasificacion = c.IdClasificacion WHERE c.Nombre = %@vNombre%";
        lista = db.Query<Videojuego>(sql, new{vNombre = nombre}).ToList();
    }
    return lista;
}

public static List<Empresa> BuscarEmpresasSegunNombre(string nombre){
    List<Empresa> lista = new List<Empresa>();
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        string sql = "SELECT * FROM Empresa WHERE Nombre LIKE '%' + @vNombre + '%'";
        lista = db.Query<Empresa>(sql, new{vNombre = nombre}).ToList();
    }
    return lista;
}
public static List<Empresa> BuscarEmpresas(){
    List<Empresa> lista = new List<Empresa>();
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        string sql = "SELECT * FROM Empresa";
        lista = db.Query<Empresa>(sql).ToList();
    }
    return lista;
}

public static void InsertarEmpresa(string Nombre, string SedeCentral, string Fundador, DateTime fechaFundacion, string Logo)
{
    string sql = "INSERT INTO Empresa VALUES (@vNombre, @vSedeCentral, @vFundador, @vfechaFundacion, @vLogo)";
    using(SqlConnection db = new SqlConnection(_connectionString)){
        db.Execute(sql, new { vNombre=Nombre ,vSedeCentral = SedeCentral, vFundador = Fundador, vfechaFundacion = fechaFundacion, vLogo = Logo});
    }
}
public static Empresa BuscarEmpresasSegunID(int id){
    Empresa empresa = new Empresa();
    string sql = "SELECT * FROM Empresa WHERE IdEmpresa = @eid";
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        empresa = db.QueryFirstOrDefault<Empresa>(sql, new{eid = id});
    }
    return empresa;
}

public static Videojuego BuscarVideojuegoSegunID(int id){
    Videojuego videojuego = new Videojuego();
    string sql = "SELECT * FROM Videojuego WHERE IdVideojuego = @vid";
    using(SqlConnection db = new SqlConnection(_connectionString)){   
        videojuego = db.QueryFirstOrDefault<Videojuego>(sql, new{vid = id});
    }
    return videojuego;
}

public static void EliminarVideojuego (int id)
{
    string sql = "DELETE FROM Videojuego WHERE IdVideojuego = @vid";
     using(SqlConnection db = new SqlConnection(_connectionString)){
        db.Execute(sql, new {vid = id});
    }

}

}