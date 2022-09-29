using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Models;
using System;


namespace CodeChallenge.Controllers
{
    [Route("api/reportingStructure")]
    public class ReportingStructureController : Controller
    {
        private readonly ILogger _logger;

        private readonly IReportingStructureService _reportingStructureService;

        public ReportingStructureController(ILogger<ReportingStructureController> logger, IReportingStructureService reportingService)
        {
            _logger = logger;
            _reportingStructureService = reportingService;
        }

        [HttpGet("{id}", Name = "getReportingStructureById")]
        public IActionResult GetReportingStructureById(String id)
        {
            _logger.LogDebug($"Received reporting structure request for '{id}'");

            var reports = _reportingStructureService.GetById(id);

            if (reports == null)
                return NotFound();

            return Ok(reports);
        }
    }
}