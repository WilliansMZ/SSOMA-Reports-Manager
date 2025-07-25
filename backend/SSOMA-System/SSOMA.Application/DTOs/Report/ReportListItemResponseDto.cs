namespace SSOMA.Application.DTOs.Report
{
    public class ReportListItemResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime ReportDate { get; set; } // Cambiado a DateTime

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public int UserId { get; set; }
        public string UserFullName { get; set; } = null!;
    }
}