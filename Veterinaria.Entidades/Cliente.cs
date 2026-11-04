using System.ComponentModel.DataAnnotations;
using Veterinaria.Entidades;

namespace Veterinaria.Entidades;

public class Cliente
{
    public int IdCliente { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(60)]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido paterno es obligatorio.")]
    [StringLength(60)]
    public string ApellidoPaterno { get; set; } = string.Empty;

    [StringLength(60)]
    public string? ApellidoMaterno { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio.")]
    [StringLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
    [StringLength(120)]
    public string? Correo { get; set; }

    [StringLength(200)]
    public string? Direccion { get; set; }

    public DateTime FechaRegistro { get; set; }
}