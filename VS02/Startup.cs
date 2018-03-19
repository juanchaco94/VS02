using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VS02.Startup))]
namespace VS02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
