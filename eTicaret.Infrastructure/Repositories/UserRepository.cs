using eTicaret.Domain.Entities;
using eTicaret.Domain.Enums;
using eTicaret.Domain.Interfaces;
using eTicaret.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly eTicaretDbContext _context;
        public UserRepository(eTicaretDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email) 
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IReadOnlyList<User>> GetUsersByRoleAsync(string roleName) 
        {
            if(Enum.TryParse(roleName, true, out UserRole role)) 
            {
                return await _context.Users.Where(u => u.UserRole == role).ToListAsync();
            }

            return new List<User>();
        }
    }
}
