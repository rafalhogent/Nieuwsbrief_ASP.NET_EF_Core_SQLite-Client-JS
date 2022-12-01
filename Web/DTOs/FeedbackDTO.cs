namespace Web.DTOs
{
    public class FeedbackDTO
    {
        public FeedbackDTO(bool isSuccess, string? message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; set; } = false;
        public string? Message { get; set; }

    }
}
