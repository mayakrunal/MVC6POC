// ***********************************************************************
// Assembly         : SportsStore
// Author           : Krunal
// Created          : 03-26-2017
//
// Last Modified By : Krunal
// Last Modified On : 03-26-2017
// ***********************************************************************
// <copyright file="FakeProductRepository.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    /// <summary>
    /// Class FakeProductRepository.
    /// </summary>
    /// <seealso cref="SportsStore.Models.IProductRepository" />
    public class FakeProductRepository : IProductRepository
    {
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <value>The products.</value>
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surf board", Price = 179 },
            new Product { Name = "Running shoes", Price = 95 }
        };
    }
}
