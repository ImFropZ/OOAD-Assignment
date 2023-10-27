namespace server.Models
{
    public class Supplier
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }

        public Supplier(string id, string name, string contactInformation)
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
        public string ID { get; set; }
        public string? Name { get; set; }
        public string? ContactInformation { get; set; }

        public SupplierUpdated(string id, string? name, string? contactInformation)
        {
            ID = id;
            Name = name;
            ContactInformation = contactInformation;
        }
    }
}
