using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LMSProj2HRL.Startup))]
namespace LMSProj2HRL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
