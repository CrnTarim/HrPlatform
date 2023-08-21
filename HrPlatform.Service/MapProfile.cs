using AutoMapper;
using HrPlatform.Entities.DTO;
using HrPlatform.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Service
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<PersonalInformation, PersonelDto>().ReverseMap();
            CreateMap<TitleInformation, TitleDto>().ReverseMap();    
        }
    }
}
