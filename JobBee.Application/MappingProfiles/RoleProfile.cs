using AutoMapper;
using JobBee.Application.Features.Role.Commands.CreateRole;
using JobBee.Application.Features.Role.Commands.UpdateRole;
using JobBee.Application.Features.Role.Queries.GetAllRoles;
using JobBee.Application.Features.Role.Queries.GetRoleDetails;
using JobBee.Domain.Entities;

namespace JobBee.Application.MappingProfiles
{
    public class RoleProfile : Profile
	{
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>().ReverseMap();

            CreateMap<Role, RoleDetailsDto>().ReverseMap();

            CreateMap<Role, CreateRoleCommand>().ReverseMap();
            CreateMap<Role, CreateRoleDto>().ReverseMap();

            CreateMap<Role, UpdateRoleCommand>().ReverseMap();
            CreateMap<Role, UpdateRoleDto>().ReverseMap();
        }
    }
}
