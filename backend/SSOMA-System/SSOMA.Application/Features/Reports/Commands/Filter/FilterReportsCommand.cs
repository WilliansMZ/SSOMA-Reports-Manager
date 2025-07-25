using MediatR;
using SSOMA.Application.DTOs.Report;

namespace SSOMA.Application.Features.Reports.Commands.Filter;

public class FilterReportsCommand : IRequest<List<ReportListItemResponseDto>>
{
    public ReportFilterRequestDto Filter { get; set; }

    public FilterReportsCommand(ReportFilterRequestDto filter)
    {
        Filter = filter;
    }
}