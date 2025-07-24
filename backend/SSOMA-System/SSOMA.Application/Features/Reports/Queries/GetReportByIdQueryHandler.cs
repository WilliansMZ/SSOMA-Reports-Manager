using AutoMapper;
using MediatR;
using SSOMA.Application.DTOs.Report;
using SSOMA.Domain.IUnitOfWork;

namespace SSOMA.Application.Features.Reports.Queries;

public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, ReportResponseDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetReportByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ReportResponseDto?> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
    {
        var report = await _unitOfWork.ReportRepository.GetWithCategoryByIdAsync(request.Id);
        if (report == null)
            return null;

        return _mapper.Map<ReportResponseDto>(report);
    }
}