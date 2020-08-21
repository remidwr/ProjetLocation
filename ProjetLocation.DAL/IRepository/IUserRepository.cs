namespace ProjetLocation.DAL.IRepository
{
    public interface IUserRepository<TUser>
    {
        TUser Login(string email, string passwd);
        int Register(TUser user);
    }
}
