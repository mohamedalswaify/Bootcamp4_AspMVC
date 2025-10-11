using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Models;

namespace Bootcamp4_AspMVC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _employeeRepo = new EmployeeRepo(_context);
            _repositoryDepartment = new MainRepository<Department>(_context);
            _repositoryJob = new MainRepository<Job>(_context);
            _repositoryCategory = new MainRepository<Category>(_context);
            _productRepo = new ProductRepo(_context);

        }





        public IEmployeeRepo _employeeRepo { get;  }

        public IRepository<Department> _repositoryDepartment { get; }

        public IRepository<Job> _repositoryJob { get; }
        public IRepository<Category> _repositoryCategory { get; }
        public IProductRepo _productRepo { get; } 
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
