using API.Models;

namespace API.Data
{
    public static class ProductRepository
    {
        public static List<Product> Products = new()
        {
    new Product { Id = 1, Name = "iPhone 14", Price = 799, Category = "Electronics", ImageUrl = "/images/iphone.jpg", IsInStock = true },
    new Product { Id = 2, Name = "Samsung Galaxy", Price = 699, Category = "Electronics", ImageUrl = "/images/samsung.jpg", IsInStock = true },
    new Product { Id = 3, Name = "Nike Air Max", Price = 120, Category = "Shoes", ImageUrl = "/images/nike.jpg", IsInStock = true },
};
    }
}
