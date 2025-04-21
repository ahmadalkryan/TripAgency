using Application.DTOs.Customer;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // CreateCustomerDto → Customer
            CreateMap<CreateCustomerDto, Customer>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.CustomerSince,
                    opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.CustomerCode,
                    opt => opt.MapFrom(src => GenerateCustomerCode(src)))
                .ForMember(dest => dest.IsPremium,
                    opt => opt.MapFrom(src => src.MembershipType == "Premium"));

            // UpdateCustomerDto → Customer
            CreateMap<UpdateCustomerDto, Customer>()
                .ForMember(dest => dest.LastUpdated,
                    opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));

            // Customer → CustomerDto
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.MembershipDuration,
                    opt => opt.MapFrom(src => (DateTime.Now - src.CustomerSince).Days / 365))
                .ForMember(dest => dest.CustomerStatus,
                    opt => opt.MapFrom(src => src.IsPremium ? "Premium" : "Standard"));
        }

        private string GenerateCustomerCode(CreateCustomerDto dto)
        {
            return $"{dto.FirstName[0]}{dto.LastName[0]}-{DateTime.Now:yyMMddHHmm}";
        }
    }
}