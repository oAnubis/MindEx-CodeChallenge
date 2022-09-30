using System.Threading.Tasks;
using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository)
        {
            _compensationRepository = compensationRepository;
            _logger = logger;
        }

        public Compensation Create(Compensation compensation)
        {
            if (compensation != null)
            {
                _compensationRepository.Create(compensation);
                SaveAsync().Wait();
            }

            return null;
            
        }

        public Compensation GetCompensationById(string id)
        {
            return _compensationRepository.GetCompensationById(id);
        }

        public Task SaveAsync()
        {
            return _compensationRepository.SaveAsync();
        }
    }
}
