using FoodManager.Application.Interfaces.Abstracts;

namespace FoodManager.Infrastructure.Services
{
    public class SmsService : ISmsService
    {
        public async Task<Task> SendSmsAsync(string mobileNumber)
        {
            //string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            //string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            //string senderContact = Environment.GetEnvironmentVariable("SMS_SENDER_NUMBER");

            //TwilioClient.Init(accountSid, authToken);

            //var message = MessageResource.Create(
            //    body: "Your account has been created on FoodPortal",
            //    from: new Twilio.Types.PhoneNumber(senderContact),
            //    to: new Twilio.Types.PhoneNumber(mobileNumber)
            //);

            return Task.CompletedTask;
        }
    }
}
