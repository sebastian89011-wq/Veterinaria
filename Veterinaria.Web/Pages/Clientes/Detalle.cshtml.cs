using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;

namespace Veterinaria.Web.Pages.Clientes;

public class DetalleModel : PageModel
{
    public Cliente Cliente { get; private set; } = new();

    public IActionResult OnGet(int id)
    {
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

        return Cliente.IdCliente == 0 ? NotFound() : Page();
    }
}