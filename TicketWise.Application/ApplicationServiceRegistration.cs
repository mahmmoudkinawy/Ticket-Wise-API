namespace TicketWise.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
    {
        // Don't forget to register fluent validation

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}
