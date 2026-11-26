using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productService;
        public ProductsController(IProductsService productService)
        {
            this.productService = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Get(int position, int skip, string? desc,
    decimal? minPrice, decimal? maxPrice, [FromQuery] int?[] categoryIds)
        {

            var (items, totalCount) = await productService.GetAllProducts(position, skip, desc,
                minPrice, maxPrice, categoryIds);

            return Ok(new { items, totalCount });
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await productService.GetProductById(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
