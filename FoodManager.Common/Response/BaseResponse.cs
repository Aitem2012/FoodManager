namespace FoodManager.Common.Response
{
    public class BaseResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public bool Status { get; set; }

        public BaseResponse<T> CreateResponse(string message, bool status, T data)
        {
            return new BaseResponse<T>
            {
                Message = message,
                Status = status,
                Data = data
            };
        }
    }
}
