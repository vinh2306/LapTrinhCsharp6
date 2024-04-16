using Microsoft.EntityFrameworkCore;
using WebDomain.Entities;
using WebHost.Data;

namespace WebHost.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(ProductEntity entity)
        {
           if(entity == null)
            {
                return false;
            }
            try
            {
                await _context.ProductEntity.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var product = await _context.ProductEntity.FindAsync(id);
                _context.ProductEntity.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetAll()
        {
            return await _context.ProductEntity.ToListAsync();
        }

        public async Task<ProductEntity> GetById(int id)
        {
            return await _context.ProductEntity.FindAsync(id);
        }

        public async Task<bool> Update(ProductEntity entity)
        {
            var p = await _context.ProductEntity.FindAsync(entity.Id);
            if (p == null)
            {
                return false;
            }
            try 
            {
                p.Code = entity.Code;
                p.Name = entity.Name;
                p.Price = entity.Price;
                _context.ProductEntity.Update(p);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
