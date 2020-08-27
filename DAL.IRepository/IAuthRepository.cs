using DAL.Models;

namespace DAL.IRepository
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);
        int Register(User user);
    }
}
