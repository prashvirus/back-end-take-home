﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Guestlogix.Startup))]

namespace Guestlogix
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
