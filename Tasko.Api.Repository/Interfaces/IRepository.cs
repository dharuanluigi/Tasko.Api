namespace Tasko.Api.Repository.Interfaces
{
  /// <summary>
  /// Repository pattern interface
  /// </summary>
  /// <typeparam name="T">A class to implements db operations</typeparam>
  public interface IRepository<T> where T : class
  {
    /// <summary>
    /// Creates a resource in repository
    /// </summary>
    /// <param name="item">Class item entity</param>
    Task CreateAsync(T item);

    /// <summary>
    /// Get an item from repository
    /// </summary>
    /// <param name="id">Item id</param>
    /// <returns>The requested item</returns>
    Task<T> GetByIdAsync(Guid id);

    /// <summary>
    /// Return all items from repository
    /// </summary>
    /// <returns>IEnumerable of the request item</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Update a information about the item in repository
    /// </summary>
    /// <param name="item">Updated item</param>
    Task Update(T item);

    /// <summary>
    /// Delete an item in repository
    /// </summary>
    /// <param name="item">Item to delete</param>
    Task Delete(T item);
  }
}