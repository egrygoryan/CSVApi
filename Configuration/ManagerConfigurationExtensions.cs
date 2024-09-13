namespace CSVApi.Configuration;

public static class ManagerConfigurationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services
        .AddScoped<IManagerRepo, ManagerRepo>()
        .AddTransient<IManagerService, ManagerService>()
        .AddTransient<ICSVService, CSVService>();
}
