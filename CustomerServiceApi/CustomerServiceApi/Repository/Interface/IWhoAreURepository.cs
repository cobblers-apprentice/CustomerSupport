
using CustomerServiceApi.Models;

namespace HabitTracker.Repository.RepositoryImplementation
{
    public interface IWhoAreURepository
    {
        public User? CheckUser(string username, string password);
        public bool CurrentUser(User user);
        public bool CurrentUserById(User user);
        public User? CheckUserById(int? userId);

    }
}