using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ResponseModels;
using Microsoft.EntityFrameworkCore.Metadata;
using brevo_csharp.Model;
using brevo_csharp.Api;
using brevo_csharp.Client;

namespace Core.Utilities.Email.Sendinblue
{
    public class SendinblueService : IEmailService
    {
        SendinblueSettings _sendinblueSettings;


        public SendinblueService(IConfiguration configuration)
        {
            _sendinblueSettings = configuration.GetSection("SendinblueSettings").Get<SendinblueSettings>()!;

            Configuration.Default.ApiKey.Add("api-key", _sendinblueSettings.ApiKey);
        }


        public async Task<object> SendEmailAsync(string toEmail, string toName, string code)
        {
            SendSmtpEmailSender sender = new()
            {
                Name = _sendinblueSettings.SenderName,
                Email = _sendinblueSettings.SenderEmail
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
                                    <body style=""font-family: Arial, sans-serif; background-color: #f9f9f9; padding: 20px; color: #333;"">
                                        <div style=""max-width: 600px; margin: auto; background-color: #ffffff; padding: 30px; border-radius: 8px; box-shadow: 0 2px 8px rgba(0, 0, 0, 0.1);"">
                                            <h1 style=""color: #28a745;"">Merhaba {toName},</h1>
                                            <p>Hesabını güvence altına almak için aşağıdaki doğrulama kodunu kullanabilirsin:</p>
                                            <p style=""margin: 20px 0; text-align: center;"">
                                                <span style=""display: inline-block; background-color: #eaf9f0; color: #28a745; font-size: 24px; font-weight: bold; padding: 12px 24px; border-radius: 6px;"">{code}</span>
                                            </p>
                                            <p>Lütfen bu kodu ilgili alana girerek hesabını doğrula. Güvenliğin için, kod yalnızca <strong>3 dakika</strong> boyunca geçerli olacaktır.</p>
                                            <p>Eğer bu işlemi sen başlatmadıysan, bu e-postayı görmezden gelebilirsin. Herhangi bir işlem yapılmayacaktır.</p>
                                            <p>Teşekkürler</p>
                                            <p><strong>EATWELL Ekibi</strong></p>
                                            <hr style=""margin-top: 30px; border: none; border-top: 1px solid #eee;"" />
                                            <p style=""font-size: 12px; color: #777; text-align: center;"">Bu e-posta otomatik olarak gönderilmiştir, lütfen yanıtlamayın.</p>
                                        </div>
                                    </body>
                                </html>"
            };


            TransactionalEmailsApi apiInstance = new();

            return await apiInstance.SendTransacEmailAsync(sendSmtpEmail);
        }


    }
}
