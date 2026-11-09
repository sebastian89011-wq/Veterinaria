using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;
using Veterinaria.Negocios;

namespace Veterinaria.Web.Pages.Mascotas;

public class IndexModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int? IdCliente { get; set; }

    public List<MascotaFila> Mascotas { get; private set; } = new();

    public string? Error { get; private set; }

    public void OnGet()
    {
        try
        {
            MascotaNegocio mascotaNegocio = new();
            ClienteNegocio clienteNegocio = new();

            List<Mascota> mascotas =
                IdCliente.HasValue
                    ? mascotaNegocio.ListarPorCliente(IdCliente.Value)
                    : mascotaNegocio.Listar();

            Dictionary<int, Cliente> clientes =
                clienteNegocio
                    .Listar()
                    // IdCliente es PK; no existen duplicados.
                    .ToDictionary(c => c.IdCliente);

            Mascotas = mascotas
                .Select(m => new MascotaFila
                {
                    Mascota = m,
                    Propietario =
                        clientes.TryGetValue(
                            m.IdCliente,
                            out Cliente? cliente)
                        ? $"{cliente.Nombre} " +
                          $"{cliente.ApellidoPaterno}"
                        : "No disponible"
                })
                .ToList();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            Error =
                "No fue posible consultar las mascotas.";
        }
    }

    public class MascotaFila
    {
        public Mascota Mascota { get; set; } = new();

        public string Propietario { get; set; } =
            string.Empty;
    }
}