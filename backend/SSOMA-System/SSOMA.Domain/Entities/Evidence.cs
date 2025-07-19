namespace SSOMA.Domain.Entities;

public partial class Evidence
{
    public int Id { get; set; }

    public int ReportId { get; set; }

    public string FileUrl { get; set; } = null!;

    public string? FileType { get; set; }

    public DateTime? UploadedAt { get; set; }

    public virtual Report Report { get; set; } = null!;
}
