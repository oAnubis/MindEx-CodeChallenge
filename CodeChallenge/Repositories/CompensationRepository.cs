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
        private readonly CompensationContext _compensationContext;

        private readonly ILogger<ICompensationRepository> _logger;

        public CompensationRepository(ILogger<ICompensationRepository> logger, CompensationContext compensationContext)
        {
            _compensationContext = compensationContext;
            _logger = logger;
        }

        public Compensation Create(Compensation compensation)
        {
            // Generate a unique Id for the new compensation (would allow future tracking in databases, this acts as the primary key for the new compensation)
            compensation.CompensationId = Guid.NewGuid().ToString();
            _compensationContext.Compensation.Add(compensation);
            return compensation;
        }

        public Compensation GetCompensationById(string id)
        {
            // This would allow multiple compensations for each employee and pull the most recent or current compensation.
            // Could also add different methods with different linq queries to find later compensation, also possible to add
            // the ability to list all compensations. Would be a fun exercise.
            return _compensationContext.Compensation.OrderByDescending(
                    c => c.EffectiveDate).FirstOrDefault(
                c => c.Employee.EmployeeId == id);
        }

        public Task SaveAsync()
        {
            return _compensationContext.SaveChangesAsync();
        }
    }
}
