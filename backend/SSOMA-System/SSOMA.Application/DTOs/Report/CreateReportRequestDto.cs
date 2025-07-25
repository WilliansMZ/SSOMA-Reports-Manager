namespace SSOMA.Application.DTOs.Report;

public class CreateReportRequestDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime ReportDate { get; set; }
    public int CategoryId { get; set; } // Se relaciona con categories.id
}