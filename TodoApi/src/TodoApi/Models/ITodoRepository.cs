using System.Collections.Generic;

namespace TodoApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITodoRepository
    {
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Add(TodoItem item);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TodoItem> GetAll();
        /// <summary>
        /// Finds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        TodoItem Find(long key);
        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        void Remove(long key);
        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Update(TodoItem item);
    }
}