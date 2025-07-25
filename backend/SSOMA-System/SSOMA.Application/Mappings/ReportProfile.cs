using AutoMapper;
using SSOMA.Application.DTOs.CorrectiveAction;
using SSOMA.Application.DTOs.Evidence;
using SSOMA.Application.DTOs.Report;
using SSOMA.Domain.Entities;

namespace SSOMA.Application.Mappings;

public class ReportProfile : Profile
{
    public ReportProfile()
    {
        // Mapeo de DTO de creación → Entidad Report
        CreateMap<CreateReportRequestDto, Report>()
            .ForMember(dest => dest.ReportDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.ReportDate)))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => "pending")); // Cambiado a "pending" en minúscula

        // Mapeo de Entidad Report → DTO de respuesta
        CreateMap<Report, ReportResponseDto>()
            .ForMember(dest => dest.ReportDate, opt => opt.MapFrom(src => src.ReportDate.ToDateTime(TimeOnly.MinValue)))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt ?? DateTime.UtcNow))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.CategoryType,
                opt => opt.MapFrom(src => src.Category.Type.Name)); // ✔️ Aquí el cambio
        // Detalle de reporte
        CreateMap<Report, ReportDetailDtoResponse>()
            .ForMember(dest => dest.ReportDate, opt => opt.MapFrom(src => src.ReportDate.ToDateTime(TimeOnly.MinValue)))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt ?? DateTime.UtcNow))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => src.Category.Type.Name))
            .ForMember(dest => dest.Evidences, opt => opt.MapFrom(src => src.Evidences))
            .ForMember(dest => dest.CorrectiveActions, opt => opt.MapFrom(src => src.CorrectiveActions))
            .ForMember(dest => dest.UserFullName,
                opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));

        // Evidencias
        CreateMap<Evidence, EvidenceDto>();

        // Acciones correctivas
        CreateMap<CorrectiveAction, CorrectiveActionDto>()
            .ForMember(dest => dest.ResponsibleFullName,
                opt => opt.MapFrom(src => src.Responsible.FirstName + " " + src.Responsible.LastName))
            .ForMember(dest => dest.ResponsibleEmail,
                opt => opt.MapFrom(src => src.Responsible.Email));

        // Mapeo para lista resumida de reportes (filtrado o listado)
        CreateMap<Report, ReportListItemResponseDto>()
            .ForMember(dest => dest.ReportDate, opt => opt.MapFrom(src => src.ReportDate.ToDateTime(TimeOnly.MinValue)))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Category.Type.Name))
            .ForMember(dest => dest.UserFullName,
                opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
    }



}