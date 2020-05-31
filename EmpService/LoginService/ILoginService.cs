using EmpService.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmpService
{
    public interface ILoginService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }

    public class LoginService : ILoginService
    {
        readonly string secKey=string.Empty;
        private IConfiguration _config;
        public LoginService(IConfiguration config)
        {
            _config = config;            
        }
        //const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Pankaj", LastName = "Sharma", Username = "pankajjsdm", Password = "test@123" },
            new User { Id = 2, FirstName = "Saurabh", LastName = "Patodi", Username = "saurabh", Password = "test@123" },
            new User { Id = 3, FirstName = "Ravinder", LastName = "Chawla", Username = "rchawla", Password = "test@123" }

        };

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                 Issuer= _config["Jwt:Issuer"],

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
    }
}
