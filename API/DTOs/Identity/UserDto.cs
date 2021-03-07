namespace API.DTOs.Identity
{
    public record UserDto
    {
        public string PersonalId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}