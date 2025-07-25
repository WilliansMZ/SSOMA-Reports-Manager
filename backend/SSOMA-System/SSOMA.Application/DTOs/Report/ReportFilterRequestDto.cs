namespace SSOMA.Application.DTOs.Report
{
    public class ReportFilterRequestDto
    {
        public string? Status { get; set; }
        public string? Type { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        public DateTime? FromDate { get; set; }  // Cambiado a DateTime
        public DateTime? ToDate { get; set; }    // Cambiado a DateTime

        // Paginación
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}