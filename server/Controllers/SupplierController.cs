using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;
using Microsoft.AspNetCore.Http.Extensions;

namespace server.Controllers
{
    [ApiController]
    [Route("api/suppliers")]
    public class SupplierController : Controller
    {
        private readonly SupplierService _service;

        public SupplierController(SupplierService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<Result<IEnumerable<Supplier>>> GetSuppliers()
        {
            return Ok(new Result<List<Supplier>>(_service.GetSuppliers()));
        }

        [HttpGet("{id}")]
        public ActionResult<Result<Supplier?>> GetSupplierById(string id)
        {
            return Ok(new Result<Supplier?>(_service.GetSupplier(id)));
        }

        [HttpPost]
        public ActionResult<Result<Supplier?>> CreateSupplier(SupplierCreated payload)
        {
            var supplier = _service.AddSupplier(payload).Result;
            return Created($"{Request.GetDisplayUrl()}/{supplier.Id}", new Result<Supplier?>(supplier));
        }

        [HttpPut]
        public ActionResult<Result<IEnumerable<Supplier>>> UpdateSupplierById(
            [FromBody] List<SupplierUpdated> suppliers
        )
        {
            return Ok(
                new Result<List<Supplier>>(_service.UpdateSuppliers(suppliers).Result)
            );
        }

        [HttpPatch("{id}")]
        public ActionResult<Result<Supplier?>> UpdateSupplierById(string id, SupplierUpdated payload)
        {
            return Ok(new Result<Supplier?>(_service.UpdateSupplier(id, payload).Result));
        }

        [HttpDelete("{id}")]
        public ActionResult<Result<bool>> DeleteSupplierById(string id)
        {
            return Ok(new Result<bool>(_service.DeleteSupplier(id).Result));
        }
    }
}
