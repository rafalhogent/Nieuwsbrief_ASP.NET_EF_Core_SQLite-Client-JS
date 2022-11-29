namespace Core.Interfaces
{
    public interface IEmailingService
    {
        Task SendEmailAsync(string email);
    }
}