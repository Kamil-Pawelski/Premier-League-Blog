using System.ComponentModel.DataAnnotations;

namespace PremierLeagueBlog.Server.Data
{
    public class ApiLoginRequest
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
