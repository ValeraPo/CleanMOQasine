using CleanMOQasine.Business.Models;

namespace CleanMOQasine.Business.Services
{
    public interface IUserService
    {
        List<UserModel> GetAllAdmins();
        List<UserModel> GetAllCleaners();
        List<UserModel> GetAllClients();
        UserModel GetUserById(int id);
        void UpdateUser(int id, UserModel userModel);
    }
}