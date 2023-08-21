using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Entities.Employees
{
    public class PersonalInformation
    {
      public Guid SSN { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Address { get; set; }
      public string Phone { get; set; }
      public string Email { get; set; }
      public string Gender { get; set; } 
      public string BankNo { get; set; }

        // Navigation property for the 1-1 relationship
        public TitleInformation TitleInformation { get; set; }

    }
}
