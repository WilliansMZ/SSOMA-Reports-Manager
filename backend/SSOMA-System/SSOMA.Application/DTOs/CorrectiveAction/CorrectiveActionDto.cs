namespace SSOMA.Application.DTOs.CorrectiveAction;

public class CorrectiveActionDto
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public int ResponsibleId { get; set; }
    public string ResponsibleFullName { get; set; } = null!; // <-- Asegúrate de tenerlo
    public string ResponsibleEmail { get; set; } = null!; 
    public DateOnly PlannedDate { get; set; }
    public DateOnly? ExecutionDate { get; set; }
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}