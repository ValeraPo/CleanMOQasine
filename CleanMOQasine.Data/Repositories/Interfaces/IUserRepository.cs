using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User? GetUserById(int id);
        User? GetUserByLogin(string login);
        List<User> GetUsers();
        void UpdateUser(int id, bool isDeleted);
        void UpdateUser(User user);
        User Login(string login, string password);
    }
}