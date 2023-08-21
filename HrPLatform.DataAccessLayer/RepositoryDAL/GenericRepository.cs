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

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }
    }
}
