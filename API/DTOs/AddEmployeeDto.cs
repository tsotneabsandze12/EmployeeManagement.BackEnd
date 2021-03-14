using System;
using Core.Enums;

namespace API.DTOs
{
    public record AddEmployeeDto
    {
        public string PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime? DateReleased { get; set; }
        public string PhoneNumber { get; set; }
        public int PositionId { get; set; }
    }
}