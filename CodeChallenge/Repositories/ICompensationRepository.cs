using CodeChallenge.Models;
using System.Threading.Tasks;

namespace CodeChallenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation Create(Compensation compensation);
        Compensation GetCompensationById(string id);
        Task SaveAsync();
    }
}
