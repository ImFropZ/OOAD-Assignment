using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;
using Microsoft.AspNetCore.Http.Extensions;

namespace server.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<Result<IEnumerable<Product>>> GetProducts()
        {
            return Ok(new Result<IEnumerable<Product>>(_service.GetProducts()));
        }

        [HttpGet("{id}")]
        public ActionResult<Result<Product?>> GetProductById(string id)
        {
            return Ok(new Result<Product?>(_service.GetProductById(id)));
        }

        [HttpPost]
        public ActionResult<Result<Product?>> CreateProduct([FromBody] ProductCreated payload)
        {
            var product = _service.AddProduct(payload).Result;
            return Created($"{Request.GetDisplayUrl()}/{product.Id}", new Result<Product?>(product));
        }

        [HttpPut]
        public ActionResult<Result<IEnumerable<Product>>> UpdateProducts(
            [FromBody] List<ProductUpdated> products
        )
        {
            return Ok(
                new Result<IEnumerable<Product>>(_service.UpdateProducts(products).Result)
            );
        }

        [HttpPatch("{id}")]
        public ActionResult<Result<Product?>> UpdateProductById(
            string id,
            [FromBody] ProductUpdated product
        )
        {
            return Ok(new Result<Product?>(_service.UpdateProductById(id, product).Result));
        }

        [HttpDelete("{id}")]
        public ActionResult<Result<bool>> DeleteProductById(string id)
        {
            return Ok(new Result<bool>(_service.DeleteProductAsync(id).Result));
        }
    }
}
