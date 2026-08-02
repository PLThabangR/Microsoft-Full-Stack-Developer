using System.Security.Principal;

namespace NZWalksAPI.Models.Domain
{
    public class Walk
    {

        public Guid id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; } = string.Empty;
        public Guid RegionId { get; set; }

        //navigateion properties
        public Region Region { get; set; }

        public Guid DifficultyId { get; set; }
        //navigateion properties
        public Difficulty Difficulty { get; set;}
    }
}
