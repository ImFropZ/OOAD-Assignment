namespace server.Models.Responses
{
    public class Response
    {
        public string error_code { get; set; }
        public string error_message { get; set; }
        public string error_description { get; set; }

        public Response(string error_code, string error_message, string error_description)
        {
            this.error_code = error_code;
            this.error_message = error_message;
            this.error_description = error_description;
        }
    }
}
