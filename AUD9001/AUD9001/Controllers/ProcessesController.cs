using AUD9001.DataAccess.Entities;
using AUD9001.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AUD9001.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessesController : ControllerBase
    {
        private readonly IRepository<Process> processRepository;
        public ProcessesController(IRepository<Process> processRepository)
        {
            this.processRepository = processRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Process> GetAllProcesses() => this.processRepository.GetAll();

        [HttpGet]
        [Route("{processId}")]
        public Process GetProcessById(int processId) => this.processRepository.GetById(processId);
    }
}
