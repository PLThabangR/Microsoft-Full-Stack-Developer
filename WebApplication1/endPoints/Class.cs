using System;
using System.Collections.Generic;
using WebApplication1.Dtos;

namespace WebApplication1.endPoints;

public static class Class
{
    const string GetGameByIdEndpointName = "GetGameById";

    // Using List initialization with proper syntax
    private static List<GameDto> games = new List<GameDto>
    {
        new GameDto(1, "Madden 2023", "EA", 49.99m, new DateOnly(2023, 9, 25)),
        new GameDto(2, "FIFA 2023", "EA", 99.99m, new DateOnly(2025, 9, 25)),
        new GameDto(3, "NBA 2K23", "2K", 79.99m, new DateOnly(2024, 9, 25)),
        new GameDto(4, "Madden 2023", "EA", 89.99m, new DateOnly(2028, 9, 25)),
        new GameDto(5, "FIFA 2023", "EA", 47.99m, new DateOnly(2018, 9, 25)),
        new GameDto(6, "NBA 2K23", "2K", 59.99m, new DateOnly(2019, 9, 25)),
    };

    public static void MapGamesEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/games"); // Better to prefix with /api

        // GET all games
        group.MapGet("/", () => games);

        // GET game by ID
        group.MapGet("/{id}", (int id) =>
        {
            var game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName(GetGameByIdEndpointName);

        // POST - Create new game
        group.MapPost("/", (GamePostDto newGame) =>
        {
            var game = new GameDto(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );

            games.Add(game);

            return Results.CreatedAtRoute(
                GetGameByIdEndpointName,
                new { id = game.Id },
                game
            );
        });

        // PUT - Update game
        group.MapPut("/{id}", (int id, GamePutDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });

        // DELETE - Remove game
        group.MapDelete("/{id}", (int id) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games.RemoveAt(index);
            return Results.NoContent();
        });
    }
}