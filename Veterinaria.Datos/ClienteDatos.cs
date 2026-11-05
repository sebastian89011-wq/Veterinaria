using MySql.Data.MySqlClient;
using Veterinaria.Entidades;

namespace Veterinaria.Datos;

public class ClienteDatos
{
    public List<Cliente> Listar()
    {
        List<Cliente> lista = new();

        using MySqlConnection cn = Conexion.Crear();
        cn.Open();

        const string sql = """
            SELECT id_cliente, nombre, apellido_paterno,
                   apellido_materno, telefono, correo,
                   direccion, fecha_registro
            FROM cliente
            ORDER BY apellido_paterno, nombre;
            """;

        using MySqlCommand cmd = new(sql, cn);
        using MySqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            lista.Add(Mapear(dr));
        }

        return lista;
    }

    public Cliente? BuscarPorId(int idCliente)
    {
        using MySqlConnection cn = Conexion.Crear();
        cn.Open();

        const string sql = """
            SELECT id_cliente, nombre, apellido_paterno,
                   apellido_materno, telefono, correo,
                   direccion, fecha_registro
            FROM cliente
            WHERE id_cliente = @idCliente;
            """;

        using MySqlCommand cmd = new(sql, cn);
        cmd.Parameters.AddWithValue("@idCliente", idCliente);

        using MySqlDataReader dr = cmd.ExecuteReader();

        return dr.Read() ? Mapear(dr) : null;
    }

    public List<Cliente> Buscar(string texto)
    {
        List<Cliente> lista = new();

        using MySqlConnection cn = Conexion.Crear();
        cn.Open();

        const string sql = """
            SELECT id_cliente, nombre, apellido_paterno,
                   apellido_materno, telefono, correo,
                   direccion, fecha_registro
            FROM cliente
            WHERE nombre LIKE @texto
               OR apellido_paterno LIKE @texto
               OR apellido_materno LIKE @texto
               OR telefono LIKE @texto
               OR correo LIKE @texto
            ORDER BY apellido_paterno, nombre;
            """;

        using MySqlCommand cmd = new(sql, cn);
        cmd.Parameters.AddWithValue("@texto", $"%{texto}%");

        using MySqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            lista.Add(Mapear(dr));
        }

        return lista;
    }

    public int Agregar(Cliente cliente)
    {
        using MySqlConnection cn = Conexion.Crear();
        cn.Open();

        const string sql = """
            INSERT INTO cliente
            (nombre, apellido_paterno, apellido_materno,
             telefono, correo, direccion)
            VALUES
            (@nombre, @apellidoPaterno, @apellidoMaterno,
             @telefono, @correo, @direccion);
            """;

        using MySqlCommand cmd = new(sql, cn);

        AgregarParametros(cmd, cliente);
        cmd.ExecuteNonQuery();

        return Convert.ToInt32(cmd.LastInsertedId);
    }

    public bool Modificar(Cliente cliente)
    {
        using MySqlConnection cn = Conexion.Crear();
        cn.Open();

        const string sql = """
            UPDATE cliente
            SET nombre = @nombre,
                apellido_paterno = @apellidoPaterno,
                apellido_materno = @apellidoMaterno,
                telefono = @telefono,
                correo = @correo,
                direccion = @direccion
            WHERE id_cliente = @idCliente;
            """;

        using MySqlCommand cmd = new(sql, cn);

        AgregarParametros(cmd, cliente);
        cmd.Parameters.AddWithValue("@idCliente", cliente.IdCliente);

        return cmd.ExecuteNonQuery() > 0;
    }

    private static void AgregarParametros(
        MySqlCommand cmd,
        Cliente cliente)
    {
        cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
        cmd.Parameters.AddWithValue(
            "@apellidoPaterno", cliente.ApellidoPaterno);

        cmd.Parameters.AddWithValue(
            "@apellidoMaterno",
            (object?)cliente.ApellidoMaterno ?? DBNull.Value);

        cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);

        cmd.Parameters.AddWithValue(
            "@correo",
            (object?)cliente.Correo ?? DBNull.Value);

        cmd.Parameters.AddWithValue(
            "@direccion",
            (object?)cliente.Direccion ?? DBNull.Value);
    }

    private static Cliente Mapear(MySqlDataReader dr)
    {
        return new Cliente
        {
            IdCliente = Convert.ToInt32(dr["id_cliente"]),
            Nombre = Convert.ToString(dr["nombre"]) ?? "",
            ApellidoPaterno =
                Convert.ToString(dr["apellido_paterno"]) ?? "",
            ApellidoMaterno =
                dr["apellido_materno"] == DBNull.Value
                    ? null
                    : Convert.ToString(dr["apellido_materno"]),
            Telefono = Convert.ToString(dr["telefono"]) ?? "",
            Correo =
                dr["correo"] == DBNull.Value
                    ? null
                    : Convert.ToString(dr["correo"]),
            Direccion =
                dr["direccion"] == DBNull.Value
                    ? null
                    : Convert.ToString(dr["direccion"]),
            FechaRegistro =
                Convert.ToDateTime(dr["fecha_registro"])
        };
    }
}