using eTicaret.Domain.Interfaces;
using eTicaret.Infrastructure.Persistence.Context;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly eTicaretDbContext _context;

        private IUserRepository _userRepositiory;
        public UnitOfWork (eTicaretDbContext context)
        {
            _context = context;            
        }

        public IUserRepository Users 
        {
            get 
            {
                if (_userRepositiory == null) 
                {
                    _userRepositiory = new UserRepository(_context);
                }

                return _userRepositiory;
            }
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            
            System.GC.SuppressFinalize(this);
        }
    }
}
