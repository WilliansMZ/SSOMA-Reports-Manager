

namespace SSOMA.Domain.Entities;

public partial class Reporte
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public DateOnly FechaReporte { get; set; }

    public int UsuarioId { get; set; }

    public int CategoriaId { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<AccionesCorrectiva> AccionesCorrectivas { get; set; } = new List<AccionesCorrectiva>();

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<Evidencia> Evidencia { get; set; } = new List<Evidencia>();

    public virtual Usuario Usuario { get; set; } = null!;
}
