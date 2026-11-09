using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;
using Veterinaria.Negocios;

namespace Veterinaria.Web.Pages.Clientes;

public class DetalleModel : PageModel
{
    public Cliente Cliente { get; private set; } = new();

    public List<Mascota> Mascotas { get; private set; } = new();

    public string? Error { get; private set; }

    public IActionResult OnGet(int id)
    {
        if (id <= 0)
            return NotFound();

        try
        {
            ClienteNegocio clienteNegocio = new();

            Cliente? cliente =
                clienteNegocio.BuscarPorId(id);

            if (cliente is null)
                return NotFound();

            Cliente = cliente;

            MascotaNegocio mascotaNegocio = new();

            Mascotas =
                mascotaNegocio.ListarPorCliente(id);

            return Page();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            Error =
                "No fue posible consultar el detalle del cliente.";

            return Page();
        }
    }
}