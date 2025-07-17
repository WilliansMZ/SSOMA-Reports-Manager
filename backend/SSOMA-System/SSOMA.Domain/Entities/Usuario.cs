
namespace SSOMA.Domain.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<AccionesCorrectiva> AccionesCorrectivas { get; set; } = new List<AccionesCorrectiva>();

    public virtual ICollection<Reporte> Reportes { get; set; } = new List<Reporte>();
}
