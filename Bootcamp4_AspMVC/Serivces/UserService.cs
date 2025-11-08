using Bootcamp4_AspMVC.Dtos;
using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Interfaces.IServices;
using Bootcamp4_AspMVC.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace Bootcamp4_AspMVC.Serivces
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(User user)
        {
            _unitOfWork._repositoryUser.Add(user);
            _unitOfWork.Save();
        }
        public void Update(User user)
        {
            _unitOfWork._repositoryUser.Update(user);
            _unitOfWork.Save();
        }
        public void Delete(int id)
        {
            _unitOfWork._repositoryUser.Delete(id);
            _unitOfWork.Save();
        }
        public IEnumerable<User> GetAll()
        {
            return _unitOfWork._repositoryUser.GetAll();
        }
        public User GetByEmailAndpass(LoginRequestDto loginRequest)
        {
            return _unitOfWork._repositoryUser.GetAll().FirstOrDefault(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password);
        }
        public User GetById(int id)
        {
            return _unitOfWork._repositoryUser.GetById(id);
        }
        public bool IsEmailExist(string email)
        {
            return _unitOfWork._repositoryUser.GetAll().Any(u => u.Email == email);
        }


    }
}
