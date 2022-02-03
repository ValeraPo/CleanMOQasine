using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    internal class UserRepository
    {
        private readonly CleanMOQasineContext _dbContext;

        public UserRepository() => _dbContext = CleanMOQasineContext.GetInstance();

        public User? GetUserById(int id) => _dbContext.User.FirstOrDefault(u => u.Id == id);

        public List<User> GetUsers() => _dbContext.User.Where(u => !u.IsDeleted).ToList();

        public User? GetUserByLogin(string login) => _dbContext.User.FirstOrDefault(u => u.Login == login);

        public void AddUser(User user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var entity = GetUserById(user.Id);
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Login = user.Login;
            entity.PhoneNumber = user.PhoneNumber;
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
