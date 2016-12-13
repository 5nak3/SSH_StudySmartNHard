using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SSH_ASPJ.Startup))]
namespace SSH_ASPJ
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
