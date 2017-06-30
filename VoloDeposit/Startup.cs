using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VoloDeposit.Startup))]
namespace VoloDeposit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
