using AutoMapper;
using MediatR;
using SSOMA.Application.DTOs.Report;
using SSOMA.Domain.Entities;
using SSOMA.Domain.IUnitOfWork;

namespace SSOMA.Application.Features.Reports.Commands;

public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, ReportResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ReportResponseDto> Handle(CreateReportCommand request, CancellationToken cancellationToken)
    {
        // Mapear del DTO a la entidad
        var report = _mapper.Map<Report>(request.ReportDto);
        
        

        // Completar los campos que no vienen del DTO
        report.UserId = request.UserId;
        report.Status = "pending";
        report.CreatedAt = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);

        await _unitOfWork.ReportRepository.AddAsync(report);
        await _unitOfWork.SaveAsync();
        
        // Recuperar con categoría incluida
        var reportWithCategory = await _unitOfWork.ReportRepository.GetWithCategoryByIdAsync(report.Id);
        // Mapear del entity al ResponseDto
        var response = _mapper.Map<ReportResponseDto>(report);
        return response;
    }
}