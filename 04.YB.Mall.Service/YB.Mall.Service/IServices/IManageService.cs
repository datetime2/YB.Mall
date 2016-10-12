using YB.Mall.Model;

namespace YB.Mall.Service
{
    public interface IManageService
    {
        ManageInfo Login(string username, string password);
    }
}