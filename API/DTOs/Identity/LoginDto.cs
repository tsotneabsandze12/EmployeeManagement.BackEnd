using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Identity
{
    public record LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}