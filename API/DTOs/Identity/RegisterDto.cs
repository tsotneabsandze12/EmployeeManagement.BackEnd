using System;
using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace API.DTOs.Identity
{
    public record RegisterDto
    {
        [MaxLength(11)] public string PersonalId { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        public GenderEnum? Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }

        [Required] public string Password { get; set; }
    }
}