using AutoMapper;
using HrPlatform.Entities;
using HrPlatform.Entities.Company;
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
            CreateMap<TitleInformation, TitleDto>().ReverseMap();

            CreateMap<CompanyInformation, CompanyDtoGet>();
            //CreateMap<CompanyDto, CompanyInformation>().ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => Guid.NewGuid())).ReverseMap();
            CreateMap<CompanyDto, CompanyInformation>().ReverseMap();

            CreateMap<PersonalInformation, PersonelDtoGet>();
            CreateMap<PersonelDto, PersonalInformation>().ReverseMap();

            CreateMap<HrAutho, HrAuthoDtoGet>().ReverseMap();
            
        }
    }
}
