using CustomerServiceApi.Models;

namespace HabitTracker.Service.ServiceInterface
{
    public interface IWhoAreUService
    {
        public string GenerateJwtToken(string username, int userId);
        public User? CheckUser(string username, string password);        
    }
}
