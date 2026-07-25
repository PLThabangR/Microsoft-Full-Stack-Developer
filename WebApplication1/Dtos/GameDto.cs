using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos;

public record class GameDto(int Id, string Name,
 string Genre,
  decimal Price,
   DateOnly ReleaseDate);

