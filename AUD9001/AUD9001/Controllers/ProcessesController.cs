using AUD9001.DataAccess.Entities;
using AUD9001.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AUD9001.ApplicationServices.API.Domain;

namespace AUD9001.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProcessesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProcesses([FromQuery] GetProcessesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        //below part to furhter refinement
        [HttpGet]
        [Route("{processId}")]
        public async Task<IActionResult> GetProcessById([FromQuery] GetProcessesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
    //oldversion
    //[ApiController]
    //[Route("[controller]")]
    //public class ProcessesController : ControllerBase
    //{
    //    private readonly IRepository<Process> processRepository;
    //    public ProcessesController(IRepository<Process> processRepository)
    //    {
    //        this.processRepository = processRepository;
    //    }

    //    [HttpGet]
    //    [Route("")]
    //    public IEnumerable<Process> GetAllProcesses() => this.processRepository.GetAll();

    //    [HttpGet]
    //    [Route("{processId}")]
    //    public Process GetProcessById(int processId) => this.processRepository.GetById(processId);
    //}
}
