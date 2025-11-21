using eTicaret.Application.DTOs.Users;
using eTicaret.Application.Interfaces;
using eTicaret.Domain.Entities;
using eTicaret.Domain.Enums;
using eTicaret.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> RegisterUserAsync(UserRegistrationDto registrationDto) 
        {
            if(registrationDto.Password != registrationDto.ConfirmPassword)
            {
                throw new ArgumentException("Passwords do not match");
            }

            var existingUser = await _unitOfWork.Users.GetUserByEmailAsync(registrationDto.Email);

            if (existingUser != null)
            {
                throw new ArgumentException("This email address is already in use.");
            }

            
            UserRole assignedRole;
            
            bool isValidRole = Enum.TryParse(registrationDto.SelectedRole, true, out assignedRole);

            
            if (!isValidRole || assignedRole == UserRole.Admin)
            {                
                throw new ArgumentException("Invalid or unauthorized user role selection.");
            }

            
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password);

            
            var newUser = new User
            {
                Email = registrationDto.Email,
                PasswordHash = passwordHash,
                FirstName = "",
                LastName = "",
                CreatedDate = DateTime.UtcNow,
                IsActive = true, 
                UserRole = assignedRole,
            };

            
            await _unitOfWork.Users.AddAsync(newUser);
            var changes = await _unitOfWork.CompleteAsync();

            if (changes > 0)
            {                
                return new UserDto
                {
                    Id = newUser.Id,
                    Email = newUser.Email,
                    FullName = newUser.GetFullName(),
                    UserRole = newUser.UserRole.ToString(),
                    AddressDescription = "Address information is not available."
                };
            }

            return null;
        }

       
    }
} 
    

