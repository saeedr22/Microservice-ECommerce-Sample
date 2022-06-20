using System.Data.Common;
using System.ComponentModel.DataAnnotations;
using System;
using AutoMapper;
using ECommerce.Api.Products.Data;
using ECommerce.Api.Products.Interfaces;
using ECommerce.Api.Products.Models;
using Product = ECommerce.Api.Products.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Products.Providers
{
    public class ProductsProvider : IProductsProvider
    {
        private readonly ProductDbContext _dbContext;
        private readonly ILogger<ProductsProvider> _logger;
        private readonly IMapper _mapper;
        public ProductsProvider(ProductDbContext dbContext, ILogger<ProductsProvider> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
            SeedData();
        }
        public async Task<(bool IsSuccess, IEnumerable<Product> products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var products = await _dbContext.Products.ToListAsync();
                if (products != null && products.Any())
                {
                    var result = _mapper.Map<IEnumerable<Data.Product>, IEnumerable<Models.Product>>(products);
                    return (true, result, null);
                }
                return (false, null, "not found");
            }
            catch (System.Exception ex)
            {
                _logger?.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
        public async Task<(bool IsSuccess, Product product, string ErrorMessage)> GetProductAsync(int Id)
        {
            try
            {
                var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
                if (product != null)
                {
                    var result = _mapper.Map<Data.Product, Models.Product>(product);
                    return (true, result, null);
                }
                return (false, null, "not found");
            }
            catch (System.Exception ex)
            {
                _logger?.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
        private void SeedData()
        {
            if (!_dbContext.Products.Any())
            {
                _dbContext.Products.Add(new Data.Product { Id = 1, Name = "Keyboard", Price = 100, Inventory = 1000 });
                _dbContext.Products.Add(new Data.Product { Id = 2, Name = "Mouse", Price = 20, Inventory = 200 });
                _dbContext.Products.Add(new Data.Product { Id = 3, Name = "Monitor", Price = 200, Inventory = 100 });
                _dbContext.Products.Add(new Data.Product { Id = 4, Name = "CPU", Price = 120, Inventory = 2000 });
                _dbContext.SaveChanges();
            }
        }
    }
}