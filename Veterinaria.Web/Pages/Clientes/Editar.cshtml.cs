using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;
using Veterinaria.Negocios;

namespace Veterinaria.Web.Pages.Clientes;

public class EditarModel : PageModel
{
    [BindProperty]
    public Cliente Cliente { get; set; } = new();

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
                "No fue posible consultar el cliente. " +
                "Verifique la conexión con MySQL.";

            return Page();
        }
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        try
        {
            ClienteNegocio negocio = new();

            bool modificado =
                negocio.Modificar(Cliente);

            if (!modificado)
                return NotFound();

            TempData["Mensaje"] =
                "Cliente modificado correctamente.";

            return RedirectToPage("./Index");
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(
                string.Empty,
                ex.Message);

            return Page();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            ModelState.AddModelError(
                string.Empty,
                "No fue posible modificar el cliente.");

            return Page();
        }
    }
}