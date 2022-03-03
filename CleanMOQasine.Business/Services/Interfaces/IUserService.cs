using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface IUserService
    {
        void RegisterNewClient(UserModel userModel);
        void CheckUser(UserModel userModel);
        bool CheckIfLoginExists(string login);
        bool CheckIfEmailExists(string email);
        void AddUser(UserModel userModel);
        void DeleteUserById(int id);
        List<UserModel> GetAllAdmins();
        List<UserModel> GetAllCleaners();
        List<UserModel> GetAllClients();
        UserModel GetUserById(int id);
        void RestoreUserById(int id);
        void UpdateUser(int id, UserModel userModel);
        void AddWorkingTime(WorkingTimeModel workingTimeModel, int userId);

    }
}