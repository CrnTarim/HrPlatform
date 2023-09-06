using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Entities.DTO
{
    public class TitleDtoGet
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Team { get; set; }
        public string Department { get; set; }
        public string StartDate { get; set; }
        public string Payment { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
   
    }
}
