// ===================================================================================================================
// Author                : Ivan Hidalgo. 
// Product               : Team.Products.Application.Services.Interfaces
// Summary               : Product Service Contract.
// Framework Version     : 4.5.2
// Company               : Team International
// ===================================================================================================================
// <copyright file="IProductService.cs" company="Team International">
//      Copyright (C) 2019 Team International
// </copyright>
// ===================================================================================================================

using Team.Products.Application.Services.DTO;

namespace Team.Products.Application.Services.Interfaces
{
    /// <summary>
    /// Product Service Contract.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products that are saved inside the database.
        /// </summary>
        /// <returns>ProductOutputDto instance.</returns>
        ProductOutputDto GetAllProducts();
    }
}
