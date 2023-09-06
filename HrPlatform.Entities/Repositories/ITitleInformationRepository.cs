using HrPlatform.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Entities.Repositories
{
    public interface ITitleInformationRepository: IGenericRepository<TitleInformation>
    {
        Task<PersonalInformation> GetPersonAsync(Guid id);
    }
}
