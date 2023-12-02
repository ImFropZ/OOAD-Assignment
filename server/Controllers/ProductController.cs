using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

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
        public ActionResult<Result<IEnumerable<ProductResponse>>> GetProducts()
        {
            var products = _service.GetProducts();
            var response = new List<ProductResponse>();

            foreach (var product in products)
            {
                response.Add(new ProductResponse()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    Categories = product.Categories,
                    SupplierId = product.SupplierId,

                });
            }
            return Ok(new Result<IEnumerable<ProductResponse>>(response));
        }

        [HttpGet("{id}")]
        public ActionResult<Result<ProductResponse?>> GetProductById(string id)
        {
            var product = _service.GetProductById(id);

            if (product == null)
                return NotFound(new Result<ProductResponse?>(null));

            var response = new ProductResponse()
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Categories = product.Categories,
                SupplierId = product.SupplierId,
            };

            return Ok(new Result<ProductResponse?>(response));
        }

        [HttpPost]
        public ActionResult<Result<ProductResponse?>> CreateProduct([FromBody] ProductCreated payload)
        {
            var product = _service.AddProduct(payload).Result;
            return Created($"{Request.GetDisplayUrl()}/{product.Id}", new Result<ProductResponse?>(new()
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Categories = product.Categories,
                SupplierId = product.SupplierId,
            }));
        }

        [HttpPut]
        public ActionResult<Result<IEnumerable<ProductResponse>>> UpdateProducts(
            [FromBody] List<ProductUpdated> products
        )
        {
            var updatedProducts = _service.UpdateProducts(products).Result;
            var response = new List<ProductResponse>();

            foreach (var product in updatedProducts)
            {
                response.Add(new ProductResponse()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    Categories = product.Categories,
                    SupplierId = product.SupplierId,
                });
            }

            return Ok(
                new Result<IEnumerable<ProductResponse>>(response)
            );
        }

        [HttpPatch("{id}")]
        public ActionResult<Result<ProductResponse?>> UpdateProductById(
            string id,
            [FromBody] ProductUpdated product
        )
        {
            var updatedProduct = _service.UpdateProductById(id, product).Result;
            if (updatedProduct == null)
                return NotFound(new Result<ProductResponse?>(null));

            return Ok(new Result<ProductResponse?>(new()
            {
                Id = updatedProduct.Id,
                Name = updatedProduct.Name,
                Quantity = updatedProduct.Quantity,
                Price = updatedProduct.Price,
                Categories = updatedProduct.Categories,
                SupplierId = product.SupplierId
            }));
        }

        [HttpDelete("{id}")]
        public ActionResult<Result<bool>> DeleteProductById(string id)
        {
            return Ok(new Result<bool>(_service.DeleteProductAsync(id).Result));
        }
    }
}
