using BikeShop.Data.Entities;

namespace BikeShop.Data.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task Create(T data);
        Task<T?> GetById(int id);
        Task Update(int id, T data);
        Task Delete(int id);
        IQueryable<T> GetAll();
    }
}