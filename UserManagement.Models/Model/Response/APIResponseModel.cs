namespace UserManagement.Model.Response
{
    public class APIResponseModel<T> : ResponseData
    {
        public T Data { get; set; }
    }

    public class ResponseData
    {
        public int ResponseCode { get; set; }  
        public bool IsError { get; set; }

        public String ErrorMessage { get; set; }
    }
}
