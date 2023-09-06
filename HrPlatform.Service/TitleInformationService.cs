using AutoMapper;
using HrPlatform.Entities.Employees;
using HrPlatform.Entities.IUnitOfWork;
using HrPlatform.Entities.Repositories;
using HrPlatform.Entities.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Service
{
    public class TitleInformationService : Services<TitleInformation>, ITitleInformationService
    {
        private readonly ITitleInformationRepository _titleRepository;
        private readonly IMapper _mapper;
        public TitleInformationService(IGenericRepository<TitleInformation> repository, IUnitOfWork unitOfWork, ITitleInformationRepository titleRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
        }

        public async Task<PersonalInformation> GetPersonAsync(Guid id)
        {
            return await _titleRepository.GetPersonAsync(id);
        }
    }
}
