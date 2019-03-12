// ===================================================================================================================
// Author                : Ivan Hidalgo. 
// Product               : Team.Products.Infraestructure.Repositories
// Summary               : Product repository.
// Framework Version     : 4.5.2
// Company               : Team International
// ===================================================================================================================
// <copyright file="ProductRepository.cs" company="Team International">
//      Copyright (C) 2019 Team International
// </copyright>
// ===================================================================================================================

using System;
using System.Collections.Generic;
using System.IO;
using Team.Products.Domain.Entities.AggregatesModel.ProductAggregate;

namespace Team.Products.Infraestructure.Repositories
{
    /// <summary>
    /// Product repository.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Products file name.
        /// </summary>
        private const string PRODUCTS_FILE_NAME = "products.json";

        /// <summary>
        /// Data folder.
        /// </summary>
        private const string DATA_FOLDER = "bin\\Data";

        /// <summary>
        /// Gets all products that are saved inside the database.
        /// </summary>
        /// <returns>Products that were returned from the database.</returns>
        public IList<Product> GetProducts()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + DATA_FOLDER;

            var jsonConfing = File.ReadAllText(Path.Combine(baseDirectory, PRODUCTS_FILE_NAME));
            var products= Newtonsoft.Json.JsonConvert.DeserializeObject<List<Product>>(jsonConfing);

            return products;
        }        
    }
}
