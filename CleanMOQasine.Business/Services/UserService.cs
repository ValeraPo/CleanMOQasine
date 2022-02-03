using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Repositories;

namespace CleanMOQasine.Business.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public List<UserModel> GetAllAdmins()
        {
            var users = _userRepository.GetUsers();
            return AutoMapperToData.GetInstance().Map<List<UserModel>>(users).Where(u => u.Role == 1).ToList();
        }

        public List<UserModel> GetAllCleaners()
        {
            var users = _userRepository.GetUsers();
            return AutoMapperToData.GetInstance().Map<List<UserModel>>(users).Where(u => u.Role == 2).ToList();
        }

        public List<UserModel> GetAllClients()
        {
            var users = _userRepository.GetUsers();
            return AutoMapperToData.GetInstance().Map<List<UserModel>>(users).Where(u => u.Role == 3).ToList();
        }
    }
}
