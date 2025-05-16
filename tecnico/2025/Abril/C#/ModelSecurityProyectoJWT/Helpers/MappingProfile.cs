using AutoMapper;
using Entity.DTOs;
using Entity.Model;

namespace Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();

            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Form, FormDTO>().ReverseMap();
            CreateMap<Module, ModuleDTO>().ReverseMap();
            //CreateMap<FormModule, FormModuleDTO>().ReverseMap();

            CreateMap<FormModule, FormModuleDTO>()
             .ForMember(dest => dest.FormName, opt => opt.MapFrom(src => src.Form.Name))
             .ForMember(dest => dest.ModuleName, opt => opt.MapFrom(src => src.Module.Name))
             .ReverseMap();

            CreateMap<FormModule, FormModuleCreateDTO>().ReverseMap();

            CreateMap<Permission, PermissionDTO>().ReverseMap();


            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<UserRole, UserRoleDTO>()
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username))
             .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
             .ReverseMap();

            CreateMap<UserRole, UserRoleCreateDTO>().ReverseMap();

            CreateMap<RoleFormPermission, RoleFormPermissionDTO>()
             .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
             .ForMember(dest => dest.FormName, opt => opt.MapFrom(src => src.Form.Name))
             .ForMember(dest => dest.PermissionName, opt => opt.MapFrom(src => src.Permission.Name))

             .ReverseMap();

            CreateMap<RoleFormPermission, RoleFormPermissionCreateDTO>().ReverseMap();


            //CreateMap<User, UserDTO>()
            //    .ForMember(dest => dest.NameComplet, opt => opt.MapFrom(src => src.Name + " " + src.LastName))
            //    .ReverseMap()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        }
    }
}
