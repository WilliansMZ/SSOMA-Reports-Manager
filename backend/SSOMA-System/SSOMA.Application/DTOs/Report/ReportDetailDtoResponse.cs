using SSOMA.Application.DTOs.CorrectiveAction;
using SSOMA.Application.DTOs.Evidence;

namespace SSOMA.Application.DTOs.Report;

public class ReportDetailDtoResponse
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime ReportDate { get; set; }
    public string Status { get; set; } = null!;

    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string CategoryType { get; set; } = null!;

    public int UserId { get; set; }
    public string UserFullName { get; set; } = null!; // NUEVO
    
    public string? UserEmail { get; set; } // <-- NUEVO

    public DateTime CreatedAt { get; set; }

    public List<EvidenceDto> Evidences { get; set; } = new();
    public List<CorrectiveActionDto> CorrectiveActions { get; set; } = new();
}