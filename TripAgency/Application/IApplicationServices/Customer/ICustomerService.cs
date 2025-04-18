using Application.DTOs.Common;
using Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IApplicationServices.Customer
{
    public interface ICustomerService
    {
        Task<CustomersDto> GetCustomers();
        Task<CustomerDto> CreateCustomer(CreateCustomerDto createCustomerDto);
        Task<CustomerDto> UpdateCustomer(UpdateCustomerDto updateCustomerDto);
        Task DeleteCustomer(BaseDto<long> dto);
    }
}