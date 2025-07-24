using MediatR;
using SSOMA.Application.DTOs.Report;

namespace SSOMA.Application.Features.Reports.Queries;

public class GetReportByIdQuery : IRequest<ReportResponseDto>
{
    public int Id { get; set; }

    public GetReportByIdQuery(int id)
    {
        Id = id;
    }
}