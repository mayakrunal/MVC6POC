// ***********************************************************************
// Assembly         : SportsStore
// Author           : Krunal
// Created          : 03-26-2017
//
// Last Modified By : Krunal
// Last Modified On : 03-26-2017
// ***********************************************************************
// <copyright file="IProductRepository.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace SportsStore.Models
{
    /// <summary>
    /// Interface IProductRepository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>The products.</value>
        IEnumerable<Product> Products { get; }

        /// <summary>
        /// Saves the product.
        /// </summary>
        /// <param name="product">The product.</param>
        void SaveProduct(Product product);

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="productID">The product identifier.</param>
        /// <returns></returns>
        Product DeleteProduct(int productID);
    }
}
