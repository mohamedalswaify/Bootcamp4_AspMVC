namespace Bootcamp4_AspMVC.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetByUId(string Uid);

        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
