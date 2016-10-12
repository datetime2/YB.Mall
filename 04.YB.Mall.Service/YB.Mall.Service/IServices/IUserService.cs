using YB.Mall.Model;

namespace YB.Mall.Service
{
    public interface IUserService
    {
        UserInfo Register(UserInfo user);
        UserInfo Login(string username, string password);
    }
}