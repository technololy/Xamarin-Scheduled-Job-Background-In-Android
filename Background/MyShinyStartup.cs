using Microsoft.Extensions.DependencyInjection;
using Shiny;
using System;
using System.Collections.Generic;
using System.Text;

namespace Background
{
    public class MyShinyStartup : ShinyStartup
    {
        public override void ConfigureServices(IServiceCollection services, IPlatform platform)
        {
            throw new NotImplementedException();
        }
    }
}
