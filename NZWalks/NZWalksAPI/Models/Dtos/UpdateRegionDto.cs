namespace NZWalksAPI.Models.Dtos
{
    public class UpdateRegionDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? imageUrl { get; set; }
    }
}
