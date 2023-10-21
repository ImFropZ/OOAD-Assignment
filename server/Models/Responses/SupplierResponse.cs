namespace server.Models.Responses
{
    public class SupplierResponse : Response
    {

        public List<Supplier> suppliers { get; set; }

        public SupplierResponse(string error_code, string error_message, string error_description, List<Supplier> suppliers) : base(error_code, error_message, error_description)
        {
            this.suppliers = suppliers;
        }
    }
}
