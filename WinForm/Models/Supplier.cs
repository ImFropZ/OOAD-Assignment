namespace WinForm.Models
{
    public class Supplier
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? ContactInformation { get; set; }
    }

    public class SupplierCreated
    {
        public string? Name { get; set; }
        public string? ContactInformation { get; set; }
    }

    public class SupplierUpdated
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? ContactInformation { get; set; }
    }
}
