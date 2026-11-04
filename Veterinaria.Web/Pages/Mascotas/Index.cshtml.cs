using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;

namespace Veterinaria.Web.Pages.Mascotas;

public class IndexModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int? IdCliente { get; set; }

    public List<MascotaFila> Mascotas { get; private set; } = new();

    public void OnGet()
    {
        Mascotas = new List<MascotaFila>
        {
            new()
            {
                Mascota = new Mascota
                {
                    IdMascota = 1,
                    IdCliente = 1,
                    Nombre = "Max",
                    Especie = "Perro",
                    Raza = "Labrador",
                    Sexo = "Macho"
                },
                Propietario = "Ana López"
            },
            new()
            {
                Mascota = new Mascota
                {
                    IdMascota = 2,
                    IdCliente = 1,
                    Nombre = "Luna",
                    Especie = "Gato",
                    Raza = "Siamés",
                    Sexo = "Hembra"
                },
                Propietario = "Ana López"
            },
            new()
            {
                Mascota = new Mascota
                {
                    IdMascota = 3,
                    IdCliente = 2,
                    Nombre = "Rocky",
                    Especie = "Perro",
                    Raza = "Pastor Alemán",
                    Sexo = "Macho"
                },
                Propietario = "Carlos Ramírez"
            }
        };

        if (IdCliente.HasValue)
        {
            Mascotas = Mascotas
                .Where(m => m.Mascota.IdCliente == IdCliente.Value)
                .ToList();
        }
    }

    public class MascotaFila
    {
        public Mascota Mascota { get; set; } = new();
        public string Propietario { get; set; } = string.Empty;
    }
}