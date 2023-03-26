using BasicCrudApp.DataLayers.Repositories;
using BasicCrudApp.Services;

namespace BasicCrudApp.Settings
{
    public static class Dependencies
    {
        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<RealEstateService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<RealEstateRepository>();
        }
    }

}
