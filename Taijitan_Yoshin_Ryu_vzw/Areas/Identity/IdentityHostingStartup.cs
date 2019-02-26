using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taijitan_Yoshin_Ryu_vzw.Data;

[assembly: HostingStartup(typeof(Taijitan_Yoshin_Ryu_vzw.Areas.Identity.IdentityHostingStartup))]
namespace Taijitan_Yoshin_Ryu_vzw.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}