namespace NZWalksAPI.Models.Dtos
{
    public class CreateWalkDto
    {
         public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; } = string.Empty;
        //ID from the region
        public Guid RegionId { get; set; }

    //ID from the difficulty
        public Guid DifficultyId { get; set; }


    }
}
