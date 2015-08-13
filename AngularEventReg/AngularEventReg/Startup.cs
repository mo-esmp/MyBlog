using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AngularEventReg.Startup))]
namespace AngularEventReg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
