
namespace SSOMA.Domain.Entities;

public partial class Evidencia
{
    public int Id { get; set; }

    public int ReporteId { get; set; }

    public string UrlArchivo { get; set; } = null!;

    public string? TipoArchivo { get; set; }

    public DateTime? FechaSubida { get; set; }

    public virtual Reporte Reporte { get; set; } = null!;
}
