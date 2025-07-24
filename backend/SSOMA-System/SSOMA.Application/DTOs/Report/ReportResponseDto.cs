namespace SSOMA.Application.DTOs.Report;

public class ReportResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime ReportDate { get; set; }
    public string Status { get; set; } = null!;
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;  // De categories.name
    public string CategoryType { get; set; } = null!;  // De categories.type
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
}