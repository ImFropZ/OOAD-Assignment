namespace server
{
    public enum HttpMethodEnum
    {
        GET,
        POST,
        PUT,
        PATCH,
        DELETE
    }


    public class Utils
    {
        public string GenerateUUID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
