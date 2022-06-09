namespace FoodManager.Services.Abstracts
{
    public interface ISmsService
    {
        Task<Task> SendSmsAsync(string mobileNumber);
    }
}
