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
    public class TitleInformationRepository : GenericRepository<TitleInformation>, ITitleInformationRepository
    {
        protected readonly HrDBConnection _context;
        private readonly DbSet<TitleInformation> _dbSet;
        public TitleInformationRepository(HrDBConnection context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<TitleInformation>();
        }

        public async Task<PersonalInformation> GetPersonAsync(Guid id)
        {
            var personalInformation = await _context.TitleInformations.Where(t => t.TitleId == id).Select(t => t.PersonalInformation).FirstOrDefaultAsync();
            return personalInformation;
        }
    }
}
