// ===================================================================================================================
// Author                : Ivan Hidalgo. 
// Product               : Team.Products.Domain.Entities.AggregatesModel.ProductAggregate
// Summary               : Product repository contract.
// Framework Version     : 4.5.2
// Company               : Team International
// ===================================================================================================================
// <copyright file="IProductRepository.cs" company="Team International">
//      Copyright (C) 2019 Team International
// </copyright>
// ===================================================================================================================

using System.Collections.Generic;


namespace Team.Products.Domain.Entities.AggregatesModel.ProductAggregate
{
    /// <summary>
    /// Product repository contract.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets all products that are saved inside the database.
        /// </summary>
        /// <returns>Products that were returned from the database.</returns>
        IList<Product> GetProducts();
    }
}
