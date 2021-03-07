using Core.Entities;

namespace Core.Specifications
{
    public class EmployeeByPersonalIdSpecification : BaseSpecification<Employee>
    {
        public EmployeeByPersonalIdSpecification(string personalId)
            : base(x => x.PersonalId == personalId)
        {
        }
    }
}