using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

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
        public ActionResult<Result<IEnumerable<SupplierResponse>>> GetSuppliers()
        {
            var suppliers = _service.GetSuppliers();
            var response = new List<SupplierResponse>();

            foreach (var supplier in suppliers)
            {
                response.Add(new SupplierResponse()
                {
                    Id = supplier.Id,
                    Name = supplier.Name,
                    ContactInformation = supplier.ContactInformation,
                });
            }

            return Ok(new Result<List<SupplierResponse>>(response));
        }

        [HttpGet("{id}")]
        public ActionResult<Result<SupplierResponse?>> GetSupplierById(string id)
        {
            var supplier = _service.GetSupplier(id);
            if (supplier == null)
                return NotFound(new Result<SupplierResponse?>(null));

            return Ok(new Result<SupplierResponse?>(new()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactInformation = supplier.ContactInformation,
            }));

        }

        [HttpPost]
        public ActionResult<Result<SupplierResponse?>> CreateSupplier(SupplierCreated payload)
        {
            var supplier = _service.AddSupplier(payload).Result;

            return Created($"{Request.GetDisplayUrl()}/{supplier.Id}", new Result<SupplierResponse?>(new()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactInformation = supplier.ContactInformation
            }));
        }

        [HttpPut]
        public ActionResult<Result<IEnumerable<SupplierResponse>>> UpdateSupplierById(
            [FromBody] List<SupplierUpdated> suppliers
        )
        {
            var updatedSuppliers = _service.UpdateSuppliers(suppliers).Result;
            var response = new List<SupplierResponse>();

            foreach (var supplier in updatedSuppliers)
            {
                response.Add(new SupplierResponse()
                {
                    Id = supplier.Id,
                    Name = supplier.Name,
                    ContactInformation = supplier.ContactInformation
                });
            }

            return Ok(
                new Result<List<SupplierResponse>>(response)
            );
        }

        [HttpPatch("{id}")]
        public ActionResult<Result<SupplierResponse?>> UpdateSupplierById(string id, SupplierUpdated payload)
        {
            var supplier = _service.GetSupplier(id);
            if (supplier == null)
                return NotFound(new Result<SupplierResponse?>(null));

            var updatedSupplier = _service.UpdateSupplier(id, payload).Result;
            if (updatedSupplier == null)
                return NotFound(new Result<SupplierResponse?>(null));

            var response = new SupplierResponse()
            {
                Id = updatedSupplier.Id,
                Name = updatedSupplier.Name,
                ContactInformation = updatedSupplier.ContactInformation
            };

            return Ok(new Result<SupplierResponse?>(response));
        }

        [HttpDelete("{id}")]
        public ActionResult<Result<bool>> DeleteSupplierById(string id)
        {
            try
            {
                return Ok(new Result<bool>(_service.DeleteSupplier(id).Result));
            }
            catch (Exception e)
            {
                return BadRequest(new Result<bool>(false, e.Message, false));
            }
        }
    }
}
