namespace server.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }

        public Supplier(int id, string name, string contactInformation)
        {
            ID = id;
            Name = name;
            ContactInformation = contactInformation;
        }
    }

    public class SupplierCreated
    {
        public string Name { get; set; }
        public string ContactInformation { get; set; }

        public SupplierCreated(string name, string contactInformation)
        {
            Name = name;
            ContactInformation = contactInformation;
        }
    }

    public class SupplierUpdated
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? ContactInformation { get; set; }

        public SupplierUpdated(int id, string? name, string? contactInformation)
        {
            ID = id;
            Name = name;
            ContactInformation = contactInformation;
        }
    }
}
