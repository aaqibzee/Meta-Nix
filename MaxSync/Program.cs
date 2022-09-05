using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Meta_Nix.Models;
using MaxSync;
using MaxSync.DataProviders;
using Microsoft.Extensions.Hosting;
using MaxSync.Client;
{
    {
        IServiceCollection services = new ServiceCollection();
        var config = GetConfiguration();
        var servieProvider = ConfigureService(config);
        var handler = servieProvider.GetService<SyncHandler>();
        handler.GetAdvertiserIndexData();
    }

    IConfigurationRoot GetConfiguration()
    {
        return new ConfigurationBuilder().SetBasePath
            (
                Directory.GetCurrentDirectory()
            )
            .AddJsonFile
            (
                $"appsettings.json"
            )
            .Build();
    }

    ServiceProvider ConfigureService(IConfigurationRoot configuration)
    {
        IServiceCollection services = new ServiceCollection();
        AddDependencies(services, configuration);
        AddDBContext(services);
        return services.BuildServiceProvider();
    }


    void AddDBContext(IServiceCollection services)
    {
        services.AddDbContext<BucketAlphaContext>((provider, options) =>
        {
            IConfiguration config = provider.GetRequiredService<IConfiguration>();
            options.UseSqlServer
            (
              config.GetConnectionString("DBConnection")
            );
        });
    }

    void AddDependencies(IServiceCollection services, IConfigurationRoot configuration)
    {
        //Example Below
        services.AddSingleton<IConfiguration>(configuration);
        services.AddScoped<IAdvertiserDataProvider, AdvertiserDataProvider>();
        services.AddScoped<IAPIClient, APIClient>();
        services.AddScoped<SyncHandler, SyncHandler>();
    }

}