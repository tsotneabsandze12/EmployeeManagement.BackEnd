using System;
using Core.Enums;

namespace API.DTOs
{
    public record EmployeeDto
    {
        public int Id { get; set; }
        public string PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime? DateReleased { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
    }
}