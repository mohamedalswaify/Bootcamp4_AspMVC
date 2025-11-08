namespace Bootcamp4_AspMVC.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int Qty { get; set; }
        public int ReservedQty { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
