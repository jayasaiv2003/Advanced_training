using Inventory_Management.Data.Repository;
using Inventory_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category_App : Controller
    {
        public readonly IGenericRepository<Category> _ICategoryRepository;
        public Category_App(IGenericRepository<Category> ICategoryRepository)
        {
            _ICategoryRepository = ICategoryRepository;
        }

        [HttpGet("allcategories")]
        public IActionResult GetAllCategories()
        {
            var categories = _ICategoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("category/{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _ICategoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);

        }

        [HttpPost("addcategory")]
        public IActionResult AddCategory([FromBody] Category category)
        {
            _ICategoryRepository.Add(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, category);
        }

        [HttpPut("updatecategory/{id}")]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            if (category == null || category.CategoryId <= 0)
            {
                return BadRequest();
            }
            var existingCategory = _ICategoryRepository.GetById(category.CategoryId);
            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.CategoryName = category.CategoryName;
            _ICategoryRepository.Update(existingCategory);
            return NoContent();
        }
        [HttpDelete("deletecategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var existingCategory = _ICategoryRepository.GetById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            _ICategoryRepository.Delete(id);
            return NoContent();
        }
    }
}
