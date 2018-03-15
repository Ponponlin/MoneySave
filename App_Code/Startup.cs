using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoneySave.Startup))]
namespace MoneySave
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
