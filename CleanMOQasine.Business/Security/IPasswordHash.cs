namespace CleanMOQasine.Business.Security
{
    public interface IPasswordHash
    {
        string HashPassword(string password);
        bool ValidatePassword(string password, string correctHash);
    }
}