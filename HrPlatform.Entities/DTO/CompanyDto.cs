using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Entities.DTO
{
    public class CompanyDto
    {
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyAddress { get; set; }

        public string CardHoldersName { get; set; }
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
    }
}
