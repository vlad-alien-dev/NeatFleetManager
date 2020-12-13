using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NeatFleetManagement.Presentation.Startup))]
namespace NeatFleetManagement.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
