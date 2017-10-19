using Autofac;
using Autofac.Integration.Mvc;
using MyBlog.Data;
using MyBlog.Data.Contracts;
using MyBlog.Service.Contracts;
using MyBlog.Service.Implementation;
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
            builder.RegisterType<ContactMessageService>().As<IContactMessageService>().InstancePerRequest();
            builder.RegisterType<MailService>().As<IMailService>().InstancePerRequest();
            builder.RegisterType<PostService>().As<IPostService>().InstancePerRequest();
            builder.RegisterType<TagService>().As<ITagService>().InstancePerRequest();
            //builder.Register(c => x).InstancePerLifetimeScope();
        }
    }
}