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
        public async Task<List<PersonelDtoGet>> All()
        {
            var personInf = await _service.GetAllAsync();
            var personInfDto = _mapper.Map<List<PersonelDtoGet>>(personInf.ToList());
            return personInfDto;
        }

        [HttpGet("getbyId")]
        public async Task<PersonelDto> GetById(Guid id) //returns only 1 company information
        {
            var person = await _service.GetbyIdAsync(id);
            var personelDto = _mapper.Map<PersonelDto>(person);
            return personelDto;

        }

        [HttpPost]
        public async Task Save(PersonelDto persondto)
        {          
            await _service.AddAsync(_mapper.Map<PersonalInformation>(persondto));
        }

        [HttpPut("updatebyId")]
        public async Task Update(Guid id, PersonelDtoGet personelDto)
        {
            var entity = await _service.GetbyIdAsync(id);
            if (entity != null)
            {
                _mapper.Map(personelDto, entity);
                await _service.UpdateAsync(entity);
            }
        }

        [HttpDelete]
        public async Task Remove(Guid id)
        {
            var personel = await _service.GetbyIdAsync(id);
            await _service.RemoveAsync(personel);
        }
    }
}
