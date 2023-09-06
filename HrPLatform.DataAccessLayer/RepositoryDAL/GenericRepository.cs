using HrPlatform.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPLatform.DataAccessLayer.RepositoryDAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HrDBConnection _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(HrDBConnection context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetbyIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }
      
        public IQueryable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
