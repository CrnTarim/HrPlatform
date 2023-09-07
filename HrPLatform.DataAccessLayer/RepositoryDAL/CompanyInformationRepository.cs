using HrPlatform.Entities.Company;
using HrPlatform.Entities.Employees;
using HrPlatform.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPLatform.DataAccessLayer.RepositoryDAL
{
    public class CompanyInformationRepository : GenericRepository<CompanyInformation>, ICompanyInformationRepository
    {
        protected readonly HrDBConnection _context;
        private readonly DbSet<CompanyInformation> _dbSet;
        public CompanyInformationRepository(HrDBConnection context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<CompanyInformation>();
        }

    

        public IQueryable<TitleInformation> GetAllTitle(Guid id)
        {
            return _dbSet.Include(c => c.TitleInformations).Where(c => c.CompanyId == id).SelectMany(c => c.TitleInformations).AsNoTracking();
        }

        public async Task<CompanyInformation> GetbyMailAsync(string mail)
        {
            return await _dbSet.SingleOrDefaultAsync(x => x.CompanyEmail == mail);
        }
    }
}
