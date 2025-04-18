using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Employee
{
    public class EmployeeDto : BaseDto<long>
    {

    }

    public class EmployeesDto
    {
        public IList<EmployeeDto> Employees = [];
    }
}
