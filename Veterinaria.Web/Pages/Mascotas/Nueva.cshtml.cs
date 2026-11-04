using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Veterinaria.Entidades;

namespace Veterinaria.Web.Pages.Mascotas;

public class NuevaModel : PageModel
{
    [BindProperty]
    public Mascota Mascota { get; set; } = new();

    public List<SelectListItem> Clientes { get; private set; } = new();

    public void OnGet()
    {
        CargarClientes();
    }

    public IActionResult OnPost()
    {
        CargarClientes();

        if (!ModelState.IsValid)
            return Page();

        // PRÁCTICA 6:
        // new MascotaNegocio().Agregar(Mascota);

        TempData["Mensaje"] =
            "Formulario de mascota validado correctamente.";

        return RedirectToPage("./Index");
    }

    private void CargarClientes()
    {
        Clientes = new List<SelectListItem>
        {
            new("Ana López", "1"),
            new("Carlos Ramírez", "2")
        };
    }
}