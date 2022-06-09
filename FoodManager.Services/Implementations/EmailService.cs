using FoodManager.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManager.Services.Implementations
{
    public class EmailService : IEmailService
    {
        public Task<int> SendEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
