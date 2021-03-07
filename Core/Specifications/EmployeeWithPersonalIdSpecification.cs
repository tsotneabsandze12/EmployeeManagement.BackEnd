using Core.Entities;

namespace Core.Specifications
{
    public class EmployeeWithPersonalIdSpecification : BaseSpecification<Employee>
    {
        public EmployeeWithPersonalIdSpecification(string personalId)
            : base(x => x.PersonalId == personalId)
        {
        }
    }
}