using AutoMapper;
using HrPlatform.Entities.Company;
using HrPlatform.Entities.DTO;
using HrPlatform.Entities.Employees;
using HrPlatform.Entities.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HrPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITitleInformationService _service;


        public TitleController(IMapper mapper, ITitleInformationService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<List<TitleDto>> All()
        {
            var titleInf = await _service.GetAllAsync();
            var titleInfDto = _mapper.Map<List<TitleDto>>(titleInf.ToList());
            return titleInfDto;
        }

        [HttpPost]
        public async Task Save(TitleDto titledto)
        {
            await _service.AddAsync(_mapper.Map<TitleInformation>(titledto));

        }

        [HttpGet("findTitle{titleId}")]
        public async Task<TitleDto> GetById(Guid titleId) //returns only 1 company information
        {
            var title = await _service.GetbyIdAsync(titleId);
            var titleDto = _mapper.Map<TitleDto>(title);
            return titleDto;

        }

        [HttpGet("findPerson/{titleId}")]
        public async Task<ActionResult<PersonelDto>> GetPersonAsync(Guid titleId)
        {
            var person = await _service.GetPersonAsync(titleId);
            var personDto = _mapper.Map<PersonelDto>(person);
            return personDto;

        }
    }
}
