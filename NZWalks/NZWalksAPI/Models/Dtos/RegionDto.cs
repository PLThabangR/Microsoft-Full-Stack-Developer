namespace NZWalksAPI.Models.Dtos
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? imageUrl { get; set; }
    }
}
