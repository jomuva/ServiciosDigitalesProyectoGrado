using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiciosDigitalesProy.Startup))]
namespace ServiciosDigitalesProy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
