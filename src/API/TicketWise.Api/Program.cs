var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices()
    .ConfigureMiddleware();

await app.ApplyMigrationsAsync();

await app.RunAsync();
