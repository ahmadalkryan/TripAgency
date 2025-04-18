using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DTOs.Authentication
{
    public class RegisterDto
    {        
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))] // Add this for proper enum handling
        public RoleEnum Role { get; set; } = RoleEnum.Customer;
        public string Address { get; set; } = string.Empty;
    }
}