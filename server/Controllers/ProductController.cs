using Microsoft.AspNetCore.Mvc;
using server.Data;
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

        public ProductController(ILogger<ProductController> logger, InventoryDbContext _databaseService)
        {
            _logger = logger;
            _productService = new ProductService(_databaseService);
        }

        [HttpGet]
        public ActionResult<Result<IEnumerable<Product>>> GetProducts()
        {
            return Ok(new Result<IEnumerable<Product>>(_productService.GetProducts()));
        }

        [HttpGet("{id}")]
        public ActionResult<Result<Product?>> GetProductById(string id)
        {
            return Ok(new Result<Product?>(_productService.GetProductById(id)));
        }

        [HttpPost]
        public ActionResult<Result<Product?>> CreateProduct([FromBody] ProductCreated product)
        {
            return Ok(new Result<Product?>(_productService.AddProduct(product).Result));
        }

        [HttpPut]
        public ActionResult<Result<IEnumerable<Product>>> UpdateProducts(
            [FromBody] List<ProductUpdated> products
        )
        {
            return Ok(
                new Result<IEnumerable<Product>>(_productService.UpdateProducts(products).Result)
            );
        }

        [HttpPatch("{id}")]
        public ActionResult<Result<Product?>> UpdateProductById(
            string id,
            [FromBody] ProductUpdated product
        )
        {
            return Ok(new Result<Product?>(_productService.UpdateProductById(id, product).Result));
        }

        [HttpDelete("{id}")]
        public ActionResult<Result<bool>> DeleteProductById(string id)
        {
            return Ok(new Result<bool>(_productService.DeleteProductAsync(id).Result));
        }
    }
}
