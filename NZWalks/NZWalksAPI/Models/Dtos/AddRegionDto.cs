using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.Dtos
{
    public class AddRegionDto
    {
        [Required ]
        [MinLength(3, ErrorMessage="Name has to be a minimum of 3 characters long")]
        [MaxLength(50, ErrorMessage="Name has to be a maximum of 50 characters long")]
        public string Name { get; set; } = string.Empty;
       
        [Required]
        [MaxLength(3, ErrorMessage = "Code cannot exceed 3 characters")]
        [MinLength(3, ErrorMessage = "Code should have at least 3characters")]
        public string Code { get; set; } = string.Empty;
        public string? imageUrl { get; set; }
    }
}

