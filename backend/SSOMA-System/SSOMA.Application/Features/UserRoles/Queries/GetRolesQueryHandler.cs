using AutoMapper;
using MediatR;
using SSOMA.Application.DTOs.UserRoles;
using SSOMA.Domain.IUnitOfWork;

namespace SSOMA.Application.Features.UserRoles.Queries;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = await _unitOfWork.RoleRepository.GetAllAsync();
        return _mapper.Map<List<RoleDto>>(roles);
    }
}