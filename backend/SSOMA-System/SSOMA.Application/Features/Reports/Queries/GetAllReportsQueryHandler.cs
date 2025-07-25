using AutoMapper;
using MediatR;
using SSOMA.Application.DTOs.Report;
using SSOMA.Domain.IUnitOfWork;

namespace SSOMA.Application.Features.Reports.Queries;

public class GetAllReportsQueryHandler : IRequestHandler<GetAllReportsQuery, List<ReportResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllReportsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ReportResponseDto>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
    {
        var reports = await _unitOfWork.ReportRepository.GetAllWithCategoryAsync();
        return _mapper.Map<List<ReportResponseDto>>(reports);
    }
}