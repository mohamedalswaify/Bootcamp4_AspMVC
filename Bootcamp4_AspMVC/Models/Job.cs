namespace Bootcamp4_AspMVC.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
