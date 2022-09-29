using System;
using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Controllers
{
        [Route("api/compensation")]
    public class CompensationController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<EmployeeController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        [HttpPost]
        public IActionResult CreateCompensationById([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received compensation create request for {compensation.Employee.FirstName} {compensation.Employee.LastName}");

            _compensationService.Create(compensation);

            return CreatedAtRoute("getCompensationById", new { id = compensation.Employee.EmployeeId }, compensation);
        }


        [HttpGet("{id}", Name = "getCompensationById")]
        public IActionResult GetCompensationById(String id)
        {
            _logger.LogDebug($"Received compensation get request for '{id}'");

            var compensation = _compensationService.GetCompensationById(id);

            if (compensation == null)
                return NotFound();
            
            return Ok(compensation);
        }


    }
}
