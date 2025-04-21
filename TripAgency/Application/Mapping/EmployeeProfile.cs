using Application.DTOs.Employee;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // CreateEmployeeDto → Employee
            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.HireDate,
                    opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.IsActive,
                    opt => opt.MapFrom(_ => true));

            // UpdateEmployeeDto → Employee
            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(dest => dest.LastModifiedDate,
                    opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));

            // Employee → EmployeeDto
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.YearsOfService,
                    opt => opt.MapFrom(src => (DateTime.Now - src.HireDate).Days / 365))
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.IsActive ? "Active" : "Inactive"));
        }
    }
}