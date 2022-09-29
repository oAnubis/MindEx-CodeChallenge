using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CodeChallenge.Data;
using CodeChallenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly EmployeeContext _employeeContext;

        private readonly ILogger<ICompensationRepository> _logger;

        public CompensationRepository(ILogger<ICompensationRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _employeeContext.Employees.Load();
            _logger = logger;
        }

        public Compensation Create(Compensation compensation)
        {
            compensation.CompensationId = Guid.NewGuid().ToString();
            _employeeContext.Compensation.Add(compensation);
            return compensation;
        }

        public Compensation GetCompensationById(string id)
        {
            return _employeeContext.Compensation.SingleOrDefault(
                c => c.Employee.EmployeeId == id);
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }
    }
}
