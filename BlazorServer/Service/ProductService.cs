using WebDomain.Entities;

namespace BlazorServer.Service
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
         
        public async Task<List<ProductEntity>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductEntity>>("http://localhost:5134/api/Product/GetList");
        }
        public async Task<ProductEntity> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductEntity>($"http://localhost:5134/api/Product/GetById?id={id}");
        }
        public async Task CreateOrEdit(ProductEntity model)
        {
           await _httpClient.PostAsJsonAsync("http://localhost:5134/api/Product/CreateOrUpdate", model);
          //  return await response.Content.ReadFromJsonAsync<ProductEntity>();
        }
        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"http://localhost:5134/api/Product/id?id={id}");
        }
    }
}
