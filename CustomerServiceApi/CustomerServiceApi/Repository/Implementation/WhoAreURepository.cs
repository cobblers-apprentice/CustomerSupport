using CustomerServiceApi.Models;
using CustomerServiceApi.Utility;
using System.Security.Cryptography;

namespace HabitTracker.Repository.RepositoryImplementation
{
    public class WhoAreURepository : IWhoAreURepository
    {
        public readonly DbContextData _dbContext;

        public WhoAreURepository(DbContextData dBContext)
        {
            _dbContext = dBContext;
        }

        public User? CheckUser(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

            return user == null ? null: user;

        }
        public User? CheckUserById(int? userId)
        {
            if (userId == null)
                return null;

            var user = _dbContext.Users.FirstOrDefault(u => u.UserID == userId);

            return user == null ? null : user;

        }

        public bool CurrentUser (User user)
        {
            var username = _dbContext.Users.FirstOrDefault(u => u.UserName == user.UserName);
            var email = _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);

            if (username != null || email != null)
            {
                return false;
            }
            else
                return true;
        }

        public bool CurrentUserById(User user)
        {
            var Id = _dbContext.Users.FirstOrDefault(u => u.UserID == user.UserID);
            if (Id != null)
            {
                return false;
            }
            else
                return true;
        }
    }
}
