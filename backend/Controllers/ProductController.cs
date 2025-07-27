using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(
            string? search = null, 
            string? category = null, 
            decimal? minPrice = null, 
            decimal? maxPrice = null,
            int page = 1, 
            int pageSize = 10)
        {
            var products = ProductRepository.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                products = products.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(category))
                products = products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

            if (minPrice.HasValue)
                products = products.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                products = products.Where(p => p.Price <= maxPrice.Value);

            var total = products.Count();

            var result = products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(new { total, result });
        }
    }
}
