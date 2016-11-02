using System.Web.Mvc;
using YB.Mall.Extend;
using YB.Mall.Extend.Helper;
using YB.Mall.Extend.Log;

namespace YB.Mall.Web
{
    public class HandlerErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            context.Result = new ContentResult { Content = new AjaxResult { state = ResultType.error.ToString(), message = context.Exception.Message }.ToJson() };
        }
        private void WriteLog(ExceptionContext context)
        {
            if (context == null)
                return;
            Log.Error(context.Exception);
        }
    }
}