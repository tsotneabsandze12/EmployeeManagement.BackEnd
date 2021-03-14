namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        public ApiException(int statusCode, string message=null, string details=null)
            :base(statusCode,message)
        {
            Details = null;
        }

        public string Details { get; set; }      
    }
}