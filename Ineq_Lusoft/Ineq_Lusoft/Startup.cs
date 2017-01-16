using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ineq_Lusoft.Startup))]
namespace Ineq_Lusoft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
