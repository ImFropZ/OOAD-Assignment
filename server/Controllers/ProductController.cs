using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;
        private readonly DatabaseService _databaseSerivce;

        public ProductController(ILogger<ProductController> logger, DatabaseService databaseService)
        {
            _logger = logger;
            _databaseSerivce = databaseService;
            _productService = new ProductService(databaseService);
        }

        [HttpGet]
        public ActionResult<Result<IEnumerable<Product>>> GetProducts()
        {
            _logger.LogInformation("GET: Products");
            return Ok(new Result<IEnumerable<Product>>(_productService.Get().Result));
        }

        [HttpGet("{id}")]
        public ActionResult<Result<Product?>> GetProductById(int id)
        {
            _logger.LogInformation($"GET: Product by id = {id}");
            return Ok(new Result<Product?>(_productService.Get(id).Result));
        }

        [HttpPost]
        public ActionResult<Result<Product?>> CreateProduct([FromBody] ProductCreated product)
        {
            _logger.LogInformation("CREATE: Product");
            return Ok(new Result<Product?>(_productService.Post(product).Result));
        }

        [HttpPut]
        public ActionResult<Result<IEnumerable<Product>>> UpdateProducts(
            [FromBody] List<ProductUpdated> products
        )
        {
            _logger.LogInformation("UPDATE: Products");
            return Ok(new Result<IEnumerable<Product>>(_productService.Put(products).Result));
        }

        [HttpPatch("{id}")]
        public ActionResult<Result<Product?>> UpdateProductById(
            int id,
            [FromBody] ProductUpdated product
        )
        {
            _logger.LogInformation($"UPDATE: Product by ID = {id}");
            return Ok(new Result<Product?>(_productService.Patch(id, product).Result));
        }

        [HttpDelete("{id}")]
        public ActionResult<Result<bool>> DeleteProductById(int id)
        {
            _logger.LogInformation($"DELETE: Product by ID = {id}");
            return Ok(new Result<bool>(_productService.Delete(id).Result));
        }
    }
}
