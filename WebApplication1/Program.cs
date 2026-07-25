using WebApplication1.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
//Constants
const string GetGameByIdEndpointName = "GetGameById";

List<GameDto> games = [
    new (1, "Madden 2023", "EA", 49.99m, new DateOnly(2023, 9, 25)),
    new (2, "FIFA 2023", "EA", 99.99m, new DateOnly(2025, 9, 25)),
    new (3, "NBA 2K23", "2K", 79.99m, new DateOnly(2024, 9, 25)),
    new (4, "Madden 2023", "EA", 89.99m, new DateOnly(2028, 9, 25)),
    new (5, "FIFA 2023", "EA", 47.99m, new DateOnly(2018, 9, 25)),
    new (6, "NBA 2K23", "2K", 59.99m, new DateOnly(2019, 9, 25)),
   
];
///API end point
/// GET - Read data
 app.MapGet("/games", () => games);



//get by id and create route for that created object
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameByIdEndpointName);

/// POST - Create data
app.MapPost("/games", (GamePostDto newGame) =>
{       
    //create game of type gameDto
     GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);
    //add game to the list
    games.Add(game);
    //return jsopong object with the game route
    return Results.CreatedAtRoute(GetGameByIdEndpointName,new { id = game.Id}, game);

});
//update our game 
app.MapPut("/games/{id}", (int id, GamePutDto updatedGame) =>
{   
    //Find game by index
   var index = games.FindIndex(game => game.Id == id);
    //if the game is not found
   if (index == -1)
   {
       return Results.NotFound();
   }
    //Index of that game to update 
    games[index] = new GameDto(id, 
    updatedGame.Name, 
    updatedGame.Genre, 
    updatedGame.Price, 
    updatedGame.ReleaseDate);
   
   return Results.NoContent();

});


//update our game 
app.MapDelete("/games/{id}", (int id) =>
{
    //Find game by index
    var index = games.FindIndex(game => game.Id == id);
    //if the game is not found
    if (index == -1)
    {
        return Results.NotFound();
    }
    //Remove game from list 
    games.RemoveAt(index);

    return Results.NoContent();

});


app.Run();
