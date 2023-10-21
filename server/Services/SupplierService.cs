using server.Models;

namespace server.Services
{
    public class SupplierService
    {
        // Mock data
        public List<Supplier> suppliers = new List<Supplier>
        {
            new Supplier
            {
                ID = 1,
                Name = "Hello",
                ContactInformation = "838383838"
            }
        };

        public List<Supplier> GetSuppliers()
        {
            return suppliers;
        }

        public Supplier GetSupplier(int id)
        {
            return suppliers.Find(supplier => supplier.ID == id);
        }

        public void AddSupplier(Supplier supplier)
        {
            // remove this if database is implemented
            supplier.ID = suppliers.Count + 1;

            suppliers.Add(supplier);
        }

        public Boolean DeleteSupplier(Supplier supplier)
        {
            return suppliers.Remove(supplier);
        }

        public void ModifySupplier(int id, Supplier payload)
        {
            Supplier foundSupplier = GetSupplier(id);
            int index = GetSupplierIndex(foundSupplier);

            suppliers[index].Name = payload.Name;
            suppliers[index].ContactInformation = payload.ContactInformation;
        }

        public int GetSupplierIndex(Supplier supplier)
        {
            return suppliers.IndexOf(supplier);
        }
    }
}
