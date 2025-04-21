using Application.DTOs.Common;
using Application.DTOs.Contact;
using Domain.Entities;
using Domain.Entities.ApplicationEntities;

namespace Application.IApplicationServices.Contact
{
    public interface IContactTypeService
    {
        Task<ContactTypeDto> CreateContactAsync(CreateContactTypeDto createAddressDto);
        Task UpdateContactAsync(UpdateContactTypeDto updateAddressDto);
        Task DeleteContactAsync(BaseDto<int> baseDto);
        Task<ContactTypesDto> GetContactTypesAsync();
        Task<ContactTypeDto> GetContactTypeByIdAsync(int id);
    }
}
