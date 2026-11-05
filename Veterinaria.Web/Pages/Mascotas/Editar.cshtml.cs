using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Veterinaria.Entidades;

namespace Veterinaria.Web.Pages.Mascotas;

public class EditarModel : PageModel
{
    [BindProperty]
    public Mascota Mascota { get; set; } = new();

    public List<SelectListItem> Clientes { get; private set; } = new();

    public IActionResult OnGet(int id)
    {
        CargarClientes();

        Mascota = id switch
        {
            1 => new Mascota
            {
                IdMascota = 1,
                IdCliente = 1,
                Nombre = "Max",
                Especie = "Perro",
                Raza = "Labrador",
                Sexo = "Macho",
                FechaNacimiento = new DateTime(2021, 4, 15),
                Color = "Dorado"
            },
            2 => new Mascota
            {
                IdMascota = 2,
                IdCliente = 1,
                Nombre = "Luna",
                Especie = "Gato",
                Raza = "Siamés",
                Sexo = "Hembra",
                FechaNacimiento = new DateTime(2022, 8, 10),
                Color = "Crema"
            },
            3 => new Mascota
            {
                IdMascota = 3,
                IdCliente = 2,
                Nombre = "Rocky",
                Especie = "Perro",
                Raza = "Pastor Alemán",
                Sexo = "Macho",
                FechaNacimiento = new DateTime(2020, 6, 20),
                Color = "Negro y café"
            },
            _ => new Mascota()
        };

        return Mascota.IdMascota == 0 ? NotFound() : Page();
    }

    public IActionResult OnPost()
    {
        CargarClientes();

        if (!ModelState.IsValid)
            return Page();

        // PRÁCTICA 6:
        // new MascotaNegocio().Modificar(Mascota);

        TempData["Mensaje"] = "Cambios de mascota validados.";
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