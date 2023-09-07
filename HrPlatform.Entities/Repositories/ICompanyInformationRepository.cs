using HrPlatform.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Entities.Repositories
{
    public interface ICompanyInformationRepository : IGenericRepository<CompanyInformation>
    {
        Task<CompanyInformation> GetbyMailAsync(string mail);
        IQueryable<Employees.TitleInformation> GetAllTitle(Guid id);
    }
}
