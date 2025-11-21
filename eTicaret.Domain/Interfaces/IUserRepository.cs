using eTicaret.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IReadOnlyList<User>> GetUsersByRoleAsync(string roleName);
    }
}
