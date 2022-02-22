﻿using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface IUserService
    {
        void AddUser(UserModel userModel);
        void DeleteUserById(int id);
        List<UserModel> GetAllAdmins();
        List<UserModel> GetAllCleaners();
        List<UserModel> GetAllClients();
        UserModel GetUserById(int id);
        UserModel GetUserByLogin(string login);
        void RestoreUserById(int id);
        void UpdateUser(int id, UserModel userModel);
        void AddWorkingTime(WorkingTimeModel workingTimeModel, int userId);

    }
}