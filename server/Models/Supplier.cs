using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Supplier
    {
        [Required, Key] public string? ID { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public string? ContactInformation { get; set; }
    }

    public class SupplierCreated
    {
        [Required] public string? Name { get; set; }
        [Required] public string? ContactInformation { get; set; }
    }

    public class SupplierUpdated
    {
        public string? ID { get; set; }
        [Required] public string? Name { get; set; }
        [Required] public string? ContactInformation { get; set; }
    }
}
