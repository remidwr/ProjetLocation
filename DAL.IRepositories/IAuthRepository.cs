namespace DAL.IRepositories
{
    public interface IAuthRepository<TUser>
    {
        TUser Login(string email, string passwd);
        int Register(TUser user);
    }
}
