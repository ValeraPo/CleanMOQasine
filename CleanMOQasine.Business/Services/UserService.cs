using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Enums;
using CleanMOQasine.Data.Repositories;

namespace CleanMOQasine.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly Mapper _autoMapperInstance;

        public UserService()
        {
            _userRepository = new UserRepository();
            _autoMapperInstance = AutoMapperToData.GetInstance();
        }

        public UserModel GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            return AutoMapperToData.GetInstance().Map<UserModel>(user);
        }

        public UserModel GetUserByLogin(string login)
        {
            var user = _userRepository.GetUserByLogin(login);

            if (user is null)
                throw new Exception($"Пользователь с логином '{login}' не найден");

            return AutoMapperToData.GetInstance().Map<UserModel>(user);
        }

        public void UpdateUser(int id, UserModel userModel)
        {
            var user = _userRepository.GetUserById(id);
            CheckUser(user, id);
            var mappedUser = AutoMapperToData.GetInstance().Map<User>(userModel);
            _userRepository.UpdateUser(mappedUser);
        }

        public List<UserModel> GetAllAdmins()
        {
            var users = _userRepository.GetUsers();
            CheckListOfUsers(users);
            return AutoMapperToData.GetInstance().Map<List<UserModel>>(users).Where(u => u.Role == Role.Admin).ToList();
        }

        public List<UserModel> GetAllCleaners()
        {
            var users = _userRepository.GetUsers();
            CheckListOfUsers(users);
            return AutoMapperToData.GetInstance().Map<List<UserModel>>(users).Where(u => u.Role == Role.Cleaner).ToList();
        }

        public List<UserModel> GetAllClients()
        {
            var users = _userRepository.GetUsers();
            CheckListOfUsers(users);
            return AutoMapperToData.GetInstance().Map<List<UserModel>>(users).Where(u => u.Role == Role.Client).ToList();
        }

        public void AddUser(UserModel userModel)
        {
            var mappedUser = AutoMapperToData.GetInstance().Map<User>(userModel);
            _userRepository.AddUser(mappedUser);
        }

        public void DeleteUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            CheckUser(user, id);
            _userRepository.UpdateUser(id, true);
        }

        public void RestoreUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            CheckUser(user, id);
            _userRepository.UpdateUser(id, false);
        }

        private void CheckUser(User user, int id)
        {
            if (user is null)
                throw new Exception($"Пользователь с id = {id} не найден");
        }

        private void CheckListOfUsers(List<User> users)
        {
            if (users is null) 
                throw new Exception($"В базе данных нет ни одного пользователя");
        }
    }
}
