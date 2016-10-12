using YB.Mall.Model;

namespace YB.Mall.Service
{
    public interface IUserInfoService
    {
        UserInfo Register(UserInfo user);
        UserInfo Login(string username, string password);
    }
}