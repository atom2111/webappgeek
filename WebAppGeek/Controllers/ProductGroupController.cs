using Microsoft.AspNetCore.Mvc;
using WebAppGeek.Dto;
using WebAppGeek.Repository;
using WebAppGeek.Models;
using WebAppGeek.Abstraction;

namespace WebAppGeek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupRepository _productGroupRepository;

        public ProductGroupController(IProductGroupRepository productGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
        }

        [HttpPost]
        public ActionResult<int> AddProductGroup([FromBody] ProductGroupDto productGroupDto)
        {
            try
            {
                var id = _productGroupRepository.AddProductGroup(productGroupDto);
                return Ok($"Добавлена группа с ID = {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(409, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductGroupDto>> GetAllProductGroups()
        {
            return Ok(_productGroupRepository.GetAllProductGroups());
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProductGroup(int id)
        {
            try
            {
                _productGroupRepository.DeleteProductGroup(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
    }
}
