namespace SSOMA.Application.DTOs.Evidence;

public class EvidenceDto
{
    public int Id { get; set; }
    public string FileUrl { get; set; } = null!;
    public string FileType { get; set; } = null!;
    public DateTime UploadedAt { get; set; }
}