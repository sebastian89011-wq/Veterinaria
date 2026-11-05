using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;

namespace Veterinaria.Web.Pages.Clientes;

public class EditarModel : PageModel
{
    [BindProperty]
    public Cliente Cliente { get; set; } = new();

    public IActionResult OnGet(int id)
    {
        // Datos temporales para comprobar la interfaz.
        Cliente = id switch
        {
            1 => new Cliente
            {
                IdCliente = 1,
                Nombre = "Ana",
                ApellidoPaterno = "López",
                ApellidoMaterno = "García",
                Telefono = "6461234567",
                Correo = "ana@correo.com",
                Direccion = "Ensenada"
            },
            2 => new Cliente
            {
                IdCliente = 2,
                Nombre = "Carlos",
                ApellidoPaterno = "Ramírez",
                ApellidoMaterno = "Torres",
                Telefono = "6467654321",
                Correo = "carlos@correo.com",
                Direccion = "Ensenada"
            },
            _ => new Cliente()
        };

        if (Cliente.IdCliente == 0)
            return NotFound();

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        // PRÁCTICA 6:
        // new ClienteNegocio().Modificar(Cliente);

        TempData["Mensaje"] = "Cambios validados correctamente.";
        return RedirectToPage("./Index");
    }
}