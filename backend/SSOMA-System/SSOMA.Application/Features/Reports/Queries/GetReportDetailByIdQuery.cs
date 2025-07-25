using MediatR;
using SSOMA.Application.DTOs.Report;

namespace SSOMA.Application.Features.Reports.Queries;

public class GetReportDetailByIdQuery : IRequest<ReportDetailDtoResponse>
{
    public int Id { get; set; }

    public GetReportDetailByIdQuery(int id)
    {
        Id = id;
    }
}
