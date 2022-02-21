using CleanMOQasine.Business.Models;
using CleanMOQasine.Business.Security;
using CleanMOQasine.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Tests.ServiceTests
{
    public class AuthServiceTestData
    {
        public string ValidPassword = "у2меня2сложный8пароль";
        public User GetUserForTests()
        {
            return new User
            {
                FirstName = "Андрей",
                LastName = "Талашев",
                Email = "andryuXa@mail.ru",
                Login = "WaspionVoronezh",
                PhoneNumber = "228",
                Password = PasswordHash.HashPassword(ValidPassword),
                Role = Data.Enums.Role.Admin
            };
        }
    }
}
