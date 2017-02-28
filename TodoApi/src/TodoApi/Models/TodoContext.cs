using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class TodoContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TodoContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the todo items.
        /// </summary>
        /// <value>
        /// The todo items.
        /// </value>
        public DbSet<TodoItem> TodoItems { get; set; }

    }
}