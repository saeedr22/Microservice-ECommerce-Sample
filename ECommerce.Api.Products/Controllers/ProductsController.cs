using System;
using ECommerce.Api.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Products.Controllers
{

    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider _productsProvider;
        public ProductsController(IProductsProvider productsProvider)
        {
            _productsProvider = productsProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await _productsProvider.GetProductsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.products);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int Id)
        {
            var result = await _productsProvider.GetProductAsync(Id);
            if (result.IsSuccess)
            {
                return Ok(result.product);
            }
            return NotFound();
        }
    }
}