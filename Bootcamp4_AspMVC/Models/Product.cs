using System.ComponentModel.DataAnnotations;

namespace Bootcamp4_AspMVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
    }
}
