using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using webAPi.Data;
using webAPi.Dtos;
using webAPi.Model;

namespace webAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthController(IAuthRepository repo, IConfiguration config,IMapper mapper)
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
        }
        
        [HttpPost("register")]
  
        public async Task<IActionResult> Register(UserToRegisterDto userToRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userToRegisterDto.Username = userToRegisterDto.Username.ToLower();
            if (await _repo.UserExist(userToRegisterDto.Username))
                return BadRequest("User Name already Exists");
            var userToCreate = _mapper.Map<User>(userToRegisterDto);
            var Createduser= await _repo.Register(userToCreate, userToRegisterDto.Password);
            return StatusCode(201);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserToLginDto userToLginDto)
        {

            var UserFromRepo = await _repo.Login(userToLginDto.Username, userToLginDto.Password);
            if (UserFromRepo == null)
                return Unauthorized();

            var claim = new[]
            {
            new  Claim(ClaimTypes.NameIdentifier,UserFromRepo.Id.ToString()),
            new Claim(ClaimTypes.Name, UserFromRepo.UserName)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSetting:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred,
            };

            var user = _mapper.Map<UserForDetailDto>(UserFromRepo);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token),user});
            }
       
        }
    
    }

