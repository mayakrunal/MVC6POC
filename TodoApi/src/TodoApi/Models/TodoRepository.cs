using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="TodoApi.Models.ITodoRepository" />
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TodoRepository(TodoContext context)
        {
            _context = context;
            Add(new TodoItem { Name = "Item1" });
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
        }

        /// <summary>
        /// Finds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public TodoItem Find(long key)
        {
            return _context.TodoItems.FirstOrDefault(t => t.Key == key);
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(long key)
        {
            var entity = _context.TodoItems.First(t => t.Key == key);
            _context.TodoItems.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Update(TodoItem item)
        {
            _context.TodoItems.Update(item);
            _context.SaveChanges();
        }
    }
}