using AutoMapper;
using ECommerce.Api.Products.Db;
using ECommerce.Api.Products.Profiles;
using ECommerce.Api.Products.Providers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Eccomerce.Api.Products.Tests
{
    public class ProductsServiceTest
    {
        [Fact]
        public async Task GetProductsReturnsAllProducts()
        {
            var options = new DbContextOptionsBuilder().UseInMemoryDatabase(nameof(GetProductsReturnsAllProducts)).Options;
            var context = new ProductsDbContext(options);
            createProducts(context);
            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);

            var provider = new ProductsProvider(context,null,mapper);
            var result = await provider.GetProductsAsync();
            Assert.True(result.IsSuccess);
            Assert.True(result.Products.Any());
            Assert.Null(result.ErrorMessage);

        }


        [Fact]
        public async Task GetProductsReturnsValidProductId()
        {
            var options = new DbContextOptionsBuilder().UseInMemoryDatabase(nameof(GetProductsReturnsValidProductId)).Options;
            var context = new ProductsDbContext(options);
            createProducts(context);
            var productProfile = new ProductProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(productProfile));
            var mapper = new Mapper(configuration);

            var provider = new ProductsProvider(context, null, mapper);
            var result = await provider.GetProductAsync(1);
            Assert.True(result.IsSuccess);
            Assert.True(result.Product.Id == 1);
            Assert.Null(result.ErrorMessage);

        }

        private void createProducts(ProductsDbContext context)
        {
            for(int i = 1; i <=10; i++)
            {
                context.Products.Add(new Product() { Id = i, Name = Guid.NewGuid().ToString(), Price = (Decimal)(i * 3.14), Inventory = (i + 10) });
            }

            context.SaveChanges();
        }
    }
}
