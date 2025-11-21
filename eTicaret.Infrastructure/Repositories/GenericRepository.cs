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
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly eTicaretDbContext _context;

        private readonly DbSet<T> _dbSet;
        public GenericRepository(eTicaretDbContext context)
        {
            _context = context;

            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync() 
        {
            return await _dbSet.ToListAsync();
        }
    }
}
