using System.ComponentModel.DataAnnotations;
using Veterinaria.Entidades;

namespace Veterinaria.Entidades;

public class Mascota
{
    public int IdMascota { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un propietario.")]
    public int IdCliente { get; set; }

    [Required(ErrorMessage = "El nombre de la mascota es obligatorio.")]
    [StringLength(60)]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "La especie es obligatoria.")]
    [StringLength(40)]
    public string Especie { get; set; } = string.Empty;

    [StringLength(60)]
    public string? Raza { get; set; }

    [StringLength(15)]
    public string? Sexo { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    [StringLength(50)]
    public string? Color { get; set; }

    [StringLength(200)]
    public string? SenasParticulares { get; set; }
}