namespace FoodManager.Application.Interfaces.Abstracts
{
    public interface IEmailService
    {
        Task<int> SendEmailAsync(string email);
    }
}
