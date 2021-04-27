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
    public class EmployeeController : ControllerBase
    {
        private readonly IAppRepository _repo;
        private readonly IMapper _mapper;
        public EmployeeController(IAppRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]

        public async Task<IActionResult> CreateEmpoyee(EmployeeToCreateDto EmployeeToCreate)
        {
            var EmployeeToCreateRepo = _mapper.Map<Model.Employee>(EmployeeToCreate);
         
            
            _repo.Add(EmployeeToCreateRepo);
           var result= await _repo.SaveAll();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpoyee()
        {
           var EmployeesFromRepo= await  _repo.GetEmployees();
            return Ok(EmployeesFromRepo);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int Id)
        {
            var employee = await _repo.GetEmployee(Id);
            var employeesDetail = _mapper.Map<EmployeeDetailDto>(employee);
            return Ok(employeesDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpoyee(int id)
        {
            var EmployeeFromRepo = _repo.GetEmployee(id);
            if (EmployeeFromRepo != null)
            {
                _repo.Delete(EmployeeFromRepo.Result);
              var result= await _repo.SaveAll();
                return Ok("Employee Deleted!");
           
            }
            else
            {
                return BadRequest("Employee doesn't exist!");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeToUpdateDto EmployeeToUpdateDto)
        {

            var EmployeeFromRepo = await _repo.GetEmployee(id);
            _mapper.Map(EmployeeToUpdateDto, EmployeeFromRepo);
            if (await _repo.SaveAll())
                return Ok();
            throw new Exception($"Updating user {id} failed in save");
        }

    }
}
