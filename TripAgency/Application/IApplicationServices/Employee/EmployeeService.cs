using Application.DTOs.Common;
using Application.DTOs.Employee;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.ApplicationServices.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IIdentityAppRepositry _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IMapper mapper,
            ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EmployeesDto> GetEmployees()
        {
            _logger.LogInformation("Fetching all employees");

            var employees = await _employeeRepository.GetAllAsync();
            return new EmployeesDto
            {
                Employees = _mapper.Map<List<EmployeeDto>>(employees)
            };
        }

        public async Task<EmployeeDto> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            _logger.LogInformation($"Creating new employee with email: {createEmployeeDto.Email}");

            
            if (await _employeeRepository.ExistsAsync(e => e.Email == createEmployeeDto.Email))
            {
                throw new DuplicateEmailException(createEmployeeDto.Email);
            }

            var employee = _mapper.Map<Domain.Entities.Employee>(createEmployeeDto);

            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveChangesAsync();

            _logger.LogInformation($"Employee created with ID: {employee.Id}");

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            _logger.LogInformation($"Updating employee with ID: {updateEmployeeDto.Id}");

            var employee = await _employeeRepository.GetByIdAsync(updateEmployeeDto.Id);

            if (employee == null)
            {
                throw new EmployeeNotFoundException(updateEmployeeDto.Id);
            }

            
            if (employee.Email != updateEmployeeDto.Email &&
                await _employeeRepository.ExistsAsync(e => e.Email == updateEmployeeDto.Email))
            {
                throw new DuplicateEmailException(updateEmployeeDto.Email);
            }

            _mapper.Map(updateEmployeeDto, employee);

            _employeeRepository.Update(employee);
            await _employeeRepository.SaveChangesAsync();

            _logger.LogInformation($"Employee with ID: {employee.Id} updated successfully");

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task DeleteEmployee(BaseDto<long> dto)
        {
            _logger.LogInformation($"Deleting employee with ID: {dto.Id}");

            var employee = await _employeeRepository.GetByIdAsync(dto.Id);

            if (employee == null)
            {
                throw new EmployeeNotFoundException(dto.Id);
            }

            _employeeRepository.Delete(employee);
            await _employeeRepository.SaveChangesAsync();

            _logger.LogInformation($"Employee with ID: {dto.Id} deleted successfully");
        }
    }
}