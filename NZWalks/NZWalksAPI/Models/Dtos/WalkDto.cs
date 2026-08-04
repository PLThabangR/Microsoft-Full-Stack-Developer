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

        //Navigation properties to get the region and difficulty details
        // This varaibles the include merthod will use this to get more details
        public DifficultyDto? Difficulty { get; set; }
        public RegionDto? Region { get; set; }
       
    }
}
