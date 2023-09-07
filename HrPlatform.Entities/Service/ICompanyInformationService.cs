using HrPlatform.Entities.Company;
using HrPlatform.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Entities.Service
{
    public interface ICompanyInformationService  : IService<CompanyInformation>
    {
        Task<CompanyInformation> GetbyMailAsync(string mail);
        Task<List<TitleDto>> GetAllTitle(Guid id);


    }
}
