using Microsoft.Owin;
using Owin;
using RemoteHomeServerAPI;

[assembly: OwinStartup(typeof(Startup))]

namespace RemoteHomeServerAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}