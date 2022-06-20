using Xunit;
using ECommerce.Api.Products.Data;
using Microsoft.EntityFrameworkCore;
using ECommerce.Api.Products.Profiles;
using AutoMapper;
using ECommerce.Api.Products.Providers;
using System.Linq;
using System;

namespace ECommerce.Api.Products.Tests;

public class ProductsServiceTest
{
    [Fact]
    public async void GetProducts_ReturnsAllProducts()
    {
        var options = new DbContextOptionsBuilder<ProductDbContext>()
                       .UseInMemoryDatabase(nameof(GetProducts_ReturnsAllProducts))
                       .Options;
        var context = new ProductDbContext(options);
        var productProfile = new ProductProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
        var mapper = new Mapper(configuration);
        CreateProducts(context);
        var productsProvider = new ProductsProvider(context, null, mapper);     
        var product = await productsProvider.GetProductsAsync();
        
        Assert.True(product.IsSuccess);
        Assert.True(product.products.Any());
        Assert.Null(product.ErrorMessage);
    }

    void CreateProducts(ProductDbContext dbContext)
    {
        for (int i = 1; i <= 10; i++)
        {
            dbContext.Products.Add(new Product
            {
                Id = i,
                Inventory = 100,
                Price = 200,
                Name = Guid.NewGuid().ToString()
            });
        }
        dbContext.SaveChanges();
    }
}