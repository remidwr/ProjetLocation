namespace DAL.IRepositories
{
    public interface IUserRepository<TUser> : IGenericRepository<TUser>
    {
        int UpdatePassword(int id, TUser user);
    }
}
