namespace FoodManager.Services.Abstracts
{
    public interface IEmailService
    {
        Task<int> SendEmailAsync(string email);
    }
}
