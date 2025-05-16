
using AutoMapper;
using Entity.DTOs;
using Entity.DTOs.Create;
using Entity.Models;

namespace Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapeo de la entidad Person 
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, PersonCreate>().ReverseMap();

            //Mapeo de la entidad Rol 
            CreateMap<Rol, RolDto>().ReverseMap();
            CreateMap<Rol, RolCreate>().ReverseMap();

            //Mapeo de la entidad Form 
            CreateMap<Form, FormDto>().ReverseMap();
            CreateMap<Form, FormCreate>().ReverseMap();

            //Mapeo de la entidad Module 
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Module, ModuleCreate>().ReverseMap();

            //Mapeo de la entidad ModuleForm 
            CreateMap<ModuleForm, ModuleFormDto>()
             .ForMember(dest => dest.NameForm, opt => opt.MapFrom(src => src.Form.Name))
             .ForMember(dest => dest.NameModule, opt => opt.MapFrom(src => src.Module.Name))
             .ReverseMap();
            CreateMap<ModuleForm, ModuleFormCreateDto>().ReverseMap();

            //Mapeo de la entidad permission
            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<Permission, PermissionCreate>().ReverseMap();

            //Mapeo de la entidad User
            CreateMap<User, UserDTO>()
             .ForMember(dest => dest.NamePerson, opt => opt.MapFrom(src => src.Person.FirstName + " " + src.Person.LastName))
            .ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();

            //Mapeo de la entidad UserROl
            CreateMap<UserRol, UserRolDto>()
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Email))
             .ForMember(dest => dest.RolName, opt => opt.MapFrom(src => src.Rol.Name))
             .ReverseMap();
            CreateMap<UserRol, UserRolCreateDto>().ReverseMap();

            //Mapeo de la entidad RolFormPermission
            CreateMap<RolFormPermission, RolFormPermissionDto>()
             .ForMember(dest => dest.RolName, opt => opt.MapFrom(src => src.Rol.Name))
             .ForMember(dest => dest.FormName, opt => opt.MapFrom(src => src.Form.Name))
             .ForMember(dest => dest.PermissionName, opt => opt.MapFrom(src => src.Permission.Name))
             .ReverseMap();
            CreateMap<RolFormPermission, RolFormPermissionCreateDto>().ReverseMap();
        }
    }
}
