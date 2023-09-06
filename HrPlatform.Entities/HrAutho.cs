using HrPlatform.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Entities
{
    public class HrAutho
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] PassWordHash { get; set; }
        public byte[] PassWordSalt { get; set; }


        public CompanyInformation CompanyInformation { get; set; }
        public Guid CompanyId { get; set; }

    }
}
