using Autofac;
using Autofac.Integration.Mvc;
using MyBlog.Data;
using MyBlog.Data.Contracts;
using System.Reflection;

namespace MyBlog.Web
{
    public class AutofacConfig
    {
        public static void InitializeContainer(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //var x = new DataContext();
            builder.RegisterType<DataContext>().As<IQueryableContext>().InstancePerRequest();
            //builder.Register(c => x).InstancePerLifetimeScope();
        }
    }
}