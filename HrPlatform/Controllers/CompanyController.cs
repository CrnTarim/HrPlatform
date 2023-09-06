using AutoMapper;
using HrPlatform.Entities.Company;
using HrPlatform.Entities.DTO;
using HrPlatform.Entities.Employees;
using HrPlatform.Entities.Service;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;


namespace HrPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyInformationService _service;

        public CompanyController(IMapper mapper, ICompanyInformationService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<List<CompanyInformation>> All()
        {
            var personInf = await _service.GetAllAsync();
            return personInf.ToList();

        }

        //[HttpGet("getCompanyDto{id}")]
        //public async Task<CompanyDto> GetByIdDto(Guid id) 
        //{
        //    var company = await _service.GetbyIdAsync(id);
        //    var companyDto = _mapper.Map<CompanyDto>(company);
        //    return companyDto;

        //}

        [HttpGet("getCompany{id}")] // bunu değiştin en son action ve ok ekledin
        public async Task<ActionResult<CompanyInformation>> GetById(Guid id)
        {
            var company = await _service.GetbyIdAsync(id);
            return Ok(company);

        }

        [HttpGet("getbyemail")]
        public async Task<ActionResult<string>> GetCompanyIdByEmail(string email)
        {
            try
            {
                var companyInfo = await _service.GetbyMailAsync(email);

                if (companyInfo != null)
                {
                    return Ok(companyInfo.CompanyId);
                }
                else
                {
                    return NotFound("Şirket bilgisi bulunamadı");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task Save(CompanyDto companydto)
        {
            await _service.AddAsync(_mapper.Map<CompanyInformation>(companydto));
        }

        [HttpPost("mail")]
        public IActionResult SendEmail(string body, string recipientEmail)
        {

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("crntrim@gmail.com"));
            email.To.Add(MailboxAddress.Parse(recipientEmail));

            email.Subject = "Email Confirmation";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("crntrim@gmail.com", "yzlijnhvqjrbipwl");

            smtp.Send(email);

            smtp.Disconnect(true);

            return Ok();

        }



        [HttpGet("[action]/{companyId}")]
        public async Task<ActionResult<List<TitleDto>>> GetCompanyTitleAsync(Guid companyId)
        {
            var titles = await _service.GetAllTitle(companyId);
           
            return Ok(titles);
        }

    }
}
