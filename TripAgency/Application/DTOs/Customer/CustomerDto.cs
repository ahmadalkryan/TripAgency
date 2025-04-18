using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Customer
{
    public class CustomerDto : BaseDto<long>
    {
    }

    public class CustomersDto
    {
        public IList<CustomerDto> Customers { get; set; } = [];
    }
}