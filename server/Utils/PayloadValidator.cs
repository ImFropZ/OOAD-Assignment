using server.Models;

namespace server.Utils
{
    public class PayloadValidator
    {
        public string ValidateSupplier(Supplier payload)
        {
            if (payload.Name == null || payload.Name == "")
            {
                return "Name is requied !";
            }

            if (payload.ContactInformation == null || payload.ContactInformation == "")
            {
                return "Contact Information is required !";
            }

            return "";
        }
    }
}
