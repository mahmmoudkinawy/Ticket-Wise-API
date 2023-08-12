namespace TicketWise.Api.Extensions;
public static class StartupExtensions
{
    public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApplicationServices();

        builder.Services.AddPersistenceServices(builder.Configuration);

        builder.Services.AddInfrastructureServices();

        return builder.Build();
    }

    public static WebApplication ConfigureMiddleware(
        this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        return app;
    }

    public static async Task ApplyMigrationsAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TicketWiseDbContext>();

        try
        {
            await dbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError("An error occurred while applying pending migrations.", ex.Message);
        }
    }

}
