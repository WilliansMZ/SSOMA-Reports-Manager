namespace SSOMA.Domain.Entities;

public partial class AccionesCorrectiva
{
    public int Id { get; set; }

    public int ReporteId { get; set; }

    public string Descripcion { get; set; } = null!;

    public int ResponsableId { get; set; }

    public DateOnly FechaPlanificada { get; set; }

    public DateOnly? FechaEjecucion { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Reporte Reporte { get; set; } = null!;

    public virtual Usuario Responsable { get; set; } = null!;
}
