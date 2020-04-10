using Gainzville.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System;
using Gainzville.Server.Services;

namespace Gainzville.Server
{
    public class Startup
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the application configration.
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = this.Configuration.GetConnectionString("DefaultConnection");
            var devMode = this.Configuration.GetValue<bool>("DevMode");

            services.AddCors();
            services.AddMvc();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            if (devMode)
            {
                Console.WriteLine("Running in Dev Mode.");

                services.AddSingleton<IGainzService, FakeDataService>();
            }
            else
            {
                Console.WriteLine("Running in Prod Mode.");

                // Create the db context and service in a scoped lifetime for the app
                services.AddDbContext<GainzDbContext>(
                    options => options.UseSqlServer(connectionString),
                    ServiceLifetime.Scoped);
                services.AddTransient<IGainzService, GainzDbService>();
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            var devMode = this.Configuration.GetValue<bool>("DevMode");
            if (!devMode)
            {
                var context = app.ApplicationServices.GetRequiredService<GainzDbContext>();
                context.Database.Migrate();
            }

            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Program>();

            app.UseCors(policy => policy
                .WithOrigins("http://gainzville.co.uk", "http://gainzville.co.uk:80", "http://gainzville.co.uk:5050", "http://localhost", "http://localhost:80", "http://localhost:5050")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Program>("index.html");
            });
        }
    }
}
