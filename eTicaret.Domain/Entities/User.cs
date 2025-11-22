using eTicaret.Domain.Enums;
using eTicaret.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public UserRole UserRole { get; set; }
        public string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }        
        public string PasswordHash { get; set; }
        public Address? Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
