using WebDomain.Entities;

namespace WebHost.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAll();
        Task<ProductEntity> GetById(int id);
        Task<bool> Create(ProductEntity entity);
        Task<bool> Update(ProductEntity entity);
        Task<bool> Delete(int id);

    }
}
