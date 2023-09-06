using HrPlatform.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Entities.Employees
{
    public class TitleInformation
    {
        public Guid TitleId { get; set; }     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Team { get; set; }
        public string Department { get; set; }
        public string StartDate { get; set; }
        public string Payment { get; set; }
       
        //userAuth
        // Navigation property for the 1-1 relationship
        public PersonalInformation PersonalInformation { get; set; }
        public Guid SsnPersonal { get; set; }
        
        public CompanyInformation CompanyInformation { get; set; }
        public Guid CompanyId { get; set; }
    
    }
}
