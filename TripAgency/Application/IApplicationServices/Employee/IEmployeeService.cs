using Application.DTOs.Common;
using Application.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IApplicationServices.Employee
{
    public interface IEmployeeService
    {
        Task<EmployeesDto> GetCustomers();
        Task<EmployeeDto> CreateCustomer(CreateEmployeeDto createEmployeeDto);
        Task<EmployeeDto> UpdateCustomer(UpdateEmployeeDto updateEmployeeDto);
        Task DeleteCustomer(BaseDto<long> dto);
    }
}