using MediatR;
using SSOMA.Application.DTOs.Report;

namespace SSOMA.Application.Features.Reports.Queries;

public class GetAllReportsQuery : IRequest<List<ReportResponseDto>>
{
}