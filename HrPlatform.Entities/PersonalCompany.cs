using HrPlatform.Entities.Company;
using HrPlatform.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Entities
{
    public class PersonalCompany
    {
        public Guid SSN { get; set; }
        public Guid CompanyId { get; set; }

        public CompanyInformation CompanyInformation { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
    }
}
