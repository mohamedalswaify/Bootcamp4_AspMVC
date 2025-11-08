using Bootcamp4_AspMVC.Dtos;
using Bootcamp4_AspMVC.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace Bootcamp4_AspMVC.Interfaces.IServices
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);

        bool IsEmailExist(string email);
        void Create(User user);
        void Update(User user);
        void Delete(int id);


        User GetByEmailAndpass(LoginRequestDto loginRequest);


    }
}
