// ===================================================================================================================
// Author                : Ivan Hidalgo. 
// Product               : Team.Products.Application.Services.DTO
// Summary               : Product Data Transfer Object.
// Framework Version     : 4.5.2
// Company               : Team International
// ===================================================================================================================
// <copyright file="ProductOutputDto.cs" company="Team International">
//      Copyright (C) 2019 Team International
// </copyright>
// ===================================================================================================================

using System.Collections.Generic;
using Team.Products.Domain.Entities.AggregatesModel.ProductAggregate;

namespace Team.Products.Application.Services.DTO
{
    /// <summary>
    /// Product Data Transfer Object.
    /// </summary>
    public class ProductOutputDto
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ProductOutputDto()
        {
            Products = new List<Product>();
        }

        /// <summary>
        /// Products collection.
        /// </summary>
        public IList<Product> Products { set; get; }
    }
}
