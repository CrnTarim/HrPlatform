using HrPlatform.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Entities.Service
{
    public interface ITitleInformationService : IService<TitleInformation>
    {
        Task<PersonalInformation> GetPersonAsync(Guid id);
    }
}
