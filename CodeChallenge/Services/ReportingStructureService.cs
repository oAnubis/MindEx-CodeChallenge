using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<ReportingStructureService> _logger;

        public ReportingStructureService(ILogger<ReportingStructureService> logger, IEmployeeRepository reportingRepository)
        {
            _employeeRepository = reportingRepository;
            _logger = logger;
        }

        public ReportingStructure GetById(string id)
        {
            
            if (!String.IsNullOrEmpty(id)) 
                return _employeeRepository.RetrieveReportingStructure(id);

            return null;
        }

    }
}
