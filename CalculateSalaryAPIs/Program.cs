using TestTask.CommonServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureAppServices();

var app = builder.Build();
app.ConfigureMiddleware();
app.Run();
