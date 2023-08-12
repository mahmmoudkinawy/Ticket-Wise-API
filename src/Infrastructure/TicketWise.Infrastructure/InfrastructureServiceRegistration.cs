namespace TicketWise.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services)
    {
        services.AddTransient<ICsvExporter, CsvExporter>();

        return services;
    }
}
