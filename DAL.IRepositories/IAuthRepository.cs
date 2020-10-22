using DAL.Models;

namespace DAL.IRepositories
{
    public interface IAuthRepository
    {
        User Login(string email, string passwd);
        void Register(User user);
    }
}
