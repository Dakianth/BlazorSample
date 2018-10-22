using BlazorSpa.Client.Services;
using BlazorSpa.Shared;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSpa.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddSingleton<AuthStore>();
            services.AddSingleton<ChatHub>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
