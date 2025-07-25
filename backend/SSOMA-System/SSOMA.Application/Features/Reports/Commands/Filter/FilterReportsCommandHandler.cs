using AutoMapper;
using MediatR;
using SSOMA.Application.DTOs.Report;
using SSOMA.Domain.IUnitOfWork;

namespace SSOMA.Application.Features.Reports.Commands.Filter;

public class FilterReportsCommandHandler : IRequestHandler<FilterReportsCommand, List<ReportListItemResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FilterReportsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ReportListItemResponseDto>> Handle(FilterReportsCommand request, CancellationToken cancellationToken)
    {
        var filter = request.Filter;

        // Convertir DateTime a DateOnly (ya que el repositorio usa DateOnly)
        DateOnly? fromDate = filter.FromDate.HasValue ? DateOnly.FromDateTime(filter.FromDate.Value) : null;
        DateOnly? toDate = filter.ToDate.HasValue ? DateOnly.FromDateTime(filter.ToDate.Value) : null;

        var reports = await _unitOfWork.ReportRepository.FilterReportsAsync(
            filter.Status,
            filter.Type,
            filter.CategoryId,
            filter.UserId,
            fromDate,
            toDate,
            filter.Page,
            filter.PageSize
        );

        return _mapper.Map<List<ReportListItemResponseDto>>(reports);
    }
}