using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;

namespace Veterinaria.Web.Pages.Clientes;

public class NuevoModel : PageModel
{
    [BindProperty]
    public Cliente Cliente { get; set; } = new();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        // PRÁCTICA 6:
        // ClienteNegocio negocio = new();
        // negocio.Agregar(Cliente);

        TempData["Mensaje"] =
            "Formulario validado. La persistencia se conectará en la Práctica 6.";

        return RedirectToPage("./Index");
    }
}