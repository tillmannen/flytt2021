using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using flytt2021.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flytt2021.Account
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor, IOptions<AzureKeyVaultSettings> azureKeyVaultSettings)
        {
            AuthMessageSenderOptions = optionsAccessor.Value;
            AzureKeyVaultSettings = azureKeyVaultSettings.Value;
        }

        public AuthMessageSenderOptions AuthMessageSenderOptions { get; }
        public AzureKeyVaultSettings AzureKeyVaultSettings { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            if (AzureKeyVaultSettings.UseAzureKeyVault)
            {
                if (string.IsNullOrWhiteSpace(AzureKeyVaultSettings.AzureKeyVaultUri))
                {
                    throw new ArgumentException("AzureKeyVaultUri is required");
                }

                if (string.IsNullOrWhiteSpace(AzureKeyVaultSettings.SendGridKey))
                {
                    throw new ArgumentException("SendGridKey is required");
                }

                var secretClient = new SecretClient(new Uri(AzureKeyVaultSettings.AzureKeyVaultUri), new ManagedIdentityCredential());
                var secret = secretClient.GetSecret(AzureKeyVaultSettings.SendGridKey).Value;
                AuthMessageSenderOptions.SendGridKey = secret.Value;
            }

            return Execute(AuthMessageSenderOptions.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(AuthMessageSenderOptions.FromEmailAddress, AuthMessageSenderOptions.FromFriendlyName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
