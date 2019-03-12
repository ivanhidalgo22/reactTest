using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Team.Products.API;
using Team.Products.Application.Services.DTO;
using Team.Products.Application.Services.Interfaces;
using Team.Products.Domain.Entities.AggregatesModel.ProductAggregate;

namespace Products.UnitTest
{
    [TestClass]
    public class ProductControllerUnitTest
    {
        public ProductController ProductsController { set; get; }

        [TestMethod]
        public void GetAllProductsOk()
        {
            var ProductServiceMock = new Mock<IProductService>();
            var productOutputDto = new ProductOutputDto();

            ProductsController = new ProductController();

            productOutputDto.Products.Add(new Product() { Id = "computer", Brand = "default brand", Description = "product description", Name = "computer" });
            productOutputDto.Products.Add(new Product() { Id = "monitor", Brand = "default brand", Description = "product description", Name = "monitor" });

            ProductServiceMock.Setup(x => x.GetAllProducts()).Returns(productOutputDto);

            ProductsController.ProductService = ProductServiceMock.Object;

            var response = ProductsController.GetAllProducts();

            Assert.IsNotNull(response);

            Assert.AreEqual(2, response.Products.Count);

        }
    }
}
