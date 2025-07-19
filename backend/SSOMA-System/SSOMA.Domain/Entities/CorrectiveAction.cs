namespace SSOMA.Domain.Entities;

public partial class CorrectiveAction
{
    public int Id { get; set; }

    public int ReportId { get; set; }

    public string Description { get; set; } = null!;

    public int ResponsibleId { get; set; }

    public DateOnly PlannedDate { get; set; }

    public DateOnly? ExecutionDate { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Report Report { get; set; } = null!;

    public virtual User Responsible { get; set; } = null!;
}
