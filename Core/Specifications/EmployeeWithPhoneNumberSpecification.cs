using Core.Entities;

namespace Core.Specifications
{
    public class EmployeeWithPhoneNumberSpecification : BaseSpecification<Employee>
    {
        public EmployeeWithPhoneNumberSpecification(string phoneNumber)
            : base(x => x.PhoneNumber == phoneNumber)
        {
        }
    }
}