// ===================================================================================================================
// Author                : Ivan Hidalgo. 
// Product               : Team.Products.API
// Summary               : Product controller.
// Framework Version     : 4.5.2
// Company               : Team International
// ===================================================================================================================
// <copyright file="ProductController.cs" company="Team International">
//      Copyright (C) 2019 Team International
// </copyright>
// ===================================================================================================================

using System.Web.Http;
using Team.Products.Application.Services.DTO;
using Team.Products.Application.Services.Interfaces;

namespace Team.Products.API
{
    /// <summary>
    /// Product controller.
    /// </summary>
    [RoutePrefix("api/v1/products")]
    public class ProductController : ApiController
    {
        /// <summary>
        /// ProductService instance.
        /// </summary>
        public IProductService ProductService { set; get; }

        /// <summary>
        /// Gets products that were saved inside database.
        /// </summary>
        /// <returns>ProductOutputDto Product Data transfer object.</returns>
        [Route("")]
        public ProductOutputDto GetAllProducts()
        {
            return ProductService.GetAllProducts();
        }
    }
}
