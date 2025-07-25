using AutoMapper;
using MediatR;
using SSOMA.Application.DTOs.Report;
using SSOMA.Domain.IUnitOfWork;

namespace SSOMA.Application.Features.Reports.Queries;

public class GetReportDetailByIdQueryHandler : IRequestHandler<GetReportDetailByIdQuery, ReportDetailDtoResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetReportDetailByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ReportDetailDtoResponse?> Handle(GetReportDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var report = await _unitOfWork.ReportRepository.GetFullReportByIdAsync(request.Id);

        if (report == null)
            return null;

        return _mapper.Map<ReportDetailDtoResponse>(report);
    }
}