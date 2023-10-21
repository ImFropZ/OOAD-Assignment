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
        public ActionResult<IEnumerable<Product>> Get()
        {
            // Wait get method to finish before returning
            return Ok(_productService.Get().Result);
        }

        [HttpGet("{id}")]
        public ActionResult<Product?> Get(int id)
        {
            return Ok(_productService.Get(id).Result);
        }

        [HttpPost]
        public ActionResult<ProductCreated?> Post([FromBody] ProductCreated product)
        {
            return Ok(_productService.Post(product).Result);
        }

        [HttpPut]
        public ActionResult<IEnumerable<ProductUpdated>> Put(
            [FromBody] List<ProductUpdated> products
        )
        {
            return Ok(_productService.Put(products).Result);
        }

        [HttpPatch("{id}")]
        public ActionResult<Product?> Patch(int id, [FromBody] ProductUpdated product)
        {
            return Ok(_productService.Patch(id, product).Result);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(_productService.Delete(id).Result);
        }
    }
}
