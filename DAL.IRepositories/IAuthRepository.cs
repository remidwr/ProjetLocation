using DAL.Models;

namespace DAL.IRepositories
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);
        int Register(User user);
    }
}
