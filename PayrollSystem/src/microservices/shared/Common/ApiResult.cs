namespace PayrollSystem.src.microservices.shared.Common
{
    public class ApiResult<T>
    {
        public ApiResult()
        {
            ResponseCode = -1;
            Message = string.Empty;
            ErrorDesc = string.Empty;
            ResponseData = new List<T>();
        }

        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public string ErrorDesc { get; set; }
        public List<T> ResponseData { get; set; }
    }
}
