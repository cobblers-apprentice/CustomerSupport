using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using CustomerServiceApi.Models;
using HabitTracker.Repository.RepositoryImplementation;
using HabitTracker.Service.ServiceInterface;
using Microsoft.IdentityModel.Tokens;

namespace HabitTracker.Service.ServiceImplementation
{
    public class WhoAreUService : IWhoAreUService
    {
        private readonly string _secretKey;
        private readonly IWhoAreURepository _whoAreURepository;


        public WhoAreUService(string secretKey, IWhoAreURepository whoAreURepository)
        {
            _secretKey = secretKey;
            _whoAreURepository = whoAreURepository;
        }

        public string? GenerateJwtToken(string username, int userId)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
        };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_secretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1), 
                SigningCredentials = creds,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }

        public User? CheckUser(string username, string password)
        {
            var user = _whoAreURepository.CheckUser(username, password);
            if (user == null)
            {
                return null;
            }

            var enteredPasswordBytes = Encoding.UTF8.GetBytes(password);


            bool isPasswordValid = VerifyPassword(enteredPasswordBytes, user.Salt, user.Hash);

            if (isPasswordValid)
            {
                return user;
            }

            return null;
        }

        private static byte[] GenerateSaltedHash(byte[] input, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(input, salt, 10000, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32);
            }
        }



        public bool VerifyPassword(byte[] enteredPasswordBytes, byte[] salt, byte[] storedHash)
        {
            var computedHash = GenerateSaltedHash(enteredPasswordBytes, salt);

            return StructuralComparisons.StructuralEqualityComparer.Equals(computedHash, storedHash);
        }
        public (byte[] hash, byte[] salt) GenerateSaltedHashPassword(string password)
        {
            var salt = Guid.NewGuid().ToByteArray();
            var hash = GenerateSaltedHash(Encoding.UTF8.GetBytes(password), salt);
            return (hash, salt);
        }              
    }
}