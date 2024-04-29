using System.ComponentModel.DataAnnotations;

namespace NewsWebsiteApi.Dtos
{
    public class LogInDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
    }
}
