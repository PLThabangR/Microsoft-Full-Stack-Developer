using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.Dtos
{
    public class UpdateWalkDto
    {

        [Required]
        [MaxLength(100, ErrorMessage = "Name should not exceed 100 characters")]
        [MinLength(3, ErrorMessage = "Name should be at least 3 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Description should not exceed 100 characters")]
        [MinLength(3, ErrorMessage = "Description should be at least 3 characters")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; } = string.Empty;

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
