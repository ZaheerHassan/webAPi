using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPi.Data;
using webAPi.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLogController : ControllerBase

    {

        private readonly IAppRepository _repo;
        private readonly IMapper _mapper;
        public WorkLogController(IAppRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkLog(InsertWorkLogDto workLogDto)
        {
           
            var WorkLog = _mapper.Map<Model.WorkLog>(workLogDto);
            _repo.Add(WorkLog);
            var result = await _repo.SaveAll();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkLogs()
        {
            var WorkLogs = await _repo.GetWorkLogs();
            return Ok(WorkLogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkLog(int id)
        {
            var WorkLogs = await _repo.GetWorkLogbyID(id);
            return Ok(WorkLogs);
        }

        public Boolean ValidateWorkLog(Model.WorkLog workLog)
        {
            bool Ret = true;
            Model.Employee employee =  _repo.GetEmployee(workLog.EmployeeId).Result;
            if (workLog.EmployeeId < 1 )   Ret = false;

            return Ret;

        }
    }
}
