using Application.DTOs.Common;
using Application.DTOs.Contact;
using Application.DTOs.Customer;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ApplicationServices.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IIdentityAppRepositry _customerRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public CustomerService(
            ICustomerRepository customerRepository,
            IContactRepository contactRepository,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<CustomersDto> GetCustomersAsync()
        {
            var customers = await _customerRepository.GetAllWithContactsAsync();
            return new CustomersDto
            {
                Customers = _mapper.Map<List<CustomerDto>>(customers)
            };
        }

        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            
            if (await _customerRepository.ExistsAsync(c => c.Email == createCustomerDto.Email))
            {
                throw new DuplicateEmailException(createCustomerDto.Email);
            }

            var customer = _mapper.Map<Domain.Entities.Customer>(createCustomerDto);

            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            var customer = await _customerRepository.GetByIdAsync(updateCustomerDto.Id);

            if (customer == null)
            {
                throw new CustomerNotFoundException(updateCustomerDto.Id);
            }

            _mapper.Map(updateCustomerDto, customer);

            _customerRepository.Update(customer);
            await _customerRepository.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task DeleteCustomerAsync(BaseDto<long> dto)
        {
            var customer = await _customerRepository.GetByIdAsync(dto.Id);

            if (customer == null)
            {
                throw new CustomerNotFoundException(dto.Id);
            }

            _customerRepository.Delete(customer);
            await _customerRepository.SaveChangesAsync();
        }

        public async Task<ContactsDto> GetCustomerContactAsync()
        {
            var contacts = await _contactRepository.GetAllAsync();
            return new ContactsDto
            {
                Contacts = _mapper.Map<List<ContactDto>>(contacts)
            };
        }

        public async Task<CustomerDto> UpdateCustomerContactsAsync()
        {
         
            throw new System.NotImplementedException();
        }

        public async Task<CustomerDto> DeleteCustomerContactAsync()
        {
           
            throw new System.NotImplementedException();
        }
    }
}