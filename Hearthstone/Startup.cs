using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Hearthstone.Data;

namespace Hearthstone                                   
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();
            //services.AddDbContextPool<HearthstoneDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("HearthstoneDb"));
            //});


            //services.AddScoped<ICardData, SqlCardData>();
            services.AddSingleton<ICardData, InMemoryCardData>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

           // app.Use(SayHelloMiddleware);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules((Microsoft.AspNetCore.Hosting.IHostingEnvironment)env);
            app.UseCookiePolicy();

            app.UseRouting();
            app.UseEndpoints(e =>
            {
                e.MapRazorPages();
                e.MapControllers();
            });
        }

        // The following function is an exercise on creating my own delegate

        //private RequestDelegate SayHelloMiddleware(RequestDelegate next)
        //{
        //    return async ctx =>
        //    {
        //        if (ctx.Request.Path.StartsWithSegments("/hello"))
        //        {
        //            await ctx.Response.WriteAsync("Hello World!");
        //        }
        //        else
        //        {
        //            await next(ctx);
        //        }
        //    };
        //}
    }
}
