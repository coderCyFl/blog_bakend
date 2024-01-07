namespace blog_bakend.DTOs.ResponseDTOs
{
    public class ErrorDto
    {
        public int ErrorCode { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        
        public string Trace { get; set; }
    }
}
