using Veterinaria.Datos;
using Veterinaria.Entidades;

namespace Veterinaria.Negocios;

public class MascotaNegocio
{
    private readonly MascotaDatos _datos = new();

    public List<Mascota> Listar()
        => _datos.Listar();

    public List<Mascota> ListarPorCliente(int idCliente)
    {
        if (idCliente <= 0)
            throw new ArgumentException("Cliente no válido.");

        return _datos.ListarPorCliente(idCliente);
    }

    public Mascota? BuscarPorId(int idMascota)
        => _datos.BuscarPorId(idMascota);

    public int Agregar(Mascota mascota)
    {
        Validar(mascota);
        return _datos.Agregar(mascota);
    }

    public bool Modificar(Mascota mascota)
    {
        if (mascota.IdMascota <= 0)
            throw new ArgumentException("Mascota no válida.");

        Validar(mascota);
        return _datos.Modificar(mascota);
    }

    private static void Validar(Mascota mascota)
    {
        if (mascota.IdCliente <= 0)
            throw new ArgumentException(
                "Debe seleccionar un propietario.");

        if (string.IsNullOrWhiteSpace(mascota.Nombre))
            throw new ArgumentException(
                "El nombre de la mascota es obligatorio.");

        if (string.IsNullOrWhiteSpace(mascota.Especie))
            throw new ArgumentException(
                "La especie es obligatoria.");
    }
}