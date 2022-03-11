using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public interface IUserRepository
    {
        int AddUser(User user);
        User? GetUserById(int id);
        User? GetClientById(int id);
        User? GetUserByLogin(string login);
        User? GetUserByEmail(string email);
        List<User> GetUsers();
        void UpdateUser(int id, bool isDeleted);
        void UpdateUser(User user);
        List<User> GetCleaners(List<CleaningAddition> cleaningAdditions, DateTime orderDate, TimeSpan duration);

    }
}