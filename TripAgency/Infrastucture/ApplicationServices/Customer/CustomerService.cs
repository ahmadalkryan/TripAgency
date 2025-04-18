using Application.DTOs.Common;
using Application.DTOs.Customer;
using Application.IApplicationServices.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ApplicationServices.Customer
{
    public class CustomerService : ICustomerService
    {
        public Task<CustomerDto> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomer(BaseDto<long> dto)
        {
            throw new NotImplementedException();
        }

        public Task<CustomersDto> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDto> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            throw new NotImplementedException();
        }
    }
}
