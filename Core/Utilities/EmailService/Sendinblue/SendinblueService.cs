using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using Core.ResponseModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core.Utilities.Email.Sendinblue
{
    public class SendinblueService : IEmailService
    {
        SendinblueSettings _brevoSettings;


        public SendinblueService(IConfiguration configuration)
        {
            _brevoSettings = configuration.GetSection("BrevoSettings").Get<SendinblueSettings>()!;

            Configuration.Default.ApiKey.Add("api-key", _brevoSettings.ApiKey);
        }


        public async Task<object> SendEmailAsync(string toEmail, string toName, string code)
        {
            SendSmtpEmailSender sender = new()
            {
                Name = _brevoSettings.SenderName,
                Email = _brevoSettings.SenderEmail
            };


            List<SendSmtpEmailTo> toList = new()
            {
                new SendSmtpEmailTo(toEmail, toName)
            };


            SendSmtpEmail sendSmtpEmail = new()
            {
                Sender = sender,
                To = toList,
                Subject = "EATWELL - Hesap Doğrulama Kodu",
                HtmlContent = $@"<html>
                                    <body>
                                        <h1>Merhaba {toName},</h1>
                                        <p>Hesabınızı doğrulamak için aşağıdaki doğrulama kodunu kullanabilirsin:</p>
                                        <h2 style=""color: #28a745; font-size: 24px; font-weight: bold;"">{code}</h2>
                                        <p>Bu kodu ilgili alana girerek hesabını doğrulayabilirsin. Kod yalnızca 3 dakika geçerli olacaktır.</p>
                                        <p>Eğer bu işlemi siz yapmadıysan, bu e-postayı göz ardı edebilirsin.</p>
                                        <p>Teşekkürler./p>
                                        <p>EATWELL Ekibi</p>
                                    </body>
                                </html>"
            };


            TransactionalEmailsApi apiInstance = new();

            return await apiInstance.SendTransacEmailAsync(sendSmtpEmail);
        }


    }
}
