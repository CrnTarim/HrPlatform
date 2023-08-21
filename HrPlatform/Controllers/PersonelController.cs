using AutoMapper;
using HrPlatform.Entities.DTO;
using HrPlatform.Entities.Employees;
using HrPlatform.Entities.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<PersonalInformation> _service;

        public PersonelController(IMapper mapper, IService<PersonalInformation> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<List<PersonelDto>> All()
        {
            var personInf = await _service.GetAllAsync();
            var personInfDto = _mapper.Map<List<PersonelDto>>(personInf.ToList());
            return personInfDto;
        }

        [HttpPost]
        public async Task Save(PersonelDto personInformationDto)
        {
            
            await _service.AddAsync(_mapper.Map<PersonalInformation>(personInformationDto));

        }
    }
}
