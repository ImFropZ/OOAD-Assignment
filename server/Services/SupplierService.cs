using server.Models;
using server.Exceptions;

namespace server.Services
{
    public class SupplierService
    {
        private readonly IDbContext _context;

        public SupplierService(IDbContext context)
        {
            _context = context;
        }

        public List<Supplier> GetSuppliers()
        {
            var suppliers = _context.Suppliers?.ToList();
            return suppliers ?? new List<Supplier>();
        }

        public Supplier GetSupplier(string id)
        {
            var supplier = _context.Suppliers?.FirstOrDefault(s => s.Id == id) ?? throw new NotFoundException("Supplier not found");
            return supplier;
        }

        public async Task<Supplier> AddSupplier(SupplierCreated supplier)
        {
            var newSupplier = new Supplier()
            {
                Id = Guid.NewGuid().ToString(),
                Name = supplier.Name,
                ContactInformation = supplier.ContactInformation
            };

            _context.Suppliers?.Add(newSupplier);
            _context.SaveChanges();

            return newSupplier;
        }

        public async Task<Supplier?> UpdateSupplier(string id, SupplierUpdated supplier)
        {
            if (supplier.Name == null && supplier.ContactInformation == null) throw new BadRequestException("No fields to update");
            var updatedSupplier = _context.Suppliers?.FirstOrDefault(s => s.Id == id);

            if (updatedSupplier != null)
            {
                if (supplier.Name != null) updatedSupplier.Name = supplier.Name;
                if (supplier.ContactInformation != null) updatedSupplier.ContactInformation = supplier.ContactInformation;

                _context.SaveChanges();
            }

            return updatedSupplier;
        }

        public async Task<List<Supplier>> UpdateSuppliers(List<SupplierUpdated> suppliers)
        {
            var updatedSuppliers = new List<Supplier>();

            foreach (var supplier in suppliers)
            {
                if (supplier.Id == null || supplier.Name == null && supplier.ContactInformation == null) continue;
                var updatedSupplier = await UpdateSupplier(supplier.Id, supplier);

                if (updatedSupplier != null)
                    updatedSuppliers.Add(updatedSupplier);
            }

            return updatedSuppliers;
        }

        public async Task<bool> DeleteSupplier(string id)
        {
            var supplier = _context.Suppliers?.FirstOrDefault(s => s.Id == id) ?? throw new NotFoundException("Supplier not found");

            _context.Suppliers?.Remove(supplier);
            _context.SaveChanges();
            return true;
        }
    }
}
