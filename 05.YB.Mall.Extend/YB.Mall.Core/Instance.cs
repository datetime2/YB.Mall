using YB.Mall.Core.ExtendException;
using YB.Mall.Extend.Log;

namespace YB.Mall.Core
{
    using Autofac;
    using Autofac.Builder;
    using System;
    public class Instance
    {
        public static T Get<T>(string classFullName)
        {
            T local2;
            ContainerBuilder builder = new ContainerBuilder();
            IContainer context = null;
            try
            {
                Type implementationType = Type.GetType(classFullName);
                builder.RegisterType(implementationType).As<T>();
                context = builder.Build(ContainerBuildOptions.None);
                local2 = context.Resolve<T>();
            }
            catch (Exception exception)
            {
                Log.Error(string.Format("{0}实例创建失败{1}", classFullName, exception.Message));
                throw new InstanceCreateException("创建实例异常", exception);
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
            return local2;
        }
    }
}

