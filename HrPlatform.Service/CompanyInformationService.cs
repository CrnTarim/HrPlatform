using AutoMapper;
using HrPlatform.Entities.Company;
using HrPlatform.Entities.DTO;
using HrPlatform.Entities.IUnitOfWork;
using HrPlatform.Entities.Repositories;
using HrPlatform.Entities.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Service
{
    public class CompanyInformationService : Services<CompanyInformation>, ICompanyInformationService
    {
        private readonly ICompanyInformationRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyInformationService(IGenericRepository<CompanyInformation> repository, IMapper mapper, IUnitOfWork unitOfWork, ICompanyInformationRepository companyRepository) : base(repository, unitOfWork)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<List<TitleDto>> GetAllTitle(Guid id)
        {
            var titles = await _companyRepository.GetAllTitle(id).ToListAsync();
            var titleDto = _mapper.Map<List<TitleDto>>(titles);
            return titleDto;
        }

        public async Task<CompanyInformation> GetbyMailAsync(string mail)
        {
             return await _companyRepository.GetbyMailAsync(mail);
        }

    }
}
