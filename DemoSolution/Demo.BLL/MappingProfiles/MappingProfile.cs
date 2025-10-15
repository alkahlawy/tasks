using AutoMapper;
using Demo.BLL.DTOs.Employees;
using Demo.DAL.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Employee, EmployeeDto>(); // Source , Destination (Employee => EmployeeDto)
            //CreateMap<EmployeeDto, Employee>();

            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.EmpGender, options => options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmpType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null))
                .ReverseMap(); // Source , Destination (Employee => EmployeeDto) Two Way Mapping

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dest => dest.PhoneNumber, options => options.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null))

                .ReverseMap()
                .ForMember(dest => dest.Phone, options => options.MapFrom(src => src.PhoneNumber));

            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())))
                .ForMember(dest => dest.Phone, options => options.MapFrom(src => src.PhoneNumber))
                .ReverseMap()
                .ForMember(dest => dest.PhoneNumber, options => options.MapFrom(src => src.Phone));

            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly())))
                .ForMember(dest => dest.Phone, options => options.MapFrom(src => src.PhoneNumber))
                .ReverseMap()
                .ForMember(dest => dest.PhoneNumber, options => options.MapFrom(src => src.Phone));
        }
    }
}
