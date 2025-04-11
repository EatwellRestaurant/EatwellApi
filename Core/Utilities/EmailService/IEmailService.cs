using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Email
{
    public interface IEmailService
    {
        Task<object> SendEmailAsync(string toEmail, string toName, string code);

    }
}
