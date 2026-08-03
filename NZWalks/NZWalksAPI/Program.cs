using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Look atb the routes and documents them
builder.Services.AddEndpointsApiExplorer();
///COnvet so the documentation meet open ape standards
///generate Swagger documentation in an OpenAPI format.
builder.Services.AddSwaggerGen();

///Inject deContext so it can be used anywh where and provide dbContext 
/// the appplication will manage the instances of the dbContext
builder.Services.AddDbContext<NZWalkDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   // to produce the Swagger JSON document.
    app.UseSwagger();
    //to create a visual interface for browsing and testing endpoints.
    app.UseSwaggerUI();
}

//Middleware
app.UseHttpsRedirection();

//
app.UseAuthorization();

//
app.MapControllers();

app.Run();
