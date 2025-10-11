using Bootcamp4_AspMVC.Models;

namespace Bootcamp4_AspMVC.Interfaces
{
    public interface IEmployeeRepo : IRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeesWithDepartmentAndJob();
    }
}
