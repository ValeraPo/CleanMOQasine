using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public class UserRepository
    {
        private readonly CleanMOQasineContext _dbContext;


        public User? GetUserById(int id) => _dbContext.Users.FirstOrDefault(u => u.Id == id);

        public List<User> GetUsers() => _dbContext.Users.Where(u => !u.IsDeleted).ToList();

        public User? GetUserByLogin(string login) => _dbContext.Users.FirstOrDefault(u => u.Login == login);

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var entity = GetUserById(user.Id);
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Login = user.Login;
            entity.PhoneNumber = user.PhoneNumber;
            entity.Rank = user.Rank;
            _dbContext.SaveChanges();
        }

        public void UpdateUser(int id, bool isDeleted)
        {
            var user = GetUserById(id);
            user.IsDeleted = isDeleted;
            _dbContext.SaveChanges();
        }
    }
}
