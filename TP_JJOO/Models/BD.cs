using System.Data.SqlClient;
using Dapper;
namespace TP_JJOO.Models;

public static class BD
{
    private static string _ConnectionString = "Server=localhost;DataBase=JJOO;Trusted_Connection=true;";

    public static void AgregarDeportista(Deportista dep)
    {
        using(SqlConnection conn = new SqlConnection(_ConnectionString)){
            string sql="INSERT INTO Deportistas (Nombre, Apellido, Fechanacimiento, Foto, IdPais, IdDeporte) VALUES (@pNombre, @pApellido, @pFechanacimiento, @pFoto, @pIdPais, @pIdDeporte)";
            conn.Execute(sql, new{pNombre = dep.Nombre, pApellido = dep.Apellido, pFechaNacimiento = dep.FechaNacimiento, pFoto = dep.Foto, pIdPais = dep.IdPais, pIdDeporte = dep.IdDeporte});
        }
    }
    public static void EliminarDeportista(int idDeportista)
    {
        using(SqlConnection conn = new SqlConnection(_ConnectionString)){
            string sql="DELETE FROM Deportistas WHERE IdDeportista = @id";
            conn.Execute(sql, new{id = idDeportista});
        }
    }
    public static Deporte VerInfoDeporte(int idDeporte)
    {
        Deporte MiDeporte = null;
        using(SqlConnection conn = new SqlConnection(_ConnectionString)){
            string sql="SELECT FROM Deportes WHERE IdDeporte = @id";
            MiDeporte = conn.QueryFirstOrDefault<Deporte>(sql, new{id = idDeporte});
        }
        return MiDeporte;
    }
    public static Pais VerInfoPais(int idPais)
    {
        Pais MiPais = null;
        using(SqlConnection conn = new SqlConnection(_ConnectionString)){
            string sql="SELECT FROM Paises WHERE IdPais = @id";
            MiPais = conn.QueryFirstOrDefault<Pais>(sql, new{id = idPais});
        }
        return MiPais;
    }
    public static Deportista VerInfoDeportista(int idDeportista)
    {
        Deportista MiDeportista = null;
        using(SqlConnection conn = new SqlConnection(_ConnectionString)){
            string sql="SELECT FROM Deportistas WHERE IdDeportista = @id";
            MiDeportista = conn.QueryFirstOrDefault<Deportista>(sql, new{id = idDeportista});
        }
        return MiDeportista;
    }
    public static List<Pais> ListarPaises()
    {
        List<Pais> ListaPaises = new List<Pais>();
        using(SqlConnection conn = new SqlConnection(_ConnectionString)){
            string sql="SELECT * FROM Paises";
            ListaPaises = conn.Query<Pais>(sql).ToList();
        }
        return ListaPaises;
    }
    public static List<Deportista> ListarDeportistas(int idDeporte)
    {
        List<Deportista> ListaDeportistas = new List<Deportista>();
        using(SqlConnection conn = new SqlConnection(_ConnectionString)){
            string sql="SELECT FROM Deportistas WHERE IdDeporte = @id";
            ListaDeportistas = conn.Query<Deportista>(sql, new{id = idDeporte}).ToList();
        }
        return ListaDeportistas;
    }
    public static List<Deportista> ListarDeportistas2(int idPais)
    {
        List<Deportista> ListaDeportistas = new List<Deportista>();
        using(SqlConnection conn = new SqlConnection(_ConnectionString)){
            string sql="SELECT FROM Deportistas WHERE IdPais = @id";
            ListaDeportistas = conn.Query<Deportista>(sql, new{id = idPais}).ToList();
        }
        return ListaDeportistas;
    }
}
