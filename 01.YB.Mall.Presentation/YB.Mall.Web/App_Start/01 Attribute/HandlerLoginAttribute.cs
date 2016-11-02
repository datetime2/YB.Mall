using System.Linq;
using System.Web.Mvc;
using YB.Mall.Extend.Operator;
namespace YB.Mall.Web
{
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        private readonly bool _ignore;
        public HandlerLoginAttribute(bool ignore = true)
        {
            _ignore = ignore;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute),false).Any())
            //    return;
            if (!_ignore) return;
            if (OperatorProvider.Provider.GetCurrent() != null) return;
            filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
            return;
        }
    }
}