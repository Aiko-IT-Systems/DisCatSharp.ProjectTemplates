using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace DisCatSharpWebHost
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            /*
                Please use the Provided Bot Project Template for adding however many
                Bots you need

                For each of those projects, you will note a ServiceCollectionExtensions class.
                This contains the extension methods needed to add the bot into our web-app environment!

                Please be sure to add a reference to the project(s).
                Example of what it could look like (It should be matter of replacing 'Bot' with 
                whatever you called your bot project
                
                (add the using statement for your bot project)
                using Bot;

                builder.Services.AddBotServices(); 
             */
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // Can map your stuff here
                // WIP for supporting the various
                // web app types (MVC / API / Blazor)
            });
        }
    }
}
