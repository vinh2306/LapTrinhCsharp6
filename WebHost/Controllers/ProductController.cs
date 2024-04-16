using Microsoft.AspNetCore.Mvc;
using WebDomain.Entities;
using WebHost.Repository;

namespace WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _repo.GetAll());
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repo.GetById(id));
        }
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate(ProductEntity obj)
        {
            if(obj.Id > 0)
            {

                return Ok(await _repo.Update(obj));
            }
            else
            {
                return Ok(await _repo.Create(obj));
            }
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _repo.Delete(id));
        }
    }
}
