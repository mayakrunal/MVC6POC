// ***********************************************************************
// Assembly         : SportsStore
// Author           : Krunal
// Created          : 03-26-2017
//
// Last Modified By : Krunal
// Last Modified On : 03-26-2017
// ***********************************************************************
// <copyright file="CartController.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    /// <summary>
    /// Class CartController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class CartController : Controller
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IProductRepository repository;

        /// <summary>
        /// The cart
        /// </summary>
        private Cart cart;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartController" /> class.
        /// </summary>
        /// <param name="repo">The repo.</param>
        /// <param name="cartServices">The cart services.</param>
        public CartController(IProductRepository repo, Cart cartServices)
        {
            repository = repo;
            cart = cartServices;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// Adds to cart.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>RedirectToActionResult.</returns>
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null) { cart.AddItem(product, 1); }

            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Removes from cart.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>RedirectToActionResult.</returns>
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null) { cart.RemoveLine(product); }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}