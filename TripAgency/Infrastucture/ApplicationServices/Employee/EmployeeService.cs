using Application.DTOs.Common;
using Application.DTOs.Employee;
using Application.IApplicationServices.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ApplicationServices.Employee
{
    internal class EmployeeService : IEmployeeService
    {
        public Task<EmployeeDto> CreateCustomer(CreateEmployeeDto createEmployeeDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomer(BaseDto<long> dto)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeesDto> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeDto> UpdateCustomer(UpdateEmployeeDto updateEmployeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
