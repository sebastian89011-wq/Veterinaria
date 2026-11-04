using MySql.Data.MySqlClient;

namespace Veterinaria.Datos;

public static class Conexion
{
    private static string? _cadenaConexion;

    public static void Configurar(string cadenaConexion)
    {
        _cadenaConexion = cadenaConexion;
    }

    public static MySqlConnection Crear()
    {
        if (string.IsNullOrWhiteSpace(_cadenaConexion))
        {
            throw new InvalidOperationException(
                "La cadena de conexión de Veterinaria no ha sido configurada.");
        }

        return new MySqlConnection(_cadenaConexion);
    }

    public static int Probar()
    {
        using MySqlConnection cn = Crear();
        cn.Open();

        using MySqlCommand cmd =
            new("SELECT COUNT(*) FROM cliente;", cn);

        return Convert.ToInt32(cmd.ExecuteScalar());
    }
}