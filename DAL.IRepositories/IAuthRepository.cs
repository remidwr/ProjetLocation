namespace DAL.IRepositories
{
    public interface IAuthRepository<TUser>
    {
        TUser Login(string email, string passwd);
        void Register(TUser user);
    }
}
