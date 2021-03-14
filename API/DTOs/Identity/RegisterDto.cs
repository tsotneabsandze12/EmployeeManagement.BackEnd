using System;
using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace API.DTOs.Identity
{
    public record RegisterDto
    {
        //[Required]
        [MaxLength(11)]
        public string PersonalId { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        //[Required]
        public GenderEnum? Gender { get; set; }
        
        //[Required]
        public DateTime? BirthDate { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}