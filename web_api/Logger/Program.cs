using Serilog;

//builder configuration
var builder = WebApplication.CreateBuilder(args);

//Congigure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//
var app = builder.Build();

// Configure the HTTP request pipeline.

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        //catch the exp
        Console.WriteLine(ex.Message);
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync(ex.Message);
    }
});

app.UseRouting();
app.MapControllers();




app.Run();


