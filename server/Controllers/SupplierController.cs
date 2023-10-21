using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Models.Responses;
using server.Services;
using server.Utils;

namespace server.Controllers
{
    [ApiController]
    [Route("api/suppliers")]
    public class SupplierController : Controller
    {
        private SupplierService supplierService;

        public SupplierController(SupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        // GET: SupplierController
        [HttpGet]
        public ActionResult<SupplierResponse> GetSuppliers()
        {
            List<Supplier> suppliers = supplierService.GetSuppliers();

            SupplierResponse response = new SupplierResponse("0001", "fail", "failed to fetch suppliers", suppliers);

            if (suppliers.Count <= 0)
            {
                return BadRequest(response);
            }

            response = new SupplierResponse("0000", "success", "successfully fetching supplier", suppliers);

            return Ok(response);
        }

        // GET: By ID
        [HttpGet("{id}")]
        public ActionResult<SupplierResponse> GetSupplierById(int id)
        {
            // Get data from suplliers array
            Supplier supplier = supplierService.GetSupplier(id);

            if (supplier == null)
            {
                SupplierResponse errorResponse = new SupplierResponse("0001", "fail", "supplier: " + id + " not found", null);
                return NotFound(errorResponse);
            }

            List<Supplier> foundSupplier = new List<Supplier> { supplier };
            SupplierResponse response = new SupplierResponse("0000", "success", "successfully fetching supplier", foundSupplier);

            return Ok(response);
        }

        // Create
        [HttpPost]
        public ActionResult<Response> CreateSupplier(Supplier payload)
        {
            string validationMessage = new PayloadValidator().ValidateSupplier(payload);
            Response response;

            if (validationMessage != "")
            {
                response = new Response("0001", "fail", validationMessage);
                return BadRequest(response);
            }

            supplierService.AddSupplier(payload);

            response = new Response("0000", "success", "successfully created");
            return Ok(response);
        }

        // Delete
        [HttpDelete("{id}")]
        public ActionResult<Response> DeleteSupplierById(int id)
        {
            // Get data from suplliers array
            Supplier supplier = supplierService.GetSupplier(id);
            Response response;

            if (supplier == null)
            {
                response = new Response("0001", "fail", "supplier: " + id + " not found");
                return NotFound(response);
            }

            Boolean isSupplierRemoved = supplierService.DeleteSupplier(supplier);

            if (isSupplierRemoved)
            {
                response = new Response("0000", "success", "successfully deleted supplier");
            }
            else
            {
                response = new Response("0001", "fail", "failed to delete supplier");
            }

            return Ok(response);
        }

        // Edit One Supplier
        [HttpPatch("{id}")]
        public ActionResult<Response> EditSupplierById(int id, Supplier payload)
        {
            string validationMessage = new PayloadValidator().ValidateSupplier(payload);
            Response response;

            if (validationMessage != "")
            {
                response = new Response("0001", "fail", validationMessage);
                return BadRequest(response);
            }

            Supplier supplier = supplierService.GetSupplier(id);

            if (supplier == null)
            {
                response = new Response("0001", "fail", "supplier: " + id + " not found");
                return NotFound(response);
            }

            supplierService.ModifySupplier(id, payload);

            response = new Response("0000", "success", "successfully modified");
            return Ok(response);
        }

    }
}
