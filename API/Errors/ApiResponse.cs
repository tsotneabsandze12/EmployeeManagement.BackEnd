using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }


        public int StatusCode { get; set; }
        public string Message { get; set; }


        private static string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request",
                401 => "Not authorized",
                404 => "Resource was not found",
                500 => "Server error",
                _ => null
            };
        }
    }
}