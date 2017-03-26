// ***********************************************************************
// Assembly         : SportsStore
// Author           : Krunal
// Created          : 03-26-2017
//
// Last Modified By : Krunal
// Last Modified On : 03-26-2017
// ***********************************************************************
// <copyright file="ProductController.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    /// <summary>
    /// Class ProductController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class ProductController : Controller
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IProductRepository repository;
        /// <summary>
        /// The page size
        /// </summary>
        public int PageSize = 4;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Lists the specified page.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <param name="page">The page.</param>
        /// <returns>ViewResult.</returns>
        public ViewResult List(string category, int page = 1) =>
            View(new ProductsListViewModel
            {
                Products = repository.Products
                            .Where(p => category == null || p.Category == category)
                            .OrderBy(p => p.ProductID)
                            .Skip((page - 1) * PageSize)
                            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Products.Count() :
                        repository.Products.Where(x=> x.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}