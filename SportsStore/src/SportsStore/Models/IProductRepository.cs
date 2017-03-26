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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
