using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CleanMOQasineContext _dbContext;

        public UserRepository(CleanMOQasineContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? GetUserById(int id) => _dbContext.Users.FirstOrDefault(u => u.Id == id);

        public List<User> GetUsers() => _dbContext.Users.Where(u => !u.IsDeleted).ToList();

        public User? GetUserByLogin(string login) => _dbContext.Users.FirstOrDefault(u => u.Login == login);

        public User? GetUserByEmail(string email) => _dbContext.Users.FirstOrDefault(u => u.Email == email);

        public int AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
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

        public List<User> GetCleaners(List<CleaningAddition> cleaningAdditions, DateTime orderDate, TimeSpan duration)
        {
            var conditions = new List<Func<User, bool>>()
            {
                // Выбираем неудаленных
                new Func<User, bool>(u => !u.IsDeleted),
                // Выбираем только клинеров
                new Func<User, bool>(u => u.Role == Enums.Role.Cleaner),
                // Выбираем тех кто работает в это время
                new Func<User, bool>(u => u.WorkingHours
                .Where(h => (int)h.Day % 7 == (int)orderDate.DayOfWeek)
                .ToList()
                .TrueForAll(h => h.StartTime <= TimeOnly.FromDateTime(orderDate)
                    && h.EndTime >= TimeOnly.FromDateTime(orderDate + duration))),
                // Выбираем тех кто не занят в это время
                new Func<User, bool>(u => u.CleanerOrders
                .Select(o => o.Date)
                .ToList()
                .TrueForAll(o => o != orderDate)),
                //поиск по способностям
                new Func<User, bool>(u => cleaningAdditions.TrueForAll(c => u.CleaningAdditions.Contains(c)))

            };
            return GetUsersByConditions(conditions);
        }

        private List<User> GetUsersByConditions(List<Func<User, bool>> conditions) =>
           _dbContext.Users.ToList().Where(u => conditions.TrueForAll(condition => condition(u))).ToList();

    }
}
