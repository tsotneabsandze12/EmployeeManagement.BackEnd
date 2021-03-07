using Core.Entities;

namespace Core.Specifications
{
    public class EmployeeByPhoneNumberSpecification : BaseSpecification<Employee>
    {
        public EmployeeByPhoneNumberSpecification(string number)
            : base(x => x.PhoneNumber == number)
        {
        }
    }
}