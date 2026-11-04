using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;

namespace Veterinaria.Web.Pages.Mascotas;

public class DetalleModel : PageModel
{
    public Mascota Mascota { get; private set; } = new();
    public string Propietario { get; private set; } = string.Empty;

    public IActionResult OnGet(int id)
    {
        switch (id)
        {
            case 1:
                Mascota = new Mascota
                {
                    IdMascota = 1,
                    IdCliente = 1,
                    Nombre = "Max",
                    Especie = "Perro",
                    Raza = "Labrador",
                    Sexo = "Macho"
                };
                Propietario = "Ana López";
                break;

            case 2:
                Mascota = new Mascota
                {
                    IdMascota = 2,
                    IdCliente = 1,
                    Nombre = "Luna",
                    Especie = "Gato",
                    Raza = "Siamés",
                    Sexo = "Hembra"
                };
                Propietario = "Ana López";
                break;

            case 3:
                Mascota = new Mascota
                {
                    IdMascota = 3,
                    IdCliente = 2,
                    Nombre = "Rocky",
                    Especie = "Perro",
                    Raza = "Pastor Alemán",
                    Sexo = "Macho"
                };
                Propietario = "Carlos Ramírez";
                break;
        }

        return Mascota.IdMascota == 0 ? NotFound() : Page();
    }
}