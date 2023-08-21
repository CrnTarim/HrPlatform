using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Entities.Repositories
{
    public interface IGenericRepository<T> where T : class
    {          
        IQueryable<T> GetAll();    
        Task AddAsync(T entity);        
    }
}
