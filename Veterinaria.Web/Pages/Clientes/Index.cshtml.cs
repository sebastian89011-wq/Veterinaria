using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Veterinaria.Entidades;
using Veterinaria.Negocios;

namespace Veterinaria.Web.Pages.Clientes;

public class IndexModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? Buscar { get; set; }

    public List<Cliente> Clientes { get; private set; } = new();

    public string? Error { get; private set; }

    public void OnGet()
    {
        try
        {
            ClienteNegocio negocio = new();

            Clientes = string.IsNullOrWhiteSpace(Buscar)
                ? negocio.Listar()
                : negocio.Buscar(Buscar);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);

            Error =
                "No fue posible consultar los clientes. " +
                "Verifique la conexión con MySQL.";
        }
    }
}