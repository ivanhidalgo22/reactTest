// ===================================================================================================================
// Author                : Ivan Hidalgo. 
// Product               : Team.Products.Application.Services.Interfaces
// Summary               : Product Service.
// Framework Version     : 4.5.2
// Company               : Team International
// ===================================================================================================================
// <copyright file="ProductService.cs" company="Team International">
//      Copyright (C) 2019 Team International
// </copyright>
// ===================================================================================================================

using Team.Products.Application.Services.DTO;
using Team.Products.Application.Services.Interfaces;
using Team.Products.Domain.Entities.AggregatesModel.ProductAggregate;

namespace Team.Products.Application.Services
{
    /// <summary>
    /// Product Service.
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// ProductRepository instance.
        /// </summary>
        public IProductRepository ProductRepository { set; get; }

        /// <summary>
        /// Gets all products that were saved inside the database.
        /// </summary>
        /// <returns>ProductOutputDto instance.</returns>
        public ProductOutputDto GetAllProducts()
        {
            var productsToBeReturned = ProductRepository.GetProducts();

            ProductOutputDto productOutputDto = new ProductOutputDto();
            if (null != productsToBeReturned)
                productOutputDto.Products = productsToBeReturned;

            return productOutputDto;
        }
    }
}
