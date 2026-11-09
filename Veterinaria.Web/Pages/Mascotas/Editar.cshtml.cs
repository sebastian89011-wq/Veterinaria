using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Veterinaria.Entidades;
using Veterinaria.Negocios;

namespace Veterinaria.Web.Pages.Mascotas;

public class EditarModel : PageModel
{
    [BindProperty]
    public Mascota Mascota { get; set; } = new();

    public List<SelectListItem> Clientes { get; private set; } = new();

    public string? Error { get; private set; }

    public IActionResult OnGet(int id)
    {
        try
        {
            CargarClientes();

            MascotaNegocio negocio = new();

            Mascota? mascota =
                negocio.BuscarPorId(id);

            if (mascota is null)
                return NotFound();

            Mascota = mascota;

            return Page();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            Error =
                "No fue posible consultar la mascota.";

            return Page();
        }
    }

    public IActionResult OnPost()
    {
        try
        {
            CargarClientes();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            ModelState.AddModelError(
                string.Empty,
                "No fue posible cargar los clientes.");

            return Page();
        }

        if (!ModelState.IsValid)
            return Page();

        try
        {
            MascotaNegocio negocio = new();

            bool modificada =
                negocio.Modificar(Mascota);

            if (!modificada)
                return NotFound();

            TempData["Mensaje"] =
                "Mascota modificada correctamente.";

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
                "No fue posible modificar la mascota.");

            return Page();
        }
    }

    private void CargarClientes()
    {
        ClienteNegocio negocio = new();

        Clientes = negocio
            .Listar()
            .Select(c => new SelectListItem
            {
                Value = c.IdCliente.ToString(),
                Text =
                    $"{c.Nombre} {c.ApellidoPaterno} {c.ApellidoMaterno}".Trim()
            })
            .ToList();
    }
}
