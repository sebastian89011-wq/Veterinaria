using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;

namespace Veterinaria.Web.Pages.Clientes;

public class IndexModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? Buscar { get; set; }

    public List<Cliente> Clientes { get; private set; } = new();

    public void OnGet()
    {
        Clientes = new List<Cliente>
        {
            new()
            {
                IdCliente = 1,
                Nombre = "Ana",
                ApellidoPaterno = "López",
                ApellidoMaterno = "García",
                Telefono = "6461234567",
                Correo = "ana@correo.com",
                Direccion = "Ensenada"
            },
            new()
            {
                IdCliente = 2,
                Nombre = "Carlos",
                ApellidoPaterno = "Ramírez",
                ApellidoMaterno = "Torres",
                Telefono = "6467654321",
                Correo = "carlos@correo.com",
                Direccion = "Ensenada"
            }
        };

        if (!string.IsNullOrWhiteSpace(Buscar))
        {
            string texto = Buscar.Trim();

            Clientes = Clientes
                .Where(c =>
                    c.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    c.ApellidoPaterno.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    (c.Correo?.Contains(texto, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    c.Telefono.Contains(texto, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}