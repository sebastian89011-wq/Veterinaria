using Veterinaria.Datos;
using Veterinaria.Entidades;

namespace Veterinaria.Negocios;

public class ClienteNegocio
{
    private readonly ClienteDatos _datos = new();

    public List<Cliente> Listar()
        => _datos.Listar();

    public List<Cliente> Buscar(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return _datos.Listar();

        return _datos.Buscar(texto.Trim());
    }

    public Cliente? BuscarPorId(int idCliente)
        => _datos.BuscarPorId(idCliente);

    public int Agregar(Cliente cliente)
    {
        Validar(cliente);
        return _datos.Agregar(cliente);
    }

    public bool Modificar(Cliente cliente)
    {
        if (cliente.IdCliente <= 0)
            throw new ArgumentException("Cliente no válido.");

        Validar(cliente);
        return _datos.Modificar(cliente);
    }

    private static void Validar(Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nombre))
            throw new ArgumentException("El nombre es obligatorio.");

        if (string.IsNullOrWhiteSpace(cliente.ApellidoPaterno))
            throw new ArgumentException(
                "El apellido paterno es obligatorio.");

        if (string.IsNullOrWhiteSpace(cliente.Telefono))
            throw new ArgumentException("El teléfono es obligatorio.");
    }
}