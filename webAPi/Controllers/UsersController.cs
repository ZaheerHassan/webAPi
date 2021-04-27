using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webAPi.Data;
using webAPi.Dtos;
using webAPi.Helpers;

namespace webAPi.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAppRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IAppRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetUsers([FromQuery] UserParams userParams)
        //{
        //    int userID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        //    var userFromRepo = await _repo.GetUser(userID);
        //    userParams.UserId = userID;
        //    if (string.IsNullOrEmpty(userParams.Gender))
        //    {
        //        userParams.Gender = userFromRepo.Gender == "male" ? "female" : "male";
        //    }

        //    var users = await _repo.GetUsers(userParams);
        //    var userToReturn = _mapper.Map<IEnumerable<UserListForDto>>(users);
        //    Response.AddPagination(users.CurrentPage,users.PageSize,users.TotalCount,users.TotalPages);
        //    return Ok(userToReturn);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int Id)
        {
            var user = await _repo.GetUser(Id);
            var userToReturn = _mapper.Map<UserForDetailDto>(user);
            return Ok(userToReturn);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id,UserToUpdateDto userToUpdateDto)
        {
            if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            var userFromRepo = await _repo.GetUser(id);
            _mapper.Map(userToUpdateDto, userFromRepo);
            if (await _repo.SaveAll())
                return NoContent();
            throw new Exception($"Updating user {id} failed in save");
        }

       
    }
}
