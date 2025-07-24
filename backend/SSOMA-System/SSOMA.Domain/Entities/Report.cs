namespace SSOMA.Domain.Entities;

public partial class Report
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly ReportDate { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<CorrectiveAction> CorrectiveActions { get; set; } = new List<CorrectiveAction>();

    public virtual ICollection<Evidence> Evidences { get; set; } = new List<Evidence>();

    public virtual User User { get; set; } = null!;
}
