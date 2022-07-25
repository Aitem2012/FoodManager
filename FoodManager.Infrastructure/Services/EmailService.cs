using FoodManager.Application.Interfaces.Abstracts;

namespace FoodManager.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public Task<int> SendEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
