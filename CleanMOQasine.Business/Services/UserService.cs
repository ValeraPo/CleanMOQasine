﻿using AutoMapper;
using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Models;
using CleanMOQasine.Data.Entities;
using CleanMOQasine.Data.Enums;
using CleanMOQasine.Data.Exceptions;
using CleanMOQasine.Data.Repositories;

namespace CleanMOQasine.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _autoMapper;

        public UserService(IMapper autoMapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _autoMapper = autoMapper;
        }

        public UserModel GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            CheckUser(user, id);
            return _autoMapper.Map<UserModel>(user);
        }

        public UserModel GetUserByLogin(string login)
        {
            var user = _userRepository.GetUserByLogin(login);

            if (user is null)
                throw new NotFoundException($"Пользователь с логином '{login}' не найден");

            return _autoMapper.Map<UserModel>(user);
        }

        public void UpdateUser(int id, UserModel userModel)
        {
            var user = _userRepository.GetUserById(id);
            CheckUser(user, id);
            var mappedUser = _autoMapper.Map<User>(userModel);
            _userRepository.UpdateUser(mappedUser);
        }

        public List<UserModel> GetAllAdmins()
        {
            var users = _userRepository.GetUsers();
            return _autoMapper.Map<List<UserModel>>(users).Where(u => u.Role == Role.Admin).ToList();
        }

        public List<UserModel> GetAllCleaners()
        {
            var users = _userRepository.GetUsers();
            return _autoMapper.Map<List<UserModel>>(users).Where(u => u.Role == Role.Cleaner).ToList();
        }

        public List<UserModel> GetAllClients()
        {
            var users = _userRepository.GetUsers();
            return _autoMapper.Map<List<UserModel>>(users).Where(u => u.Role == Role.Client).ToList();
        }

        public void AddUser(UserModel userModel)
        {
            var mappedUser = _autoMapper.Map<User>(userModel);
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
                throw new NotFoundException($"Пользователь с id = {id} не найден");
        }
    }
}
