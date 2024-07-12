using Microsoft.AspNetCore.Mvc;
using WebAppGeek.Abstraction;
using WebAppGeek.Dto;
using WebAppGeek.Models;
using WebAppGeek.Repository;
using System.Text;

namespace WebAppGeek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public ActionResult<int> AddProduct([FromBody] ProductDto productDto)
        {
            try
            {
                var id = _productRepository.AddProduct(productDto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(409, ex.Message);
            }
        }

        [HttpGet("get_all_products")]
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts()
        {
            return Ok(_productRepository.GetAllProducts());
        }

        [HttpGet("export_products_csv")]
        public IActionResult ExportProductsToCsv()
        {
            var products = _productRepository.GetAllProducts();
            var csv = new StringBuilder();
            csv.AppendLine("Id,Name,Description,Price");

            foreach (var product in products)
            {
                csv.AppendLine($"{product.Id},{product.Name},{product.Description},{product.Price}");
            }

            var fileName = "products.csv";
            var mimeType = "text/csv";
            var content = Encoding.UTF8.GetBytes(csv.ToString());

            return File(content, mimeType, fileName);
        }
    }
}
