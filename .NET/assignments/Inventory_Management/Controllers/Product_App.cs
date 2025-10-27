using Inventory_Management.Data.Repository;
using Inventory_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_App : Controller
    {
        public readonly IGenericRepository<Product> _IProductRepository;
        public Product_App(IGenericRepository<Product> IProductRepository)
        {
            _IProductRepository = IProductRepository;
        }

        [HttpGet("allproducts")]
        public IActionResult GetAllProducts()
        {
            var products = _IProductRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("product/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _IProductRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost("addproduct")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _IProductRepository.Add(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.ProductId }, product);
        }

        [HttpPut("updateproduct/{id}")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            if (product == null || product.ProductId <= 0)
            {
                return BadRequest();
            }
            var existingProduct = _IProductRepository.GetById(product.ProductId);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;
            existingProduct.CategoryId = product.CategoryId;
            _IProductRepository.Update(existingProduct);
            return NoContent();

        }

        [HttpDelete("deleteproduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingProduct = _IProductRepository.GetById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            _IProductRepository.Delete(id);
            return NoContent();
        }
    }
}
