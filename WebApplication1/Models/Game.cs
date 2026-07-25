using System;

namespace WebApplication1.models;

public class Game
{
    public int Id{get;set;}
    public Genre? genre{get;set;}
    public int GenreId { get; set; } 
    public decimal Price{get;set;}
    public DateOnly dateOnly{get;set;}
}
