﻿using server.Models;
using server.Data;
using server.Exceptions;

namespace server.Services
{
    public class SupplierService
    {
        private readonly InventoryDbContext _service;

        public SupplierService(InventoryDbContext service)
        {
            _service = service;
        }

        public List<Supplier> GetSuppliers()
        {
            var suppliers = _service.Suppliers?.ToList();
            return suppliers ?? new List<Supplier>();
        }

        public Supplier GetSupplier(string id)
        {
            var supplier = _service.Suppliers?.FirstOrDefault(s => s.ID == id) ?? throw new NotFoundException("Supplier not found");
            return supplier;
        }

        public async Task<Supplier> AddSupplier(SupplierCreated supplier)
        {
            var newSupplier = new Supplier()
            {
                ID = Guid.NewGuid().ToString(),
                Name = supplier.Name,
                ContactInformation = supplier.ContactInformation
            };

            _service.Suppliers?.Add(newSupplier);
            await _service.SaveChangesAsync();

            return newSupplier;
        }

        public async Task<Supplier?> UpdateSupplier(string id, SupplierUpdated supplier)
        {
            if (supplier.Name == null && supplier.ContactInformation == null) throw new BadRequestException("No fields to update");
            var updatedSupplier = _service.Suppliers?.FirstOrDefault(s => s.ID == id);

            if (updatedSupplier != null)
            {
                if (supplier.Name != null) updatedSupplier.Name = supplier.Name;
                if (supplier.ContactInformation != null) updatedSupplier.ContactInformation = supplier.ContactInformation;

                await _service.SaveChangesAsync();
            }

            return updatedSupplier;
        }

        public async Task<List<Supplier>> UpdateSuppliers(List<SupplierUpdated> suppliers)
        {
            var updatedSuppliers = new List<Supplier>();

            foreach (var supplier in suppliers)
            {
                if (supplier.ID == null || supplier.Name == null && supplier.ContactInformation == null) continue;
                var updatedSupplier = await UpdateSupplier(supplier.ID, supplier);

                if (updatedSupplier != null)
                    updatedSuppliers.Add(updatedSupplier);
            }

            return updatedSuppliers;
        }

        public async Task<bool> DeleteSupplier(string id)
        {
            var supplier = _service.Suppliers?.FirstOrDefault(s => s.ID == id) ?? throw new NotFoundException("Supplier not found");

            _service.Suppliers?.Remove(supplier);
            await _service.SaveChangesAsync();
            return true;
        }
    }
}
