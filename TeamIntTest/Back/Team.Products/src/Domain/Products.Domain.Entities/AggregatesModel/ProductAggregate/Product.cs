// ===================================================================================================================
// Author                : Ivan Hidalgo. 
// Product               : Team.Products.Domain.Entities.AggregatesModel.ProductAggregate
// Summary               : Product class definition.
// Framework Version     : 4.5.2
// Company               : Team International
// ===================================================================================================================
// <copyright file="Product.cs" company="Team International">
//      Copyright (C) 2019 Team International
// </copyright>
// ===================================================================================================================

using System.Collections.Generic;

namespace Team.Products.Domain.Entities.AggregatesModel.ProductAggregate
{
    /// <summary>
    /// Product class definition.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Product()
        {
            Categories = new List<Category>();
        }

        /// <summary>
        /// Product Identifier.
        /// </summary>
        public string Id { set; get; }

        /// <summary>
        /// Product Name.
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Product Description.
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// Product Price.
        /// </summary>
        public string Price { set; get; }

        /// <summary>
        /// Product Brand.
        /// </summary>
        public string Brand { set; get; }

        /// <summary>
        /// Product Stock.
        /// </summary>
        public string Stock { set; get; }

        /// <summary>
        /// Product Photo.
        /// </summary>
        public string Photo { set; get; }

        /// <summary>
        /// Product's categories.
        /// </summary>
        public IList<Category> Categories { set; get; }

    }
}
