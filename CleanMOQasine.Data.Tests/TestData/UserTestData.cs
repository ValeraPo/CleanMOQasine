using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Tests.TestData
{
    public class UserTestData
    {
        public User GetUserForTests()
        {
            User user = new User
            {
                Id = 23, 
                Email = "bugaga@mail.com", 
                FirstName = "Сергей", 
                LastName = "Бугаев", 
                Login = "Bugai", 
                Password="fhryr352", 
                PhoneNumber ="+7(921)765-45-23", 
                IsDeleted = false, 
                Role = Enums.Role.Client
            };
            return user;
        }


    }
}
