using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPi.Data;
using webAPi.Dtos;
namespace webAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrolContoller : ControllerBase
    {
        private readonly IAppRepository _repo;
        private readonly IMapper _mapper;
        public PayrolContoller(IAppRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]

        public async Task<IActionResult> ProcessPayRoll(DateTime date)
        {
            
            return Ok(result);
        }
    }
}
