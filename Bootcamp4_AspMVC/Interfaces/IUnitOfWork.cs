using Bootcamp4_AspMVC.Models;

namespace Bootcamp4_AspMVC.Interfaces
{
    public interface IUnitOfWork
    {
 
       
        IEmployeeRepo _employeeRepo { get; }
        IRepository<Department> _repositoryDepartment { get; }
        IRepository<Job> _repositoryJob { get; }
        IRepository<Category> _repositoryCategory { get; }
        IProductRepo _productRepo { get; }

        void Save();

    }
}
