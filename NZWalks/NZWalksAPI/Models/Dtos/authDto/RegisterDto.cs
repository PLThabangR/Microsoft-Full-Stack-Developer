using System.ComponentModel.DataAnnotations;

namespace NZWalksAPI.Models.Dtos.authDto
{
    public class RegisterDto
    {
        [Required]

      [DataType(DataType.EmailAddress)]
        public  string Username { get; set; }=string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        //Roles 
        public string[]? Roles { get; set; }
    }
}
