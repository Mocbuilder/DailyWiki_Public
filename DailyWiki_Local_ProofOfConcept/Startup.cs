﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DailyWiki_Local_ProofOfConcept;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using DailyWiki_Local_ProofOfConcept;


namespace DailyWiki_Local_ProofOfConcept
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddScoped<rticleLogEntry>();
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configure your app's middleware here
        }
    }
}
