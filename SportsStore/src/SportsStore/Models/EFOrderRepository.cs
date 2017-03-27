// ***********************************************************************
// Assembly         : SportsStore
// Author           : Krunal
// Created          : 03-27-2017
//
// Last Modified By : Krunal
// Last Modified On : 03-27-2017
// ***********************************************************************
// <copyright file="EFOrderRepository.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    /// <summary>
    /// Class EFOrderRepository.
    /// </summary>
    /// <seealso cref="SportsStore.Models.IOrderRepository" />
    public class EFOrderRepository : IOrderRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFOrderRepository"/> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        /// <summary>
        /// Gets the orders.
        /// </summary>
        /// <value>The orders.</value>
        public IEnumerable<Order> Orders =>
            context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        /// <summary>
        /// Saves the order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
