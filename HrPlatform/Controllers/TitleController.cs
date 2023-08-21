using AutoMapper;
using HrPlatform.Entities.Company;
using HrPlatform.Entities.DTO;
using HrPlatform.Entities.Employees;
using HrPlatform.Entities.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<TitleInformation> _service;

        public TitleController(IMapper mapper, IService<TitleInformation> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<List<TitleDto>>All()
        {         
            var titleInf = await _service.GetAllAsync();
            var titleInfDto = _mapper.Map<List<TitleDto>>(titleInf.ToList());
            return titleInfDto;
        }

        [HttpPost]
        public async Task Save(TitleDto titleDto)
        {
            await _service.AddAsync(_mapper.Map<TitleInformation>(titleDto));

        }

    }
}
