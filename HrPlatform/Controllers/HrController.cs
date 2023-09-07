using AutoMapper;
using HrPlatform.Entities;
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
    public class HrController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<HrAutho> _service;
        public HrController(IMapper mapper, IService<HrAutho> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<List<HrAutho>> All()
        {
            var hrAuthoInf = await _service.GetAllAsync();
            return hrAuthoInf.ToList();
        }

        [HttpPost("register")]
        public async Task<ActionResult<HrAutho>> Register(HrAuthoDto userDto)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);
             
            var user = new HrAutho
            {
                Id = userDto.Id,
                CompanyId = userDto.CompanyId,
                Name = userDto.Name,
                PassWordHash = passwordHash,
                PassWordSalt = passwordSalt
            };

            await _service.AddAsync(user);
            return Ok(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(HrDtoLogin userDto)
        {

            var entity = _service.Where(x => x.Name == userDto.Name).FirstOrDefault();

            if (entity == null)
            {
                return Ok("wrong username");
            }

            if (!VerifyPasswordHash(userDto.Password, entity.PassWordHash, entity.PassWordSalt))
            {
               return Ok("wrong password");
            }
            //return CreatedToken(entity);
            return Ok(entity.Id);
        }

        private string CreatedToken(HrAutho user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name)};

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }


        [HttpGet("getHr{id}")]
        public async Task<ActionResult<string>> GetById(Guid id)
        {
            var company = await _service.GetbyIdAsync(id);
            
            return  Ok(company.CompanyId);
        }

    }
}
