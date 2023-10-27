using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api/suppliers")]
    public class SupplierController : Controller
    {
        private readonly SupplierService _supplierService;

        public SupplierController(DatabaseService _databaseService)
        {
            _supplierService = new SupplierService(_databaseService);
        }

        [HttpGet]
        public ActionResult<Result<IEnumerable<Supplier>>> GetSuppliers()
        {
            return Ok(new Result<List<Supplier>>(_supplierService.GetSuppliers().Result));
        }

        [HttpGet("{id}")]
        public ActionResult<Result<Supplier?>> GetSupplierById(string id)
        {
            return Ok(new Result<Supplier?>(_supplierService.GetSupplier(id).Result));
        }

        [HttpPost]
        public ActionResult<Result<Supplier?>> CreateSupplier(SupplierCreated payload)
        {
            return Ok(new Result<Supplier?>(_supplierService.AddSupplier(payload).Result));
        }

        [HttpPut]
        public ActionResult<Result<IEnumerable<Supplier>>> UpdateSupplierById(
            [FromBody] List<SupplierUpdated> suppliers
        )
        {
            return Ok(
                new Result<List<Supplier>>(_supplierService.UpdateSuppliers(suppliers).Result)
            );
        }

        [HttpPatch("{id}")]
        public ActionResult<Result<Supplier?>> UpdateSupplierById(string id, SupplierUpdated payload)
        {
            return Ok(new Result<Supplier?>(_supplierService.UpdateSupplier(id, payload).Result));
        }

        [HttpDelete("{id}")]
        public ActionResult<Result<bool>> DeleteSupplierById(string id)
        {
            return Ok(new Result<bool>(_supplierService.DeleteSupplier(id).Result));
        }
    }
}
