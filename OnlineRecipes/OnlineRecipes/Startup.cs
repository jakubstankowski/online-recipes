using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineRecipes.Startup))]
namespace OnlineRecipes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
