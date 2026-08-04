using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Models.Dtos
{
    public class WalkDto
    {
        public Guid id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; } = string.Empty;
        public Guid RegionId { get; set; }

        public Guid DifficultyId { get; set; }
      
    }
}
