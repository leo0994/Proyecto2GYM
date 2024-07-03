namespace DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }

    public static class ResponseHelper
    {
        public static ApiResponse<T> CreateResponse<T>(bool success, string message, T data)
        {
            return new ApiResponse<T>(success, message, data);
        }

        public static ApiResponse<T> Success<T>(T data, string message = "Request successful.")
        {
            return new ApiResponse<T>(true, message, data);
        }

        public static ApiResponse<T> Error<T>(string message, T data = default)
        {
            return new ApiResponse<T>(false, message, data);
        }
    }
}