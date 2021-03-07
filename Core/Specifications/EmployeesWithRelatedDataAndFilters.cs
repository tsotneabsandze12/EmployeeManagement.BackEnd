using Core.Entities;

namespace Core.Specifications
{
    public class EmployeesWithRelatedDataAndFilters : BaseSpecification<Employee>
    {
        public EmployeesWithRelatedDataAndFilters(SpecParams specParams)
        {
            AddInclude(Includes, x => x.Position);
            
            AddFilters(Filters, x=>(string.IsNullOrEmpty(specParams.FirstName) || x.FirstName.Contains(specParams.FirstName.ToLower())));
            AddFilters(Filters, x=>(string.IsNullOrEmpty(specParams.LastName) || x.LastName.Contains(specParams.LastName.ToLower())));
        }

        public EmployeesWithRelatedDataAndFilters(int id)
            : base(x => x.Id == id)
        {
            AddInclude(Includes, x => x.Position);
        }
    }
}