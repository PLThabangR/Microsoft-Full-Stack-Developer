using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.Dtos
{
    public class UpdateRegionDto
    {   
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [MinLength(2, ErrorMessage = "Name should have at least 2 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(3, ErrorMessage = "Code cannot exceed 3 characters")]
        [MinLength(3, ErrorMessage = "Code should have at least 3characters")]
        public string Code { get; set; } = string.Empty;
        public string? imageUrl { get; set; }
    }
}
