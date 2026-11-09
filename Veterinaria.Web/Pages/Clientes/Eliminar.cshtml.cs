using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;
using Veterinaria.Negocios;

namespace Veterinaria.Web.Pages.Clientes;

public class EliminarModel : PageModel
{
    public Cliente Cliente { get; private set; } = new();

    public string? Error { get; private set; }

    public IActionResult OnGet(int id)
    {
        try
        {
            ClienteNegocio negocio = new();

            Cliente? cliente =
                negocio.BuscarPorId(id);

            if (cliente is null)
                return NotFound();

            Cliente = cliente;

            return Page();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            Error =
                "No fue posible consultar el cliente.";

            return Page();
        }
    }

    public IActionResult OnPost(int id)
    {
        ClienteNegocio negocio = new();

        Cliente? cliente =
            negocio.BuscarPorId(id);

        if (cliente is null)
            return NotFound();

        Cliente = cliente;

        try
        {
            bool eliminado =
                negocio.Eliminar(id);

            if (!eliminado)
                return NotFound();

            TempData["Mensaje"] =
                "Cliente eliminado correctamente.";

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
                "No fue posible eliminar el cliente.";

            return Page();
        }
    }
}