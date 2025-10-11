using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Interfaces.IServices;
using Bootcamp4_AspMVC.Models;

namespace Bootcamp4_AspMVC.Serivces
{
    

    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Create(Category category)
        {
            _unitOfWork._repositoryCategory.Add(category);
            _unitOfWork.Save();
            return true;


        }

        public bool DeleteByUid(string uid)
        {
            var category = _unitOfWork._repositoryCategory.GetByUId(uid);
            if (category == null)
            {
                return false;
            }
            _unitOfWork._repositoryCategory.Delete(category.Id);
            _unitOfWork.Save();
            return true;

        }

        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork._repositoryCategory.GetAll();

        }

        public Category? GetByUid(string uid)
        {
            return _unitOfWork._repositoryCategory.GetByUId(uid);

        }

        public bool Update(string uid, Category input)
        {
            var category = _unitOfWork._repositoryCategory.GetByUId(uid);
            if (category == null)
            {
                return false;
            }
            category.Name = input.Name;
            category.Description = input.Description;
            _unitOfWork._repositoryCategory.Update(category);
            _unitOfWork.Save();
            return true;

        }
    }
}
