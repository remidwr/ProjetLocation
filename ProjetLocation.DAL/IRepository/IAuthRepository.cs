using ProjetLocation.DAL.Models;

namespace ProjetLocation.DAL.IRepository
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);
        int Register(User user);
    }
}
