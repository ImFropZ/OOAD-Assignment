namespace WinForm.Models
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public Result(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public Result(T data)
        {
            Success = true;
            Message = "Success";
            Data = data;
        }

        public Result() { }
    }
}
