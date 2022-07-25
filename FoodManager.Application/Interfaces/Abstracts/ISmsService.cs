namespace FoodManager.Application.Interfaces.Abstracts
{
    public interface ISmsService
    {
        Task<Task> SendSmsAsync(string mobileNumber);
    }
}
