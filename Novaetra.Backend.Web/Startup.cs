using Abp.Owin;
using Microsoft.Owin;
using Novaetra.Backend.Web;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
[assembly: OwinStartup(typeof(Startup))]

namespace Novaetra.Backend.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseAbp();
        }
    }
}