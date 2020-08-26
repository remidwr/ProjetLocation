namespace ProjetLocation.API.Models.User
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Passwd { get; set; }
        public bool IsAdmin { get; set; }
        public string Token { get; set; }
    }
}
