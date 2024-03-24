using Backend.Context;
using Backend.Dtos;
using Backend.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        //CRUD Functiionality
        //create
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateUpdateProductDto dto)
        {
            var newProduct = new ProductEntity()
            {
                Brand = dto.Brand,
                Title = dto.Title,
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return Ok("Product Added Successfully");

        }
        //Read
        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> GetAllProduct()
        {
            var Products = await _context.Products.ToListAsync();
            return Ok(Products);
        }

        //GetById
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProductByID([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product is null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }

        //update
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] long id, [FromBody] CreateUpdateProductDto dto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product is null)
            {
                return NotFound("Product not found");
            }
            product.Title = dto.Title;
            product.Brand = dto.Brand;
            product.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok("Product Update Successfully");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product is null)
            {
                return NotFound("Product not found");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok("Product Delete Successfully");
        }
    }
}
