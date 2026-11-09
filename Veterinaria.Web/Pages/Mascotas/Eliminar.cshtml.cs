using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;
using Veterinaria.Negocios;

namespace Veterinaria.Web.Pages.Mascotas;

public class EliminarModel : PageModel
{
    public Mascota Mascota { get; private set; } = new();

    public Cliente Propietario { get; private set; } = new();

    public string? Error { get; private set; }

    public IActionResult OnGet(int id)
    {
        try
        {
            return Cargar(id);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            Error =
                "No fue posible consultar la mascota.";

            return Page();
        }
    }

    public IActionResult OnPost(int id)
    {
        IActionResult resultado =
            Cargar(id);

        if (resultado is NotFoundResult)
            return resultado;

        try
        {
            MascotaNegocio negocio = new();

            bool eliminada =
                negocio.Eliminar(id);

            if (!eliminada)
                return NotFound();

            TempData["Mensaje"] =
                "Mascota eliminada correctamente.";

            return RedirectToPage("./Index");
        }
        catch (ReglaNegocioException ex)
        {
            Error = ex.Message;

            return Page();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            Error =
                "No fue posible eliminar la mascota.";

            return Page();
        }
    }

    private IActionResult Cargar(int id)
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
}