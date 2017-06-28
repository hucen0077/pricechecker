using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrickCheckerSolutions.Startup))]
namespace PrickCheckerSolutions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
