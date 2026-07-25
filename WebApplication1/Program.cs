using WebApplication1;
using WebApplication1.Dtos;
using WebApplication1.endPoints;

var builder = WebApplication.CreateBuilder(args);

//Use builder to register additional service 
builder.Services.AddValidation();

//Use dependency injection to add DB Context
var connectionString = "Data Source=Games.db";
builder.Services.AddDS<GameStoreConrext>();

// this program is build from here 
var app = builder.Build();




app.MapGamesEndPoints();

app.Run();
