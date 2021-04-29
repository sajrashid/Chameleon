using BlazorSignalR.Server.DbContexts;
using ConfigShared.Extensions.Swagger;
using ConfigShared.Extensions.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using System.IO;
using System.Linq;

namespace BlazorSignalR.Server
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });


            services.AddControllersWithViews();
            services.AddDbContext<UserDbContext>(options =>
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            // I think this was pre-Core3.x
            //services.AddMvc();
            services.AddSignalR();
            // add Swagger
            services.AddSwaggerConfig();
            // Register the Swagger generator, defining 1 or more Swagger documents

            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseStaticFiles();

            app.UseLoggerConfig(env);
            // Enable middleware to serve generated Swagger as a JSON endpoint.

            // enable swagger
            app.UseSwaggerConfig();


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                // SignalR endpoint routing setup
                endpoints.MapHub<Hubs.ChatHub>(Shared.ChatClient.HUBURL);

                endpoints.MapFallbackToFile("index.html");  // preview2 change
            });
        }

    }
}
