// ***********************************************************************
// Assembly         : SportsStore
// Author           : Krunal
// Created          : 03-26-2017
//
// Last Modified By : Krunal
// Last Modified On : 03-26-2017
// ***********************************************************************
// <copyright file="ProductsListViewModel.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.ViewModels
{
    /// <summary>
    /// Class ProductsListViewModel.
    /// </summary>
    public class ProductsListViewModel
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        public IEnumerable<Product> Products { get; set; }
        /// <summary>
        /// Gets or sets the paging information.
        /// </summary>
        /// <value>The paging information.</value>
        public PagingInfo PagingInfo { get; set; }
        /// <summary>
        /// Gets or sets the current category.
        /// </summary>
        /// <value>The current category.</value>
        public string CurrentCategory { get; set; }
    }
}
