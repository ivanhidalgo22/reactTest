using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Team.Products.Application.Services;
using Team.Products.Domain.Entities.AggregatesModel.ProductAggregate;
using Moq;

namespace Team.Products.UnitTest.Services
{
    /// <summary>
    /// Summary description for ProductServiceUnitTest
    /// </summary>
    [TestClass]
    public class ProductServiceUnitTest
    {

        public ProductService ProductService { set; get; }

        [TestMethod]
        public void GetAllProductsOk()
        {
            var ProductRepositoryeMock = new Mock<IProductRepository>();
            ProductService = new ProductService();
            var productToBeReturned = new List<Product>();

            productToBeReturned.Add(new Product() { Id = "computer", Brand = "default brand", Description = "product description", Name = "computer" });
            productToBeReturned.Add(new Product() { Id = "monitor", Brand = "default brand", Description = "product description", Name = "monitor" });

            ProductRepositoryeMock.Setup(x => x.GetProducts()).Returns(productToBeReturned);

            ProductService.ProductRepository = ProductRepositoryeMock.Object;

            var response = ProductService.GetAllProducts();

            Assert.IsNotNull(response);

            Assert.AreEqual(2, response.Products.Count);

        }
    }
}
