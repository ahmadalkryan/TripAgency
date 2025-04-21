using Application.DTOs.Contact;
using AutoMapper;
using DataAccessLayer.Enum;
using Domain.Entities.ApplicationEntities;

namespace Application.Mapping
{
    public class ContactTypeProfile : Profile
    {
        public ContactTypeProfile()
        {
            
            CreateMap<CreateContactTypeDto, ContactType>()
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.CreatedDate,
                    opt => opt.MapFrom(_ => DateTime.UtcNow));

            
            CreateMap<UpdateContactTypeDto, ContactType>()
                .ForMember(dest => dest.LastModifiedDate,
                    opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null)); 

            
            CreateMap<ContactType, ContactTypeDto>()
                .ForMember(dest => dest.TypeDescription,
                    opt => opt.MapFrom(src => GetTypeDescription(src.Type)));

           
            CreateMap<ContactTypeEnum, ContactTypeDto>()
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.TypeDescription,
                    opt => opt.MapFrom(src => GetTypeDescription(src)));
        }

        
    }
}