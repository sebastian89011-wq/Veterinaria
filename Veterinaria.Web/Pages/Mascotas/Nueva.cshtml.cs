using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Veterinaria.Entidades;
using Veterinaria.Negocios;

namespace Veterinaria.Web.Pages.Mascotas;

public class NuevaModel : PageModel
{
    [BindProperty]
    public Mascota Mascota { get; set; } = new();

    public List<SelectListItem> Clientes { get; private set; } = new();

    public bool HayClientes => Clientes.Count > 0;

    public string? Error { get; private set; }

    public void OnGet()
    {
        try
        {
            CargarClientes();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            Error =
                "No fue posible cargar los clientes. " +
                "Verifique la conexión con MySQL.";
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

        if (!HayClientes)
        {
            ModelState.AddModelError(
                string.Empty,
                "No existen clientes registrados. " +
                "Primero registre un cliente.");

            return Page();
        }

        if (!ModelState.IsValid)
            return Page();

        try
        {
            MascotaNegocio negocio = new();

            int id = negocio.Agregar(Mascota);

            TempData["Mensaje"] =
                $"Mascota registrada correctamente. ID: {id}";

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
                "No fue posible registrar la mascota.");

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