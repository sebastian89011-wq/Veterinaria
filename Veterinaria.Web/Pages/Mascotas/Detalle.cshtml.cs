using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;
using Veterinaria.Negocios;

namespace Veterinaria.Web.Pages.Mascotas;

public class DetalleModel : PageModel
{
    public Mascota Mascota { get; private set; } = new();

    public Cliente Propietario { get; private set; } = new();

    public string? Error { get; private set; }

    public IActionResult OnGet(int id)
    {
        try
        {
            MascotaNegocio mascotaNegocio = new();

            Mascota? mascota =
                mascotaNegocio.BuscarPorId(id);

            if (mascota is null)
                return NotFound();

            Mascota = mascota;

            ClienteNegocio clienteNegocio = new();

            Cliente? propietario =
                clienteNegocio.BuscarPorId(
                    mascota.IdCliente);

            if (propietario is null)
                return NotFound();

            Propietario = propietario;

            return Page();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            Error =
                "No fue posible consultar el detalle de la mascota.";

            return Page();
        }
    }
}