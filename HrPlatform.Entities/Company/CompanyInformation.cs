﻿using HrPlatform.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Entities.Company
{
    public class CompanyInformation
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

        public ICollection<TitleInformation> TitleInformations { get; set; }
        public ICollection<HrAutho> HrAuthos { get; set; }
        public ICollection<PersonalCompany> PersonalInformations { get; set; }


    }
}
