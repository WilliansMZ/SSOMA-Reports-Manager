using MediatR;
using SSOMA.Application.DTOs.Report;

namespace SSOMA.Application.Features.Reports.Commands;

public class CreateReportCommand : IRequest<ReportResponseDto>
{
    public CreateReportRequestDto ReportDto { get; }
    public int UserId { get; }

    public CreateReportCommand(CreateReportRequestDto reportDto, int userId)
    {
        ReportDto = reportDto ?? throw new ArgumentNullException(nameof(reportDto));
        UserId = userId;
    }
}