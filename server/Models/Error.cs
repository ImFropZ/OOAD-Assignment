namespace server.Error
{
  public class ServerError : Exception
  {
    public int StatusCode { get; set; }

    public ServerError(string message, int statusCode = 200) : base(message)
    {
      StatusCode = statusCode;
    }
  }
  public class NotFoundException : ServerError
  {
    public NotFoundException(string message) : base(message, 404) { }
  }

  public class BadRequestException : ServerError
  {
    public BadRequestException(string message) : base(message, 400) { }
  }

  public class InternalException : ServerError
  {
    public InternalException(string message) : base(message, 500) { }
  }
}