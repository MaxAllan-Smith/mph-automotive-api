using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mph_automotive_api.Models;
using mph_automotive_api.Models.DTOs;
using mph_automotive_api.Persistence;

namespace mph_automotive_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductWithPricesDto>>> GetProducts()
    {
        var result = await dbContext.Products
            .Select(p => new ProductWithPricesDto
            {
                Product = p,
                SellingPrices = dbContext.SellingPrices.Where(sp => sp.ProductId == p.Id).ToList()
            })
            .ToListAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var product = await dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct(Product model)
    {
        var product = new Product
        {
            CategoryId = model.CategoryId,
            SupplierId = model.SupplierId,
            ProductCode = model.ProductCode,
            Description = model.Description,
            StockQty = model.StockQty,
            ImageUrl = model.ImageUrl,
            CreatedAt = DateTime.Now
        };

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, model);
    }

    // 2) Then swap your action to take that DTO and only apply non-nulls:
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product model)
    {
        if (id != model.Id)
            return BadRequest();

        var product = await dbContext.Products.FindAsync(id);
        if (product is null)
            return NotFound();

        // Only overwrite the fields the client actually provided:
        if (model.CategoryId.HasValue) product.CategoryId = model.CategoryId.Value;
        if (model.SupplierId.HasValue) product.SupplierId = model.SupplierId.Value;
        if (!string.IsNullOrWhiteSpace(model.ProductCode)) product.ProductCode = model.ProductCode;
        if (!string.IsNullOrWhiteSpace(model.Description)) product.Description = model.Description;
        if (model.StockQty.HasValue) product.StockQty = model.StockQty;
        if (!string.IsNullOrWhiteSpace(model.ImageUrl)) product.ImageUrl = model.ImageUrl;

        // stamp an update time
        product.UpdatedAt = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await dbContext.Products.FindAsync(id);

        if (product is null) return NotFound();

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();

        return NoContent();
    }
}