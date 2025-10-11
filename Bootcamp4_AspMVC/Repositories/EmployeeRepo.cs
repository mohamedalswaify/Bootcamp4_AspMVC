using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp4_AspMVC.Repositories
{
    public class EmployeeRepo : MainRepository<Employee>, IEmployeeRepo
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeesWithDepartmentAndJob()
        {
            return _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Job)
                .ToList();

        }
    }
}
