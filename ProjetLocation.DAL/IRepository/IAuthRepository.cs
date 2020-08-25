namespace ProjetLocation.DAL.IRepository
{
    public interface IAuthRepository<TUser>
    {
        TUser Login(string email, string passwd);
        int Register(TUser user);
    }
}
