using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Json2Csharp.js.Startup))]
namespace Json2Csharp.js
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
